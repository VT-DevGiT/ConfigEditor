using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ConfigEditor.ServerControl
{

    public delegate void Logger(string text, Color color, bool formUser);

    public delegate void ServerStop();
    public interface IServerControl : IDisposable
    {
        event Logger Log;

        event ServerStop ServerStop;

        ServerStade Stade { get; set; }

        void Start();

        void Kill();

        bool SendCommand(string command);
    }
}
