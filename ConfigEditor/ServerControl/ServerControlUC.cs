#if SERVER_CONTROL
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
using System.Threading;

namespace ConfigEditor.ServerControl
{
    public partial class ServerControlUC : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly Thread _mainThread;

        private IServerControl _serverControl;
        private Queue<(string text, Color color, bool formUser)> _pandingLog;
        private object _logLocker = new object();
        private Task _readLog;

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
            _pandingLog = new Queue<(string text, Color color, bool formUser)>();
            _mainThread = Thread.CurrentThread;
            _readLog = ReadLog();
            _serverControl.Log += AddLog;
            this.Load += (s, e) =>
            {
                var form = this.FindForm();
                form.Shown += CallStart;
                _serverControl.ServerStop += OnServerStop;
                form.FormClosing += (fs, fe) =>
                {
                    this._serverControl.Kill();
                    this._serverControl.Dispose();
                };
            };
        }

        private async Task ReadLog()
        {
            while (true)
            {
                int logsCount;
                lock (_logLocker)
                {
                    logsCount = _pandingLog.Count;
                }
                if (logsCount == 0)
                {
                    await Task.Delay(500);
                    continue;
                }
                (string, Color, bool) log;
                lock (_logLocker)
                {
                    log = _pandingLog.Dequeue();
                }
                AddLog(log.Item1, log.Item2, log.Item3);

            }
        }

        private void OnServerStop(bool closeForm)
        {
            if (closeForm)
            {
                _serverControl.ServerStop -= OnServerStop;
                this.FindForm().Close();
            }
        }

        void CallStart(object fs, EventArgs fe)
        {
            var form = this.FindForm();
            if (form != null)//Null when the user abort the start
            {
                _serverControl.Start();
                form.Shown -= CallStart;
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
            if (Thread.CurrentThread == _mainThread)
            {
                text += "\n";
                var document = this._consoleLog.Document;
                DocumentRange range = document.AppendText(formUser ? "▌" + text : text);
                CharacterProperties cp = document.BeginUpdateCharacters(range);
                if (color != Color.Transparent)
                    cp.ForeColor = color;
                document.EndUpdateCharacters(cp);
            }
            else
            {
                lock(_logLocker)
                {
                    _pandingLog.Enqueue((text, color, formUser));
                }
            }
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
#endif