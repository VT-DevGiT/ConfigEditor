namespace ConfigEditor.ServerControl
{
    partial class ServerConfigUC
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
            this._port = new DevExpress.XtraEditors.TextEdit();
            this._runButton = new DevExpress.XtraEditors.CheckButton();
            this._restart = new DevExpress.XtraEditors.CheckEdit();
            this._undoButton = new DevExpress.XtraEditors.CheckButton();
            this._fileDialog = new System.Windows.Forms.OpenFileDialog();
            this._filePath = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._port.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._restart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._filePath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _port
            // 
            this._port.EditValue = "7777";
            this._port.Location = new System.Drawing.Point(224, 3);
            this._port.Name = "_port";
            this._port.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this._port.Properties.MaskSettings.Set("mask", "000000");
            this._port.Size = new System.Drawing.Size(100, 20);
            this._port.TabIndex = 5;
            // 
            // _runButton
            // 
            this._runButton.Location = new System.Drawing.Point(156, 52);
            this._runButton.Name = "_runButton";
            this._runButton.Size = new System.Drawing.Size(81, 17);
            this._runButton.TabIndex = 6;
            this._runButton.Text = "Run";
            this._runButton.CheckedChanged += new System.EventHandler(this.UndoButton_CheckedChanged);
            // 
            // _restart
            // 
            this._restart.Location = new System.Drawing.Point(0, 29);
            this._restart.Name = "_restart";
            this._restart.Properties.Caption = "Restart After Crash";
            this._restart.Size = new System.Drawing.Size(121, 20);
            this._restart.TabIndex = 7;
            // 
            // _undoButton
            // 
            this._undoButton.Location = new System.Drawing.Point(243, 52);
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(81, 17);
            this._undoButton.TabIndex = 8;
            this._undoButton.Text = "Undo";
            // 
            // _fileDialog
            // 
            this._fileDialog.FileName = "openFileDialog1";
            this._fileDialog.Filter = "SCP sl Exe (SCPSL.exe)|SCPSL.exe";
            // 
            // _filePath
            // 
            this._filePath.Location = new System.Drawing.Point(0, 3);
            this._filePath.Name = "_filePath";
            this._filePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this._filePath.Size = new System.Drawing.Size(220, 20);
            this._filePath.TabIndex = 9;
            // 
            // ServerConfigUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = false;
            this.Controls.Add(this._filePath);
            this.Controls.Add(this._undoButton);
            this.Controls.Add(this._restart);
            this.Controls.Add(this._runButton);
            this.Controls.Add(this._port);
            this.MinimumSize = new System.Drawing.Size(330, 55);
            this.Name = "ServerConfigUC";
            this.Size = new System.Drawing.Size(330, 75);
            this.Controls.SetChildIndex(this._port, 0);
            this.Controls.SetChildIndex(this._runButton, 0);
            this.Controls.SetChildIndex(this._restart, 0);
            this.Controls.SetChildIndex(this._undoButton, 0);
            this.Controls.SetChildIndex(this._filePath, 0);
            ((System.ComponentModel.ISupportInitialize)(this.BindingDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._port.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._restart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._filePath.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit _port;
        private DevExpress.XtraEditors.CheckButton _runButton;
        private DevExpress.XtraEditors.CheckEdit _restart;
        private DevExpress.XtraEditors.CheckButton _undoButton;
        private System.Windows.Forms.OpenFileDialog _fileDialog;
        private DevExpress.XtraEditors.ButtonEdit _filePath;
    }
}
