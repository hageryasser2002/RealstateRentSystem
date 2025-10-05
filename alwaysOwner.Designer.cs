using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class alwaysOwner
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
            this.subregioncombo = new System.Windows.Forms.TextBox();
            this.wayofrentcobmo = new System.Windows.Forms.ComboBox();
            this.wayOFOwnerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSrealowner = new RealStateRentSystem.DSTables.DSrealowner();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.building_Type_IDLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.regioncompo = new System.Windows.Forms.ComboBox();
            this.regionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSregion = new RealStateRentSystem.DSTables.DSregion();
            this.label1 = new System.Windows.Forms.Label();
            this.region_IDLabel = new System.Windows.Forms.Label();
            this.subResgionIDLabel = new System.Windows.Forms.Label();
            this.buildingLabel = new System.Windows.Forms.Label();
            this.areaLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.wayOfRentLabel = new System.Windows.Forms.Label();
            this.floorLabel = new System.Windows.Forms.Label();
            this.ct = new System.Windows.Forms.TextBox();
            this.at = new System.Windows.Forms.TextBox();
            this.cf = new System.Windows.Forms.TextBox();
            this.af = new System.Windows.Forms.TextBox();
            this.floorComment = new System.Windows.Forms.TextBox();
            this.floor = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.roomsTextBox = new System.Windows.Forms.TextBox();
            this.roomsLabel = new System.Windows.Forms.Label();
            this.phone_oneLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.owner = new System.Windows.Forms.TextBox();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buildingtypecombp = new System.Windows.Forms.ComboBox();
            this.p1 = new System.Windows.Forms.TextBox();
            this.building = new System.Windows.Forms.TextBox();
            this.regionTableAdapter = new RealStateRentSystem.DSTables.DSregionTableAdapters.RegionTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wayOFOwnerTableAdapter = new RealStateRentSystem.DSTables.DSrealownerTableAdapters.WayOFOwnerTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.user = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Gp1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wayOFOwnerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealowner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSregion)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // subregioncombo
            // 
            this.subregioncombo.Location = new System.Drawing.Point(646, 96);
            this.subregioncombo.Margin = new System.Windows.Forms.Padding(4);
            this.subregioncombo.Name = "subregioncombo";
            this.subregioncombo.Size = new System.Drawing.Size(180, 24);
            this.subregioncombo.TabIndex = 1;
            this.subregioncombo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.subregioncombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.subregioncombo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.subregioncombo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // wayofrentcobmo
            // 
            this.wayofrentcobmo.DataSource = this.wayOFOwnerBindingSource;
            this.wayofrentcobmo.DisplayMember = "Name";
            this.wayofrentcobmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wayofrentcobmo.FormattingEnabled = true;
            this.wayofrentcobmo.Location = new System.Drawing.Point(331, 131);
            this.wayofrentcobmo.Margin = new System.Windows.Forms.Padding(4);
            this.wayofrentcobmo.Name = "wayofrentcobmo";
            this.wayofrentcobmo.Size = new System.Drawing.Size(193, 24);
            this.wayofrentcobmo.TabIndex = 10;
            this.wayofrentcobmo.ValueMember = "Name";
            this.wayofrentcobmo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.wayofrentcobmo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(400, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 55;
            this.label3.Text = "الى";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(499, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "من";
            // 
            // building_Type_IDLabel
            // 
            this.building_Type_IDLabel.AutoSize = true;
            this.building_Type_IDLabel.BackColor = System.Drawing.Color.Transparent;
            this.building_Type_IDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.building_Type_IDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.building_Type_IDLabel.Location = new System.Drawing.Point(534, 169);
            this.building_Type_IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.building_Type_IDLabel.Name = "building_Type_IDLabel";
            this.building_Type_IDLabel.Size = new System.Drawing.Size(74, 17);
            this.building_Type_IDLabel.TabIndex = 17;
            this.building_Type_IDLabel.Text = "نوع البناء :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(400, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "الى";
            // 
            // regioncompo
            // 
            this.regioncompo.DataSource = this.regionBindingSource;
            this.regioncompo.DisplayMember = "Name";
            this.regioncompo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regioncompo.FormattingEnabled = true;
            this.regioncompo.Location = new System.Drawing.Point(646, 59);
            this.regioncompo.Margin = new System.Windows.Forms.Padding(4);
            this.regioncompo.MaxDropDownItems = 100;
            this.regioncompo.MaxLength = 100;
            this.regioncompo.Name = "regioncompo";
            this.regioncompo.Size = new System.Drawing.Size(180, 24);
            this.regioncompo.TabIndex = 0;
            this.regioncompo.ValueMember = "ID";
            this.regioncompo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.regioncompo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
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
            this.label1.Location = new System.Drawing.Point(499, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "من";
            // 
            // region_IDLabel
            // 
            this.region_IDLabel.AutoSize = true;
            this.region_IDLabel.BackColor = System.Drawing.Color.Transparent;
            this.region_IDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.region_IDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.region_IDLabel.Location = new System.Drawing.Point(840, 66);
            this.region_IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.region_IDLabel.Name = "region_IDLabel";
            this.region_IDLabel.Size = new System.Drawing.Size(69, 17);
            this.region_IDLabel.TabIndex = 3;
            this.region_IDLabel.Text = "المنطقة :";
            // 
            // subResgionIDLabel
            // 
            this.subResgionIDLabel.AutoSize = true;
            this.subResgionIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.subResgionIDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.subResgionIDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.subResgionIDLabel.Location = new System.Drawing.Point(840, 96);
            this.subResgionIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subResgionIDLabel.Name = "subResgionIDLabel";
            this.subResgionIDLabel.Size = new System.Drawing.Size(126, 17);
            this.subResgionIDLabel.TabIndex = 5;
            this.subResgionIDLabel.Text = "الجزيرة \\ الشارع :";
            // 
            // buildingLabel
            // 
            this.buildingLabel.AutoSize = true;
            this.buildingLabel.BackColor = System.Drawing.Color.Transparent;
            this.buildingLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buildingLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buildingLabel.Location = new System.Drawing.Point(840, 132);
            this.buildingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buildingLabel.Name = "buildingLabel";
            this.buildingLabel.Size = new System.Drawing.Size(47, 17);
            this.buildingLabel.TabIndex = 7;
            this.buildingLabel.Text = "البناء :";
            // 
            // areaLabel
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.BackColor = System.Drawing.Color.Transparent;
            this.areaLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.areaLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.areaLabel.Location = new System.Drawing.Point(534, 30);
            this.areaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.areaLabel.Name = "areaLabel";
            this.areaLabel.Size = new System.Drawing.Size(76, 17);
            this.areaLabel.TabIndex = 33;
            this.areaLabel.Text = "المساحة :";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.BackColor = System.Drawing.Color.Transparent;
            this.priceLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.priceLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.priceLabel.Location = new System.Drawing.Point(534, 63);
            this.priceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(57, 17);
            this.priceLabel.TabIndex = 35;
            this.priceLabel.Text = "السعر :";
            // 
            // wayOfRentLabel
            // 
            this.wayOfRentLabel.AutoSize = true;
            this.wayOfRentLabel.BackColor = System.Drawing.Color.Transparent;
            this.wayOfRentLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.wayOfRentLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.wayOfRentLabel.Location = new System.Drawing.Point(533, 134);
            this.wayOfRentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.wayOfRentLabel.Name = "wayOfRentLabel";
            this.wayOfRentLabel.Size = new System.Drawing.Size(107, 17);
            this.wayOfRentLabel.TabIndex = 39;
            this.wayOfRentLabel.Text = "طريقة البيع :";
            // 
            // floorLabel
            // 
            this.floorLabel.AutoSize = true;
            this.floorLabel.BackColor = System.Drawing.Color.Transparent;
            this.floorLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.floorLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.floorLabel.Location = new System.Drawing.Point(840, 166);
            this.floorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.floorLabel.Name = "floorLabel";
            this.floorLabel.Size = new System.Drawing.Size(63, 17);
            this.floorLabel.TabIndex = 9;
            this.floorLabel.Text = "الطابق :";
            // 
            // ct
            // 
            this.ct.Location = new System.Drawing.Point(331, 58);
            this.ct.Margin = new System.Windows.Forms.Padding(4);
            this.ct.Name = "ct";
            this.ct.Size = new System.Drawing.Size(68, 24);
            this.ct.TabIndex = 9;
            this.ct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.ct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1_KeyPress);
            // 
            // at
            // 
            this.at.Location = new System.Drawing.Point(331, 25);
            this.at.Margin = new System.Windows.Forms.Padding(4);
            this.at.Name = "at";
            this.at.Size = new System.Drawing.Size(68, 24);
            this.at.TabIndex = 7;
            this.at.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.at.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1_KeyPress);
            // 
            // cf
            // 
            this.cf.Location = new System.Drawing.Point(430, 58);
            this.cf.Margin = new System.Windows.Forms.Padding(4);
            this.cf.Name = "cf";
            this.cf.Size = new System.Drawing.Size(68, 24);
            this.cf.TabIndex = 8;
            this.cf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.cf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1_KeyPress);
            // 
            // af
            // 
            this.af.Location = new System.Drawing.Point(430, 25);
            this.af.Margin = new System.Windows.Forms.Padding(4);
            this.af.Name = "af";
            this.af.Size = new System.Drawing.Size(68, 24);
            this.af.TabIndex = 6;
            this.af.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.af.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1_KeyPress);
            // 
            // floorComment
            // 
            this.floorComment.Location = new System.Drawing.Point(646, 166);
            this.floorComment.Margin = new System.Windows.Forms.Padding(4);
            this.floorComment.Name = "floorComment";
            this.floorComment.Size = new System.Drawing.Size(92, 24);
            this.floorComment.TabIndex = 4;
            this.floorComment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.floorComment.TextChanged += new System.EventHandler(this.floorComment_TextChanged);
            this.floorComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.floorComment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.floorComment.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // floor
            // 
            this.floor.Location = new System.Drawing.Point(738, 166);
            this.floor.Margin = new System.Windows.Forms.Padding(4);
            this.floor.Name = "floor";
            this.floor.Size = new System.Drawing.Size(89, 24);
            this.floor.TabIndex = 3;
            this.floor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.floor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.floor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1_KeyPress);
            this.floor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.floor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.IDTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.roomsTextBox);
            this.groupBox1.Controls.Add(this.roomsLabel);
            this.groupBox1.Controls.Add(this.phone_oneLabel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.owner);
            this.groupBox1.Controls.Add(this.ownerLabel);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.subregioncombo);
            this.groupBox1.Controls.Add(this.wayofrentcobmo);
            this.groupBox1.Controls.Add(this.buildingtypecombp);
            this.groupBox1.Controls.Add(this.ct);
            this.groupBox1.Controls.Add(this.at);
            this.groupBox1.Controls.Add(this.cf);
            this.groupBox1.Controls.Add(this.af);
            this.groupBox1.Controls.Add(this.floorComment);
            this.groupBox1.Controls.Add(this.floor);
            this.groupBox1.Controls.Add(this.p1);
            this.groupBox1.Controls.Add(this.building);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.building_Type_IDLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.regioncompo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.region_IDLabel);
            this.groupBox1.Controls.Add(this.subResgionIDLabel);
            this.groupBox1.Controls.Add(this.buildingLabel);
            this.groupBox1.Controls.Add(this.areaLabel);
            this.groupBox1.Controls.Add(this.priceLabel);
            this.groupBox1.Controls.Add(this.wayOfRentLabel);
            this.groupBox1.Controls.Add(this.floorLabel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(6, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(968, 248);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox3.Location = new System.Drawing.Point(187, 169);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox3.Size = new System.Drawing.Size(113, 21);
            this.checkBox3.TabIndex = 90;
            this.checkBox3.Text = " : مع مرفقات";
            this.checkBox3.UseVisualStyleBackColor = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(646, 25);
            this.IDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(180, 24);
            this.IDTextBox.TabIndex = 88;
            this.IDTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.IDTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextNumber_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(840, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 89;
            this.label7.Text = "الرقم المعرف :";
            // 
            // roomsTextBox
            // 
            this.roomsTextBox.Location = new System.Drawing.Point(331, 95);
            this.roomsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.roomsTextBox.Name = "roomsTextBox";
            this.roomsTextBox.Size = new System.Drawing.Size(193, 24);
            this.roomsTextBox.TabIndex = 86;
            this.roomsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.roomsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextNumber_KeyPress);
            // 
            // roomsLabel
            // 
            this.roomsLabel.AutoSize = true;
            this.roomsLabel.BackColor = System.Drawing.Color.Transparent;
            this.roomsLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.roomsLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.roomsLabel.Location = new System.Drawing.Point(534, 98);
            this.roomsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roomsLabel.Name = "roomsLabel";
            this.roomsLabel.Size = new System.Drawing.Size(85, 17);
            this.roomsLabel.TabIndex = 87;
            this.roomsLabel.Text = "عدد الغرف :";
            // 
            // phone_oneLabel
            // 
            this.phone_oneLabel.AutoSize = true;
            this.phone_oneLabel.BackColor = System.Drawing.Color.Transparent;
            this.phone_oneLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.phone_oneLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.phone_oneLabel.Location = new System.Drawing.Point(210, 63);
            this.phone_oneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phone_oneLabel.Name = "phone_oneLabel";
            this.phone_oneLabel.Size = new System.Drawing.Size(95, 17);
            this.phone_oneLabel.TabIndex = 85;
            this.phone_oneLabel.Text = "هــ \\م \\ أخر :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(153, 96);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 23);
            this.label9.TabIndex = 84;
            this.label9.Text = "-";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 131);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 24);
            this.textBox1.TabIndex = 16;
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(23, 209);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 33);
            this.button1.TabIndex = 18;
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
            this.label6.Location = new System.Drawing.Point(210, 136);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 81;
            this.label6.Text = "في الحدث :";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox2.Location = new System.Drawing.Point(26, 96);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox2.Size = new System.Drawing.Size(114, 21);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = " : محدد تماما";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            // 
            // owner
            // 
            this.owner.Location = new System.Drawing.Point(26, 23);
            this.owner.Margin = new System.Windows.Forms.Padding(4);
            this.owner.Name = "owner";
            this.owner.Size = new System.Drawing.Size(180, 24);
            this.owner.TabIndex = 11;
            this.owner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.owner.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // ownerLabel
            // 
            this.ownerLabel.AutoSize = true;
            this.ownerLabel.BackColor = System.Drawing.Color.Transparent;
            this.ownerLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ownerLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ownerLabel.Location = new System.Drawing.Point(211, 28);
            this.ownerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(105, 17);
            this.ownerLabel.TabIndex = 80;
            this.ownerLabel.Text = "صاحب المنزل :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(171, 209);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 33);
            this.button2.TabIndex = 17;
            this.button2.Text = "تفريغ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox1.Location = new System.Drawing.Point(187, 97);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox1.Size = new System.Drawing.Size(126, 21);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = " : في الارشيف";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            // 
            // buildingtypecombp
            // 
            this.buildingtypecombp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.buildingtypecombp.FormattingEnabled = true;
            this.buildingtypecombp.Items.AddRange(new object[] {
            "برجي",
            "طابقي",
            "تراسي",
            "ارض",
            "سوق تجاري"});
            this.buildingtypecombp.Location = new System.Drawing.Point(331, 165);
            this.buildingtypecombp.Margin = new System.Windows.Forms.Padding(4);
            this.buildingtypecombp.Name = "buildingtypecombp";
            this.buildingtypecombp.Size = new System.Drawing.Size(193, 24);
            this.buildingtypecombp.TabIndex = 5;
            this.buildingtypecombp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(26, 58);
            this.p1.Margin = new System.Windows.Forms.Padding(4);
            this.p1.MaxLength = 255;
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(180, 24);
            this.p1.TabIndex = 12;
            this.p1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.p1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.p1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.p1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // building
            // 
            this.building.Location = new System.Drawing.Point(646, 131);
            this.building.Margin = new System.Windows.Forms.Padding(4);
            this.building.Name = "building";
            this.building.Size = new System.Drawing.Size(180, 24);
            this.building.TabIndex = 2;
            this.building.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.building.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.building.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
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
            this.label5.Location = new System.Drawing.Point(698, 681);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(617, 37);
            this.label5.TabIndex = 66;
            this.label5.Text = "مكــــتب رتيـــــب العقــــاري";
            this.label5.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RealStateRentSystem.Properties.Resources.logo_;
            this.pictureBox1.Location = new System.Drawing.Point(512, 399);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(808, 272);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // wayOFOwnerTableAdapter
            // 
            this.wayOFOwnerTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(412, 118);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(979, 260);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.user.ForeColor = System.Drawing.Color.White;
            this.user.Location = new System.Drawing.Point(650, 3);
            this.user.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(60, 21);
            this.user.TabIndex = 69;
            this.user.Text = "مرحبا ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Gp1);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.groupBox3.Location = new System.Drawing.Point(754, 35);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(226, 70);
            this.groupBox3.TabIndex = 72;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "المواعيد";
            // 
            // Gp1
            // 
            this.Gp1.AutoSize = true;
            this.Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Gp1.Location = new System.Drawing.Point(19, 32);
            this.Gp1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Gp1.Name = "Gp1";
            this.Gp1.Size = new System.Drawing.Size(12, 19);
            this.Gp1.TabIndex = 72;
            this.Gp1.Text = "i";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(131, 26);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 28);
            this.button3.TabIndex = 69;
            this.button3.Text = "تسجيل";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Highlight;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(36, 26);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 28);
            this.button4.TabIndex = 70;
            this.button4.Text = "حفظ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.user);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1622, 34);
            this.panel1.TabIndex = 73;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::RealStateRentSystem.Properties.Resources.KeyLogin;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.Location = new System.Drawing.Point(813, -2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(38, 34);
            this.button5.TabIndex = 70;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // alwaysOwner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1622, 922);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "alwaysOwner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "9";
            this.Load += new System.EventHandler(this.always_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.wayOFOwnerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealowner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSregion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox subregioncombo;
        private System.Windows.Forms.ComboBox wayofrentcobmo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label building_Type_IDLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox regioncompo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label region_IDLabel;
        private System.Windows.Forms.Label subResgionIDLabel;
        private System.Windows.Forms.Label buildingLabel;
        private System.Windows.Forms.Label areaLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label wayOfRentLabel;
        private System.Windows.Forms.Label floorLabel;
        private System.Windows.Forms.TextBox ct;
        private System.Windows.Forms.TextBox at;
        private System.Windows.Forms.TextBox cf;
        private System.Windows.Forms.TextBox af;
        private System.Windows.Forms.TextBox floorComment;
        private System.Windows.Forms.TextBox floor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox buildingtypecombp;
        private System.Windows.Forms.TextBox p1;
        private System.Windows.Forms.TextBox building;
        private System.Windows.Forms.Button button1;
        private DSregion dSregion;
        private System.Windows.Forms.BindingSource regionBindingSource;
        private DSTables.DSregionTableAdapters.RegionTableAdapter regionTableAdapter;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox owner;
        private System.Windows.Forms.Label ownerLabel;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private DSrealowner dSrealowner;
        private System.Windows.Forms.BindingSource wayOFOwnerBindingSource;
        private DSTables.DSrealownerTableAdapters.WayOFOwnerTableAdapter wayOFOwnerTableAdapter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label phone_oneLabel;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.Label Gp1;
        private System.Windows.Forms.TextBox roomsTextBox;
        private System.Windows.Forms.Label roomsLabel;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}