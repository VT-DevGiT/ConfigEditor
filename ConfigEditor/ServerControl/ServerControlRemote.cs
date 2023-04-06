#if SERVER_CONTROL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor.ServerControl
{
    internal class ServerControlRemote : IServerControl, IDisposable
    {
        public event Logger Log;

        public event ServerStop ServerStop;

        private bool _runing = false;
        private ServerStade _stade;
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
                    } 
                }
                else if (!_runing)
                {
                    Start();
                }
                _stade = value;
            }
        }

        public void Start()
        {
            _runing = true;
        }

        public void Kill()
        {
            _runing = false;
        }

        public bool SendCommand(string command)
        {
            return true;
        }

        public void Dispose()
        {
            
        }
    }
}
#endif