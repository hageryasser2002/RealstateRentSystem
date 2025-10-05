using RealStateRentSystem.DSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
namespace RealStateRentSystem
{
    public partial class insertintophone : Form
    {
        static insertintophone newMessageBox;
        public static string Button_Clicked;
        public static DateTime appdate;
        public static DateTime apptime;
        public Boolean soso = false;
        public string clicked = "";
        public static Boolean continues = false;
        public static Boolean Exsit = false;
        private static DSTables.DSappointmentTableAdapters.AppointmentsNumbersTableAdapter AppointmentsNumbersTableAdapter = new DSTables.DSappointmentTableAdapters.AppointmentsNumbersTableAdapter();

        public static string am;

        public insertintophone()
        {
            InitializeComponent();
        }


        public static void ShowMe()
        {
            newMessageBox = new insertintophone();
            newMessageBox.ShowDialog();

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                this.phoneBindingNavigatorSaveItem.PerformClick();


            }
            else
            {
                Button_Clicked = "";
                MessageBox.Show("الرجاء ادخال اسم");
                newMessageBox.Focus();
                nameTextBox.Focus();

            }
        }


        private void LoginMsg_Paint(object sender, PaintEventArgs e)
        {
            //Graphics mGraphics = e.Graphics;
            //Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

            //Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            //LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            //mGraphics.FillRectangle(LGB, Area1);
            //mGraphics.DrawRectangle(pen1, Area1);
        }
        private void LoginMsg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSphone.Phone' table. You can move, or remove it, as needed.
            this.phoneTableAdapter.Fill(this.dSphone.Phone);

            this.bindingNavigatorAddNewItem.PerformClick();
            dataofchangedDateTimePicker.Value = DateTime.Now;
            userTextBox.Text = Utils.current_user;
            this.clicked = "clicked";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button_Clicked = "";
            newMessageBox.Dispose();
        }

        
        private void phoneBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                int esra2 = 0;
                soso = false;
                if (!soso)
                {
                    if (((Utils.checkexistPhone(nameTextBox.Text, p1TextBox.Text, p2TextBox.Text, m2TextBox.Text, m3TextBox.Text, esra2).Rows.Count <= 0) || continues ||  Exsit))//|| gnon == "del")
                    {
                        AppointmentsNumbersTableAdapter.Insert("rent");
                        
                        dataofchangedDateTimePicker.Value = DateTime.Now;
                        userTextBox.Text = Utils.current_user;
                        //notesTextBox.Text = " موعد : " + dateTimePicker1.Value.Date.ToShortDateString() + "\r\n" + " رقم الموعد : " + Utils.LastIDApp();
                        notesTextBox.Text = " موعد : " + dateTimePicker1.Value.Date.AddDays(1).ToShortDateString() + "\r\n" + " رقم الموعد : " + Utils.LastIDApp();


                        if (!Exsit)
                        {
                            this.Validate();
                            this.phoneBindingSource.EndEdit();
                            this.tableAdapterManager.UpdateAll(this.dSphone);
                            Utils.PhoneID = Convert.ToInt32(((DSphone.PhoneRow)this.dSphone.Phone.Rows[phoneBindingSource.Position]).ID);
                        }

                        

                        Button_Clicked = nameTextBox.Text;
                        //appdate = dateTimePicker1.Value.Date;
                        appdate = dateTimePicker1.Value.Date.AddDays(1);

                        apptime = dateTimePicker2.Value;


                        if(am=="rent")
                        {
                        Utils.NameOfCustomer = nameTextBox.Text;
                        Utils.CustPhon=p1TextBox.Text;
                        Utils.CustMobile=m2TextBox.Text;
                        Utils.CusOther=otherTextBox.Text;
                        }

                        if(am=="own")
                        {
                        Utils.ONameOfCustomer = nameTextBox.Text;
                        Utils.OCustPhon = p1TextBox.Text;
                        Utils.OCustMobile = m2TextBox.Text;
                        Utils.OCusOther = otherTextBox.Text;
                        }

                        //MessageBox.Show("حفظ");
                        newMessageBox.Dispose();

                    }
                    else
                    {
                        DSphoneSearch.PhoneDataTable dt = (DSphoneSearch.PhoneDataTable)Utils.checkexistPhone(nameTextBox.Text, p1TextBox.Text, p2TextBox.Text, m2TextBox.Text, m3TextBox.Text, esra2);
                        CheckPhone.iam = "phapp";
                        string g = CheckPhone.ShowMe(dt);

                        if (g == "kml")
                        {
                            continues = true;
                            CheckPhone.iam = "";
//                            notesTextBox.Text = " موعد : " + dateTimePicker1.Value.Date.ToShortDateString() + "\r\n" + " رقم الموعد : " + Utils.LastIDApp();
                            phoneBindingNavigatorSaveItem.PerformClick();
                        }
                        if (g == "cancel")
                        {
                            continues = false;
                            CheckPhone.iam = "";
                            nameTextBox.Focus();
                        }
                        if (g == "Exist")
                        {
                            if (am == "rent")
                            {
                                Utils.NameOfCustomer = nameTextBox.Text;
                                Utils.CustPhon = p1TextBox.Text;
                                Utils.CustMobile = m2TextBox.Text;
                                Utils.CusOther = otherTextBox.Text;
                            }

                            if (am == "own")
                            {
                                Utils.ONameOfCustomer = nameTextBox.Text;
                                Utils.OCustPhon = p1TextBox.Text;
                                Utils.OCustMobile = m2TextBox.Text;
                                Utils.OCusOther = otherTextBox.Text;
                            }
                            CheckPhone.iam = "";
                           // MessageBox.Show("OK");
                            newMessageBox.Dispose();
                        }

                        continues = false;
                    }
                }
                else
                {
                }

            }
            else
            {
                Button_Clicked = "";
                MessageBox.Show("الرجاء ادخال اسم");
                newMessageBox.Focus();
                nameTextBox.Focus();

            }

            Exsit = false;

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (clicked == "clicked")
            {
                //                phoneBindingNavigatorSaveItem.PerformClick();
                dataofchangedDateTimePicker.Value = DateTime.Now;
                userTextBox.Text = Utils.current_user;
                this.clicked = "clicked";

            }
            else
            {

                dataofchangedDateTimePicker.Value = DateTime.Now;
                userTextBox.Text = Utils.current_user;
                this.clicked = "clicked";


            }
        }

        private void p1TextBox_KeyPress(object sender, KeyPressEventArgs e)
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



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {

                if (keyData == Keys.Escape)
                {

                    Button_Clicked = "";
                    this.Close();
                    return true;
                }


            }
            return base.ProcessDialogKey(keyData);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            phoneBindingNavigatorSaveItem.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Exsit  = true;
            CheckPhone.iam = "";
            phoneBindingNavigatorSaveItem.PerformClick();

        }

       
    }
}
