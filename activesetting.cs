using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;


namespace RealStateRentSystem
{
    public partial class activesetting : Form
    {
        private DSTables.DSsettingTableAdapters.PCinfoTableAdapter PCinfoTableAdapter = new DSTables.DSsettingTableAdapters.PCinfoTableAdapter();
        
        public activesetting()
        {
            InitializeComponent();
        }

      

    public static string GetMacAddress()
    {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (nic.OperationalStatus == OperationalStatus.Up &&
                nic.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                !nic.Description.ToLower().Contains("virtual") &&
                !nic.Description.ToLower().Contains("pseudo"))
            {
                return nic.GetPhysicalAddress().ToString();
            }
        }
        return null;
    }


    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {

                if (keyData == Keys.Escape)
                {

                            this.Close();
                            return true;

                    }

                }

                return base.ProcessDialogKey(keyData);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable pcinfo = new DataTable();
            int id = 0;
            pcinfo = PCinfoTableAdapter.GetDataByexist(GetMacAddress());//System.Environment.OSVersion.ToString(), System.Environment.Version.ToString());
            if (pcinfo.Rows.Count > 0)
            {
                id = Convert.ToInt16(pcinfo.Rows[0]["id"].ToString());

            }

            if (id != 0)
            {
                PCinfoTableAdapter.UpdateQuery(alertCheckBox.Checked, backupCheckBox.Checked, id);

            }
            else
            {
                PCinfoTableAdapter.Insert(GetMacAddress(), alertCheckBox.Checked, backupCheckBox.Checked);
            }

        }

        private void activesetting_Load(object sender, EventArgs e)
        {

            DataTable pcinfo = new DataTable();
            pcinfo = PCinfoTableAdapter.GetDataByexist(Utils.macaddreass);
            if (pcinfo.Rows.Count > 0)
            {
                this.pCinfoTableAdapter1.FillByexist(this.dSsetting.PCinfo, Utils.macaddreass);
            }
            else
            {

                this.pCinfoTableAdapter1.Fill(this.dSsetting.PCinfo);
                bindingNavigatorAddNewItem.PerformClick();
                mACAddressTextBox.Text =Utils.macaddreass;
                alertCheckBox.Checked = true;
                //backupCheckBox.Checked = true;

                //versionTextBox.Text = System.Environment.Version.ToString();

            }
        }

        private void pCinfoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pCinfoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSsetting);

        }

        private void backupCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
