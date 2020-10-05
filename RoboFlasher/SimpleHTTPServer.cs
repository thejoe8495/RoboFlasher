using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RoboFlasher {

    class SimpleHTTPServer {
        private Thread _serverThread;
        private string _rootDirectory;
        private HttpListener _listener;
        private int _port;
        public string baseurl { get; private set; }

        public int Port {
            get { return _port; }
            private set { }
        }

        /// <summary>
        /// Construct server with given port.
        /// </summary>
        /// <param name="path">Directory path to serve.</param>
        /// <param name="port">Port of the server.</param>
        public SimpleHTTPServer(string path, int port) {
            this.Initialize(path, port);
        }
        
        /// <summary>
        /// Construct server with given port.
        /// </summary>
        /// <param name="path">Directory path to serve.</param>
        /// <param name="port">Port of the server.</param>
        public SimpleHTTPServer(int port, string ip) {
            this.Initialize(Path.GetFullPath("."), port, ip);
        }

        /// <summary>
        /// Construct server with given port.
        /// </summary>
        /// <param name="path">Directory path to serve.</param>
        /// <param name="port">Port of the server.</param>
        public SimpleHTTPServer() {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            this.Initialize(Path.GetFullPath("."), port);
        }

        /// <summary>
        /// Construct server with suitable port.
        /// </summary>
        /// <param name="path">Directory path to serve.</param>
        public SimpleHTTPServer(string path) {
            //get an empty port
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            this.Initialize(path, port);
        }

        /// <summary>
        /// Stop server and dispose all functions.
        /// </summary>
        public void Stop() {
            _serverThread.Abort();
            _listener.Stop();

            classes.FirewallHelper p = new classes.FirewallHelper(Port);
            p.closeFirewall();
        }
        private string getIP() {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void Listen() {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + _port.ToString() + "/");
            _listener.Start();
            while (true) {
                try {
                    HttpListenerContext context = _listener.GetContext();
                    HandleRequest(context);
                } catch (Exception) {

                }
            }
        }

        private void HandleRequest(HttpListenerContext context) {
            string filename = context.Request.Url.AbsolutePath;
            Console.WriteLine(filename);
            filename = filename.Substring(1);

            filename = Path.Combine(_rootDirectory, filename);
            if (Path.GetExtension(filename) != ".pkg") filename = Path.Combine(_rootDirectory, "index.html");

            if (File.Exists(filename)) {
                try {
                    Stream input = new FileStream(filename, FileMode.Open);

                    //Adding permanent http response headers
                    context.Response.ContentType = Path.GetExtension(filename)== ".html" ? "text/html" : "application/octet-stream";
                    context.Response.ContentLength64 = input.Length;
                    context.Response.AddHeader("Date", DateTime.Now.ToString("r"));
                    context.Response.AddHeader("Last-Modified", System.IO.File.GetLastWriteTime(filename).ToString("r"));

                    byte[] buffer = new byte[1024 * 16];
                    int nbytes;
                    while ((nbytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        context.Response.OutputStream.Write(buffer, 0, nbytes);
                    input.Close();

                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.OutputStream.Flush();
                } catch (Exception) {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }

            } else {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            context.Response.OutputStream.Close();
        }

        private void Initialize(string path, int port, string ip = null) {
            this._rootDirectory = path;
            this._port = port;
            baseurl = "http://" + ip + ":" + port + "/";
            //string args = "http add urlacl url=http://*:" + _port.ToString() + "/ user=Jeder listen=yes";

            //ProcessStartInfo psi = new ProcessStartInfo("netsh", args);
            ////psi.Verb = "runas";
            //psi.CreateNoWindow = true;
            //psi.WindowStyle = ProcessWindowStyle.Hidden;
            //psi.UseShellExecute = true;

            //Process.Start(psi).WaitForExit();

            //this.Listen();
            _serverThread = new Thread(this.Listen);
            _serverThread.Start();
        }


    }
}
