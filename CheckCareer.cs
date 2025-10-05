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
    public partial class CheckCareer : Form
    {
        public static DScareersearch.careerDataTable dt;


        static CheckCareer newMessageBox;
        
        
        public static string Button_Clicked;
        public CheckCareer()
        {
            InitializeComponent();
           
        }
        public static string ShowMe(DScareersearch.careerDataTable pdt)
         {
             newMessageBox = new CheckCareer();
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



            CareerSearchParameter sp = new CareerSearchParameter(dt);
            sp.ShowDialog();
            //ShowModalExcept(newMessageBox, MainForm.searchForm);



        }

        private void Cancel_Click(object sender, EventArgs e)
        {
             Button_Clicked="kml";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button_Clicked = "cancel";
        }
    }
}
