using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConfigtEditor.CustomClass
{
    [Serializable]
    [XmlRoot("SynapseCustomClass")]
    public class CustomSynapseListClass
    {

        #region Attributes & Properties

        [XmlArray("List")]
        [XmlArrayItem("CustomClass")]
        public List<CustomSynapseClass> Elements { get; set; }
        #endregion

        #region Constructors & Destructor
        #endregion

        #region Methods
        public static CustomSynapseListClass FromXml(string xml)
        {
            // Safe design
            //if (xml == null) { throw new ArgumentNullException(nameof(xml)); }
            string toParse = xml;
            if (!String.IsNullOrWhiteSpace(toParse))
            {
                var xDoc = XDocument.Parse(toParse);
                var xmlSerializer = new XmlSerializer(typeof(CustomSynapseListClass));

                var mdlInfo = (CustomSynapseListClass)xmlSerializer.Deserialize(xDoc.CreateReader());
                return mdlInfo;
            }
            else
            {
                return new CustomSynapseListClass();
            }
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

            var xmlSerializer = new XmlSerializer(typeof(CustomSynapseListClass));
            xmlSerializer.Serialize(xmlWriter, this, nameSpace);

            return stringwriter.ToString();
        }

        #endregion


    }
}
