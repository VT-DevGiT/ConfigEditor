using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace ScriptEditor.Utils
{
    public static class PanelControlExtensions
    {
        #region Methods

        public static void Fill(this PanelControl panelControl, Control control)
        {
            // Safe design
            if (panelControl == null) { throw new ArgumentNullException(nameof(panelControl)); }
            if (control == null) { throw new ArgumentNullException(nameof(control)); }

            panelControl.Controls.Clear();
            panelControl.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        #endregion
    }
}
