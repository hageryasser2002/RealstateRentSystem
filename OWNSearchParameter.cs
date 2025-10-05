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
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace RealStateRentSystem
{
    public partial class OWNSearchParameter : Form
    {
        public int y;
        DSrealsearchown.RealstateOwneDataTable dt = new DSrealsearchown.RealstateOwneDataTable();
        //      DSrealstatesearch.RealStateDataTable dt = new DSrealstatesearch.RealStateDataTable();
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
        public OWNSearchParameter(string where)
        {
            InitializeComponent();

            //panel_closing.BringToFront();
            y = DoQuery(where);
            encrypt();

            ChangeBorderColor();
            FillWidthColumns();

         



        }


        /// <summary>
        /// Alter Floor Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void realStateDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // اتأكدي إن العمود الحالي هو floorDataGridViewTextBoxColumn
            if (realStateDataGridView.Columns[e.ColumnIndex].Name == "dataGridViewTextBoxColumn5")
            {
                var row = realStateDataGridView.Rows[e.RowIndex];
                if (row.IsNewRow) return;

                string id = row.Cells["dataGridViewTextBoxColumn1"].Value?.ToString();
                if (string.IsNullOrEmpty(id)) return;

                string floor = row.Cells["dataGridViewTextBoxColumn5"].Value?.ToString() ?? "";
                string floorComment = clsRealStateOwn.GetFloorCommentById(id);

                e.Value = $"{floor}  {floorComment}".Trim();
                e.FormattingApplied = true;
            }
        }

        private void FillWidthColumns()
        {
            realStateDataGridView.Columns["dataGridViewTextBoxColumn3"].Width = 200;
            realStateDataGridView.Columns["dataGridViewTextBoxColumn4"].Width = 200;
            realStateDataGridView.Columns["dataGridViewTextBoxColumn10"].Width = 200;
            realStateDataGridView.Columns["Column1"].Width = 80;
            realStateDataGridView.Columns["dataGridViewTextBoxColumn1"].Width = 110;
        }

        private void ChangeBorderColor()
        {
            this.Size = new Size(MainForm.MainForm_Size.Width - 20, MainForm.MainForm_Size.Height - 100);
            this.Location = new Point(MainForm.MainForm_Location.X + 10, MainForm.MainForm_Location.Y + 100);
            realStateDataGridView.Location = new Point(this.Location.X, this.Location.Y - 48);
            realStateDataGridView.Size = new Size(this.Size.Width - 7, this.Size.Height - 45);
            Color color = Color.FromArgb(45, 216, 129);
            panel_top.BackColor = color;
            panel_bottom.BackColor = color;
            panel_left.BackColor = color;
            panel_right.BackColor = color;

        }

        public OWNSearchParameter(DSrealsearchown.RealstateOwneDataTable pdt)
        {
            InitializeComponent();
            dt = (DSrealsearchown.RealstateOwneDataTable)pdt;
            realStateBindingSource.DataSource = dt;
            realStateDataGridView.DataSource = realStateBindingSource;
            realStateDataGridView.Refresh();
            encrypt();
        }

        public void encrypt()
        {
            if (Utils.EncryptMode)
            {

                dataGridViewTextBoxColumn4.Visible = false;
                dataGridViewTextBoxColumn10.Visible = false;


                //MainForm.Imagencrypt.Visible = true;
                //MainForm.Imagencrypt2.Visible = true;
            }
            if (!Utils.EncryptMode)
            {


                dataGridViewTextBoxColumn4.Visible = true;
                dataGridViewTextBoxColumn10.Visible = true;


                //MainForm.Imagencrypt.Visible = false;
                //MainForm.Imagencrypt2.Visible = false;

            }

        }
        private OpenFileDialog fdlg = new OpenFileDialog();


        private void Realstate_Load(object sender, EventArgs e)
        {
            //
            realStateDataGridView.CellFormatting += realStateDataGridView_CellFormatting;

            realStateDataGridView.BeginEdit(true);
            if (Utils.ORentRecord == true)
            {
                startrecord();
            }

            if (Utils.ORentRecord == false)
            {
                //stoprecord();
            }



        }


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //  this.subRegionsTableAdapter.FillRegionBy(this.dSregion.SubRegions, Convert.ToInt32(regioncompo.SelectedValue.ToString()));
        }

        private void buildingTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string[] keys = e.KeyData.ToString().Split(',');
            if (keys.Length == 2)
            {
                DataTable t = new DataTable();
                t = shorCutKeysTableAdapter.GetDataBy(keys[1].Trim().ToString(), keys[0].Trim().ToString());
                if (t.Rows.Count > 0)
                    this.ActiveControl.Text += t.Rows[0]["Text"].ToString();

            }
        }

        public int DoQuery(string clouse)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            try
            {
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(clouse, conn);
                dt = new DSrealsearchown.RealstateOwneDataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    //if (dt.Rows.Count == 1)
                    //{
                    //    RealstateOwner u = new RealstateOwner();
                    //    try
                    //    {
                    //        u.recored_id = Convert.ToInt32(dt.Rows[0]["id"]);
                    //        this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date, u.recored_id);
                    //        u.am = "Search";
                    //        u.Text = "بحث بيع";

                    //        this.Close();
                    //        u.ShowDialog();


                    //    }
                    //    catch
                    //    {
                    //        u.Close();
                    //    }

                    //    conn.Close();
                    //    conn.Dispose();
                    //    return 2;

                    //}
                    //else
                    //{

                    RowCount_lbl.Text = dt.Rows.Count.ToString();
                    realStateBindingSource.DataSource = dt;
                    realStateDataGridView.DataSource = realStateBindingSource;
                    realStateDataGridView.Refresh();
                    conn.Close();
                    conn.Dispose();
                    return 1;
                    //}

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

        private void realStateDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            realStateDataGridView.EndEdit();
            RealstateOwner u = new RealstateOwner();
            try
            {

                if (e.ColumnIndex == 2)
                {
                    //u.MdiParent = this.MdiParent;
                    u.recored_id = Convert.ToInt32(realStateDataGridView.CurrentCell
                                  .OwningRow.Cells["dataGridViewTextBoxColumn1"].Value.ToString());
                    this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date, u.recored_id);
                    u.am = "Search";
                    u.Text = "بحث بيع";
                    u.ShowDialog();
                    //ShowModalExcept(u, MainForm.searchForm);

                }
            }
            catch
            {
                u.Close();
            }



            if (e.ColumnIndex == 2)
            {
                if (Convert.ToBoolean(realStateDataGridView.CurrentCell.OwningRow.Cells[2].Value) == false)
                {
                    if (Utils.OSortdDTRealAppointinfo.Count > 0)
                    {

                        if (Utils.OSortdDTRealAppointinfo.ContainsKey(Convert.ToInt32(realStateDataGridView.CurrentCell.OwningRow.Cells[0].Value)))
                        {
                            Utils.OSortdDTRealAppointinfo.Remove((Convert.ToInt32(realStateDataGridView.CurrentCell.OwningRow.Cells[0].Value)));

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


        private void realStateDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < realStateDataGridView.Rows.Count; i++)
            {
                realStateDataGridView.Rows[i].Cells["Column1"].Value = i + 1;
            }
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

        public void startrecord()
        {
            realStateDataGridView.BeginEdit(true);
            Column2.Visible = true;


            if (Utils.ORentRecord == true && Utils.OSortdDTRealAppointinfo.Count > 0 && Column2.Visible == true)
            {
                for (int h = 0; h < Utils.OSortdDTRealAppointinfo.Count; h++)
                {
                    foreach (DataGridViewRow row in realStateDataGridView.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value.ToString()) == Utils.OSortdDTRealAppointinfo.Keys[h])
                        {

                            row.Cells[2].Value = true;
                        }

                    }

                }


            }


            //            Column3.Visible = true;
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
                        if (Convert.ToBoolean(row.Cells[1].Value) == true)
                        {

                            if (!Utils.OSortdDTRealAppointinfo.ContainsKey(Convert.ToInt32(row.Cells[3].Value.ToString())))
                            {
                                DataRow newrow;
                                newrow = Utils.ODTRealAppointinfo.NewRow();
                                //newrow["CustomerName"] = Utils.NameOfCustomer;
                                newrow["RealID"] = Convert.ToInt32(row.Cells[3].Value.ToString());
                                newrow["apppointdate"] = Utils.Oappdate;
                                // newrow["apppointTime"] = Convert.ToDateTime(row.Cells["Column3"].Value.ToString()); ;

                                Utils.OSortdDTRealAppointinfo.Add(Convert.ToInt32(row.Cells[3].Value.ToString()), "");

                                //Utils.DTRealAppointinfo.Rows.Add(newrow);
                            }
                        }
                        //if (row.Cells[2].Value != null && Convert.ToBoolean(row.Cells[2].Value) == true)
                        //{
                        //    var keyCellValue = row.Cells[0].Value;
                        //    if (keyCellValue != null)
                        //    {
                        //        int key = Convert.ToInt32(keyCellValue.ToString());
                        //        if (!Utils.OSortdDTRealAppointinfo.ContainsKey(key))
                        //        {
                        //            // أكمل


                        //            DataRow newrow;
                        //            newrow = Utils.ODTRealAppointinfo.NewRow();
                        //            //newrow["CustomerName"] = Utils.NameOfCustomer;
                        //            newrow["RealID"] = Convert.ToInt32(row.Cells[0].Value.ToString());
                        //            newrow["apppointdate"] = Utils.Oappdate;
                        //            // newrow["apppointTime"] = Convert.ToDateTime(row.Cells["Column3"].Value.ToString()); ;

                        //            Utils.OSortdDTRealAppointinfo.Add(Convert.ToInt32(row.Cells[0].Value.ToString()), "");

                        //            //Utils.DTRealAppointinfo.Rows.Add(newrow);
                        //        }
                        //    }
                        //}

                    }
                }

                Column2.Visible = false;
                //                Column3.Visible = false;


            }

        }

        private void realStateDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex == 1)
            {

                //try
                //{
                //    DateTime dateTime = (DateTime)((new DateTimeConverter()).ConvertFromString((string)e.FormattedValue));
                //}
                //catch (FormatException formatException)
                //{
                //    MessageBox.Show("Time not in correct format");
                //    e.Cancel = true;
                //}
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

        private void OWNSearchParameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            stoprecord();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
