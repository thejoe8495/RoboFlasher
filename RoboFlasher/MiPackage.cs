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
        Dictionary<string, string> _folders;

        public MiPackage(string package) {
            if (Path.GetExtension(package) == ".pkg") {
                _package = package;
            } else if (Directory.Exists(package)) {
                _folder = package;
                _basefolder = Path.GetPathRoot(package);
            }
        }

        public string generateandCrypt() {
            string pkg;
            if (!string.IsNullOrEmpty(_folder))
                pkg = generateSnd();
            else
                pkg = generateFw();
            var proc = System.Diagnostics.Process.Start("ccrypt" + Path.DirectorySeparatorChar + "ccrypt.exe", "-e -K \"" + PASSWORD_SND + "\" \"" + pkg + "\"");
            proc.WaitForExit();
            File.Move(pkg + ".cpt", pkg);
            return pkg;
        }

        public string generateFw() {
            File.Move(_package, _package + ".cpt");
            var proc = System.Diagnostics.Process.Start("ccrypt" + Path.DirectorySeparatorChar + "ccrypt.exe", "-e -K \"" + PASSWORD_FW + "\" \"" + _package + ".cpt\"");
            proc.WaitForExit();

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
    }
}