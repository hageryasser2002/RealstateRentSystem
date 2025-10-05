using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class CopyWithBackgroundWorker : Form
    {
        public string src { get; set; }
        public string dst { get; set; }
        public CopyWithBackgroundWorker(string src, string dst)
        {
            InitializeComponent();

            this.src = src;
            this.dst = dst;

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
          
        }

        private void CopyWithBackgroundWorker_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(src))
            {
                MessageBox.Show("مجلد المصدر غير موجود.");
                return;
            }

            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("يتم النسخ بالفعل...");
                return;
            }

            backgroundWorker1.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var allFiles = Directory.GetFiles(src, "*", SearchOption.AllDirectories);
            int total = allFiles.Length;
            int count = 0;

            foreach (string file in allFiles)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                string relativePath = GetRelativePath(src, file);
                string destFile = Path.Combine(dst, relativePath);
                string destDir = Path.GetDirectoryName(destFile);
                if (!Directory.Exists(destDir))
                    Directory.CreateDirectory(destDir);

                File.Copy(file, destFile, true);
                count++;

                int percent = (int)((count / (float)total) * 100);
                backgroundWorker1.ReportProgress(percent);
            }
        }

        public static string GetRelativePath(string basePath, string fullPath)
        {
            Uri baseUri = new Uri(basePath.EndsWith("\\") ? basePath : basePath + "\\");
            Uri fullUri = new Uri(fullPath);
            return Uri.UnescapeDataString(baseUri.MakeRelativeUri(fullUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label2.Text = $"{e.ProgressPercentage} %";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("تم إلغاء العملية.");
                label1.Text = "تم الإلغاء.";
            }
            else if (e.Error != null)
            {
                MessageBox.Show("حدث خطأ: " + e.Error.Message);
                label1.Text = "فشل النسخ.";
            }
            else
            {
                MessageBox.Show(" النسخة الاحتياطية تمت بنجاح ");
                this.Close();
            }

            progressBar1.Value = 0;
        }

        private void CopyWithBackgroundWorker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }
    }
}
