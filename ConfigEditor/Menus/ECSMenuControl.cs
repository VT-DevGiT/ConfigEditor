using System;
using System.ComponentModel;
using System.Linq;
using ConfigtEditor.Elements;
using ConfigtEditor.Metadatas;
using ConfigtEditor.Utils;
using DevExpress.XtraNavBar;


namespace ConfigtEditor.Menus
{
    /// <summary>
    /// Control to manage the menu that appears on the left side of the application
    /// </summary>
    [ToolboxItem(false)]
    public class ECSMenuControl : NavBarControl
    {
        #region Constructors & Destructor

        public ECSMenuControl(string text) : this()
        {
            // Safe design
            if (String.IsNullOrWhiteSpace(text)) { throw new ArgumentNullException(nameof(text)); }

            Text = text;
        }


        private ECSMenuControl() : base()
        {
            Visible = false;
            Groups.CollectionChanged += Groups_CollectionChanged;
            Groups.CollectionItemChanged += Groups_CollectionItemChanged;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Adds a group to the menu (a group holds menu items)
        /// </summary>
        public ECSMenuGroup AddGroup(ECSMenuGroup group)
        {
            // Safe design
            if (group == null) { throw new ArgumentNullException(nameof(group)); }

            return this.Groups.Add(group) as ECSMenuGroup;
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ECSMenuControl
            // 
            this.OptionsNavPane.ExpandedWidth = 140;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        #region Events

        private void Groups_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            Visible = (Groups.Count > 0) && Groups.Any(g => g.VisibleItemLinks.Any());
        }

        private void Groups_CollectionItemChanged(object sender, CollectionItemEventArgs e)
        {
            Visible = (Groups.Count > 0) && Groups.Any(g => g.VisibleItemLinks.Any());
        }

        #endregion
    }
}