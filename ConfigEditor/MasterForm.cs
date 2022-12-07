using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ConfigtEditor.Forms;

namespace ConfigtEditor
{
    public partial class MasterForm : DevExpress.XtraEditors.XtraForm
    {
        public MasterForm()
        {
            InitializeComponent();
            this.FormClosing += MasterForm_FormClosing;
        }

        private void MasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is ECSChildForm)
                {
                    if ((form as ECSChildForm).GetHashCode() == hash)
                    {
                        return form;
                    }
                }
            }
            e.Cancel = true;
        }
    }
}