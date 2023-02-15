using ConfigEditor.Elements;
using ConfigtEditor.Controls;
using ConfigtEditor.Elements;
using ConfigtEditor.Utils;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        public TcpServer _tcpServer;

        private ushort _portTcp;
        private Process _process;
        private ServerStade _stade = ServerStade.WhaitConfig;
        private bool _runing;

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

        private void SendLog(string message, bool fromeUser = false) => SendLog(message, Color.Transparent, fromeUser);

        private void SendLog(string message, Color color, bool fromeUser = false)
        {
            Log?.Invoke(message, color, fromeUser);
        }

        public void Start()
        {
            _runing = true; 
            _stade = ServerStade.WhaitConfig;
            if (!SelectServer(out var info))
            {
                ServerStop?.Invoke(true);
                return;
            }
            if (Config.Singleton.ServerConfig == null)
            {
                Config.Singleton.ServerConfig = new ServerConfig()
                {
                    ExePath = info.ExePath
                };
                Config.Singleton.Save();
            }
            else
            {
                Config.Singleton.ServerConfig.ExePath = info.ExePath;
                Config.Singleton.Save();
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
            {
                _portTcp = FreeTcpPort();
                _tcpServer = new TcpServer(_portTcp, SendLog);
            }

            int proccessID = Process.GetCurrentProcess().Id;
            int port = info.Port;
            string directory = Path.GetDirectoryName(info.ExePath);

            ProcessStartInfo startInfo = new ProcessStartInfo(info.ExePath)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = directory,
            };


            SendLog($"Start server on port: {port}.\n", Color.Red);
            _process = Process.Start(startInfo);
            _process.EnableRaisingEvents = true;
            _process.Exited += OnExited;
            _process.OutputDataReceived += OutPutData;
            _process.ErrorDataReceived += OutPutError;
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();

            return true;
        }

        public void Kill()
        {
            _runing = false;
            _stade = ServerStade.Stop;
            ServerStop?.Invoke(false);
        }

        public bool SendCommand(string command)
        {
            if (!_runing)
            {
                SendLog("You need to start the server first", Color.Red);
                return false;
            }
            _tcpServer.Send(command);
            return true;
        }

        private void OutPutError(object sender, DataReceivedEventArgs e)
        {
            SendLog(e.Data, Color.DarkRed);
        }

        private void OutPutData(object sender, DataReceivedEventArgs e)
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
