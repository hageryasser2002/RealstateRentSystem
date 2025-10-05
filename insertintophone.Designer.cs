using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class insertintophone
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label p1Label;
            System.Windows.Forms.Label m2Label;
            System.Windows.Forms.Label otherLabel;
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.dSphone = new RealStateRentSystem.DSTables.DSphone();
            this.phoneTableAdapter = new RealStateRentSystem.DSTables.DSphoneTableAdapters.PhoneTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSphoneTableAdapters.TableAdapterManager();
            this.phoneBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.phoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.phoneBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.iDTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.p1TextBox = new System.Windows.Forms.TextBox();
            this.m2TextBox = new System.Windows.Forms.TextBox();
            this.otherTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.p2TextBox = new System.Windows.Forms.TextBox();
            this.m3TextBox = new System.Windows.Forms.TextBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.dataofchangedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.userTextBox = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            p1Label = new System.Windows.Forms.Label();
            m2Label = new System.Windows.Forms.Label();
            otherLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSphone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBindingNavigator)).BeginInit();
            this.phoneBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new System.Drawing.Font("Tahoma", 8F);
            nameLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            nameLabel.Location = new System.Drawing.Point(229, 44);
            nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(53, 17);
            nameLabel.TabIndex = 35;
            nameLabel.Text = "الاسم :";
            // 
            // p1Label
            // 
            p1Label.AutoSize = true;
            p1Label.Font = new System.Drawing.Font("Tahoma", 8F);
            p1Label.ForeColor = System.Drawing.SystemColors.HotTrack;
            p1Label.Location = new System.Drawing.Point(229, 76);
            p1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            p1Label.Name = "p1Label";
            p1Label.Size = new System.Drawing.Size(47, 17);
            p1Label.TabIndex = 36;
            p1Label.Text = "هاتف :";
            // 
            // m2Label
            // 
            m2Label.AutoSize = true;
            m2Label.Font = new System.Drawing.Font("Tahoma", 8F);
            m2Label.ForeColor = System.Drawing.SystemColors.HotTrack;
            m2Label.Location = new System.Drawing.Point(229, 111);
            m2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            m2Label.Name = "m2Label";
            m2Label.Size = new System.Drawing.Size(52, 17);
            m2Label.TabIndex = 37;
            m2Label.Text = "موبايل :";
            // 
            // otherLabel
            // 
            otherLabel.AutoSize = true;
            otherLabel.Font = new System.Drawing.Font("Tahoma", 8F);
            otherLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            otherLabel.Location = new System.Drawing.Point(229, 143);
            otherLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            otherLabel.Name = "otherLabel";
            otherLabel.Size = new System.Drawing.Size(35, 17);
            otherLabel.TabIndex = 38;
            otherLabel.Text = "أخر :";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // dSphone
            // 
            this.dSphone.DataSetName = "DSphone";
            this.dSphone.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // phoneTableAdapter
            // 
            this.phoneTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.PhoneAttachTableAdapter = null;
            this.tableAdapterManager.phoneEventTableAdapter = null;
            this.tableAdapterManager.PhoneTableAdapter = this.phoneTableAdapter;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSphoneTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // phoneBindingNavigator
            // 
            this.phoneBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.phoneBindingNavigator.BindingSource = this.phoneBindingSource;
            this.phoneBindingNavigator.CountItem = null;
            this.phoneBindingNavigator.DeleteItem = null;
            this.phoneBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.phoneBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phoneBindingNavigatorSaveItem,
            this.bindingNavigatorAddNewItem});
            this.phoneBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.phoneBindingNavigator.MoveFirstItem = null;
            this.phoneBindingNavigator.MoveLastItem = null;
            this.phoneBindingNavigator.MoveNextItem = null;
            this.phoneBindingNavigator.MovePreviousItem = null;
            this.phoneBindingNavigator.Name = "phoneBindingNavigator";
            this.phoneBindingNavigator.PositionItem = null;
            this.phoneBindingNavigator.Size = new System.Drawing.Size(374, 25);
            this.phoneBindingNavigator.TabIndex = 9;
            this.phoneBindingNavigator.Text = "bindingNavigator1";
            // 
            // phoneBindingSource
            // 
            this.phoneBindingSource.DataMember = "Phone";
            this.phoneBindingSource.DataSource = this.dSphone;
            // 
            // phoneBindingNavigatorSaveItem
            // 
            this.phoneBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.phoneBindingNavigatorSaveItem.Name = "phoneBindingNavigatorSaveItem";
            this.phoneBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 22);
            this.phoneBindingNavigatorSaveItem.Text = "Save Data";
            this.phoneBindingNavigatorSaveItem.Click += new System.EventHandler(this.phoneBindingNavigatorSaveItem_Click);
            // 
            // iDTextBox
            // 
            this.iDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBindingSource, "ID", true));
            this.iDTextBox.Location = new System.Drawing.Point(141, 0);
            this.iDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.iDTextBox.Name = "iDTextBox";
            this.iDTextBox.Size = new System.Drawing.Size(11, 24);
            this.iDTextBox.TabIndex = 16;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(43, 38);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(174, 24);
            this.nameTextBox.TabIndex = 1;
            // 
            // p1TextBox
            // 
            this.p1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBindingSource, "p1", true));
            this.p1TextBox.Location = new System.Drawing.Point(43, 70);
            this.p1TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.p1TextBox.Name = "p1TextBox";
            this.p1TextBox.Size = new System.Drawing.Size(174, 24);
            this.p1TextBox.TabIndex = 2;
            this.p1TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1TextBox_KeyPress);
            // 
            // m2TextBox
            // 
            this.m2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBindingSource, "m2", true));
            this.m2TextBox.Location = new System.Drawing.Point(43, 105);
            this.m2TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.m2TextBox.Name = "m2TextBox";
            this.m2TextBox.Size = new System.Drawing.Size(174, 24);
            this.m2TextBox.TabIndex = 3;
            this.m2TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1TextBox_KeyPress);
            // 
            // otherTextBox
            // 
            this.otherTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBindingSource, "other", true));
            this.otherTextBox.Location = new System.Drawing.Point(43, 137);
            this.otherTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.otherTextBox.Name = "otherTextBox";
            this.otherTextBox.Size = new System.Drawing.Size(174, 24);
            this.otherTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(222, 210);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "الوقت :";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(111, 206);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeftLayout = true;
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(106, 24);
            this.dateTimePicker2.TabIndex = 6;
            this.dateTimePicker2.Value = new System.DateTime(2010, 11, 17, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(222, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "التاريخ :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(nameLabel);
            this.groupBox1.Controls.Add(p1Label);
            this.groupBox1.Controls.Add(this.iDTextBox);
            this.groupBox1.Controls.Add(m2Label);
            this.groupBox1.Controls.Add(otherLabel);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.p1TextBox);
            this.groupBox1.Controls.Add(this.m2TextBox);
            this.groupBox1.Controls.Add(this.otherTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Login);
            this.groupBox1.Controls.Add(this.p2TextBox);
            this.groupBox1.Controls.Add(this.m3TextBox);
            this.groupBox1.Controls.Add(this.notesTextBox);
            this.groupBox1.Controls.Add(this.dataofchangedDateTimePicker);
            this.groupBox1.Controls.Add(this.userTextBox);
            this.groupBox1.Location = new System.Drawing.Point(0, -18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(374, 265);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(103, 237);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 28);
            this.button3.TabIndex = 40;
            this.button3.Text = "بدون حفظ بالهاتف";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(264, 237);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 28);
            this.button2.TabIndex = 39;
            this.button2.Text = "حفظ بالهاتف";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 171);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(106, 24);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Value = new System.DateTime(2011, 2, 23, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(7, 238);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "الغاء الامر";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.SystemColors.Highlight;
            this.Login.ForeColor = System.Drawing.Color.White;
            this.Login.Location = new System.Drawing.Point(8, 282);
            this.Login.Margin = new System.Windows.Forms.Padding(4);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(88, 28);
            this.Login.TabIndex = 10;
            this.Login.Text = "تم";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Visible = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // p2TextBox
            // 
            this.p2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBindingSource, "p2", true));
            this.p2TextBox.Location = new System.Drawing.Point(16, -1);
            this.p2TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.p2TextBox.Name = "p2TextBox";
            this.p2TextBox.Size = new System.Drawing.Size(37, 24);
            this.p2TextBox.TabIndex = 22;
            // 
            // m3TextBox
            // 
            this.m3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBindingSource, "m3", true));
            this.m3TextBox.Location = new System.Drawing.Point(76, -1);
            this.m3TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.m3TextBox.Name = "m3TextBox";
            this.m3TextBox.Size = new System.Drawing.Size(19, 24);
            this.m3TextBox.TabIndex = 26;
            // 
            // notesTextBox
            // 
            this.notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBindingSource, "notes", true));
            this.notesTextBox.Location = new System.Drawing.Point(103, -1);
            this.notesTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(12, 24);
            this.notesTextBox.TabIndex = 30;
            // 
            // dataofchangedDateTimePicker
            // 
            this.dataofchangedDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.phoneBindingSource, "dataofchanged", true));
            this.dataofchangedDateTimePicker.Location = new System.Drawing.Point(160, -1);
            this.dataofchangedDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dataofchangedDateTimePicker.Name = "dataofchangedDateTimePicker";
            this.dataofchangedDateTimePicker.Size = new System.Drawing.Size(47, 24);
            this.dataofchangedDateTimePicker.TabIndex = 32;
            // 
            // userTextBox
            // 
            this.userTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phoneBindingSource, "user", true));
            this.userTextBox.Location = new System.Drawing.Point(296, -1);
            this.userTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(12, 24);
            this.userTextBox.TabIndex = 34;
            // 
            // insertintophone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(374, 254);
            this.ControlBox = false;
            this.Controls.Add(this.phoneBindingNavigator);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(392, 301);
            this.MinimumSize = new System.Drawing.Size(344, 301);
            this.Name = "insertintophone";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "معلومات الموعد";
            this.Load += new System.EventHandler(this.LoginMsg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSphone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBindingNavigator)).EndInit();
            this.phoneBindingNavigator.ResumeLayout(false);
            this.phoneBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private DSphone dSphone;
        private DSTables.DSphoneTableAdapters.PhoneTableAdapter phoneTableAdapter;
        private DSTables.DSphoneTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator phoneBindingNavigator;
        private System.Windows.Forms.BindingSource phoneBindingSource;
        private System.Windows.Forms.ToolStripButton phoneBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox iDTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox p1TextBox;
        private System.Windows.Forms.TextBox m2TextBox;
        private System.Windows.Forms.TextBox otherTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox p2TextBox;
        private System.Windows.Forms.TextBox m3TextBox;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.DateTimePicker dataofchangedDateTimePicker;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}