using ScriptEditor.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScriptEditor.Elements
{
    public class CompletorValue : BaseUintElement
    {
        [ECSDisplayColumn("Value", 1, 20)]
        [XmlElement("Value")]
        public string Value { get; set; }

        public CompletorValue()
        {

        }

        public CompletorValue(string value)
        {
            Id = Config.Singleton.GetCompletorValueId();
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
