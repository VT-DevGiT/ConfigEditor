using ScriptEditor.Elements;
using ScriptEditor.Interfaces;
using ScriptEditor.Managers;
using ScriptEditor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEditor.CustomClass
{
    public class CustomSynapseClassManager : FixedListManager<CustomSynapseClass>, IWriteManager
    {

        #region Attributes & Properties
        public object CurrentObject { get; set; }
        public CustomSynapseClass Current => CurrentObject as CustomSynapseClass;

        private CustomSynapseListClass liste;
        #endregion

        #region Constructors & Destructor
        public CustomSynapseClassManager() : base()
        {
            // lire du fichier Xml
            LoadXmlFile();
        }
        #endregion

        #region Methods
        public void LoadXmlFile()
        {
            liste = new CustomSynapseListClass();
            _results = liste.Elements;
            this.LoadList();

        }

        internal bool CheckIdInvalid()
        {
            return Elements.Any(p => p.IdClass == Current.IdClass && p.Id != Current.Id);
        }

        public void PrepareNew()
        {
            CurrentObject = new CustomSynapseClass()
            {
                IdClass = 33
            };
        }
        public bool Save()
        {
            if (Current.IsNew())
            {
                Elements.Add(Current);
            }
            Current.Id = (uint)Current.IdClass;
            OnElementListUpdated();
            return true;
        }
        internal void CreateAllClass()
        {
            System.Windows.Forms.MessageBox.Show("Cree all class");
        }
        #endregion

    }
}
