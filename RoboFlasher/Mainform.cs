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

namespace RoboFlasher {
    public partial class Mainform : MetroForm {
        private List<GitRelases> valrelease = new List<GitRelases>();
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Dictionary<string, string> tokens = new Dictionary<string, string>();
        SimpleHTTPServer ws = new SimpleHTTPServer();
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
            llbWebserver.Text = ws.baseurl;

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

        private async Task loadGit() {
            string res = "";
            using (var httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("RoborockFlasher", "1.0"));
                HttpResponseMessage response = await httpClient.GetAsync("https://api.github.com/repos/rand256/valetudo/releases");
                res = await response.Content.ReadAsStringAsync();
            }
            JObject resources = JObject.Parse(res);
        }

        public static string SendResponse(HttpListenerRequest request) {
            return System.IO.File.ReadAllText(request.Url.LocalPath.Substring(1));
        }

        private async void btnupdateFirmware_Click(object sender, EventArgs e) {
            var device = new MiDevice(txtipadress.Text, txtToken.Text);
            dynamic jsonObject = new JObject();
            jsonObject.method = "miIO.ota";
            jsonObject.@params = new {
                mode = "normal",
                install = "1",
                app_url = ws.baseurl,// + localfile.Replace("\\", "/");
                file_md5 = CalculateMD5(lstfirmware.Text), //CalculateMD5(localfile);
                proc = "dnld install"
            };

            Dlid.MiHome.Protocol.MiHomeResponse response = await Task.FromResult(device.Send(jsonObject));
            addtolog(response.ResponseText);

        }


        private void txtToken_TextChanged(object sender, EventArgs e) {
            lblErrorToken.Text = "";
            if (Regex.IsMatch(txtToken.Text, "^[a-f0-9]{32}$"))
                lblErrorToken.Text = "Sorry token not match: #^[a-f0-9]{32}#";
        }

        private void lstdevices_SelectedIndexChanged(object sender, EventArgs e) {
            if (txtipadress.Text.Length > 0 && tokens.ContainsKey(txtipadress.Text))
                tokens[txtipadress.Text] = txtToken.Text;
            else if (txtipadress.Text.Length > 0)
                tokens.Add(txtipadress.Text, txtToken.Text);
            txtipadress.Text = ((Device)lstdevices.SelectedItem).IP;
            if (tokens.ContainsKey(txtipadress.Text))
                txtToken.Text = tokens[txtipadress.Text];
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            loadFiles("webinterface", lstwebinterface, cboWebinterface);
            loadFiles("firmware", lstfirmware, cboFirmware);
            loadFiles("voicepack", lstVoices, cboVoicepacks);
        }

        private async void btnWebinterfaceInstall_Click(object sender, EventArgs e) {
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
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

        private void btnGenerateNew_Click(object sender, EventArgs e) {
            var keygen = new SshKeyGenerator.SshKeyGenerator(1024);

            System.IO.File.WriteAllText(txtRsaKey.Text, keygen.ToPrivateKey());
            System.IO.File.WriteAllText(txtRsaKey.Text + ".pub", keygen.ToRfcPublicKey("RoboFlasher"));
            Clipboard.SetText(keygen.ToRfcPublicKey("RoboFlasher"));
            MetroFramework.MetroMessageBox.Show(this, "Key generated please copy the key to Valetudo webinterface\nPublic key is copied to clipboard\n\n " + keygen.ToRfcPublicKey("RoboFlasher"), "Public Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // GZip.Compress(File.OpenRead(parser.Source), File.Create(parser.Target), true, parser.Level);

        }

        private async void btndiscover_Click(object sender, EventArgs e) {
            addtolog("Scan for Xiaomi Devices");
            var test = new MiIO("255.255.255.255", "not needet", 3000);
            await Task.FromResult(test.handshake());
            lstdevices.DataSource = test.devlist;
            if (test.devlist.Count > 0) lstdevices_SelectedIndexChanged(null,null);
            addtolog("Scan for Xiaomi Devices Finished");

            Process p = new Process();
            p.StartInfo.FileName = "netsh.exe";
            StringBuilder parameters = new StringBuilder();
            parameters.Append(" firewall");
            parameters.Append(" add portopening");
            parameters.Append(" protocol = UDP");
            parameters.Append(" port = 54321");
            parameters.Append(" name = RoboflasherDiscover");
            parameters.Append(" mode = ENABLE");
            parameters.Append(" profile = ALL");
            p.StartInfo.Arguments = parameters.ToString();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.WaitForExit(10000);
        }

        private void addtolog(string text) {
            txtlog.Text = text + Environment.NewLine + txtlog.Text;
        }

        private async void btnInstallVoicepack_Click(object sender, EventArgs e) {
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
            await Task.FromResult(device.Send(jsonObject));
            Dlid.MiHome.Protocol.MiHomeResponse response = await Task.FromResult(device.Send("get_sound_progress"));
            addtolog(response.ResponseText);
            progressMiiO = "get_sound_progress";
            timProgress.Start();
            prgMiiO.Value = 0;
        }
        private async void btnInstallFirmware_Click(object sender, EventArgs e) {
            string pkgname = "firmware" + Path.DirectorySeparatorChar + (string)lstVoices.SelectedItem;
            await sendInstall(pkgname);
        }

        private async void btnPackandFlash_Click(object sender, EventArgs e) {
            if (Path.GetExtension((string)cboFirmware.SelectedItem) != ".pkg") {
                addtolog("Sorry no pkg Firmware selected");
                return;
            }
            MiPackage pkg = new MiPackage((string)cboFirmware.SelectedItem);

            await Task.Run(() => pkg.generateandCrypt());
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
            await Task.FromResult(device.Send(jsonObject));
            Dlid.MiHome.Protocol.MiHomeResponse response = await Task.FromResult(device.Send("miIO.get_ota_progress"));
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
            if (string.IsNullOrEmpty(response.ResponseText)) return;
            JObject jobj = JObject.Parse(response.ResponseText);
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
                    addtolog("Device Can't connect to Webserver");
                    progressMiiO = "";
                    break;
                case 3:
                    addtolog("MD5 Hash wrong please retry");
                    progressMiiO = "";
                    break;
                case 4:
                    addtolog("Wrong File Format?");
                    progressMiiO = "";
                    break;
                default:
                    addtolog("unknown Error");
                    progressMiiO = "";
                    break;
            }
        }

        private void llbWebserver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(ws.baseurl);
        }
    }
}
