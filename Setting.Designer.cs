using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class Setting
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
            System.Windows.Forms.Label remainderingDaysLabel;
            System.Windows.Forms.Label remainderingPeriodLabel;
            System.Windows.Forms.Label remainderingPeriodEmptyLabel;
            System.Windows.Forms.Label backUpTimeLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label phoneNumerLengthLabel;
            System.Windows.Forms.Label mobileNumerLengthLabel;
            System.Windows.Forms.Label portnameLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIsWriterDevice = new System.Windows.Forms.CheckBox();
            this.hasModemCheckBox = new System.Windows.Forms.CheckBox();
            this.settingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSsetting = new RealStateRentSystem.DSTables.DSsetting();
            this.DataFolderPath_btn = new System.Windows.Forms.Button();
            this.DataFolderPath_txt = new System.Windows.Forms.TextBox();
            this.portnameTextBox = new System.Windows.Forms.TextBox();
            this.mobileNumerLengthTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumerLengthTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sBackUpPathTextBox = new System.Windows.Forms.TextBox();
            this.sBackUpTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.backUpPathTextBox = new System.Windows.Forms.TextBox();
            this.backUpNameTextBox = new System.Windows.Forms.TextBox();
            this.brows = new System.Windows.Forms.Button();
            this.remainderingDaysTextBox = new System.Windows.Forms.TextBox();
            this.remainderingPeriodTextBox = new System.Windows.Forms.TextBox();
            this.remainderingPeriodEmptyTextBox = new System.Windows.Forms.TextBox();
            this.backUpTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.settingBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.settingBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.fdlg = new System.Windows.Forms.SaveFileDialog();
            this.settingTableAdapter = new RealStateRentSystem.DSTables.DSsettingTableAdapters.SettingTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager();
            remainderingDaysLabel = new System.Windows.Forms.Label();
            remainderingPeriodLabel = new System.Windows.Forms.Label();
            remainderingPeriodEmptyLabel = new System.Windows.Forms.Label();
            backUpTimeLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            phoneNumerLengthLabel = new System.Windows.Forms.Label();
            mobileNumerLengthLabel = new System.Windows.Forms.Label();
            portnameLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingBindingNavigator)).BeginInit();
            this.settingBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // remainderingDaysLabel
            // 
            remainderingDaysLabel.AutoSize = true;
            remainderingDaysLabel.Font = new System.Drawing.Font("Tahoma", 8F);
            remainderingDaysLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            remainderingDaysLabel.Location = new System.Drawing.Point(509, 46);
            remainderingDaysLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            remainderingDaysLabel.Name = "remainderingDaysLabel";
            remainderingDaysLabel.Size = new System.Drawing.Size(179, 19);
            remainderingDaysLabel.TabIndex = 2;
            remainderingDaysLabel.Text = "عدد الأيام لتفعيل التنبيه :";
            // 
            // remainderingPeriodLabel
            // 
            remainderingPeriodLabel.AutoSize = true;
            remainderingPeriodLabel.Font = new System.Drawing.Font("Tahoma", 8F);
            remainderingPeriodLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            remainderingPeriodLabel.Location = new System.Drawing.Point(509, 84);
            remainderingPeriodLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            remainderingPeriodLabel.Name = "remainderingPeriodLabel";
            remainderingPeriodLabel.Size = new System.Drawing.Size(157, 19);
            remainderingPeriodLabel.TabIndex = 4;
            remainderingPeriodLabel.Text = "فترة تكرار التنبيه كلــ :";
            // 
            // remainderingPeriodEmptyLabel
            // 
            remainderingPeriodEmptyLabel.AutoSize = true;
            remainderingPeriodEmptyLabel.Font = new System.Drawing.Font("Tahoma", 8F);
            remainderingPeriodEmptyLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            remainderingPeriodEmptyLabel.Location = new System.Drawing.Point(509, 122);
            remainderingPeriodEmptyLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            remainderingPeriodEmptyLabel.Name = "remainderingPeriodEmptyLabel";
            remainderingPeriodEmptyLabel.Size = new System.Drawing.Size(278, 19);
            remainderingPeriodEmptyLabel.TabIndex = 6;
            remainderingPeriodEmptyLabel.Text = "الفترة المتبقية لوضع العقار ضمن الغارغ :";
            // 
            // backUpTimeLabel
            // 
            backUpTimeLabel.AutoSize = true;
            backUpTimeLabel.Font = new System.Drawing.Font("Tahoma", 8F);
            backUpTimeLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            backUpTimeLabel.Location = new System.Drawing.Point(510, 163);
            backUpTimeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            backUpTimeLabel.Name = "backUpTimeLabel";
            backUpTimeLabel.Size = new System.Drawing.Size(289, 19);
            backUpTimeLabel.TabIndex = 8;
            backUpTimeLabel.Text = "الوقت اليومي لتفعيل النسخة الأحتياطية :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F);
            label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            label1.Location = new System.Drawing.Point(63, 83);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 19);
            label1.TabIndex = 12;
            label1.Text = "دقيقة .";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8F);
            label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            label2.Location = new System.Drawing.Point(67, 46);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(39, 19);
            label2.TabIndex = 13;
            label2.Text = "يوم .";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8F);
            label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            label3.Location = new System.Drawing.Point(73, 120);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(39, 19);
            label3.TabIndex = 14;
            label3.Text = "يوم .";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8F);
            label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            label4.Location = new System.Drawing.Point(509, 196);
            label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(229, 19);
            label4.TabIndex = 18;
            label4.Text = "مسار تخزين النسخة الأحتياطية :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8F);
            label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            label5.Location = new System.Drawing.Point(510, 239);
            label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(333, 19);
            label5.TabIndex = 21;
            label5.Text = "الوقت اليومي لتفعيل النسخة الأحتياطية الثانيه :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8F);
            label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            label6.Location = new System.Drawing.Point(509, 277);
            label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(273, 19);
            label6.TabIndex = 22;
            label6.Text = "مسار تخزين النسخة الأحتياطية الثانية :";
            // 
            // phoneNumerLengthLabel
            // 
            phoneNumerLengthLabel.AutoSize = true;
            phoneNumerLengthLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            phoneNumerLengthLabel.Location = new System.Drawing.Point(513, 312);
            phoneNumerLengthLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            phoneNumerLengthLabel.Name = "phoneNumerLengthLabel";
            phoneNumerLengthLabel.Size = new System.Drawing.Size(131, 19);
            phoneNumerLengthLabel.TabIndex = 23;
            phoneNumerLengthLabel.Text = "طول ارقام الهاتف :";
            // 
            // mobileNumerLengthLabel
            // 
            mobileNumerLengthLabel.AutoSize = true;
            mobileNumerLengthLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            mobileNumerLengthLabel.Location = new System.Drawing.Point(516, 350);
            mobileNumerLengthLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            mobileNumerLengthLabel.Name = "mobileNumerLengthLabel";
            mobileNumerLengthLabel.Size = new System.Drawing.Size(140, 19);
            mobileNumerLengthLabel.TabIndex = 24;
            mobileNumerLengthLabel.Text = "طول ارقام الموبايل :";
            // 
            // portnameLabel
            // 
            portnameLabel.AutoSize = true;
            portnameLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            portnameLabel.Location = new System.Drawing.Point(516, 388);
            portnameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            portnameLabel.Name = "portnameLabel";
            portnameLabel.Size = new System.Drawing.Size(133, 19);
            portnameLabel.TabIndex = 25;
            portnameLabel.Text = "اسم بورت المودم :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            label7.Location = new System.Drawing.Point(517, 463);
            label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(143, 19);
            label7.TabIndex = 27;
            label7.Text = "مسار مجلد البيانات:";
            label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            label8.Location = new System.Drawing.Point(517, 419);
            label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(136, 19);
            label8.TabIndex = 33;
            label8.Text = "تسجيل المكالمات:";
            label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIsWriterDevice);
            this.groupBox1.Controls.Add(label8);
            this.groupBox1.Controls.Add(this.hasModemCheckBox);
            this.groupBox1.Controls.Add(this.DataFolderPath_btn);
            this.groupBox1.Controls.Add(this.DataFolderPath_txt);
            this.groupBox1.Controls.Add(label7);
            this.groupBox1.Controls.Add(portnameLabel);
            this.groupBox1.Controls.Add(this.portnameTextBox);
            this.groupBox1.Controls.Add(mobileNumerLengthLabel);
            this.groupBox1.Controls.Add(this.mobileNumerLengthTextBox);
            this.groupBox1.Controls.Add(phoneNumerLengthLabel);
            this.groupBox1.Controls.Add(this.phoneNumerLengthTextBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(label6);
            this.groupBox1.Controls.Add(label5);
            this.groupBox1.Controls.Add(this.sBackUpPathTextBox);
            this.groupBox1.Controls.Add(this.sBackUpTimeDateTimePicker);
            this.groupBox1.Controls.Add(label4);
            this.groupBox1.Controls.Add(this.backUpPathTextBox);
            this.groupBox1.Controls.Add(this.backUpNameTextBox);
            this.groupBox1.Controls.Add(this.brows);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(remainderingDaysLabel);
            this.groupBox1.Controls.Add(this.remainderingDaysTextBox);
            this.groupBox1.Controls.Add(remainderingPeriodLabel);
            this.groupBox1.Controls.Add(this.remainderingPeriodTextBox);
            this.groupBox1.Controls.Add(remainderingPeriodEmptyLabel);
            this.groupBox1.Controls.Add(this.remainderingPeriodEmptyTextBox);
            this.groupBox1.Controls.Add(backUpTimeLabel);
            this.groupBox1.Controls.Add(this.backUpTimeDateTimePicker);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(13, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(897, 559);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الأعدادات الأوليه للنظام";
            // 
            // chkIsWriterDevice
            // 
            this.chkIsWriterDevice.Location = new System.Drawing.Point(464, 419);
            this.chkIsWriterDevice.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsWriterDevice.Name = "chkIsWriterDevice";
            this.chkIsWriterDevice.Size = new System.Drawing.Size(27, 28);
            this.chkIsWriterDevice.TabIndex = 34;
            this.chkIsWriterDevice.UseVisualStyleBackColor = true;
            // 
            // hasModemCheckBox
            // 
            this.hasModemCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingBindingSource, "HasModem", true));
            this.hasModemCheckBox.Location = new System.Drawing.Point(84, 385);
            this.hasModemCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.hasModemCheckBox.Name = "hasModemCheckBox";
            this.hasModemCheckBox.Size = new System.Drawing.Size(27, 28);
            this.hasModemCheckBox.TabIndex = 32;
            this.hasModemCheckBox.UseVisualStyleBackColor = true;
            // 
            // settingBindingSource
            // 
            this.settingBindingSource.DataMember = "Setting";
            this.settingBindingSource.DataSource = this.dSsetting;
            // 
            // dSsetting
            // 
            this.dSsetting.DataSetName = "DSsetting";
            this.dSsetting.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataFolderPath_btn
            // 
            this.DataFolderPath_btn.Location = new System.Drawing.Point(10, 469);
            this.DataFolderPath_btn.Margin = new System.Windows.Forms.Padding(5);
            this.DataFolderPath_btn.Name = "DataFolderPath_btn";
            this.DataFolderPath_btn.Size = new System.Drawing.Size(113, 33);
            this.DataFolderPath_btn.TabIndex = 31;
            this.DataFolderPath_btn.Text = "استعراض";
            this.DataFolderPath_btn.UseVisualStyleBackColor = true;
            this.DataFolderPath_btn.Click += new System.EventHandler(this.DataFolderPath_btn_Click);
            // 
            // DataFolderPath_txt
            // 
            this.DataFolderPath_txt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "DataFolderPath", true));
            this.DataFolderPath_txt.Location = new System.Drawing.Point(129, 460);
            this.DataFolderPath_txt.Margin = new System.Windows.Forms.Padding(5);
            this.DataFolderPath_txt.Multiline = true;
            this.DataFolderPath_txt.Name = "DataFolderPath_txt";
            this.DataFolderPath_txt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DataFolderPath_txt.Size = new System.Drawing.Size(363, 46);
            this.DataFolderPath_txt.TabIndex = 28;
            this.DataFolderPath_txt.TextChanged += new System.EventHandler(this.DataFolderPath_txt_TextChanged);
            // 
            // portnameTextBox
            // 
            this.portnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "Portname", true));
            this.portnameTextBox.Location = new System.Drawing.Point(127, 382);
            this.portnameTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.portnameTextBox.Name = "portnameTextBox";
            this.portnameTextBox.Size = new System.Drawing.Size(363, 27);
            this.portnameTextBox.TabIndex = 26;
            // 
            // mobileNumerLengthTextBox
            // 
            this.mobileNumerLengthTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "MobileNumerLength", true));
            this.mobileNumerLengthTextBox.Location = new System.Drawing.Point(129, 344);
            this.mobileNumerLengthTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.mobileNumerLengthTextBox.Name = "mobileNumerLengthTextBox";
            this.mobileNumerLengthTextBox.Size = new System.Drawing.Size(361, 27);
            this.mobileNumerLengthTextBox.TabIndex = 25;
            this.mobileNumerLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneNumerLengthTextBox_KeyPress);
            // 
            // phoneNumerLengthTextBox
            // 
            this.phoneNumerLengthTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "PhoneNumerLength", true));
            this.phoneNumerLengthTextBox.Location = new System.Drawing.Point(127, 309);
            this.phoneNumerLengthTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.phoneNumerLengthTextBox.Name = "phoneNumerLengthTextBox";
            this.phoneNumerLengthTextBox.Size = new System.Drawing.Size(363, 27);
            this.phoneNumerLengthTextBox.TabIndex = 24;
            this.phoneNumerLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneNumerLengthTextBox_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 266);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 33);
            this.button1.TabIndex = 23;
            this.button1.Text = "استعراض";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sBackUpPathTextBox
            // 
            this.sBackUpPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "SBackUpPath", true));
            this.sBackUpPathTextBox.Location = new System.Drawing.Point(129, 271);
            this.sBackUpPathTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.sBackUpPathTextBox.Name = "sBackUpPathTextBox";
            this.sBackUpPathTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sBackUpPathTextBox.Size = new System.Drawing.Size(361, 27);
            this.sBackUpPathTextBox.TabIndex = 20;
            this.sBackUpPathTextBox.TextChanged += new System.EventHandler(this.sBackUpPathTextBox_TextChanged);
            // 
            // sBackUpTimeDateTimePicker
            // 
            this.sBackUpTimeDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.settingBindingSource, "SBackUpTime", true));
            this.sBackUpTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.sBackUpTimeDateTimePicker.Location = new System.Drawing.Point(129, 233);
            this.sBackUpTimeDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.sBackUpTimeDateTimePicker.Name = "sBackUpTimeDateTimePicker";
            this.sBackUpTimeDateTimePicker.RightToLeftLayout = true;
            this.sBackUpTimeDateTimePicker.ShowUpDown = true;
            this.sBackUpTimeDateTimePicker.Size = new System.Drawing.Size(361, 27);
            this.sBackUpTimeDateTimePicker.TabIndex = 19;
            // 
            // backUpPathTextBox
            // 
            this.backUpPathTextBox.BackColor = System.Drawing.Color.White;
            this.backUpPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "BackUpPath", true));
            this.backUpPathTextBox.Location = new System.Drawing.Point(127, 195);
            this.backUpPathTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.backUpPathTextBox.Name = "backUpPathTextBox";
            this.backUpPathTextBox.ReadOnly = true;
            this.backUpPathTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.backUpPathTextBox.Size = new System.Drawing.Size(363, 27);
            this.backUpPathTextBox.TabIndex = 17;
            this.backUpPathTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.remainderingDaysTextBox_KeyUp);
            // 
            // backUpNameTextBox
            // 
            this.backUpNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "BackUpName", true));
            this.backUpNameTextBox.Location = new System.Drawing.Point(8, 158);
            this.backUpNameTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.backUpNameTextBox.Name = "backUpNameTextBox";
            this.backUpNameTextBox.Size = new System.Drawing.Size(111, 27);
            this.backUpNameTextBox.TabIndex = 16;
            this.backUpNameTextBox.Visible = false;
            // 
            // brows
            // 
            this.brows.Location = new System.Drawing.Point(8, 190);
            this.brows.Margin = new System.Windows.Forms.Padding(5);
            this.brows.Name = "brows";
            this.brows.Size = new System.Drawing.Size(113, 33);
            this.brows.TabIndex = 15;
            this.brows.Text = "استعراض";
            this.brows.UseVisualStyleBackColor = true;
            this.brows.Click += new System.EventHandler(this.brows_Click);
            // 
            // remainderingDaysTextBox
            // 
            this.remainderingDaysTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "RemainderingDays", true));
            this.remainderingDaysTextBox.Location = new System.Drawing.Point(129, 43);
            this.remainderingDaysTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.remainderingDaysTextBox.Name = "remainderingDaysTextBox";
            this.remainderingDaysTextBox.Size = new System.Drawing.Size(361, 27);
            this.remainderingDaysTextBox.TabIndex = 3;
            this.remainderingDaysTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneNumerLengthTextBox_KeyPress);
            this.remainderingDaysTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.remainderingDaysTextBox_KeyUp);
            // 
            // remainderingPeriodTextBox
            // 
            this.remainderingPeriodTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "RemainderingPeriod", true));
            this.remainderingPeriodTextBox.Location = new System.Drawing.Point(129, 81);
            this.remainderingPeriodTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.remainderingPeriodTextBox.Name = "remainderingPeriodTextBox";
            this.remainderingPeriodTextBox.Size = new System.Drawing.Size(361, 27);
            this.remainderingPeriodTextBox.TabIndex = 5;
            this.remainderingPeriodTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneNumerLengthTextBox_KeyPress);
            this.remainderingPeriodTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.remainderingDaysTextBox_KeyUp);
            // 
            // remainderingPeriodEmptyTextBox
            // 
            this.remainderingPeriodEmptyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "RemainderingPeriodEmpty", true));
            this.remainderingPeriodEmptyTextBox.Location = new System.Drawing.Point(129, 119);
            this.remainderingPeriodEmptyTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.remainderingPeriodEmptyTextBox.Name = "remainderingPeriodEmptyTextBox";
            this.remainderingPeriodEmptyTextBox.Size = new System.Drawing.Size(361, 27);
            this.remainderingPeriodEmptyTextBox.TabIndex = 7;
            this.remainderingPeriodEmptyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phoneNumerLengthTextBox_KeyPress);
            this.remainderingPeriodEmptyTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.remainderingDaysTextBox_KeyUp);
            // 
            // backUpTimeDateTimePicker
            // 
            this.backUpTimeDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.settingBindingSource, "BackUpTime", true));
            this.backUpTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.backUpTimeDateTimePicker.Location = new System.Drawing.Point(129, 157);
            this.backUpTimeDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.backUpTimeDateTimePicker.Name = "backUpTimeDateTimePicker";
            this.backUpTimeDateTimePicker.RightToLeftLayout = true;
            this.backUpTimeDateTimePicker.ShowUpDown = true;
            this.backUpTimeDateTimePicker.Size = new System.Drawing.Size(361, 27);
            this.backUpTimeDateTimePicker.TabIndex = 9;
            // 
            // settingBindingNavigator
            // 
            this.settingBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.settingBindingNavigator.BindingSource = this.settingBindingSource;
            this.settingBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.settingBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.settingBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.settingBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.settingBindingNavigatorSaveItem});
            this.settingBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.settingBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.settingBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.settingBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.settingBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.settingBindingNavigator.Name = "settingBindingNavigator";
            this.settingBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.settingBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.settingBindingNavigator.Size = new System.Drawing.Size(910, 29);
            this.settingBindingNavigator.TabIndex = 1;
            this.settingBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 25);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            this.bindingNavigatorCountItem.Visible = false;
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Visible = false;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 26);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Visible = false;
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 26);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Visible = false;
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(73, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            this.bindingNavigatorPositionItem.Visible = false;
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Visible = false;
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Visible = false;
            // 
            // settingBindingNavigatorSaveItem
            // 
            this.settingBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("settingBindingNavigatorSaveItem.Image")));
            this.settingBindingNavigatorSaveItem.Name = "settingBindingNavigatorSaveItem";
            this.settingBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 24);
            this.settingBindingNavigatorSaveItem.Text = "Save Data";
            this.settingBindingNavigatorSaveItem.Click += new System.EventHandler(this.settingBindingNavigatorSaveItem_Click_1);
            // 
            // settingTableAdapter
            // 
            this.settingTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.PCinfoTableAdapter = null;
            this.tableAdapterManager.RealStaticTableAdapter = null;
            this.tableAdapterManager.SettingTableAdapter = this.settingTableAdapter;
            this.tableAdapterManager.ShorCutKeysTableAdapter = null;
            this.tableAdapterManager.StaticTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSsettingTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(910, 595);
            this.Controls.Add(this.settingBindingNavigator);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(802, 386);
            this.Name = "Setting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اعدادت النظام";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSsetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingBindingNavigator)).EndInit();
            this.settingBindingNavigator.ResumeLayout(false);
            this.settingBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DSsetting dSsetting;
        private System.Windows.Forms.BindingSource settingBindingSource;
        private DSTables.DSsettingTableAdapters.SettingTableAdapter settingTableAdapter;
        private DSTables.DSsettingTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator settingBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton settingBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox remainderingDaysTextBox;
        private System.Windows.Forms.TextBox remainderingPeriodTextBox;
        private System.Windows.Forms.TextBox remainderingPeriodEmptyTextBox;
        private System.Windows.Forms.DateTimePicker backUpTimeDateTimePicker;
        private System.Windows.Forms.Button brows;
        private System.Windows.Forms.TextBox backUpNameTextBox;
        private System.Windows.Forms.SaveFileDialog fdlg;
        private System.Windows.Forms.TextBox backUpPathTextBox;
        private System.Windows.Forms.DateTimePicker sBackUpTimeDateTimePicker;
        private System.Windows.Forms.TextBox sBackUpPathTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox portnameTextBox;
        private System.Windows.Forms.TextBox mobileNumerLengthTextBox;
        private System.Windows.Forms.TextBox phoneNumerLengthTextBox;
        private System.Windows.Forms.Button DataFolderPath_btn;
        private System.Windows.Forms.TextBox DataFolderPath_txt;
        private System.Windows.Forms.CheckBox hasModemCheckBox;
        private System.Windows.Forms.CheckBox chkIsWriterDevice;
    }
}