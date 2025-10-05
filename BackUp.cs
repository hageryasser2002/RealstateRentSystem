using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;


namespace RealStateRentSystem
{
    class BackUp
    {
        private static System.Windows.Forms.Timer main_timer;
        //private static bool GetFileExisting(string filename)
        //{

        //    if (Directory.Exists(filename))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

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
            TimeSpan current = DateTime.Now.TimeOfDay;
            TimeSpan target = Utils.BackUpTime.TimeOfDay;

            if (Math.Abs((current - target).TotalSeconds) <= 5)
            {
                string filespath = Utils.BackUpPath;
                try
                {
                    if (Utils.BackUpPath != "" && Utils.BackUpPath != null)
                    {
                        string FileName = "Back up " + DateTime.Now.ToString("yyyy-MM-dd");
                        if (Directory.Exists(filespath))
                        {
                            if (!Directory.Exists(Path.Combine(filespath, FileName))) {

                                Utils.update_auto();

                                // Backup Db
                                string Fullpath = Path.Combine(filespath, FileName, "Db");
                                Directory.CreateDirectory(Fullpath);
                                string GetDbName = CustomPath.GetDBName();
                                string GetDBFullPath = CustomPath.GetDBFullPath();
                                Fullpath = Path.Combine(Fullpath, GetDbName);
                                File.Copy(GetDBFullPath, Fullpath);

                                // Backup Attachment
                                Fullpath = Path.Combine(filespath, FileName,"Attachment");
                                CopyWithBackgroundWorker copyWithBackgroundWorker =
                                    new CopyWithBackgroundWorker(Utils.DataFolderPath, Fullpath);
                                copyWithBackgroundWorker.ShowDialog();
                                //ShowModalExcept(copyWithBackgroundWorker, MainForm.searchForm);


                                checkDelete();
                               // copyDirectory(Utils.DataFolderPath, Fullpath);
                               // MessageBox.Show(FileName.ToString() + " النسخة الاحتياطية تمت بنجاح ");
                            }
                 
                        }
                        else
                            MessageBox.Show($"{filespath}\r\n مسار النسخة الاحتياطية غير صحيح");
                    }
                    else
                        MessageBox.Show("الرجاء تحديد مسار النسخة الاحتياطية");
                }
                catch
                {
                    MessageBox.Show(" هناك خطأ قد حدث لم يتم تفعيل النسخ الاحتياطي!");
                }

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



        public static void copyDirectory(string Src, string Dst)
        {
            if (!Directory.Exists(Dst))
                Directory.CreateDirectory(Dst);

            foreach (string element in Directory.GetFileSystemEntries(Src))
            {
                string destPath = Path.Combine(Dst, Path.GetFileName(element));

                if (Directory.Exists(element))
                    copyDirectory(element, destPath);
                else
                    File.Copy(element, destPath, true);
            }
        }
        public static void checkDelete()
        {
            // اسم النسخة القديمة حسب نفس تنسيق المجلد في النسخ الاحتياطي
            string oldBackupDate = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
            string folderName = "Backup " + oldBackupDate;
            string fullFolderPath = Path.Combine(Utils.BackUpPath, folderName);

            if (Directory.Exists(Utils.BackUpPath) && Directory.GetDirectories(Utils.BackUpPath).Length > 10)
            {
                if (Directory.Exists(fullFolderPath))
                    Directory.Delete(fullFolderPath, true);
            }

        }

        //public static void EmptyFolder(DirectoryInfo directoryInfo)
        //{
        //    foreach (FileInfo file in directoryInfo.GetFiles())
        //    {

        //        file.Delete();
        //    }
        //    foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
        //    {
        //        EmptyFolder(subfolder);
        //        //   subfolder.Delete();
        //    }
        //    directoryInfo.Delete();

        //}


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
