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
using System.Threading;
using static System.Windows.Forms.TabControl;

namespace RealStateRentSystem
{
    public partial class Statics : Form
    {

        DataTable dt = new DataTable();

        private DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter RealStateTableAdaptersearchown = new DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter();

        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();

        public static string whatTab = "tab1";

        public Statics()
        {
            System.Diagnostics.Debug.WriteLine("Constructor Executed at " + DateTime.Now);

            Utils.getsetting();
            InitializeComponent();
            dt = GetNeglectedRealState(Utils.EnterPeriodOwnerToHouses);
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
            //realStateDataGridView.Columns["Status_dataGridViewTextBox"].DisplayIndex = 9;
            realStateDataGridView.Columns["DateOfEnter_dataGridViewTextBox"].DisplayIndex = 10;

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
            // dataGridView1.Columns["Status_Event_dataGridViewTextBox"].DisplayIndex = 9;
            dataGridView1.Columns["DateOfEnter_Event_dataGridViewTextBox"].DisplayIndex = 10;


        }
        private void realStateDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;  // تجاهل الضغط على الهيدر أو الأعمدة الفاضية

            RealstateOwner u = new RealstateOwner();
            try
            {

                if (realStateDataGridView.CurrentCell.OwningColumn.DisplayIndex == 0)
                {
                    //  u.MdiParent = this.MdiParent;
                    u.recored_id = Convert.ToInt32(realStateDataGridView.CurrentCell.OwningRow.Cells["ID_dataGridViewTextBox"].Value.ToString());
                    this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date, u.recored_id);
                    u.am = "Search";
                    u.Text = "بحث بيع";
                    u.ShowDialog();

                }
            }
            catch
            {
                u.Close();
            }
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


        private void UpdateTabTitles()
        {

            TabControl tabControl = tabControl1;

            int selectedIndex = tabControl.SelectedIndex;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                TabPage tabPage = tabControl.TabPages[i];
                string originalText = tabPage.Text;

                // إزالة أي رقم موجود في البداية
                int spaceIndex = originalText.IndexOf(" ");
                if (spaceIndex > 0 && int.TryParse(originalText.Substring(0, spaceIndex), out _))
                {
                    originalText = originalText.Substring(spaceIndex + 1);
                }

                // إذا هو التبويب المحدد، أضف الرقم
                if (i == selectedIndex)
                {
                    tabPage.Text = dt.Rows.Count + "  " + originalText;
                }
                else
                {
                    // غير محدد = فقط النص الأصلي بدون رقم
                    tabPage.Text = originalText;
                }


            }
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
           
            if (tabControl1.SelectedTab == this.tabPage1)
            {
                dt.Clear();
                whatTab = "tab1";
                dt = GetNeglectedRealState(Utils.EnterPeriodOwnerToHouses);
                realStateBindingSource.DataSource = dt;
                realStateDataGridView.DataSource = realStateBindingSource;
                realStateDataGridView.Refresh();
            }

            if (tabControl1.SelectedTab == this.tabPage2)
            {
                dt.Clear();
                whatTab = "tab2";
                dt = GetNeglectedEvent(Utils.EnterPeriodOwnerToEvents);
                realStateBindingSource.DataSource = dt;
                dataGridView1.DataSource = realStateBindingSource;
                dataGridView1.Refresh();
            }

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;  // تجاهل الضغط على الهيدر أو الأعمدة الفاضية

            RealstateOwner u = new RealstateOwner();
            try
            {

                if (dataGridView1.CurrentCell.OwningColumn.DisplayIndex == 0)
                {
                    u.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells["ID_Event_dataGridViewTextBox"].Value.ToString());
                    //  this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date, Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString()));
                    u.am = "Search";
                    u.Text = "بحث بيع";
                    u.ShowDialog();

                }
            }
            catch
            {
                u.Close();
            }

        }

        private DataTable GetNeglectedRealState(int days)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);

            string SqlStatement = @"
                 SELECT      RealstateOwne.ID, RealstateOwne.Region_ID, RealstateOwne.SubResgionID, 
                      RealstateOwne.Building, RealstateOwne.Floor, RealstateOwne.FloorComment,
                      RealstateOwne.Entrance, RealstateOwne.Distance, 
                                            RealstateOwne.Building_Type_ID, RealstateOwne.Owner,
                      RealstateOwne.Phone_one, RealstateOwne.Phone_Two, RealstateOwne.Mobile,
                      RealstateOwne.Other, RealstateOwne.DateOfEnter, RealstateOwne.UserID, RealstateOwne.area, 
                                            RealstateOwne.Price, RealstateOwne.investiture, 
                      RealstateOwne.WayOFOwner, RealstateOwne.[Key], RealstateOwne.[Note], RealstateOwne.Info_Source,
                      RealstateOwne.active, RealstateOwne.DateOchange, bt.Building_Type, 
                                            i.Investiture_Name, Users.User_Name, RealstateOwne.DateOchangeEvent, RealstateOwne.Rooms, RealstateOwne.Mobile2
                      FROM          (((RealstateOwne LEFT OUTER JOIN
                      BuildingType bt ON bt.ID = RealstateOwne.Building_Type_ID) LEFT OUTER JOIN
                      OwnInvestiture i ON i.ID = RealstateOwne.investiture) LEFT OUTER JOIN
                      Users ON RealstateOwne.ID = Users.ID)
                        WHERE (RealstateOwne.active = 1) and (DateDiff('d',RealstateOwne.DateOchange,Date()) >= ?)
                       Order by RealstateOwne.DateOchange DESC,RealstateOwne.ID
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
                   SELECT      RealstateOwne.ID, RealstateOwne.Region_ID, RealstateOwne.SubResgionID, 
                      RealstateOwne.Building, RealstateOwne.Floor, RealstateOwne.FloorComment,
                      RealstateOwne.Entrance, RealstateOwne.Distance, 
                                            RealstateOwne.Building_Type_ID, RealstateOwne.Owner,
                      RealstateOwne.Phone_one, RealstateOwne.Phone_Two, RealstateOwne.Mobile,
                      RealstateOwne.Other, RealstateOwne.DateOfEnter, RealstateOwne.UserID, RealstateOwne.area, 
                                            RealstateOwne.Price, RealstateOwne.investiture, 
                      RealstateOwne.WayOFOwner, RealstateOwne.[Key], RealstateOwne.[Note], RealstateOwne.Info_Source,
                      RealstateOwne.active, RealstateOwne.DateOchange, bt.Building_Type, 
                                            i.Investiture_Name, Users.User_Name, RealstateOwne.DateOchangeEvent, RealstateOwne.Rooms, RealstateOwne.Mobile2
                      FROM          (((RealstateOwne LEFT OUTER JOIN
                      BuildingType bt ON bt.ID = RealstateOwne.Building_Type_ID) LEFT OUTER JOIN
                      OwnInvestiture i ON i.ID = RealstateOwne.investiture) LEFT OUTER JOIN
                      Users ON RealstateOwne.ID = Users.ID)
                        WHERE   (RealstateOwne.active = 1) and (DateDiff('d',RealstateOwne.DateOchangeEvent,Date()) >= ?)
                       Order by RealstateOwne.DateOchangeEvent DESC,RealstateOwne.ID
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

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Cells["Btn_Event_dataGridViewTextBox"].Value = i + 1;
        }

        private void realStateDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < realStateDataGridView.Rows.Count; i++)
                realStateDataGridView.Rows[i].Cells["Btn_dataGridViewTextBox"].Value = i + 1;
        }

        bool isCheck = true;
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
            Rectangle paddedBounds = new Rectangle(e.Bounds.X + 15, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height);

            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(e.Graphics, tabPage.Text, font, paddedBounds, foreColor, flags);


            // ===== إشعار (دائرة برقم) =====

            // تحديد موضع الدائرة بالنسبة لمستطيل التبويب
            // **إضافة دائرة العدد بجانب كل تبويب مهما كان محدد أو لا**

            //if (isSelected) {
            //    // الحصول على عدد الصفوف المرتبط بكل تبويب حسب الفهرس
            //    int rowCount = 0;
            //    if (e.Index == 0)
            //        rowCount = realStateDataGridView.RowCount;
            //    else if (e.Index == 1)
            //        rowCount = dataGridView1.RowCount;

            //    // تحجيم الدائرة حسب عدد الأرقام في العدد
            //    int circleWidth = Math.Max(19, rowCount.ToString().Length * 11);
            //    int circleHeight = 19;

            //    // مكان الدائرة (بجانب الاسم من الجهة اليمنى مثلاً)
            //    // نحسب مكان النص أولاً حتى نضع الدائرة بجانبه
            //    Size textSize = TextRenderer.MeasureText(tabPage.Text, font);

            //    // هنا نحسب مكان الدائرة بحيث تكون بعد النص
            //    int circleX = e.Bounds.Left + textSize.Width + 20; // 5 بكسل مسافة بين النص والدائرة
            //    int circleY = e.Bounds.Top + (e.Bounds.Height - circleHeight) / 2;

            //    Rectangle circleRect = new Rectangle(circleX, circleY, circleWidth, circleHeight);

            //    // رسم الدائرة الحمراء
            //    using (Brush circleBrush = new SolidBrush(Color.Red))
            //        e.Graphics.FillEllipse(circleBrush, circleRect);

            //    // رسم الرقم داخل الدائرة
            //    using (Font notifFont = new Font("Tahoma", 8F, FontStyle.Bold))
            //    using (Brush textBrush = new SolidBrush(Color.White))
            //    {
            //        StringFormat stringFormat = new StringFormat()
            //        {
            //            Alignment = StringAlignment.Center,
            //            LineAlignment = StringAlignment.Center,
            //        };
            //        e.Graphics.DrawString(rowCount.ToString(), notifFont, textBrush, circleRect, stringFormat);
            //    }
            //}
        }

       

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // UpdateTabTitles();
        }
    }
}
