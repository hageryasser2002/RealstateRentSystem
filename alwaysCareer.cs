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
    public partial class alwaysCareer : Form
    {
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
        private System.Windows.Forms.ToolTip m_wndToolTip;
        private bool isLoaded = false;

        public alwaysCareer()
        {
            InitializeComponent();

            Careertype.Focus();
            groupBox2.BackColor = Color.FromArgb(250, 163, 7);

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
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                if (textBox1.Text != "")
                {
                    DoQuery(" SELECT career.ID, career.name, career.careertype," +
                    " career.p, career.m," +
                    " career.other, " +
                    " career.notes, career.category " +
                    " FROM ( career LEFT JOIN" +
                    " careerEvent careerEvent ON career.ID = careerEvent.careerID )" +
                     whereClouse() + "");

                }
                else
                {

                    DoQuery(" SELECT career.ID, career.name, career.careertype," +
                    " career.p, career.m," +
                    " career.other, " +
                    " career.notes, career.category " +
                    " FROM  career " +
                     whereClouse() + "");

                }
            }
            else
            {
                if (textBox1.Text != "")
                {

                    DoQuery(" SELECT career.ID, career.name, career.careertype," +
                             " career.p, career.m," +
                             " career.other, " +
                             " career.notes, career.category " +
                             " FROM ( career LEFT JOIN" +
                             " careerEvent careerEvent ON career.ID = careerEvent.careerID )" +
                              whereClouseexact() + "");

                }
                else
                {
                    DoQuery(" SELECT career.ID, career.name, career.careertype," +
                    " career.p, career.m," +
                    " career.other, " +
                    " career.notes, career.category " +
                    " FROM  career " +
                     whereClouseexact() + "");

                }


            }


        }
        public string whereClouseexact()
        {
            //Utils.getsetting();
            string prametrs = " where ";
            string buildingtype = "";


            if (Careertype.SelectedValue != null)
            {
                prametrs += " career.careertype= '" + Careertype.Text + "'";
                prametrs += " and ";
            }




            if (personname.Text != "")
            {
                prametrs += " career.name = '" + personname.Text.Trim() + "' ";

                prametrs += " and ";
            }



            if (careerCatog.SelectedItem != null)
            {
                buildingtype = careerCatog.SelectedItem.ToString();
                if (buildingtype == "وسط")
                {
                    prametrs += " career.category= 'وسط' ";
                }
                if (buildingtype == "جيد")
                {
                    prametrs += " career.category= 'جيد' ";
                }
                if (buildingtype == "ممتاز")
                {
                    prametrs += " career.category= 'ممتاز' ";
                }
                prametrs += " and ";

            }

            if (p1.Text != "")
            {
                prametrs += " ( ";
                prametrs += " career.p = '" + p1.Text.Trim() + "'";
                prametrs += " or ";
                prametrs += " career.m = '" + p1.Text.Trim() + "'";
                prametrs += " or ";
                prametrs += " career.other = '" + p1.Text.Trim() + "'";
                prametrs += " ) ";
                prametrs += " and ";
            }

            if (textBox1.Text != "")
            {
                prametrs += " careerEvent.Event = '" + textBox1.Text + "'";
                prametrs += " and ";

            }

            if (prametrs != " where ")
                return prametrs.Substring(0, prametrs.LastIndexOf("and"));
            else
                return "";
        }

        public string whereClouse()
        {
            //Utils.getsetting();
            string prametrs = " where ";

            string buildingtype = "";


            if (Careertype.SelectedValue != null)
            {
                prametrs += " career.careertype= '" + Careertype.Text + "'";
                prametrs += " and ";
            }





            if (personname.Text != "")
            {
                prametrs += "( career.name like '%" + personname.Text.Trim() + "%' or ";

                string trimed = personname.Text.Trim();
                string Hmza = personname.Text.Trim().Replace("أ", "ا");
                prametrs += " career.name like '%" + Hmza + "%' or ";
                trimed = Hmza.Trim().Replace("ه", "ة");
                prametrs += " career.name like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ة", "ه");
                prametrs += " career.name like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ي", "ى");
                prametrs += " career.name like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ى", "ي");
                prametrs += " career.name like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ا", "ه");
                prametrs += " career.name like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ه", "ا");
                prametrs += " career.name like '%" + trimed + "%' or ";


                string Alftriemd = personname.Text.Trim().Replace("ا", "أ");
                prametrs += " career.name like '%" + Alftriemd + "%' or ";
                trimed = Alftriemd.Trim().Replace("ه", "ة");
                prametrs += " career.name like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ة", "ه");
                prametrs += " career.name like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ي", "ى");
                prametrs += " career.name like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ى", "ي");
                prametrs += " career.name like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ا", "ه");
                prametrs += " career.name like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ه", "ا");
                prametrs += " career.name like '%" + trimed + "%' )  ";
                prametrs += " and ";

            }



            if (careerCatog.SelectedItem != null)
            {
                buildingtype = careerCatog.SelectedItem.ToString();
                if (buildingtype == "وسط")
                {
                    prametrs += " career.category= 'وسط' ";
                }
                if (buildingtype == "جيد")
                {
                    prametrs += " career.category= 'جيد' ";
                }
                if (buildingtype == "ممتاز")
                {
                    prametrs += " career.category= 'ممتاز' ";
                }
                prametrs += " and ";

            }

            if (p1.Text != "")
            {
                prametrs += " ( ";
                prametrs += " career.p like '%" + p1.Text.Trim() + "%'";
                prametrs += " or ";
                prametrs += " career.m like '%" + p1.Text.Trim() + "%'";
                prametrs += " or ";
                prametrs += " career.other like '%" + p1.Text.Trim() + "%'";
                prametrs += " ) ";
                prametrs += " and ";
            }

            if (textBox1.Text != "")
            {
                prametrs += " careerEvent.Event like '%" + textBox1.Text + "%'";
                prametrs += " and ";

            }

            if (prametrs != " where ")
                return prametrs.Substring(0, prametrs.LastIndexOf("and"));
            else
                return "";
        }

        void DoQuery(string clouse)
        {

            CareerSearchParameter sp = new CareerSearchParameter(clouse);
            //   eventtext.Text = "";
            if (sp.y == 1)
                sp.ShowDialog();
            //ShowModalExcept(sp, MainForm.searchForm);
            else if (sp.y != 2)
                MessageBox.Show("لا توجد معلومات");
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


        private void always_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dScareer.careerCatog' table. You can move, or remove it, as needed.
            //this.careerCatogTableAdapter.Fill(this.dScareer.careerCatog);
            //// TODO: This line of code loads data into the 'dScareer.TypeOfcarrer' table. You can move, or remove it, as needed.
            //this.typeOfcarrerTableAdapter.Fill(this.dScareer.TypeOfcarrer);
            if (!isLoaded)
            {
                this.careerCatogTableAdapter.Fill(this.dScareer.careerCatog);
                this.typeOfcarrerTableAdapter.Fill(this.dScareer.TypeOfcarrer);
                isLoaded = true;
            }
            this.m_wndToolTip = new System.Windows.Forms.ToolTip(this.components);
            m_wndToolTip.ShowAlways = true;

            Careertype.Text = null;
            Careertype.Focus();

            ///
            RefreshUserUI();

        }
        private void buildingTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string[] keys = e.KeyData.ToString().Split(',');
            if (keys.Length == 2)
            {
                DataTable t = new DataTable();
                t = shorCutKeysTableAdapter.GetDataBy(keys[1].Trim().ToString(), keys[0].Trim().ToString());
                if (t.Rows.Count > 0)
                {
                    if ((keys[1].Trim().ToString() == "Control") && (keys[0].Trim().ToString() == "Z"))
                    {
                        this.ActiveControl.Text = "";
                        this.ActiveControl.Text = t.Rows[0]["Text"].ToString();
                        ((TextBox)this.ActiveControl).SelectionStart = this.ActiveControl.Text.Length + 1;
                    }
                    else
                    {
                        this.ActiveControl.Text += t.Rows[0]["Text"].ToString();
                        ((TextBox)this.ActiveControl).SelectionStart = this.ActiveControl.Text.Length + 1;
                    }
                }

            }


        }

        private void entranceTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == MouseButtons.Middle.ToString())
            {
                DataTable dt = new DataTable();
                dt = this.shorCutKeysTableAdapter.GetData();
                string al = "";
                if (dt.Rows.Count > 0)
                {
                    for (int h = 0; h < dt.Rows.Count; h++)
                    {

                        al += dt.Rows[h]["Key_Two"] + " + " + dt.Rows[h]["Key_One"] + " = " + dt.Rows[h]["Text"] + "\n";
                    }

                }

                m_wndToolTip.SetToolTip(this.ActiveControl, al);
            }
        }

        private void p1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow numbers and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

        }

        private void always_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //13 = enter
            {

                button1.PerformClick();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Careertype.Text = null;
            textBox1.Text = "";
            personname.Text = "";
            careerCatog.Text = null;
            p1.Text = "";
            checkBox2.Checked = false;


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
