using ConfigEditor.Elements;
using ConfigtEditor.Controls;
using ConfigtEditor.Elements;
using ConfigtEditor.Utils;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor.ServerControl
{
    internal class ServerControlLocal : IServerControl, IDisposable
    {
        public event Logger Log;
        public event ServerStop ServerStop;

        private readonly ushort _portTcp;
        public TcpServer _tcpServer;
        private Process _process;

        private bool _runing;
        private ServerStade _stade = ServerStade.WhaitConfig;

        public ServerControlLocal()
        {
            _portTcp = FreeTcpPort();
        }

        public ServerStade Stade
        {
            get => _stade;
            set
            {
                if (_stade == value) return;
                if (_stade == ServerStade.Stop)
                {
                    if (_runing)
                    {
                        Kill();
                        _runing = false;
                    }
                }
                else if (!_runing)
                {
                    Start();
                    _runing = true;
                }
                _stade = value;
            }
        }

        private void SendLog(string message, Color? color = null)
        {
            Log?.Invoke(message, color ?? Color.Transparent, false);
        }


        public void Start()
        {
            _runing = true; 
            _stade = ServerStade.WhaitConfig;
            if (!SelectServer(out var info))
            {
                ServerStop?.Invoke();
                return;
            }
            if (Config.Singleton.ServerConfig == null)
            {
                Config.Singleton.ServerConfig = new ServerConfig()
                {
                    ExePath = info.ExePath
                };
            }
            else
            {
                Config.Singleton.ServerConfig.ExePath = info.ExePath;
            }
            _stade = ServerStade.Starting;
            StartPorcess(info);
            _stade = ServerStade.Runing;
        }

        public bool SelectServer(out StartInfo info)
        {
            var ctrl = new ServerConfigUC();
            ctrl.EcsDisplayAsDialog = true;
            var frm = ECSFormUtility.CreateForm(ctrl);
            frm.Display();
            info = ctrl.Info;
            return ctrl.Allow;
        }

        public bool StartPorcess(StartInfo info)
        {
            if (_tcpServer == null)
                _tcpServer = new TcpServer(_portTcp, Log.Invoke) ;

            int proccessID = Process.GetCurrentProcess().Id;
            int port = info.Port;
            string startArg = $"-id{proccessID} -console{_portTcp} -port{port} -batchmode -nographics -nodedicateddelete ";

            if (info.CrashRestart) 
                startArg += "-heartbeat";

            ProcessStartInfo startInfo = new ProcessStartInfo(info.ExePath, startArg)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            SendLog($"Start server on port: {port}.\n", Color.Red);
            _process = Process.Start(startInfo);
            _process.Exited += OnExited;
            _process.OutputDataReceived += StdOut;
            _process.ErrorDataReceived += StdErr;
            return true;
        }

        public void Kill()
        {
            _runing = false;
            _stade = ServerStade.Stop;
        }

        public bool SendCommand(string command)
        {
            if (!_runing)
            {
                SendLog("You need to start the server first", Color.Red);
                return false;
            }
            return true;
        }

        private void StdErr(object sender, DataReceivedEventArgs e)
        {
            SendLog(e.Data, Color.DarkRed);
        }

        private void StdOut(object sender, DataReceivedEventArgs e)
        {
            SendLog(e.Data, Color.Blue);
        }

        private void OnExited(object sender, EventArgs e)
        {
            _stade = ServerStade.Stop;
        }

        private ushort FreeTcpPort()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            ushort port = (ushort)((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        public void Dispose()
        {
            Kill();
            if (_tcpServer != null)
            {
                _tcpServer.Dispose();
                _tcpServer = null;
            }
        }
    }
}
