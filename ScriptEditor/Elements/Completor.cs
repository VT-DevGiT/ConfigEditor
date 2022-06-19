using ScriptEditor.Attributes;
using ScriptEditor.ConfigEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScriptEditor.Elements
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
        #endregion

        #region Constructors & Destructor

        #endregion

        #region Methods
        public bool IsItemCompletor(SymlContentItem synapseItem)
        {
            // Safe design
            if (synapseItem == null) return false;

            if (CompletorType == CompletorType.ByValue)
            {
                return ListValues.Contains(new CompletorValue(synapseItem.Value));
            }
            else if (CompletorType == CompletorType.ByName)
            {
                return synapseItem.Name.ToLower().Contains(ContainWord.ToLower());
            }
            else if (CompletorType == CompletorType.ByNameOrValue)
            {
                return synapseItem.Name.ToLower().Contains(ContainWord.ToLower()) || ListValues.Contains(new CompletorValue(synapseItem.Value));
            }
            else if (CompletorType == CompletorType.ByNameAndValue)
            {
                return synapseItem.Name.ToLower().Contains(ContainWord.ToLower()) && ListValues.Contains(new CompletorValue(synapseItem.Value));
            }
            return false;
        }
        #endregion

    }
}
