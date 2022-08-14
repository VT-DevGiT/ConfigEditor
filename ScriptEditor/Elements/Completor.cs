﻿using ConfigtEditor.Attributes;
using ConfigtEditor.ConfigEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                string info = $"{synapseItem.Name} {synapseItem.ParentListName} {synapseItem.ParentComment}";
                return CheckContains(info);
            }
 
            return false;
        }

        private bool CheckContains(string value)
        {
            if (String.IsNullOrWhiteSpace(ContainWord))
            {
                return false;
            }
            var allOrWord = ContainWord.Split('|');
            bool result = false;
            int i = 0;
            while (!result && i < allOrWord.Count())
            {
                result = CheckAndWord(value, allOrWord[i]);
                i++;
            }

            return result;// CaseSensitive ? value.Contains(word) : value.ToLower().Contains(word.ToLower());
        }

        private bool CheckAndWord(string value, string word)
        {
            var allWord = word.Split('&');
            bool result = true;
            int i = 0;
            while (result && i < allWord.Count())
            {
                result = CeckSensitiveInsensitive(value, allWord[i]);
                i++;
            }
            return result;
        }
        private bool CeckSensitiveInsensitive(string value, string word)
        {
            return CaseSensitive ? value.Contains(word) : value.ToLower().Contains(word.ToLower());
        }
        #endregion

    }
}
