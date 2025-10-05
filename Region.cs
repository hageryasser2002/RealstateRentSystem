using RealStateRentSystem.DSTables;
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
    public partial class Region : Form
    {
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
        public Boolean checke = false;
        public  string close = "";
        public Region()
        {
            InitializeComponent();
        }

        private void Region_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSregion.Region' table. You can move, or remove it, as needed.
            this.regionTableAdapter.Fill(this.dSregion.Region);
        }
 

        private void nameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            checke = true;
            string[] keys = e.KeyData.ToString().Split(',');
            if (keys.Length == 2)
            {
                DataTable t = new DataTable();
                t = shorCutKeysTableAdapter.GetDataBy(keys[1].Trim().ToString(), keys[0].Trim().ToString());
                if (t.Rows.Count > 0)
                {
                    this.ActiveControl.Text = t.Rows[0]["Text"].ToString();
                    ((TextBox)this.ActiveControl).SelectionStart = this.ActiveControl.Text.Length + 1;
                }

            }
        }

        private void regionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.regionBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSregion);
            checke = false;

            if (this.regionBindingSource.Count == 1)
            {
                this.regionTableAdapter.Fill(this.dSregion.Region);

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

        //                    regionBindingNavigatorSaveItem.PerformClick();
        //                    close = "closed";
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
                            "هل تريد الحفظ ", "تنبيه",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                        if (result1 == DialogResult.Yes)
                        {
                            regionBindingNavigatorSaveItem.PerformClick();
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
                            return true; // يمنع تنفيذ أي أمر آخر ويوقف الإغلاق
                        }
                    }
                }
            }

            if ((keyData & Keys.Alt) == Keys.Alt)
                return true;
            else
                return base.ProcessDialogKey(keyData);
        }

        //private void Region_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (close != "closed")
        //    {

        //        if (checke)
        //        {

        //            DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

        //            if (result1 == DialogResult.Yes)
        //            {
        //                regionBindingNavigatorSaveItem.PerformClick();
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
        private void Region_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close != "closed")
            {
                if (checke)
                {
                    DialogResult result1 = MessageBox.Show(
                        "هل تريد الحفظ ", "تنبيه",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk,
                        MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                    if (result1 == DialogResult.Yes)
                    {
                        regionBindingNavigatorSaveItem.PerformClick();
                        close = "closed";
                        // مفيش داعي تستدعي this.Close() هنا لأنك أصلاً في FormClosing
                    }
                    else if (result1 == DialogResult.No)
                    {
                        close = "closed";
                        // برضه مفيش داعي لـ this.Close()
                    }
                    else if (result1 == DialogResult.Cancel)
                    {
                        e.Cancel = true; // يمنع الإغلاق
                        return;
                    }
                }
            }

            close = "";
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            checke = true;
        }

        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            int id = Convert.ToInt32(((DSregion.RegionRow)this.dSregion.Region.Rows[regionBindingSource.Position]).ID);

            if (!Utils.checkRegion(id))
            {
                bindingNavigatorDeleteItem.PerformClick();
                this.regionTableAdapter.DeleteQuery(id);
                this.regionTableAdapter.Fill(this.dSregion.Region);
            }
            else
            {

                MessageBox.Show("لا يمكن حذف المنطقة لوجود عقارات مرتبطة بها");
            }

       }



        }



       
    }

