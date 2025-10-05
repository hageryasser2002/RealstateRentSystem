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
    public partial class AddToPhone : Form
    {

        string number = "";
        string type = "";
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
        public AddToPhone(string pnumber,string ptype)
        {
            number = pnumber;
            
            type = ptype;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "اجار")
            {

                Realstate r = new Realstate();
                r.toDo="new";
                if (type == "mop")
                {
                    r.toDomop = number;
                }
                else if (type == "land")
                {
                    r.toDophne = number;
                }
                else
                {
                    r.toDoother = number;
                }

                r.ShowDialog();
                //ShowModalExcept(r, MainForm.searchForm);

            }

            if (comboBox1.Text == "بيع")
            {


                RealstateOwner r = new RealstateOwner();
                r.toDo = "new";
                if (type == "mop")
                {
                    r.toDomop = number;
                }
                else if (type == "land")
                {
                    r.toDophne = number;
                }
                else
                {
                    r.toDoother = number;
                }

                r.ShowDialog();
                //ShowModalExcept(r, MainForm.searchForm);



            }

            if (comboBox1.Text == "مهن")
            {

                career r = new career();
                r.toDo = "new";
                if (type == "mop")
                {
                    r.toDomop = number;
                }
                else if (type == "land")
                {
                    r.toDophne = number;
                }
                else
                {
                    r.toDoother = number;
                }

                r.ShowDialog();
                //ShowModalExcept(r, MainForm.searchForm);




            }

            if (comboBox1.Text == "هاتف")
            {

                phone r = new phone();
                r.toDo = "new";
                if (type == "mop")
                {
                    r.toDomop = number;
                }
                else if (type == "land")
                {
                    r.toDophne = number;
                }
                else
                {
                    r.toDoother = number;
                }

                r.ShowDialog();
                //ShowModalExcept(r, MainForm.searchForm);



            }

            if (comboBox1.Text != "")
                this.Close();


        }

        /// <summary>
        /// Search TextBox
        /// </summary>
        /// 
        public static void ShowModalExcept(Form modalForm, Form exceptionForm)
        {
            // إيقاف كل الفورمز ما عدا فورم البحث
            foreach (Form f in Application.OpenForms)
            {
                if (f != modalForm && f != exceptionForm)
                {
                    f.Enabled = false;
                }
            }

            // لما الفورم تتقفل، نرجّع كل حاجة
            modalForm.FormClosed += (s, e) =>
            {
                foreach (Form f in Application.OpenForms)
                {
                    f.Enabled = true;
                }
            };

            modalForm.Show();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {

                if (keyData == Keys.Escape)
                {

                    this.Close();
                }


                if (((keyData & Keys.Alt) == Keys.Alt))
                {
                    return true;
                }

                


            }

            if (((keyData & Keys.Shift) == Keys.Shift) && ((keyData & Keys.F10) == Keys.F10))
            {
                return true;
            }

            if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.F10) == Keys.F10))
            {
                return true;
            }

            return false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            allsearch f = new allsearch(textBox1.Text,"Hadi");

            Clipboard.SetDataObject(number, true);
            f.ShowDialog();
            //ShowModalExcept(f, MainForm.searchForm);


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //13 = enter
            {
                button2.PerformClick();
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

            //realStateBindingNavigatorSaveItem.Enabled = true;

            
            string[] keys = e.KeyData.ToString().Split(',');
            if (keys.Length == 2)
            {
                try{
                DataTable t = new DataTable();
                t = shorCutKeysTableAdapter.GetDataBy(keys[1].Trim().ToString(), keys[0].Trim().ToString());
                if (t.Rows.Count > 0)
                {
                    if ((keys[1].Trim().ToString() == "Control") && (keys[0].Trim().ToString() == "Z"))
                    {
                        this.ActiveControl.Text = "";
                        this.ActiveControl.Text = t.Rows[0]["Text"].ToString();
                        ((TextBox)this.ActiveControl).SelectionStart = this.ActiveControl.Text.Length + 1;
                    }
                    else
                    {
                        this.ActiveControl.Text += t.Rows[0]["Text"].ToString();
                        ((TextBox)this.ActiveControl).SelectionStart = this.ActiveControl.Text.Length + 1;
                    }


                }
                }
                catch
                {

                }
            }

        }

        


    }
}
