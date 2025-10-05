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
    class SBackUp
    {
        private static System.Windows.Forms.Timer main_timer;
        private static bool GetFileExisting(string filename)
        {

            if (Directory.Exists(filename))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
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
            TimeSpan target = Utils.SBackUpTime.TimeOfDay;

            if (Math.Abs((current - target).TotalSeconds) <= 5)
            {

                string filespath = Utils.SBackUpPath;
                try
                {
                    if (Utils.SBackUpPath != "" && Utils.SBackUpPath != null)
                    {
                        string FileName = "Back up " + DateTime.Now.ToString("yyyy-MM-dd");

                        if (Directory.Exists(filespath))
                        {
                            if (!Directory.Exists(Path.Combine(filespath, FileName)))
                            {
                            Utils.update_auto();

                                // Backup Db
                                string Fullpath = Path.Combine(filespath, FileName, "Db");
                                Directory.CreateDirectory(Fullpath);
                                string GetDbName = CustomPath.GetDBName();
                                string GetDBFullPath = CustomPath.GetDBFullPath();
                                Fullpath = Path.Combine(Fullpath, GetDbName);
                                File.Copy(GetDBFullPath, Fullpath);

                                // Backup Attachment
                                Fullpath = Path.Combine(filespath, FileName, "Attachment");
                                CopyWithBackgroundWorker copyWithBackgroundWorker =
                                    new CopyWithBackgroundWorker(Utils.DataFolderPath, Fullpath);
                                copyWithBackgroundWorker.ShowDialog();

                                checkDelete();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"{filespath}\r\n مسار النسخة الاحتياطية غير صحيح");
                        }
                    }
                    else
                    {
                        MessageBox.Show("الرجاء تحديد مسار النسخة الاحتياطية");
                    }
                }
                catch
                {
                    MessageBox.Show("هناك خطأ قد حدث لم يتم النسخ");
                }
            }
        }

        public static void copyDirectory(string Src, string Dst)
        {
            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                // Sub directories

                if (Directory.Exists(Element))
                    copyDirectory(Element, Dst + Path.GetFileName(Element));
                // Files in directory

                else
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
            }
        }
        public static void checkDelete()
        {
          // اسم النسخة القديمة حسب نفس تنسيق المجلد في النسخ الاحتياطي
            string oldBackupDate = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
            string folderName = "Backup " + oldBackupDate;
            string fullFolderPath = Path.Combine(Utils.SBackUpPath, folderName);

            // تحقق إذا كان هناك أكثر من 30 نسخة احتياطية
            if (Directory.Exists(Utils.SBackUpPath) && Directory.GetDirectories(Utils.SBackUpPath).Length > 10)
            {
                if (Directory.Exists(fullFolderPath))
                {
                    // حذف محتوى المجلد ثم حذفه
                    Directory.Delete(fullFolderPath, true); // حذف كامل مع المحتوى
                }
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
