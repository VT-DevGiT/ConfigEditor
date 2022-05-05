using ScriptEditor.Attributes;
using ScriptEditor.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScriptEditor.CustomClass
{
    [Serializable]
    [XmlRoot("CustomClass")]
    public class CustomSynapseClass : BaseUintElement, INotifyPropertyChanged
    {

        #region Attributes & Properties
        [XmlElement("Name")]
        [ECSDisplayColumn("Name", 1, 12)]
        [ECSRequired()]
        public string Name { get; set; }

        private int _idClass;
        [XmlElement("Id")]
        [ECSDisplayColumn("Id", 2, 8, ECSDisplayColumnAttribute.TextAlign.Right)]
        [ECSRequired()]
        public int IdClass
        {
            get { return _idClass; }
            set
            {
                _idClass = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors & Destructor
        #endregion

        #region Methods
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }
}
