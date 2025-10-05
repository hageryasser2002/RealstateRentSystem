using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    partial class ToRentPrametr
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
            System.Windows.Forms.Label status_IDLabel;
            System.Windows.Forms.Label startRentDateLabel;
            System.Windows.Forms.Label endRendDateLabel;
            System.Windows.Forms.Label periodLabel;
            System.Windows.Forms.Label priceLabel;
            System.Windows.Forms.Label wayOfRentLabel;
            System.Windows.Forms.Label remainingDayLabel;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.remainingDayTextBox = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.wayOfRentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSrealstate = new RealStateRentSystem.DSTables.DSrealstate();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.status_IDListBox = new System.Windows.Forms.ComboBox();
            this.statusTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.periodTextBox = new System.Windows.Forms.TextBox();
            this.startRentDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endRendDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.wayOfRentTableAdapter = new RealStateRentSystem.DSTables.DSrealstateTableAdapters.WayOfRentTableAdapter();
            this.statusTypeTableAdapter = new RealStateRentSystem.DSTables.DSrealstateTableAdapters.StatusTypeTableAdapter();
            status_IDLabel = new System.Windows.Forms.Label();
            startRentDateLabel = new System.Windows.Forms.Label();
            endRendDateLabel = new System.Windows.Forms.Label();
            periodLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            wayOfRentLabel = new System.Windows.Forms.Label();
            remainingDayLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wayOfRentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealstate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // status_IDLabel
            // 
            status_IDLabel.AutoSize = true;
            status_IDLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            status_IDLabel.ForeColor = System.Drawing.Color.Black;
            status_IDLabel.Location = new System.Drawing.Point(447, 100);
            status_IDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            status_IDLabel.Name = "status_IDLabel";
            status_IDLabel.Size = new System.Drawing.Size(62, 19);
            status_IDLabel.TabIndex = 58;
            status_IDLabel.Text = "الحالة :";
            // 
            // startRentDateLabel
            // 
            startRentDateLabel.AutoSize = true;
            startRentDateLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            startRentDateLabel.ForeColor = System.Drawing.Color.Black;
            startRentDateLabel.Location = new System.Drawing.Point(379, 139);
            startRentDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            startRentDateLabel.Name = "startRentDateLabel";
            startRentDateLabel.Size = new System.Drawing.Size(125, 19);
            startRentDateLabel.TabIndex = 59;
            startRentDateLabel.Text = "تاريخ بدء الأجار :";
            // 
            // endRendDateLabel
            // 
            endRendDateLabel.AutoSize = true;
            endRendDateLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            endRendDateLabel.ForeColor = System.Drawing.Color.Black;
            endRendDateLabel.Location = new System.Drawing.Point(363, 177);
            endRendDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            endRendDateLabel.Name = "endRendDateLabel";
            endRendDateLabel.Size = new System.Drawing.Size(140, 19);
            endRendDateLabel.TabIndex = 60;
            endRendDateLabel.Text = "تاريخ انتهاء الأجار :";
            // 
            // periodLabel
            // 
            periodLabel.AutoSize = true;
            periodLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            periodLabel.ForeColor = System.Drawing.Color.Black;
            periodLabel.Location = new System.Drawing.Point(368, 215);
            periodLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            periodLabel.Name = "periodLabel";
            periodLabel.Size = new System.Drawing.Size(138, 19);
            periodLabel.TabIndex = 61;
            periodLabel.Text = "المده (بالاشهر ) :";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            priceLabel.ForeColor = System.Drawing.Color.Black;
            priceLabel.Location = new System.Drawing.Point(449, 25);
            priceLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(64, 19);
            priceLabel.TabIndex = 64;
            priceLabel.Text = "السعر :";
            // 
            // wayOfRentLabel
            // 
            wayOfRentLabel.AutoSize = true;
            wayOfRentLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            wayOfRentLabel.ForeColor = System.Drawing.Color.Black;
            wayOfRentLabel.Location = new System.Drawing.Point(391, 59);
            wayOfRentLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            wayOfRentLabel.Name = "wayOfRentLabel";
            wayOfRentLabel.Size = new System.Drawing.Size(117, 19);
            wayOfRentLabel.TabIndex = 65;
            wayOfRentLabel.Text = "طريقة التأجير :";
            // 
            // remainingDayLabel
            // 
            remainingDayLabel.AutoSize = true;
            remainingDayLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            remainingDayLabel.ForeColor = System.Drawing.Color.Black;
            remainingDayLabel.Location = new System.Drawing.Point(276, 252);
            remainingDayLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            remainingDayLabel.Name = "remainingDayLabel";
            remainingDayLabel.Size = new System.Drawing.Size(219, 19);
            remainingDayLabel.TabIndex = 103;
            remainingDayLabel.Text = "الوقت المتبقي لانتهاء الاجار :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.remainingDayTextBox);
            this.groupBox1.Controls.Add(remainingDayLabel);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(priceLabel);
            this.groupBox1.Controls.Add(wayOfRentLabel);
            this.groupBox1.Controls.Add(this.priceTextBox);
            this.groupBox1.Controls.Add(this.status_IDListBox);
            this.groupBox1.Controls.Add(this.periodTextBox);
            this.groupBox1.Controls.Add(this.startRentDateDateTimePicker);
            this.groupBox1.Controls.Add(this.endRendDateDateTimePicker);
            this.groupBox1.Controls.Add(status_IDLabel);
            this.groupBox1.Controls.Add(startRentDateLabel);
            this.groupBox1.Controls.Add(endRendDateLabel);
            this.groupBox1.Controls.Add(periodLabel);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Login);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(539, 390);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // remainingDayTextBox
            // 
            this.remainingDayTextBox.BackColor = System.Drawing.Color.White;
            this.remainingDayTextBox.Enabled = false;
            this.remainingDayTextBox.ForeColor = System.Drawing.Color.Red;
            this.remainingDayTextBox.Location = new System.Drawing.Point(42, 246);
            this.remainingDayTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.remainingDayTextBox.Name = "remainingDayTextBox";
            this.remainingDayTextBox.Size = new System.Drawing.Size(230, 27);
            this.remainingDayTextBox.TabIndex = 6;
            // 
            // comboBox4
            // 
            this.comboBox4.DataSource = this.wayOfRentBindingSource;
            this.comboBox4.DisplayMember = "WayOfRent";
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(42, 56);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(230, 27);
            this.comboBox4.TabIndex = 1;
            this.comboBox4.ValueMember = "ID";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // wayOfRentBindingSource
            // 
            this.wayOfRentBindingSource.DataMember = "WayOfRent";
            this.wayOfRentBindingSource.DataSource = this.dSrealstate;
            // 
            // dSrealstate
            // 
            this.dSrealstate.DataSetName = "DSrealstate";
            this.dSrealstate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(42, 18);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(230, 27);
            this.priceTextBox.TabIndex = 0;
            this.priceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // status_IDListBox
            // 
            this.status_IDListBox.DataSource = this.statusTypeBindingSource;
            this.status_IDListBox.DisplayMember = "StatusName";
            this.status_IDListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status_IDListBox.FormattingEnabled = true;
            this.status_IDListBox.Location = new System.Drawing.Point(42, 94);
            this.status_IDListBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.status_IDListBox.Name = "status_IDListBox";
            this.status_IDListBox.Size = new System.Drawing.Size(230, 27);
            this.status_IDListBox.TabIndex = 2;
            this.status_IDListBox.ValueMember = "ID";
            this.status_IDListBox.SelectedIndexChanged += new System.EventHandler(this.status_IDListBox_SelectedIndexChanged);
            this.status_IDListBox.SelectionChangeCommitted += new System.EventHandler(this.status_IDListBox_SelectionChangeCommitted);
            // 
            // statusTypeBindingSource
            // 
            this.statusTypeBindingSource.DataMember = "StatusType";
            this.statusTypeBindingSource.DataSource = this.dSrealstate;
            // 
            // periodTextBox
            // 
            this.periodTextBox.Location = new System.Drawing.Point(42, 208);
            this.periodTextBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.periodTextBox.Name = "periodTextBox";
            this.periodTextBox.Size = new System.Drawing.Size(230, 27);
            this.periodTextBox.TabIndex = 5;
            this.periodTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.periodTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.periodTextBox_KeyUp);
            // 
            // startRentDateDateTimePicker
            // 
            this.startRentDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startRentDateDateTimePicker.Location = new System.Drawing.Point(42, 132);
            this.startRentDateDateTimePicker.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.startRentDateDateTimePicker.Name = "startRentDateDateTimePicker";
            this.startRentDateDateTimePicker.RightToLeftLayout = true;
            this.startRentDateDateTimePicker.Size = new System.Drawing.Size(230, 27);
            this.startRentDateDateTimePicker.TabIndex = 3;
            this.startRentDateDateTimePicker.ValueChanged += new System.EventHandler(this.startRentDateDateTimePicker_ValueChanged);
            this.startRentDateDateTimePicker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.startRentDateDateTimePicker_KeyUp);
            // 
            // endRendDateDateTimePicker
            // 
            this.endRendDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endRendDateDateTimePicker.Location = new System.Drawing.Point(42, 171);
            this.endRendDateDateTimePicker.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.endRendDateDateTimePicker.Name = "endRendDateDateTimePicker";
            this.endRendDateDateTimePicker.RightToLeftLayout = true;
            this.endRendDateDateTimePicker.Size = new System.Drawing.Size(230, 27);
            this.endRendDateDateTimePicker.TabIndex = 4;
            this.endRendDateDateTimePicker.ValueChanged += new System.EventHandler(this.startRentDateDateTimePicker_ValueChanged);
            this.endRendDateDateTimePicker.KeyUp += new System.Windows.Forms.KeyEventHandler(this.startRentDateDateTimePicker_KeyUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(165, 297);
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
            this.Login.Location = new System.Drawing.Point(42, 297);
            this.Login.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(113, 33);
            this.Login.TabIndex = 10;
            this.Login.Text = "تم";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // wayOfRentTableAdapter
            // 
            this.wayOfRentTableAdapter.ClearBeforeFill = true;
            // 
            // statusTypeTableAdapter
            // 
            this.statusTypeTableAdapter.ClearBeforeFill = true;
            // 
            // ToRentPrametr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(539, 390);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ToRentPrametr";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "نسخ الى الاجار";
            this.Load += new System.EventHandler(this.ToOwnPrametr_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wayOfRentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSrealstate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox status_IDListBox;
        private System.Windows.Forms.TextBox periodTextBox;
        private System.Windows.Forms.DateTimePicker startRentDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker endRendDateDateTimePicker;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.TextBox remainingDayTextBox;
        private DSrealstate dSrealstate;
        private System.Windows.Forms.BindingSource wayOfRentBindingSource;
        private DSTables.DSrealstateTableAdapters.WayOfRentTableAdapter wayOfRentTableAdapter;
        private System.Windows.Forms.BindingSource statusTypeBindingSource;
        private DSTables.DSrealstateTableAdapters.StatusTypeTableAdapter statusTypeTableAdapter;
    }
}