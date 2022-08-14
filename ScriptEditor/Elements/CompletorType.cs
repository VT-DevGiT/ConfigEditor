using System;
using System.Xml.Serialization;

namespace ConfigtEditor.Elements
{
    [Serializable]
    [XmlRoot("Type")]
    public class CompletorType : BaseUintElement
    {

        #region Attributes & Properties
        public static CompletorType ByValue => new CompletorType(1, "By value");
        public static CompletorType ByName => new CompletorType(2, "By containing name");
        public static CompletorType ByNameOrValue => new CompletorType(3, "By containing name or value");
        public static CompletorType ByNameAndValue => new CompletorType(4, "By containing name and value");
        public static CompletorType ByIsListContaing => new CompletorType(5, "Parent list containing");

        [XmlElement("Id")]
        public override uint Id { get => base.Id; set => base.Id = value; }

        [XmlElement("Name")]
        public string Name { get; set; }
        

        #endregion

        #region Constructors & Destructor
        public CompletorType()
        {
        }
        public CompletorType(uint id, string name) : this()
        {
            Id = id;
            Name = name;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return Name;
        }
        #endregion

    }
}