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
    public partial class phonesearch : Form
    {
        public int y;

        DSphoneSearch.PhoneDataTable dt = new DSphoneSearch.PhoneDataTable();


        public phonesearch(string where)
        {
            InitializeComponent();

            y = DoQuery(where);
        }

        public phonesearch(DSphoneSearch.PhoneDataTable pdt)
        {
            InitializeComponent();
            dt = (DSphoneSearch.PhoneDataTable)pdt;
            phoneBindingSource.DataSource = dt;
            phoneDataGridView.DataSource = phoneBindingSource;
            phoneDataGridView.Refresh();
        }

        private void phonesearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSphoneSearch.Phone' table. You can move, or remove it, as needed.
        //    this.phoneTableAdapter.Fill(this.dSphoneSearch.Phone);

        }


        public int DoQuery(string clouse)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            try
            {
                conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(clouse, conn);
                dt = new DSphoneSearch.PhoneDataTable();
                this.dSphoneSearch.Clear();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    phoneBindingSource.DataSource = dt;
                    phoneDataGridView.DataSource = phoneBindingSource;
                    phoneDataGridView.Refresh();
                    conn.Close();
                    conn.Dispose();
                    return 1;
                }
                else
                {


                    phoneBindingSource.DataSource = dt;
                    phoneDataGridView.Refresh();
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

        private void phoneDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            phone u = new phone();
            try
            {

                if (e.ColumnIndex == 1)
                {
                    //  u.MdiParent = this.MdiParent;
                    u.recored_id = Convert.ToInt32(phoneDataGridView.CurrentCell.OwningRow.Cells[0].Value.ToString());
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
    }

}
