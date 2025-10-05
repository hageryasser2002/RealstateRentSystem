using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace RealStateRentSystem
{
    class CallArchive
    {


        private static System.Windows.Forms.Timer main_timer;

        public static void startbackup()
        {
            main_timer = new System.Windows.Forms.Timer();
            main_timer.Interval = 1000;
            main_timer.Start();
            main_timer.Tick += new EventHandler(RunAlarm);
        }
        private static void RunAlarm(object sender, EventArgs eArgs)
        {
            doBackup();
        }
        private static void doBackup()
        {
            DateTime someStart = DateTime.Now;
            // Utils.getsetting();

            if ((someStart.Hour == Utils.CallsBackArchiveone.Hour) &&
            (someStart.Minute == Utils.CallsBackArchiveone.Minute) &&
            (someStart.Second == Utils.CallsBackArchiveone.Second))
            {
                Utils.update_auto();
                Utils.update_auto_calls();

            }
            else if ((someStart.Hour == Utils.CallsBackArchivetwo.Hour)
            && (someStart.Minute == Utils.CallsBackArchivetwo.Minute)
            && (someStart.Second == Utils.CallsBackArchivetwo.Second))
            {
                Utils.update_auto_calls();
                Utils.update_auto();
            }


        }


        public static string DateDiff(DateTime startDate, DateTime endDate)
        {
            string timeStr = string.Empty;
            int yr = 0;
            int mth = 0;
            int days = 0;

            TimeSpan ts = new TimeSpan();
            ts = endDate.Subtract(startDate);
            yr = (ts.Days / 365);

            do
            {
                for (int i = 0; i <= 12; i++)
                {
                    if (endDate.Subtract(startDate.AddYears(yr).AddMonths(i)).Days > 0)
                    {
                        mth = i;
                    }
                    else
                    {
                        break;
                    }
                }

                if (mth > 12)
                    yr = yr + 1;
            } while (mth > 12);

            days = endDate.Subtract(startDate.AddYears(yr).AddMonths(mth)).Days;

            if (yr >= 0)
                timeStr += yr.ToString() + "-";
            if (mth >= 0)
                timeStr += mth.ToString() + "-";
            if (days >= 0)
                timeStr += days.ToString();

            DateTime all = DateTime.Now.AddYears(yr).AddMonths(mth).AddDays(endDate.Day - 10);

            return (all.Day.ToString() + "-" + all.Month.ToString() + "-" + all.Year.ToString());
        }
       




    }




}
