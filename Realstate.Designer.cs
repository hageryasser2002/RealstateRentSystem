using RealStateRentSystem.DSTables;
using System;

namespace RealStateRentSystem
{
    partial class Realstate
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
            System.Windows.Forms.Label subResgionIDLabel;
            System.Windows.Forms.Label buildingLabel;
            System.Windows.Forms.Label floorLabel;
            System.Windows.Forms.Label entranceLabel;
            System.Windows.Forms.Label distanceLabel;
            System.Windows.Forms.Label building_Type_IDLabel;
            System.Windows.Forms.Label ownerLabel;
            System.Windows.Forms.Label dateOfEnterLabel;
            System.Windows.Forms.Label areaLabel;
            System.Windows.Forms.Label priceLabel;
            System.Windows.Forms.Label investitureLabel;
            System.Windows.Forms.Label wayOfRentLabel;
            System.Windows.Forms.Label keyLabel;
            System.Windows.Forms.Label noteLabel;
            System.Windows.Forms.Label info_SourceLabel;
            System.Windows.Forms.Label status_IDLabel;
            System.Windows.Forms.Label startRentDateLabel;
            System.Windows.Forms.Label endRendDateLabel;
            System.Windows.Forms.Label periodLabel;
            System.Windows.Forms.Label remainingDayLabel;
            System.Windows.Forms.Label dateLabel;
            System.Windows.Forms.Label eventLabel;
            System.Windows.Forms.Label userIDLabel;
            System.Windows.Forms.Label roomsLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Realstate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.realStateBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.realStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSrealstate = new RealStateRentSystem.DSTables.DSrealstate();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.realStateBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.txtBuilding = new System.Windows.Forms.TextBox();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.txtFloorComment = new System.Windows.Forms.TextBox();
            this.txtEntrance = new System.Windows.Forms.TextBox();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.buildingTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSregion = new RealStateRentSystem.DSTables.DSregion();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.txtPhoneOne = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.dtpDateOfModification = new System.Windows.Forms.DateTimePicker();
            this.areaTextBox = new System.Windows.Forms.TextBox();
            this.investitureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wayOfRentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.keyCheckBox = new System.Windows.Forms.CheckBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.info_SourceTextBox = new System.Windows.Forms.TextBox();
            this.statusTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.startRentDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.periodTextBox = new System.Windows.Forms.TextBox();
            this.remainingDayTextBox = new System.Windows.Forms.TextBox();
            this.regionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.regionTableAdapter = new RealStateRentSystem.DSTables.DSregionTableAdapters.RegionTableAdapter();
            this.buildingTypeTableAdapter = new RealStateRentSystem.DSTables.DSregionTableAdapters.BuildingTypeTableAdapter();
            this.investitureTableAdapter = new RealStateRentSystem.DSTables.DSregionTableAdapters.InvestitureTableAdapter();
            this.statusTypeTableAdapter = new RealStateRentSystem.DSTables.DSregionTableAdapters.StatusTypeTableAdapter();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.wayOfRentTableAdapter = new RealStateRentSystem.DSTables.DSregionTableAdapters.WayOfRentTableAdapter();
            this.endRendDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBuildingType = new System.Windows.Forms.ComboBox();
            this.txtSubResgion = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.otherLabel = new System.Windows.Forms.Label();
            this.btnCall5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCall4 = new System.Windows.Forms.Button();
            this.phone_TwoLabel = new System.Windows.Forms.Label();
            this.btnCall3 = new System.Windows.Forms.Button();
            this.mobileLabel = new System.Windows.Forms.Label();
            this.btnCall1 = new System.Windows.Forms.Button();
            this.phone_oneLabel = new System.Windows.Forms.Label();
            this.btnCall2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Gm2 = new System.Windows.Forms.Label();
            this.txtMobile2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.Gp2 = new System.Windows.Forms.Label();
            this.Gm1 = new System.Windows.Forms.Label();
            this.Gp1 = new System.Windows.Forms.Label();
            this.txtPhoneTow = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.roomsTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.status_IDListBox = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.attachmentDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.attachmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.attachmentBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.downloadFile_toolStrip = new System.Windows.Forms.ToolStripButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.rDateOchangeEventDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.rDateOchangeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.realStateTableAdapter = new RealStateRentSystem.DSTables.DSrealstateTableAdapters.RealStateTableAdapter();
            this.tableAdapterManager = new RealStateRentSystem.DSTables.DSrealstateTableAdapters.TableAdapterManager();
            this.attachmentTableAdapter = new RealStateRentSystem.DSTables.DSrealstateTableAdapters.AttachmentTableAdapter();
            this.eventTableAdapter = new RealStateRentSystem.DSTables.DSrealstateTableAdapters.EventTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.eventTextBox = new System.Windows.Forms.TextBox();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchtext = new System.Windows.Forms.TextBox();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
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
            this.activeTextBox = new System.Windows.Forms.TextBox();
            this.empty = new System.Windows.Forms.Button();
            this.Restore = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.saved = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.IDLabel = new System.Windows.Forms.Label();
            this.Top_panel = new System.Windows.Forms.Panel();
            this.otherRecords = new System.Windows.Forms.Button();
            this.Published = new System.Windows.Forms.CheckBox();
            this.btnSlideshow = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            region_IDLabel = new System.Windows.Forms.Label();
            subResgionIDLabel = new System.Windows.Forms.Label();
            buildingLabel = new System.Windows.Forms.Label();
            floorLabel = new System.Windows.Forms.Label();
            entranceLabel = new System.Windows.Forms.Label();
            distanceLabel = new System.Windows.Forms.Label();
            building_Type_IDLabel = new System.Windows.Forms.Label();
            ownerLabel = new System.Windows.Forms.Label();
            dateOfEnterLabel = new System.Windows.Forms.Label();
            areaLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            investitureLabel = new System.Windows.Forms.Label();
            wayOfRentLabel = new System.Windows.Forms.Label();
            keyLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            info_SourceLabel = new System.Windows.Forms.Label();
            status_IDLabel = new System.Windows.Forms.Label();
            startRentDateLabel = new System.Windows.Forms.Label();
            endRendDateLabel = new System.Windows.Forms.Label();
            periodLabel = new System.Windows.Forms.Label();
            remainingDayLabel = new System.Windows.Forms.Label();
            dateLabel = new System.Windows.Forms.Label();
            eventLabel = new System.Windows.Forms.Label();
            userIDLabel = new System.Windows.Forms.Label();
            roomsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.realStateBindingNavigator)).BeginInit();
            this.realStateBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.realStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealstate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildingTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSregion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investitureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wayOfRentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentBindingNavigator)).BeginInit();
            this.attachmentBindingNavigator.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingNavigator)).BeginInit();
            this.eventBindingNavigator.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // region_IDLabel
            // 
            region_IDLabel.AutoSize = true;
            region_IDLabel.Location = new System.Drawing.Point(271, 26);
            region_IDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            region_IDLabel.Name = "region_IDLabel";
            region_IDLabel.Size = new System.Drawing.Size(73, 19);
            region_IDLabel.TabIndex = 3;
            region_IDLabel.Text = "المنطقة :";
            // 
            // subResgionIDLabel
            // 
            subResgionIDLabel.AutoSize = true;
            subResgionIDLabel.Location = new System.Drawing.Point(271, 65);
            subResgionIDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            subResgionIDLabel.Name = "subResgionIDLabel";
            subResgionIDLabel.Size = new System.Drawing.Size(129, 19);
            subResgionIDLabel.TabIndex = 5;
            subResgionIDLabel.Text = "الجزيرة \\ الشارع :";
            // 
            // buildingLabel
            // 
            buildingLabel.AutoSize = true;
            buildingLabel.Location = new System.Drawing.Point(271, 106);
            buildingLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            buildingLabel.Name = "buildingLabel";
            buildingLabel.Size = new System.Drawing.Size(52, 19);
            buildingLabel.TabIndex = 7;
            buildingLabel.Text = "البناء :";
            // 
            // floorLabel
            // 
            floorLabel.AutoSize = true;
            floorLabel.Location = new System.Drawing.Point(271, 144);
            floorLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            floorLabel.Name = "floorLabel";
            floorLabel.Size = new System.Drawing.Size(63, 19);
            floorLabel.TabIndex = 9;
            floorLabel.Text = "الطابق :";
            // 
            // entranceLabel
            // 
            entranceLabel.AutoSize = true;
            entranceLabel.Location = new System.Drawing.Point(271, 184);
            entranceLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            entranceLabel.Name = "entranceLabel";
            entranceLabel.Size = new System.Drawing.Size(71, 19);
            entranceLabel.TabIndex = 13;
            entranceLabel.Text = "المدخل :";
            // 
            // distanceLabel
            // 
            distanceLabel.AutoSize = true;
            distanceLabel.Location = new System.Drawing.Point(271, 222);
            distanceLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            distanceLabel.Name = "distanceLabel";
            distanceLabel.Size = new System.Drawing.Size(58, 19);
            distanceLabel.TabIndex = 16;
            distanceLabel.Text = "الجهة :";
            // 
            // building_Type_IDLabel
            // 
            building_Type_IDLabel.AutoSize = true;
            building_Type_IDLabel.Location = new System.Drawing.Point(271, 258);
            building_Type_IDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            building_Type_IDLabel.Name = "building_Type_IDLabel";
            building_Type_IDLabel.Size = new System.Drawing.Size(78, 19);
            building_Type_IDLabel.TabIndex = 18;
            building_Type_IDLabel.Text = "نوع البناء :";
            // 
            // ownerLabel
            // 
            ownerLabel.AutoSize = true;
            ownerLabel.Location = new System.Drawing.Point(255, 27);
            ownerLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            ownerLabel.Name = "ownerLabel";
            ownerLabel.Size = new System.Drawing.Size(104, 19);
            ownerLabel.TabIndex = 19;
            ownerLabel.Text = "صاحب العقار :";
            // 
            // dateOfEnterLabel
            // 
            dateOfEnterLabel.AutoSize = true;
            dateOfEnterLabel.Location = new System.Drawing.Point(719, 26);
            dateOfEnterLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dateOfEnterLabel.Name = "dateOfEnterLabel";
            dateOfEnterLabel.Size = new System.Drawing.Size(103, 19);
            dateOfEnterLabel.TabIndex = 29;
            dateOfEnterLabel.Text = "تاريخ التعديل :";
            // 
            // areaLabel
            // 
            areaLabel.AutoSize = true;
            areaLabel.Location = new System.Drawing.Point(273, 28);
            areaLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            areaLabel.Name = "areaLabel";
            areaLabel.Size = new System.Drawing.Size(81, 19);
            areaLabel.TabIndex = 34;
            areaLabel.Text = "المساحة :";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(273, 102);
            priceLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(61, 19);
            priceLabel.TabIndex = 35;
            priceLabel.Text = "السعر :";
            // 
            // investitureLabel
            // 
            investitureLabel.AutoSize = true;
            investitureLabel.Location = new System.Drawing.Point(273, 139);
            investitureLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            investitureLabel.Name = "investitureLabel";
            investitureLabel.Size = new System.Drawing.Size(117, 19);
            investitureLabel.TabIndex = 37;
            investitureLabel.Text = "الوضع الداخلي :";
            // 
            // wayOfRentLabel
            // 
            wayOfRentLabel.AutoSize = true;
            wayOfRentLabel.Location = new System.Drawing.Point(273, 176);
            wayOfRentLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            wayOfRentLabel.Name = "wayOfRentLabel";
            wayOfRentLabel.Size = new System.Drawing.Size(108, 19);
            wayOfRentLabel.TabIndex = 39;
            wayOfRentLabel.Text = "طريقة التأجير :";
            // 
            // keyLabel
            // 
            keyLabel.AutoSize = true;
            keyLabel.Location = new System.Drawing.Point(273, 215);
            keyLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            keyLabel.Name = "keyLabel";
            keyLabel.Size = new System.Drawing.Size(68, 19);
            keyLabel.TabIndex = 41;
            keyLabel.Text = "المفتاح :";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(273, 289);
            noteLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(79, 19);
            noteLabel.TabIndex = 43;
            noteLabel.Text = "ملاحظات :";
            // 
            // info_SourceLabel
            // 
            info_SourceLabel.AutoSize = true;
            info_SourceLabel.Location = new System.Drawing.Point(273, 253);
            info_SourceLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            info_SourceLabel.Name = "info_SourceLabel";
            info_SourceLabel.Size = new System.Drawing.Size(126, 19);
            info_SourceLabel.TabIndex = 45;
            info_SourceLabel.Text = "مصدر المعلومات :";
            // 
            // status_IDLabel
            // 
            status_IDLabel.AutoSize = true;
            status_IDLabel.Location = new System.Drawing.Point(273, 368);
            status_IDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            status_IDLabel.Name = "status_IDLabel";
            status_IDLabel.Size = new System.Drawing.Size(59, 19);
            status_IDLabel.TabIndex = 47;
            status_IDLabel.Text = "الحالة :";
            // 
            // startRentDateLabel
            // 
            startRentDateLabel.AutoSize = true;
            startRentDateLabel.Location = new System.Drawing.Point(273, 408);
            startRentDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            startRentDateLabel.Name = "startRentDateLabel";
            startRentDateLabel.Size = new System.Drawing.Size(115, 19);
            startRentDateLabel.TabIndex = 49;
            startRentDateLabel.Text = "تاريخ بدء الأجار :";
            // 
            // endRendDateLabel
            // 
            endRendDateLabel.AutoSize = true;
            endRendDateLabel.Location = new System.Drawing.Point(273, 446);
            endRendDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            endRendDateLabel.Name = "endRendDateLabel";
            endRendDateLabel.Size = new System.Drawing.Size(130, 19);
            endRendDateLabel.TabIndex = 51;
            endRendDateLabel.Text = "تاريخ انتهاء الأجار :";
            // 
            // periodLabel
            // 
            periodLabel.AutoSize = true;
            periodLabel.Location = new System.Drawing.Point(275, 484);
            periodLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            periodLabel.Name = "periodLabel";
            periodLabel.Size = new System.Drawing.Size(129, 19);
            periodLabel.TabIndex = 53;
            periodLabel.Text = "المده (بالاشهر ) :";
            // 
            // remainingDayLabel
            // 
            remainingDayLabel.AutoSize = true;
            remainingDayLabel.Location = new System.Drawing.Point(247, 520);
            remainingDayLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            remainingDayLabel.Name = "remainingDayLabel";
            remainingDayLabel.Size = new System.Drawing.Size(204, 19);
            remainingDayLabel.TabIndex = 55;
            remainingDayLabel.Text = "الوقت المتبقي لانتهاء الاجار :";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new System.Drawing.Point(449, 75);
            dateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(61, 19);
            dateLabel.TabIndex = 17;
            dateLabel.Text = "التاريخ :";
            // 
            // eventLabel
            // 
            eventLabel.AutoSize = true;
            eventLabel.Location = new System.Drawing.Point(449, 106);
            eventLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            eventLabel.Name = "eventLabel";
            eventLabel.Size = new System.Drawing.Size(62, 19);
            eventLabel.TabIndex = 21;
            eventLabel.Text = "الحدث :";
            // 
            // userIDLabel
            // 
            userIDLabel.AutoSize = true;
            userIDLabel.Location = new System.Drawing.Point(365, 26);
            userIDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            userIDLabel.Name = "userIDLabel";
            userIDLabel.Size = new System.Drawing.Size(91, 19);
            userIDLabel.TabIndex = 102;
            userIDLabel.Text = "المستخدم :";
            // 
            // roomsLabel
            // 
            roomsLabel.AutoSize = true;
            roomsLabel.Location = new System.Drawing.Point(273, 66);
            roomsLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            roomsLabel.Name = "roomsLabel";
            roomsLabel.Size = new System.Drawing.Size(88, 19);
            roomsLabel.TabIndex = 104;
            roomsLabel.Text = "عدد الغرف :";
            // 
            // realStateBindingNavigator
            // 
            this.realStateBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.realStateBindingNavigator.BindingSource = this.realStateBindingSource;
            this.realStateBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.realStateBindingNavigator.DeleteItem = null;
            this.realStateBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.realStateBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.realStateBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.realStateBindingNavigatorSaveItem});
            this.realStateBindingNavigator.Location = new System.Drawing.Point(0, 13);
            this.realStateBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.realStateBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.realStateBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.realStateBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.realStateBindingNavigator.Name = "realStateBindingNavigator";
            this.realStateBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.realStateBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.realStateBindingNavigator.Size = new System.Drawing.Size(406, 38);
            this.realStateBindingNavigator.TabIndex = 0;
            this.realStateBindingNavigator.Text = "bindingNavigator1";
            this.realStateBindingNavigator.RefreshItems += new System.EventHandler(this.realStateBindingNavigator_RefreshItems);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // realStateBindingSource
            // 
            this.realStateBindingSource.DataMember = "RealState";
            this.realStateBindingSource.DataSource = this.dSrealstate;
            this.realStateBindingSource.PositionChanged += new System.EventHandler(this.realStateBindingSource_PositionChanged);
            // 
            // dSrealstate
            // 
            this.dSrealstate.DataSetName = "DSrealstate";
            this.dSrealstate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 33);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 38);
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
            this.bindingNavigatorPositionItem.Enter += new System.EventHandler(this.bindingNavigatorPositionItem_Enter);
            this.bindingNavigatorPositionItem.Leave += new System.EventHandler(this.bindingNavigatorPositionItem_Leave);
            this.bindingNavigatorPositionItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // realStateBindingNavigatorSaveItem
            // 
            this.realStateBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.realStateBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("realStateBindingNavigatorSaveItem.Image")));
            this.realStateBindingNavigatorSaveItem.Name = "realStateBindingNavigatorSaveItem";
            this.realStateBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 33);
            this.realStateBindingNavigatorSaveItem.Text = "Save Data";
            this.realStateBindingNavigatorSaveItem.Click += new System.EventHandler(this.realStateBindingNavigatorSaveItem_Click);
            // 
            // txtBuilding
            // 
            this.txtBuilding.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Building", true));
            this.txtBuilding.Location = new System.Drawing.Point(17, 96);
            this.txtBuilding.Margin = new System.Windows.Forms.Padding(5);
            this.txtBuilding.MaxLength = 256;
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBuilding.Size = new System.Drawing.Size(230, 27);
            this.txtBuilding.TabIndex = 2;
            this.txtBuilding.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtBuilding.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtBuilding.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // txtFloor
            // 
            this.txtFloor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Floor", true));
            this.txtFloor.Location = new System.Drawing.Point(131, 134);
            this.txtFloor.Margin = new System.Windows.Forms.Padding(5);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(115, 27);
            this.txtFloor.TabIndex = 3;
            this.txtFloor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtFloor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_oneTextBox_KeyPress);
            this.txtFloor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtFloor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // txtFloorComment
            // 
            this.txtFloorComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "FloorComment", true));
            this.txtFloorComment.Location = new System.Drawing.Point(17, 134);
            this.txtFloorComment.Margin = new System.Windows.Forms.Padding(5);
            this.txtFloorComment.MaxLength = 256;
            this.txtFloorComment.Name = "txtFloorComment";
            this.txtFloorComment.Size = new System.Drawing.Size(112, 27);
            this.txtFloorComment.TabIndex = 4;
            this.txtFloorComment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtFloorComment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtFloorComment.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // txtEntrance
            // 
            this.txtEntrance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Entrance", true));
            this.txtEntrance.Location = new System.Drawing.Point(17, 176);
            this.txtEntrance.Margin = new System.Windows.Forms.Padding(5);
            this.txtEntrance.MaxLength = 256;
            this.txtEntrance.Name = "txtEntrance";
            this.txtEntrance.Size = new System.Drawing.Size(230, 27);
            this.txtEntrance.TabIndex = 5;
            this.txtEntrance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtEntrance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtEntrance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // txtDistance
            // 
            this.txtDistance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Distance", true));
            this.txtDistance.Location = new System.Drawing.Point(17, 214);
            this.txtDistance.Margin = new System.Windows.Forms.Padding(5);
            this.txtDistance.MaxLength = 256;
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(230, 27);
            this.txtDistance.TabIndex = 6;
            this.txtDistance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtDistance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtDistance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // buildingTypeBindingSource
            // 
            this.buildingTypeBindingSource.DataMember = "BuildingType";
            this.buildingTypeBindingSource.DataSource = this.dSregion;
            // 
            // dSregion
            // 
            this.dSregion.DataSetName = "DSregion";
            this.dSregion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtOwner
            // 
            this.txtOwner.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Owner", true));
            this.txtOwner.Location = new System.Drawing.Point(17, 24);
            this.txtOwner.Margin = new System.Windows.Forms.Padding(5);
            this.txtOwner.MaxLength = 256;
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(230, 27);
            this.txtOwner.TabIndex = 8;
            this.txtOwner.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtOwner.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtOwner.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // txtPhoneOne
            // 
            this.txtPhoneOne.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Phone_one", true));
            this.txtPhoneOne.Location = new System.Drawing.Point(58, 62);
            this.txtPhoneOne.Margin = new System.Windows.Forms.Padding(5);
            this.txtPhoneOne.MaxLength = 0;
            this.txtPhoneOne.Name = "txtPhoneOne";
            this.txtPhoneOne.Size = new System.Drawing.Size(189, 27);
            this.txtPhoneOne.TabIndex = 9;
            this.txtPhoneOne.BindingContextChanged += new System.EventHandler(this.phone_oneTextBox_TextChanged);
            this.txtPhoneOne.TextChanged += new System.EventHandler(this.phone_oneTextBox_TextChanged);
            this.txtPhoneOne.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_oneTextBox_KeyPress);
            this.txtPhoneOne.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtPhoneOne.Leave += new System.EventHandler(this.phone_oneTextBox_Leave);
            this.txtPhoneOne.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // txtMobile
            // 
            this.txtMobile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Mobile", true));
            this.txtMobile.Location = new System.Drawing.Point(58, 100);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(5);
            this.txtMobile.MaxLength = 0;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(189, 27);
            this.txtMobile.TabIndex = 10;
            this.txtMobile.BindingContextChanged += new System.EventHandler(this.phone_oneTextBox_TextChanged);
            this.txtMobile.TextChanged += new System.EventHandler(this.phone_oneTextBox_TextChanged);
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_oneTextBox_KeyPress);
            this.txtMobile.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtMobile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // txtOther
            // 
            this.txtOther.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Other", true));
            this.txtOther.Location = new System.Drawing.Point(58, 209);
            this.txtOther.Margin = new System.Windows.Forms.Padding(5);
            this.txtOther.MaxLength = 256;
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(189, 27);
            this.txtOther.TabIndex = 13;
            this.txtOther.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtOther.TextChanged += new System.EventHandler(this.txtOther_TextChanged);
            this.txtOther.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtOther.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // dtpDateOfModification
            // 
            this.dtpDateOfModification.CalendarForeColor = System.Drawing.Color.Red;
            this.dtpDateOfModification.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.realStateBindingSource, "DateOfEnter", true));
            this.dtpDateOfModification.Enabled = false;
            this.dtpDateOfModification.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfModification.Location = new System.Drawing.Point(478, 20);
            this.dtpDateOfModification.Margin = new System.Windows.Forms.Padding(5);
            this.dtpDateOfModification.Name = "dtpDateOfModification";
            this.dtpDateOfModification.RightToLeftLayout = true;
            this.dtpDateOfModification.Size = new System.Drawing.Size(230, 27);
            this.dtpDateOfModification.TabIndex = 100;
            this.dtpDateOfModification.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // areaTextBox
            // 
            this.areaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "area", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "##,#"));
            this.areaTextBox.Location = new System.Drawing.Point(13, 23);
            this.areaTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.areaTextBox.MaxLength = 4;
            this.areaTextBox.Name = "areaTextBox";
            this.areaTextBox.Size = new System.Drawing.Size(230, 27);
            this.areaTextBox.TabIndex = 14;
            this.areaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_oneTextBox_KeyPress);
            this.areaTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.areaTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // investitureBindingSource
            // 
            this.investitureBindingSource.DataMember = "Investiture";
            this.investitureBindingSource.DataSource = this.dSregion;
            // 
            // wayOfRentBindingSource
            // 
            this.wayOfRentBindingSource.DataMember = "WayOfRent";
            this.wayOfRentBindingSource.DataSource = this.dSregion;
            // 
            // keyCheckBox
            // 
            this.keyCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.realStateBindingSource, "Key", true));
            this.keyCheckBox.Location = new System.Drawing.Point(13, 209);
            this.keyCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.keyCheckBox.Name = "keyCheckBox";
            this.keyCheckBox.Size = new System.Drawing.Size(233, 36);
            this.keyCheckBox.TabIndex = 19;
            this.keyCheckBox.Text = "في المكتب";
            this.keyCheckBox.UseVisualStyleBackColor = true;
            // 
            // noteTextBox
            // 
            this.noteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Note", true));
            this.noteTextBox.Location = new System.Drawing.Point(13, 285);
            this.noteTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.noteTextBox.Size = new System.Drawing.Size(230, 68);
            this.noteTextBox.TabIndex = 21;
            this.noteTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.noteTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.noteTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // info_SourceTextBox
            // 
            this.info_SourceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Info_Source", true));
            this.info_SourceTextBox.Location = new System.Drawing.Point(13, 247);
            this.info_SourceTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.info_SourceTextBox.MaxLength = 256;
            this.info_SourceTextBox.Name = "info_SourceTextBox";
            this.info_SourceTextBox.Size = new System.Drawing.Size(230, 27);
            this.info_SourceTextBox.TabIndex = 20;
            this.info_SourceTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.info_SourceTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.info_SourceTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // statusTypeBindingSource
            // 
            this.statusTypeBindingSource.DataMember = "StatusType";
            this.statusTypeBindingSource.DataSource = this.dSregion;
            // 
            // startRentDateDateTimePicker
            // 
            this.startRentDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.realStateBindingSource, "StartRentDate", true));
            this.startRentDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startRentDateDateTimePicker.Location = new System.Drawing.Point(13, 400);
            this.startRentDateDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.startRentDateDateTimePicker.Name = "startRentDateDateTimePicker";
            this.startRentDateDateTimePicker.RightToLeftLayout = true;
            this.startRentDateDateTimePicker.Size = new System.Drawing.Size(230, 27);
            this.startRentDateDateTimePicker.TabIndex = 23;
            this.startRentDateDateTimePicker.ValueChanged += new System.EventHandler(this.startRentDateDateTimePicker_ValueChanged);
            this.startRentDateDateTimePicker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.startRentDateDateTimePicker_KeyUp);
            // 
            // periodTextBox
            // 
            this.periodTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Period", true));
            this.periodTextBox.Location = new System.Drawing.Point(13, 476);
            this.periodTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.periodTextBox.Name = "periodTextBox";
            this.periodTextBox.Size = new System.Drawing.Size(230, 27);
            this.periodTextBox.TabIndex = 100;
            this.periodTextBox.TabStop = false;
            this.periodTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.periodTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_oneTextBox_KeyPress);
            this.periodTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.periodTextBox_KeyUp);
            // 
            // remainingDayTextBox
            // 
            this.remainingDayTextBox.BackColor = System.Drawing.Color.White;
            this.remainingDayTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "RemainingDay", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "##,#"));
            this.remainingDayTextBox.Enabled = false;
            this.remainingDayTextBox.ForeColor = System.Drawing.Color.Red;
            this.remainingDayTextBox.Location = new System.Drawing.Point(13, 514);
            this.remainingDayTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.remainingDayTextBox.Name = "remainingDayTextBox";
            this.remainingDayTextBox.Size = new System.Drawing.Size(230, 27);
            this.remainingDayTextBox.TabIndex = 105;
            this.remainingDayTextBox.TabStop = false;
            this.remainingDayTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // regionBindingSource
            // 
            this.regionBindingSource.DataMember = "Region";
            this.regionBindingSource.DataSource = this.dSregion;
            // 
            // regionTableAdapter
            // 
            this.regionTableAdapter.ClearBeforeFill = true;
            // 
            // buildingTypeTableAdapter
            // 
            this.buildingTypeTableAdapter.ClearBeforeFill = true;
            // 
            // investitureTableAdapter
            // 
            this.investitureTableAdapter.ClearBeforeFill = true;
            // 
            // statusTypeTableAdapter
            // 
            this.statusTypeTableAdapter.ClearBeforeFill = true;
            // 
            // cmbRegion
            // 
            this.cmbRegion.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.realStateBindingSource, "Region_ID", true));
            this.cmbRegion.DataSource = this.regionBindingSource;
            this.cmbRegion.DisplayMember = "Name";
            this.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(17, 24);
            this.cmbRegion.Margin = new System.Windows.Forms.Padding(5);
            this.cmbRegion.MaxDropDownItems = 100;
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(230, 27);
            this.cmbRegion.TabIndex = 0;
            this.cmbRegion.ValueMember = "ID";
            this.cmbRegion.SelectionChangeCommitted += new System.EventHandler(this.status_IDListBox_SelectionChangeCommitted);
            this.cmbRegion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // wayOfRentTableAdapter
            // 
            this.wayOfRentTableAdapter.ClearBeforeFill = true;
            // 
            // endRendDateDateTimePicker
            // 
            this.endRendDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.realStateBindingSource, "EndRendDate", true));
            this.endRendDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endRendDateDateTimePicker.Location = new System.Drawing.Point(13, 441);
            this.endRendDateDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.endRendDateDateTimePicker.Name = "endRendDateDateTimePicker";
            this.endRendDateDateTimePicker.RightToLeftLayout = true;
            this.endRendDateDateTimePicker.Size = new System.Drawing.Size(230, 27);
            this.endRendDateDateTimePicker.TabIndex = 24;
            this.endRendDateDateTimePicker.ValueChanged += new System.EventHandler(this.startRentDateDateTimePicker_ValueChanged);
            this.endRendDateDateTimePicker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.startRentDateDateTimePicker_KeyUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBuildingType);
            this.groupBox1.Controls.Add(this.txtSubResgion);
            this.groupBox1.Controls.Add(this.txtBuilding);
            this.groupBox1.Controls.Add(building_Type_IDLabel);
            this.groupBox1.Controls.Add(this.txtDistance);
            this.groupBox1.Controls.Add(this.cmbRegion);
            this.groupBox1.Controls.Add(distanceLabel);
            this.groupBox1.Controls.Add(region_IDLabel);
            this.groupBox1.Controls.Add(this.txtEntrance);
            this.groupBox1.Controls.Add(subResgionIDLabel);
            this.groupBox1.Controls.Add(entranceLabel);
            this.groupBox1.Controls.Add(buildingLabel);
            this.groupBox1.Controls.Add(this.txtFloorComment);
            this.groupBox1.Controls.Add(this.txtFloor);
            this.groupBox1.Controls.Add(floorLabel);
            this.groupBox1.Location = new System.Drawing.Point(15, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(405, 297);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            // 
            // cmbBuildingType
            // 
            this.cmbBuildingType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.realStateBindingSource, "Building_Type_ID", true));
            this.cmbBuildingType.DisplayMember = "ID";
            this.cmbBuildingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuildingType.FormattingEnabled = true;
            this.cmbBuildingType.Location = new System.Drawing.Point(17, 253);
            this.cmbBuildingType.Margin = new System.Windows.Forms.Padding(5);
            this.cmbBuildingType.Name = "cmbBuildingType";
            this.cmbBuildingType.Size = new System.Drawing.Size(232, 27);
            this.cmbBuildingType.TabIndex = 7;
            this.cmbBuildingType.ValueMember = "ID";
            this.cmbBuildingType.SelectionChangeCommitted += new System.EventHandler(this.status_IDListBox_SelectionChangeCommitted);
            this.cmbBuildingType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // txtSubResgion
            // 
            this.txtSubResgion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "SubResgionID", true));
            this.txtSubResgion.Location = new System.Drawing.Point(17, 59);
            this.txtSubResgion.Margin = new System.Windows.Forms.Padding(5);
            this.txtSubResgion.MaxLength = 256;
            this.txtSubResgion.Name = "txtSubResgion";
            this.txtSubResgion.Size = new System.Drawing.Size(230, 27);
            this.txtSubResgion.TabIndex = 1;
            this.txtSubResgion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtSubResgion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.otherLabel);
            this.groupBox2.Controls.Add(this.btnCall5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnCall4);
            this.groupBox2.Controls.Add(this.phone_TwoLabel);
            this.groupBox2.Controls.Add(this.btnCall3);
            this.groupBox2.Controls.Add(this.mobileLabel);
            this.groupBox2.Controls.Add(this.btnCall1);
            this.groupBox2.Controls.Add(this.phone_oneLabel);
            this.groupBox2.Controls.Add(this.btnCall2);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.Gm2);
            this.groupBox2.Controls.Add(this.txtMobile2);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.Gp2);
            this.groupBox2.Controls.Add(this.Gm1);
            this.groupBox2.Controls.Add(this.Gp1);
            this.groupBox2.Controls.Add(this.txtPhoneTow);
            this.groupBox2.Controls.Add(this.txtOwner);
            this.groupBox2.Controls.Add(ownerLabel);
            this.groupBox2.Controls.Add(this.txtOther);
            this.groupBox2.Controls.Add(this.txtPhoneOne);
            this.groupBox2.Controls.Add(this.txtMobile);
            this.groupBox2.Location = new System.Drawing.Point(15, 343);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(405, 279);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            // 
            // otherLabel
            // 
            this.otherLabel.AutoSize = true;
            this.otherLabel.Location = new System.Drawing.Point(255, 214);
            this.otherLabel.Name = "otherLabel";
            this.otherLabel.Size = new System.Drawing.Size(37, 19);
            this.otherLabel.TabIndex = 110;
            this.otherLabel.Text = "اخر:";
            // 
            // btnCall5
            // 
            this.btnCall5.BackColor = System.Drawing.Color.White;
            this.btnCall5.ForeColor = System.Drawing.Color.White;
            this.btnCall5.Image = global::RealStateRentSystem.Properties.Resources.app4;
            this.btnCall5.Location = new System.Drawing.Point(14, 208);
            this.btnCall5.Name = "btnCall5";
            this.btnCall5.Size = new System.Drawing.Size(36, 29);
            this.btnCall5.TabIndex = 133;
            this.btnCall5.Tag = "txtOther";
            this.btnCall5.UseVisualStyleBackColor = false;
            this.btnCall5.Click += new System.EventHandler(this.BtnCall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 109;
            this.label2.Text = "موبايل 2:";
            // 
            // btnCall4
            // 
            this.btnCall4.BackColor = System.Drawing.Color.White;
            this.btnCall4.ForeColor = System.Drawing.Color.White;
            this.btnCall4.Image = global::RealStateRentSystem.Properties.Resources.app3;
            this.btnCall4.Location = new System.Drawing.Point(14, 171);
            this.btnCall4.Name = "btnCall4";
            this.btnCall4.Size = new System.Drawing.Size(36, 29);
            this.btnCall4.TabIndex = 132;
            this.btnCall4.Tag = "txtMobile2";
            this.btnCall4.UseVisualStyleBackColor = false;
            this.btnCall4.Click += new System.EventHandler(this.BtnCall_Click);
            // 
            // phone_TwoLabel
            // 
            this.phone_TwoLabel.AutoSize = true;
            this.phone_TwoLabel.Location = new System.Drawing.Point(255, 142);
            this.phone_TwoLabel.Name = "phone_TwoLabel";
            this.phone_TwoLabel.Size = new System.Drawing.Size(64, 19);
            this.phone_TwoLabel.TabIndex = 108;
            this.phone_TwoLabel.Text = "هاتف 2:";
            // 
            // btnCall3
            // 
            this.btnCall3.BackColor = System.Drawing.Color.White;
            this.btnCall3.ForeColor = System.Drawing.Color.White;
            this.btnCall3.Image = global::RealStateRentSystem.Properties.Resources.app;
            this.btnCall3.Location = new System.Drawing.Point(14, 136);
            this.btnCall3.Name = "btnCall3";
            this.btnCall3.Size = new System.Drawing.Size(36, 29);
            this.btnCall3.TabIndex = 131;
            this.btnCall3.Tag = "txtPhoneTow";
            this.btnCall3.UseVisualStyleBackColor = false;
            this.btnCall3.Click += new System.EventHandler(this.BtnCall_Click);
            // 
            // mobileLabel
            // 
            this.mobileLabel.AutoSize = true;
            this.mobileLabel.Location = new System.Drawing.Point(255, 103);
            this.mobileLabel.Name = "mobileLabel";
            this.mobileLabel.Size = new System.Drawing.Size(69, 19);
            this.mobileLabel.TabIndex = 107;
            this.mobileLabel.Text = "موبايل 1:";
            // 
            // btnCall1
            // 
            this.btnCall1.BackColor = System.Drawing.Color.White;
            this.btnCall1.ForeColor = System.Drawing.Color.White;
            this.btnCall1.Image = global::RealStateRentSystem.Properties.Resources.app2;
            this.btnCall1.Location = new System.Drawing.Point(14, 62);
            this.btnCall1.Name = "btnCall1";
            this.btnCall1.Size = new System.Drawing.Size(36, 29);
            this.btnCall1.TabIndex = 130;
            this.btnCall1.Tag = "txtPhoneOne";
            this.btnCall1.UseVisualStyleBackColor = false;
            this.btnCall1.Click += new System.EventHandler(this.BtnCall_Click);
            // 
            // phone_oneLabel
            // 
            this.phone_oneLabel.AutoSize = true;
            this.phone_oneLabel.Location = new System.Drawing.Point(255, 65);
            this.phone_oneLabel.Name = "phone_oneLabel";
            this.phone_oneLabel.Size = new System.Drawing.Size(64, 19);
            this.phone_oneLabel.TabIndex = 106;
            this.phone_oneLabel.Text = "هاتف 1:";
            // 
            // btnCall2
            // 
            this.btnCall2.BackColor = System.Drawing.Color.White;
            this.btnCall2.ForeColor = System.Drawing.Color.White;
            this.btnCall2.Image = global::RealStateRentSystem.Properties.Resources.app1;
            this.btnCall2.Location = new System.Drawing.Point(14, 97);
            this.btnCall2.Name = "btnCall2";
            this.btnCall2.Size = new System.Drawing.Size(36, 29);
            this.btnCall2.TabIndex = 129;
            this.btnCall2.Tag = "txtMobile";
            this.btnCall2.UseVisualStyleBackColor = false;
            this.btnCall2.Click += new System.EventHandler(this.BtnCall_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::RealStateRentSystem.Properties.Resources.Whats_App;
            this.pictureBox3.Location = new System.Drawing.Point(354, 172);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(44, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 128;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // Gm2
            // 
            this.Gm2.AutoSize = true;
            this.Gm2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gm2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gm2.Location = new System.Drawing.Point(333, 176);
            this.Gm2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Gm2.Name = "Gm2";
            this.Gm2.Size = new System.Drawing.Size(13, 19);
            this.Gm2.TabIndex = 127;
            this.Gm2.Text = "i";
            // 
            // txtMobile2
            // 
            this.txtMobile2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Mobile2", true));
            this.txtMobile2.Location = new System.Drawing.Point(58, 173);
            this.txtMobile2.Margin = new System.Windows.Forms.Padding(5);
            this.txtMobile2.MaxLength = 0;
            this.txtMobile2.Name = "txtMobile2";
            this.txtMobile2.Size = new System.Drawing.Size(189, 27);
            this.txtMobile2.TabIndex = 12;
            this.txtMobile2.BindingContextChanged += new System.EventHandler(this.phone_oneTextBox_TextChanged);
            this.txtMobile2.TextChanged += new System.EventHandler(this.phone_oneTextBox_TextChanged);
            this.txtMobile2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_oneTextBox_KeyPress);
            this.txtMobile2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtMobile2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::RealStateRentSystem.Properties.Resources.Whats_App;
            this.pictureBox2.Location = new System.Drawing.Point(354, 209);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 124;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::RealStateRentSystem.Properties.Resources.Whats_App;
            this.pictureBox1.Location = new System.Drawing.Point(354, 99);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button7
            // 
            this.button7.Image = global::RealStateRentSystem.Properties.Resources.Call_Dial;
            this.button7.Location = new System.Drawing.Point(352, 135);
            this.button7.Margin = new System.Windows.Forms.Padding(5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(45, 31);
            this.button7.TabIndex = 120;
            this.button7.TabStop = false;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Image = global::RealStateRentSystem.Properties.Resources.Call_Dial;
            this.button6.Location = new System.Drawing.Point(352, 59);
            this.button6.Margin = new System.Windows.Forms.Padding(5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(45, 31);
            this.button6.TabIndex = 120;
            this.button6.TabStop = false;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Gp2
            // 
            this.Gp2.AutoSize = true;
            this.Gp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gp2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gp2.Location = new System.Drawing.Point(332, 144);
            this.Gp2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Gp2.Name = "Gp2";
            this.Gp2.Size = new System.Drawing.Size(13, 19);
            this.Gp2.TabIndex = 42;
            this.Gp2.Text = "i";
            // 
            // Gm1
            // 
            this.Gm1.AutoSize = true;
            this.Gm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gm1.Location = new System.Drawing.Point(332, 102);
            this.Gm1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Gm1.Name = "Gm1";
            this.Gm1.Size = new System.Drawing.Size(13, 19);
            this.Gm1.TabIndex = 41;
            this.Gm1.Text = "i";
            // 
            // Gp1
            // 
            this.Gp1.AutoSize = true;
            this.Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gp1.Location = new System.Drawing.Point(332, 64);
            this.Gp1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Gp1.Name = "Gp1";
            this.Gp1.Size = new System.Drawing.Size(13, 19);
            this.Gp1.TabIndex = 40;
            this.Gp1.Text = "i";
            // 
            // txtPhoneTow
            // 
            this.txtPhoneTow.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Phone_Two", true));
            this.txtPhoneTow.Location = new System.Drawing.Point(58, 138);
            this.txtPhoneTow.Margin = new System.Windows.Forms.Padding(5);
            this.txtPhoneTow.MaxLength = 0;
            this.txtPhoneTow.Name = "txtPhoneTow";
            this.txtPhoneTow.Size = new System.Drawing.Size(189, 27);
            this.txtPhoneTow.TabIndex = 11;
            this.txtPhoneTow.BindingContextChanged += new System.EventHandler(this.phone_oneTextBox_TextChanged);
            this.txtPhoneTow.TextChanged += new System.EventHandler(this.phone_oneTextBox_TextChanged);
            this.txtPhoneTow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_oneTextBox_KeyPress);
            this.txtPhoneTow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtPhoneTow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.roomsTextBox);
            this.groupBox3.Controls.Add(roomsLabel);
            this.groupBox3.Controls.Add(this.priceTextBox);
            this.groupBox3.Controls.Add(this.status_IDListBox);
            this.groupBox3.Controls.Add(this.comboBox4);
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.periodTextBox);
            this.groupBox3.Controls.Add(this.remainingDayTextBox);
            this.groupBox3.Controls.Add(this.startRentDateDateTimePicker);
            this.groupBox3.Controls.Add(areaLabel);
            this.groupBox3.Controls.Add(this.endRendDateDateTimePicker);
            this.groupBox3.Controls.Add(priceLabel);
            this.groupBox3.Controls.Add(this.info_SourceTextBox);
            this.groupBox3.Controls.Add(investitureLabel);
            this.groupBox3.Controls.Add(this.noteTextBox);
            this.groupBox3.Controls.Add(wayOfRentLabel);
            this.groupBox3.Controls.Add(this.areaTextBox);
            this.groupBox3.Controls.Add(keyLabel);
            this.groupBox3.Controls.Add(this.keyCheckBox);
            this.groupBox3.Controls.Add(noteLabel);
            this.groupBox3.Controls.Add(info_SourceLabel);
            this.groupBox3.Controls.Add(status_IDLabel);
            this.groupBox3.Controls.Add(startRentDateLabel);
            this.groupBox3.Controls.Add(remainingDayLabel);
            this.groupBox3.Controls.Add(endRendDateLabel);
            this.groupBox3.Controls.Add(periodLabel);
            this.groupBox3.Location = new System.Drawing.Point(432, 42);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(504, 580);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            // 
            // roomsTextBox
            // 
            this.roomsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Rooms", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "##,#"));
            this.roomsTextBox.Location = new System.Drawing.Point(13, 59);
            this.roomsTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.roomsTextBox.Name = "roomsTextBox";
            this.roomsTextBox.Size = new System.Drawing.Size(230, 27);
            this.roomsTextBox.TabIndex = 15;
            this.roomsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.roomsTextBox_KeyPress);
            // 
            // priceTextBox
            // 
            this.priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "Price", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "##,#"));
            this.priceTextBox.Location = new System.Drawing.Point(13, 95);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(230, 27);
            this.priceTextBox.TabIndex = 16;
            this.priceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.phone_oneTextBox_KeyPress);
            this.priceTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // status_IDListBox
            // 
            this.status_IDListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.realStateBindingSource, "Status_ID", true));
            this.status_IDListBox.DataSource = this.statusTypeBindingSource;
            this.status_IDListBox.DisplayMember = "StatusName";
            this.status_IDListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status_IDListBox.FormattingEnabled = true;
            this.status_IDListBox.Location = new System.Drawing.Point(13, 362);
            this.status_IDListBox.Margin = new System.Windows.Forms.Padding(5);
            this.status_IDListBox.Name = "status_IDListBox";
            this.status_IDListBox.Size = new System.Drawing.Size(230, 27);
            this.status_IDListBox.TabIndex = 22;
            this.status_IDListBox.ValueMember = "ID";
            this.status_IDListBox.SelectedIndexChanged += new System.EventHandler(this.status_IDListBox_SelectedIndexChanged);
            this.status_IDListBox.SelectionChangeCommitted += new System.EventHandler(this.status_IDListBox_SelectionChangeCommitted);
            this.status_IDListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.status_IDListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // comboBox4
            // 
            this.comboBox4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.realStateBindingSource, "WayOfRent", true));
            this.comboBox4.DataSource = this.wayOfRentBindingSource;
            this.comboBox4.DisplayMember = "WayOfRent";
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(13, 170);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(230, 27);
            this.comboBox4.TabIndex = 18;
            this.comboBox4.ValueMember = "ID";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            this.comboBox4.SelectionChangeCommitted += new System.EventHandler(this.status_IDListBox_SelectionChangeCommitted);
            this.comboBox4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.realStateBindingSource, "investiture", true));
            this.comboBox3.DataSource = this.investitureBindingSource;
            this.comboBox3.DisplayMember = "Investiture_Name";
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(13, 132);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(230, 27);
            this.comboBox3.TabIndex = 17;
            this.comboBox3.ValueMember = "ID";
            this.comboBox3.SelectionChangeCommitted += new System.EventHandler(this.status_IDListBox_SelectionChangeCommitted);
            this.comboBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.attachmentDataGridView);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.attachmentBindingNavigator);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.rDateOchangeEventDateTimePicker);
            this.groupBox4.Controls.Add(this.rDateOchangeDateTimePicker);
            this.groupBox4.Location = new System.Drawing.Point(15, 730);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox4.Size = new System.Drawing.Size(921, 218);
            this.groupBox4.TabIndex = 67;
            this.groupBox4.TabStop = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Highlight;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(98, 18);
            this.button5.Margin = new System.Windows.Forms.Padding(5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(113, 33);
            this.button5.TabIndex = 30;
            this.button5.TabStop = false;
            this.button5.Text = "فتح بواسطة";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // attachmentDataGridView
            // 
            this.attachmentDataGridView.AllowUserToAddRows = false;
            this.attachmentDataGridView.AllowUserToDeleteRows = false;
            this.attachmentDataGridView.AllowUserToOrderColumns = true;
            this.attachmentDataGridView.AutoGenerateColumns = false;
            this.attachmentDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.attachmentDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.attachmentDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.attachmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attachmentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Visible});
            this.attachmentDataGridView.DataSource = this.attachmentBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.attachmentDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.attachmentDataGridView.Location = new System.Drawing.Point(9, 53);
            this.attachmentDataGridView.Margin = new System.Windows.Forms.Padding(5);
            this.attachmentDataGridView.Name = "attachmentDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.attachmentDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.attachmentDataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.attachmentDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.attachmentDataGridView.Size = new System.Drawing.Size(901, 147);
            this.attachmentDataGridView.TabIndex = 100;
            this.attachmentDataGridView.TabStop = false;
            this.attachmentDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.attachmentDataGridView_CellContentClick);
            this.attachmentDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.attachmentDataGridView_UserDeletingRow);
            this.attachmentDataGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RealState_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "RealState_ID";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FileName";
            this.dataGridViewTextBoxColumn3.HeaderText = "اسم الملف";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Path";
            this.dataGridViewTextBoxColumn4.HeaderText = "الملف";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DateOFAttash";
            this.dataGridViewTextBoxColumn5.HeaderText = "تاريخ التحميل";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 115;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn6.HeaderText = "التعليق";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 320;
            // 
            // Visible
            // 
            this.Visible.DataPropertyName = "Visible";
            this.Visible.HeaderText = "Visible";
            this.Visible.MinimumWidth = 8;
            this.Visible.Name = "Visible";
            this.Visible.Width = 150;
            // 
            // attachmentBindingSource
            // 
            this.attachmentBindingSource.DataMember = "RealState_Attachment";
            this.attachmentBindingSource.DataSource = this.realStateBindingSource;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(449, 20);
            this.textBox4.Margin = new System.Windows.Forms.Padding(5);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(460, 27);
            this.textBox4.TabIndex = 25;
            this.textBox4.TabStop = false;
            this.textBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.textBox4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // attachmentBindingNavigator
            // 
            this.attachmentBindingNavigator.AddNewItem = null;
            this.attachmentBindingNavigator.BindingSource = this.attachmentBindingSource;
            this.attachmentBindingNavigator.CountItem = null;
            this.attachmentBindingNavigator.DeleteItem = this.toolStripButton4;
            this.attachmentBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.attachmentBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.attachmentBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.downloadFile_toolStrip});
            this.attachmentBindingNavigator.Location = new System.Drawing.Point(8, 18);
            this.attachmentBindingNavigator.MoveFirstItem = null;
            this.attachmentBindingNavigator.MoveLastItem = null;
            this.attachmentBindingNavigator.MoveNextItem = null;
            this.attachmentBindingNavigator.MovePreviousItem = null;
            this.attachmentBindingNavigator.Name = "attachmentBindingNavigator";
            this.attachmentBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.attachmentBindingNavigator.PositionItem = null;
            this.attachmentBindingNavigator.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.attachmentBindingNavigator.Size = new System.Drawing.Size(87, 38);
            this.attachmentBindingNavigator.TabIndex = 71;
            this.attachmentBindingNavigator.Text = "bindingNavigator1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(34, 33);
            this.toolStripButton4.Text = "Delete";
            this.toolStripButton4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton4_MouseDown);
            // 
            // downloadFile_toolStrip
            // 
            this.downloadFile_toolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.downloadFile_toolStrip.Image = global::RealStateRentSystem.Properties.Resources.download_24px;
            this.downloadFile_toolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.downloadFile_toolStrip.Name = "downloadFile_toolStrip";
            this.downloadFile_toolStrip.Size = new System.Drawing.Size(34, 33);
            this.downloadFile_toolStrip.Text = "downloadFile";
            this.downloadFile_toolStrip.Click += new System.EventHandler(this.downloadFile_toolStrip_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(323, 18);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 33);
            this.button3.TabIndex = 27;
            this.button3.TabStop = false;
            this.button3.Text = "استعراض";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Highlight;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(210, 18);
            this.button4.Margin = new System.Windows.Forms.Padding(5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 33);
            this.button4.TabIndex = 28;
            this.button4.TabStop = false;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // rDateOchangeEventDateTimePicker
            // 
            this.rDateOchangeEventDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.realStateBindingSource, "RDateOchangeEvent", true));
            this.rDateOchangeEventDateTimePicker.Location = new System.Drawing.Point(379, 170);
            this.rDateOchangeEventDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.rDateOchangeEventDateTimePicker.Name = "rDateOchangeEventDateTimePicker";
            this.rDateOchangeEventDateTimePicker.Size = new System.Drawing.Size(298, 27);
            this.rDateOchangeEventDateTimePicker.TabIndex = 74;
            // 
            // rDateOchangeDateTimePicker
            // 
            this.rDateOchangeDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.realStateBindingSource, "RDateOchange", true));
            this.rDateOchangeDateTimePicker.Location = new System.Drawing.Point(210, 100);
            this.rDateOchangeDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.rDateOchangeDateTimePicker.Name = "rDateOchangeDateTimePicker";
            this.rDateOchangeDateTimePicker.Size = new System.Drawing.Size(298, 27);
            this.rDateOchangeDateTimePicker.TabIndex = 73;
            // 
            // realStateTableAdapter
            // 
            this.realStateTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AttachmentTableAdapter = this.attachmentTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BuildingTypeTableAdapter = null;
            this.tableAdapterManager.EventTableAdapter = this.eventTableAdapter;
            this.tableAdapterManager.InvestitureTableAdapter = null;
            this.tableAdapterManager.RealStateTableAdapter = this.realStateTableAdapter;
            this.tableAdapterManager.RegionTableAdapter = null;
            this.tableAdapterManager.StatusTypeTableAdapter = null;
            this.tableAdapterManager.SubRegionsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = RealStateRentSystem.DSTables.DSrealstateTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            this.tableAdapterManager.WayOfRentTableAdapter = null;
            // 
            // attachmentTableAdapter
            // 
            this.attachmentTableAdapter.ClearBeforeFill = true;
            // 
            // eventTableAdapter
            // 
            this.eventTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(8, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 32;
            this.button1.TabStop = false;
            this.button1.Text = "بحث";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.eventTextBox);
            this.groupBox5.Controls.Add(this.searchtext);
            this.groupBox5.Controls.Add(dateLabel);
            this.groupBox5.Controls.Add(this.dateDateTimePicker);
            this.groupBox5.Controls.Add(eventLabel);
            this.groupBox5.Controls.Add(this.eventDataGridView);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.userTextBox);
            this.groupBox5.Controls.Add(this.eventBindingNavigator);
            this.groupBox5.Controls.Add(this.activeTextBox);
            this.groupBox5.Location = new System.Drawing.Point(944, 48);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(535, 944);
            this.groupBox5.TabIndex = 68;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "الأحداث";
            // 
            // eventTextBox
            // 
            this.eventTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "Event", true));
            this.eventTextBox.Location = new System.Drawing.Point(9, 107);
            this.eventTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.eventTextBox.Multiline = true;
            this.eventTextBox.Name = "eventTextBox";
            this.eventTextBox.ReadOnly = true;
            this.eventTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.eventTextBox.Size = new System.Drawing.Size(428, 170);
            this.eventTextBox.TabIndex = 26;
            this.eventTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.eventTextBox.TextChanged += new System.EventHandler(this.eventTextBox_TextChanged);
            this.eventTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.eventTextBox.Leave += new System.EventHandler(this.eventTextBox_Leave);
            this.eventTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataMember = "RealState_Event";
            this.eventBindingSource.DataSource = this.realStateBindingSource;
            // 
            // searchtext
            // 
            this.searchtext.Location = new System.Drawing.Point(107, 25);
            this.searchtext.Margin = new System.Windows.Forms.Padding(5);
            this.searchtext.Name = "searchtext";
            this.searchtext.Size = new System.Drawing.Size(336, 27);
            this.searchtext.TabIndex = 31;
            this.searchtext.TabStop = false;
            this.searchtext.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.searchtext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.eventBindingSource, "Date", true));
            this.dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateTimePicker.Location = new System.Drawing.Point(102, 69);
            this.dateDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.RightToLeftLayout = true;
            this.dateDateTimePicker.Size = new System.Drawing.Size(336, 27);
            this.dateDateTimePicker.TabIndex = 33;
            this.dateDateTimePicker.TabStop = false;
            // 
            // eventDataGridView
            // 
            this.eventDataGridView.AllowUserToAddRows = false;
            this.eventDataGridView.AllowUserToDeleteRows = false;
            this.eventDataGridView.AllowUserToOrderColumns = true;
            this.eventDataGridView.AutoGenerateColumns = false;
            this.eventDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.eventDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.eventDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.eventDataGridView.DataSource = this.eventBindingSource;
            this.eventDataGridView.Location = new System.Drawing.Point(5, 284);
            this.eventDataGridView.Margin = new System.Windows.Forms.Padding(5);
            this.eventDataGridView.Name = "eventDataGridView";
            this.eventDataGridView.ReadOnly = true;
            this.eventDataGridView.RowHeadersWidth = 34;
            this.eventDataGridView.Size = new System.Drawing.Size(527, 616);
            this.eventDataGridView.TabIndex = 35;
            this.eventDataGridView.TabStop = false;
            this.eventDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eventDataGridView_CellContentClick);
            this.eventDataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.eventDataGridView_MouseUp);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn7.HeaderText = "ID";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "RealStateID";
            this.dataGridViewTextBoxColumn8.HeaderText = "RealStateID";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn9.HeaderText = "التاريخ";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "User";
            this.dataGridViewTextBoxColumn10.HeaderText = "المستخدم";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Event";
            this.dataGridViewTextBoxColumn11.HeaderText = "الحدث";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 150;
            // 
            // userTextBox
            // 
            this.userTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "User", true));
            this.userTextBox.Location = new System.Drawing.Point(26, 115);
            this.userTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(77, 27);
            this.userTextBox.TabIndex = 24;
            // 
            // eventBindingNavigator
            // 
            this.eventBindingNavigator.AddNewItem = this.toolStripButton1;
            this.eventBindingNavigator.BindingSource = this.eventBindingSource;
            this.eventBindingNavigator.CountItem = null;
            this.eventBindingNavigator.DeleteItem = this.toolStripButton2;
            this.eventBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.eventBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.eventBindingNavigator.Location = new System.Drawing.Point(5, 25);
            this.eventBindingNavigator.MoveFirstItem = null;
            this.eventBindingNavigator.MoveLastItem = null;
            this.eventBindingNavigator.MoveNextItem = null;
            this.eventBindingNavigator.MovePreviousItem = null;
            this.eventBindingNavigator.Name = "eventBindingNavigator";
            this.eventBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.eventBindingNavigator.PositionItem = null;
            this.eventBindingNavigator.Size = new System.Drawing.Size(525, 38);
            this.eventBindingNavigator.TabIndex = 12;
            this.eventBindingNavigator.Text = "bindingNavigator1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(34, 33);
            this.toolStripButton1.Text = "Add new";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(34, 33);
            this.toolStripButton2.Text = "Delete";
            this.toolStripButton2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripButton2_MouseDown);
            // 
            // activeTextBox
            // 
            this.activeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "active", true));
            this.activeTextBox.Location = new System.Drawing.Point(114, 115);
            this.activeTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.activeTextBox.Name = "activeTextBox";
            this.activeTextBox.Size = new System.Drawing.Size(148, 27);
            this.activeTextBox.TabIndex = 24;
            // 
            // empty
            // 
            this.empty.BackColor = System.Drawing.SystemColors.Highlight;
            this.empty.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.empty.Location = new System.Drawing.Point(525, 12);
            this.empty.Margin = new System.Windows.Forms.Padding(5);
            this.empty.Name = "empty";
            this.empty.Size = new System.Drawing.Size(113, 30);
            this.empty.TabIndex = 73;
            this.empty.Text = "اخلاء";
            this.empty.UseVisualStyleBackColor = false;
            this.empty.Click += new System.EventHandler(this.empty_Click);
            // 
            // Restore
            // 
            this.Restore.BackColor = System.Drawing.SystemColors.Highlight;
            this.Restore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Restore.Location = new System.Drawing.Point(1140, 12);
            this.Restore.Margin = new System.Windows.Forms.Padding(5);
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(113, 30);
            this.Restore.TabIndex = 37;
            this.Restore.TabStop = false;
            this.Restore.Text = "استعاده";
            this.Restore.UseVisualStyleBackColor = false;
            this.Restore.Visible = false;
            this.Restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtUserName);
            this.groupBox6.Controls.Add(userIDLabel);
            this.groupBox6.Controls.Add(this.dtpDateOfModification);
            this.groupBox6.Controls.Add(dateOfEnterLabel);
            this.groupBox6.Location = new System.Drawing.Point(15, 624);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox6.Size = new System.Drawing.Size(921, 58);
            this.groupBox6.TabIndex = 102;
            this.groupBox6.TabStop = false;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "UserID", true));
            this.txtUserName.Enabled = false;
            this.txtUserName.ForeColor = System.Drawing.Color.Red;
            this.txtUserName.Location = new System.Drawing.Point(103, 20);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(229, 27);
            this.txtUserName.TabIndex = 103;
            // 
            // saved
            // 
            this.saved.BackColor = System.Drawing.SystemColors.Control;
            this.saved.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.saved.ForeColor = System.Drawing.Color.Red;
            this.saved.Location = new System.Drawing.Point(888, 19);
            this.saved.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.saved.Name = "saved";
            this.saved.Size = new System.Drawing.Size(67, 19);
            this.saved.TabIndex = 103;
            this.saved.Text = "Saved";
            this.saved.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(1259, 12);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 30);
            this.button2.TabIndex = 36;
            this.button2.TabStop = false;
            this.button2.Text = "نسخ للبيع";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // IDLabel
            // 
            this.IDLabel.BackColor = System.Drawing.Color.White;
            this.IDLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.realStateBindingSource, "ID", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "##,#"));
            this.IDLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.IDLabel.Location = new System.Drawing.Point(1389, 17);
            this.IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(91, 20);
            this.IDLabel.TabIndex = 105;
            this.IDLabel.Text = "IDNumber";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Top_panel
            // 
            this.Top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Top_panel.Location = new System.Drawing.Point(0, 0);
            this.Top_panel.Margin = new System.Windows.Forms.Padding(4);
            this.Top_panel.Name = "Top_panel";
            this.Top_panel.Size = new System.Drawing.Size(1504, 6);
            this.Top_panel.TabIndex = 106;
            // 
            // otherRecords
            // 
            this.otherRecords.BackColor = System.Drawing.Color.DarkOrange;
            this.otherRecords.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.otherRecords.Location = new System.Drawing.Point(973, 11);
            this.otherRecords.Margin = new System.Windows.Forms.Padding(5);
            this.otherRecords.Name = "otherRecords";
            this.otherRecords.Size = new System.Drawing.Size(157, 30);
            this.otherRecords.TabIndex = 107;
            this.otherRecords.TabStop = false;
            this.otherRecords.Text = "سجلات أخري";
            this.otherRecords.UseVisualStyleBackColor = false;
            this.otherRecords.Click += new System.EventHandler(this.otherRecords_Click);
            // 
            // Published
            // 
            this.Published.AutoSize = true;
            this.Published.Location = new System.Drawing.Point(413, 19);
            this.Published.Name = "Published";
            this.Published.Size = new System.Drawing.Size(86, 23);
            this.Published.TabIndex = 108;
            this.Published.Text = "Publish";
            this.Published.UseVisualStyleBackColor = true;
            this.Published.CheckedChanged += new System.EventHandler(this.Published_CheckedChanged);
            // 
            // btnSlideshow
            // 
            this.btnSlideshow.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSlideshow.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSlideshow.Location = new System.Drawing.Point(15, 691);
            this.btnSlideshow.Name = "btnSlideshow";
            this.btnSlideshow.Size = new System.Drawing.Size(173, 41);
            this.btnSlideshow.TabIndex = 109;
            this.btnSlideshow.Text = "عرض المرفقات";
            this.btnSlideshow.UseVisualStyleBackColor = false;
            this.btnSlideshow.Click += new System.EventHandler(this.Attachments_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.Highlight;
            this.button8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button8.Location = new System.Drawing.Point(211, 690);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(173, 41);
            this.button8.TabIndex = 110;
            this.button8.Text = "Website";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // Realstate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1504, 944);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.Published);
            this.Controls.Add(this.otherRecords);
            this.Controls.Add(this.btnSlideshow);
            this.Controls.Add(this.Top_panel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.saved);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.Restore);
            this.Controls.Add(this.empty);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.realStateBindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1459, 1000);
            this.Name = "Realstate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ادخال";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Realstate_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Realstate_FormClosed);
            this.Load += new System.EventHandler(this.Realstate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.realStateBindingNavigator)).EndInit();
            this.realStateBindingNavigator.ResumeLayout(false);
            this.realStateBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.realStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealstate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildingTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSregion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investitureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wayOfRentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attachmentBindingNavigator)).EndInit();
            this.attachmentBindingNavigator.ResumeLayout(false);
            this.attachmentBindingNavigator.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingNavigator)).EndInit();
            this.eventBindingNavigator.ResumeLayout(false);
            this.eventBindingNavigator.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     

        #endregion

        public DSrealstate dSrealstate;
        private System.Windows.Forms.BindingSource realStateBindingSource;
        public DSTables.DSrealstateTableAdapters.RealStateTableAdapter realStateTableAdapter;
        private DSTables.DSrealstateTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton realStateBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.TextBox txtFloorComment;
        private System.Windows.Forms.TextBox txtEntrance;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.DateTimePicker dtpDateOfModification;
        private System.Windows.Forms.TextBox areaTextBox;
        private System.Windows.Forms.CheckBox keyCheckBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.TextBox info_SourceTextBox;
        private System.Windows.Forms.DateTimePicker startRentDateDateTimePicker;
        private System.Windows.Forms.TextBox periodTextBox;
        private System.Windows.Forms.TextBox remainingDayTextBox;
        private DSregion dSregion;
        private System.Windows.Forms.BindingSource regionBindingSource;
        private DSTables.DSregionTableAdapters.RegionTableAdapter regionTableAdapter;
        private System.Windows.Forms.BindingSource buildingTypeBindingSource;
        private DSTables.DSregionTableAdapters.BuildingTypeTableAdapter buildingTypeTableAdapter;
        private System.Windows.Forms.BindingSource investitureBindingSource;
        private DSTables.DSregionTableAdapters.InvestitureTableAdapter investitureTableAdapter;
        private System.Windows.Forms.BindingSource statusTypeBindingSource;
        private DSTables.DSregionTableAdapters.StatusTypeTableAdapter statusTypeTableAdapter;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.BindingSource wayOfRentBindingSource;
        private DSTables.DSregionTableAdapters.WayOfRentTableAdapter wayOfRentTableAdapter;
        private System.Windows.Forms.DateTimePicker endRendDateDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DSTables.DSrealstateTableAdapters.AttachmentTableAdapter attachmentTableAdapter;
        private System.Windows.Forms.BindingSource attachmentBindingSource;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView attachmentDataGridView;
        private System.Windows.Forms.TextBox txtSubResgion;
        private System.Windows.Forms.ComboBox cmbBuildingType;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox status_IDListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox5;
        private DSTables.DSrealstateTableAdapters.EventTableAdapter eventTableAdapter;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private System.Windows.Forms.DataGridView eventDataGridView;
        private System.Windows.Forms.TextBox eventTextBox;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.TextBox searchtext;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Button empty;
        private System.Windows.Forms.Button Restore;
        private System.Windows.Forms.TextBox activeTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.BindingNavigator eventBindingNavigator;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.BindingNavigator attachmentBindingNavigator;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TextBox txtPhoneTow;
        private System.Windows.Forms.Label saved;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DateTimePicker rDateOchangeEventDateTimePicker;
        private System.Windows.Forms.DateTimePicker rDateOchangeDateTimePicker;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Label Gp2;
        private System.Windows.Forms.Label Gm1;
        private System.Windows.Forms.Label Gp1;
        public System.Windows.Forms.BindingNavigator realStateBindingNavigator;
        public System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        public System.Windows.Forms.TextBox txtPhoneOne;
        public System.Windows.Forms.TextBox txtMobile;
        public System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox roomsTextBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Panel Top_panel;
        private System.Windows.Forms.ToolStripButton downloadFile_toolStrip;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label Gm2;
        public System.Windows.Forms.TextBox txtMobile2;
        private System.Windows.Forms.Button btnCall2;
        private System.Windows.Forms.Button btnCall5;
        private System.Windows.Forms.Button btnCall4;
        private System.Windows.Forms.Button btnCall3;
        private System.Windows.Forms.Button btnCall1;
        private System.Windows.Forms.Button otherRecords;
        private System.Windows.Forms.Label phone_oneLabel;
        private System.Windows.Forms.Label otherLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label phone_TwoLabel;
        private System.Windows.Forms.Label mobileLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Visible;
        private System.Windows.Forms.CheckBox Published;
        private System.Windows.Forms.Button btnSlideshow;
        private System.Windows.Forms.Button button8;
    }
}