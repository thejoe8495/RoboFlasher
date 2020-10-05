using Dlid.MiHome;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using Renci.SshNet;
using RoboFlasher.classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace RoboFlasher {
    public partial class Mainform : MetroForm {
        private OnlineResources valrelease = new OnlineResources();
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Dictionary<string, string> tokens = new Dictionary<string, string>();
        public List<MiDevice> knowndev = new List<MiDevice>();
        public List<MiDevice> discovered = new List<MiDevice>();
        private  Dictionary<string,string> ipbroadcast = new Dictionary<string,string>();
        SimpleHTTPServer ws;
        string progressMiiO = "";

        public Mainform() {
            InitializeComponent();
            loadFiles("webinterface", lstwebinterface, cboWebinterface);
            loadFiles("firmware", lstfirmware, cboFirmware);
            loadFiles("voicepack", lstVoices, cboVoicepacks);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

            if (Properties.Settings.Default.Context.ContainsKey("rsafile"))
                txtRsaKey.Text = Properties.Settings.Default.Context["rsafile"].ToString();
            if (Properties.Settings.Default.Context.ContainsKey("tokens"))
                tokens = (Dictionary<string, string>)Properties.Settings.Default.Context["tokens"];
            loadDevicelist();
            lstdevices.DataSource = knowndev;

            NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface Interface in Interfaces) {
                if (Interface.NetworkInterfaceType == NetworkInterfaceType.Loopback || Interface.OperationalStatus != OperationalStatus.Up) continue;
                Console.WriteLine(Interface.Description);
                UnicastIPAddressInformationCollection UnicastIPInfoCol = Interface.GetIPProperties().UnicastAddresses;
                foreach (UnicastIPAddressInformation UnicatIPInfo in UnicastIPInfoCol) {
                    if (UnicatIPInfo.Address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork) continue;
                    byte[] broadcastIPBytes = new byte[4];
                    byte[] hostBytes = UnicatIPInfo.Address.GetAddressBytes();
                    byte[] maskBytes = UnicatIPInfo.IPv4Mask.GetAddressBytes();
                    for (int i = 0; i < 4; i++) {
                        broadcastIPBytes[i] = (byte)(hostBytes[i] | (byte)~maskBytes[i]);
                    }
                    ipbroadcast.Add(UnicatIPInfo.Address.ToString(), new IPAddress(broadcastIPBytes).ToString());
                }
            }
            string[] keys = new string[ipbroadcast.Keys.Count];
            ipbroadcast.Keys.CopyTo(keys, 0);
            cbolisten.DataSource = keys;
            //ws = new SimpleHTTPServer(6999, cbolisten.SelectedText);
        }
        private void Mainform_FormClosing(object sender, FormClosingEventArgs e) {
            ws.Stop();
            if (Properties.Settings.Default.Context.ContainsKey("rsafile"))
                Properties.Settings.Default.Context.Add("rsafile", txtRsaKey.Text);
            else
                Properties.Settings.Default.Context["rsafile"] = txtRsaKey.Text;

            if (Properties.Settings.Default.Context.ContainsKey("tokens"))
                Properties.Settings.Default.Context.Add("tokens", tokens);
            else
                Properties.Settings.Default.Context["tokens"] = tokens;
            Properties.Settings.Default.Save();
        }

        private void loadFiles(string folder, ListBox lst, ComboBox cbo) {
            List<string> files = loadFiles(folder);
            lst.Items.Clear();
            lst.Items.AddRange(files.ToArray());
            files.Insert(0, "--");
            cbo.Items.Clear();
            cbo.Items.AddRange(files.ToArray());
        }

        private List<string> loadFiles(string folder) {
            List<string> filesandfolders = new List<string>();
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            string[] files = Directory.GetFiles(folder);
            foreach (string file in files) {
                filesandfolders.Add(Path.GetFileName(file));
            }
            string[] dirs = Directory.GetDirectories(folder);
            foreach (string dir in dirs) {
                filesandfolders.Add(Path.GetFileName(dir));
            }
            return filesandfolders;
        }

        private async Task loadDevicelist() {
            if (!File.Exists("devicelist.json"))
                return;
            string devicelist = await Task.FromResult(System.IO.File.ReadAllText("devicelist.json"));
            knowndev = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MiDevice>>(devicelist);
            refreshdevices();
        }

        private void saveDevicelist() {
            string devicelist = Newtonsoft.Json.JsonConvert.SerializeObject(knowndev);
            System.IO.File.WriteAllText("devicelist.json", devicelist);
        }

        private async Task loadRepos() {
            using (var httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("RoborockFlasher", "1.0"));
                HttpResponseMessage response = await httpClient.GetAsync("https://raw.githubusercontent.com/thejoe8495/RoboFlasher/master/Resources.json");
                string res = await response.Content.ReadAsStringAsync();
                valrelease = Newtonsoft.Json.JsonConvert.DeserializeObject<OnlineResources>(res);
            }
            await valrelease.webinterface[1].getReleases();
            lstwebinterface.Items.AddRange(valrelease.webinterface[1].releases.ToArray());
        }

        private void txtToken_TextChanged(object sender, EventArgs e) {
            lblErrorToken.Text = "";
            if (!Regex.IsMatch(txtToken.Text, "^[a-fA-F0-9]{32}$"))
                lblErrorToken.Text = "Sorry token not match: ^[a-fA-F0-9]{32}$";
        }

        private void lstdevices_SelectedIndexChanged(object sender, EventArgs e) {
            if (txtipadress.Text.Length > 0) {
                bool found = false;
                foreach (var item in knowndev) {
                    if (item.IpAddress == txtipadress.Text) {
                        item.Token = txtToken.Text;
                        found = true;
                    }
                }
                if (!found) {
                    MiDevice dev = new MiDevice(txtipadress.Text, txtToken.Text);
                    knowndev.Add(dev);
                }
            }
            if (lstdevices.SelectedIndex > -1) {
                txtipadress.Text = ((MiDevice)lstdevices.SelectedItem).IpAddress;
                txtToken.Text = ((MiDevice)lstdevices.SelectedItem).Token.ToLower();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e) {
            loadFiles("webinterface", lstwebinterface, cboWebinterface);
            loadFiles("firmware", lstfirmware, cboFirmware);
            loadFiles("voicepack", lstVoices, cboVoicepacks);
            //await loadRepos();
        }

        private async void btnWebinterfaceInstall_Click(object sender, EventArgs e) {
            if (lstwebinterface.SelectedIndex == -1) {
                MessageBox.Show("Sprachpaket wurde nicht ausgewählt");
                return;
            } else if (txtipadress.Text.Length == 0) {
                MessageBox.Show("Roborock wurde nicht ausgewählt");
                return;
            }
            var connectionInfo = new ConnectionInfo(txtipadress.Text, "root", new PrivateKeyAuthenticationMethod("root", new PrivateKeyFile(txtRsaKey.Text)));
            btnWebinterfaceInstall.Enabled = false;
            lstwebinterface.Enabled = false;
            txtRsaKey.Enabled = false;
            txtipadress.Enabled = false;
            lstdevices.Enabled = false;
            addtolog("Uploading Frontend");
            string filename = (string)lstwebinterface.SelectedItem;
            bool uploadfailed = false;
            using (var client = new SftpClient(connectionInfo)) {
                try {
                    client.Connect();
                    FileStream fs = new FileStream("webinterface/" + filename, FileMode.Open);
                    await Task.Run(() => client.UploadFile(fs, "/tmp/" + filename));
                } catch (FileNotFoundException fe) {
                    addtolog("Local File Error: " + fe.Message);
                    uploadfailed = true;
                } catch (Renci.SshNet.Common.SshException ssh) {
                    addtolog("SSH Upload Error: " + ssh.Message);
                    uploadfailed = true;
                } catch (Exception ex) {
                    addtolog(ex.Message);
                    uploadfailed = true;
                } finally {
                    client.Disconnect();
                }
            }
            if (uploadfailed) {
                btnWebinterfaceInstall.Enabled = true;
                lstwebinterface.Enabled = true;
                txtRsaKey.Enabled = true;
                txtipadress.Enabled = true;
                lstdevices.Enabled = true;
                return;
            }
            using (var client = new SshClient(connectionInfo)) {
                client.Connect();
                try {
                    if (Path.GetExtension(filename) == ".deb") {
                        addtolog("Installing .deb file");
                        SshCommand cmd = client.RunCommand("dpkg -i /tmp/" + filename);
                        addtolog(cmd.Result);
                    } else {
                        addtolog("Delete Valetudo");
                        client.RunCommand("rm /usr/local/bin/valetudo");
                        addtolog("Move new Valetudo file");
                        client.RunCommand("mv /tmp/" + filename + " /usr/local/bin/valetudo");
                        addtolog("Kill current running Valetudo for auto respawn");
                        client.RunCommand("kill $(ps aux | grep '/usr/local/bin/valetudo' | awk '{print $2}')");
                    }
                } catch (Renci.SshNet.Common.SshException ssh) {
                    addtolog("SSH Upload Error: " + ssh.Message);
                } finally {
                    client.Disconnect();
                }
            }
            btnWebinterfaceInstall.Enabled = true;
            lstwebinterface.Enabled = true;
            txtRsaKey.Enabled = true;
            txtipadress.Enabled = true;
            lstdevices.Enabled = true;
        }

        private void btnSearchKey_Click(object sender, EventArgs e) {
            openFileDialog1.DefaultExt = "";
            openFileDialog1.Title = "Open SSH Key File";
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
                txtRsaKey.Text = openFileDialog1.FileName;
        }

        private void btnGenerateNew_Click(object sender, EventArgs e) {
            var keygen = new SshKeyGenerator.SshKeyGenerator(1024);

            System.IO.File.WriteAllText(txtRsaKey.Text, keygen.ToPrivateKey());
            System.IO.File.WriteAllText(txtRsaKey.Text + ".pub", keygen.ToRfcPublicKey("RoboFlasher"));
            Clipboard.SetText(keygen.ToRfcPublicKey("RoboFlasher"));
            MetroFramework.MetroMessageBox.Show(this, "Key generated please copy the key to Valetudo webinterface\nPublic key is copied to clipboard\n\n " + keygen.ToRfcPublicKey("RoboFlasher"), "Public Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // GZip.Compress(File.OpenRead(parser.Source), File.Create(parser.Target), true, parser.Level);

        }

        private void mergeDevices() {
            bool found = false;
            foreach (var disitem in discovered) {
                foreach (var item in knowndev) {
                    if (item.SerialID == disitem.SerialID && item.TypeID == disitem.TypeID) {
                        item.IpAddress = disitem.IpAddress;
                        item.SerialID = disitem.SerialID;
                        item.TypeID = disitem.TypeID;
                        found = true;
                    }
                }
                if (!found) {
                    knowndev.Add(disitem);
                }
            }
        }

        private void refreshdevices() {
            lstdevices.SelectedIndex = -1;
            lstdevices.DataSource = null;
            if (chkAllKnown.Checked)
                lstdevices.DataSource = knowndev;
            else
                lstdevices.DataSource = discovered;
            lstdevices.DisplayMember = "Devicename";
            if (lstdevices.Items.Count > 0) lstdevices_SelectedIndexChanged(null, null);
        }

        private async void btndiscover_Click(object sender, EventArgs e) {
            addtolog("Scan for Xiaomi Devices");
            string broad = "";
            ipbroadcast.TryGetValue(cbolisten.SelectedValue.ToString(), out broad);
            var test2 = new MiDiscover(broad);
            await Task.Run(test2.Discover);
            foreach (var item in test2.Devices) {
                addtolog(item.IpAddress + ": " + item.Token);
            }
            discovered = test2.Devices;
            mergeDevices();
            saveDevicelist();
            refreshdevices();
            addtolog("Scan for Xiaomi Devices Finished");
        }

        private void addtolog(string text) {
            txtlog.Text = text + Environment.NewLine + txtlog.Text;
        }

        private void errorMsgBox(string error) {
            MessageBox.Show(error);
        }

        private async void btnInstallVoicepack_Click(object sender, EventArgs e) {
            if (lstVoices.SelectedIndex == -1) {
                MessageBox.Show("Sprachpaket wurde nicht ausgewählt");
                return;
            } else if (txtipadress.Text.Length == 0) {
                MessageBox.Show("Roborock wurde nicht ausgewählt");
                return;
            }
            string pkgname = "voicepack" + Path.DirectorySeparatorChar + (string)lstVoices.SelectedItem;
            if (Path.GetExtension(pkgname) == "") {
                addtolog("Generate Package for Soundfiles");
                MiPackage pkg = new MiPackage(pkgname);
                await Task.Run(() => pkg.generateandCrypt());
                pkgname += ".pkg";
            }
            addtolog("Send Download Request");
            dynamic jsonObject = new JObject();
            jsonObject.method = "dnld_install_sound";
            jsonObject.@params = new JObject();
            jsonObject.@params.sid = 1;
            jsonObject.@params.url = ws.baseurl + pkgname.Replace("\\", "/");
            jsonObject.@params.md5 = CalculateMD5(pkgname);

            var device = new MiDevice(txtipadress.Text, txtToken.Text);
            Dlid.MiHome.Protocol.MiHomeResponse response = await Task.FromResult(device.Send(jsonObject));
            if (string.IsNullOrEmpty(response.ResponseText)) {
                addtolog("Response is Empty, wrong Token?");
                return;
            }
            response = await Task.FromResult(device.Send("get_sound_progress"));
            addtolog(response.ResponseText);
            progressMiiO = "get_sound_progress";
            timProgress.Start();
            prgMiiO.Value = 0;
        }

        private async void btnInstallFirmware_Click(object sender, EventArgs e) {
            if (lstfirmware.SelectedIndex == -1) {
                MessageBox.Show("Sprachpaket wurde nicht ausgewählt");
                return;
            } else if (txtipadress.Text.Length == 0) {
                MessageBox.Show("Roborock wurde nicht ausgewählt");
                return;
            }
            string pkgname = "firmware" + Path.DirectorySeparatorChar + (string)lstfirmware.SelectedItem;
            await sendInstall(pkgname);
        }

        private async void btnPackandFlash_Click(object sender, EventArgs e) {
            if (Path.GetExtension((string)cboFirmware.SelectedItem) != ".pkg") {
                addtolog("Sorry no pkg Firmware selected");
                return;
            }
            MiPackage pkg = new MiPackage((string)cboFirmware.SelectedItem);

            string pkgname = await Task.FromResult(pkg.generateandCrypt());
            await sendInstall(pkgname);
        }

        private async Task sendInstall(string pkgname) {
            if (Path.GetExtension(pkgname) == "") {
                addtolog("You can only Flash pkg files");
                return;
            }
            addtolog("Send Download Request");
            dynamic jsonObject = new JObject();
            jsonObject.method = "miIO.ota";
            jsonObject.@params = new JObject();
            jsonObject.@params.mode = "normal";
            jsonObject.@params.install = "1";
            jsonObject.@params.app_url = ws.baseurl + pkgname.Replace("\\", "/");
            jsonObject.@params.file_md5 = CalculateMD5(pkgname); //CalculateMD5(localfile);
            jsonObject.@params.proc = "dnld install";

            var device = new MiDevice(txtipadress.Text, txtToken.Text);
            Dlid.MiHome.Protocol.MiHomeResponse response = await Task.FromResult(device.Send(jsonObject));
            if (string.IsNullOrEmpty(response.ResponseText)) {
                addtolog("Response is Empty, wrong Token?");
                return;
            }
            response = await Task.FromResult(device.Send("miIO.get_ota_progress"));
            addtolog(response.ResponseText);
            progressMiiO = "miIO.get_ota_progress";
            timProgress.Start();
            prgMiiO.Value = 0;
        }

        static string CalculateMD5(string filename) {
            using (var md5 = MD5.Create()) {
                var hash = md5.ComputeHash(System.IO.File.ReadAllBytes(filename));
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        private async void timWebinterface_Tick(object sender, EventArgs e) {
            try {
                using (var httpClient = new HttpClient()) {
                    httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("RoborockFlasher", "1.0"));
                    HttpResponseMessage response = await httpClient.GetAsync("http://" + txtipadress.Text);
                    lblStatusWI.ForeColor = Color.DarkSeaGreen;
                    lblStatusWI.Text = "running";
                }
            } catch (HttpRequestException) {
                lblStatusWI.ForeColor = Color.OrangeRed;
                lblStatusWI.Text = "stopped";
            } catch (System.UriFormatException) {
                lblStatusWI.ForeColor = Color.OrangeRed;
                lblStatusWI.Text = "wrong IP or Hostname";
            }
        }

        private void btnRunWerbint_Click(object sender, EventArgs e) {
            var connectionInfo = new ConnectionInfo(txtipadress.Text, "root", new PrivateKeyAuthenticationMethod("root", new PrivateKeyFile(txtRsaKey.Text)));
            using (var client = new SshClient(connectionInfo)) {
                client.Connect();
                addtolog("Start Webinterface (take some time)");
                SshCommand cmd = client.RunCommand("/usr/local/bin/valetudo &");
                addtolog(cmd.Result);
            }
        }

        private void btnSshCommand_Click(object sender, EventArgs e) {
            var connectionInfo = new ConnectionInfo(txtipadress.Text, "root", new PrivateKeyAuthenticationMethod("root", new PrivateKeyFile(txtRsaKey.Text)));
            using (var client = new SshClient(connectionInfo)) {
                client.Connect();
                try {
                    SshCommand cmd = client.RunCommand(txtSshCommand.Text);
                    addtolog(cmd.Result);
                } catch (Renci.SshNet.Common.SshException ssh) {
                    addtolog("SSH Error: " + ssh.Message);
                } finally {
                    client.Disconnect();
                }
            }
        }

        private async void btnMiioCommand_Click(object sender, EventArgs e) {
            if (txtMiioParameter.Text.Length > 2) {
                dynamic jsonObject;
                try {
                    jsonObject = JObject.Parse(txtMiioParameter.Text);
                } catch {
                    addtolog("JSON Parse Error");
                    return;
                }
                var device = new MiDevice(txtipadress.Text, txtToken.Text);
                Dlid.MiHome.Protocol.MiHomeResponse response = await Task.FromResult(device.Send(txtMiioCommand.Text, jsonObject));
                addtolog(response.ResponseText);
            } else {
                var device = new MiDevice(txtipadress.Text, txtToken.Text);
                Dlid.MiHome.Protocol.MiHomeResponse response = await Task.FromResult(device.Send(txtMiioCommand.Text));
                addtolog(response.ResponseText);

            }
        }

        private async void timProgress_Tick(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(progressMiiO)) {
                timProgress.Stop();
                return;
            }
            var device = new MiDevice(txtipadress.Text, txtToken.Text);
            Dlid.MiHome.Protocol.MiHomeResponse response = await Task.FromResult(device.Send(progressMiiO));
            addtolog(response.ResponseText);
            if (string.IsNullOrEmpty(response.ResponseText)) {
                progressMiiO = "";
                addtolog("Device answer is null");
                return;
            }
            JObject jobj = JObject.Parse(response.ResponseText);
            if (progressMiiO == "get_sound_progress") {
                if ((int)jobj["result"][0]["state"] == 3) {
                    addtolog("Install Finished");
                    progressMiiO = "";
                }
                prgMiiO.Value = (int)jobj["result"][0]["progress"];
                prgMiiO.Update();
                switch ((int)jobj["result"][0]["error"]) {
                    case 0:
                        break;
                    case 2:
                        addtolog("Device can't connect to webserver");
                        progressMiiO = "";
                        break;
                    case 3:
                        addtolog("MD5 hash wrong please retry");
                        progressMiiO = "";
                        break;
                    case 4:
                        addtolog("Wrong file format?");
                        progressMiiO = "";
                        break;
                    default:
                        addtolog("unknown error");
                        progressMiiO = "";
                        break;
                }
            } else if (progressMiiO == "miIO.get_ota_progress") {
                prgMiiO.Value = (int)jobj["result"][0];
            }
        }

        private void llbWebserver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(ws.baseurl);
        }

        private void chkAllKnown_CheckedChanged(object sender, EventArgs e) {
            refreshdevices();
        }

        private void cboMiioCommands_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboMiioCommands.SelectedItem.ToString() == "--")
                return;
            else if (cboMiioCommands.SelectedItem.ToString() == "miIO.config_router") {
                txtMiioParameter.Text = "{\"ssid\":\"XXX\",\"passwd\":\"XXX\"}";
            } else {
                txtMiioParameter.Text = "";
            }
            txtMiioCommand.Text = cboMiioCommands.SelectedItem.ToString();
        }

        private void filewatcher_Changed(object sender, FileSystemEventArgs e) {
            btnRefresh_Click(null, null);
        }

        private void cbolisten_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbolisten.SelectedIndex == -1) return;
            if (ws != null) ws.Stop();
            ws = new SimpleHTTPServer(6999, cbolisten.SelectedValue.ToString());
            llbWebserver.Text = ws.baseurl;
        }
    }
}
