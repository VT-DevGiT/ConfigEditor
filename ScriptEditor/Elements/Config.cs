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
        [XmlIgnore]
        public static Config Singleton = new Config();
        
        [XmlArray("Completors")]
        [XmlArrayItem("Completor")]
        public List<Completor> Completors
        {
            get; set;
        }

        public Config()
        {
            Completors = new List<Completor>();
        }

        public uint GetCompletorId() 
        {
            uint max = 0;
            if (Completors.Any())
            {
                max = Completors.Max(p => p.Id);
            }
            return max + 1 ;
        }

        public uint GetCompletorValueId()
        {
            uint nextId = 0;
            foreach (var completor in Config.Singleton.Completors)
            {
                if (completor.ListValues.Any())
                {
                    var max = completor.ListValues.Max(p => p.Id);
                    if (max > nextId)
                    {
                        nextId = max;
                    }
                }
            }
            return nextId + 1;
        }
        public void Default()
        {
            var completorBool = new Completor();
            completorBool.Id = GetCompletorId();
            completorBool.Name = "Bool";
            Singleton.Completors.Add(completorBool);
            completorBool.ListValues.Add(new CompletorValue("true"));
            completorBool.ListValues.Add(new CompletorValue("false"));
            completorBool.CompletorType = CompletorType.ByValue;
            

            var completorRoom = new Completor();
            completorRoom.Id = GetCompletorId();
            completorRoom.Name = "Room";
            Singleton.Completors.Add(completorRoom);
            completorRoom.ListValues.Add(new CompletorValue("LCZ_Toilets"));
            completorRoom.ListValues.Add(new CompletorValue("LCZ_Cafe (15)"));
            completorRoom.ListValues.Add(new CompletorValue("HCZ_EZ_Checkpoint"));
            completorRoom.ContainWord = "room";
            completorRoom.CompletorType = CompletorType.ByName;
            

            Singleton.Save();
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

        public static void Load()
        {

            if (File.Exists(FileName))
            {
                string xml = File.ReadAllText(FileName);
                if (!String.IsNullOrWhiteSpace(xml))
                {
                    var xDoc = XDocument.Parse(xml);
                    var xmlSerializer = new XmlSerializer(typeof(Config));

                    Singleton = (Config)xmlSerializer.Deserialize(xDoc.CreateReader());
                }
            }
            else
            {
                Singleton = new Config();
                Singleton.Default();
            }
        }

        internal Completor GetCompletor(SymlContentItem symlContentItem)
        {
            return Completors.FirstOrDefault(p => p.IsItemCompletor(symlContentItem));
        }

    }
}
