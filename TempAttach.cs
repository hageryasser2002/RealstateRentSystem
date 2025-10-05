using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace RealStateRentSystem
{
    
    public partial class TempAttach : Form
    {
        private OpenFileDialog fdlg = new OpenFileDialog();
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
        private System.Windows.Forms.ToolTip m_wndToolTip;
        public  Boolean chechupdatestate=true;
        public static string close = "";
        public TempAttach()
        {
            InitializeComponent();
        }
        private bool GetFileExisting(string filename)
        {

            if (File.Exists(Utils.ProjectName + "\\TempAttachment\\" + filename))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fileNameTextBox.Text == null)
            {
                int id = this.tempAttachmentBindingSource.Count + 1;
                fdlg.Title = "Attach file";
                fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;

                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    string filename = fdlg.SafeFileName;
                    string ext = filename.Substring(filename.LastIndexOf("."));
                    string yy = filename.Substring(0, filename.LastIndexOf("."));
                    string fullname = "T" + yy + id + 1 + ext;
                    if (!(GetFileExisting(fullname)))
                    {
                        pathTextBox.Text = Utils.ProjectName + "\\TempAttachment\\" + fdlg.SafeFileName;
                    }
                    else
                    {
                        MessageBox.Show("الملف موجود من قبل");
                    }
                }
                if (pathTextBox.Text != null && pathTextBox.Text != "")
                {
                    string filename = fdlg.SafeFileName;
                    string ext = filename.Substring(filename.LastIndexOf("."));
                    string yy = filename.Substring(0, filename.LastIndexOf("."));
                    string fullname = "T" + yy + id + 1 + ext;
                    fileNameTextBox.Text = fullname;
                    File.Copy(fdlg.FileName, Utils.ProjectName + "\\TempAttachment\\" + fullname);
                    MessageBox.Show("تم ");
                    pathTextBox.Text = "";
                    //tempAttachmentBindingNavigatorSaveItem.PerformClick();
                    //this.tempAttachmentTableAdapter.Fill(this.dSTempAttch.TempAttachment);
                }
            }
            else
            {

                string prev = fileNameTextBox.Text;


                    int id = this.tempAttachmentBindingSource.Count + 1;
                    fdlg.Title = "Attach file";
                    fdlg.InitialDirectory = @"c:\";
                    fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                    fdlg.FilterIndex = 2;
                    fdlg.RestoreDirectory = true;

                    if (fdlg.ShowDialog() == DialogResult.OK)
                    {
                        string filename = fdlg.SafeFileName;
                        string ext = filename.Substring(filename.LastIndexOf("."));
                        string yy = filename.Substring(0, filename.LastIndexOf("."));
                        string fullname = "T" + yy + id + 1 + ext;

                        if (GetFileExisting(prev))
                        {
                            File.Delete(Utils.ProjectName + "\\TempAttachment\\" + prev);
                        }

                        if (!(GetFileExisting(fullname)))
                        {
                            pathTextBox.Text = Utils.ProjectName + "\\TempAttachment\\" + fdlg.SafeFileName;
                        }
                        else
                        {
                            MessageBox.Show("الملف موجود من قبل");
                        }
                    }


                    if (pathTextBox.Text != null && pathTextBox.Text != "")
                    {
                        string filename = fdlg.SafeFileName;
                        string ext = filename.Substring(filename.LastIndexOf("."));
                        string yy = filename.Substring(0, filename.LastIndexOf("."));
                        string fullname = "T" + yy + id + 1 + ext;
                        fileNameTextBox.Text = fullname;
                        File.Copy(fdlg.FileName, Utils.ProjectName + "\\TempAttachment\\" + fullname);
                        MessageBox.Show("تم ");
                        pathTextBox.Text = "";
                        //tempAttachmentBindingNavigatorSaveItem.PerformClick();
                        //this.tempAttachmentTableAdapter.Fill(this.dSTempAttch.TempAttachment);
                    }



                
            }
        }

        
        private void TempAttach_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSregion.Region' table. You can move, or remove it, as needed.
            this.regionTableAdapter.Fill(this.dSregion.Region);
            // TODO: This line of code loads data into the 'dSTempAttch.TempAttachment' table. You can move, or remove it, as needed.
            this.tempAttachmentTableAdapter.Fill(this.dSTempAttch.TempAttachment);

            this.m_wndToolTip = new System.Windows.Forms.ToolTip(this.components);
            m_wndToolTip.ShowAlways = true;
        }

        private void tempAttachmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tempAttachmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSTempAttch);

            chechupdatestate = true;

        }

        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result1 = MessageBox.Show("هل تريد حذف المرفق ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            DialogResult result2;

            if (result1 == DialogResult.Yes)
            {
                result2 = MessageBox.Show("هل انت متأكد من حذف المرفق ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (result2 == DialogResult.Yes)
                {
                    string path = fileNameTextBox.Text;
                    if ((GetFileExisting(path)))
                    {
                        File.Delete(Utils.ProjectName + "\\TempAttachment\\" + path);
                        bindingNavigatorDeleteItem.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("الملف غير موجود");
                    }
                    
                }

            }
        }

        private void tempAttachmentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tempAttachmentDataGridView.CurrentCell.OwningColumn.Index == 2)
            {
                string path = tempAttachmentDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
                if (GetFileExisting(path))
                {
                    System.Diagnostics.Process.Start(Utils.ProjectName + "\\TempAttachment\\" + path);
                }
                else
                {
                    MessageBox.Show("الملف غير موجود");
                }
            }
        }

        private void subregionTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == MouseButtons.Middle.ToString())
            {
                DataTable dt = new DataTable();
                dt = this.shorCutKeysTableAdapter.GetData();
                string al = "";
                if (dt.Rows.Count > 0)
                {
                    for (int h = 0; h < dt.Rows.Count; h++)
                    {

                        al += dt.Rows[h]["Key_Two"] + " + " + dt.Rows[h]["Key_One"] + " = " + dt.Rows[h]["Text"] + "\n";
                    }

                }

                m_wndToolTip.SetToolTip(this.ActiveControl, al);
            }
        }

        private void subregionTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == MouseButtons.Middle.ToString())
            {
                DataTable dt = new DataTable();
                dt = this.shorCutKeysTableAdapter.GetData();
                string al = "";
                if (dt.Rows.Count > 0)
                {
                    for (int h = 0; h < dt.Rows.Count; h++)
                    {

                        al += dt.Rows[h]["Key_Two"] + " + " + dt.Rows[h]["Key_One"] + " = " + dt.Rows[h]["Text"] + "\n";
                    }

                }

                m_wndToolTip.SetToolTip(this.ActiveControl, al);
            }
        }

        private void subregionTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            chechupdatestate = false;
            string[] keys = e.KeyData.ToString().Split(',');
            if (keys.Length == 2)
            {
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


        }


        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{

        //    const int WM_KEYDOWN = 0x100;
        //    if (msg.Msg == WM_KEYDOWN)
        //    {
        //        if (keyData == Keys.Escape)
        //        {
        //            if (!chechupdatestate)
        //            {

        //                DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

        //                if (result1 == DialogResult.Yes)
        //                {
        //                    tempAttachmentBindingNavigatorSaveItem.PerformClick();
        //                    close = "closed";
        //                    this.Close();
        //                }
        //                if (result1 == DialogResult.No)
        //                {

        //                    close = "closed";
        //                    this.Close();
        //                }

        //            }
        //            else
        //            {

        //                close = "closed";
        //                this.Close();
        //            }
        //        }



        //    }

        //    if (((keyData & Keys.Alt) == Keys.Alt) || ((keyData & Keys.Shift) == Keys.Shift))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {
                if (keyData == Keys.Escape)
                {
                    if (!chechupdatestate)
                    {
                        DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                        if (result1 == DialogResult.Yes)
                        {
                            tempAttachmentBindingNavigatorSaveItem.PerformClick();
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
                            return true; // وقف الإغلاق، وكأنك ألغيت العملية
                        }
                    }
                    else
                    {
                        close = "closed";
                        this.Close();
                    }
                }
            }

            if (((keyData & Keys.Alt) == Keys.Alt) || ((keyData & Keys.Shift) == Keys.Shift))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //private void TempAttach_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (close != "closed")
        //    {

        //        if (!chechupdatestate)
        //        {

        //            DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

        //            if (result1 == DialogResult.Yes)
        //            {
        //                tempAttachmentBindingNavigatorSaveItem.PerformClick();

        //            }


        //        }
        //        close = "closed";
        //        this.Close();
        //    }
        //    close = "";

        //}
        private void TempAttach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close != "closed")
            {
                if (!chechupdatestate)
                {
                    DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk,
                        MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                    if (result1 == DialogResult.Yes)
                    {
                        tempAttachmentBindingNavigatorSaveItem.PerformClick();
                    }
                    else if (result1 == DialogResult.Cancel)
                    {
                        e.Cancel = true; // وقف الإغلاق
                        return;
                    }
                }
                close = "closed";
                this.Close();
            }
            close = "";
        }


    }

}
