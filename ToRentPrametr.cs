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
    public partial class ToRentPrametr : Form
    {
        int realid;
        int region;
        public string ss = "go";
        public ToRentPrametr(int prealid,int pregion)
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
                    if (priceTextBox.Text != "" && priceTextBox.Text != null)
                    {
                        Utils.ToRentcopy(realid, region, Convert.ToDouble(priceTextBox.Text), Convert.ToInt32(comboBox4.SelectedValue), Convert.ToInt32(status_IDListBox.SelectedValue), startRentDateDateTimePicker.Value, endRendDateDateTimePicker.Value, periodTextBox.Text, remainingDayTextBox.Text);
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
            // TODO: This line of code loads data into the 'dSrealstate.StatusType' table. You can move, or remove it, as needed.
            this.statusTypeTableAdapter.Fill(this.dSrealstate.StatusType);
            // TODO: This line of code loads data into the 'dSrealstate.WayOfRent' table. You can move, or remove it, as needed.
            this.wayOfRentTableAdapter.Fill(this.dSrealstate.WayOfRent);

            status_IDListBox.SelectedValue = 2;

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

        private void status_IDListBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (status_IDListBox.SelectedValue.ToString() == "2")
            {
                startRentDateDateTimePicker.Value = DateTime.Now;
                endRendDateDateTimePicker.Value = DateTime.Now;
                remainingDayTextBox.Text = "0";
                periodTextBox.Text = "0";

            }
        }

        private void status_IDListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (status_IDListBox.SelectedValue.ToString() == "1")
                {
                    status_IDListBox.BackColor = Color.Red;
                    status_IDListBox.ForeColor = Color.White;
                    
                }
                else
                {
                    status_IDListBox.BackColor = Color.White;
                    status_IDListBox.ForeColor = Color.Black;
                    remainingDayTextBox.Text = "0";
                    periodTextBox.Text = "0";

                }
            }
            catch
            {

            }
        }

        private void startRentDateDateTimePicker_KeyUp(object sender, KeyEventArgs e)
        {
            //hadi
            //realStateBindingNavigatorSaveItem.Enabled = true;
            if (ss == "go")
            {

                DateTime d1 = startRentDateDateTimePicker.Value.Date;
                DateTime d2 = endRendDateDateTimePicker.Value.Date;

                int M = Math.Abs((d1.Year - d2.Year));
                //                int months = ((M * 12) + Math.Abs((d1.Month - d2.Month)));
                int monthsApart = 12 * (d1.Year - d2.Year) +
                d1.Month - d2.Month;
                int months = Math.Abs(monthsApart);
                periodTextBox.Text = months.ToString();
                remainingDayTextBox.Text = GetDates.DateDiffDays(DateTime.Now.Date, endRendDateDateTimePicker.Value.Date).ToString();

                if (remainingDayTextBox.Text == "0")
                {
                    status_IDListBox.SelectedValue = 2;

                }
                else
                {
                    status_IDListBox.SelectedValue = 1;
                }



            }
        }

        private void startRentDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

            if (ss == "go")
            {

                DateTime d1 = startRentDateDateTimePicker.Value.Date;
                DateTime d2 = endRendDateDateTimePicker.Value.Date;
                if (d1.Date <= d2.Date)
                {

                    int monthsApart = 12 * (d1.Year - d2.Year) +
                    d1.Month - d2.Month;
                    int months = Math.Abs(monthsApart);
                    periodTextBox.Text = months.ToString();

                    remainingDayTextBox.Text = GetDates.DateDiffDays(DateTime.Now.Date, endRendDateDateTimePicker.Value.Date).ToString();

                    if (remainingDayTextBox.Text == "0")
                    {
                        status_IDListBox.SelectedValue = 2;

                    }
                    else
                    {
                        status_IDListBox.SelectedValue = 1;
                    }

                }
                else
                {

                    // MessageBox.Show("خطأ بالتواريخ");
                    // startRentDateDateTimePicker.Focus();
                }

            }
        }

        private void periodTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //realStateBindingNavigatorSaveItem.Enabled = true;

            if (periodTextBox.Text != "" && periodTextBox.Text != null && periodTextBox.Text != "0")
            {
                ss = "not go";
                //                startRentDateDateTimePicker.Value = DateTime.Now.Date;
                endRendDateDateTimePicker.Value = DateTime.Now.Date;
                endRendDateDateTimePicker.Value = startRentDateDateTimePicker.Value.Date.AddMonths(Convert.ToInt32(periodTextBox.Text));
                remainingDayTextBox.Text = GetDates.DateDiffDays(startRentDateDateTimePicker.Value.Date, endRendDateDateTimePicker.Value.Date).ToString();
                if (remainingDayTextBox.Text == "0")
                {
                    status_IDListBox.SelectedValue = 2;

                }
                else
                {
                    status_IDListBox.SelectedValue = 1;
                }
            }
            else
            {
                ss = "not go";
                
                    startRentDateDateTimePicker.Value = DateTime.Now.Date;
                    endRendDateDateTimePicker.Value = DateTime.Now.Date;
                    remainingDayTextBox.Text ="0";
                
                if (remainingDayTextBox.Text == "0")
                {
                    status_IDListBox.SelectedValue = 2;

                }
                else
                {
                    status_IDListBox.SelectedValue = 1;
                }
            }
            ss = "go";

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox4.SelectedValue.ToString() == "1")
                {
                    //mafrosh
                    comboBox4.ForeColor = Color.Green;
                }
                else if (comboBox4.SelectedValue.ToString() == "2")
                {

                    comboBox4.ForeColor = Color.Blue;

                }
            }
            catch
            {
            }
        }
    }
}
