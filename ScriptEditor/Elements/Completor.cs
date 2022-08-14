using ConfigtEditor.Attributes;
using ConfigtEditor.ConfigEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConfigtEditor.Elements
{
    [Serializable]
    [XmlRoot("Completor")]
    public class Completor : BaseUintElement
    {
        #region Attributes & Properties
        [ECSDisplayColumn("Name", 1, 20)]
        [XmlElement("Name")]
        public string Name {get;set;}
        private List<CompletorValue> _listValues = new List<CompletorValue>();
        
        [XmlArray("Values")]
        [XmlArrayItem("Value")]
        public List<CompletorValue> ListValues => _listValues;
        
        [XmlElement("Type")]
        [ECSDisplayColumn("Type", 1, 20)]
        public CompletorType CompletorType { get; set; }

        [XmlElement("Contain")]
        [ECSDisplayColumn("Contain", 1, 12)]
        public string ContainWord { get; set; }

        [XmlElement("CaseSensitive")]
        [ECSDisplayColumn("Case Sensitive", 1, 7)]
        public bool CaseSensitive { get; set; }
        #endregion

        #region Constructors & Destructor

        #endregion

        #region Methods
        public bool IsItemCompletor(SymlContentItem synapseItem)
        {
            // Safe design
            if (synapseItem == null || synapseItem.Value == null) return false;

            if (CompletorType == CompletorType.ByValue)
            {
                return ListValues.Any(p=> p.Value != null && p.Value == synapseItem.Value);
            }
            else if (CompletorType == CompletorType.ByName)
            {
                return CeckSensitiveInsensitive(synapseItem.Name);
            }
            else if (CompletorType == CompletorType.ByNameOrValue)
            {
                return CeckSensitiveInsensitive(synapseItem.Name) || ListValues.Any(p => p.Value != null && p.Value.Contains(synapseItem.Value));
            }
            else if (CompletorType == CompletorType.ByNameAndValue)
            {
                return CeckSensitiveInsensitive(synapseItem.Name) && ListValues.Any(p => p.Value != null && p.Value.Contains(synapseItem.Value));
            }
            else if (CompletorType == CompletorType.ByIsListContaing)
            {
                return CeckSensitiveInsensitive(synapseItem.ParentListName);
            }
            return false;
        }

        private bool CeckSensitiveInsensitive(string name)
        {
            return CaseSensitive ? name.Contains(ContainWord) : name.ToLower().Contains(ContainWord.ToLower());
        }
        #endregion

    }
}
