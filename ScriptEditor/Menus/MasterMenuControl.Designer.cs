namespace ConfigtEditor.Menus
{
    partial class MasterMenuControl
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
            this._tabControl = new DevExpress.XtraTab.XtraTabControl();
            this._logo = new System.Windows.Forms.PictureBox();
            this._layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this._logoLayout = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this._tabControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._layoutControl)).BeginInit();
            this._layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._logoLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this._tabControl.Location = new System.Drawing.Point(12, 96);
            this._tabControl.Name = "_tabControl";
            this._tabControl.Size = new System.Drawing.Size(154, 384);
            this._tabControl.TabIndex = 0;
            // 
            // _logo
            // 
            this._logo.Location = new System.Drawing.Point(12, 12);
            this._logo.MaximumSize = new System.Drawing.Size(0, 80);
            this._logo.MinimumSize = new System.Drawing.Size(0, 80);
            this._logo.Name = "_logo";
            this._logo.Size = new System.Drawing.Size(154, 80);
            this._logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._logo.TabIndex = 1;
            this._logo.TabStop = false;
            // 
            // _layoutControl
            // 
            this._layoutControl.Controls.Add(this._tabControl);
            this._layoutControl.Controls.Add(this._logo);
            this._layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._layoutControl.Location = new System.Drawing.Point(0, 0);
            this._layoutControl.Name = "_layoutControl";
            this._layoutControl.Root = this.Root;
            this._layoutControl.Size = new System.Drawing.Size(178, 492);
            this._layoutControl.TabIndex = 2;
            this._layoutControl.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this._logoLayout,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(178, 492);
            this.Root.TextVisible = false;
            // 
            // _logoLayout
            // 
            this._logoLayout.Control = this._logo;
            this._logoLayout.Location = new System.Drawing.Point(0, 0);
            this._logoLayout.MaxSize = new System.Drawing.Size(0, 84);
            this._logoLayout.MinSize = new System.Drawing.Size(95, 84);
            this._logoLayout.Name = "_logoLayout";
            this._logoLayout.Size = new System.Drawing.Size(158, 84);
            this._logoLayout.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this._logoLayout.TextSize = new System.Drawing.Size(0, 0);
            this._logoLayout.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this._tabControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 84);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(158, 388);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // MasterMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._layoutControl);
            this.Name = "MasterMenuControl";
            this.Size = new System.Drawing.Size(178, 492);
            ((System.ComponentModel.ISupportInitialize)(this._tabControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._layoutControl)).EndInit();
            this._layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._logoLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl _tabControl;
        private System.Windows.Forms.PictureBox _logo;
        private DevExpress.XtraLayout.LayoutControl _layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem _logoLayout;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
