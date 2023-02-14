using ConfigEditor.Utils;
using DevExpress.Emf;
using DevExpress.PivotGrid.QueryMode.Sorting;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using DevExpress.Office.Utils;
using ConfigtEditor.Commands;
using ConfigtEditor.Utils;

namespace ConfigEditor.ServerControl
{
    public partial class ServerControlUC : DevExpress.XtraEditors.XtraUserControl
    {
        IServerControl _serverControl;

        public ServerControlUC(bool local)
        {
            InitializeComponent();
            if (Theme.ShouldSystemUseDarkMode())
            {
                this._consoleLog.ActiveView.BackColor = Color.FromArgb(38, 38, 38);
            }
            this._consoleLog.ActiveView.AdjustColorsToSkins = true;
            this._consoleInput.KeyPress += _consoleInput_KeyPress;
            if (local)
            {
                _serverControl = new ServerControlLocal();
            }
            else
            {
                _serverControl = new ServerControlRemote();
            }
            _serverControl.Log += AddLog;
            this.Load += (s, e) =>
            {
                var form = this.FindForm();
                form.Shown += CallStart;
                form.FormClosing += (fs, fe) =>
                {
                    this._serverControl.Kill();
                    this._serverControl.Dispose();
                };
            };

            void CallStart(object fs, EventArgs fe)
            {
                _serverControl.Start();
                this.FindForm().Shown -= CallStart;
            }
        }

        private void _consoleInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendCommand(this._consoleInput.Text);
                this._consoleInput.Text = string.Empty;
            }
        }

        private void AddLog(string text, Color color, bool formUser)
        {
            text += "\n";
            var document = this._consoleLog.Document;
            DocumentRange range = document.AppendText(formUser ? "▌" + text : text);
            CharacterProperties cp = document.BeginUpdateCharacters(range);
            if (color != Color.Transparent)
                cp.ForeColor = color;
            document.EndUpdateCharacters(cp);
        }

        private void AddLog(string text, bool formUser)
        {
            AddLog(text, Color.Transparent, formUser);
        }

        private void SendCommand(string command)
        {
            AddLog(command, true);
            _serverControl.SendCommand(command);
        }
    }
}
