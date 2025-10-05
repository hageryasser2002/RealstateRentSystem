using RealStateRentSystem.DSTables;
namespace RealStateRentSystem
{
    partial class ToOwnPrametr
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
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager();
            this.usersTableAdapter = new RealStateRentSystem.DSTables.DSsettingTableAdapters.UsersTableAdapter();
            this.dSsetting = new RealStateRentSystem.DSTables.DSsetting();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.wayOFOwnerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSrealowner = new RealStateRentSystem.DSTables.DSrealowner();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wayOFOwnerTableAdapter = new RealStateRentSystem.DSTables.DSrealownerTableAdapters.WayOFOwnerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wayOFOwnerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealowner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // dSsetting
            // 
            this.dSsetting.DataSetName = "DSsetting";
            this.dSsetting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Login);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(479, 248);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(284, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "طريقة البيع :";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.wayOFOwnerBindingSource;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(50, 80);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 27);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.ValueMember = "ID";
            // 
            // wayOFOwnerBindingSource
            // 
            this.wayOFOwnerBindingSource.DataMember = "WayOFOwner";
            this.wayOFOwnerBindingSource.DataSource = this.dSrealowner;
            // 
            // dSrealowner
            // 
            this.dSrealowner.DataSetName = "DSrealowner";
            this.dSrealowner.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 39);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 27);
            this.textBox1.TabIndex = 13;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(329, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "السعر:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(248, 153);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "الغاء الامر";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.SystemColors.Highlight;
            this.Login.ForeColor = System.Drawing.Color.White;
            this.Login.Location = new System.Drawing.Point(88, 153);
            this.Login.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(113, 33);
            this.Login.TabIndex = 10;
            this.Login.Text = "تم";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            // 
            // wayOFOwnerTableAdapter
            // 
            this.wayOFOwnerTableAdapter.ClearBeforeFill = true;
            // 
            // ToOwnPrametr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(478, 242);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ToOwnPrametr";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نسخ الى البيع";
            this.Load += new System.EventHandler(this.ToOwnPrametr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wayOFOwnerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealowner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSTables.DSsettingTableAdapters.TableAdapterManager tableAdapterManager;
        private DSTables.DSsettingTableAdapters.UsersTableAdapter usersTableAdapter;
        private DSsetting dSsetting;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private DSrealowner dSrealowner;
        private System.Windows.Forms.BindingSource wayOFOwnerBindingSource;
        private DSTables.DSrealownerTableAdapters.WayOFOwnerTableAdapter wayOFOwnerTableAdapter;
    }
}