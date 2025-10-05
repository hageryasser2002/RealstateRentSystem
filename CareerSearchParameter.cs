using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RealStateRentSystem.DSTables;
namespace RealStateRentSystem
{
    public partial class CareerSearchParameter : Form
    {
        public int y;

        DScareersearch.careerDataTable dt = new DScareersearch.careerDataTable();
        //      DSrealstatesearch.RealStateDataTable dt = new DSrealstatesearch.RealStateDataTable();
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();

        public CareerSearchParameter(string where)
        {
            InitializeComponent();
            y = DoQuery(where);
            ChangeBorderColor();
            FillWidthColumns();
        }

        private void FillWidthColumns()
        {
            realStateDataGridView.Columns["Column1"].Width = 80;
            realStateDataGridView.Columns["notesDataGridViewTextBoxColumn"].Width = 400;
        }

        private void ChangeBorderColor()
        {
            this.Size = new Size(MainForm.MainForm_Size.Width - 20, MainForm.MainForm_Size.Height - 100);
            this.Location = new Point(MainForm.MainForm_Location.X + 10, MainForm.MainForm_Location.Y + 100);
            Color color = Color.FromArgb(250, 163, 7);
            panel_top.BackColor = color;
            panel_bottom.BackColor = color;
            panel_left.BackColor = color;
            panel_right.BackColor = color;

        }

        public CareerSearchParameter(DScareersearch.careerDataTable pdt)
        {
            InitializeComponent();
            dt = (DScareersearch.careerDataTable)pdt;
            careerBindingSource.DataSource = dt;
            realStateDataGridView.DataSource = careerBindingSource;
            realStateDataGridView.Refresh();
        }

        private void realStateDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < realStateDataGridView.Rows.Count; i++)
            {
                realStateDataGridView.Rows[i].Cells["Column1"].Value = i + 1;
            }
        }

        private void Realstate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dScareersearch.career' table. You can move, or remove it, as needed.
            //            this.careerTableAdapter.Fill(this.dScareersearch.career);

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
                dt = new DScareersearch.careerDataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    if (dt.Rows.Count == 1)
                    {
                        career u = new career();
                        try
                        {

                            u.recored_id = Convert.ToInt32(dt.Rows[0]["id"]);
                            u.am = "Search";
                            u.Text = "بحث";
                            u.ShowDialog();
                            //ShowModalExcept(u, MainForm.searchForm);



                        }
                        catch
                        {
                            u.Close();
                        }

                        conn.Close();
                        conn.Dispose();
                        return 2;

                    }
                    else
                    {
                        careerBindingSource.DataSource = dt;
                        realStateDataGridView.DataSource = careerBindingSource;
                        realStateDataGridView.Refresh();
                        conn.Close();
                        conn.Dispose();
                        return 1;
                    }

                }
                else
                {


                    careerBindingSource.DataSource = dt;
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
            career u = new career();
            try
            {

                if (e.ColumnIndex == 1)
                {

                    //  u.MdiParent = this.MdiParent;
                    u.recored_id = Convert.ToInt32(realStateDataGridView.CurrentCell.OwningRow.Cells[0].Value.ToString());
                    //this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date,Convert.ToInt32(realStateDataGridView.CurrentCell.OwningRow.Cells[0].Value.ToString()));
                    u.am = "Search";
                    u.Text = "بحث";
                    u.ShowDialog();
                    //ShowModalExcept(u, MainForm.searchForm);


                }
            }
            catch
            {
                u.Close();
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

                    this.Close();
                    return true;

                }
                if (keyData == Keys.F11)
                {
                    Utils.EncryptMode = !Utils.EncryptMode;
                    return true;

                }

            }

            return true;

        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
