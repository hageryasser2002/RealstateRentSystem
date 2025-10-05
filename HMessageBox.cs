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
    public partial class HMessageBox : Form
    {

        static HMessageBox newMessageBox;
        public static string Button_Clicked;
        public static Boolean actived = false;
        public static int current_id;
        public static int counternow;


        public HMessageBox()
        {
            InitializeComponent();
            groupBox1.BringToFront();
            groupBox1.BackColor = Color.White;
            Bg_Panel.BackColor = Color.FromArgb(220,80, 80, 80);
            groupBox1.Location = new Point(this.Location.X+3, this.Location.Y + 3);
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {

                if (keyData == Keys.Escape)
                {
                    actived = false;
                    Button_Clicked = "Cancel";
                    newMessageBox.Dispose();

                }


            }

            if ((keyData & Keys.Alt) == Keys.Alt)
                return true;
            else
                return base.ProcessDialogKey(keyData);

        }
        public string ShowBox(Form owner, int id, int counter)
        {
            actived = true;
            current_id = id;
            counternow = counter;   
            newMessageBox = new HMessageBox();
            // newMessageBox.lblTitle.Text = txtTitle;

            // ✅ ضمان الظهور في الأعلى
           // newMessageBox.TopMost = true;
            newMessageBox.BringToFront();
            newMessageBox.Activate();

            if (owner.InvokeRequired)
            {
                owner.Invoke((MethodInvoker)(() =>
                {
                    newMessageBox.ShowDialog(owner);
                }));
            }
            else
            {
                newMessageBox.ShowDialog(owner);
            }
            return Button_Clicked;
        }

        private void HMessageBox_Load(object sender, EventArgs e)
        {

            label5.Text += " " + counternow.ToString();
            DataTable dt = new DataTable();
            dt = this.realStateTableAdapter.GetAll(current_id);
            DSTables.DSregionTableAdapters.RegionTableAdapter RegionTableAdapter = new DSTables.DSregionTableAdapters.RegionTableAdapter();
            DSTables.DSregionTableAdapters.SubRegionsTableAdapter SubRegionTableAdapter = new DSTables.DSregionTableAdapters.SubRegionsTableAdapter();

            if (dt.Rows.Count > 0)
            {
                
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    DataTable dt1 = new DataTable();
                    
                    dt1 = RegionTableAdapter.GetName(Convert.ToInt32(dt.Rows[r]["Region_ID"].ToString()));
                    region_IDTextBox.Text = dt1.Rows[0]["Name"].ToString();
                    subResgionIDTextBox.Text = dt.Rows[r]["SubResgionID"].ToString();
                    buildingTextBox.Text = dt.Rows[r]["Building"].ToString();
                    ownerTextBox.Text = dt.Rows[r]["Owner"].ToString();
                    days.Text = dt.Rows[r]["RemainingDay"].ToString();
//                    month.Text = dt.Rows[r]["Period"].ToString();
        
                }

            }
         }

        private void HMessageBox_Paint(object sender, PaintEventArgs e)
        {
        //    Graphics mGraphics = e.Graphics;
        //    Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

        //    Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        //    LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
        //    mGraphics.FillRectangle(LGB, Area1);
        //    mGraphics.DrawRectangle(pen1, Area1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            Button_Clicked = "Agnoring";
            newMessageBox.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            actived = false;
            Button_Clicked = "Cancel";
            newMessageBox.Close();
 
        }
        private DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter RealStateTableAdaptersearch = new DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter();
        //private  void view_Click(object sender, EventArgs e)
        //{

        //    Realstate u = new Realstate();
        //    u.MdiParent = this.MdiParent;
        //    u.recored_id = current_id;


        //    this.RealStateTableAdaptersearch.UpdateQuery(DateTime.Now.Date, current_id);
        //    //this.dSrealstate.RealState.AcceptChanges();
        //    //this.dSrealstate.RealState.EndInit();

        //    u.am = "View";
        //    u.SnewMessageBox =newMessageBox;
        //    AlarmSound.main_timer.Stop();
        //    AlarmSound.player.Stop();
        //    u.Show();
        //    Button_Clicked = "Agnoring";
        //}
        private Realstate u = null;

        private void view_Click(object sender, EventArgs e)
        {
            if (u == null || u.IsDisposed)
            {
                u = new Realstate();
                u.MdiParent = this.MdiParent;
                u.recored_id = current_id;
                u.am = "View";
                u.SnewMessageBox = newMessageBox;
                u.Show();
            }
            else
            {
                u.BringToFront();
            }

            this.RealStateTableAdaptersearch.UpdateQuery(DateTime.Now.Date, current_id);
            AlarmSound.main_timer.Stop();
            AlarmSound.player.Stop();
            Button_Clicked = "Agnoring";
        }

        private void Renew_Click(object sender, EventArgs e)
        {
            Realstate u = new Realstate();
            u.MdiParent = this.MdiParent;
            u.recored_id = current_id;
            u.am = "Renew";
            u.Show();
            Button_Clicked = "Renew";

        }

        private void Empty_Click(object sender, EventArgs e)
        {
            this.realStateTableAdapter.UpdateQuery(2, current_id);
            Button_Clicked = "Empty";
                 }

     

    }
}