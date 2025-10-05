using System.Drawing;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.العقاراتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.العقاراتToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.الأرشيفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.الاحصائياتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.الهاتفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.المهنToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.الاحصائياتToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.التنبيهاتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.الاعدادتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مفاتيحإختصارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.النماذجالمرفقهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.اعداداتالنظامToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعريفالمستخدمينToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.APItoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مناطقToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.طرقالبيعToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اعداداتالنظامالبيعToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اعداداتنظامالايجارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.انواعالمهنToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ادواتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حولToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حولToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.main_timer = new System.Windows.Forms.Timer(this.components);
            this.wayOfRentTableAdapter = new RealStateRentSystem.DSTables.DSrealstateTableAdapters.WayOfRentTableAdapter();
            this.statusTypeTableAdapter = new RealStateRentSystem.DSTables.DSrealstateTableAdapters.StatusTypeTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtPhoneSearch = new System.Windows.Forms.TextBox();
            this.Imagencrypt2 = new System.Windows.Forms.PictureBox();
            this.Imagencrypt = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Imagencrypt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagencrypt)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.العقاراتToolStripMenuItem,
            this.الاعدادتToolStripMenuItem,
            this.ادواتToolStripMenuItem,
            this.حولToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1902, 36);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // العقاراتToolStripMenuItem
            // 
            this.العقاراتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.العقاراتToolStripMenuItem1,
            this.الأرشيفToolStripMenuItem,
            this.interToolStripMenuItem,
            this.archiveToolStripMenuItem,
            this.الاحصائياتToolStripMenuItem,
            this.الهاتفToolStripMenuItem,
            this.المهنToolStripMenuItem,
            this.الاحصائياتToolStripMenuItem1,
            this.التنبيهاتToolStripMenuItem});
            this.العقاراتToolStripMenuItem.MergeIndex = 10;
            this.العقاراتToolStripMenuItem.Name = "العقاراتToolStripMenuItem";
            this.العقاراتToolStripMenuItem.ShowShortcutKeys = false;
            this.العقاراتToolStripMenuItem.Size = new System.Drawing.Size(84, 32);
            this.العقاراتToolStripMenuItem.Text = "البرنامج";
            // 
            // العقاراتToolStripMenuItem1
            // 
            this.العقاراتToolStripMenuItem1.Image = global::RealStateRentSystem.Properties.Resources.home_menu;
            this.العقاراتToolStripMenuItem1.Name = "العقاراتToolStripMenuItem1";
            this.العقاراتToolStripMenuItem1.Size = new System.Drawing.Size(216, 34);
            this.العقاراتToolStripMenuItem1.Text = "ادخال تأجير";
            this.العقاراتToolStripMenuItem1.Click += new System.EventHandler(this.العقاراتToolStripMenuItem1_Click);
            // 
            // الأرشيفToolStripMenuItem
            // 
            this.الأرشيفToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.Address_Book;
            this.الأرشيفToolStripMenuItem.Name = "الأرشيفToolStripMenuItem";
            this.الأرشيفToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.الأرشيفToolStripMenuItem.Text = "أرشيف التأجير";
            this.الأرشيفToolStripMenuItem.Click += new System.EventHandler(this.الأرشيفToolStripMenuItem_Click);
            // 
            // interToolStripMenuItem
            // 
            this.interToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.home_menu;
            this.interToolStripMenuItem.Name = "interToolStripMenuItem";
            this.interToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.interToolStripMenuItem.Text = "ادخال البيع";
            this.interToolStripMenuItem.Visible = false;
            this.interToolStripMenuItem.Click += new System.EventHandler(this.interToolStripMenuItem_Click);
            // 
            // archiveToolStripMenuItem
            // 
            this.archiveToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.Address_Book;
            this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            this.archiveToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.archiveToolStripMenuItem.Text = "أرشيف البيع";
            this.archiveToolStripMenuItem.Visible = false;
            this.archiveToolStripMenuItem.Click += new System.EventHandler(this.archiveToolStripMenuItem_Click);
            // 
            // الاحصائياتToolStripMenuItem
            // 
            this.الاحصائياتToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.readebook;
            this.الاحصائياتToolStripMenuItem.Name = "الاحصائياتToolStripMenuItem";
            this.الاحصائياتToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.الاحصائياتToolStripMenuItem.Text = "مراجعة البيع";
            this.الاحصائياتToolStripMenuItem.Visible = false;
            this.الاحصائياتToolStripMenuItem.Click += new System.EventHandler(this.الاحصائياتToolStripMenuItem_Click);
            // 
            // الهاتفToolStripMenuItem
            // 
            this.الهاتفToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.ctxhelp_opn;
            this.الهاتفToolStripMenuItem.Name = "الهاتفToolStripMenuItem";
            this.الهاتفToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.الهاتفToolStripMenuItem.Text = "الهاتف";
            this.الهاتفToolStripMenuItem.Visible = false;
            this.الهاتفToolStripMenuItem.Click += new System.EventHandler(this.الهاتفToolStripMenuItem_Click);
            // 
            // المهنToolStripMenuItem
            // 
            this.المهنToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.designer_icon;
            this.المهنToolStripMenuItem.Name = "المهنToolStripMenuItem";
            this.المهنToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.المهنToolStripMenuItem.Text = "المهن";
            this.المهنToolStripMenuItem.Visible = false;
            this.المهنToolStripMenuItem.Click += new System.EventHandler(this.المهنToolStripMenuItem_Click);
            // 
            // الاحصائياتToolStripMenuItem1
            // 
            this.الاحصائياتToolStripMenuItem1.Image = global::RealStateRentSystem.Properties.Resources.readebook;
            this.الاحصائياتToolStripMenuItem1.Name = "الاحصائياتToolStripMenuItem1";
            this.الاحصائياتToolStripMenuItem1.Size = new System.Drawing.Size(216, 34);
            this.الاحصائياتToolStripMenuItem1.Text = "مراجعة الاجار";
            this.الاحصائياتToolStripMenuItem1.Click += new System.EventHandler(this.الاحصائياتToolStripMenuItem1_Click);
            // 
            // التنبيهاتToolStripMenuItem
            // 
            this.التنبيهاتToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.AG00040_;
            this.التنبيهاتToolStripMenuItem.Name = "التنبيهاتToolStripMenuItem";
            this.التنبيهاتToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.التنبيهاتToolStripMenuItem.Text = "التنبيهات";
            this.التنبيهاتToolStripMenuItem.Click += new System.EventHandler(this.التنبيهاتToolStripMenuItem_Click);
            // 
            // الاعدادتToolStripMenuItem
            // 
            this.الاعدادتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.مفاتيحإختصارToolStripMenuItem,
            this.النماذجالمرفقهToolStripMenuItem,
            this.toolStripSeparator1,
            this.اعداداتالنظامToolStripMenuItem,
            this.administratorToolStripMenuItem,
            this.تعريفالمستخدمينToolStripMenuItem,
            this.تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem,
            this.APItoolStripMenuItem,
            this.مناطقToolStripMenuItem,
            this.toolStripSeparator2,
            this.طرقالبيعToolStripMenuItem,
            this.اعداداتالنظامالبيعToolStripMenuItem,
            this.اعداداتنظامالايجارToolStripMenuItem,
            this.انواعالمهنToolStripMenuItem});
            this.الاعدادتToolStripMenuItem.Name = "الاعدادتToolStripMenuItem";
            this.الاعدادتToolStripMenuItem.Size = new System.Drawing.Size(95, 32);
            this.الاعدادتToolStripMenuItem.Text = "الاعدادت";
            // 
            // مفاتيحإختصارToolStripMenuItem
            // 
            this.مفاتيحإختصارToolStripMenuItem.Enabled = false;
            this.مفاتيحإختصارToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.key;
            this.مفاتيحإختصارToolStripMenuItem.Name = "مفاتيحإختصارToolStripMenuItem";
            this.مفاتيحإختصارToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.مفاتيحإختصارToolStripMenuItem.Text = "مفاتيح إختصار";
            this.مفاتيحإختصارToolStripMenuItem.Click += new System.EventHandler(this.مفاتيحإختصارToolStripMenuItem_Click);
            // 
            // النماذجالمرفقهToolStripMenuItem
            // 
            this.النماذجالمرفقهToolStripMenuItem.Enabled = false;
            this.النماذجالمرفقهToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.help;
            this.النماذجالمرفقهToolStripMenuItem.Name = "النماذجالمرفقهToolStripMenuItem";
            this.النماذجالمرفقهToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.النماذجالمرفقهToolStripMenuItem.Text = "النماذج المرفقه";
            this.النماذجالمرفقهToolStripMenuItem.Click += new System.EventHandler(this.النماذجالمرفقهToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(349, 6);
            // 
            // اعداداتالنظامToolStripMenuItem
            // 
            this.اعداداتالنظامToolStripMenuItem.Enabled = false;
            this.اعداداتالنظامToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.setting;
            this.اعداداتالنظامToolStripMenuItem.Name = "اعداداتالنظامToolStripMenuItem";
            this.اعداداتالنظامToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.اعداداتالنظامToolStripMenuItem.Text = "اعدادات النظام";
            this.اعداداتالنظامToolStripMenuItem.Click += new System.EventHandler(this.اعداداتالنظامToolStripMenuItem_Click);
            // 
            // administratorToolStripMenuItem
            // 
            this.administratorToolStripMenuItem.Enabled = false;
            this.administratorToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.image1;
            this.administratorToolStripMenuItem.Name = "administratorToolStripMenuItem";
            this.administratorToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.administratorToolStripMenuItem.Text = "Administrator";
            this.administratorToolStripMenuItem.Click += new System.EventHandler(this.administratorToolStripMenuItem_Click);
            // 
            // تعريفالمستخدمينToolStripMenuItem
            // 
            this.تعريفالمستخدمينToolStripMenuItem.Enabled = false;
            this.تعريفالمستخدمينToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.messenger_big1;
            this.تعريفالمستخدمينToolStripMenuItem.Name = "تعريفالمستخدمينToolStripMenuItem";
            this.تعريفالمستخدمينToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.تعريفالمستخدمينToolStripMenuItem.Text = "تعريف المستخدمين";
            this.تعريفالمستخدمينToolStripMenuItem.Click += new System.EventHandler(this.تعريفالمستخدمينToolStripMenuItem_Click);
            // 
            // تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem
            // 
            this.تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem.Enabled = false;
            this.تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem.Name = "تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem";
            this.تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem.Text = "تفيعل التنبيه والنسخة الاحتياطية";
            this.تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem.Click += new System.EventHandler(this.تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem_Click);
            // 
            // APItoolStripMenuItem
            // 
            this.APItoolStripMenuItem.Enabled = false;
            this.APItoolStripMenuItem.Name = "APItoolStripMenuItem";
            this.APItoolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.APItoolStripMenuItem.Text = "API";
            this.APItoolStripMenuItem.Click += new System.EventHandler(this.APIToolStripMenuItem_Click);
            // 
            // مناطقToolStripMenuItem
            // 
            this.مناطقToolStripMenuItem.Enabled = false;
            this.مناطقToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.region;
            this.مناطقToolStripMenuItem.Name = "مناطقToolStripMenuItem";
            this.مناطقToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.مناطقToolStripMenuItem.Text = "مناطق";
            this.مناطقToolStripMenuItem.Click += new System.EventHandler(this.مناطقToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(349, 6);
            // 
            // طرقالبيعToolStripMenuItem
            // 
            this.طرقالبيعToolStripMenuItem.Enabled = false;
            this.طرقالبيعToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources._base;
            this.طرقالبيعToolStripMenuItem.ImageTransparentColor = System.Drawing.SystemColors.Control;
            this.طرقالبيعToolStripMenuItem.Name = "طرقالبيعToolStripMenuItem";
            this.طرقالبيعToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.طرقالبيعToolStripMenuItem.Text = "طرق البيع";
            this.طرقالبيعToolStripMenuItem.Visible = false;
            this.طرقالبيعToolStripMenuItem.Click += new System.EventHandler(this.طرقالبيعToolStripMenuItem_Click);
            // 
            // اعداداتالنظامالبيعToolStripMenuItem
            // 
            this.اعداداتالنظامالبيعToolStripMenuItem.Enabled = false;
            this.اعداداتالنظامالبيعToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.setting;
            this.اعداداتالنظامالبيعToolStripMenuItem.Name = "اعداداتالنظامالبيعToolStripMenuItem";
            this.اعداداتالنظامالبيعToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.اعداداتالنظامالبيعToolStripMenuItem.Text = "اعدادات نظام البيع";
            this.اعداداتالنظامالبيعToolStripMenuItem.Visible = false;
            this.اعداداتالنظامالبيعToolStripMenuItem.Click += new System.EventHandler(this.اعداداتالنظامالبيعToolStripMenuItem_Click);
            // 
            // اعداداتنظامالايجارToolStripMenuItem
            // 
            this.اعداداتنظامالايجارToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.setting;
            this.اعداداتنظامالايجارToolStripMenuItem.Name = "اعداداتنظامالايجارToolStripMenuItem";
            this.اعداداتنظامالايجارToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.اعداداتنظامالايجارToolStripMenuItem.Text = "اعدادات العقارات المهملة";
            this.اعداداتنظامالايجارToolStripMenuItem.Click += new System.EventHandler(this.اعداداتنظامالايجارToolStripMenuItem_Click);
            // 
            // انواعالمهنToolStripMenuItem
            // 
            this.انواعالمهنToolStripMenuItem.Enabled = false;
            this.انواعالمهنToolStripMenuItem.Image = global::RealStateRentSystem.Properties.Resources.SES_D;
            this.انواعالمهنToolStripMenuItem.Name = "انواعالمهنToolStripMenuItem";
            this.انواعالمهنToolStripMenuItem.Size = new System.Drawing.Size(352, 34);
            this.انواعالمهنToolStripMenuItem.Text = "انواع المهن";
            this.انواعالمهنToolStripMenuItem.Visible = false;
            this.انواعالمهنToolStripMenuItem.Click += new System.EventHandler(this.انواعالمهنToolStripMenuItem_Click);
            // 
            // ادواتToolStripMenuItem
            // 
            this.ادواتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countToolStripMenuItem});
            this.ادواتToolStripMenuItem.Name = "ادواتToolStripMenuItem";
            this.ادواتToolStripMenuItem.Size = new System.Drawing.Size(73, 32);
            this.ادواتToolStripMenuItem.Text = "ادوات";
            // 
            // countToolStripMenuItem
            // 
            this.countToolStripMenuItem.Name = "countToolStripMenuItem";
            this.countToolStripMenuItem.Size = new System.Drawing.Size(162, 34);
            this.countToolStripMenuItem.Text = "Count";
            this.countToolStripMenuItem.Click += new System.EventHandler(this.countToolStripMenuItem_Click);
            // 
            // حولToolStripMenuItem
            // 
            this.حولToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.حولToolStripMenuItem1});
            this.حولToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.حولToolStripMenuItem.Name = "حولToolStripMenuItem";
            this.حولToolStripMenuItem.Size = new System.Drawing.Size(85, 32);
            this.حولToolStripMenuItem.Text = "مساعدة";
            // 
            // حولToolStripMenuItem1
            // 
            this.حولToolStripMenuItem1.Name = "حولToolStripMenuItem1";
            this.حولToolStripMenuItem1.Size = new System.Drawing.Size(140, 34);
            this.حولToolStripMenuItem1.Text = "حول";
            this.حولToolStripMenuItem1.Click += new System.EventHandler(this.حولToolStripMenuItem1_Click);
            // 
            // wayOfRentTableAdapter
            // 
            this.wayOfRentTableAdapter.ClearBeforeFill = true;
            // 
            // statusTypeTableAdapter
            // 
            this.statusTypeTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1272, 812);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 19);
            this.label2.TabIndex = 15;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 4);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 21);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "بحث عام";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(350, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(429, 2);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(116, 27);
            this.textBox2.TabIndex = 17;
            this.textBox2.Visible = false;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(723, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 30);
            this.button2.TabIndex = 19;
            this.button2.Text = "مكالمات واردة";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(500, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 13;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1894, 917);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "الهاتف";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1894, 917);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "المهن";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1894, 917);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "بيع";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1894, 914);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ايجار";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 36);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1902, 947);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 4;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1894, 917);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "مستودع";
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1894, 917);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "متابعة";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(750, 1);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(116, 27);
            this.textBox3.TabIndex = 17;
            // 
            // txtPhoneSearch
            // 
            this.txtPhoneSearch.Location = new System.Drawing.Point(0, 0);
            this.txtPhoneSearch.Name = "txtPhoneSearch";
            this.txtPhoneSearch.Size = new System.Drawing.Size(100, 27);
            this.txtPhoneSearch.TabIndex = 0;
            // 
            // Imagencrypt2
            // 
            this.Imagencrypt2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Imagencrypt2.Image = global::RealStateRentSystem.Properties.Resources.fieldnonpublic;
            this.Imagencrypt2.Location = new System.Drawing.Point(682, 5);
            this.Imagencrypt2.Margin = new System.Windows.Forms.Padding(4);
            this.Imagencrypt2.Name = "Imagencrypt2";
            this.Imagencrypt2.Size = new System.Drawing.Size(29, 21);
            this.Imagencrypt2.TabIndex = 0;
            this.Imagencrypt2.TabStop = false;
            this.Imagencrypt2.Visible = false;
            // 
            // Imagencrypt
            // 
            this.Imagencrypt.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Imagencrypt.Image = global::RealStateRentSystem.Properties.Resources.Keywords1;
            this.Imagencrypt.Location = new System.Drawing.Point(650, 5);
            this.Imagencrypt.Margin = new System.Windows.Forms.Padding(4);
            this.Imagencrypt.Name = "Imagencrypt";
            this.Imagencrypt.Size = new System.Drawing.Size(29, 21);
            this.Imagencrypt.TabIndex = 11;
            this.Imagencrypt.TabStop = false;
            this.Imagencrypt.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1902, 983);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Imagencrypt2);
            this.Controls.Add(this.Imagencrypt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "برنامج طموحات العقارية";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Imagencrypt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagencrypt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        /////
        private System.Windows.Forms.TextBox txtPhoneSearch;

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem الاعدادتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تعريفالمستخدمينToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem مفاتيحإختصارToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem مناطقToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اعداداتالنظامToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem العقاراتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem العقاراتToolStripMenuItem1;
        private System.Windows.Forms.Timer main_timer;
        private System.Windows.Forms.ToolStripMenuItem الأرشيفToolStripMenuItem;
        private DSTables.DSrealstateTableAdapters.WayOfRentTableAdapter wayOfRentTableAdapter;
        private DSTables.DSrealstateTableAdapters.StatusTypeTableAdapter statusTypeTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem administratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حولToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem حولToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem النماذجالمرفقهToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem الاحصائياتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem طرقالبيعToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem اعداداتالنظامالبيعToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem الهاتفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem المهنToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem انواعالمهنToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem الاحصائياتToolStripMenuItem1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripMenuItem ادواتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.PictureBox Imagencrypt;
        public System.Windows.Forms.PictureBox Imagencrypt2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem التنبيهاتToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        public  System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ToolStripMenuItem اعداداتنظامالايجارToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolStripMenuItem APItoolStripMenuItem;
    }
}



