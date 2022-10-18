using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit;
using ConfigtEditor.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigtEditor.ConfigEditor
{
    class LoadConfigCommand : BaseCommand
    {
        private SymlSectionManager _managerSection;
        private bool _isPermission;

        public LoadConfigCommand(SymlSectionManager managerSection)
        {
            _managerSection = managerSection;
        }

        protected override void ExecuteCommand()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Config Synapse (*.syml)|*.syml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _managerSection.LoadSyml(openFileDialog.FileName);
                }
            }
        }
    }
}
