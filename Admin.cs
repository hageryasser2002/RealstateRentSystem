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
    public partial class Admin : Form
    {
        public static Boolean checke = false;
        public Admin()
        {
            InitializeComponent();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (user_PasswordTextBox.Text == textBox1.Text)
            {
                this.Validate();
                this.usersBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dSsetting);
                checke = false;
            }
            else
            {
                MessageBox.Show("الرجاء التأكد من كلمة المرور");
                user_PasswordTextBox.Focus();

            }

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSsetting.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.FillBy(this.dSsetting.Users);

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
        //                    usersBindingNavigatorSaveItem.PerformClick();

        //                }


        //            }

        //            this.Close();
        //            return true;

        //        }


        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);

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
                            MessageBoxOptions.RightAlign);

                        if (result1 == DialogResult.Yes)
                        {
                            usersBindingNavigatorSaveItem.PerformClick();
                            this.Close();
                        }
                        else if (result1 == DialogResult.No)
                        {
                            this.Close();
                        }
                        else if (result1 == DialogResult.Cancel)
                        {
                            // البقاء في نفس الفورم
                            return true; // يمنع الإغلاق
                        }
                    }
                    else
                    {
                        this.Close();
                    }

                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void user_NameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            checke = true;
        }
    }
}
