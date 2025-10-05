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
    public partial class ShortCutKeys : Form
    {
        public  Boolean checke = false;
        public  string close = "";

        public Boolean rctrl = false;
        public ShortCutKeys()
        {
            InitializeComponent();
        }
        

        private void shorCutKeysBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.shorCutKeysBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSsetting);
            checke = false;


            if (this.shorCutKeysBindingSource.Count == 1)
            {
                this.shorCutKeysTableAdapter.Fill(this.dSsetting.ShorCutKeys);

            }

        }

        private void ShortCutKeys_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSsetting.ShorCutKeys' table. You can move, or remove it, as needed.
            this.shorCutKeysTableAdapter.Fill(this.dSsetting.ShorCutKeys);

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

        //                    shorCutKeysBindingNavigatorSaveItem.PerformClick();
        //                     close = "closed";
        //                    this.Close();

        //                }

        //                if (result1 == DialogResult.No)
        //                {


        //                    close = "closed";
        //                    this.Close();


        //                }


        //            }

        //        }


        //    }


        //    if ((keyData & Keys.Alt) == Keys.Alt)
        //    {
        //        return true;
        //    }

        //    else
        //    {
        //        return base.ProcessDialogKey(keyData);
        //    }

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
                        DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                        if (result1 == DialogResult.Yes)
                        {
                            shorCutKeysBindingNavigatorSaveItem.PerformClick();
                            close = "closed";
                            this.Close();
                        }
                        else if (result1 == DialogResult.No)
                        {
                            close = "closed";
                            this.Close();
                        }
                        else if (result1 == DialogResult.Cancel)
                        {
                            // البقاء في نفس الفورم وعدم الإغلاق
                            return true; // يوقف المعالجة ويمنع الغلق
                        }

                        return true;
                    }

                    this.Close();
                    return true;
                }
            }

            if ((keyData & Keys.Alt) == Keys.Alt)
            {
                return true;
            }
            else
            {
                return base.ProcessDialogKey(keyData);
            }
        }




        private void textTextBox_KeyUp(object sender, KeyEventArgs e)
        {

            if (!rctrl)
            {
                checke = true;

                string[] keys = e.KeyData.ToString().Split(',');

                List<string> letters = new List<string>();
                letters.Add("a"); letters.Add("b"); letters.Add("c"); letters.Add("d"); letters.Add("e");
                letters.Add("f"); letters.Add("g"); letters.Add("h"); letters.Add("i"); letters.Add("j");
                letters.Add("k"); letters.Add("l"); letters.Add("m"); letters.Add("n"); letters.Add("o");
                letters.Add("b"); letters.Add("q"); letters.Add("r"); letters.Add("s"); letters.Add("t");
                letters.Add("u"); letters.Add("v"); letters.Add("w"); letters.Add("x"); letters.Add("y");
                letters.Add("z"); letters.Add("p");


                if (keys.Length == 2)
                {
                    if ((!letters.Contains(keys[1].Trim().ToString().ToLower())) && (!letters.Contains(keys[0].Trim().ToString().ToLower())))
                    {
                        DataTable t = new DataTable();
                        t = shorCutKeysTableAdapter.GetDataBy(keys[1].Trim().ToString(), keys[0].Trim().ToString());
                        if (t.Rows.Count == 0)
                        {
                            key_OneTextBox.Text = keys[1].Trim().ToString();
                            key_TwoTextBox.Text = keys[0].Trim().ToString();
                        }
                        else
                        {
                            MessageBox.Show(keys[1].Trim().ToString() + " + " + keys[0].Trim().ToString() + " مفاتيح الاختصار متكررة ");
                        }

                    }
                    else
                    {

                        MessageBox.Show(keys[1].Trim().ToString() + " + " + keys[0].Trim().ToString() + " غير مسموح بإنشاء هذا الاختصار");
                    }
                }
            }
        }

        //private void ShortCutKeys_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (close != "closed")
        //    {

        //        if (checke)
        //        {

        //            DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

        //            if (result1 == DialogResult.Yes)
        //            {
        //                shorCutKeysBindingNavigatorSaveItem.PerformClick();
        //                close = "closed";
        //                this.Close();


        //            }
        //            if (result1 == DialogResult.No)
        //            {


        //                close = "closed";
        //                this.Close();


        //            }


        //        }

        //    }
        //    close = "";
        //}
        private void ShortCutKeys_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close != "closed")
            {
                if (checke)
                {
                    DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk,
                        MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                    if (result1 == DialogResult.Yes)
                    {
                        shorCutKeysBindingNavigatorSaveItem.PerformClick();
                        close = "closed";
                        this.Close();
                    }
                    else if (result1 == DialogResult.No)
                    {
                        close = "closed";
                        this.Close();
                    }
                    else if (result1 == DialogResult.Cancel)
                    {
                        e.Cancel = true; // منع الإغلاق والبقاء في الفورم
                        return;
                    }
                }
            }

            close = "";
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            checke = false;
        }

        

        

        

        

    }
}
