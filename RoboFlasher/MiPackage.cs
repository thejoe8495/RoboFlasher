using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using System.Collections.Generic;
using System.IO;

namespace RoboFlasher {
    class MiPackage {
        string PASSWORD_FW = "rockrobo";
        string PASSWORD_SND = "r0ckrobo#23456";
        string _folder;
        string _basefolder;
        string _package;
        string _valetudo;
        Dictionary<string, string> _folders;

        public MiPackage(string package) {
            if (Path.GetExtension(package) == ".pkg") {
                _package = package;
            } else if (Directory.Exists(package)) {
                _folder = package;
                _basefolder = package;
            }
        }

        public string generateandCrypt() {
            string pkg;
            if (!string.IsNullOrEmpty(_folder))
                pkg = generateSnd();
            else
                pkg = generateFw();
            //var proc = System.Diagnostics.Process.Start("ccrypt" + Path.DirectorySeparatorChar + "ccrypt.exe", "-e -K \"" + PASSWORD_SND + "\" \"" + pkg + "\"");
            //proc.WaitForExit();
            //File.Move(pkg + ".cpt", pkg);
            return pkg;
        }

        public string generateFw() {
            File.Move(_package, _package + ".cpt");
            var proc = System.Diagnostics.Process.Start("ccrypt" + Path.DirectorySeparatorChar + "ccrypt.exe", "-e -K \"" + PASSWORD_FW + "\" \"" + _package + ".cpt\"");
            proc.WaitForExit();
            Stream outStream = File.OpenWrite(_package);
            Stream gzoStream = new GZipOutputStream(outStream);
            TarArchive tarArchive = TarArchive.CreateInputTarArchive(gzoStream);
            if (!Directory.Exists(Path.Combine(_folder, "deployment"))) {
                string deploypath = Path.Combine(_folder, "deployment");
                tarArchive.RootPath = deploypath;
                Directory.CreateDirectory(deploypath);
                Directory.CreateDirectory(Path.Combine(deploypath, "etc"));
                File.WriteAllText(Path.Combine(deploypath, "etc", "rc.local"), "### Roboflasher RC.LOCAL\n\niptables - F OUTPUT\nip6tables - F OUTPUT\niptables - t nat - F OUTPUT\niptables - t nat - A OUTPUT - p tcp--dport 80 - d 203.0.113.1 - j DNAT--to - destination 127.0.0.1:8053\n" +
                    "iptables - t nat - A OUTPUT - p udp--dport 8053 - d 203.0.113.1 - j DNAT--to - destination 127.0.0.1:8053\niptables - A OUTPUT - d 203.0.113.1 / 32 - j REJECT\nip6tables - A OUTPUT - d 2001:db8::1 / 128 - j REJECT\n### Roboflasher RC.LOCAL EXIT ###");
                File.WriteAllText(Path.Combine(deploypath, "etc", "hosts"), generateHostEntrys());
                File.WriteAllText(Path.Combine(deploypath, "opt", "rockrobo", "watchdog", "ntpserver.conf"), "0.pool.ntp.org\n1.pool.ntp.org\n2.pool.ntp.org\n3.pool.ntp.org\n"); 
                File.WriteAllText(Path.Combine(deploypath, "etc", "init", "valetudo.conf"), "#!upstart\ndescription \"Valetudo\"\n\nstart on started network-interface INTERFACE=wlan0\n" +
                    "stop on runlevel[06]\n\n oom score 1000\n exec /usr/local/bin/valetudo\n respawn\n respawn limit 10 90\n limit as 209715200 209715200");
                Directory.CreateDirectory(Path.Combine(deploypath, "root", ".ssh"));
                File.WriteAllText(Path.Combine(deploypath, "root", ".ssh", "authorized_keys"), "");  // need public key
                File.Move(_valetudo, Path.Combine(deploypath, "usr","local","bin","valetudo"));
            }
            return _package;
        }

        public string generateSnd() {
            string pkg = _basefolder + ".pkg";
            File.Delete(pkg);
            Stream outStream = File.Create(pkg);
            Stream gzoStream = new GZipOutputStream(outStream);
            TarArchive tarArchive = TarArchive.CreateOutputTarArchive(gzoStream);
            tarArchive.RootPath = _folder;
            string[] filenames = Directory.GetFiles(_folder);
            foreach (string filename in filenames) {
                var tarEntry = TarEntry.CreateEntryFromFile(filename);
                tarArchive.WriteEntry(tarEntry, true);
            }
            tarArchive.Close();
            return pkg;
        }

        public void addFolder(string src, string dst) {
            if (Directory.Exists(src) || File.Exists(src))
                _folders.Add(src, dst);
        }
        public string generateHostEntrys() {
            string content = "";
            string[] midomains = new string[] { "", "us.", "sg.", "st.", "de.", "ru.", "in.", "tw.", "ea.", "pv." };
            foreach (string item in midomains) {
                content = content + "\n203.0.113.1 " + item + "ot.io.mi.com";
                content = content + "\n2001:db8::1 " + item + "ot.io.mi.com";
                content = content + "\n203.0.113.1 " + item + "ott.io.mi.com";
                content = content + "\n2001:db8::1 " + item + "ott.io.mi.com";
            }
           midomains = new string[] { "cdn.cnbj0.files", "cnbj0", "cnbj2", "awsbj0", "awsbj0-files", "awsusor0", "awsusor0-files", "awssgp0", "awssgp0-files", "awsde0", "awsde0", "awsde0-files", "ksyru0-eco", "ksyru0-eco-files", "awsind0-eco", "awsind0-eco-files" };
            foreach (string item in midomains) {
                content = content + "\n203.0.113.1 " + item + ".fds.api.xiaomi.com";
                content = content + "\n2001:db8::1 " + item + ".fds.api.xiaomi.com";
            }
            return content;
        } 
    }
}