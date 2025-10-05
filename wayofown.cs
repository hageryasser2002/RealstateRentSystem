using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class wayofown : Form
    {
        public wayofown()
        {
            InitializeComponent();
        }

        private void wayOFOwnerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wayOFOwnerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSrealowner);

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

            if ((keyData & Keys.Alt) == Keys.Alt)
                return true;
            else
                return base.ProcessDialogKey(keyData);

        }
        private void wayofrent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSrealowner.WayOFOwner' table. You can move, or remove it, as needed.
            this.wayOFOwnerTableAdapter.Fill(this.dSrealowner.WayOFOwner);

        }
    }
}
