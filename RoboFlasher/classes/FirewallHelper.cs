using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NetFwTypeLib;
using Microsoft.Win32;

namespace RoboFlasher.classes {
    class FirewallHelper {
            int _port;
            protected INetFwProfile fwProfile;

        public FirewallHelper(int port) {
            this._port = port;
        }

        public void openFirewall() {
                ///////////// Firewall Authorize Application ////////////
                String imageFilename = getImageFilename();
                setProfile();
                INetFwAuthorizedApplications apps = fwProfile.AuthorizedApplications;
                INetFwAuthorizedApplication app = (INetFwAuthorizedApplication)getInstance("INetAuthApp");
                app.Name = "RoboFlasher";
                app.ProcessImageFileName = imageFilename;
                apps.Add(app);
                apps = null;

                //////////////// Open Needed Ports /////////////////
                INetFwOpenPorts openports = fwProfile.GloballyOpenPorts;
                INetFwOpenPort openport = (INetFwOpenPort)getInstance("INetOpenPort");
                openport.Port = _port;
                openport.Protocol = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                openport.Name = "HTTPServer RoboFlasher";
                openports.Add(openport);
                openports = null;
            } // openFirewall

            public void closeFirewall() {
                //String imageFilename = getImageFilename();
                //setProfile();
                //INetFwAuthorizedApplications apps = fwProfile.AuthorizedApplications;
                //apps.Remove(imageFilename);
                //apps = null;
                //INetFwOpenPorts ports = fwProfile.GloballyOpenPorts;
                //ports.Remove(_port, NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);
                //ports = null;
            }

            protected string getImageFilename() {
                return System.Reflection.Assembly.GetEntryAssembly().Location;
            // Get install directory from the registry
            RegistryKey pRegKey = Registry.LocalMachine;
                pRegKey = pRegKey.OpenSubKey("SOFTWARE\\Company Directory\\AppDir");
                Object insDir = pRegKey.GetValue("InstallDir");
                return insDir + "RVP.exe";
            }

            protected void setProfile() {
                // Access INetFwMgr
                INetFwMgr fwMgr = (INetFwMgr)getInstance("INetFwMgr");
                INetFwPolicy fwPolicy = fwMgr.LocalPolicy;
                fwProfile = fwPolicy.CurrentProfile;
                fwMgr = null;
                fwPolicy = null;
            }

            protected Object getInstance(String typeName) {
                if (typeName == "INetFwMgr") {
                    Type type = Type.GetTypeFromCLSID(
                    new Guid("{304CE942-6E39-40D8-943A-B913C40C9CD4}"));
                    return Activator.CreateInstance(type);
                } else if (typeName == "INetAuthApp") {
                    Type type = Type.GetTypeFromCLSID(
                    new Guid("{EC9846B3-2762-4A6B-A214-6ACB603462D2}"));
                    return Activator.CreateInstance(type);
                } else if (typeName == "INetOpenPort") {
                    Type type = Type.GetTypeFromCLSID(
                    new Guid("{0CA545C6-37AD-4A6C-BF92-9F7610067EF5}"));
                    return Activator.CreateInstance(type);
                } else return null;
            }
        }
}
