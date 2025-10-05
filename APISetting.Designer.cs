namespace RealStateRentSystem
{
    partial class APISetting
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APISetting));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.settingBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExport = new System.Windows.Forms.TextBox();
            this.txtImport = new System.Windows.Forms.TextBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingBindingNavigatorSaveItem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(520, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // settingBindingNavigatorSaveItem
            // 
            this.settingBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("settingBindingNavigatorSaveItem.Image")));
            this.settingBindingNavigatorSaveItem.Name = "settingBindingNavigatorSaveItem";
            this.settingBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 28);
            this.settingBindingNavigatorSaveItem.Text = "Save Data";
            this.settingBindingNavigatorSaveItem.Click += new System.EventHandler(this.settingBindingNavigatorSaveItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 50);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(148, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Export Calling Link:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 90);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(165, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Import Caller ID Link:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 130);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Interval:";
            // 
            // txtExport
            // 
            this.txtExport.Location = new System.Drawing.Point(32, 47);
            this.txtExport.Name = "txtExport";
            this.txtExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtExport.Size = new System.Drawing.Size(300, 27);
            this.txtExport.TabIndex = 0;
            // 
            // txtImport
            // 
            this.txtImport.Location = new System.Drawing.Point(32, 87);
            this.txtImport.Name = "txtImport";
            this.txtImport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtImport.Size = new System.Drawing.Size(300, 27);
            this.txtImport.TabIndex = 1;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(32, 127);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInterval.Size = new System.Drawing.Size(300, 27);
            this.txtInterval.TabIndex = 2;
            // 
            // APISetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 180);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.txtImport);
            this.Controls.Add(this.txtExport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "APISetting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعدادات الـ API";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExport;
        private System.Windows.Forms.TextBox txtImport;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.ToolStripButton settingBindingNavigatorSaveItem;
    }
}
