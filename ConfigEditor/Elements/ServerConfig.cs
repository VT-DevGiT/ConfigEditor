using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConfigEditor.Elements
{
    [Serializable]
    [XmlRoot("ServerConfig")]
    public class ServerConfig
    {
        #region Attributes & Properties
        [XmlElement("ExePath")]
        public string ExePath { get; set; } = string.Empty;

        List<ServerValue> _serverIp = new List<ServerValue>();
        [XmlArray("ServersIp")]
        [XmlArrayItem("ServerIp")]
        public List<ServerValue> ServerIp => _serverIp;

        #endregion

        #region Constructors & Destructor

        #endregion
    }
}
