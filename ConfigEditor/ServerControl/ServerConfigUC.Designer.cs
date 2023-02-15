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
            this.components = new System.ComponentModel.Container();
            this._port = new DevExpress.XtraEditors.TextEdit();
            this._runButton = new DevExpress.XtraEditors.CheckButton();
            this._undoButton = new DevExpress.XtraEditors.CheckButton();
            this._fileDialog = new System.Windows.Forms.OpenFileDialog();
            this._filePath = new DevExpress.XtraEditors.ButtonEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BindingDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._port.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._filePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
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
            this._runButton.Location = new System.Drawing.Point(156, 39);
            this._runButton.Name = "_runButton";
            this._runButton.Size = new System.Drawing.Size(81, 17);
            this._runButton.TabIndex = 6;
            this._runButton.Text = "Run";
            this._runButton.CheckedChanged += new System.EventHandler(this.RunButton_CheckedChanged);
            // 
            // _undoButton
            // 
            this._undoButton.Location = new System.Drawing.Point(243, 39);
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(81, 17);
            this._undoButton.TabIndex = 8;
            this._undoButton.Text = "Undo";
            this._undoButton.CheckedChanged += new System.EventHandler(this.UndoButton_CheckedChanged);
            // 
            // _fileDialog
            // 
            this._fileDialog.FileName = "openFileDialog1";
            this._fileDialog.Filter = "Secret Admin (SecretAdminL.exe)|SecretAdmin.exe|Local Admin (LocalAdmin.exe)|Loca" +
    "lAdmin.exe";
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
            this.Controls.Add(this._runButton);
            this.Controls.Add(this._port);
            this.MinimumSize = new System.Drawing.Size(330, 55);
            this.Name = "ServerConfigUC";
            this.Size = new System.Drawing.Size(330, 63);
            this.Controls.SetChildIndex(this._port, 0);
            this.Controls.SetChildIndex(this._runButton, 0);
            this.Controls.SetChildIndex(this._undoButton, 0);
            this.Controls.SetChildIndex(this._filePath, 0);
            ((System.ComponentModel.ISupportInitialize)(this.BindingDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._port.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._filePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit _port;
        private DevExpress.XtraEditors.CheckButton _runButton;
        private DevExpress.XtraEditors.CheckButton _undoButton;
        private System.Windows.Forms.OpenFileDialog _fileDialog;
        private DevExpress.XtraEditors.ButtonEdit _filePath;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}
