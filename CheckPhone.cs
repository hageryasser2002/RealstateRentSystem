using RealStateRentSystem.DSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class CheckPhone : Form
    {
        public static DSphoneSearch.PhoneDataTable dt;
        

        static CheckPhone newMessageBox;
        public static string iam;
        
        
        public static string Button_Clicked;
        public CheckPhone()
        {
            InitializeComponent();
           
        }
        public static string ShowMe(DSphoneSearch.PhoneDataTable pdt)
         {
             newMessageBox = new CheckPhone();
             dt = pdt;
            newMessageBox.ShowDialog();
            //ShowModalExcept(newMessageBox, MainForm.searchForm);

            return Button_Clicked;
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



        private void Login_Click(object sender, EventArgs e)
        {
            phonesearch sp = new phonesearch(dt);
            sp.ShowDialog();
            //ShowModalExcept(sp, MainForm.searchForm);


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
             Button_Clicked="kml";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button_Clicked = "cancel";
        }

        private void CheckPhone_Load(object sender, EventArgs e)
        {

            if (iam == "phapp")
                button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            iam = "";
            Button_Clicked = "Exist";
            this.Close();
        }
    }
}
