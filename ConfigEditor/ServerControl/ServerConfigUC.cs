using ConfigtEditor.Commands;
using ConfigtEditor.Controls;
using ConfigtEditor.Elements;
using ConfigtEditor.Utils;
using DevExpress.XtraEditors.Controls;
using System;
using System.Runtime.InteropServices;

namespace ConfigEditor.ServerControl
{
    public partial class ServerConfigUC : ECSEditUserControl
    {
        public StartInfo Info 
        {
            get
            {
                ushort.TryParse(this._port.Text, out ushort port);
                return new StartInfo(this._filePath.Text, port, this._restart.CausesValidation);
            }  
        }

        public bool Allow { get; private set; } = false;

        public ServerConfigUC()
        {
            InitializeComponent();
            this._filePath.BindCommand(new ActionCommand(() => OpenFile()));
            this._filePath.Text = Config.Singleton.ServerConfig?.ExePath ?? string.Empty;
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                this._fileDialog.Filter = "SCP sl Exe (SCPSL.exe)|SCPSL.x86_64";
        }

        private void OpenFile()
        {
            if (this._fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this._filePath.Text = this._fileDialog.FileName;
            }
        }
        
        private void UndoButton_CheckedChanged(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void RunButton_CheckedChanged(object sender, System.EventArgs e)
        {
            Allow = true;
            this.Close();
        }
    }
}
