using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigEditor.ServerControl
{
    public struct StartInfo
    {
        public string ExePath { get; set; }

        public ushort Port { get; set; }

        public StartInfo(string expePath, ushort port)
        {
            ExePath = expePath;
            Port = port;
        }
    }
}
