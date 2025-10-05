using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class Admin
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
            System.Windows.Forms.Label user_NameLabel;
            System.Windows.Forms.Label user_PasswordLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.dSsetting = new RealStateRentSystem.DSTables.DSsetting();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new RealStateRentSystem.DSTables.DSsettingTableAdapters.UsersTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager();
            this.usersBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.usersBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.user_NameTextBox = new System.Windows.Forms.TextBox();
            this.user_PasswordTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            user_NameLabel = new System.Windows.Forms.Label();
            user_PasswordLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingNavigator)).BeginInit();
            this.usersBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // user_NameLabel
            // 
            user_NameLabel.AutoSize = true;
            user_NameLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            user_NameLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            user_NameLabel.Location = new System.Drawing.Point(77, 47);
            user_NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            user_NameLabel.Name = "user_NameLabel";
            user_NameLabel.Size = new System.Drawing.Size(56, 17);
            user_NameLabel.TabIndex = 3;
            user_NameLabel.Text = "الأسم :";
            // 
            // user_PasswordLabel
            // 
            user_PasswordLabel.AutoSize = true;
            user_PasswordLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            user_PasswordLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            user_PasswordLabel.Location = new System.Drawing.Point(49, 79);
            user_PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            user_PasswordLabel.Name = "user_PasswordLabel";
            user_PasswordLabel.Size = new System.Drawing.Size(90, 17);
            user_PasswordLabel.TabIndex = 5;
            user_PasswordLabel.Text = "كلمة المرور :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            label1.Location = new System.Drawing.Point(18, 112);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(125, 17);
            label1.TabIndex = 10;
            label1.Text = "تأكيد كلمة المرور :";
            // 
            // dSsetting
            // 
            this.dSsetting.DataSetName = "DSsetting";
            this.dSsetting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.dSsetting;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.PCinfoTableAdapter = null;
            this.tableAdapterManager.RealStaticTableAdapter = null;
            this.tableAdapterManager.SettingTableAdapter = null;
            this.tableAdapterManager.ShorCutKeysTableAdapter = null;
            this.tableAdapterManager.StaticTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = this.usersTableAdapter;
            // 
            // usersBindingNavigator
            // 
            this.usersBindingNavigator.AddNewItem = null;
            this.usersBindingNavigator.BindingSource = this.usersBindingSource;
            this.usersBindingNavigator.CountItem = null;
            this.usersBindingNavigator.DeleteItem = null;
            this.usersBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.usersBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersBindingNavigatorSaveItem});
            this.usersBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.usersBindingNavigator.MoveFirstItem = null;
            this.usersBindingNavigator.MoveLastItem = null;
            this.usersBindingNavigator.MoveNextItem = null;
            this.usersBindingNavigator.MovePreviousItem = null;
            this.usersBindingNavigator.Name = "usersBindingNavigator";
            this.usersBindingNavigator.PositionItem = null;
            this.usersBindingNavigator.Size = new System.Drawing.Size(348, 27);
            this.usersBindingNavigator.TabIndex = 0;
            this.usersBindingNavigator.Text = "bindingNavigator1";
            // 
            // usersBindingNavigatorSaveItem
            // 
            this.usersBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.usersBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("usersBindingNavigatorSaveItem.Image")));
            this.usersBindingNavigatorSaveItem.Name = "usersBindingNavigatorSaveItem";
            this.usersBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.usersBindingNavigatorSaveItem.Text = "Save Data";
            this.usersBindingNavigatorSaveItem.Click += new System.EventHandler(this.usersBindingNavigatorSaveItem_Click);
            // 
            // user_NameTextBox
            // 
            this.user_NameTextBox.BackColor = System.Drawing.Color.White;
            this.user_NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usersBindingSource, "User_Name", true));
            this.user_NameTextBox.ForeColor = System.Drawing.Color.Silver;
            this.user_NameTextBox.Location = new System.Drawing.Point(136, 43);
            this.user_NameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.user_NameTextBox.Name = "user_NameTextBox";
            this.user_NameTextBox.ReadOnly = true;
            this.user_NameTextBox.Size = new System.Drawing.Size(151, 24);
            this.user_NameTextBox.TabIndex = 4;
            // 
            // user_PasswordTextBox
            // 
            this.user_PasswordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usersBindingSource, "User_Password", true));
            this.user_PasswordTextBox.Location = new System.Drawing.Point(136, 75);
            this.user_PasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.user_PasswordTextBox.Name = "user_PasswordTextBox";
            this.user_PasswordTextBox.Size = new System.Drawing.Size(151, 24);
            this.user_PasswordTextBox.TabIndex = 6;
            this.user_PasswordTextBox.UseSystemPasswordChar = true;
            this.user_PasswordTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.user_NameTextBox_KeyUp);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.usersBindingSource, "User_Password", true));
            this.textBox1.Location = new System.Drawing.Point(136, 107);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(151, 24);
            this.textBox1.TabIndex = 11;
            this.textBox1.UseSystemPasswordChar = true;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.user_NameTextBox_KeyUp);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(348, 138);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(label1);
            this.Controls.Add(user_NameLabel);
            this.Controls.Add(this.user_NameTextBox);
            this.Controls.Add(user_PasswordLabel);
            this.Controls.Add(this.user_PasswordTextBox);
            this.Controls.Add(this.usersBindingNavigator);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(366, 185);
            this.MinimumSize = new System.Drawing.Size(366, 185);
            this.Name = "Admin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator";
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingNavigator)).EndInit();
            this.usersBindingNavigator.ResumeLayout(false);
            this.usersBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSsetting dSsetting;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private DSTables.DSsettingTableAdapters.UsersTableAdapter usersTableAdapter;
        private DSTables.DSsettingTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator usersBindingNavigator;
        private System.Windows.Forms.ToolStripButton usersBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox user_NameTextBox;
        private System.Windows.Forms.TextBox user_PasswordTextBox;
        private System.Windows.Forms.TextBox textBox1;



    }
}