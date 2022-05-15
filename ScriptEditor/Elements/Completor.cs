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
    public class Completor
    {
        #region Attributes & Properties
        [XmlElement("Name")]
        public string Name { get; set; }
        private List<string> _listValues = new List<string>();
        [XmlArray("Values")]
        [XmlArrayItem("Value")]
        public List<string> ListValues => _listValues;
        [XmlElement("Type")]
        public CompletorType CompletorType { get; set; }

        [XmlElement("Contain")]
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
                return ListValues.Contains(synapseItem.Value);
            }
            else if (CompletorType == CompletorType.ByName)
            {
                return synapseItem.Name.ToLower().Contains(ContainWord.ToLower());
            }
            else if (CompletorType == CompletorType.ByNameOrValue)
            {
                return synapseItem.Name.ToLower().Contains(ContainWord.ToLower()) || ListValues.Contains(synapseItem.Value);
            }
            else if (CompletorType == CompletorType.ByNameAndValue)
            {
                return synapseItem.Name.ToLower().Contains(ContainWord.ToLower()) && ListValues.Contains(synapseItem.Value);
            }
            return false;
        }
        #endregion

    }
}
