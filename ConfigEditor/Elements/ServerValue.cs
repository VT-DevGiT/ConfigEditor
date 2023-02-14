using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConfigEditor.Elements
{
    [Serializable]
    [XmlRoot("ServerIp")]
    public class ServerValue
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Ip")]
        public string Ip { get; set; }

        [XmlElement("Port")]
        public uint Port { get; set; }

        public ServerValue()
        {

        }

        public ServerValue(string name, string ip, uint port)
        {
            Name = name;
            Ip = ip;
            Port = port;
        }

        public IPAddress GetIp() => IPAddress.Parse(Ip);
    }
}
