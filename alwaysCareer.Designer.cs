using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class alwaysCareer
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
            this.building_Type_IDLabel = new System.Windows.Forms.Label();
            this.Careertype = new System.Windows.Forms.ComboBox();
            this.typeOfcarrerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dScareer = new RealStateRentSystem.DSTables.DScareer();
            this.region_IDLabel = new System.Windows.Forms.Label();
            this.buildingLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.phone_oneLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.careerCatog = new System.Windows.Forms.ComboBox();
            this.p1 = new System.Windows.Forms.TextBox();
            this.personname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.typeOfcarrerTableAdapter = new RealStateRentSystem.DSTables.DScareerTableAdapters.TypeOfcarrerTableAdapter();
            this.careerCatogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.careerCatogTableAdapter = new RealStateRentSystem.DSTables.DScareerTableAdapters.careerCatogTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.typeOfcarrerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dScareer)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.careerCatogBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // building_Type_IDLabel
            // 
            this.building_Type_IDLabel.AutoSize = true;
            this.building_Type_IDLabel.BackColor = System.Drawing.Color.Transparent;
            this.building_Type_IDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.building_Type_IDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.building_Type_IDLabel.Location = new System.Drawing.Point(410, 31);
            this.building_Type_IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.building_Type_IDLabel.Name = "building_Type_IDLabel";
            this.building_Type_IDLabel.Size = new System.Drawing.Size(70, 17);
            this.building_Type_IDLabel.TabIndex = 17;
            this.building_Type_IDLabel.Text = "التصنيف :";
            // 
            // Careertype
            // 
            this.Careertype.DataSource = this.typeOfcarrerBindingSource;
            this.Careertype.DisplayMember = "name";
            this.Careertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Careertype.FormattingEnabled = true;
            this.Careertype.Location = new System.Drawing.Point(531, 25);
            this.Careertype.Margin = new System.Windows.Forms.Padding(4);
            this.Careertype.MaxDropDownItems = 100;
            this.Careertype.Name = "Careertype";
            this.Careertype.Size = new System.Drawing.Size(180, 24);
            this.Careertype.TabIndex = 1;
            this.Careertype.ValueMember = "name";
            this.Careertype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.Careertype.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            // 
            // typeOfcarrerBindingSource
            // 
            this.typeOfcarrerBindingSource.DataMember = "TypeOfcarrer";
            this.typeOfcarrerBindingSource.DataSource = this.dScareer;
            // 
            // dScareer
            // 
            this.dScareer.DataSetName = "DScareer";
            this.dScareer.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // region_IDLabel
            // 
            this.region_IDLabel.AutoSize = true;
            this.region_IDLabel.BackColor = System.Drawing.Color.Transparent;
            this.region_IDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.region_IDLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.region_IDLabel.Location = new System.Drawing.Point(724, 30);
            this.region_IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.region_IDLabel.Name = "region_IDLabel";
            this.region_IDLabel.Size = new System.Drawing.Size(57, 17);
            this.region_IDLabel.TabIndex = 3;
            this.region_IDLabel.Text = "المهنة :";
            // 
            // buildingLabel
            // 
            this.buildingLabel.AutoSize = true;
            this.buildingLabel.BackColor = System.Drawing.Color.Transparent;
            this.buildingLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buildingLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buildingLabel.Location = new System.Drawing.Point(724, 63);
            this.buildingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buildingLabel.Name = "buildingLabel";
            this.buildingLabel.Size = new System.Drawing.Size(56, 17);
            this.buildingLabel.TabIndex = 7;
            this.buildingLabel.Text = "الاسم :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.phone_oneLabel);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.careerCatog);
            this.groupBox1.Controls.Add(this.p1);
            this.groupBox1.Controls.Add(this.personname);
            this.groupBox1.Controls.Add(this.building_Type_IDLabel);
            this.groupBox1.Controls.Add(this.Careertype);
            this.groupBox1.Controls.Add(this.region_IDLabel);
            this.groupBox1.Controls.Add(this.buildingLabel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(939, 199);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // phone_oneLabel
            // 
            this.phone_oneLabel.AutoSize = true;
            this.phone_oneLabel.BackColor = System.Drawing.Color.Transparent;
            this.phone_oneLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.phone_oneLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.phone_oneLabel.Location = new System.Drawing.Point(724, 95);
            this.phone_oneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phone_oneLabel.Name = "phone_oneLabel";
            this.phone_oneLabel.Size = new System.Drawing.Size(95, 17);
            this.phone_oneLabel.TabIndex = 85;
            this.phone_oneLabel.Text = "هــ \\م \\ أخر :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(216, 59);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 24);
            this.textBox1.TabIndex = 5;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(391, 164);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 28);
            this.button1.TabIndex = 8;
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
            this.label6.Location = new System.Drawing.Point(410, 64);
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
            this.checkBox2.Location = new System.Drawing.Point(382, 96);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox2.Size = new System.Drawing.Size(114, 21);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = " : محدد تماما";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(502, 164);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "تفريغ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // careerCatog
            // 
            this.careerCatog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.careerCatog.FormattingEnabled = true;
            this.careerCatog.Items.AddRange(new object[] {
            "وسط",
            "جيد",
            "ممتاز"});
            this.careerCatog.Location = new System.Drawing.Point(216, 25);
            this.careerCatog.Margin = new System.Windows.Forms.Padding(4);
            this.careerCatog.MaxDropDownItems = 100;
            this.careerCatog.Name = "careerCatog";
            this.careerCatog.Size = new System.Drawing.Size(180, 24);
            this.careerCatog.TabIndex = 4;
            this.careerCatog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(531, 90);
            this.p1.Margin = new System.Windows.Forms.Padding(4);
            this.p1.MaxLength = 255;
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(180, 24);
            this.p1.TabIndex = 3;
            this.p1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.p1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.p1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.p1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // personname
            // 
            this.personname.Location = new System.Drawing.Point(531, 58);
            this.personname.Margin = new System.Windows.Forms.Padding(4);
            this.personname.Name = "personname";
            this.personname.Size = new System.Drawing.Size(180, 24);
            this.personname.TabIndex = 2;
            this.personname.MouseClick += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            this.personname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            this.personname.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buildingTextBox_KeyUp);
            this.personname.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entranceTextBox_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(628, 689);
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
            this.pictureBox1.Location = new System.Drawing.Point(509, 382);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(808, 272);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Yellow;
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(412, 118);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(951, 210);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            // 
            // typeOfcarrerTableAdapter
            // 
            this.typeOfcarrerTableAdapter.ClearBeforeFill = true;
            // 
            // careerCatogBindingSource
            // 
            this.careerCatogBindingSource.DataMember = "careerCatog";
            this.careerCatogBindingSource.DataSource = this.dScareer;
            // 
            // careerCatogTableAdapter
            // 
            this.careerCatogTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.user);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1622, 34);
            this.panel1.TabIndex = 73;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::RealStateRentSystem.Properties.Resources.KeyLogin;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(813, -2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 34);
            this.button3.TabIndex = 72;
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.user.TabIndex = 71;
            this.user.Text = "مرحبا ";
            // 
            // alwaysCareer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1622, 922);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "alwaysCareer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "always";
            this.Load += new System.EventHandler(this.always_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.always_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.typeOfcarrerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dScareer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.careerCatogBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label building_Type_IDLabel;
        private System.Windows.Forms.ComboBox Careertype;
        private System.Windows.Forms.Label region_IDLabel;
        private System.Windows.Forms.Label buildingLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox careerCatog;
        private System.Windows.Forms.TextBox p1;
        private System.Windows.Forms.TextBox personname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label phone_oneLabel;
        private DScareer dScareer;
        private System.Windows.Forms.BindingSource typeOfcarrerBindingSource;
        private DSTables.DScareerTableAdapters.TypeOfcarrerTableAdapter typeOfcarrerTableAdapter;
        private System.Windows.Forms.BindingSource careerCatogBindingSource;
        private DSTables.DScareerTableAdapters.careerCatogTableAdapter careerCatogTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Button button3;
    }
}