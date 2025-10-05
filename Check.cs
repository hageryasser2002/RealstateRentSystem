using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    public partial class Check : Form
    {
        public static DSTables.DSrealstatesearch.RealStateDataTable dt;
        public static DSTables.DSrealsearchown.RealstateOwneDataTable dtown;

        static Check newMessageBox;
        public static string who;
        
        public static string Button_Clicked;
        public Check()
        {
            InitializeComponent();
           
        }
        public static string ShowMe(DSTables.DSrealstatesearch.RealStateDataTable pdt)
         {
             newMessageBox = new Check();
             dt = pdt;
             if (pdt.Rows.Count > 0)
             {

                 if (Convert.ToInt32(pdt.Rows[0]["active"].ToString()) == 0)
                 {
                     Whatype.Visible = true;
                 }
                 else
                 {
                     Whatype.Visible = false;
                 }
             }
            newMessageBox.ShowDialog();
            //ShowModalExcept(newMessageBox, MainForm.searchForm);

            return Button_Clicked;
        }

        public static string ShowMeOWN(DSTables.DSrealsearchown.RealstateOwneDataTable pdto)
        {
            newMessageBox = new Check();
            dtown = pdto;
            if (pdto.Rows.Count > 0)
            {

                if (Convert.ToInt32(pdto.Rows[0]["active"].ToString()) == 0)
                {
                    Whatype.Visible = true;
                }
                else
                {
                    Whatype.Visible = false;
                }
            }
            newMessageBox.ShowDialog();
            //ShowModalExcept(newMessageBox, MainForm.searchForm);

            return Button_Clicked;
        }
        private void Login_Click(object sender, EventArgs e)
        {
            if (who == "rent")
            {
                Appointsearch sp = new Appointsearch(dt);
                sp.ShowDialog();
                //ShowModalExcept(sp, MainForm.searchForm);

            }
            if (who == "own")
            {
                OWNSearchParameter sp = new OWNSearchParameter(dtown);
                sp.ShowDialog();
                //ShowModalExcept(sp, MainForm.searchForm);

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



        private void Cancel_Click(object sender, EventArgs e)
        {
             Button_Clicked="kml";
             Whatype.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button_Clicked = "cancel";
            Whatype.Visible = false;
        }
    }
}
