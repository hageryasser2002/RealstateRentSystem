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
    public partial class StaticMessageBox : Form
    {

        static StaticMessageBox newMessageBox;
        public static string Button_Clicked;
        public static Boolean actived = false;
        public static int current_id;
        public static int counternow;
        private DSTables.DSsettingTableAdapters.StaticTableAdapter StaticTableAdapter = new DSTables.DSsettingTableAdapters.StaticTableAdapter();

        public StaticMessageBox()
        {
            InitializeComponent();
        }


        public string ShowBox()
        {
            actived = true;
            newMessageBox = new StaticMessageBox();
           // newMessageBox.lblTitle.Text = txtTitle;
            newMessageBox.ShowDialog();
         
            return Button_Clicked;
        }

        private void HMessageBox_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = StaticTableAdapter.GetData();

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

            StaticMessageBox.actived = false;
            StaticAlarmSound.main_timer.Stop();
            StaticAlarmSound.player.Stop();

            newMessageBox.Dispose();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button_Clicked = "Cancel";
            this.StaticTableAdapter.UpdateQueryAccess(DateTime.Now.Date);
            StaticMessageBox.actived = false;
            StaticAlarmSound.main_timer.Stop();
            StaticAlarmSound.player.Stop();

            Statics re = new Statics();
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
                    StaticMessageBox.actived = false;
                    StaticAlarmSound.main_timer.Stop();
                    StaticAlarmSound.player.Stop();
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