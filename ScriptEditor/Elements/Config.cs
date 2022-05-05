using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ScriptEditor.ConfigEditor;

namespace ScriptEditor.Elements
{
    [Serializable]
    [XmlRoot("CONFIG")]
    public class Config
    {
        [XmlArray("Rooms")]
        [XmlArrayItem("Room")]
        public List<string> ValideRooms
        {
            get; set;
        }

        public Config()
        {

        }

        public static Config Default()
        {
            var config = new Config();
            config.ValideRooms = new List<string>()
            {
                "LCZ_Toilets","LCZ_Cafe (15)","HCZ_EZ_Checkpoint"
            };
            return config;
        }

        public string ToXml()
        {

            var nameSpace = new XmlSerializerNamespaces();
            // Pour ne pas avoir les xmlns sur la racine 
            nameSpace.Add("", "");

            var stringwriter = new StringWriter();
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            var xmlWriter = XmlWriter.Create(stringwriter, settings);

            var xmlSerializer = new XmlSerializer(typeof(Config));
            xmlSerializer.Serialize(xmlWriter, this, nameSpace);

            return stringwriter.ToString();
        }

        private static string FileName => $@"{Application.StartupPath}\EditorConfig.xml";

        public void Save()
        {
            File.WriteAllText(FileName, ToXml());
        }

        public static Config Load()
        {
            if (File.Exists(FileName))
            {
                string xml = File.ReadAllText(FileName);
                if (!String.IsNullOrWhiteSpace(xml))
                {
                    var xDoc = XDocument.Parse(xml);
                    var xmlSerializer = new XmlSerializer(typeof(Config));

                    return (Config)xmlSerializer.Deserialize(xDoc.CreateReader());
                }
            }
            return Config.Default();
        }

        internal void AddRoom(SymlContentItem item)
        {
            if (!ValideRooms.Contains(item.Value))
            {
                ValideRooms.Add(item.Value);
                Save();
            }
        }
    }
}
