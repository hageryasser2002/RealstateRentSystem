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
    public partial class ToOwnPrametr : Form
    {
        int realid;
        string region;
        public ToOwnPrametr(int prealid,string pregion)
        {
            InitializeComponent();

            realid = prealid;
            region = pregion;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            
            DialogResult result1 = MessageBox.Show("هل تريد نسخ العقار ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            DialogResult result2;

            if (result1 == DialogResult.Yes)
            {
                result2 = MessageBox.Show("هل انت متأكد من نسخ العقار ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (result2 == DialogResult.Yes)
                {
                    if (textBox1.Text != "" && comboBox1.Text != null)
                    {
                        Utils.ToOwncopy(realid, Convert.ToDouble(textBox1.Text), comboBox1.Text, region);
                        MessageBox.Show("تم");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Complate");
                    }


                }
                else if (result2 == DialogResult.No)
                {
                    this.Close();
                }

            }
            else if (result1 == DialogResult.No)
            {
                this.Close();
            }


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToOwnPrametr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSrealowner.WayOFOwner' table. You can move, or remove it, as needed.
            this.wayOFOwnerTableAdapter.Fill(this.dSrealowner.WayOFOwner);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "+")
            {
                this.ActiveControl.Text += "000";
            }
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
    }
}
