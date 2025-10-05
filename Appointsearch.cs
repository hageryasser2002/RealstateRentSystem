using RealStateRentSystem.DSTables;
using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class Appointsearch : Form
    {
        public int y;
        public int h;

        DSrealstatesearch.RealStateDataTable dt = new DSrealstatesearch.RealStateDataTable();
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();

        BindingSource bd;

        public Appointsearch(string where)
        {
            InitializeComponent();
            panel_closing.BringToFront();
            //MessageBox.Show(where);
            ChangeBorderColor();
            FillWidthColumns();

            y = DoQuery(where);
            encrypt();
        }

        /// <summary>
        /// Alter Floor Column
        /// </summary>
        /// 
        private void realStateDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // اتأكدي إن العمود الحالي هو floorDataGridViewTextBoxColumn
            if (realStateDataGridView.Columns[e.ColumnIndex].Name == "floorDataGridViewTextBoxColumn")
            {
                var row = realStateDataGridView.Rows[e.RowIndex];
                if (row.IsNewRow) return;

                string id = row.Cells["iDDataGridViewTextBoxColumn"].Value?.ToString();
                if (string.IsNullOrEmpty(id)) return;

                string floor = row.Cells["floorDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                string floorComment = clsRealState.GetFloorCommentById(id);

                e.Value = $"{floor}  {floorComment}".Trim();
                e.FormattingApplied = true;
            }
        }

        private void FillWidthColumns()
        {
            this.Size = new Size(MainForm.MainForm_Size.Width - 20, MainForm.MainForm_Size.Height - 100);
            this.Location = new Point(MainForm.MainForm_Location.X + 10, MainForm.MainForm_Location.Y + 100);

            realStateDataGridView.Location = new Point(this.Location.X, this.Location.Y - 48);
            realStateDataGridView.Size = new Size(this.Size.Width - 7, this.Size.Height - 45);
            realStateDataGridView.Columns["buildingDataGridViewTextBoxColumn"].Width = 200;
            realStateDataGridView.Columns["ownerDataGridViewTextBoxColumn"].Width = 200;
            realStateDataGridView.Columns["Building"].Width = 200;
            realStateDataGridView.Columns["Column1"].Width = 80;
            realStateDataGridView.Columns["iDDataGridViewTextBoxColumn"].Width = 110;
        }
        private void ChangeBorderColor()
        {

            Color color = Color.FromArgb(188, 71, 73);
            panel_top.BackColor = color;
            panel_bottom.BackColor = color;
            panel_left.BackColor = color;
            panel_right.BackColor = color;

        }
        public Appointsearch(DSrealstatesearch.RealStateDataTable pdt)
        {
            InitializeComponent();
            dt = (DSrealstatesearch.RealStateDataTable)pdt;
            realStateBindingSource.DataSource = dt;
            realStateDataGridView.DataSource = realStateBindingSource;
            realStateDataGridView.Refresh();
            encrypt();

            RowCount_lbl.Text = dt.Count.ToString();

        }
        public void encrypt()
        {
            if (Utils.EncryptMode)
            {

                Building.Visible = false;
                ownerDataGridViewTextBoxColumn.Visible = false;

            }
            if (!Utils.EncryptMode)
            {

                Building.Visible = true;
                ownerDataGridViewTextBoxColumn.Visible = true;

            }

        }
        private void Appointsearch_Load(object sender, EventArgs e)
        {
            //
            realStateDataGridView.CellFormatting += realStateDataGridView_CellFormatting;

            realStateDataGridView.BeginEdit(true);
            if (Utils.RentRecord == true)
            {
                startrecord();
            }

            if (Utils.RentRecord == false)
            {
                //stoprecord();
            }

            ChangeBorderColor();
            FillWidthColumns();

            ///
            //ApplyFloorLabels();
        }

        public int DoQuery(string clouse)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            try
            {
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(clouse, conn);
                dt = new DSrealstatesearch.RealStateDataTable();
                this.dSrealstatesearch.Clear();
                // ⛔ تعطيل التحقق من القيود في الـ DataSet كله
                this.dSrealstatesearch.EnforceConstraints = false;
                // استخدم DataTable عادية بدون تصميم داخلي
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                if (dtt.Rows.Count > 0)
                {
                    RowCount_lbl.Text = dtt.Rows.Count.ToString();
                    realStateBindingSource.DataSource = dtt;
                    realStateDataGridView.DataSource = realStateBindingSource;
                    realStateDataGridView.Refresh();
                    conn.Close();
                    conn.Dispose();
                    return 1;
                    // }
                }
                else
                {


                    realStateBindingSource.DataSource = dt;
                    realStateDataGridView.Refresh();
                    conn.Close();
                    conn.Dispose();
                    return 0;

                }
            }
            catch
            {
                conn.Close();
                conn.Dispose();
                return 0;
            }
        }

        //************************************

        //******************************************
        private void realStateDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            realStateDataGridView.EndEdit();
            Realstate u = new Realstate();
            try
            {
                if (e.ColumnIndex == 2)
                {
                    //  u.MdiParent = this.MdiParent;
                    u.recored_id = Convert.ToInt32(realStateDataGridView.CurrentCell
                                    .OwningRow.Cells["iDDataGridViewTextBoxColumn"].Value.ToString());
                    this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date, u.recored_id);
                    u.am = "Search";
                    u.Text = "بحث اجار";

                    u.ShowDialog();
                    //ShowModalExcept(u, MainForm.searchForm);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                            ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button3
                        );
                u.Close();
            }

            if (e.ColumnIndex == 1)//2)
            {
                if (Convert.ToBoolean(realStateDataGridView.CurrentCell.OwningRow.Cells[1].Value) == false)
                {
                    if (Utils.SortdDTRealAppointinfo.Count > 0)
                    {

                        if (Utils.SortdDTRealAppointinfo.ContainsKey(Convert.ToInt32(realStateDataGridView.CurrentCell.OwningRow.Cells[3].Value)))
                        {
                            Utils.SortdDTRealAppointinfo.Remove((Convert.ToInt32(realStateDataGridView.CurrentCell.OwningRow.Cells[3].Value)));

                        }

                    }
                }
            }

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
                    stoprecord();
                    this.Close();
                    return true;

                }

                if (keyData == Keys.F11)
                {

                    Utils.EncryptMode = !Utils.EncryptMode;
                    encrypt();
                    return true;

                }

            }

            return false;
        }



        /////**********************************************************


        private void realStateDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            int availableHomes = 0;

            for (int i = 0; i < realStateDataGridView.Rows.Count; i++)
            {
                realStateDataGridView.Rows[i].Cells["Column1"].Value = i + 1;

                int lastColIndex = realStateDataGridView.Columns.Count - 2;
                object lastCellValue = realStateDataGridView.Rows[i].Cells[lastColIndex].Value;

                // اطبع القيم الفعلية
                System.Diagnostics.Debug.WriteLine($"Row {i}: '{lastCellValue}'");

                bool isZero = false;

                if (lastCellValue != null && lastCellValue != DBNull.Value)
                {
                    string strVal = lastCellValue.ToString().Trim();

                    // تحويل الأرقام العربية إلى إنجليزية
                    strVal = strVal.Replace("٠", "0").Replace("٫", ".").Replace(',', '.');

                    double val;
                    if (double.TryParse(strVal, out val))
                    {
                        isZero = Math.Abs(val) < 0.0001; // يسمح بأصفار عشرية
                    }
                }

                var regionCell = realStateDataGridView.Rows[i].Cells[4];

                if (isZero)
                {
                    regionCell.Style.ForeColor = Color.Black;
                    regionCell.Style.Font = new Font(realStateDataGridView.Font, FontStyle.Regular);
                    availableHomes++;
                }
                else
                {
                    regionCell.Style.ForeColor = Color.Red;
                    regionCell.Style.Font = new Font(realStateDataGridView.Font, FontStyle.Bold);
                }
            }

            lbNumberOfAvailableHomes.Text = availableHomes.ToString();
            if (realStateDataGridView.Rows.Count > 0)
                realStateDataGridView.Refresh();

        }

        //****************************
        public void startrecord()
        {
            realStateDataGridView.BeginEdit(true);
            Column2.Visible = true;

            if (Utils.RentRecord == true && Utils.SortdDTRealAppointinfo.Count > 0 && Column2.Visible == true)
            {
                for (int h = 0; h < Utils.SortdDTRealAppointinfo.Count; h++)
                {
                    foreach (DataGridViewRow row in realStateDataGridView.Rows)
                    {

                        if (Convert.ToInt32(row.Cells[3].Value.ToString()) == Utils.SortdDTRealAppointinfo.Keys[h])

                        {

                            row.Cells[2].Value = true;
                        }

                    }

                }
            }
        }


        public void stoprecord()
        {

            if (Column2.Visible == true)
            {
                realStateDataGridView.EndEdit();

                foreach (DataGridViewRow row in realStateDataGridView.Rows)
                {

                    if (Convert.ToBoolean(row.Cells[1].Value) == true)
                    {

                        if (!Utils.SortdDTRealAppointinfo.ContainsKey(Convert.ToInt32(row.Cells[3].Value.ToString())))
                        {
                            DataRow newrow;
                            newrow = Utils.DTRealAppointinfo.NewRow();
                            //newrow["CustomerName"] = Utils.NameOfCustomer;
                            newrow["RealID"] = Convert.ToInt32(row.Cells[3].Value.ToString());
                            newrow["apppointdate"] = Utils.appdate;
                            // newrow["apppointTime"] = Convert.ToDateTime(row.Cells["Column3"].Value.ToString()); ;

                            Utils.SortdDTRealAppointinfo.Add(Convert.ToInt32(row.Cells[3].Value.ToString()), "");

                            //Utils.DTRealAppointinfo.Rows.Add(newrow);
                        }


                        //    if (row != null && row.Cells != null && row.Cells.Count > 0 && row.Cells[0].Value != null && Utils.SortdDTRealAppointinfo != null)
                        //    {
                        //        int key;
                        //        if (int.TryParse(row.Cells[0].Value.ToString(), out key))
                        //        {
                        //            if (!Utils.SortdDTRealAppointinfo.ContainsKey(key))
                        //            {
                        //                // هنا تكتبي الكود اللي المفروض يتنفذ لو المفتاح مش موجود


                        //                if (!Utils.SortdDTRealAppointinfo.ContainsKey(Convert.ToInt32(row.Cells[0].Value.ToString())))
                        //                {
                        //                    DataRow newrow;
                        //                    newrow = Utils.DTRealAppointinfo.NewRow();
                        //                    //newrow["CustomerName"] = Utils.NameOfCustomer;
                        //                    newrow["RealID"] = Convert.ToInt32(row.Cells[0].Value.ToString());
                        //                    newrow["apppointdate"] = Utils.appdate;
                        //                    // newrow["apppointTime"] = Convert.ToDateTime(row.Cells["Column3"].Value.ToString()); ;

                        //                    Utils.SortdDTRealAppointinfo.Add(Convert.ToInt32(row.Cells[0].Value.ToString()), "");

                        //                    //Utils.DTRealAppointinfo.Rows.Add(newrow);
                        //                }


                        //            }

                        //        }
                        //    }


                    }
                }

                Column2.Visible = false;
            }

        }

        private void realStateDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // تأكد إن العمود هو عمود التاريخ، باستخدام الفهرس أو اسم العمود
            if (e.ColumnIndex == 1)
            {
                // تأكد إن القيمة هي string قبل محاولة تحويلها لتاريخ
                if (e.FormattedValue is string stringValue)
                {
                    try
                    {
                        DateTime dateTime = (DateTime)(new DateTimeConverter()).ConvertFromString(stringValue);
                        // تاريخ صالح، لا تفعل شيء
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("من فضلك أدخل التاريخ بصيغة صحيحة (مثال: 2025/07/31)", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
            }
        }

        //private void realStateDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    if (e.ColumnIndex == 1)
        //    {
        //        try
        //        {
        //            DateTime dateTime = (DateTime)((new DateTimeConverter()).ConvertFromString((string)e.FormattedValue));
        //        }
        //        catch (FormatException formatException)
        //        {
        //            MessageBox.Show("Time not in correct format");
        //            e.Cancel = true;
        //        }

        //    }
        //}

        private void Appointsearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            stoprecord();
            //this.Close();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

