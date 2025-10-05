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
    public partial class RealStaticMessageBox : Form
    {

        static RealStaticMessageBox newMessageBox;
        public static string Button_Clicked;
        public static Boolean actived = false;
        public static int current_id;
        public static int counternow;
        private DSTables.DSsettingTableAdapters.RealStaticTableAdapter RealStaticTableAdapter = new DSTables.DSsettingTableAdapters.RealStaticTableAdapter();

        public RealStaticMessageBox()
        {
            InitializeComponent();
        }


        public string ShowBox()
        {
            actived = true;
            newMessageBox = new RealStaticMessageBox();
           // newMessageBox.lblTitle.Text = txtTitle;
            newMessageBox.ShowDialog();
         
            return Button_Clicked;
        }

        private void HMessageBox_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = RealStaticTableAdapter.GetData();

            if (dt.Rows.Count > 0)
            {
                int days = GetDates.DateDiffDays(Convert.ToDateTime(dt.Rows[0]["AccessDate"].ToString()).Date, DateTime.Now.Date);
                label2.Text = days.ToString();
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            actived = false;
            Button_Clicked = "Cancel";

            RealStaticMessageBox.actived = false;
            RealStaticAlarmSound.main_timer.Stop();
            RealStaticAlarmSound.player.Stop();

            newMessageBox.Dispose();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button_Clicked = "Cancel";
            this.RealStaticTableAdapter.UpdateQuery(DateTime.Now.Date);
            RealStaticMessageBox.actived = false;
            RealStaticAlarmSound.main_timer.Stop();
            RealStaticAlarmSound.player.Stop();

            RealStatics re = new RealStatics();
            actived = false;
            newMessageBox.Dispose();

            re.ShowDialog();

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
                    RealStaticMessageBox.actived = false;
                    RealStaticAlarmSound.main_timer.Stop();
                    RealStaticAlarmSound.player.Stop();
                   newMessageBox.Dispose();
 

                }


            }

            if ((keyData & Keys.Alt) == Keys.Alt)
                return true;
            else
                return base.ProcessDialogKey(keyData);

        }
     

    }
}