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
    public partial class Redail : Form
    {
        static Redail newMessageBox;
        public static string Button_Clicked;

        public Redail()
        {
            InitializeComponent();
        }


        public static void ShowMe()
        {
           newMessageBox = new Redail();

           timer1.Start();
           timer2.Start();
           label3.Text = DateTime.Now.ToLongTimeString();
           newMessageBox.ShowDialog();
            
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Utils.mode.CancelCall();
            newMessageBox.Dispose();
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
        //    this.label3.Text = DateTime.Now.ToLongTimeString();    
        }

        private static void timer1_Tick(object sender, EventArgs e)
        {
            Utils.mode.CancelCall();
            newMessageBox.Dispose();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        

       


    }
}
