using RealStateRentSystem.DSTables;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    partial class LoginMsg
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
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.tableAdapterManager = new RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager();
        //    this.usersTableAdapter = new RealStateRentSystem.DSTables.DSsettingTableAdapters.UsersTableAdapter();
        //    this.dSsetting = new RealStateRentSystem.DSTables.DSsetting();
        //    this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //    this.groupBox1 = new System.Windows.Forms.GroupBox();
        //    this.Login = new System.Windows.Forms.Button();
        //    this.Cancel = new System.Windows.Forms.Button();
        //    this.pass = new System.Windows.Forms.TextBox();
        //    this.name = new System.Windows.Forms.TextBox();
        //    this.label2 = new System.Windows.Forms.Label();
        //    this.label1 = new System.Windows.Forms.Label();
        //    this.flowLayoutPanelUsers = new System.Windows.Forms.FlowLayoutPanel();
        //    this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        //    this.AutoSize = true;
        //    this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        //    this.SizeChanged += LoginMsg_SizeChanged;

        //    ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
        //    this.groupBox1.SuspendLayout();
        //    this.SuspendLayout();

        //    // 
        //    // tableAdapterManager
        //    // 
        //    this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
        //    this.tableAdapterManager.PCinfoTableAdapter = null;
        //    this.tableAdapterManager.RealStaticTableAdapter = null;
        //    this.tableAdapterManager.SettingTableAdapter = null;
        //    this.tableAdapterManager.ShorCutKeysTableAdapter = null;
        //    this.tableAdapterManager.StaticTableAdapter = null;
        //    this.tableAdapterManager.UsersTableAdapter = this.usersTableAdapter;
        //    this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;

        //    // 
        //    // usersTableAdapter
        //    // 
        //    this.usersTableAdapter.ClearBeforeFill = true;

        //    // 
        //    // dSsetting
        //    // 
        //    this.dSsetting.DataSetName = "DSsetting";
        //    this.dSsetting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

        //    // 
        //    // usersBindingSource
        //    // 
        //    this.usersBindingSource.DataMember = "Users";

        //    // 
        //    // groupBox1
        //    // 
        //    this.groupBox1.Controls.Add(this.Login);
        //    this.groupBox1.Controls.Add(this.Cancel);
        //    this.groupBox1.Controls.Add(this.pass);
        //    this.groupBox1.Controls.Add(this.name);
        //    this.groupBox1.Controls.Add(this.label2);
        //    this.groupBox1.Controls.Add(this.label1);
        //    this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
        //    this.groupBox1.Name = "groupBox1";
        //    this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
        //    //this.groupBox1.Size = new System.Drawing.Size(361, 200);
        //    this.groupBox1.Size = new System.Drawing.Size(500, 250);
        //    this.groupBox1.TabIndex = 6;
        //    this.groupBox1.TabStop = false;

        //    // 
        //    // Login
        //    // 
        //    this.Login.BackColor = System.Drawing.SystemColors.Highlight;
        //    this.Login.ForeColor = System.Drawing.Color.White;
        //    this.Login.Location = new System.Drawing.Point(130, 106);
        //    this.Login.Name = "Login";
        //    this.Login.Size = new System.Drawing.Size(88, 28);
        //    this.Login.TabIndex = 10;
        //    this.Login.Text = "دخول";
        //    this.Login.UseVisualStyleBackColor = false;
        //    this.Login.Click += new System.EventHandler(this.Login_Click);

        //    // 
        //    // Cancel
        //    // 
        //    this.Cancel.BackColor = System.Drawing.SystemColors.Highlight;
        //    this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        //    this.Cancel.ForeColor = System.Drawing.Color.White;
        //    this.Cancel.Location = new System.Drawing.Point(22, 106);
        //    this.Cancel.Name = "Cancel";
        //    this.Cancel.Size = new System.Drawing.Size(88, 28);
        //    this.Cancel.TabIndex = 11;
        //    this.Cancel.Text = "خروج";
        //    this.Cancel.UseVisualStyleBackColor = false;
        //    this.Cancel.Click += new System.EventHandler(this.Cancel_Click);

        //    // 
        //    // pass
        //    // 
        //    this.pass.Location = new System.Drawing.Point(7, 55);
        //    this.pass.Name = "pass";
        //    this.pass.Size = new System.Drawing.Size(224, 24);
        //    this.pass.TabIndex = 9;
        //    this.pass.UseSystemPasswordChar = true;
        //    this.pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.name_KeyDown);

        //    // 
        //    // name
        //    // 
        //    this.name.Location = new System.Drawing.Point(7, 23);
        //    this.name.Name = "name";
        //    this.name.Size = new System.Drawing.Size(224, 24);
        //    this.name.TabIndex = 8;
        //    this.name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.name_KeyDown);
        //    this.name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.name_KeyPress);

        //    // 
        //    // label2
        //    // 
        //    this.label2.AutoSize = true;
        //    this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
        //    this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
        //    this.label2.Location = new System.Drawing.Point(234, 60);
        //    this.label2.Name = "label2";
        //    this.label2.Size = new System.Drawing.Size(90, 17);
        //    this.label2.Text = "كلمة المرور :";

        //    // 
        //    // label1
        //    // 
        //    this.label1.AutoSize = true;
        //    this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
        //    this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
        //    this.label1.Location = new System.Drawing.Point(234, 28);
        //    this.label1.Name = "label1";
        //    this.label1.Size = new System.Drawing.Size(117, 17);
        //    this.label1.Text = "أسم المستخدم :";

        //    // 
        //    // flowLayoutPanelUsers
        //    // 
        //    this.flowLayoutPanelUsers.Name = "flowLayoutPanelUsers";

        //    this.flowLayoutPanelUsers.AutoSize = false;
        //    this.flowLayoutPanelUsers.AutoScroll = true; // علشان يظهر الاسكرول لما يتزاحم
        //    this.flowLayoutPanelUsers.WrapContents = true; // علشان لما العرض يخلص ينزل لتحت
        //    this.flowLayoutPanelUsers.FlowDirection = FlowDirection.LeftToRight; // علشان كل سطر يمشي أفقياً
        //    this.flowLayoutPanelUsers.Dock = DockStyle.Fill; // أو Top مع Height ثابتة حسب تصميمك

        //    // 
        //    // tableLayoutPanel1
        //    // 
        //    this.tableLayoutPanel1.AutoSize = true;
        //    this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        //    this.tableLayoutPanel1.ColumnCount = 1;
        //    this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //    this.tableLayoutPanel1.RowCount = 2;
        //    this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize)); // الصف الأول
        //    this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); // الصف الثاني
        //    this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        //    this.tableLayoutPanel1.Name = "tableLayoutPanel1";

        //    //this.tableLayoutPanel1.Size = new System.Drawing.Size(361, 302);
        //    this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 400);

        //    // ✅ إضافة العناصر داخل الجدول
        //    this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelUsers, 0, 0);
        //    this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);

        //    // 
        //    // LoginMsg
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.BackColor = System.Drawing.Color.White;
        //    //this.ClientSize = new System.Drawing.Size(361, 302);
        //    this.ClientSize = new System.Drawing.Size(500, 400);

        //    this.ControlBox = false;
        //    this.Controls.Add(this.tableLayoutPanel1);
        //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //    this.Name = "LoginMsg";
        //    this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        //    this.RightToLeftLayout = true;
        //    //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        //    this.StartPosition = FormStartPosition.CenterScreen;

        //    this.Text = "Login";
        //    this.Load += new System.EventHandler(this.LoginMsg_Load);
        //    this.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginMsg_Paint);

        //    ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
        //    this.groupBox1.ResumeLayout(false);
        //    this.groupBox1.PerformLayout();
        //    this.ResumeLayout(false);
        //    this.PerformLayout();
        //}

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager();
            this.usersTableAdapter = new RealStateRentSystem.DSTables.DSsettingTableAdapters.UsersTableAdapter();
            this.dSsetting = new RealStateRentSystem.DSTables.DSsetting();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Login = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.pass = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();

            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // إعداد الفورم
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.Name = "LoginMsg";
            this.Text = "Login";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Paint += new PaintEventHandler(this.LoginMsg_Paint);

            // tableLayoutPanel1 (لا تغطي الحواف - لتظهر الحدود)
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new Size(480, 380); // أصغر من الفورم
            this.tableLayoutPanel1.Location = new Point(15, 15); // يترك حواف للإطار
            this.tableLayoutPanel1.Anchor = AnchorStyles.None;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            

            // flowLayoutPanelUsers
            this.flowLayoutPanelUsers.Anchor = AnchorStyles.None;
            this.flowLayoutPanelUsers.AutoScroll = true;
            this.flowLayoutPanelUsers.WrapContents = true;
            this.flowLayoutPanelUsers.FlowDirection = FlowDirection.LeftToRight;
            this.flowLayoutPanelUsers.Size = new Size(480, 100);
            this.flowLayoutPanelUsers.Name = "flowLayoutPanelUsers";

            // groupBox1
            this.groupBox1.Anchor = AnchorStyles.None;
            this.groupBox1.Size = new Size(480, 180);
            this.groupBox1.Controls.Add(this.Login);
            this.groupBox1.Controls.Add(this.Cancel);
            this.groupBox1.Controls.Add(this.pass);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;

            // Login button
            this.Login.BackColor = System.Drawing.SystemColors.Highlight;
            this.Login.ForeColor = Color.White;
            //this.Login.Location = new Point(130, 106);
            this.Login.Location = new Point(241, 130); 
            this.Login.Size = new Size(88, 28);
            this.Login.Text = "دخول";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new EventHandler(this.Login_Click);

            // Cancel button
            this.Cancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.Cancel.ForeColor = Color.White;
            //this.Cancel.Location = new Point(22, 106);
            this.Cancel.Location = new Point(141, 130);
            this.Cancel.Size = new Size(88, 28);
            this.Cancel.Text = "خروج";
            this.Cancel.DialogResult = DialogResult.Cancel;
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new EventHandler(this.Cancel_Click);

            // name textbox
            this.name.Size = new Size(224, 24);
            this.name.Location = new Point(78, 30); 
            this.name.KeyDown += new KeyEventHandler(this.name_KeyDown);
            this.name.KeyPress += new KeyPressEventHandler(this.name_KeyPress);

            // pass textbox
            this.pass.Size = new Size(224, 24);
            this.pass.Location = new Point(78, 70); 
            this.pass.UseSystemPasswordChar = true;
            this.pass.KeyDown += new KeyEventHandler(this.name_KeyDown);

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            this.label1.ForeColor = SystemColors.HotTrack;
            this.label1.Text = "أسم المستخدم :";
            this.label1.RightToLeft = RightToLeft.Yes;
            this.label1.TextAlign = ContentAlignment.MiddleRight;
            this.label1.Size = new Size(100, 24);
            this.label1.Location = new Point(302, 30);

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            this.label2.ForeColor = SystemColors.HotTrack;
            this.label2.Text = "كلمة المرور :";
            this.label2.RightToLeft = RightToLeft.Yes;
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            this.label2.Size = new Size(100, 24);
            this.label2.Location = new Point(302, 70); 

            // إضافة العناصر داخل الـ TableLayoutPanel
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelUsers, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);

            // إضافة الجدول إلى الفورم
            this.Controls.Add(this.tableLayoutPanel1);

            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

       



        #endregion

        private DSTables.DSsettingTableAdapters.TableAdapterManager tableAdapterManager;
        private DSTables.DSsettingTableAdapters.UsersTableAdapter usersTableAdapter;
        private DSsetting dSsetting;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUsers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}