using RealStateRentSystem_Buisness;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class APISetting : Form
    {
        public APISetting()
        {
            InitializeComponent();
            LoadSettingsFromDB();
        }

        private void LoadSettingsFromDB()
        {
            var settings = clsSettingsCalling.LoadSettings();
            txtExport.Text = settings.ExportLink;
            txtImport.Text = settings.ImportLink;
            txtInterval.Text = settings.Interval.ToString();
        }
        private void settingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInterval.Text, out int interval))
            {
                MessageBox.Show("الرجاء إدخال رقم صحيح في خانة Interval");
                return;
            }

            clsSettingsCalling.SaveSettings(txtExport.Text, txtImport.Text, interval);
            //MessageBox.Show("تم حفظ الإعدادات بنجاح");
        }
    }
}
