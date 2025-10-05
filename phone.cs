using Microsoft.Win32;
using RealStateRentSystem.DSTables;
using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RealStateRentSystem
{
    public partial class phone : Form
    {

        public string savecliced = "";

        public static string close = "";
        public Boolean actived = false;
        public Boolean soso = false;
        public HMessageBox SnewMessageBox;
        public string clicked = "";
        public string ss = "go";
        public int recored_id;
        public string am;
        public string back;
        public static Boolean continues = false;
        public Boolean change = false;
        private OpenFileDialog fdlg = new OpenFileDialog();
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
        private DSTables.DSTempAttchTableAdapters.TempAttachmentTableAdapter TempTableAdapterManager = new DSTables.DSTempAttchTableAdapters.TempAttachmentTableAdapter();
        public Boolean chechupdatestate = true;
        private System.Windows.Forms.ToolTip m_wndToolTip;

        public string toDo = "";
        public string toDophne = "";
        public string toDomop = "";
        public string toDoother = "";
        RelatedRecordsForm f;

        public phone()
        {
            InitializeComponent();
            menuPhones = new ContextMenuStrip();
            menuPhones.ItemClicked += MenuTypes_ItemClicked;
        }
        private void phone_Load(object sender, EventArgs e)
        {
            //btnCall1.Tag = (m2TextBox, m2Label);
            //btnCall2.Tag = (m3TextBox, m3Label);
            //btnCall3.Tag = (p1TextBox, p1Label);
            //btnCall4.Tag = (p2TextBox, p2Label);

            m2TextBox.TextChanged += p1TextBox_TextChanged;

            // استدعاء أول مرة للتحقق عند التحميل
            CheckOtherRecords();

        }



        private void CheckOtherRecords()
        {
            Utils.CheckOtherRecord = true;

            // Collect all numbers from the textboxes
            List<string> numbers = new List<string>();
            if (!string.IsNullOrWhiteSpace(m2TextBox.Text)) numbers.Add(m2TextBox.Text.Trim());
            if (!string.IsNullOrWhiteSpace(m3TextBox.Text)) numbers.Add(m3TextBox.Text.Trim());
            if (!string.IsNullOrWhiteSpace(p1TextBox.Text)) numbers.Add(p1TextBox.Text.Trim());
            if (!string.IsNullOrWhiteSpace(p2TextBox.Text)) numbers.Add(p2TextBox.Text.Trim());

            if (numbers.Count > 0)
            {
                // Pass the list of numbers to Form1
                f = new RelatedRecordsForm(numbers, "", "", "0", Utils.PhoneID.ToString());

                if (f.totalRecordsFound > 0) // Use new property in Form1
                {
                    otherRecordsBtn.Visible = true;
                    otherRecordsBtn.Text = $"سجلات أخري ({f.totalRecordsFound})"; // Show record count
                }
                else
                {
                    otherRecordsBtn.Visible = false;
                }
            }
            else
            {
                otherRecordsBtn.Visible = false;
            }
        }



        private void phoneBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            int esra2;
            if (clicked == "clicked")
            {
                soso = false;
                esra2 = 0;
                clicked = "dd";
            }
            else
            {
                soso = checkduplicate();
                esra2 = Utils.PhoneID;
            }

            if (!soso)
            {
                if (((Utils.checkexistPhone(nameTextBox.Text, p1TextBox.Text, p2TextBox.Text, m2TextBox.Text, m3TextBox.Text, esra2).Rows.Count <= 0) || continues) || gnon == "del")
                {

                    dataofchangedDateTimePicker.Value = DateTime.Now;
                    userTextBox.Text = Utils.current_user;
                    this.Validate();
                    this.phoneEventBindingSource.EndEdit();
                    this.phoneBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.dSphone);
                    this.phoneTableAdapter.Fill(this.dSphone.Phone);
                    this.phoneEventTableAdapter.Fill(this.dSphone.phoneEvent);
                    Utils.PhoneID = Convert.ToInt32(((DSphone.PhoneRow)this.dSphone.Phone.Rows[phoneBindingSource.Position]).ID);
                    chechupdatestate = true;

                }
                else
                {
                    DSphoneSearch.PhoneDataTable dt = (DSphoneSearch.PhoneDataTable)Utils.checkexistPhone(nameTextBox.Text, p1TextBox.Text, p2TextBox.Text, m2TextBox.Text, m3TextBox.Text, esra2);
                    string g = CheckPhone.ShowMe(dt);
                    if (g == "kml")
                    {
                        continues = true;
                        phoneBindingNavigatorSaveItem.PerformClick();
                    }
                    if (g == "cancel")
                    {
                        continues = false;
                        nameTextBox.Focus();
                    }
                    continues = false;
                }
            }
            else
            {

                dataofchangedDateTimePicker.Value = DateTime.Now;
                userTextBox.Text = Utils.current_user;
                this.Validate();
                this.phoneEventBindingSource.EndEdit();
                this.phoneBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dSphone);
                this.phoneTableAdapter.Fill(this.dSphone.Phone);
                this.phoneEventTableAdapter.Fill(this.dSphone.phoneEvent);
                Utils.PhoneID = Convert.ToInt32(((DSphone.PhoneRow)this.dSphone.Phone.Rows[phoneBindingSource.Position]).ID);
                chechupdatestate = true;
            }


            Utils.CallName = nameTextBox.Text;
            Utils.CallPlaceID = ",p" + Utils.PhoneID;
            Utils.CallPlace = "," + "هاتف";

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            btnCall1.Tag = (m2TextBox, m2Label);
            btnCall2.Tag = (m3TextBox, m3Label);
            btnCall3.Tag = (p1TextBox, p1Label);
            btnCall4.Tag = (p2TextBox, p2Label);

            m2TextBox.TextChanged += p1TextBox_TextChanged;
            m3TextBox.TextChanged += (s, ev) => CheckOtherRecords();

            // استدعاء أول مرة للتحقق عند التحميل
            CheckOtherRecords();


            // TODO: This line of code loads data into the 'dSphone.PhoneAttach' table. You can move, or remove it, as needed.
            this.phoneAttachTableAdapter.Fill(this.dSphone.PhoneAttach);
            // TODO: This line of code loads data into the 'dSphone.phoneEvent' table. You can move, or remove it, as needed.
            this.phoneEventTableAdapter.Fill(this.dSphone.phoneEvent);
            // TODO: This line of code loads data into the 'dSphone.Phone' table. You can move, or remove it, as needed.
            this.phoneTableAdapter.Fill(this.dSphone.Phone);

            this.m_wndToolTip = new System.Windows.Forms.ToolTip(this.components);
            m_wndToolTip.ShowAlways = true;

            encrypt();
            if (am == "Search")
            {
                this.Text = "بحث";
                bindingNavigatorAddNewItem.Enabled = false;
            }
            Utils.PhoneID = Convert.ToInt32(((DSphone.PhoneRow)this.dSphone.Phone.Rows[phoneBindingSource.Position]).ID);

            if (recored_id > 0)
            {
                this.phoneTableAdapter.FillBy(this.dSphone.Phone, recored_id);
                bindingNavigatorAddNewItem.Enabled = false;
                Utils.PhoneID = recored_id;
            }


            if (toDo == "new")
            {
                bindingNavigatorAddNewItem.PerformClick();
                p1TextBox.Text = toDophne;
                otherTextBox.Text = toDoother;
                m2TextBox.Text = toDomop;

            }


        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            if (this.dSphone.Phone.Rows.Count >= phoneBindingSource.Count)
            {

                eventuserTextBox.Text = Utils.current_user.ToString();
                eventTextBox.ReadOnly = false;
                eventTextBox.Focus();
                dateDateTimePicker.Value = DateTime.Now.AddDays(-2).AddMonths(-2).AddYears(-2);
                dateDateTimePicker.Value = DateTime.Now;
                chechupdatestate = false;
            }
            else
            {

                MessageBox.Show("قم بالحفظ قبل");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (this.dSphone.Phone.Rows.Count >= phoneBindingSource.Count)
            {
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
                    string fullname = yy + Utils.PhoneID + ext;
                    if (!(GetFileExisting(fullname)))
                    {
                        textBox4.Text = Utils.ProjectName + "\\" + fdlg.SafeFileName;
                    }
                    else
                    {
                        MessageBox.Show("الملف موجود من قبل");
                    }
                }
            }
            else
            {

                MessageBox.Show("قم بالحفظ قبل");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            PhoneattachComment.ShowMe();
            string result = PhoneattachComment.Button_Clicked;
            if (result != "")
            {

                if (textBox4.Text != null && textBox4.Text != "")
                {
                    string filename = fdlg.SafeFileName;
                    string ext = filename.Substring(filename.LastIndexOf("."));
                    string yy = filename.Substring(0, filename.LastIndexOf("."));
                    string fullname = yy + Utils.PhoneID + ext;
                    int id = Convert.ToInt32(((DSphone.PhoneRow)this.dSphone.Phone.Rows[phoneBindingSource.Position]).ID);

                    this.phoneAttachTableAdapter.Insert(id, fullname, fdlg.FileName, DateTime.Now.Date, result);
                    File.Copy(fdlg.FileName, Utils.ProjectName + "\\PhoneAttach\\" + fullname);
                    MessageBox.Show("تم الحفظ");

                    this.phoneAttachTableAdapter.Fill(this.dSphone.PhoneAttach);

                    textBox4.Text = "";


                }

                else
                {

                    int idatt = Convert.ToInt32(phoneAttachDataGridView.CurrentRow.Cells[0].Value);
                    this.phoneAttachTableAdapter.UpdateQuery(result, idatt);
                    this.phoneAttachTableAdapter.Fill(this.dSphone.PhoneAttach);
                }
            }

            else
            {

                MessageBox.Show("الرجاء ادخال النص");
            }
        }

        private bool GetFileExisting(string filename)
        {
            if (File.Exists(Utils.ProjectName + "\\PhoneAttach\\" + filename))
            {
                return true;
            }

            else
            {
                return false;
            }


        }

        private void toolStripButton3_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result1 = MessageBox.Show("هل تريد حذف المرفق ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            DialogResult result2;

            if (result1 == DialogResult.Yes)
            {
                result2 = MessageBox.Show("هل انت متأكد من حذف المرفق ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (result2 == DialogResult.Yes)
                {
                    string path = phoneAttachDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
                    if (File.Exists(Utils.ProjectName + "\\PhoneAttach\\" + path))
                    {
                        File.Delete(Utils.ProjectName + "\\PhoneAttach\\" + path);
                        chechupdatestate = false;
                        toolStripButton3.PerformClick();
                        phoneBindingNavigatorSaveItem.PerformClick();
                    }

                    else
                    {
                        MessageBox.Show("الملف غير موجود");
                    }
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (phoneAttachDataGridView.CurrentCell.OwningColumn.Index == 2)
            //{
            //    string path = phoneAttachDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();

            //    if ((GetFileExisting(path)))
            //    {
            //        System.Diagnostics.Process.Start(Utils.ProjectName + "\\attachment\\PhoneAttach\\" + path);

            //    }
            if (phoneAttachDataGridView.CurrentCell.OwningColumn.Index == 2)
            {
                string path = phoneAttachDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();

                if ((GetFileExisting(path)))
                {
                    if (File.Exists(@"d:\myFile.txt"))
                    {
                        File.Delete(@"d:\myFile.txt");
                    }
                    using (StreamWriter w = File.AppendText(@"d:\myFile.txt"))
                    {
                        w.WriteLine(Utils.ProjectName + "\\PhoneAttach\\" + path);
                    }
                    System.Diagnostics.Process.Start(Utils.ProjectName + "\\PhoneAttach\\" + path);

                }

                else
                {
                    MessageBox.Show("الملف غير موجود");
                }
            }
        }

        public void encrypt()
        {
            if (Utils.EncryptMode)
            {


                nameTextBox.ForeColor = Color.White;
                p1TextBox.ForeColor = Color.White;
                p2TextBox.ForeColor = Color.White;
                m2TextBox.ForeColor = Color.White;
                m3TextBox.ForeColor = Color.White;
                otherTextBox.ForeColor = Color.White;

                eventTextBox.ReadOnly = false;
                eventTextBox.ForeColor = Color.White;
                dataGridViewTextBoxColumn5.Visible = false;


                //MainForm.Imagencrypt.Visible = true;
                //MainForm.Imagencrypt2.Visible = true;
            }
            if (!Utils.EncryptMode)
            {
                nameTextBox.ForeColor = Color.Black;
                p1TextBox.ForeColor = Color.Black;
                p2TextBox.ForeColor = Color.Black;
                m2TextBox.ForeColor = Color.Black;
                m3TextBox.ForeColor = Color.Black;
                otherTextBox.ForeColor = Color.Black;


                eventTextBox.ReadOnly = true;
                eventTextBox.ForeColor = Color.Black;
                dataGridViewTextBoxColumn5.Visible = true;

                //MainForm.Imagencrypt.Visible = false;
                //MainForm.Imagencrypt2.Visible = false;

            }

        }
        public Boolean checkduplicate()
        {
            Boolean forme = true;
            string name = "";
            string p1 = "";
            string p2 = "";
            string m1 = "";
            string m2 = "";
            ////////////////////////////////////////////////////////////////////////////
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT ID from Phone WHERE ";

            if (nameTextBox.Text != "")
            {
                name = nameTextBox.Text;
                SqlStatement += " Phone.Name = '" + name + "'";
                SqlStatement += " and ";

            }

            if (p1TextBox.Text != "")
            {
                p1 = p1TextBox.Text;
                SqlStatement += " Phone.p1 = '" + p1 + "'";
                SqlStatement += " and ";


            }
            if (p2TextBox.Text.ToString() != "")
            {
                p2 = p2TextBox.Text;
                SqlStatement += " Phone.p2 = '" + p2 + "'";
                SqlStatement += " and ";

            }


            if (m2TextBox.Text.ToString() != "")
            {
                m1 = m2TextBox.Text;
                SqlStatement += " Phone.m2 = '" + m1 + "'";
                SqlStatement += " and ";

            }

            if (m3TextBox.Text.ToString() != "")
            {
                m2 = m3TextBox.Text;
                SqlStatement += " Phone.m3 = '" + m2 + "'";
                SqlStatement += " and ";

            }

            //////////////////////////////////////////////////////////////////////////////
            if (SqlStatement != "SELECT ID from Phone WHERE ")
            {
                SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and")) + "and id=" + Utils.PhoneID;
                OleDbConnection conn = new OleDbConnection(serverConnectionString);
                try
                {
                    conn.Open();
                    OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    conn.Close();
                    conn.Dispose();
                    sda.Dispose();
                    if (dt.Rows.Count > 0)
                        forme = true;
                    else
                        forme = false;
                }
                catch (Exception)
                {
                    throw;

                }
            }

            return forme;

        }

        public Boolean checkupdate()
        {
            Boolean forme = true;
            string name = "";
            string p1 = "";
            string p2 = "";
            string m1 = "";
            string m2 = "";
            string note = "";
            string other = "";
            ////////////////////////////////////////////////////////////////////////////
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT ID from Phone WHERE ";

            if (nameTextBox.Text != "")
            {
                name = nameTextBox.Text;
                SqlStatement += " Phone.Name = '" + name + "'";
                SqlStatement += " and ";

            }

            if (p1TextBox.Text != "")
            {
                p1 = p1TextBox.Text;
                SqlStatement += " Phone.p1 = '" + p1 + "'";
                SqlStatement += " and ";


            }
            if (p2TextBox.Text.ToString() != "")
            {
                p2 = p2TextBox.Text;
                SqlStatement += " Phone.p2 = '" + p2 + "'";
                SqlStatement += " and ";

            }


            if (m2TextBox.Text.ToString() != "")
            {
                m1 = m2TextBox.Text;
                SqlStatement += " Phone.m2 = '" + m1 + "'";
                SqlStatement += " and ";

            }

            if (m3TextBox.Text.ToString() != "")
            {
                m2 = m3TextBox.Text;
                SqlStatement += " Phone.m3 = '" + m2 + "'";
                SqlStatement += " and ";

            }

            if (notesTextBox.Text.ToString() != "")
            {
                note = notesTextBox.Text;
                SqlStatement += " Phone.notes = '" + note + "'";
                SqlStatement += " and ";

            }

            if (otherTextBox.Text.ToString() != "")
            {
                other = otherTextBox.Text;
                SqlStatement += " Phone.other = '" + other + "'";
                SqlStatement += " and ";

            }
            //////////////////////////////////////////////////////////////////////////////
            if (SqlStatement != "SELECT ID from Phone WHERE ")
            {
                SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and")) + "and id=" + Utils.PhoneID;
                OleDbConnection conn = new OleDbConnection(serverConnectionString);
                try
                {
                    conn.Open();
                    OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    conn.Close();
                    conn.Dispose();
                    sda.Dispose();
                    if (dt.Rows.Count > 0)
                        forme = true;
                    else
                        forme = false;
                }
                catch (Exception)
                {
                    throw;

                }
            }

            return forme;

        }
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Escape)
        //    {

        //        if (!chechupdatestate || !checkupdate())
        //        {

        //            DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

        //            if (result1 == DialogResult.Yes)
        //            {
        //                phoneBindingNavigatorSaveItem.PerformClick();
        //                close = "closed";
        //                this.Close();
        //            }
        //            if (result1 == DialogResult.No)
        //            {

        //                close = "closed";
        //                this.Close();
        //            }
        //        }
        //        else
        //        {

        //            close = "closed";
        //            this.Close();
        //        }
        //    }

        //    if (keyData == Keys.F2)
        //    {


        //        phoneBindingNavigatorSaveItem.PerformClick();
        //        return true;
        //    }

        //    if (keyData == Keys.F5)
        //    {

        //        phoneBindingNavigatorSaveItem.PerformClick();
        //        bindingNavigatorAddNewItem.PerformClick();
        //        nameTextBox.Focus();
        //        return true;

        //    }

        //    if (keyData == Keys.F11)
        //    {

        //        Utils.EncryptMode = !Utils.EncryptMode;
        //        encrypt();
        //        return true;

        //    }

        //    if (keyData == Keys.F1)
        //    {

        //        back = "back";
        //        this.Close();
        //        return true;

        //    }


        //    if (((keyData & Keys.Alt) == Keys.Alt))
        //    {
        //        return true;
        //    }

        //    if (((keyData & Keys.Shift) == Keys.Shift) && ((keyData & Keys.F10) == Keys.F10))
        //    {
        //        return true;
        //    }

        //    return false;
        //}
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (!chechupdatestate || !checkupdate())
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
                        phoneBindingNavigatorSaveItem.PerformClick();
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
                        // البقاء في الفورم وعدم الإغلاق
                        return true; // وقف المعالجة هنا
                    }
                }
                else
                {
                    close = "closed";
                    this.Close();
                }

                return true; // منع أي أكشن إضافي للـ ESC
            }

            if (keyData == Keys.F2)
            {
                phoneBindingNavigatorSaveItem.PerformClick();
                return true;
            }

            if (keyData == Keys.F5)
            {
                phoneBindingNavigatorSaveItem.PerformClick();
                bindingNavigatorAddNewItem.PerformClick();
                nameTextBox.Focus();
                return true;
            }

            if (keyData == Keys.F11)
            {
                Utils.EncryptMode = !Utils.EncryptMode;
                encrypt();
                return true;
            }

            if (keyData == Keys.F1)
            {
                back = "back";
                this.Close();
                return true;
            }

            if (((keyData & Keys.Alt) == Keys.Alt))
            {
                return true;
            }

            if (((keyData & Keys.Shift) == Keys.Shift) && ((keyData & Keys.F10) == Keys.F10))
            {
                return true;
            }

            return false;
        }

        string gnon = "";
        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result1 = MessageBox.Show("هل تريد حذف السجل ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            DialogResult result2;

            if (result1 == DialogResult.Yes)
            {
                result2 = MessageBox.Show("هل انت متأكد من حذف السجل ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (result2 == DialogResult.Yes)
                {
                    Utils.deleteventattachphon(Utils.PhoneID);
                    bindingNavigatorDeleteItem.PerformClick();
                    //continues = true;
                    gnon = "del";
                    phoneBindingNavigatorSaveItem.PerformClick();


                }

            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            Utils.PhoneID = Convert.ToInt32(((DSphone.PhoneRow)this.dSphone.Phone.Rows[phoneBindingSource.Position]).ID);
            // TODO: This line of code loads data into the 'dSphone.phoneEvent' table. You can move, or remove it, as needed.
            this.phoneEventTableAdapter.Fill(this.dSphone.phoneEvent);
        }

        private void bindingNavigatorDeleteItem1_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result1 = MessageBox.Show("هل تريد حذف الحدث ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            DialogResult result2;

            if (result1 == DialogResult.Yes)
            {
                result2 = MessageBox.Show("هل انت متأكد من حذف الحدث ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (result2 == DialogResult.Yes)
                {
                    bindingNavigatorDeleteItem1.PerformClick();
                    chechupdatestate = false;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((DSphone.PhoneRow)this.dSphone.Phone.Rows[phoneBindingSource.Position]).ID);
            this.phoneEventTableAdapter.FillByseach(this.dSphone.phoneEvent, id, "%" + searchtext.Text + "%", "%" + searchtext.Text + "%");
        }

        private void eventTextBox_Leave(object sender, EventArgs e)
        {
            eventTextBox.ReadOnly = true;
        }

        private void phoneEventDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            eventTextBox.ReadOnly = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close != "closed")
            {


                if (!chechupdatestate || !checkupdate())
                {

                    DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                    if (result1 == DialogResult.Yes)
                    {
                        phoneBindingNavigatorSaveItem.PerformClick();
                        close = "closed";
                        this.Close();
                    }
                    if (result1 == DialogResult.No)
                    {

                        close = "closed";
                        this.Close();
                    }
                    if (result1 == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }

                }

            }
            close = "";

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (clicked == "clicked")
            {
                phoneBindingNavigatorSaveItem.PerformClick();
                dataofchangedDateTimePicker.Value = DateTime.Now;
                userTextBox.Text = Utils.current_user;
                chechupdatestate = false;
                this.clicked = "clicked";

            }
            else
            {

                dataofchangedDateTimePicker.Value = DateTime.Now;
                userTextBox.Text = Utils.current_user;
                chechupdatestate = false;
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

        private void p1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (p1TextBox.Text.Length == Utils.PhoneNumerLength)
            {
                Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gp1.BackColor = System.Drawing.Color.Red;
                Gp1.ForeColor = System.Drawing.Color.Red;
            }

            if (p2TextBox.Text.Length == Utils.PhoneNumerLength)
            {
                Gp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gp2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gp2.BackColor = System.Drawing.Color.Red;
                Gp2.ForeColor = System.Drawing.Color.Red;
            }

            if (m2TextBox.Text.Length == Utils.MobileNumerLength)
            {
                Gm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gm1.BackColor = System.Drawing.Color.Red;
                Gm1.ForeColor = System.Drawing.Color.Red;
            }

            if (m3TextBox.Text.Length == Utils.MobileNumerLength)
            {
                Gm2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gm2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gm2.BackColor = System.Drawing.Color.Red;
                Gm2.ForeColor = System.Drawing.Color.Red;
            }


        }

        private void eventTextBox_MouseDown(object sender, MouseEventArgs e)
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

        private void eventTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string[] keys = e.KeyData.ToString().Split(',');
            if (keys.Length == 2)
            {
                try
                {
                    DataTable t = new DataTable();
                    t = shorCutKeysTableAdapter.GetDataBy(keys[1].Trim().ToString(), keys[0].Trim().ToString());
                    if (t.Rows.Count > 0)
                    {
                        if ((keys[1].Trim().ToString() == "Control") && (keys[0].Trim().ToString() == "Z"))
                        {
                            this.ActiveControl.Text = "";
                            this.ActiveControl.Text = t.Rows[0]["Text"].ToString();
                            ((System.Windows.Forms.TextBox)this.ActiveControl).SelectionStart = this.ActiveControl.Text.Length + 1;
                        }
                        else
                        {
                            this.ActiveControl.Text += t.Rows[0]["Text"].ToString();
                            ((System.Windows.Forms.TextBox)this.ActiveControl).SelectionStart = this.ActiveControl.Text.Length + 1;
                        }


                    }
                }
                catch
                {

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Utils.mode != null)
            {
                if (p1TextBox.Text.Length == Utils.PhoneNumerLength)
                {
                    double Num;
                    bool isNum = double.TryParse(p1TextBox.Text, out Num);
                    if (isNum)
                    {
                        Utils.mode.Call(p1TextBox.Text);
                        Redail.ShowMe();
                    }

                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Utils.mode != null)
            {
                if (p2TextBox.Text.Length == Utils.PhoneNumerLength)
                {
                    double Num;
                    bool isNum = double.TryParse(p2TextBox.Text, out Num);
                    if (isNum)
                    {
                        Utils.mode.Call(p2TextBox.Text);
                        Redail.ShowMe();
                    }

                }
            }

        }


        public static string NormalizePhoneNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            input = input.Trim();
            input = new string(input.Where(c => Char.IsDigit(c)).ToArray());  // إزالة أي رموز غير الأرقام

            if (input.StartsWith("09"))
            {
                return "963" + input.Substring(1);
            }
            else if (input.StartsWith("00"))
            {
                return input.Substring(2);
            }
            else if (input.StartsWith("++"))
            {
                return input.Substring(2);
            }
            else if (input.StartsWith("+"))
            {
                return input.Substring(1);
            }
            else
            {
                return input;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string originalPhoneNumber = m2TextBox.Text.Trim();
            string normalizedPhoneNumber = NormalizePhoneNumber(originalPhoneNumber);

            if (string.IsNullOrEmpty(normalizedPhoneNumber))
            {
                MessageBox.Show("رقم الهاتف غير صحيح!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string url = $"https://wa.me/{normalizedPhoneNumber}";

            try
            {
                Clipboard.SetText(url);
                //MessageBox.Show("تم نسخ رابط الواتساب إلى الحافظة.");
                Process.Start(url);
            }
            catch
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string originalPhoneNumber = m3TextBox.Text.Trim();
            string normalizedPhoneNumber = NormalizePhoneNumber(originalPhoneNumber);

            if (string.IsNullOrEmpty(normalizedPhoneNumber))
            {
                MessageBox.Show("رقم الهاتف غير صحيح!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string url = $"https://wa.me/{normalizedPhoneNumber}";

            try
            {
                Clipboard.SetText(url);
                //MessageBox.Show("تم نسخ رابط الواتساب إلى الحافظة.");
                Process.Start(url);
            }
            catch
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
        }


        #region Export calling

        private ContextMenuStrip menuPhones;
        private string targetPhoneNumber;
        private string exportCallingLink = clsSettingsCalling.LoadSettings().ExportLink;
        private string secretKey = "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il"; // TODO: من الإعدادات

        private void BtnCall_Click(object sender, EventArgs e)
        {
            menuPhones.Items.Clear();

            var currentUser = clsSettingsCalling.GetUserByName(Utils.current_user);
            if (currentUser == null) return;

            List<clsSettingsCalling.UserPhoneInfo> finalList;
            if (currentUser.PhoneRestriction)
            {
                finalList = new List<clsSettingsCalling.UserPhoneInfo> { currentUser };
            }
            else
            {
                finalList = clsSettingsCalling.GetAllUsers();
                finalList.RemoveAll(u => u.UserName == currentUser.UserName);
                finalList.Insert(0, currentUser);
            }

            var btn = sender as System.Windows.Forms.Button;
            if (btn == null) return;

            var related = ((System.Windows.Forms.TextBox textBox, Label label))btn.Tag;
            System.Windows.Forms.TextBox relatedTextBox = related.textBox;
            Label relatedLabel = related.label;

            // ✅ Remove duplicates based on PhoneName
            var distinctPhones = finalList
                .Where(u => !string.IsNullOrWhiteSpace(u.PhoneName))
                .GroupBy(u => u.PhoneName)
                .Select(g => g.First()) // Take first occurrence for each PhoneName
                .ToList();

            foreach (var user in distinctPhones)
            {
                var phoneItem = new ToolStripMenuItem($"{user.PhoneName}")
                {
                    ForeColor = Color.Black
                };

                if (!relatedLabel.Text.Contains("هاتف"))
                {
                    var wItem = new ToolStripMenuItem("W")
                    {
                        Tag = (user.PhoneName, "W", btn)
                    };
                    wItem.Click += MenuTypes_ItemClicked;
                    phoneItem.DropDownItems.Add(wItem);
                }

                var nItem = new ToolStripMenuItem("N")
                {
                    Tag = (user.PhoneName, "N", btn)
                };
                nItem.Click += MenuTypes_ItemClicked;
                phoneItem.DropDownItems.Add(nItem);

                menuPhones.Items.Add(phoneItem);
            }

            menuPhones.RightToLeft = RightToLeft.No;
            this.Update();
            menuPhones.Show(btn, new Point(btn.Width + menuPhones.Width, 0));
        }

        private void MenuTypes_ItemClicked(object sender, EventArgs e)
        {
            var clickedItem = sender as ToolStripMenuItem;
            if (clickedItem == null) return;

            var tag = ((string phoneName, string numberType, System.Windows.Forms.Button btn))clickedItem.Tag;
            string phoneName = tag.phoneName;
            string numberType = tag.numberType;
            System.Windows.Forms.Button btn = tag.btn;

            if (btn == null) return;

            var related = ((System.Windows.Forms.TextBox textBox, Label label))btn.Tag;
            System.Windows.Forms.TextBox relatedTextBox = related.textBox;
            Label relatedLabel = related.label;

            if (relatedTextBox == null || string.IsNullOrEmpty(relatedTextBox.Text))
                return;

            targetPhoneNumber = relatedTextBox.Text;

            if (relatedLabel.Text.Contains("هاتف"))
            {
                targetPhoneNumber = "011" + targetPhoneNumber;
            }

            // Call API
            bool success = ApiManager.ExportCall(exportCallingLink, targetPhoneNumber, phoneName, numberType, secretKey);

            if (success)
                ShowTempMessage("تم إرسال الاتصال بنجاح", Color.Green);
            else
                ShowTempMessage("تعذر إرسال الطلب", Color.Red);
        }


        private void ShowTempMessage(string text, Color color)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.ForeColor = color;
            lbl.BackColor = Color.FromArgb(200, Color.White); // شفاف جزئياً مع خلفية
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // ضع الرسالة في منتصف الفورم أو حسب حاجتك
            lbl.Location = new Point((this.ClientSize.Width - lbl.PreferredWidth) / 2, 25);
            lbl.BringToFront(); // اجعلها فوق كل شيء
            this.Controls.Add(lbl);

            Timer timer = new Timer();
            timer.Interval = 5000; // 3 ثواني
            timer.Tick += (s, e) =>
            {
                this.Controls.Remove(lbl);
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }


        #endregion

        private void otherRecordsBtn_Click(object sender, EventArgs e)
        {
            f.ShowDialog();
        }
    }
}
