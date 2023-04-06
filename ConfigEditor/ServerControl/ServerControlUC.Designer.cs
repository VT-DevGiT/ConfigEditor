#if SERVER_CONTROL
namespace ConfigEditor.ServerControl
{
    partial class ServerControlUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerControlUC));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this._player = new DevExpress.XtraEditors.PanelControl();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this._consoleInput = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this._consoleLog = new DevExpress.XtraRichEdit.RichEditControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._consoleInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.AccessibleRole = System.Windows.Forms.AccessibleRole.Cell;
            this.layoutControl.AllowHide = false;
            this.layoutControl.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControl.GroupBordersVisible = false;
            this.layoutControl.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.splitterItem1});
            this.layoutControl.Name = "Root";
            this.layoutControl.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControl.Size = new System.Drawing.Size(852, 502);
            this.layoutControl.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this._player;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(252, 502);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // _player
            // 
            this._player.Location = new System.Drawing.Point(2, 2);
            this._player.Name = "_player";
            this._player.Size = new System.Drawing.Size(248, 498);
            this._player.TabIndex = 6;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this._consoleInput;
            this.layoutControlItem2.Location = new System.Drawing.Point(252, 478);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(600, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // _consoleInput
            // 
            this._consoleInput.Location = new System.Drawing.Point(254, 480);
            this._consoleInput.Name = "_consoleInput";
            this._consoleInput.Size = new System.Drawing.Size(596, 20);
            this._consoleInput.StyleController = this.layoutControl1;
            this._consoleInput.TabIndex = 5;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this._consoleLog);
            this.layoutControl1.Controls.Add(this._player);
            this.layoutControl1.Controls.Add(this._consoleInput);
            this.layoutControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(889, 206, 650, 400);
            this.layoutControl1.Root = this.layoutControl;
            this.layoutControl1.Size = new System.Drawing.Size(852, 502);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // _consoleLog
            // 
            this._consoleLog.AccessibleName = "_consoleLog";
            this._consoleLog.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this._consoleLog.Appearance.Text.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._consoleLog.Appearance.Text.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this._consoleLog.Appearance.Text.Options.UseBackColor = true;
            this._consoleLog.Appearance.Text.Options.UseFont = true;
            this._consoleLog.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this._consoleLog.Location = new System.Drawing.Point(254, 12);
            this._consoleLog.Name = "_consoleLog";
            this._consoleLog.Options.AutoCorrect.ReplaceTextAsYouType = false;
            this._consoleLog.Options.Behavior.ShowPopupMenu = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
            this._consoleLog.Options.Import.PlainText.Encoding = ((System.Text.Encoding)(resources.GetObject("_consoleLog.Options.Import.PlainText.Encoding")));
            this._consoleLog.ReadOnly = true;
            this._consoleLog.Size = new System.Drawing.Size(596, 464);
            this._consoleLog.TabIndex = 7;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this._consoleLog;
            this.layoutControlItem1.Location = new System.Drawing.Point(252, 10);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(600, 468);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(252, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(600, 10);
            // 
            // ServerControlUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ServerControlUC";
            this.Size = new System.Drawing.Size(852, 502);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._consoleInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup layoutControl;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit _consoleInput;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.PanelControl _player;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraRichEdit.RichEditControl _consoleLog;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
#endif