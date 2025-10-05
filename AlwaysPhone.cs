using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class AlwaysPhone : Form
    {
        public static string numberold;



        public AlwaysPhone()
        {
            InitializeComponent();
            user.Text += " " + Utils.current_user;
           
            numberold = numbers.Text;
            name.Focus();

            ///
            CenterControlsHorizontally();
            this.Resize += new EventHandler(Form1_Resize);

        }

        /// <summary>
        /// Added Method To Centralize Components of Form
        /// </summary>
        private void CenterControlsHorizontally()
        {
            foreach (Control ctrl in this.Controls)
            {
                int formWidth = this.ClientSize.Width;
                ctrl.Left = (formWidth - ctrl.Width) / 2;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterControlsHorizontally();
        }

        private void always_Load(object sender, EventArgs e)
        {
            RefreshUserUI();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {

                if (keyData == Keys.F12)
                {
                    button2.PerformClick();

                }

                if (keyData == Keys.Enter)
                {
                    button1.PerformClick();

                }

                if (keyData == Keys.F11)
                {
                    Utils.EncryptMode = !Utils.EncryptMode;

                    //if (Utils.EncryptMode)
                    //{

                    //    MainForm.Imagencrypt.Visible = true;
                    //    MainForm.Imagencrypt2.Visible = true;
                    //}
                    //if (!Utils.EncryptMode)
                    //{
                    //    MainForm.Imagencrypt.Visible = false;
                    //    MainForm.Imagencrypt2.Visible = false;
                    //}
                    return true;

                }

                if (keyData == Keys.F3)
                {
                    numberold = numberold.Replace("*", "");
                    star();

                }



                if (keyData == Keys.F1)
                {

                    button2.PerformClick();
                    numbers.Focus();
                }


                if (((keyData & Keys.Shift) == Keys.Shift) && ((keyData & Keys.F10) == Keys.F10))
                {
                    return true;
                }

                if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.F10) == Keys.F10))
                {
                    return true;
                }



                if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.PageDown) == Keys.PageDown))
                {
                    return true;
                }
                if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.PageUp) == Keys.PageUp))
                {
                    return true;
                }

            }
            return false;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            name.Text = null;
            numbers.Text = "";
            textBox1.Text = "";
            checkBox2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numberold = numbers.Text.Replace("*", "");
            if (checkBox2.Checked == false)
            {

                Form1 f = new Form1(name.Text, numbers.Text, textBox1.Text, "0");
                if (f.yes)
                {
                    f.ShowDialog();
                    //ShowModalExcept(f, MainForm.searchForm);
                }
                if (f.alwaysback == "back")
                {
                    button2.PerformClick();
                    numbers.Focus();
                }

            }
            else
            {
                Form1 f = new Form1(name.Text, numbers.Text, textBox1.Text, "1");
                if (f.yes)
                {
                    f.ShowDialog();
                    //ShowModalExcept(f, MainForm.searchForm);
                }
                if (f.alwaysback == "back")
                {
                    button2.PerformClick();
                    numbers.Focus();
                }

            }


        }

        /// <summary>
        /// Search TextBox
        /// </summary>
        /// 
        public static void ShowModalExcept(Form modalForm, Form exceptionForm)
        {
            // إيقاف كل الفورمز ما عدا فورم البحث
            foreach (Form f in Application.OpenForms)
            {
                if (f != modalForm && f != exceptionForm)
                {
                    f.Enabled = false;
                }
            }

            // لما الفورم تتقفل، نرجّع كل حاجة
            modalForm.FormClosed += (s, e) =>
            {
                foreach (Form f in Application.OpenForms)
                {
                    f.Enabled = true;
                }
            };

            modalForm.Show();
        }


        private void star()
        {

            numbers.Text = numberold;
            if (checkBox2.Checked == false)
            {
                Form1 f = new Form1(name.Text, numberold, textBox1.Text, "0");

                if (f.yes)
                {
                    f.ShowDialog();
                    //ShowModalExcept(f, MainForm.searchForm);

                }
                if (f.alwaysback == "back")
                {
                    button2.PerformClick();
                    numbers.Focus();
                }

            }
            else
            {

                Form1 f = new Form1(name.Text, numberold, textBox1.Text, "1");
                if (f.yes)
                {
                    f.ShowDialog();
                    //ShowModalExcept(f, MainForm.searchForm);

                }
                if (f.alwaysback == "back")
                {
                    button2.PerformClick();
                    numbers.Focus();
                }

            }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Added Code
        /// </summary>
        private void SetUserColorFromCache()
        {
            try
            {
                var user = Utils.cachedUsers.FirstOrDefault(u => u.UserName == Utils.current_user);

                if (user != null)
                {
                    panel1.BackColor = ColorTranslator.FromHtml(user.Color); // أو PanelUserColo على حسب اسم العنصر
                }
                else
                {
                    panel1.BackColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل اللون من الكاش: " + ex.Message);
                panel1.BackColor = Color.Gray;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // نعرض نفس فورم تسجيل الدخول الحالية
            //LoginMsg loginMsg = new LoginMsg();

            //// نوقف تنفيذ الكود لحين ما المستخدم يختار اسم ويدوس "دخول"
            //if (loginMsg.ShowDialog() == DialogResult.OK)
            //{
            if (LoginMsg.ShowMe() == "ok")
            {
                // تحديث اسم المستخدم الجديد من فورم تسجيل الدخول
                string newUsername = Utils.current_user; // من المفترض أن LoginForm يكتب الاسم في Utils.current_user

                // تحديث الاسم في الفورم الرئيسية
                this.user.Text = "مرحبًا " + newUsername;

                // إعادة تحميل الصلاحيات (لو مرتبطة بالمستخدم)
                //MainForm main = new MainForm();
                if (MainForm.Instance != null)
                {
                    MainForm.Instance.ReloadUserPermissions();
                    MainForm.Instance.RefreshAllTabs();
                }
            }

        }
        public void RefreshUserUI()
        {
            user.Text = "مرحبًا " + Utils.current_user;
            SetUserColorFromCache();
        }
   
    }
}

