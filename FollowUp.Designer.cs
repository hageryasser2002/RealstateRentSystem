using RealStateRentSystem.DSTables;
using RealStateRentSystem.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RealStateRentSystem.FollowUp
{
    partial class FollowUp
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
            this.careerCatogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dScareer = new RealStateRentSystem.DSTables.DScareer();
            this.typeOfcarrerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panelCardsContainer = new System.Windows.Forms.Panel();
            this.flowLayoutPanelCards = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCustomerDetails = new System.Windows.Forms.Panel();
            this.groupBoxCustomerDetails = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkShowArchived = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDischarge = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxRequestType = new System.Windows.Forms.GroupBox();
            this.txtEvents = new System.Windows.Forms.TextBox();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.txtVia = new System.Windows.Forms.TextBox();
            this.txtPhoneDetails = new System.Windows.Forms.TextBox();
            this.txtMobile22 = new System.Windows.Forms.TextBox();
            this.txtMobile1 = new System.Windows.Forms.TextBox();
            this.txtNameDetails = new System.Windows.Forms.TextBox();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblRequest = new System.Windows.Forms.Label();
            this.lblVia = new System.Windows.Forms.Label();
            this.lblPhoneDetails = new System.Windows.Forms.Label();
            this.lblMobile2 = new System.Windows.Forms.Label();
            this.lblMobile1 = new System.Windows.Forms.Label();
            this.lblNameDetails = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.typeOfcarrerTableAdapter = new RealStateRentSystem.DSTables.DScareerTableAdapters.TypeOfcarrerTableAdapter();
            this.careerCatogTableAdapter = new RealStateRentSystem.DSTables.DScareerTableAdapters.careerCatogTableAdapter();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.panelFilterCard = new System.Windows.Forms.Panel();
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.panelCustomerDetailsContainer = new System.Windows.Forms.Panel();
            this.groupBoxAppointments = new System.Windows.Forms.GroupBox();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.dtpAppointment = new System.Windows.Forms.DateTimePicker();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnDeleteAppointment = new System.Windows.Forms.Button();
            this.btnGreetings = new System.Windows.Forms.Button();
            this.Top_panel = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.eventTextBox = new System.Windows.Forms.TextBox();
            this.searchtext = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.eventLabel = new System.Windows.Forms.Label();
            this.eventDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.eventBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.activeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2Details = new System.Windows.Forms.GroupBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.lblCompanyReference = new System.Windows.Forms.Label();
            this.txtCompanyReference = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.otherLabel = new System.Windows.Forms.Label();
            this.btnCall5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCall4 = new System.Windows.Forms.Button();
            this.mobileLabel = new System.Windows.Forms.Label();
            this.btnCall1 = new System.Windows.Forms.Button();
            this.phone_oneLabel = new System.Windows.Forms.Label();
            this.btnCall2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Gm2 = new System.Windows.Forms.Label();
            this.txtMobile2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.Gm1 = new System.Windows.Forms.Label();
            this.Gp1 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.txtPhoneOne = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.btnBackToCards = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.colAppointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppointmentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.careerCatogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dScareer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeOfcarrerBindingSource)).BeginInit();
            this.panelCardsContainer.SuspendLayout();
            this.panelCustomerDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelFilterCard.SuspendLayout();
            this.panelMainContainer.SuspendLayout();
            this.panelCustomerDetailsContainer.SuspendLayout();
            this.groupBoxAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingNavigator)).BeginInit();
            this.eventBindingNavigator.SuspendLayout();
            this.groupBox2Details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dScareer
            // 
            this.dScareer.DataSetName = "DScareer";
            this.dScareer.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(478, 52);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(180, 27);
            this.txtPhone.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(478, 15);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(180, 27);
            this.txtName.TabIndex = 1;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblPhone.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPhone.Location = new System.Drawing.Point(725, 63);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(59, 19);
            this.lblPhone.TabIndex = 85;
            this.lblPhone.Text = "هاتف :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblName.Location = new System.Drawing.Point(725, 26);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 19);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "الاسم :";
            // 
            // panelCardsContainer
            // 
            this.panelCardsContainer.Controls.Add(this.flowLayoutPanelCards);
            this.panelCardsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardsContainer.Location = new System.Drawing.Point(0, 0);
            this.panelCardsContainer.Margin = new System.Windows.Forms.Padding(4);
            this.panelCardsContainer.Name = "panelCardsContainer";
            this.panelCardsContainer.Size = new System.Drawing.Size(1200, 445);
            this.panelCardsContainer.TabIndex = 2;
            // 
            // flowLayoutPanelCards
            // 
            this.flowLayoutPanelCards.AutoScroll = true;
            this.flowLayoutPanelCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.flowLayoutPanelCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelCards.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelCards.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelCards.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelCards.Name = "flowLayoutPanelCards";
            this.flowLayoutPanelCards.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.flowLayoutPanelCards.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanelCards.Size = new System.Drawing.Size(1200, 445);
            this.flowLayoutPanelCards.TabIndex = 1;
            this.flowLayoutPanelCards.WrapContents = false;
            this.flowLayoutPanelCards.Resize += new System.EventHandler(this.flowLayoutPanelCards_Resize);
            // 
            // panelCustomerDetails
            // 
            this.panelCustomerDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCustomerDetails.BackColor = System.Drawing.Color.White;
            this.panelCustomerDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCustomerDetails.Controls.Add(this.groupBoxCustomerDetails);
            this.panelCustomerDetails.Location = new System.Drawing.Point(0, 700);
            this.panelCustomerDetails.Margin = new System.Windows.Forms.Padding(4);
            this.panelCustomerDetails.Name = "panelCustomerDetails";
            this.panelCustomerDetails.Size = new System.Drawing.Size(1200, 0);
            this.panelCustomerDetails.TabIndex = 3;
            this.panelCustomerDetails.Visible = false;
            // 
            // groupBoxCustomerDetails
            // 
            this.groupBoxCustomerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCustomerDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCustomerDetails.Name = "groupBoxCustomerDetails";
            this.groupBoxCustomerDetails.Size = new System.Drawing.Size(1198, 0);
            this.groupBoxCustomerDetails.TabIndex = 0;
            this.groupBoxCustomerDetails.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.chkShowArchived);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnDischarge);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblPhone);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(939, 207);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // chkShowArchived
            // 
            this.chkShowArchived.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkShowArchived.Location = new System.Drawing.Point(650, 101);
            this.chkShowArchived.Name = "chkShowArchived";
            this.chkShowArchived.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkShowArchived.Size = new System.Drawing.Size(165, 24);
            this.chkShowArchived.TabIndex = 0;
            this.chkShowArchived.Text = " : في الارشيف";
            this.chkShowArchived.CheckedChanged += new System.EventHandler(this.chkShowArchived_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(286, 146);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 39);
            this.button1.TabIndex = 96;
            this.button1.Text = "بحث";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDischarge
            // 
            this.btnDischarge.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDischarge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDischarge.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnDischarge.ForeColor = System.Drawing.Color.White;
            this.btnDischarge.Location = new System.Drawing.Point(473, 146);
            this.btnDischarge.Margin = new System.Windows.Forms.Padding(5);
            this.btnDischarge.Name = "btnDischarge";
            this.btnDischarge.Size = new System.Drawing.Size(179, 39);
            this.btnDischarge.TabIndex = 95;
            this.btnDischarge.Text = "تفريغ";
            this.btnDischarge.UseVisualStyleBackColor = false;
            this.btnDischarge.Click += new System.EventHandler(this.btnDischarge_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox4.Location = new System.Drawing.Point(210, 83);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox4.Size = new System.Drawing.Size(94, 26);
            this.checkBox4.TabIndex = 94;
            this.checkBox4.Text = "استئجار";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox3.Location = new System.Drawing.Point(123, 83);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox3.Size = new System.Drawing.Size(80, 26);
            this.checkBox3.TabIndex = 93;
            this.checkBox3.Text = "اكساء";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox2.Location = new System.Drawing.Point(53, 83);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox2.Size = new System.Drawing.Size(60, 26);
            this.checkBox2.TabIndex = 92;
            this.checkBox2.Text = "أخر";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox1.Location = new System.Drawing.Point(308, 83);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox1.Size = new System.Drawing.Size(73, 26);
            this.checkBox1.TabIndex = 91;
            this.checkBox1.Text = "شراء";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(411, 316);
            this.textBox3.Margin = new System.Windows.Forms.Padding(5);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox3.Size = new System.Drawing.Size(370, 98);
            this.textBox3.TabIndex = 156;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(548, 245);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(233, 29);
            this.textBox2.TabIndex = 153;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(513, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 29);
            this.textBox1.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(292, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 86;
            this.label1.Text = "عن طريق :";
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(0, 0);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(100, 27);
            this.textBox33.TabIndex = 0;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(0, 0);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(100, 27);
            this.textBox22.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 160;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.Color.Blue;
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(130, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(951, 221);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            // 
            // groupBoxRequestType
            // 
            this.groupBoxRequestType.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRequestType.Name = "groupBoxRequestType";
            this.groupBoxRequestType.Size = new System.Drawing.Size(200, 100);
            this.groupBoxRequestType.TabIndex = 0;
            this.groupBoxRequestType.TabStop = false;
            // 
            // txtEvents
            // 
            this.txtEvents.Location = new System.Drawing.Point(0, 0);
            this.txtEvents.Name = "txtEvents";
            this.txtEvents.Size = new System.Drawing.Size(100, 27);
            this.txtEvents.TabIndex = 0;
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(0, 0);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(100, 27);
            this.txtRequest.TabIndex = 0;
            // 
            // txtVia
            // 
            this.txtVia.Location = new System.Drawing.Point(0, 0);
            this.txtVia.Name = "txtVia";
            this.txtVia.Size = new System.Drawing.Size(100, 27);
            this.txtVia.TabIndex = 0;
            // 
            // txtPhoneDetails
            // 
            this.txtPhoneDetails.Location = new System.Drawing.Point(0, 0);
            this.txtPhoneDetails.Name = "txtPhoneDetails";
            this.txtPhoneDetails.Size = new System.Drawing.Size(100, 27);
            this.txtPhoneDetails.TabIndex = 0;
            // 
            // txtMobile22
            // 
            this.txtMobile22.Location = new System.Drawing.Point(0, 0);
            this.txtMobile22.Name = "txtMobile22";
            this.txtMobile22.Size = new System.Drawing.Size(100, 27);
            this.txtMobile22.TabIndex = 0;
            // 
            // txtMobile1
            // 
            this.txtMobile1.Location = new System.Drawing.Point(0, 0);
            this.txtMobile1.Name = "txtMobile1";
            this.txtMobile1.Size = new System.Drawing.Size(100, 27);
            this.txtMobile1.TabIndex = 0;
            // 
            // txtNameDetails
            // 
            this.txtNameDetails.Location = new System.Drawing.Point(0, 0);
            this.txtNameDetails.Name = "txtNameDetails";
            this.txtNameDetails.Size = new System.Drawing.Size(100, 27);
            this.txtNameDetails.TabIndex = 0;
            // 
            // lblEvents
            // 
            this.lblEvents.Location = new System.Drawing.Point(0, 0);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEvents.Size = new System.Drawing.Size(100, 23);
            this.lblEvents.TabIndex = 0;
            // 
            // lblRequest
            // 
            this.lblRequest.Location = new System.Drawing.Point(0, 0);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRequest.Size = new System.Drawing.Size(100, 23);
            this.lblRequest.TabIndex = 0;
            // 
            // lblVia
            // 
            this.lblVia.Location = new System.Drawing.Point(0, 0);
            this.lblVia.Name = "lblVia";
            this.lblVia.Size = new System.Drawing.Size(100, 23);
            this.lblVia.TabIndex = 0;
            // 
            // lblPhoneDetails
            // 
            this.lblPhoneDetails.Location = new System.Drawing.Point(0, 0);
            this.lblPhoneDetails.Name = "lblPhoneDetails";
            this.lblPhoneDetails.Size = new System.Drawing.Size(100, 23);
            this.lblPhoneDetails.TabIndex = 0;
            // 
            // lblMobile2
            // 
            this.lblMobile2.Location = new System.Drawing.Point(0, 0);
            this.lblMobile2.Name = "lblMobile2";
            this.lblMobile2.Size = new System.Drawing.Size(100, 23);
            this.lblMobile2.TabIndex = 0;
            // 
            // lblMobile1
            // 
            this.lblMobile1.Location = new System.Drawing.Point(0, 0);
            this.lblMobile1.Name = "lblMobile1";
            this.lblMobile1.Size = new System.Drawing.Size(100, 23);
            this.lblMobile1.TabIndex = 0;
            // 
            // lblNameDetails
            // 
            this.lblNameDetails.Location = new System.Drawing.Point(0, 0);
            this.lblNameDetails.Name = "lblNameDetails";
            this.lblNameDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNameDetails.Size = new System.Drawing.Size(100, 23);
            this.lblNameDetails.TabIndex = 0;
            // 
            // typeOfcarrerTableAdapter
            // 
            this.typeOfcarrerTableAdapter.ClearBeforeFill = true;
            // 
            // careerCatogTableAdapter
            // 
            this.careerCatogTableAdapter.ClearBeforeFill = true;
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(200, 100);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            // 
            // panelFilterCard
            // 
            this.panelFilterCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelFilterCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilterCard.Controls.Add(this.groupBox2);
            this.panelFilterCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilterCard.Location = new System.Drawing.Point(0, 0);
            this.panelFilterCard.Margin = new System.Windows.Forms.Padding(4);
            this.panelFilterCard.Name = "panelFilterCard";
            this.panelFilterCard.Size = new System.Drawing.Size(1200, 255);
            this.panelFilterCard.TabIndex = 0;
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Controls.Add(this.panelCustomerDetailsContainer);
            this.panelMainContainer.Controls.Add(this.panelCardsContainer);
            this.panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContainer.Location = new System.Drawing.Point(0, 255);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(1200, 445);
            this.panelMainContainer.TabIndex = 4;
            // 
            // panelCustomerDetailsContainer
            // 
            this.panelCustomerDetailsContainer.AutoScroll = true;
            this.panelCustomerDetailsContainer.BackColor = System.Drawing.Color.White;
            this.panelCustomerDetailsContainer.Controls.Add(this.groupBoxAppointments);
            this.panelCustomerDetailsContainer.Controls.Add(this.btnGreetings);
            this.panelCustomerDetailsContainer.Controls.Add(this.Top_panel);
            this.panelCustomerDetailsContainer.Controls.Add(this.groupBox5);
            this.panelCustomerDetailsContainer.Controls.Add(this.groupBox2Details);
            this.panelCustomerDetailsContainer.Controls.Add(this.btnBackToCards);
            this.panelCustomerDetailsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomerDetailsContainer.Location = new System.Drawing.Point(0, 0);
            this.panelCustomerDetailsContainer.Name = "panelCustomerDetailsContainer";
            this.panelCustomerDetailsContainer.Size = new System.Drawing.Size(1200, 445);
            this.panelCustomerDetailsContainer.TabIndex = 0;
            this.panelCustomerDetailsContainer.Visible = false;
            // 
            // groupBoxAppointments
            // 
            this.groupBoxAppointments.Controls.Add(this.dgvAppointments);
            this.groupBoxAppointments.Controls.Add(this.dtpAppointment);
            this.groupBoxAppointments.Controls.Add(this.btnAddAppointment);
            this.groupBoxAppointments.Controls.Add(this.btnDeleteAppointment);
            this.groupBoxAppointments.Location = new System.Drawing.Point(865, 502);
            this.groupBoxAppointments.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxAppointments.Name = "groupBoxAppointments";
            this.groupBoxAppointments.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxAppointments.Size = new System.Drawing.Size(859, 323);
            this.groupBoxAppointments.TabIndex = 108;
            this.groupBoxAppointments.TabStop = false;
            this.groupBoxAppointments.Text = "المواعيد";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAppointmentDate,
            this.colAppointmentTime});
            this.dgvAppointments.Location = new System.Drawing.Point(9, 70);
            this.dgvAppointments.Margin = new System.Windows.Forms.Padding(5);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.Size = new System.Drawing.Size(828, 230);
            this.dgvAppointments.TabIndex = 3;
            // 
            // dtpAppointment
            // 
            this.dtpAppointment.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointment.Location = new System.Drawing.Point(373, 25);
            this.dtpAppointment.Margin = new System.Windows.Forms.Padding(5);
            this.dtpAppointment.Name = "dtpAppointment";
            this.dtpAppointment.RightToLeftLayout = true;
            this.dtpAppointment.Size = new System.Drawing.Size(200, 29);
            this.dtpAppointment.TabIndex = 0;
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddAppointment.ForeColor = System.Drawing.Color.White;
            this.btnAddAppointment.Location = new System.Drawing.Point(250, 22);
            this.btnAddAppointment.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(113, 35);
            this.btnAddAppointment.TabIndex = 1;
            this.btnAddAppointment.Text = "إضافة موعد";
            this.btnAddAppointment.UseVisualStyleBackColor = false;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click_1);
            // 
            // btnDeleteAppointment
            // 
            this.btnDeleteAppointment.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDeleteAppointment.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAppointment.Location = new System.Drawing.Point(127, 22);
            this.btnDeleteAppointment.Margin = new System.Windows.Forms.Padding(5);
            this.btnDeleteAppointment.Name = "btnDeleteAppointment";
            this.btnDeleteAppointment.Size = new System.Drawing.Size(113, 35);
            this.btnDeleteAppointment.TabIndex = 2;
            this.btnDeleteAppointment.Text = "حذف المحدد";
            this.btnDeleteAppointment.UseVisualStyleBackColor = false;
            this.btnDeleteAppointment.Click += new System.EventHandler(this.btnDeleteAppointment_Click_1);
            // 
            // btnGreetings
            // 
            this.btnGreetings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGreetings.ForeColor = System.Drawing.Color.White;
            this.btnGreetings.Location = new System.Drawing.Point(235, 12);
            this.btnGreetings.Margin = new System.Windows.Forms.Padding(5);
            this.btnGreetings.Name = "btnGreetings";
            this.btnGreetings.Size = new System.Drawing.Size(150, 40);
            this.btnGreetings.TabIndex = 107;
            this.btnGreetings.Text = "إرسال تحية";
            this.btnGreetings.UseVisualStyleBackColor = false;
            // 
            // Top_panel
            // 
            this.Top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_panel.Location = new System.Drawing.Point(0, 0);
            this.Top_panel.Margin = new System.Windows.Forms.Padding(4);
            this.Top_panel.Name = "Top_panel";
            this.Top_panel.Size = new System.Drawing.Size(1724, 6);
            this.Top_panel.TabIndex = 106;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.eventTextBox);
            this.groupBox5.Controls.Add(this.searchtext);
            this.groupBox5.Controls.Add(this.dateLabel);
            this.groupBox5.Controls.Add(this.dateDateTimePicker);
            this.groupBox5.Controls.Add(this.eventLabel);
            this.groupBox5.Controls.Add(this.eventDataGridView);
            this.groupBox5.Controls.Add(this.userTextBox);
            this.groupBox5.Controls.Add(this.eventBindingNavigator);
            this.groupBox5.Controls.Add(this.activeTextBox);
            this.groupBox5.Location = new System.Drawing.Point(235, 84);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(535, 430);
            this.groupBox5.TabIndex = 68;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "الأحداث";
            // 
            // eventTextBox
            // 
            this.eventTextBox.Location = new System.Drawing.Point(9, 107);
            this.eventTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.eventTextBox.Multiline = true;
            this.eventTextBox.Name = "eventTextBox";
            this.eventTextBox.ReadOnly = true;
            this.eventTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.eventTextBox.Size = new System.Drawing.Size(428, 170);
            this.eventTextBox.TabIndex = 26;
            // 
            // searchtext
            // 
            this.searchtext.Location = new System.Drawing.Point(107, 25);
            this.searchtext.Margin = new System.Windows.Forms.Padding(5);
            this.searchtext.Name = "searchtext";
            this.searchtext.Size = new System.Drawing.Size(336, 29);
            this.searchtext.TabIndex = 31;
            this.searchtext.TabStop = false;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(449, 75);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(67, 22);
            this.dateLabel.TabIndex = 17;
            this.dateLabel.Text = "التاريخ :";
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateTimePicker.Location = new System.Drawing.Point(102, 69);
            this.dateDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.RightToLeftLayout = true;
            this.dateDateTimePicker.Size = new System.Drawing.Size(336, 29);
            this.dateDateTimePicker.TabIndex = 33;
            this.dateDateTimePicker.TabStop = false;
            // 
            // eventLabel
            // 
            this.eventLabel.AutoSize = true;
            this.eventLabel.Location = new System.Drawing.Point(449, 106);
            this.eventLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.Size = new System.Drawing.Size(68, 22);
            this.eventLabel.TabIndex = 21;
            this.eventLabel.Text = "الحدث :";
            // 
            // eventDataGridView
            // 
            this.eventDataGridView.AllowUserToAddRows = false;
            this.eventDataGridView.AllowUserToDeleteRows = false;
            this.eventDataGridView.AllowUserToOrderColumns = true;
            this.eventDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.eventDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.eventDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.eventDataGridView.Location = new System.Drawing.Point(5, 284);
            this.eventDataGridView.Margin = new System.Windows.Forms.Padding(5);
            this.eventDataGridView.Name = "eventDataGridView";
            this.eventDataGridView.ReadOnly = true;
            this.eventDataGridView.RowHeadersWidth = 34;
            this.eventDataGridView.Size = new System.Drawing.Size(527, 138);
            this.eventDataGridView.TabIndex = 35;
            this.eventDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "ID";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "RealStateID";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "التاريخ";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "المستخدم";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "الحدث";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 150;
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(26, 115);
            this.userTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(77, 29);
            this.userTextBox.TabIndex = 24;
            // 
            // eventBindingNavigator
            // 
            this.eventBindingNavigator.AddNewItem = this.toolStripButton1;
            this.eventBindingNavigator.CountItem = null;
            this.eventBindingNavigator.DeleteItem = this.toolStripButton2;
            this.eventBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.eventBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton2});
            this.eventBindingNavigator.Location = new System.Drawing.Point(5, 27);
            this.eventBindingNavigator.MoveFirstItem = null;
            this.eventBindingNavigator.MoveLastItem = null;
            this.eventBindingNavigator.MoveNextItem = null;
            this.eventBindingNavigator.MovePreviousItem = null;
            this.eventBindingNavigator.Name = "eventBindingNavigator";
            this.eventBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.eventBindingNavigator.PositionItem = null;
            this.eventBindingNavigator.Size = new System.Drawing.Size(525, 25);
            this.eventBindingNavigator.TabIndex = 12;
            this.eventBindingNavigator.Text = "bindingNavigator1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(34, 20);
            this.toolStripButton1.Text = "Add new";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(34, 20);
            this.toolStripButton2.Text = "Delete";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(34, 20);
            this.toolStripButton5.Text = "Add new";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(34, 20);
            this.toolStripButton6.Text = "Delete";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(34, 20);
            this.toolStripButton3.Text = "Delete";
            // 
            // activeTextBox
            // 
            this.activeTextBox.Location = new System.Drawing.Point(114, 115);
            this.activeTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.activeTextBox.Name = "activeTextBox";
            this.activeTextBox.Size = new System.Drawing.Size(148, 29);
            this.activeTextBox.TabIndex = 24;
            // 
            // groupBox2Details
            // 
            this.groupBox2Details.Controls.Add(this.checkedListBox2);
            this.groupBox2Details.Controls.Add(this.lblCompanyReference);
            this.groupBox2Details.Controls.Add(this.txtCompanyReference);
            this.groupBox2Details.Controls.Add(this.textBox3);
            this.groupBox2Details.Controls.Add(this.label3);
            this.groupBox2Details.Controls.Add(this.label11);
            this.groupBox2Details.Controls.Add(this.textBox2);
            this.groupBox2Details.Controls.Add(this.otherLabel);
            this.groupBox2Details.Controls.Add(this.btnCall5);
            this.groupBox2Details.Controls.Add(this.label2);
            this.groupBox2Details.Controls.Add(this.btnCall4);
            this.groupBox2Details.Controls.Add(this.mobileLabel);
            this.groupBox2Details.Controls.Add(this.btnCall1);
            this.groupBox2Details.Controls.Add(this.phone_oneLabel);
            this.groupBox2Details.Controls.Add(this.btnCall2);
            this.groupBox2Details.Controls.Add(this.pictureBox3);
            this.groupBox2Details.Controls.Add(this.Gm2);
            this.groupBox2Details.Controls.Add(this.txtMobile2);
            this.groupBox2Details.Controls.Add(this.pictureBox2);
            this.groupBox2Details.Controls.Add(this.pictureBox1);
            this.groupBox2Details.Controls.Add(this.button6);
            this.groupBox2Details.Controls.Add(this.Gm1);
            this.groupBox2Details.Controls.Add(this.Gp1);
            this.groupBox2Details.Controls.Add(this.txtOwner);
            this.groupBox2Details.Controls.Add(this.ownerLabel);
            this.groupBox2Details.Controls.Add(this.txtOther);
            this.groupBox2Details.Controls.Add(this.txtPhoneOne);
            this.groupBox2Details.Controls.Add(this.txtMobile);
            this.groupBox2Details.Location = new System.Drawing.Point(865, 68);
            this.groupBox2Details.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2Details.Name = "groupBox2Details";
            this.groupBox2Details.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2Details.Size = new System.Drawing.Size(859, 424);
            this.groupBox2Details.TabIndex = 62;
            this.groupBox2Details.TabStop = false;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            ": استئجار",
            ": شراء",
            ": اكساء ",
            ": أخر"});
            this.checkedListBox2.Location = new System.Drawing.Point(84, 47);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkedListBox2.Size = new System.Drawing.Size(184, 82);
            this.checkedListBox2.TabIndex = 159;
            // 
            // lblCompanyReference
            // 
            this.lblCompanyReference.AutoSize = true;
            this.lblCompanyReference.Location = new System.Drawing.Point(795, 288);
            this.lblCompanyReference.Name = "lblCompanyReference";
            this.lblCompanyReference.Size = new System.Drawing.Size(48, 22);
            this.lblCompanyReference.TabIndex = 157;
            this.lblCompanyReference.Text = "رقم :";
            // 
            // txtCompanyReference
            // 
            this.txtCompanyReference.Location = new System.Drawing.Point(549, 280);
            this.txtCompanyReference.Margin = new System.Windows.Forms.Padding(5);
            this.txtCompanyReference.Name = "txtCompanyReference";
            this.txtCompanyReference.Size = new System.Drawing.Size(233, 29);
            this.txtCompanyReference.TabIndex = 158;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(789, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 22);
            this.label3.TabIndex = 155;
            this.label3.Text = "الطلب:";
            // 
            // otherLabel
            // 
            this.otherLabel.AutoSize = true;
            this.otherLabel.Location = new System.Drawing.Point(694, 200);
            this.otherLabel.Name = "otherLabel";
            this.otherLabel.Size = new System.Drawing.Size(40, 22);
            this.otherLabel.TabIndex = 110;
            this.otherLabel.Text = "اخر:";
            // 
            // btnCall5
            // 
            this.btnCall5.BackColor = System.Drawing.Color.White;
            this.btnCall5.ForeColor = System.Drawing.Color.White;
            this.btnCall5.Location = new System.Drawing.Point(453, 194);
            this.btnCall5.Name = "btnCall5";
            this.btnCall5.Size = new System.Drawing.Size(36, 29);
            this.btnCall5.TabIndex = 133;
            this.btnCall5.Tag = "txtOther";
            this.btnCall5.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(694, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 109;
            this.label2.Text = "موبايل 2:";
            // 
            // btnCall4
            // 
            this.btnCall4.BackColor = System.Drawing.Color.White;
            this.btnCall4.ForeColor = System.Drawing.Color.White;
            this.btnCall4.Location = new System.Drawing.Point(453, 157);
            this.btnCall4.Name = "btnCall4";
            this.btnCall4.Size = new System.Drawing.Size(36, 29);
            this.btnCall4.TabIndex = 132;
            this.btnCall4.Tag = "txtMobile2";
            this.btnCall4.UseVisualStyleBackColor = false;
            // 
            // mobileLabel
            // 
            this.mobileLabel.AutoSize = true;
            this.mobileLabel.Location = new System.Drawing.Point(695, 123);
            this.mobileLabel.Name = "mobileLabel";
            this.mobileLabel.Size = new System.Drawing.Size(77, 22);
            this.mobileLabel.TabIndex = 107;
            this.mobileLabel.Text = "موبايل 1:";
            // 
            // btnCall1
            // 
            this.btnCall1.BackColor = System.Drawing.Color.White;
            this.btnCall1.ForeColor = System.Drawing.Color.White;
            this.btnCall1.Location = new System.Drawing.Point(454, 82);
            this.btnCall1.Name = "btnCall1";
            this.btnCall1.Size = new System.Drawing.Size(36, 29);
            this.btnCall1.TabIndex = 130;
            this.btnCall1.Tag = "txtPhoneOne";
            this.btnCall1.UseVisualStyleBackColor = false;
            // 
            // phone_oneLabel
            // 
            this.phone_oneLabel.AutoSize = true;
            this.phone_oneLabel.Location = new System.Drawing.Point(695, 85);
            this.phone_oneLabel.Name = "phone_oneLabel";
            this.phone_oneLabel.Size = new System.Drawing.Size(54, 22);
            this.phone_oneLabel.TabIndex = 106;
            this.phone_oneLabel.Text = "هاتف:";
            // 
            // btnCall2
            // 
            this.btnCall2.BackColor = System.Drawing.Color.White;
            this.btnCall2.ForeColor = System.Drawing.Color.White;
            this.btnCall2.Location = new System.Drawing.Point(454, 117);
            this.btnCall2.Name = "btnCall2";
            this.btnCall2.Size = new System.Drawing.Size(36, 29);
            this.btnCall2.TabIndex = 129;
            this.btnCall2.Tag = "txtMobile";
            this.btnCall2.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(793, 158);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(44, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 128;
            this.pictureBox3.TabStop = false;
            // 
            // Gm2
            // 
            this.Gm2.AutoSize = true;
            this.Gm2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gm2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gm2.Location = new System.Drawing.Point(772, 162);
            this.Gm2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Gm2.Name = "Gm2";
            this.Gm2.Size = new System.Drawing.Size(14, 22);
            this.Gm2.TabIndex = 127;
            this.Gm2.Text = "i";
            // 
            // txtMobile2
            // 
            this.txtMobile2.Location = new System.Drawing.Point(497, 159);
            this.txtMobile2.Margin = new System.Windows.Forms.Padding(5);
            this.txtMobile2.MaxLength = 0;
            this.txtMobile2.Name = "txtMobile2";
            this.txtMobile2.Size = new System.Drawing.Size(189, 29);
            this.txtMobile2.TabIndex = 12;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(793, 195);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 124;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(794, 119);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(792, 79);
            this.button6.Margin = new System.Windows.Forms.Padding(5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(45, 31);
            this.button6.TabIndex = 120;
            this.button6.TabStop = false;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // Gm1
            // 
            this.Gm1.AutoSize = true;
            this.Gm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gm1.Location = new System.Drawing.Point(772, 122);
            this.Gm1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Gm1.Name = "Gm1";
            this.Gm1.Size = new System.Drawing.Size(14, 22);
            this.Gm1.TabIndex = 41;
            this.Gm1.Text = "i";
            // 
            // Gp1
            // 
            this.Gp1.AutoSize = true;
            this.Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gp1.Location = new System.Drawing.Point(772, 84);
            this.Gp1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Gp1.Name = "Gp1";
            this.Gp1.Size = new System.Drawing.Size(14, 22);
            this.Gp1.TabIndex = 40;
            this.Gp1.Text = "i";
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(457, 44);
            this.txtOwner.Margin = new System.Windows.Forms.Padding(5);
            this.txtOwner.MaxLength = 256;
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(230, 29);
            this.txtOwner.TabIndex = 8;
            // 
            // ownerLabel
            // 
            this.ownerLabel.AutoSize = true;
            this.ownerLabel.Location = new System.Drawing.Point(695, 47);
            this.ownerLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(67, 22);
            this.ownerLabel.TabIndex = 19;
            this.ownerLabel.Text = "الاسم :";
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(497, 195);
            this.txtOther.Margin = new System.Windows.Forms.Padding(5);
            this.txtOther.MaxLength = 256;
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(189, 29);
            this.txtOther.TabIndex = 13;
            // 
            // txtPhoneOne
            // 
            this.txtPhoneOne.Location = new System.Drawing.Point(498, 82);
            this.txtPhoneOne.Margin = new System.Windows.Forms.Padding(5);
            this.txtPhoneOne.MaxLength = 0;
            this.txtPhoneOne.Name = "txtPhoneOne";
            this.txtPhoneOne.Size = new System.Drawing.Size(189, 29);
            this.txtPhoneOne.TabIndex = 9;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(498, 120);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(5);
            this.txtMobile.MaxLength = 0;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(189, 29);
            this.txtMobile.TabIndex = 10;
            // 
            // btnBackToCards
            // 
            this.btnBackToCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnBackToCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToCards.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackToCards.ForeColor = System.Drawing.Color.White;
            this.btnBackToCards.Location = new System.Drawing.Point(20, 12);
            this.btnBackToCards.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackToCards.Name = "btnBackToCards";
            this.btnBackToCards.Size = new System.Drawing.Size(150, 40);
            this.btnBackToCards.TabIndex = 0;
            this.btnBackToCards.Text = "← رجوع للقائمة";
            this.btnBackToCards.UseVisualStyleBackColor = false;
            this.btnBackToCards.Click += new System.EventHandler(this.CustomerDetailsPanel_BackButtonClicked);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(67, 21);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(196, 29);
            this.textBox4.TabIndex = 97;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(513, 63);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(196, 29);
            this.textBox5.TabIndex = 98;
            // 
            // colAppointmentDate
            // 
            this.colAppointmentDate.HeaderText = "التاريخ";
            this.colAppointmentDate.MinimumWidth = 6;
            this.colAppointmentDate.Name = "colAppointmentDate";
            this.colAppointmentDate.ReadOnly = true;
            // 
            // colAppointmentTime
            // 
            this.colAppointmentTime.HeaderText = "الوقت";
            this.colAppointmentTime.MinimumWidth = 6;
            this.colAppointmentTime.Name = "colAppointmentTime";
            this.colAppointmentTime.ReadOnly = true;
            // 
            // FollowUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelMainContainer);
            this.Controls.Add(this.panelFilterCard);
            this.Controls.Add(this.panelCustomerDetails);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FollowUp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FollowUp";
            this.Load += new System.EventHandler(this.FollowUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.careerCatogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dScareer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeOfcarrerBindingSource)).EndInit();
            this.panelCardsContainer.ResumeLayout(false);
            this.panelCustomerDetails.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelFilterCard.ResumeLayout(false);
            this.panelMainContainer.ResumeLayout(false);
            this.panelCustomerDetailsContainer.ResumeLayout(false);
            this.groupBoxAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingNavigator)).EndInit();
            this.eventBindingNavigator.ResumeLayout(false);
            this.eventBindingNavigator.PerformLayout();
            this.groupBox2Details.ResumeLayout(false);
            this.groupBox2Details.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource careerCatogBindingSource;
        private DSTables.DScareer dScareer;
        private System.Windows.Forms.BindingSource typeOfcarrerBindingSource;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panelCardsContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCards;
        private System.Windows.Forms.Panel panelCustomerDetails;
        private System.Windows.Forms.GroupBox groupBoxCustomerDetails;
        private System.Windows.Forms.GroupBox groupBoxRequestType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEvents;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.TextBox txtVia;
        private System.Windows.Forms.TextBox txtPhoneDetails;
        private System.Windows.Forms.TextBox txtMobile2;
        private System.Windows.Forms.TextBox txtMobile1;
        private System.Windows.Forms.TextBox txtNameDetails;
        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Label lblVia;
        private System.Windows.Forms.Label lblPhoneDetails;
        private System.Windows.Forms.Label lblMobile2;
        private System.Windows.Forms.Label lblMobile1;
        private System.Windows.Forms.Label lblNameDetails;
        private System.Windows.Forms.ToolTip toolTip;
        private DSTables.DScareerTableAdapters.TypeOfcarrerTableAdapter typeOfcarrerTableAdapter;
        private DSTables.DScareerTableAdapters.careerCatogTableAdapter careerCatogTableAdapter;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Panel panelFilterCard;
        private Label label1;
        private Label label11;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox chkShowArchived;
        private Button button1;
        private Button btnDischarge;







        // Customer Details Panel Components - EXACT COPY of CustomerDetails
        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Panel panelCustomerDetailsContainer;
        private System.Windows.Forms.GroupBox groupBoxAppointments;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.DateTimePicker dtpAppointment;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button btnDeleteAppointment;
        private System.Windows.Forms.Button btnGreetings;
        private System.Windows.Forms.Panel Top_panel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox eventTextBox;
        private System.Windows.Forms.TextBox searchtext;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.DataGridView eventDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.BindingNavigator eventBindingNavigator;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox activeTextBox;
        private System.Windows.Forms.GroupBox groupBox2Details;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Label lblCompanyReference;
        private System.Windows.Forms.TextBox txtCompanyReference;
        private System.Windows.Forms.TextBox textBox33;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Label otherLabel;
        private System.Windows.Forms.Button btnCall5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCall4;
        private System.Windows.Forms.Label mobileLabel;
        private System.Windows.Forms.Button btnCall1;
        private System.Windows.Forms.Label phone_oneLabel;
        private System.Windows.Forms.Button btnCall2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label Gm2;
        private System.Windows.Forms.TextBox txtMobile22;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label Gm1;
        private System.Windows.Forms.Label Gp1;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label ownerLabel;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.TextBox txtPhoneOne;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Button btnBackToCards;
        private TextBox textBox5;
        private TextBox textBox4;
        private DataGridViewTextBoxColumn colAppointmentDate;
        private DataGridViewTextBoxColumn colAppointmentTime;
    }
}