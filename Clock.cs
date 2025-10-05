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
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(drawclock);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
        }
        private void drawclock(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(20, 20, 250, 250);
            LinearGradientBrush linearbrush = new LinearGradientBrush(rec, Color.Yellow, Color.Red, 225);
            g.FillEllipse(linearbrush, 20, 20, 200, 200);
            linearbrush.LinearColors = new Color[] { Color.Yellow, Color.Red, };
            g.FillEllipse(linearbrush, 30, 30, 180, 180);
            linearbrush.LinearColors = new Color[] { Color.Red, Color.Yellow };
            g.FillEllipse(linearbrush, 33, 33, 174, 174);

            SolidBrush solidbrush = new SolidBrush(Color.White);
            Font textFont = new Font("Arial Bold", 12F, FontStyle.Bold);
            g.DrawString("12", textFont, solidbrush, 109, 40);
            g.DrawString("11", textFont, solidbrush, 75, 50);
            g.DrawString("10", textFont, solidbrush, 47, 75);
            g.DrawString("9", textFont, solidbrush, 43, 110);
            g.DrawString("8", textFont, solidbrush, 52, 145);
            g.DrawString("7", textFont, solidbrush, 75, 170);
            g.DrawString("6", textFont, solidbrush, 113, 180);
            g.DrawString("5", textFont, solidbrush, 150, 170);
            g.DrawString("4", textFont, solidbrush, 173, 145);
            g.DrawString("3", textFont, solidbrush, 182, 110);
            g.DrawString("2", textFont, solidbrush, 173, 75);
            g.DrawString("1", textFont, solidbrush, 150, 50);

            g.TranslateTransform(120, 120, MatrixOrder.Append);
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;
            // Create Pens
            Pen hourPen = new Pen(Color.White, 2);
            Pen minutePen = new Pen(Color.LightGray, 2);
            Pen secondPen = new Pen(Color.Green, 2);

            // Create angles
            double secondAngle = 2.0 * Math.PI * sec / 60.0;
            double minuteAngle = 2.0 * Math.PI * (min + sec / 60.0) / 60.0;
            double hourAngle = 2.0 * Math.PI * (hour + min / 60.0) / 12.0;

            // Set centre point
            Point centre = new Point(0, 0);

            // Draw Hour Hand
            Point hourHand = new Point((int)(40 * Math.Sin(hourAngle)),
                                        (int)(-40 * Math.Cos(hourAngle)));
            g.DrawLine(hourPen, centre, hourHand);

            // Draw Minute Hand
            Point minHand = new Point((int)(70 * Math.Sin(minuteAngle)),
                                       (int)(-70 * Math.Cos(minuteAngle)));
            g.DrawLine(minutePen, centre, minHand);

            // Draw Second Hand
            Point secHand = new Point((int)(70 * Math.Sin(secondAngle)),
                                       (int)(-70 * Math.Cos(secondAngle)));
            g.DrawLine(secondPen, centre, secHand);
            Invalidate();


        }
    }
}