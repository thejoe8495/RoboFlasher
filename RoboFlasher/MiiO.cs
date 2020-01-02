using Newtonsoft.Json;
using RoboFlasher.classes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace RoboFlasher {
    /// <summary>
    /// deprecated wait for Dlid.MiHome
    /// </summary>
    [Obsolete]
    public class MiIO {

        private string device_ip;
        private string device_token;
        private byte[] device_handshake;
        private string device_info;
        private string device_code;
        private TimeSpan device_timedelta;
        AesCryptoServiceProvider encryptor;
        private int socket_timeout;
        private int retries = 5;
        byte[] recivebytes;
        UdpClient Client = new UdpClient();
        public List<Device> devlist = new List<Device>();

        public MiIO(string device_ip, string device_token, int socket_timeout) {
            this.device_ip = device_ip;
            this.device_token = device_token;
            this.device_handshake = new byte[] { 0x21, 0x31, 0, 0x20, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
            encryptor = new AesCryptoServiceProvider();
            encryptor.Mode = CipherMode.CBC;
            encryptor.BlockSize = 128;
            encryptor.KeySize = 128;
            string packet_key = md5(this.device_token);
            string packet_iv = md5(packet_key + this.device_token);
            byte[] aesKey = new byte[32];
            Array.Copy(Encoding.ASCII.GetBytes(packet_key), 0, aesKey, 0, 32);
            encryptor.Key = aesKey;
            byte[] ivbytes = new byte[16];
            Array.Copy(Encoding.ASCII.GetBytes(packet_iv), 0, ivbytes, 0, 16);
            encryptor.IV = ivbytes;
            this.socket_timeout = socket_timeout;
        }

        public string hex2bin(string strHex) {
            if (strHex.Length > 2) {
                string binary = "";
                for (int i = 0; i < strHex.Length; i = i + 2) {
                    binary += hex2bin(strHex.Substring(i, 2));
                }
                return binary;
            } else
                return System.Convert.ToChar(int.Parse(strHex, System.Globalization.NumberStyles.AllowHexSpecifier)).ToString();
        }

        public string bin2hex(byte[] strBin) {
            return bin2hex(strBin, 0, strBin.Length);
        }
        public string bin2hex(byte[] strBin, int start) {
            return bin2hex(strBin, start, strBin.Length - start);
        }
        public string bin2hex(byte[] strBin, int start, int length) {
            byte[] chars = new byte[length];
            Array.Copy(strBin, start, chars, 0, length);
            string hexNr = "";
            for (int i = 0; i < chars.Length; i++) {
                hexNr += Convert.ToByte(chars[i]).ToString("x2");
            }
            return hexNr;
        }

        public static string md5(string TextToHash) {
            //Prüfen ob Daten übergeben wurden.
            if ((TextToHash == null) || (TextToHash.Length == 0)) {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] textToHash = Encoding.ASCII.GetBytes(TextToHash);
            byte[] result = md5.ComputeHash(textToHash);

            return System.BitConverter.ToString(result).Replace("-", "");
        }


        private Dictionary<string, string> packet_send(string message) {
            return packet_send(Encoding.ASCII.GetBytes(message));
        }

        private Dictionary<string, string> packet_send(byte[] sendb) {
            for (int x = 0; x < this.retries; x++) {
                System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse(device_ip);
                System.Net.IPEndPoint remoteEP = new IPEndPoint(ipAdd, 54321);
                Client.Send(sendb, sendb.Length, remoteEP);
                try {
                    Client.Client.ReceiveTimeout = this.socket_timeout;
                    Client.BeginReceive(new AsyncCallback(recv), null);
                    //recivebytes = Client.Receive(ref remoteEP);
                } catch (Exception exception) {
                    this.log("Device handshake error on " + exception.ToString());
                }
                //Array.Copy(recivebytes, 0, newarr, 0, recivebytes);
                System.Threading.Thread.Sleep(3000);
                if (recivebytes != null)
                    return packet_parse(recivebytes);
            }
            return null;
        }

        private void recv(IAsyncResult res) {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 54321);
            byte[] received = Client.EndReceive(res, ref RemoteIpEndPoint);
            //Process codes
            Dictionary<string, string> result = packet_parse(received);
            bool found = false;
            foreach (var item in devlist) {
                if (item.Serial == result["serial"])
                    found = true;
            }
            if (!found) {
                Device dev = new Device(RemoteIpEndPoint.Address.ToString(), result["type"], result["serial"]);
                devlist.Add(dev);
            }
            Client.BeginReceive(new AsyncCallback(recv), null);
        }

        private string packet_build(Dictionary<string, string> message) {
            string msgjson = bin2hex(EncryptString(JsonConvert.SerializeObject(message)));
            string length = string.Format("{0:x4}", msgjson.Length / 2 + 32);
            string timestamp = string.Format("{0:x8}", DateTime.Now.Add(this.device_timedelta).toUnixTimestamp());
            string packet = "2131" + length + "00000000" + this.device_code + timestamp + this.device_token + msgjson;
            packet = "2131" + length + "00000000" + this.device_code + timestamp + md5(hex2bin(packet)) + msgjson;
            return packet;
        }
        private UInt32 ReadInt32(byte[] rawpacket, int startIndex, int bytes) {
            Int32 lastByte = bytes - 1;
            UInt32 value = 0;
            for (Int32 index = 0; index < bytes; index++) {
                Int32 offs = startIndex + lastByte - index;
                value += (UInt32)(rawpacket[offs] << (8 * index));
            }
            return value;
        }

        private Dictionary<string, string> packet_parse(byte[] rawpacket) {
            Dictionary<string, string> packet = new Dictionary<string, string>();
            packet.Add("header", bin2hex(rawpacket, 0, 2));
            packet.Add("length", BitConverter.ToUInt16(rawpacket, 3).ToString());
            packet.Add("zeroes", bin2hex(rawpacket, 4, 4));
            packet.Add("type", bin2hex(rawpacket, 8, 2));
            packet.Add("serial", bin2hex(rawpacket, 10, 2));
            packet.Add("timestamp", ReadInt32(rawpacket, 12, 4).ToString());
            packet.Add("checksum", bin2hex(rawpacket, 16, 16));
            if (rawpacket.Length > 32)
                packet.Add("result", bin2hex(DecryptString(rawpacket)));
            else
                packet.Add("result", "success");
            //if (packet = @unpack("H4header/n1length/H8zeroes/H4type/H4serial/N1timestamp/H32checksum/A*result", rawpacket)) {
            //	if (!string.IsNullOrEmpty(packet["result"])) {
            //		packet["result"] = DecryptString(packet["result"], "AES-128-CBC", this.packet_key, this.packet_iv);
            //		packet["result"] = JsonConvert.DeserializeObject(packet["result"].trim());
            //		packet["result"] = isset(packet["result"]["result"][0]) && count(packet["result"]["result"]) == 1 ? packet["result"]["result"][0] : packet["result"]["result"];
            //	} else {
            //		packet.Add("result", "ok");
            //	}
            return packet;
        }

        public bool log(string msg) {
            Console.WriteLine(msg);
            return true;
        }

        public bool handshake() {
            try {
                Dictionary<string, string> response = this.packet_send(this.device_handshake);
                if (response == null)
                    return false;
                this.device_code = response["type"] + response["serial"];


                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
                this.device_timedelta = DateTime.Now - epoch.AddSeconds(int.Parse(response["timestamp"]));
                return true;
            } catch (Exception exception) {
                return this.log("Device handshake error on " + exception.ToString());
            }
        }

        private Dictionary<string, string> call(string method) {
            return this.call(method, null);
        }
        private Dictionary<string, string> call(string method, Dictionary<string, string> parameter) {
            if (!this.handshake()) {
                return null;
            }
            Dictionary<string, string> sendpara = new Dictionary<string, string>();
            sendpara.Add("method", method);
            if (parameter != null)
                sendpara.Add("params", JsonConvert.SerializeObject(parameter));
            else
                sendpara.Add("params", "false");
            Dictionary<string, string> response = this.packet_send(this.packet_build(sendpara));
            return response;
        }

        public string info() {
            Dictionary<string, string> response = this.call("miIO.info");
            this.device_info = response["data"];
            return this.device_info;
        }

        public Dictionary<string, string> firmware_install(string url, string md5) {
            Dictionary<string, string> list = new Dictionary<string, string>();
            list.Add("mode", "normal");
            list.Add("install", "1");
            list.Add("app_url", url);
            list.Add("file_md5", md5);
            list.Add("proc", "dnld install");
            Dictionary<string, string> response = this.call("miIO.ota", list);
            return response;
        }

        public Dictionary<string, string> firmware_progress() {
            return this.call("miIO.get_ota_progress");
        }

        public Dictionary<string, string> firmware_state() {
            return this.call("miIO.get_ota_state");
        }
        private byte[] EncryptString(string plainText) {
            var _crypto = encryptor.CreateEncryptor(encryptor.Key, encryptor.IV);
            byte[] encrypted = _crypto.TransformFinalBlock(ASCIIEncoding.UTF8.GetBytes(plainText), 0, ASCIIEncoding.UTF8.GetBytes(plainText).Length);
            _crypto.Dispose();
            return encrypted;
        }

        public byte[] DecryptString(byte[] cipherText) {
            var _crypto = encryptor.CreateDecryptor(encryptor.Key, encryptor.IV);
            byte[] decrypted = _crypto.TransformFinalBlock(cipherText, 0, cipherText.Length);
            _crypto.Dispose();
            return decrypted;
        }

    }
}
