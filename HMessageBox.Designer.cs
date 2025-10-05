using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class HMessageBox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label region_IDLabel;
            System.Windows.Forms.Label buildingLabel;
            System.Windows.Forms.Label subResgionIDLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label ownerLabel;
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.view = new System.Windows.Forms.Button();
            this.realStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSrealstate = new RealStateRentSystem.DSTables.DSrealstate();
            this.realStateTableAdapter = new RealStateRentSystem.DSTables.DSrealstateTableAdapters.RealStateTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSrealstateTableAdapters.TableAdapterManager();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ownerTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.days = new System.Windows.Forms.TextBox();
            this.buildingTextBox = new System.Windows.Forms.TextBox();
            this.subResgionIDTextBox = new System.Windows.Forms.TextBox();
            this.region_IDTextBox = new System.Windows.Forms.TextBox();
            this.Bg_Panel = new System.Windows.Forms.Panel();
            region_IDLabel = new System.Windows.Forms.Label();
            buildingLabel = new System.Windows.Forms.Label();
            subResgionIDLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ownerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.realStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealstate)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Bg_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // region_IDLabel
            // 
            region_IDLabel.AutoSize = true;
            region_IDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            region_IDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            region_IDLabel.Location = new System.Drawing.Point(394, 60);
            region_IDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            region_IDLabel.Name = "region_IDLabel";
            region_IDLabel.Size = new System.Drawing.Size(110, 17);
            region_IDLabel.TabIndex = 12;
            region_IDLabel.Text = "اسم المنطقة  : ";
            // 
            // buildingLabel
            // 
            buildingLabel.AutoSize = true;
            buildingLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            buildingLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            buildingLabel.Location = new System.Drawing.Point(400, 139);
            buildingLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            buildingLabel.Name = "buildingLabel";
            buildingLabel.Size = new System.Drawing.Size(47, 17);
            buildingLabel.TabIndex = 14;
            buildingLabel.Text = "البناء :";
            // 
            // subResgionIDLabel
            // 
            subResgionIDLabel.AutoSize = true;
            subResgionIDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            subResgionIDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            subResgionIDLabel.Location = new System.Drawing.Point(394, 113);
            subResgionIDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            subResgionIDLabel.Name = "subResgionIDLabel";
            subResgionIDLabel.Size = new System.Drawing.Size(134, 17);
            subResgionIDLabel.TabIndex = 21;
            subResgionIDLabel.Text = "الجزيرة \\ الشارع  : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            label1.Location = new System.Drawing.Point(400, 164);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(85, 17);
            label1.TabIndex = 23;
            label1.Text = "الإنتهاء بعد :";
            // 
            // ownerLabel
            // 
            ownerLabel.AutoSize = true;
            ownerLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            ownerLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            ownerLabel.Location = new System.Drawing.Point(394, 87);
            ownerLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            ownerLabel.Name = "ownerLabel";
            ownerLabel.Size = new System.Drawing.Size(109, 17);
            ownerLabel.TabIndex = 37;
            ownerLabel.Text = "صاحب المنزل : ";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(363, 228);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "الغاء";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(11, 176);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 21);
            this.lblTimer.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(153, 228);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 28);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "تجاهل";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 6);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 17);
            this.lblTitle.TabIndex = 8;
            // 
            // view
            // 
            this.view.BackColor = System.Drawing.SystemColors.Highlight;
            this.view.Cursor = System.Windows.Forms.Cursors.Hand;
            this.view.ForeColor = System.Drawing.Color.White;
            this.view.Location = new System.Drawing.Point(258, 228);
            this.view.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(101, 28);
            this.view.TabIndex = 9;
            this.view.Text = "مطالعه";
            this.view.UseVisualStyleBackColor = false;
            this.view.Click += new System.EventHandler(this.view_Click);
            // 
            // realStateBindingSource
            // 
            this.realStateBindingSource.DataMember = "RealState";
            this.realStateBindingSource.DataSource = this.dSrealstate;
            // 
            // dSrealstate
            // 
            this.dSrealstate.DataSetName = "DSrealstate";
            this.dSrealstate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // realStateTableAdapter
            // 
            this.realStateTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AttachmentTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BuildingTypeTableAdapter = null;
            this.tableAdapterManager.EventTableAdapter = null;
            this.tableAdapterManager.InvestitureTableAdapter = null;
            this.tableAdapterManager.RealStateTableAdapter = this.realStateTableAdapter;
            this.tableAdapterManager.RegionTableAdapter = null;
            this.tableAdapterManager.StatusTypeTableAdapter = null;
            this.tableAdapterManager.SubRegionsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSrealstateTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            this.tableAdapterManager.WayOfRentTableAdapter = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(179, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "ايام";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(38, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "عدد التنيهات";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ownerTextBox);
            this.groupBox1.Controls.Add(ownerLabel);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.days);
            this.groupBox1.Controls.Add(this.buildingTextBox);
            this.groupBox1.Controls.Add(this.subResgionIDTextBox);
            this.groupBox1.Controls.Add(this.region_IDTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(region_IDLabel);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.lblTimer);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.view);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(buildingLabel);
            this.groupBox1.Controls.Add(subResgionIDLabel);
            this.groupBox1.Location = new System.Drawing.Point(3, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(529, 262);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // ownerTextBox
            // 
            this.ownerTextBox.Location = new System.Drawing.Point(221, 82);
            this.ownerTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ownerTextBox.Name = "ownerTextBox";
            this.ownerTextBox.Size = new System.Drawing.Size(175, 24);
            this.ownerTextBox.TabIndex = 38;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RealStateRentSystem.Properties.Resources.AG00040_;
            this.pictureBox2.Location = new System.Drawing.Point(15, 41);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(149, 140);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // days
            // 
            this.days.Location = new System.Drawing.Point(221, 160);
            this.days.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.days.Name = "days";
            this.days.Size = new System.Drawing.Size(175, 24);
            this.days.TabIndex = 34;
            // 
            // buildingTextBox
            // 
            this.buildingTextBox.Location = new System.Drawing.Point(221, 134);
            this.buildingTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buildingTextBox.Name = "buildingTextBox";
            this.buildingTextBox.Size = new System.Drawing.Size(175, 24);
            this.buildingTextBox.TabIndex = 33;
            // 
            // subResgionIDTextBox
            // 
            this.subResgionIDTextBox.Location = new System.Drawing.Point(221, 108);
            this.subResgionIDTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.subResgionIDTextBox.Name = "subResgionIDTextBox";
            this.subResgionIDTextBox.Size = new System.Drawing.Size(175, 24);
            this.subResgionIDTextBox.TabIndex = 31;
            // 
            // region_IDTextBox
            // 
            this.region_IDTextBox.Location = new System.Drawing.Point(221, 57);
            this.region_IDTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.region_IDTextBox.Name = "region_IDTextBox";
            this.region_IDTextBox.Size = new System.Drawing.Size(175, 24);
            this.region_IDTextBox.TabIndex = 30;
            this.region_IDTextBox.Text = "dadasd";
            // 
            // Bg_Panel
            // 
            this.Bg_Panel.Controls.Add(this.groupBox1);
            this.Bg_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bg_Panel.Location = new System.Drawing.Point(0, 0);
            this.Bg_Panel.Name = "Bg_Panel";
            this.Bg_Panel.Size = new System.Drawing.Size(535, 269);
            this.Bg_Panel.TabIndex = 9;
            // 
            // HMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 269);
            this.Controls.Add(this.Bg_Panel);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "HMessageBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " تنبيه";
            this.Load += new System.EventHandler(this.HMessageBox_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HMessageBox_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.realStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealstate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Bg_Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button view;
        private DSrealstate dSrealstate;
        private System.Windows.Forms.BindingSource realStateBindingSource;
        private DSTables.DSrealstateTableAdapters.RealStateTableAdapter realStateTableAdapter;
        private DSTables.DSrealstateTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox region_IDTextBox;
        private System.Windows.Forms.TextBox days;
        private System.Windows.Forms.TextBox buildingTextBox;
        private System.Windows.Forms.TextBox subResgionIDTextBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox ownerTextBox;
        private System.Windows.Forms.Panel Bg_Panel;
    }
}