using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class Setting : Form
    {
        public static Boolean checke = false;
        public Setting()
        {
            
            InitializeComponent();
            DataTable dt = new DataTable();
             dt= this.settingTableAdapter.GetCountBy();
           if (dt.Rows.Count > 0)
               bindingNavigatorAddNewItem.Visible = false;
        }

        private void settingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.settingBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSsetting);

        }

        private void settingBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            if (!Directory.Exists(DataFolderPath_txt.Text))
            {
                MessageBox.Show(
                                     $"مسار المجلدات غير موجود يرجى التحقق من المسار \r\n {DataFolderPath_txt.Text}",
                                     "خطأ",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error,
                                     MessageBoxDefaultButton.Button3,
                                     MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                                 );
                return;
            }
            this.Validate();
            this.settingBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSsetting);

            ///chkIsWriterDevice
            //Properties.Settings.Default.IsWriterDevice = chkIsWriterDevice.Checked;
            //Properties.Settings.Default.Save();

            bool canSave = chkIsWriterDevice.Checked;
            bool hasModem = hasModemCheckBox.Checked;
            clsDeviceSettings.SaveDeviceSetting(Utils.macaddreass, Utils.alert, Utils.backup, canSave, hasModem);

            checke = false;
            Utils.ProjectName = DataFolderPath_txt.Text;
            Utils.getsetting();
            
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSsetting.Setting' table. You can move, or remove it, as needed.
            this.settingTableAdapter.Fill(this.dSsetting.Setting);
            chkIsWriterDevice.Checked = clsDeviceSettings.CanSaveCalls();// Properties.Settings.Default.IsWriterDevice;

        }

        private void brows_Click(object sender, EventArgs e)
        {
          //  SaveFileDialog fdlg = new SaveFileDialog();
            fdlg.Title = "Attach file";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            fdlg.FileName = "db1";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {

                string f = fdlg.FileName.Substring(0, fdlg.FileName.LastIndexOf("\\"));
                backUpPathTextBox.Text = f ;
                backUpNameTextBox.Text = "db1";

            }
        }



        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{

        //    const int WM_KEYDOWN = 0x100;
        //    if (msg.Msg == WM_KEYDOWN)
        //    {

        //        if (keyData == Keys.Escape)
        //        {

        //            if (checke)
        //            {

        //                DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

        //                if (result1 == DialogResult.Yes)
        //                {

        //                    settingBindingNavigatorSaveItem.PerformClick();

        //                }
        //                else if (result1 == DialogResult.No)
        //                {
        //                    this.Close();
        //                }
        //                else if (result1 == DialogResult.Cancel)
        //                {
        //                    // البقاء في نفس الفورم وعدم الإغلاق
        //                    return true; // يوقف المعالجة ويمنع الغلق
        //                }


        //                return true;
        //            }

        //            this.Close();
        //            return true;

        //        }


        //    }

        //    if ((keyData & Keys.Alt) == Keys.Alt)
        //        return true;
        //    else
        //        return base.ProcessDialogKey(keyData);

        //}
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {
                if (keyData == Keys.Escape)
                {
                    if (checke)
                    {
                        DialogResult result1 = MessageBox.Show(
                            "هل تريد الحفظ ",
                            "تنبيه",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button2,
                            MessageBoxOptions.RightAlign
                        );

                        if (result1 == DialogResult.Yes)
                        {
                            settingBindingNavigatorSaveItem.PerformClick();
                            this.Close(); // بعد الحفظ يقفل
                        }
                        else if (result1 == DialogResult.No)
                        {
                            this.Close(); // يقفل بدون حفظ
                        }
                        else if (result1 == DialogResult.Cancel)
                        {
                            return true; // يبقى في الفورم وما يقفلش
                        }

                        return true; // يمنع معالجة إضافية
                    }

                    this.Close(); // لو مفيش تغييرات يقفل على طول
                    return true;
                }
            }

            if ((keyData & Keys.Alt) == Keys.Alt)
                return true;
            else
                return base.ProcessDialogKey(keyData);
        }

        private void remainderingDaysTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            checke = true;   
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    fdlg.Title = "Attach file";
        //    fdlg.InitialDirectory = @"c:\";
        //    fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
        //    fdlg.FilterIndex = 2;
        //    fdlg.RestoreDirectory = true;
        //    fdlg.FileName = "db1";
        //    if (fdlg.ShowDialog() == DialogResult.OK)
        //    {

        //        string f = fdlg.FileName.Substring(0, fdlg.FileName.LastIndexOf("\\"));
        //        sBackUpPathTextBox.Text = f;
        //        backUpNameTextBox.Text = "db1";

        //    }
        //}

        /// <summary>
        /// BackUp Directory Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "اختر مجلد حفظ النسخة الاحتياطية";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupFolder = folderDialog.SelectedPath;
                    string sourceFolder = Application.StartupPath;

                    try
                    {
                        // ✅ حذف النسخة القديمة
                        ClearDirectory(backupFolder);

                        // ✅ نسخ الملفات الجديدة
                        CopyDirectory(sourceFolder, backupFolder);

                        MessageBox.Show("تم تحديث النسخة الاحتياطية (الاحتفاظ بنسخة واحدة فقط).", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حدث خطأ أثناء النسخ الاحتياطي:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearDirectory(string path)
        {
            foreach (string file in Directory.GetFiles(path))
            {
                File.Delete(file);
            }

            foreach (string dir in Directory.GetDirectories(path))
            {
                Directory.Delete(dir, true);
            }
        }

        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            foreach (string filePath in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(filePath);
                string destFilePath = Path.Combine(destinationDir, fileName);
                File.Copy(filePath, destFilePath, true);
            }

            foreach (string dirPath in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(dirPath);
                string destDirPath = Path.Combine(destinationDir, dirName);
                Directory.CreateDirectory(destDirPath);
                CopyDirectory(dirPath, destDirPath);
            }
        }



        private void phoneNumerLengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow numbers and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {

                e.Handled = true;


            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                //   MessageBox.Show("رقم الهاتف غير كامل");
            }
        }

        private void DataFolderPath_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                 DataFolderPath_txt.Text= browserDialog.SelectedPath;
            }
        }

        private void DataFolderPath_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void sBackUpPathTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
