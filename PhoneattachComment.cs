using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
namespace RealStateRentSystem
{
    public partial class PhoneattachComment : Form
    {
        static PhoneattachComment newMessageBox;
        public static string Button_Clicked;

        public PhoneattachComment()
        {
            InitializeComponent();
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

        public static void ShowMe()
        {
            newMessageBox = new PhoneattachComment();
            newMessageBox.ShowDialog();
            //ShowModalExcept(newMessageBox, MainForm.searchForm);


        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (name.Text!="")
            {
                Button_Clicked = name.Text;
                newMessageBox.Dispose();
            }
            else
            {
                Button_Clicked = "";
                MessageBox.Show("الرجاء ادخال النص");
                newMessageBox.Focus();

            }
        }

   
        private void LoginMsg_Paint(object sender, PaintEventArgs e)
        {
            //Graphics mGraphics = e.Graphics;
            //Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

            //Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            //LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            //mGraphics.FillRectangle(LGB, Area1);
            //mGraphics.DrawRectangle(pen1, Area1);
        }
        private void LoginMsg_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button_Clicked = "";
            newMessageBox.Dispose();
        }


    }
}
