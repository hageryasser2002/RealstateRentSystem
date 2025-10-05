using Microsoft.Win32;
using RealStateRentSystem.DSTables;
using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;


namespace RealStateRentSystem
{
    public partial class career : Form
    {
        public string back;
        public string savecliced = "";
        public static string close = "";
        public Boolean actived = false;
        public Boolean soso = false;
        public HMessageBox SnewMessageBox;
        public string clicked = "";
        public string ss = "go";
        public int recored_id;
        public string am;
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
        public career()
        {
            InitializeComponent();
            menuPhones = new ContextMenuStrip();
            menuPhones.ItemClicked += MenuTypes_ItemClicked;

        }

        private void careerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
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
                esra2 = Utils.CareerID;
            }


            if (!soso)
            {
                if (((Utils.checkexistcareer(nameTextBox.Text, pTextBox.Text, mTextBox.Text, esra2).Rows.Count <= 0) || continues) || gnon == "del")
                {

                    dataofchangedDateTimePicker.Value = DateTime.Now;
                    this.Validate();
                    this.careerEventBindingSource.EndEdit();
                    this.careerAttachBindingSource.EndEdit();
                    this.careerBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.dScareer);
                    this.careerTableAdapter.Fill(this.dScareer.career);
                    this.careerEventTableAdapter.Fill(this.dScareer.careerEvent);
                    Utils.CareerID = Convert.ToInt32(((DScareer.careerRow)this.dScareer.career.Rows[careerBindingSource.Position]).ID);
                    chechupdatestate = true;


                }
                else
                {

                    DScareersearch.careerDataTable dt = (DScareersearch.careerDataTable)Utils.checkexistcareer(nameTextBox.Text, pTextBox.Text, mTextBox.Text, esra2);
                    string g = CheckCareer.ShowMe(dt);
                    if (g == "kml")
                    {
                        continues = true;
                        careerBindingNavigatorSaveItem.PerformClick();
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
                this.Validate();
                this.careerEventBindingSource.EndEdit();
                this.careerAttachBindingSource.EndEdit();
                this.careerBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dScareer);
                this.careerTableAdapter.Fill(this.dScareer.career);
                this.careerEventTableAdapter.Fill(this.dScareer.careerEvent);
                Utils.CareerID = Convert.ToInt32(((DScareer.careerRow)this.dScareer.career.Rows[careerBindingSource.Position]).ID);
                chechupdatestate = true;
            }

            Utils.CallName = nameTextBox.Text;
            Utils.CallPlaceID = ",m" + Utils.CareerID;
            Utils.CallPlace = "," + "مهن";

        }


        private void career_Load(object sender, EventArgs e)
        {
            btnCall1.Tag = (mTextBox, mLabel);
            btnCall2.Tag = (otherTextBox, otherLabel);
            btnCall3.Tag = (pTextBox, pLabel);

            mTextBox.TextChanged += pTextBox_TextChanged;
            mTextBox.TextChanged += (s, ev) => CheckOtherRecords();

            //استدعاء أول مرة للتحقق عند التحميل
            CheckOtherRecords();



            Top_panel.BackColor = Color.FromArgb(250, 163, 7);
            // TODO: This line of code loads data into the 'dScareer.careerEvent' table. You can move, or remove it, as needed.
            this.careerEventTableAdapter.Fill(this.dScareer.careerEvent);
            // TODO: This line of code loads data into the 'dScareer.careerCatog' table. You can move, or remove it, as needed.
            this.careerCatogTableAdapter.Fill(this.dScareer.careerCatog);
            // TODO: This line of code loads data into the 'dScareer.TypeOfcarrer' table. You can move, or remove it, as needed.
            this.typeOfcarrerTableAdapter.Fill(this.dScareer.TypeOfcarrer);
            // TODO: This line of code loads data into the 'dScareer.careerAttach' table. You can move, or remove it, as needed.
            this.careerAttachTableAdapter.Fill(this.dScareer.careerAttach);
            // TODO: This line of code loads data into the 'dScareer.careerEvent' table. You can move, or remove it, as needed.
            this.careerEventTableAdapter.Fill(this.dScareer.careerEvent);
            // TODO: This line of code loads data into the 'dScareer.career' table. You can move, or remove it, as needed.
            this.careerTableAdapter.Fill(this.dScareer.career);

            this.m_wndToolTip = new System.Windows.Forms.ToolTip(this.components);
            m_wndToolTip.ShowAlways = true;

            if (am == "Search")
            {
                this.Text = "بحث";
                bindingNavigatorAddNewItem.Enabled = false;
            }


            if (recored_id > 0)
            {
                this.careerTableAdapter.FillBy(this.dScareer.career, recored_id);
                bindingNavigatorAddNewItem.Enabled = false;

            }
            encrypt();

            if (careerBindingSource.Count > 0)
            {
                Utils.CareerID = Convert.ToInt32(((DScareer.careerRow)this.dScareer.career.Rows[careerBindingSource.Position]).ID);
            }
            if (recored_id > 0)
            {
                Utils.CareerID = recored_id;
            }


            if (toDo == "new")
            {
                bindingNavigatorAddNewItem.PerformClick();
                pTextBox.Text = toDophne;
                otherTextBox.Text = toDoother;
                mTextBox.Text = toDomop;

            }

        }

        private void CheckOtherRecords()
        {
            Utils.CheckOtherRecord = true;

            // Collect all numbers from the textboxes
            List<string> numbers = new List<string>();
            if (!string.IsNullOrWhiteSpace(pTextBox.Text)) numbers.Add(pTextBox.Text.Trim());
            if (!string.IsNullOrWhiteSpace(otherTextBox.Text)) numbers.Add(otherTextBox.Text.Trim());
            if (!string.IsNullOrWhiteSpace(mTextBox.Text)) numbers.Add(mTextBox.Text.Trim());

            if (numbers.Count > 0)
            {
                // Pass the list of numbers to Form1
                f = new RelatedRecordsForm(numbers, "", "", "0", Utils.CareerID.ToString());

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





        public Boolean checkduplicate()
        {
            Boolean forme = true;
            string name = "";
            string p1 = "";
            string m = "";
            ////////////////////////////////////////////////////////////////////////////
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT ID from career WHERE ";

            if (nameTextBox.Text != "")
            {

                name = nameTextBox.Text;
                SqlStatement += " career.Name = '" + name + "'";
                SqlStatement += " and ";

            }

            if (pTextBox.Text != "")
            {

                p1 = pTextBox.Text;
                SqlStatement += " career.p = '" + p1 + "'";
                SqlStatement += " and ";


            }
            if (mTextBox.Text.ToString() != "")
            {

                m = mTextBox.Text;
                SqlStatement += " career.m = '" + m + "'";
                SqlStatement += " and ";

            }

            //////////////////////////////////////////////////////////////////////////////
            if (SqlStatement != "SELECT ID from career WHERE ")
            {
                SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and")) + "and id=" + Utils.CareerID;
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
            string m = "";
            string type = "";
            string category = "";
            string note = "";
            string other = "";
            ////////////////////////////////////////////////////////////////////////////
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT ID from career WHERE ";

            if (nameTextBox.Text != "")
            {

                name = nameTextBox.Text;
                SqlStatement += " career.Name = '" + name + "'";
                SqlStatement += " and ";

            }

            if (pTextBox.Text != "")
            {

                p1 = pTextBox.Text;
                SqlStatement += " career.p = '" + p1 + "'";
                SqlStatement += " and ";


            }
            if (mTextBox.Text.ToString() != "")
            {

                m = mTextBox.Text;
                SqlStatement += " career.m = '" + m + "'";
                SqlStatement += " and ";

            }


            if (comboBox1.SelectedValue != null)
            {
                type = comboBox1.Text;
                SqlStatement += " career.careertype= '" + type + "'";
                SqlStatement += " and ";
            }
            if (comboBox2.Text.ToString() != "")
            {

                category = comboBox2.Text;
                SqlStatement += " career.category = '" + category + "'";
                SqlStatement += " and ";

            }

            if (notesTextBox.Text.ToString() != "")
            {

                note = notesTextBox.Text;
                SqlStatement += " career.notes = '" + note + "'";
                SqlStatement += " and ";

            }

            if (otherTextBox.Text.ToString() != "")
            {
                other = otherTextBox.Text;
                SqlStatement += " career.other = '" + other + "'";
                SqlStatement += " and ";

            }
            //////////////////////////////////////////////////////////////////////////////
            if (SqlStatement != "SELECT ID from career WHERE ")
            {
                SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and")) + "and id=" + Utils.CareerID;
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
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.dScareer.career.Rows.Count >= careerBindingSource.Count)
            {

                userTextBox1.Text = Utils.current_user.ToString();
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

        private void toolStripButton2_MouseDown(object sender, MouseEventArgs e)
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

        private void toolStripButton3_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result1 = MessageBox.Show("هل تريد حذف المرفق ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            DialogResult result2;

            if (result1 == DialogResult.Yes)
            {
                result2 = MessageBox.Show("هل انت متأكد من حذف المرفق ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (result2 == DialogResult.Yes)
                {
                    string path = careerAttachDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
                    if (File.Exists(Utils.ProjectName + "\\CareerAttach\\" + path))
                    {
                        File.Delete(Utils.ProjectName + "\\CareerAttach\\" + path);
                        chechupdatestate = false;
                        toolStripButton3.PerformClick();
                        careerBindingNavigatorSaveItem.PerformClick();
                    }

                    else
                    {
                        MessageBox.Show("الملف غير موجود");
                    }
                }

            }
        }

        private bool GetFileExisting(string filename)
        {
            if (File.Exists(Utils.ProjectName + "\\CareerAttach\\" + filename))
            {
                return true;
            }

            else
            {
                return false;
            }


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
        //                careerBindingNavigatorSaveItem.PerformClick();
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


        //        careerBindingNavigatorSaveItem.PerformClick();
        //        return true;
        //    }

        //    if (keyData == Keys.F5)
        //    {

        //        careerBindingNavigatorSaveItem.PerformClick();
        //        bindingNavigatorAddNewItem.PerformClick();
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
                        careerBindingNavigatorSaveItem.PerformClick();
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
                        // إلغاء الإغلاق
                        return true;
                    }
                }
                else
                {
                    close = "closed";
                    this.Close();
                }

                return true; // علشان يمنع أي معالجة إضافية للزر ESC
            }

            if (keyData == Keys.F2)
            {
                careerBindingNavigatorSaveItem.PerformClick();
                return true;
            }

            if (keyData == Keys.F5)
            {
                careerBindingNavigatorSaveItem.PerformClick();
                bindingNavigatorAddNewItem.PerformClick();
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

            return false;
        }

        public void encrypt()
        {
            if (Utils.EncryptMode)
            {



            }
            if (!Utils.EncryptMode)
            {



            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (clicked == "clicked")
            {
                careerBindingNavigatorSaveItem.PerformClick();
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

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            Utils.CareerID = Convert.ToInt32(((DScareer.careerRow)this.dScareer.career.Rows[careerBindingSource.Position]).ID);

            this.careerEventTableAdapter.Fill(this.dScareer.careerEvent);
        }

        //private void career_FormClosing(object sender, FormClosingEventArgs e)
        //{


        //    if (close != "closed")
        //    {

        //        if (!chechupdatestate || !checkupdate())
        //        {

        //            DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

        //            if (result1 == DialogResult.Yes)
        //            {
        //                careerBindingNavigatorSaveItem.PerformClick();
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
        private void career_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close != "closed")
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
                        careerBindingNavigatorSaveItem.PerformClick();
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
                        // منع الإغلاق والبقاء في نفس الفورم
                        e.Cancel = true;
                        return;
                    }
                }
            }

            close = "";
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
                    Utils.careerdeleteventattach(Utils.CareerID);
                    bindingNavigatorDeleteItem.PerformClick();
                    //continues = true;
                    gnon = "del";
                    careerBindingNavigatorSaveItem.PerformClick();


                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (this.dScareer.career.Rows.Count >= careerBindingSource.Count)

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
                    string fullname = yy + Utils.CareerID + ext;
                    if (!(GetFileExisting(fullname)))
                    {
                        textBox4.Text = Utils.ProjectName + "\\CareerAttach\\" + fdlg.SafeFileName;
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

            CareerattachComment.ShowMe();
            string result = CareerattachComment.Button_Clicked;
            if (result != "")
            {

                if (textBox4.Text != null && textBox4.Text != "")
                {
                    string filename = fdlg.SafeFileName;
                    string ext = filename.Substring(filename.LastIndexOf("."));
                    string yy = filename.Substring(0, filename.LastIndexOf("."));
                    string fullname = yy + Utils.CareerID + ext;
                    int id = Convert.ToInt32(((DScareer.careerRow)this.dScareer.career.Rows[careerBindingSource.Position]).ID);

                    this.careerAttachTableAdapter.Insert(id, fullname, fdlg.FileName, DateTime.Now.Date, result);
                    File.Copy(fdlg.FileName, Utils.ProjectName + "\\CareerAttach\\" + fullname);
                    MessageBox.Show("تم الحفظ");

                    this.careerAttachTableAdapter.Fill(this.dScareer.careerAttach);

                    textBox4.Text = "";


                }

                else
                {

                    int idatt = Convert.ToInt32(careerAttachDataGridView.CurrentRow.Cells[0].Value);
                    this.careerAttachTableAdapter.UpdateQuery(result, idatt);
                    this.careerAttachTableAdapter.Fill(this.dScareer.careerAttach);
                }
            }

            else
            {

                MessageBox.Show("الرجاء ادخال النص");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((DScareer.careerRow)this.dScareer.career.Rows[careerBindingSource.Position]).ID);

            this.careerEventTableAdapter.FillBy(this.dScareer.careerEvent, id, "%" + searchtext.Text + "%", "%" + searchtext.Text + "%");
        }

        private void careerEventDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            eventTextBox.ReadOnly = false;
        }

        private void eventTextBox_Leave(object sender, EventArgs e)
        {
            eventTextBox.ReadOnly = true;
        }


        private void careerAttachDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (careerAttachDataGridView.CurrentCell.OwningColumn.Index == 2)
            {
                string path = careerAttachDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();

                if ((GetFileExisting(path)))
                {
                    if (File.Exists(@"d:\myFile.txt"))
                    {
                        File.Delete(@"d:\myFile.txt");
                    }
                    using (StreamWriter w = File.AppendText(@"d:\myFile.txt"))
                    {
                        w.WriteLine(Utils.ProjectName + "\\CareerAttach\\" + path);
                    }
                    System.Diagnostics.Process.Start(Utils.ProjectName + "\\CareerAttach\\" + path);

                }

                else
                {
                    MessageBox.Show("الملف غير موجود");
                }
            }
        }

        private void pTextBox_TextChanged(object sender, EventArgs e)
        {

            if (pTextBox.Text.Length == Utils.PhoneNumerLength)
            {
                Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gp1.BackColor = System.Drawing.Color.Red;
                Gp1.ForeColor = System.Drawing.Color.Red;
            }

            if (mTextBox.Text.Length == Utils.MobileNumerLength)
            {
                Gm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gm1.BackColor = System.Drawing.Color.Red;
                Gm1.ForeColor = System.Drawing.Color.Red;
            }

            if (otherTextBox.Text.Length == Utils.MobileNumerLength)
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

        private void button6_Click(object sender, EventArgs e)
        {

            if (Utils.mode != null)
            {
                if (pTextBox.Text.Length == Utils.PhoneNumerLength)
                {
                    double Num;
                    bool isNum = double.TryParse(pTextBox.Text, out Num);
                    if (isNum)
                    {
                        Utils.mode.Call(pTextBox.Text);
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
            string rawPhone = mTextBox.Text;

            if (string.IsNullOrEmpty(rawPhone))
            {
                MessageBox.Show("من فضلك أدخل رقم الهاتف أولاً.");
                return;
            }

            string phone = NormalizePhoneNumber(rawPhone);
            string currentUsername = Utils.current_user;

            string message = $"مرحبا معك {currentUsername} من طموحات العقارية";
            string encodedMessage = Uri.EscapeDataString(message);

            string url = $"https://wa.me/{phone}?text={encodedMessage}";

            try
            {
                Clipboard.SetText(url);
                //MessageBox.Show("تم نسخ رابط الواتساب إلى الحافظة.");
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء فتح الرابط: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string rawPhone = otherTextBox.Text;

            if (string.IsNullOrEmpty(rawPhone))
            {
                MessageBox.Show("من فضلك أدخل رقم الهاتف أولاً.");
                return;
            }

            string phone = NormalizePhoneNumber(rawPhone);
            string currentUsername = Utils.current_user;

            string message = $"مرحبا معك {currentUsername} من طموحات العقارية";
            string encodedMessage = Uri.EscapeDataString(message);

            string url = $"https://wa.me/{phone}?text={encodedMessage}";

            try
            {
                Clipboard.SetText(url);
                //MessageBox.Show("تم نسخ رابط الواتساب إلى الحافظة.");
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء فتح الرابط: " + ex.Message);
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

            var btn = sender as Button;
            if (btn == null) return;

            var related = ((TextBox textBox, System.Windows.Forms.Label label))btn.Tag;
            TextBox relatedTextBox = related.textBox;
            System.Windows.Forms.Label relatedLabel = related.label;

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

            var tag = ((string phoneName, string numberType, Button btn))clickedItem.Tag;
            string phoneName = tag.phoneName;
            string numberType = tag.numberType;
            Button btn = tag.btn;

            if (btn == null) return;

            var related = ((TextBox textBox, System.Windows.Forms.Label label))btn.Tag;
            TextBox relatedTextBox = related.textBox;
            System.Windows.Forms.Label relatedLabel = related.label;

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
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.ForeColor = color;
            lbl.BackColor = Color.FromArgb(200, Color.White); // شفاف جزئياً مع خلفية
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // ضع الرسالة في منتصف الفورم أو حسب حاجتك
            lbl.Location = new Point((this.ClientSize.Width - lbl.PreferredWidth) / 2, 10);
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
