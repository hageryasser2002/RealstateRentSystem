using RealStateRentSystem.DSTables;
using System.Drawing;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    partial class FrmAlways
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
            this.txtSubregion = new System.Windows.Forms.TextBox();
            this.cmbRentalMethod = new System.Windows.Forms.ComboBox();
            this.building_Type_IDLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.regionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSregion = new RealStateRentSystem.DSTables.DSregion();
            this.label1 = new System.Windows.Forms.Label();
            this.region_IDLabel = new System.Windows.Forms.Label();
            this.subResgionIDLabel = new System.Windows.Forms.Label();
            this.buildingLabel = new System.Windows.Forms.Label();
            this.areaLabel = new System.Windows.Forms.Label();
            this.wayOfRentLabel = new System.Windows.Forms.Label();
            this.floorLabel = new System.Windows.Forms.Label();
            this.status_IDLabel = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtAreaTo = new System.Windows.Forms.TextBox();
            this.txtAreaFrom = new System.Windows.Forms.TextBox();
            this.txtFloorComment = new System.Windows.Forms.TextBox();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPriceTo = new System.Windows.Forms.TextBox();
            this.txtPriceFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.txtNumberOfRooms = new System.Windows.Forms.TextBox();
            this.roomsLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInEvent = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.txtHomeOwner = new System.Windows.Forms.TextBox();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.btnDischarge = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRentalExpiryDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkInArchive = new System.Windows.Forms.CheckBox();
            this.cmbBuildingType = new System.Windows.Forms.ComboBox();
            this.p1 = new System.Windows.Forms.TextBox();
            this.txtBuilding = new System.Windows.Forms.TextBox();
            this.phone_oneLabel = new System.Windows.Forms.Label();
            this.regionTableAdapter = new RealStateRentSystem.DSTables.DSregionTableAdapters.RegionTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Gp1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PanelUserColo = new System.Windows.Forms.Panel();
            this.user = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSregion)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.PanelUserColo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSubregion
            // 
            this.txtSubregion.Location = new System.Drawing.Point(846, 116);
            this.txtSubregion.Margin = new System.Windows.Forms.Padding(5);
            this.txtSubregion.Name = "txtSubregion";
            this.txtSubregion.Size = new System.Drawing.Size(230, 27);
            this.txtSubregion.TabIndex = 1;
            this.txtSubregion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtSubregion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtSubregion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtSubregion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // cmbRentalMethod
            // 
            this.cmbRentalMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRentalMethod.FormattingEnabled = true;
            this.cmbRentalMethod.Items.AddRange(new object[] {
            "مفروش",
            "غير مفروش",
            "كلتا الحالتين"});
            this.cmbRentalMethod.Location = new System.Drawing.Point(449, 152);
            this.cmbRentalMethod.Margin = new System.Windows.Forms.Padding(5);
            this.cmbRentalMethod.Name = "cmbRentalMethod";
            this.cmbRentalMethod.Size = new System.Drawing.Size(246, 27);
            this.cmbRentalMethod.TabIndex = 10;
            this.cmbRentalMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.cmbRentalMethod.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // building_Type_IDLabel
            // 
            this.building_Type_IDLabel.AutoSize = true;
            this.building_Type_IDLabel.BackColor = System.Drawing.Color.Transparent;
            this.building_Type_IDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.building_Type_IDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.building_Type_IDLabel.Location = new System.Drawing.Point(1085, 238);
            this.building_Type_IDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.building_Type_IDLabel.Name = "building_Type_IDLabel";
            this.building_Type_IDLabel.Size = new System.Drawing.Size(83, 19);
            this.building_Type_IDLabel.TabIndex = 17;
            this.building_Type_IDLabel.Text = "نوع البناء :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(537, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 19);
            this.label2.TabIndex = 51;
            this.label2.Text = "الى";
            // 
            // cmbRegion
            // 
            this.cmbRegion.DataSource = this.regionBindingSource;
            this.cmbRegion.DisplayMember = "Name";
            this.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(846, 75);
            this.cmbRegion.Margin = new System.Windows.Forms.Padding(5);
            this.cmbRegion.MaxDropDownItems = 100;
            this.cmbRegion.MaxLength = 100;
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(230, 27);
            this.cmbRegion.TabIndex = 0;
            this.cmbRegion.ValueMember = "ID";
            this.cmbRegion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.cmbRegion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // regionBindingSource
            // 
            this.regionBindingSource.DataMember = "Region";
            this.regionBindingSource.DataSource = this.dSregion;
            // 
            // dSregion
            // 
            this.dSregion.DataSetName = "DSregion";
            this.dSregion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(665, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 19);
            this.label1.TabIndex = 50;
            this.label1.Text = "من";
            // 
            // region_IDLabel
            // 
            this.region_IDLabel.AutoSize = true;
            this.region_IDLabel.BackColor = System.Drawing.Color.Transparent;
            this.region_IDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.region_IDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.region_IDLabel.Location = new System.Drawing.Point(1085, 77);
            this.region_IDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.region_IDLabel.Name = "region_IDLabel";
            this.region_IDLabel.Size = new System.Drawing.Size(80, 19);
            this.region_IDLabel.TabIndex = 3;
            this.region_IDLabel.Text = "المنطقة :";
            // 
            // subResgionIDLabel
            // 
            this.subResgionIDLabel.AutoSize = true;
            this.subResgionIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.subResgionIDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.subResgionIDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.subResgionIDLabel.Location = new System.Drawing.Point(1085, 116);
            this.subResgionIDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.subResgionIDLabel.Name = "subResgionIDLabel";
            this.subResgionIDLabel.Size = new System.Drawing.Size(140, 19);
            this.subResgionIDLabel.TabIndex = 5;
            this.subResgionIDLabel.Text = "الجزيرة \\ الشارع :";
            // 
            // buildingLabel
            // 
            this.buildingLabel.AutoSize = true;
            this.buildingLabel.BackColor = System.Drawing.Color.Transparent;
            this.buildingLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buildingLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buildingLabel.Location = new System.Drawing.Point(1085, 156);
            this.buildingLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buildingLabel.Name = "buildingLabel";
            this.buildingLabel.Size = new System.Drawing.Size(53, 19);
            this.buildingLabel.TabIndex = 7;
            this.buildingLabel.Text = "البناء :";
            // 
            // areaLabel
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.BackColor = System.Drawing.Color.Transparent;
            this.areaLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.areaLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.areaLabel.Location = new System.Drawing.Point(707, 37);
            this.areaLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.areaLabel.Name = "areaLabel";
            this.areaLabel.Size = new System.Drawing.Size(86, 19);
            this.areaLabel.TabIndex = 33;
            this.areaLabel.Text = "المساحة :";
            // 
            // wayOfRentLabel
            // 
            this.wayOfRentLabel.AutoSize = true;
            this.wayOfRentLabel.BackColor = System.Drawing.Color.Transparent;
            this.wayOfRentLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.wayOfRentLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.wayOfRentLabel.Location = new System.Drawing.Point(710, 156);
            this.wayOfRentLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.wayOfRentLabel.Name = "wayOfRentLabel";
            this.wayOfRentLabel.Size = new System.Drawing.Size(117, 19);
            this.wayOfRentLabel.TabIndex = 39;
            this.wayOfRentLabel.Text = "طريقة التأجير :";
            // 
            // floorLabel
            // 
            this.floorLabel.AutoSize = true;
            this.floorLabel.BackColor = System.Drawing.Color.Transparent;
            this.floorLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.floorLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.floorLabel.Location = new System.Drawing.Point(1085, 194);
            this.floorLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.floorLabel.Name = "floorLabel";
            this.floorLabel.Size = new System.Drawing.Size(70, 19);
            this.floorLabel.TabIndex = 9;
            this.floorLabel.Text = "الطابق :";
            // 
            // status_IDLabel
            // 
            this.status_IDLabel.AutoSize = true;
            this.status_IDLabel.BackColor = System.Drawing.Color.Transparent;
            this.status_IDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.status_IDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.status_IDLabel.Location = new System.Drawing.Point(711, 197);
            this.status_IDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.status_IDLabel.Name = "status_IDLabel";
            this.status_IDLabel.Size = new System.Drawing.Size(62, 19);
            this.status_IDLabel.TabIndex = 47;
            this.status_IDLabel.Text = "الحالة :";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "مؤجر",
            "غير مؤجر",
            "كلتا الحالتين"});
            this.cmbStatus.Location = new System.Drawing.Point(449, 194);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(5);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(246, 27);
            this.cmbStatus.TabIndex = 11;
            this.cmbStatus.SelectionChangeCommitted += new System.EventHandler(this.statuscombo_SelectionChangeCommitted);
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.cmbStatus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // txtAreaTo
            // 
            this.txtAreaTo.Location = new System.Drawing.Point(449, 30);
            this.txtAreaTo.Margin = new System.Windows.Forms.Padding(5);
            this.txtAreaTo.Name = "txtAreaTo";
            this.txtAreaTo.Size = new System.Drawing.Size(86, 27);
            this.txtAreaTo.TabIndex = 7;
            this.txtAreaTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtAreaTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1_KeyPress);
            // 
            // txtAreaFrom
            // 
            this.txtAreaFrom.Location = new System.Drawing.Point(576, 31);
            this.txtAreaFrom.Margin = new System.Windows.Forms.Padding(5);
            this.txtAreaFrom.Name = "txtAreaFrom";
            this.txtAreaFrom.Size = new System.Drawing.Size(86, 27);
            this.txtAreaFrom.TabIndex = 6;
            this.txtAreaFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtAreaFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1_KeyPress);
            // 
            // txtFloorComment
            // 
            this.txtFloorComment.Location = new System.Drawing.Point(846, 194);
            this.txtFloorComment.Margin = new System.Windows.Forms.Padding(5);
            this.txtFloorComment.Name = "txtFloorComment";
            this.txtFloorComment.Size = new System.Drawing.Size(117, 27);
            this.txtFloorComment.TabIndex = 4;
            this.txtFloorComment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtFloorComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtFloorComment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtFloorComment.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(964, 194);
            this.txtFloor.Margin = new System.Windows.Forms.Padding(5);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(113, 27);
            this.txtFloor.TabIndex = 3;
            this.txtFloor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtFloor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtFloor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1_KeyPress);
            this.txtFloor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtFloor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPriceTo);
            this.groupBox1.Controls.Add(this.txtPriceFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.priceLabel);
            this.groupBox1.Controls.Add(this.txtNumberOfRooms);
            this.groupBox1.Controls.Add(this.roomsLabel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtInEvent);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.txtHomeOwner);
            this.groupBox1.Controls.Add(this.ownerLabel);
            this.groupBox1.Controls.Add(this.btnDischarge);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtRentalExpiryDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chkInArchive);
            this.groupBox1.Controls.Add(this.txtSubregion);
            this.groupBox1.Controls.Add(this.cmbRentalMethod);
            this.groupBox1.Controls.Add(this.cmbBuildingType);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.txtAreaTo);
            this.groupBox1.Controls.Add(this.txtAreaFrom);
            this.groupBox1.Controls.Add(this.txtFloorComment);
            this.groupBox1.Controls.Add(this.txtFloor);
            this.groupBox1.Controls.Add(this.p1);
            this.groupBox1.Controls.Add(this.txtBuilding);
            this.groupBox1.Controls.Add(this.phone_oneLabel);
            this.groupBox1.Controls.Add(this.building_Type_IDLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbRegion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.region_IDLabel);
            this.groupBox1.Controls.Add(this.subResgionIDLabel);
            this.groupBox1.Controls.Add(this.buildingLabel);
            this.groupBox1.Controls.Add(this.areaLabel);
            this.groupBox1.Controls.Add(this.wayOfRentLabel);
            this.groupBox1.Controls.Add(this.floorLabel);
            this.groupBox1.Controls.Add(this.status_IDLabel);
            this.groupBox1.Location = new System.Drawing.Point(467, 140);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1245, 294);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox1.Location = new System.Drawing.Point(261, 196);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox1.Size = new System.Drawing.Size(133, 23);
            this.checkBox1.TabIndex = 93;
            this.checkBox1.Text = " : مع مرفقات";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(846, 32);
            this.txtID.Margin = new System.Windows.Forms.Padding(5);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(230, 27);
            this.txtID.TabIndex = 91;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextNumber_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(1085, 37);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 19);
            this.label11.TabIndex = 92;
            this.label11.Text = "الرقم المعرف:";
            // 
            // txtPriceTo
            // 
            this.txtPriceTo.Location = new System.Drawing.Point(449, 72);
            this.txtPriceTo.Margin = new System.Windows.Forms.Padding(5);
            this.txtPriceTo.Name = "txtPriceTo";
            this.txtPriceTo.Size = new System.Drawing.Size(86, 27);
            this.txtPriceTo.TabIndex = 87;
            // 
            // txtPriceFrom
            // 
            this.txtPriceFrom.Location = new System.Drawing.Point(576, 72);
            this.txtPriceFrom.Margin = new System.Windows.Forms.Padding(5);
            this.txtPriceFrom.Name = "txtPriceFrom";
            this.txtPriceFrom.Size = new System.Drawing.Size(86, 27);
            this.txtPriceFrom.TabIndex = 86;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(537, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 90;
            this.label3.Text = "الى";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(665, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 19);
            this.label4.TabIndex = 89;
            this.label4.Text = "من";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.BackColor = System.Drawing.Color.Transparent;
            this.priceLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.priceLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.priceLabel.Location = new System.Drawing.Point(710, 78);
            this.priceLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(64, 19);
            this.priceLabel.TabIndex = 88;
            this.priceLabel.Text = "السعر :";
            // 
            // txtNumberOfRooms
            // 
            this.txtNumberOfRooms.Location = new System.Drawing.Point(449, 113);
            this.txtNumberOfRooms.Margin = new System.Windows.Forms.Padding(5);
            this.txtNumberOfRooms.Name = "txtNumberOfRooms";
            this.txtNumberOfRooms.Size = new System.Drawing.Size(246, 27);
            this.txtNumberOfRooms.TabIndex = 84;
            this.txtNumberOfRooms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtNumberOfRooms.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextNumber_KeyPress);
            // 
            // roomsLabel
            // 
            this.roomsLabel.AutoSize = true;
            this.roomsLabel.BackColor = System.Drawing.Color.Transparent;
            this.roomsLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.roomsLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.roomsLabel.Location = new System.Drawing.Point(710, 118);
            this.roomsLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.roomsLabel.Name = "roomsLabel";
            this.roomsLabel.Size = new System.Drawing.Size(96, 19);
            this.roomsLabel.TabIndex = 85;
            this.roomsLabel.Text = "عدد الغرف :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(193, 114);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 27);
            this.label9.TabIndex = 83;
            this.label9.Text = "-";
            // 
            // txtInEvent
            // 
            this.txtInEvent.Location = new System.Drawing.Point(49, 150);
            this.txtInEvent.Margin = new System.Windows.Forms.Padding(5);
            this.txtInEvent.Name = "txtInEvent";
            this.txtInEvent.Size = new System.Drawing.Size(230, 27);
            this.txtInEvent.TabIndex = 18;
            this.txtInEvent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.txtInEvent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtInEvent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtInEvent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(42, 247);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 39);
            this.button1.TabIndex = 20;
            this.button1.Text = "بحث";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(285, 157);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 19);
            this.label6.TabIndex = 81;
            this.label6.Text = "في الحدث :";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox2.Location = new System.Drawing.Point(53, 116);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox2.Size = new System.Drawing.Size(116, 23);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "محدد تماما";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            // 
            // txtHomeOwner
            // 
            this.txtHomeOwner.Location = new System.Drawing.Point(49, 27);
            this.txtHomeOwner.Margin = new System.Windows.Forms.Padding(5);
            this.txtHomeOwner.Name = "txtHomeOwner";
            this.txtHomeOwner.Size = new System.Drawing.Size(230, 27);
            this.txtHomeOwner.TabIndex = 13;
            this.txtHomeOwner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtHomeOwner.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // ownerLabel
            // 
            this.ownerLabel.AutoSize = true;
            this.ownerLabel.BackColor = System.Drawing.Color.Transparent;
            this.ownerLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ownerLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ownerLabel.Location = new System.Drawing.Point(287, 33);
            this.ownerLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(119, 19);
            this.ownerLabel.TabIndex = 80;
            this.ownerLabel.Text = "صاحب المنزل :";
            // 
            // btnDischarge
            // 
            this.btnDischarge.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDischarge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDischarge.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnDischarge.ForeColor = System.Drawing.Color.White;
            this.btnDischarge.Location = new System.Drawing.Point(229, 247);
            this.btnDischarge.Margin = new System.Windows.Forms.Padding(5);
            this.btnDischarge.Name = "btnDischarge";
            this.btnDischarge.Size = new System.Drawing.Size(179, 39);
            this.btnDischarge.TabIndex = 19;
            this.btnDischarge.Text = "تفريغ";
            this.btnDischarge.UseVisualStyleBackColor = false;
            this.btnDischarge.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(406, 234);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 19);
            this.label8.TabIndex = 77;
            this.label8.Text = "يوما";
            // 
            // txtRentalExpiryDate
            // 
            this.txtRentalExpiryDate.Location = new System.Drawing.Point(450, 230);
            this.txtRentalExpiryDate.Margin = new System.Windows.Forms.Padding(5);
            this.txtRentalExpiryDate.Name = "txtRentalExpiryDate";
            this.txtRentalExpiryDate.ReadOnly = true;
            this.txtRentalExpiryDate.Size = new System.Drawing.Size(229, 27);
            this.txtRentalExpiryDate.TabIndex = 12;
            this.txtRentalExpiryDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtRentalExpiryDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(684, 238);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 19);
            this.label7.TabIndex = 75;
            this.label7.Text = "مدة انتهاء الاجار :";
            // 
            // chkInArchive
            // 
            this.chkInArchive.AutoSize = true;
            this.chkInArchive.BackColor = System.Drawing.Color.Transparent;
            this.chkInArchive.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkInArchive.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkInArchive.Location = new System.Drawing.Point(256, 116);
            this.chkInArchive.Margin = new System.Windows.Forms.Padding(5);
            this.chkInArchive.Name = "chkInArchive";
            this.chkInArchive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkInArchive.Size = new System.Drawing.Size(146, 23);
            this.chkInArchive.TabIndex = 16;
            this.chkInArchive.Text = " : في الارشيف";
            this.chkInArchive.UseVisualStyleBackColor = false;
            this.chkInArchive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            // 
            // cmbBuildingType
            // 
            this.cmbBuildingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuildingType.FormattingEnabled = true;
            this.cmbBuildingType.Items.AddRange(new object[] {
            "برجي",
            "طابقي",
            "تراسي",
            "سوق تجاري"});
            this.cmbBuildingType.Location = new System.Drawing.Point(846, 233);
            this.cmbBuildingType.Margin = new System.Windows.Forms.Padding(5);
            this.cmbBuildingType.Name = "cmbBuildingType";
            this.cmbBuildingType.Size = new System.Drawing.Size(230, 27);
            this.cmbBuildingType.TabIndex = 5;
            this.cmbBuildingType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(49, 70);
            this.p1.Margin = new System.Windows.Forms.Padding(5);
            this.p1.MaxLength = 255;
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(230, 27);
            this.p1.TabIndex = 14;
            this.p1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.p1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.p1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.p1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // txtBuilding
            // 
            this.txtBuilding.Location = new System.Drawing.Point(846, 154);
            this.txtBuilding.Margin = new System.Windows.Forms.Padding(5);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.Size = new System.Drawing.Size(230, 27);
            this.txtBuilding.TabIndex = 2;
            this.txtBuilding.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.txtBuilding.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.txtBuilding.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // phone_oneLabel
            // 
            this.phone_oneLabel.AutoSize = true;
            this.phone_oneLabel.BackColor = System.Drawing.Color.Transparent;
            this.phone_oneLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.phone_oneLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.phone_oneLabel.Location = new System.Drawing.Point(284, 75);
            this.phone_oneLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.phone_oneLabel.Name = "phone_oneLabel";
            this.phone_oneLabel.Size = new System.Drawing.Size(110, 19);
            this.phone_oneLabel.TabIndex = 67;
            this.phone_oneLabel.Text = "هــ \\م \\ أخر :";
            // 
            // regionTableAdapter
            // 
            this.regionTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(833, 803);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(740, 46);
            this.label5.TabIndex = 66;
            this.label5.Text = "مكــــتب رتيـــــب العقــــاري";
            this.label5.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RealStateRentSystem.Properties.Resources.logo_;
            this.pictureBox1.Location = new System.Drawing.Point(572, 462);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1039, 323);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(456, 134);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(1260, 308);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(168, 31);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 33);
            this.button3.TabIndex = 69;
            this.button3.Text = "تسجيل";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Highlight;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(46, 31);
            this.button4.Margin = new System.Windows.Forms.Padding(5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 33);
            this.button4.TabIndex = 70;
            this.button4.Text = "حفظ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Gp1);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.groupBox3.Location = new System.Drawing.Point(986, 42);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(291, 83);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "المواعيد";
            // 
            // Gp1
            // 
            this.Gp1.AutoSize = true;
            this.Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gp1.Location = new System.Drawing.Point(24, 38);
            this.Gp1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Gp1.Name = "Gp1";
            this.Gp1.Size = new System.Drawing.Size(14, 21);
            this.Gp1.TabIndex = 71;
            this.Gp1.Text = "i";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label10.Location = new System.Drawing.Point(1124, 859);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(270, 48);
            this.label10.TabIndex = 72;
            this.label10.Text = "Version: V 5.0";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // PanelUserColo
            // 
            this.PanelUserColo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelUserColo.Controls.Add(this.user);
            this.PanelUserColo.Controls.Add(this.button2);
            this.PanelUserColo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelUserColo.Location = new System.Drawing.Point(0, 0);
            this.PanelUserColo.Margin = new System.Windows.Forms.Padding(4);
            this.PanelUserColo.Name = "PanelUserColo";
            this.PanelUserColo.Size = new System.Drawing.Size(1946, 40);
            this.PanelUserColo.TabIndex = 73;
            this.PanelUserColo.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelUserColo_Paint);
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.user.ForeColor = System.Drawing.Color.White;
            this.user.Location = new System.Drawing.Point(836, 4);
            this.user.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(68, 24);
            this.user.TabIndex = 71;
            this.user.Text = "مرحبا ";
            // 
            // button2
            // 
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::RealStateRentSystem.Properties.Resources.KeyLogin;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 5;
            this.button2.Location = new System.Drawing.Point(1045, -2);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 40);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // FrmAlways
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1946, 1095);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.PanelUserColo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmAlways";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "always";
            this.Load += new System.EventHandler(this.always_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.always_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSregion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.PanelUserColo.ResumeLayout(false);
            this.PanelUserColo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubregion;
        private System.Windows.Forms.ComboBox cmbRentalMethod;
        private System.Windows.Forms.Label building_Type_IDLabel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label region_IDLabel;
        private System.Windows.Forms.Label subResgionIDLabel;
        private System.Windows.Forms.Label buildingLabel;
        private System.Windows.Forms.Label areaLabel;
        private System.Windows.Forms.Label wayOfRentLabel;
        private System.Windows.Forms.Label floorLabel;
        private System.Windows.Forms.Label status_IDLabel;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtAreaTo;
        private System.Windows.Forms.TextBox txtAreaFrom;
        private System.Windows.Forms.TextBox txtFloorComment;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbBuildingType;
        private System.Windows.Forms.TextBox p1;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label phone_oneLabel;
        private DSregion dSregion;
        private System.Windows.Forms.BindingSource regionBindingSource;
        private DSTables.DSregionTableAdapters.RegionTableAdapter regionTableAdapter;
        private System.Windows.Forms.CheckBox chkInArchive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRentalExpiryDate;
        private System.Windows.Forms.Button btnDischarge;
        private System.Windows.Forms.TextBox txtHomeOwner;
        private System.Windows.Forms.Label ownerLabel;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInEvent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label Gp1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumberOfRooms;
        private System.Windows.Forms.Label roomsLabel;
        private System.Windows.Forms.TextBox txtPriceTo;
        private System.Windows.Forms.TextBox txtPriceFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel PanelUserColo;
        private System.Windows.Forms.Button button2;
        private Label user;
        private CheckBox checkBox1;
    }
}