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
namespace RealStateRentSystem
{
    public partial class RealStatics : Form
    {
        DataTable dt = new DataTable();

        private DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter RealStateTableAdapter = new DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter();
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
        public static string whatTab = "tab1";

        public RealStatics()
        {
            Utils.getsetting();
            InitializeComponent();
            dt = GetNeglectedRealState(Utils.EnterPeriodRentToHouses);
            realStateBindingSource.DataSource = dt;
            realStateDataGridView.DataSource = realStateBindingSource;
            realStateDataGridView.Refresh();
            encrypt();
            FillWidthColumns();
        }


        private void FillWidthColumns()
        {
            this.Size = new Size(MainForm.MainForm_Size.Width - 20, MainForm.MainForm_Size.Height - 100);
            this.Location = new Point(MainForm.MainForm_Location.X + 10, MainForm.MainForm_Location.Y + 100);
            realStateDataGridView.Columns["Build_dataGridViewTextBox"].Width = 150;
            realStateDataGridView.Columns["Floor_dataGridViewTextBox"].Width = 60;
            realStateDataGridView.Columns["Btn_dataGridViewTextBox"].Width = 60;

            dataGridView1.Columns["Build_Event_dataGridViewTextBox"].Width = 150;
            dataGridView1.Columns["Floor_Event_dataGridViewTextBox"].Width = 60;
            dataGridView1.Columns["Btn_Event_dataGridViewTextBox"].Width = 60;


            realStateDataGridView.Columns["Btn_dataGridViewTextBox"].DisplayIndex = 0;
            realStateDataGridView.Columns["ID_dataGridViewTextBox"].DisplayIndex = 1;
            realStateDataGridView.Columns["Area_dataGridViewTextBox"].DisplayIndex = 2;
            realStateDataGridView.Columns["Street_dataGridViewTextBox"].DisplayIndex = 3;
            realStateDataGridView.Columns["Build_dataGridViewTextBox"].DisplayIndex = 4;
            realStateDataGridView.Columns["Floor_dataGridViewTextBox"].DisplayIndex = 5;
            realStateDataGridView.Columns["Owner_dataGridViewTextBox"].DisplayIndex = 6;
            realStateDataGridView.Columns["PhoneOne_dataGridViewTextBox"].DisplayIndex = 7;
            realStateDataGridView.Columns["PhoneTwo_dataGridViewTextBox"].DisplayIndex = 8;
            realStateDataGridView.Columns["Mobile_dataGridViewTextBox"].DisplayIndex = 9;
            realStateDataGridView.Columns["Status_dataGridViewTextBox"].DisplayIndex = 10;
            realStateDataGridView.Columns["RDateOChange_dataGridViewTextBox"].DisplayIndex = 11;

            dataGridView1.Columns["Btn_Event_dataGridViewTextBox"].DisplayIndex = 0;
            dataGridView1.Columns["ID_Event_dataGridViewTextBox"].DisplayIndex = 1;
            dataGridView1.Columns["Area_Event_dataGridViewTextBox"].DisplayIndex = 2;
            dataGridView1.Columns["Street_Event_dataGridViewTextBox"].DisplayIndex = 3;
            dataGridView1.Columns["Build_Event_dataGridViewTextBox"].DisplayIndex = 4;
            dataGridView1.Columns["Floor_Event_dataGridViewTextBox"].DisplayIndex = 5;
            dataGridView1.Columns["Owner_Event_dataGridViewTextBox"].DisplayIndex = 6;
            dataGridView1.Columns["PhoneOne_Event_dataGridViewTextBox"].DisplayIndex = 7;
            dataGridView1.Columns["PhoneTwo_Event_dataGridViewTextBox"].DisplayIndex = 8;
            dataGridView1.Columns["Mobile_Event_dataGridViewTextBox"].DisplayIndex = 9;
            dataGridView1.Columns["Status_Event_dataGridViewTextBox"].DisplayIndex = 10;
            dataGridView1.Columns["RDateOChange_Event_dataGridViewTextBox"].DisplayIndex = 11;


        }
        public void encrypt()
        {
            if (Utils.EncryptMode)
            {

                //dataGridViewTextBoxColumn3.Visible = false;
                //dataGridViewTextBoxColumn10.Visible = false;
                //dataGridViewTextBoxColumn11.Visible = false;
                //dataGridViewTextBoxColumn12.Visible = false;
                //dataGridViewTextBoxColumn13.Visible = false;
                //dataGridViewTextBoxColumn14.Visible = false;



                //dataGridViewTextBoxColumn36.Visible = false;
                //dataGridViewTextBoxColumn43.Visible = false;
                //dataGridViewTextBoxColumn44.Visible = false;
                //dataGridViewTextBoxColumn45.Visible = false;
                //dataGridViewTextBoxColumn46.Visible = false;
                //dataGridViewTextBoxColumn47.Visible = false;



                //MainForm.Imagencrypt.Visible = true;
                //MainForm.Imagencrypt2.Visible = true;
            }
            if (!Utils.EncryptMode)
            {


                //dataGridViewTextBoxColumn3.Visible = true;
                //dataGridViewTextBoxColumn10.Visible = true;
                //dataGridViewTextBoxColumn11.Visible = true;
                //dataGridViewTextBoxColumn12.Visible = true;
                //dataGridViewTextBoxColumn13.Visible = true;
                //dataGridViewTextBoxColumn14.Visible = true;


                //dataGridViewTextBoxColumn36.Visible = true;
                //dataGridViewTextBoxColumn43.Visible = true;
                //dataGridViewTextBoxColumn44.Visible = true;
                //dataGridViewTextBoxColumn45.Visible = true;
                //dataGridViewTextBoxColumn46.Visible = true;
                //dataGridViewTextBoxColumn47.Visible = true;

                //MainForm.Imagencrypt.Visible = false;
                //MainForm.Imagencrypt2.Visible = false;

            }

        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            Utils.getsetting();
            if (tabControl1.SelectedTab == this.tabPage1)
            {
                dt.Clear();
                whatTab = "tab1";
                dt = GetNeglectedRealState(Utils.EnterPeriodRentToHouses);
                realStateBindingSource.DataSource = dt;
                realStateDataGridView.DataSource = realStateBindingSource;
                realStateDataGridView.Refresh();
                encrypt();
            }

            if (tabControl1.SelectedTab == this.tabPage2)
            {
                //dataGridViewTextBoxColumn33.Visible = false;
                dt.Clear();
                whatTab = "tab2";
                dt = GetNeglectedEvent(Utils.EnterPeriodRentToEvents);
                realStateBindingSource.DataSource = dt;
                dataGridView1.DataSource = realStateBindingSource;
                dataGridView1.Refresh();
                encrypt();
            }
        }
        private void realStateDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;  // تجاهل الضغط على الهيدر أو الأعمدة الفاضية
          
            
            Realstate u = new Realstate();
            try
            {

                if (realStateDataGridView.CurrentCell.OwningColumn.DisplayIndex == 0)
                {
                    //  u.MdiParent = this.MdiParent;
                    u.recored_id = Convert.ToInt32(realStateDataGridView.CurrentCell.OwningRow.Cells["ID_dataGridViewTextBox"].Value.ToString());

                    this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date, u.recored_id);
                    u.am = "Search";
                    u.Text = "بحث اجار";
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
                    encrypt();
                    return true;

                }


            }

            return true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            Realstate u = new Realstate();
            try
            {

                if (dataGridView1.CurrentCell.OwningColumn.DisplayIndex == 0)
                {
                    u.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells["ID_Event_dataGridViewTextBox"].Value.ToString());
                    //this.realStateTableAdapter.UpdateQueryEvent(DateTime.Now.Date, u.recored_id);
                    u.am = "Search";
                    u.Text = "بحث اجار";
                    u.ShowDialog();
                    //ShowModalExcept(u, MainForm.searchForm);


                }
            }
            catch
            {
                u.Close();
            }

        }

        private void realStateDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            for (int i = 0; i < realStateDataGridView.Rows.Count; i++)
            {
                //
                //  if (Convert.ToInt32(realStateDataGridView.Rows[i].Cells[10].Value.ToString()) == 1)
                //if (!string.IsNullOrEmpty(realStateDataGridView.Rows[i].Cells[10].Value.ToString())
                //    && Convert.ToInt32(realStateDataGridView.Rows[i].Cells[10].Value.ToString()) == 1)
                //{
                //    realStateBindingSource.Position = i;
                //    realStateDataGridView.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                //}

                realStateDataGridView.Rows[i].Cells["Btn_dataGridViewTextBox"].Value = i + 1;

                //var cellValue = realStateDataGridView.Rows[i].Cells["remainingDayDataGridViewTextBoxColumn"].Value;
                //string status = realStateDataGridView.Rows[i].Cells["Status_ID"].Value.ToString();

                //if (string.IsNullOrEmpty(status)) status = "1";

                //if (cellValue != null && Convert.ToInt32(cellValue) <= Utils.RemainderingPeriodEmpty && Convert.ToInt32(status) == 1)
                //    realStateDataGridView.Rows[i].Cells[4].Style.ForeColor = Color.Red;


                //if (realStateDataGridView.Rows.Count > 0)
                //{
                //    realStateDataGridView.Refresh();
                //}
            }
        }

        private void dataGridView1_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                dataGridView1.Rows[i].Cells["Btn_Event_dataGridViewTextBox"].Value = i + 1;
                //if (Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value.ToString()) == 1)
                //if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[10].Value.ToString())
                //    && Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value.ToString()) == 1)
                //{
                //    realStateBindingSource.Position = i;
                //    dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                //}
            }
        }


        private DataTable GetNeglectedRealState(int days)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);

            string SqlStatement = @"
                  SELECT RealState.ID, RealState.Region_ID, RealState.SubResgionID,
                      RealState.Building, RealState.Floor, RealState.FloorComment,
                      RealState.Entrance, RealState.Distance, RealState.Building_Type_ID,
                      RealState.Owner, RealState.Phone_one, 
                      RealState.Phone_Two, RealState.Mobile, RealState.Other, RealState.DateOfEnter,
                      RealState.UserID, RealState.area, RealState.Price, RealState.investiture,
                      RealState.WayOfRent, RealState.[Key], RealState.[Note], RealState.Info_Source, 
                      RealState.Status_ID, RealState.StartRentDate, RealState.EndRendDate, 
                      RealState.Period, RealState.RemainingDay, bt.Building_Type, i.Investiture_Name, re.Name,
                      Users.User_Name, wr.WayOfRent AS Expr1, st.StatusName, 
                      RealState.active, RealState.RDateOchange, RealState.RDateOchangeEvent, RealState.Rooms, RealState.Mobile2
                      FROM    ((((((RealState LEFT OUTER JOIN
                      BuildingType bt ON bt.ID = RealState.Building_Type_ID) LEFT OUTER JOIN
                      Investiture i ON i.ID = RealState.investiture) LEFT OUTER JOIN
                      Region re ON re.ID = RealState.Region_ID) LEFT OUTER JOIN
                      WayOfRent wr ON wr.ID = RealState.WayOfRent) LEFT OUTER JOIN
                      Users ON RealState.ID = Users.ID) LEFT OUTER JOIN
                      StatusType st ON st.ID = RealState.Status_ID)
                       WHERE    (RealState.active = 1) AND  RealState.Status_ID=2  AND (DateDiff('d',RealState.RDateOchange,Date()) >= ?)
                       Order by RealState.RDateOchange DESC,RealState.ID
                ";
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(SqlStatement, conn);
                cmd.Parameters.AddWithValue("?", days);

                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conn.Close();
                conn.Dispose();
                sda.Dispose();

                return dt;

            }
            catch (Exception)
            {
                throw;

            }
        }
        private DataTable GetNeglectedEvent(int days)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);

            string SqlStatement = @"
                  SELECT RealState.ID, RealState.Region_ID, RealState.SubResgionID,
                      RealState.Building, RealState.Floor, RealState.FloorComment,
                      RealState.Entrance, RealState.Distance, RealState.Building_Type_ID,
                      RealState.Owner, RealState.Phone_one, 
                      RealState.Phone_Two, RealState.Mobile, RealState.Other, RealState.DateOfEnter,
                      RealState.UserID, RealState.area, RealState.Price, RealState.investiture,
                      RealState.WayOfRent, RealState.[Key], RealState.[Note], RealState.Info_Source, 
                      RealState.Status_ID, RealState.StartRentDate, RealState.EndRendDate, 
                      RealState.Period, RealState.RemainingDay, bt.Building_Type, i.Investiture_Name, re.Name,
                      Users.User_Name, wr.WayOfRent AS Expr1, st.StatusName, 
                      RealState.active, RealState.RDateOchange, RealState.RDateOchangeEvent, RealState.Rooms, RealState.Mobile2
                      FROM    ((((((RealState LEFT OUTER JOIN
                      BuildingType bt ON bt.ID = RealState.Building_Type_ID) LEFT OUTER JOIN
                      Investiture i ON i.ID = RealState.investiture) LEFT OUTER JOIN
                      Region re ON re.ID = RealState.Region_ID) LEFT OUTER JOIN
                      WayOfRent wr ON wr.ID = RealState.WayOfRent) LEFT OUTER JOIN
                      Users ON RealState.ID = Users.ID) LEFT OUTER JOIN
                      StatusType st ON st.ID = RealState.Status_ID)
                       WHERE    (RealState.active = 1) AND  RealState.Status_ID=2  AND (DateDiff('d',RealState.RDateOchangeEvent,Date()) >= ?)
                       Order by RealState.RDateOchangeEvent DESC,RealState.ID
                ";
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(SqlStatement, conn);
                cmd.Parameters.AddWithValue("?", days);

                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conn.Close();
                conn.Dispose();
                sda.Dispose();

                return dt;

            }
            catch (Exception)
            {
                throw;

            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage tabPage = tabControl.TabPages[e.Index];
            int currentTab = tabControl.SelectedIndex;
            bool isSelected = (tabControl.SelectedIndex == e.Index);

            Color color = Color.FromArgb(108, 91, 83);
            if (currentTab == 0)
                color = Color.FromArgb(112, 128, 144);

            Color backColor = isSelected ? color : SystemColors.Control;
            Color foreColor = isSelected ? Color.White : SystemColors.ControlText;
            Font font = isSelected ? new Font("Tahoma", 9F, FontStyle.Bold) : new Font("Tahoma", 8F, FontStyle.Bold);

            using (Brush brush = new SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, e.Bounds);


            // تعديل الموضع: أضف padding داخلي (مثلاً للأسفل)
            Rectangle paddedBounds = new Rectangle(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height);

            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(e.Graphics, tabPage.Text, font, paddedBounds, foreColor, flags);

        }


    }
}
