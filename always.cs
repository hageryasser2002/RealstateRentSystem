using IWshRuntimeLibrary;
using RealStateRentSystem.Classes;
using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Text;
using System.Windows.Forms;



namespace RealStateRentSystem
{
    public partial class FrmAlways : Form
    {
        private static DSTables.DSrealstateTableAdapters.RealStateTableAdapter RealStateTableAdapter = new DSTables.DSrealstateTableAdapters.RealStateTableAdapter();
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
        private DSTables.DSappointmentTableAdapters.AppointmentsNumbersTableAdapter AppointmentsNumbersTableAdapter = new DSTables.DSappointmentTableAdapters.AppointmentsNumbersTableAdapter();
        private DSTables.DSphoneTableAdapters.phoneEventTableAdapter phoneEventTableAdapter = new DSTables.DSphoneTableAdapters.phoneEventTableAdapter();
        private System.Windows.Forms.ToolTip m_wndToolTip;
        private Timer _Timer = new Timer();


        public static string currenttabe;

      

        //static LoginMsg newMessageBox;

        ///////////////////
        List<string> suggestions = new List<string>();
        string lastText = string.Empty;
        static bool textChanging = false;
        private CustomSource autoComplete;


        public FrmAlways()
        {
            InitializeComponent();

            cmbStatus.SelectedIndex = 1;
            cmbRegion.Text = null;
            cmbBuildingType.Text = null;
            cmbRegion.Focus();
            groupBox2.BackColor = Color.FromArgb(188, 71, 73);


            DataAccess dataAccess = new DataAccess();

            autoComplete = new CustomSource(dataAccess.GetBuilding().ToArray());
            txtBuilding.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuilding.AutoCompleteSource = AutoCompleteSource.CustomSource;
            autoComplete.Bind(txtBuilding);




            //_Timer.Interval = 1000;

            //_Timer.Tick += new EventHandler(_Timer_Tick);

            //_Timer.Start();




            //Clock c = new Clock();
            //c.TopLevel = false;
            //c.TopMost = false;
            //c.MdiParent = this.MdiParent;
            //this.panel1.Controls.Add(c);
            //c.Show();

            ///
            CenterControlsHorizontally();
            this.Resize += new EventHandler(Form1_Resize);

        }

        /// <summary>
        /// Added Method To Centralize Components of Form
        /// </summary>
        private void CenterControlsHorizontally()
        {
            foreach (Control ctrl in this.Controls)
            {
                int formWidth = this.ClientSize.Width;
                ctrl.Left = (formWidth - ctrl.Width) / 2;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterControlsHorizontally();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox2.Checked == false)
            {
                if (txtInEvent.Text != "")
                {
                    DoQuery("SELECT RealState.ID, RealState.Region_ID, RealState.SubResgionID, RealState.Building, RealState.Floor, RealState.FloorComment, RealState.Entrance, " +
                        " RealState.Distance, RealState.Building_Type_ID, RealState.Owner, RealState.Phone_one, RealState.Phone_Two, RealState.Mobile, RealState.Other, " +
                        " RealState.DateOfEnter, RealState.UserID, RealState.area,RealState.Rooms, RealState.Mobile2, RealState.Price, RealState.investiture, RealState.WayOfRent, RealState.[Key], " +
                        " RealState.[Note], RealState.Info_Source, RealState.Status_ID, RealState.StartRentDate, RealState.EndRendDate, RealState.Period, " +
                        " RealState.RemainingDay, bt.Building_Type, i.Investiture_Name, re.Name, Users.User_Name, wr.WayOfRent AS Expr1, st.StatusName , RealState.active " +
                        " FROM ((((((( RealState LEFT JOIN " +
                        " BuildingType bt ON bt.ID = RealState.Building_Type_ID) LEFT JOIN " +
                        " Investiture i ON i.ID = RealState.investiture) LEFT JOIN " +
                        " Region re ON re.ID = RealState.Region_ID) LEFT JOIN " +
                        " WayOfRent wr ON wr.ID = RealState.WayOfRent) LEFT JOIN " +
                        " Users ON RealState.ID = Users.ID ) LEFT JOIN " +
                        " StatusType st ON st.ID = RealState.Status_ID ) LEFT JOIN " +
                        " Event Event ON RealState.ID = Event.RealStateID )"
                        + whereClouse() + "");
                }
                else
                {
                    DoQuery(" SELECT RealState.ID, RealState.Region_ID, RealState.SubResgionID, RealState.Building, RealState.Floor, RealState.FloorComment, RealState.Entrance, " +
                         " RealState.Distance, RealState.Building_Type_ID, RealState.Owner, RealState.Phone_one, RealState.Phone_Two, RealState.Mobile, RealState.Other, " +
                         " RealState.DateOfEnter, RealState.UserID, RealState.area,RealState.Rooms,  RealState.Mobile2, RealState.Price, RealState.investiture, RealState.WayOfRent, RealState.[Key], " +
                         " RealState.[Note], RealState.Info_Source, RealState.Status_ID, RealState.StartRentDate, RealState.EndRendDate, RealState.Period, " +
                         " RealState.RemainingDay, bt.Building_Type, i.Investiture_Name, re.Name, Users.User_Name, wr.WayOfRent AS Expr1, st.StatusName , RealState.active " +
                         " FROM ((((((RealState LEFT JOIN " +
                         " BuildingType bt ON bt.ID = RealState.Building_Type_ID) LEFT JOIN " +
                         " Investiture i ON i.ID = RealState.investiture) LEFT JOIN " +
                         " Region re ON re.ID = RealState.Region_ID) LEFT JOIN " +
                         " WayOfRent wr ON wr.ID = RealState.WayOfRent) LEFT JOIN " +
                         " Users ON RealState.ID = Users.ID ) LEFT JOIN " +
                         " StatusType st ON st.ID = RealState.Status_ID )" + whereClouse() + "");


                }
            }
            else
            {
                if (txtInEvent.Text != "")
                {
                    DoQuery("SELECT RealState.ID, RealState.Region_ID, RealState.SubResgionID, RealState.Building, RealState.Floor, RealState.FloorComment, RealState.Entrance, " +
                        " RealState.Distance, RealState.Building_Type_ID, RealState.Owner, RealState.Phone_one, RealState.Phone_Two, RealState.Mobile, RealState.Other, " +
                        " RealState.DateOfEnter, RealState.UserID, RealState.area,RealState.Rooms,  RealState.Mobile2,RealState.Price, RealState.investiture, RealState.WayOfRent, RealState.[Key], " +
                        " RealState.[Note], RealState.Info_Source, RealState.Status_ID, RealState.StartRentDate, RealState.EndRendDate, RealState.Period, " +
                        " RealState.RemainingDay, bt.Building_Type, i.Investiture_Name, re.Name, Users.User_Name, wr.WayOfRent AS Expr1, st.StatusName , RealState.active " +
                        " FROM ((((((( RealState LEFT JOIN " +
                        " BuildingType bt ON bt.ID = RealState.Building_Type_ID) LEFT JOIN " +
                        " Investiture i ON i.ID = RealState.investiture) LEFT JOIN " +
                        " Region re ON re.ID = RealState.Region_ID) LEFT JOIN " +
                        " WayOfRent wr ON wr.ID = RealState.WayOfRent) LEFT JOIN " +
                        " Users ON RealState.ID = Users.ID ) LEFT JOIN " +
                        " StatusType st ON st.ID = RealState.Status_ID ) LEFT JOIN " +
                        " Event Event ON RealState.ID = Event.RealStateID )"
                        + whereClouseexact() + "");



                }
                else
                {
                    DoQuery("SELECT RealState.ID, RealState.Region_ID, RealState.SubResgionID, RealState.Building, RealState.Floor, RealState.FloorComment, RealState.Entrance, " +
                         " RealState.Distance, RealState.Building_Type_ID, RealState.Owner, RealState.Phone_one, RealState.Phone_Two, RealState.Mobile, RealState.Other, " +
                         " RealState.DateOfEnter, RealState.UserID, RealState.area,RealState.Rooms, RealState.Mobile2, RealState.Price, RealState.investiture, RealState.WayOfRent, RealState.[Key], " +
                         " RealState.[Note], RealState.Info_Source, RealState.Status_ID, RealState.StartRentDate, RealState.EndRendDate, RealState.Period, " +
                         " RealState.RemainingDay, bt.Building_Type, i.Investiture_Name, re.Name, Users.User_Name, wr.WayOfRent AS Expr1, st.StatusName , RealState.active " +
                         " FROM ((((((RealState LEFT JOIN " +
                         " BuildingType bt ON bt.ID = RealState.Building_Type_ID) LEFT JOIN " +
                         " Investiture i ON i.ID = RealState.investiture) LEFT JOIN " +
                         " Region re ON re.ID = RealState.Region_ID) LEFT JOIN " +
                         " WayOfRent wr ON wr.ID = RealState.WayOfRent) LEFT JOIN " +
                         " Users ON RealState.ID = Users.ID ) LEFT JOIN " +
                         " StatusType st ON st.ID = RealState.Status_ID )" + whereClouseexact() + "");
                }
            }
        }

        public string whereClouseexact()
        {
            //Utils.getsetting();
            string prametrs = " where ";
            string statuc = "";
            string buildingtype = "";
            string way = "";

            

            if (cmbRegion.SelectedValue != null)
            {
                prametrs += " RealState.Region_ID=" + Convert.ToInt32(cmbRegion.SelectedValue.ToString()) + "";
                prametrs += " and ";
            }


            if (txtSubregion.Text != "")
            {
                string[] prameter = txtSubregion.Text.Split('-');
                if (prameter.Length > 1)
                {
                    prametrs += "(";
                    foreach (string f in prameter)
                    {

                        prametrs += " ( RealState.SubResgionID = '" + f.Trim() + "' )";
                        prametrs += " or ";

                    }

                    prametrs = prametrs.Substring(0, prametrs.LastIndexOf("or"));
                    prametrs += ")";

                }
                else
                {

                    prametrs += " RealState.SubResgionID='" + txtSubregion.Text.Trim() + "'";
                }

                prametrs += " and ";


            }


            if (txtBuilding.Text != "")
            {
               //prametrs +=" RealState.Building like '%" + building.Text.Trim() + "%'";
              
                prametrs += " RealState.Building='" + txtBuilding.Text.Trim() + "'";
                prametrs += " and ";
            }

            if (txtNumberOfRooms.Text.Trim() != "")
            {
                prametrs += " RealState.Rooms=" + Convert.ToInt32(txtNumberOfRooms.Text.Trim()) + "";
                prametrs += " and ";
            }

            if (txtFloor.Text != "")
            {

                prametrs += " RealState.Floor=" + Convert.ToInt32(txtFloor.Text.Trim()) + "";
                prametrs += " and ";
            }
            if (txtFloorComment.Text != "")
            {
                prametrs += " RealState.FloorComment = '" + txtFloorComment.Text.Trim() + "'";
                prametrs += " and ";
            }

            if (cmbBuildingType.SelectedItem != null)
            {
                buildingtype = cmbBuildingType.SelectedItem.ToString();
                if (buildingtype == "برجي")
                {
                    prametrs += " RealState.Building_Type_ID= 1 ";
                }
                if (buildingtype == "طابقي")
                {
                    prametrs += " RealState.Building_Type_ID= 2 ";
                }

                if (buildingtype == "تراسي")
                {
                    prametrs += " RealState.Building_Type_ID= 3 ";
                }
                if (buildingtype == "ارض")
                {
                    prametrs += " RealState.Building_Type_ID= 4 ";
                }

                if (buildingtype == "سوق تجاري")
                {
                    prametrs += " RealState.Building_Type_ID= 5 ";
                }

                prametrs += " and ";

            }
            //WHERE (RealState.Building_Type_ID = 1) AND (RealState.area = 140) OR (RealState.area <= 150) AND (RealState.active = 1)
            if (txtAreaFrom.Text != "")
            {

                if (txtAreaTo.Text != "")
                {
                    //                    prametrs += "(RealState.area >=" + Convert.ToInt32(af.Text) + " and RealState.area <=" + Convert.ToInt32(at.Text) + " ) and ( RealState.area >=" + Convert.ToInt32(af.Text) + " and RealState.area >=" + Convert.ToInt32(af.Text) + ")";
                    prametrs += "(RealState.area >=" + Convert.ToInt32(txtAreaFrom.Text.Trim()) + ") and (RealState.area <=" + Convert.ToInt32(txtAreaTo.Text.Trim()) + " )";
                }
                else
                {

                    prametrs += " RealState.area =" + Convert.ToInt32(txtAreaFrom.Text.Trim()) + "";
                }

                prametrs += " and ";
            }


            if (txtPriceFrom.Text != "")
            {

                if (txtPriceTo.Text != "")
                {
                    //prametrs += "( RealState.Price >=" + Convert.ToInt32(cf.Text) + " and ( RealState.Price <=" + Convert.ToInt32(ct.Text) +") and ( RealState. Price >=" + Convert.ToInt32(ct.Text) + " and RealState. Price >=" + Convert.ToInt32(ct.Text)+")";
                    prametrs += "( RealState.Price >=" + Convert.ToInt32(txtPriceFrom.Text.Trim()) + ") and ( RealState.Price <=" + Convert.ToInt32(txtPriceTo.Text.Trim()) + ")";
                }
                else
                {

                    prametrs += " RealState.Price =" + Convert.ToInt32(txtPriceFrom.Text.Trim()) + "";
                }
                prametrs += " and ";
            }


            if (cmbRentalMethod.SelectedItem != null)
            {
                way = cmbRentalMethod.SelectedItem.ToString();
                if (way == "مفروش")
                {
                    prametrs += "( RealState.WayOfRent= 1 or RealState.WayOfRent= 3 ) ";
                }
                if (way == "غير مفروش")
                {
                    prametrs += " ( RealState.WayOfRent= 2 or RealState.WayOfRent= 3 ) ";
                }

                if (way == "كلتا الحالتين")
                {
                    prametrs += " (RealState.WayOfRent= 3 or  RealState.WayOfRent= 1 or  RealState.WayOfRent= 2)  ";
                }

                // prametrs += " RealState.WayOfRent=" + Convert.ToInt32(wayofrentcobmo.SelectedValue.ToString()) + "";
                prametrs += " and ";

            }

            if (cmbStatus.SelectedItem != null)
            {

                statuc = cmbStatus.SelectedItem.ToString();
                if (statuc == "مؤجر")
                {
                    if (txtRentalExpiryDate.Text != "" && txtRentalExpiryDate.Text != null)
                    {
                        prametrs += " RealState.Status_ID = 1 and RealState.RemainingDay <=" + Convert.ToInt32(txtRentalExpiryDate.Text) + "";
                    }
                    else
                    {
                        prametrs += " RealState.Status_ID = 1";
                    }

                    prametrs += " and ";
                }

                if (statuc == "غير مؤجر")
                {
                    prametrs += " RealState.Status_ID = 2";
                   // prametrs += " RealState.RemainingDay <=" + Utils.RemainderingPeriodEmpty + "";
                    prametrs += " and ";
                }

                if (statuc == "كلتا الحالتين")
                {
                    prametrs += "RealState.RemainingDay <=" + Convert.ToInt32(txtRentalExpiryDate.Text) + "";
                    prametrs += " and ";
                }


            }

            if (txtHomeOwner.Text != "")
            {
                prametrs += "( RealState.Owner = '" + txtHomeOwner.Text.Trim() + "' or ";



                string trimed = txtHomeOwner.Text.Trim().Substring(1, txtHomeOwner.Text.Trim().Length - 1);

                prametrs += " RealState.Owner like '%[أا]" + trimed + "%' or ";
                trimed = txtHomeOwner.Text.Trim().Replace("أ", "ا");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = txtHomeOwner.Text.Trim().Replace("ا", "أ");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = txtHomeOwner.Text.Trim().Substring(0, txtHomeOwner.Text.Trim().Length - 1);
                prametrs += " RealState.Owner like '%" + trimed + "[ى ي]%' or ";
                trimed = txtHomeOwner.Text.Trim().Substring(0, txtHomeOwner.Text.Trim().Length - 1);
                prametrs += " RealState.Owner like '%" + trimed + "[ى ا]%' or ";
                trimed = txtHomeOwner.Text.Trim().Substring(0, txtHomeOwner.Text.Trim().Length - 1);
                prametrs += " RealState.Owner like '%" + trimed + "[ةه]%' or ";
                trimed = txtHomeOwner.Text.Trim().Substring(1, txtHomeOwner.Text.Trim().Length - 2);
                prametrs += " RealState.Owner like '%[أا]" + trimed + "[ةه]%'  or ";
                trimed = txtHomeOwner.Text.Trim().Substring(1, txtHomeOwner.Text.Trim().Length - 2);
                prametrs += " RealState.Owner like '%[أا]" + trimed + "[ى ا]%' or ";
                trimed = txtHomeOwner.Text.Trim().Substring(1, txtHomeOwner.Text.Trim().Length - 2);
                prametrs += " RealState.Owner like '%[أا]" + trimed + "[ى ي]%' ) ";





                prametrs += " and ";

                //prametrs += " RealState.Owner = '" + owner.Text.Trim() + "'";
                //prametrs += " and ";
            }

            if (p1.Text != "")
            {
                prametrs += " ( ";
                prametrs += " RealState.Phone_one = '" + p1.Text.Trim() + "'";
                prametrs += " or ";
                prametrs += " RealState.Phone_Two = '" + p1.Text.Trim() + "'";
                prametrs += " or ";
                prametrs += " RealState.Mobile = '" + p1.Text.Trim() + "'";
                prametrs += " or ";
                prametrs += " RealState.Mobile2 = '" + p1.Text.Trim() + "'";
                prametrs += " or ";
                prametrs += " RealState.Other = '" + p1.Text.Trim() + "'";
                prametrs += " ) ";
                prametrs += " and ";
            }


            //if (p2.Text != "")
            //{
            //    prametrs += " RealState.Phone_Two like '%" + p2.Text + "%'";
            //    prametrs += " and ";
            //}

            //if (mop.Text != "")
            //{
            //    prametrs += " RealState.Mobile like '%" + mop.Text + "%'";
            //    prametrs += " and ";
            //}

            //if (other.Text != "")
            //{
            //    prametrs += " RealState.Other = '" + other.Text + "'";
            //    prametrs += " and ";

            //}

            if (chkInArchive.Checked == true)
            {
                prametrs += " RealState.active=0";
                prametrs += " and ";
            }
            else
            {
                prametrs += " RealState.active=1";
                prametrs += " and ";

            }

            //hadi
            //if (txtInEvent.Text != "")
            //{
            //    prametrs += " Event.Event = '" + txtInEvent.Text + "'";
            //    prametrs += " and ";

            //}

            ///// Added Code
            //if (checkBox1.Checked)
            //{
            //    prametrs += " AND EXISTS (SELECT * FROM Attachment A WHERE A.RealState_ID = RealState.ID AND NOT (A.Comment LIKE '%ارفاق الي%' OR A.Comment LIKE '%ارفاق آلي%' OR A.Comment LIKE '%صورة كراج البناء%'))";
            //}

            //return prametrs.Substring(0, prametrs.LastIndexOf("and"));


            if (txtInEvent.Text != "")
            {
                prametrs += " Event.Event = '" + txtInEvent.Text + "' AND ";
            }

            // شرط الفلترة على الصور
            if (checkBox1.Checked)
            {
                prametrs += " EXISTS (SELECT * FROM Attachment A WHERE A.RealState_ID = RealState.ID AND NOT (A.Comment LIKE '%ارفاق الي%' OR A.Comment LIKE '%ارفاق آلي%' OR A.Comment LIKE '%صورة كراج البناء%')) AND ";
            }

            // في الآخر نشيل آخر AND لو اتضافت
            if (prametrs.EndsWith(" AND "))
            {
                prametrs = prametrs.Substring(0, prametrs.Length - 5); // نشيل " AND "
            }

            return prametrs;
        }

        public string whereClouse()
        {
            //Utils.getsetting();
            string prametrs = " where ";
            string statuc = "";
            string buildingtype = "";
            string way = "";


            if (txtID.Text != "")
            {
                prametrs += " RealState.ID =" + txtID.Text;
                return prametrs;
            }


            if (cmbRegion.SelectedValue != null)
            {
                prametrs += " RealState.Region_ID=" + Convert.ToInt32(cmbRegion.SelectedValue.ToString()) + "";
                prametrs += " and ";
            }


            if (txtSubregion.Text != "")
            {
                string[] prameter = txtSubregion.Text.Split('-');
                if (prameter.Length > 1)
                {
                    prametrs += "(";
                    foreach (string f in prameter)
                    {
                       // prametrs += "( RealState.SubResgionID = '" + f.Trim() + "' )";
                        prametrs += "( RealState.SubResgionID like '%" + f.Trim() + "%' )";
                        prametrs += " or ";
                    }

                    prametrs = prametrs.Substring(0, prametrs.LastIndexOf("or"));
                    prametrs += ")";

                }
                else
                {
                    prametrs += " RealState.SubResgionID like  '%" + txtSubregion.Text.Trim() + "%'";
                    // prametrs += " RealState.SubResgionID =  '" + subregioncombo.Text.Trim() + "'";
                }
                prametrs += " and ";
            }

            if (txtBuilding.Text != "")
            {
                prametrs += " RealState.Building like '%" + txtBuilding.Text.Trim() + "%'";
                prametrs += " and ";
            }

            if (txtNumberOfRooms.Text.Trim() != "")
            {
                prametrs += " RealState.Rooms=" + Convert.ToInt32(txtNumberOfRooms.Text.Trim()) + "";
                prametrs += " and ";
            }

            if (txtFloor.Text != "")
            {
                prametrs += " RealState.Floor=" + Convert.ToInt32(txtFloor.Text.Trim()) + "";
                prametrs += " and ";
            }
            if (txtFloorComment.Text != "")
            {
                prametrs += " RealState.FloorComment like '%" + txtFloorComment.Text.Trim() + "%'";
                prametrs += " and ";
            }

            if (cmbBuildingType.SelectedItem != null)
            {
                //Edited Codee
                buildingtype = ((DataRowView)cmbBuildingType.SelectedItem)["Building_Type"].ToString(); //cmbBuildingType.SelectedItem.ToString();
                if (buildingtype == "برجي")
                {
                    prametrs += " RealState.Building_Type_ID= 1 ";
                }
                if (buildingtype == "طابقي")
                {
                    prametrs += " RealState.Building_Type_ID= 2 ";
                }
                if (buildingtype == "تراسي")
                {
                    prametrs += " RealState.Building_Type_ID= 3 ";
                }
                if (buildingtype == "ارض")
                {
                    prametrs += " RealState.Building_Type_ID= 4 ";
                }

                if (buildingtype == "سوق تجاري")
                {
                    prametrs += " RealState.Building_Type_ID= 5 ";
                }
                prametrs += " and ";

            }
            //WHERE (RealState.Building_Type_ID = 1) AND (RealState.area = 140) OR (RealState.area <= 150) AND (RealState.active = 1)
            if (txtAreaFrom.Text != "")
            {

                if (txtAreaTo.Text != "")
                {
                    //                    prametrs += "(RealState.area >=" + Convert.ToInt32(af.Text) + " and RealState.area <=" + Convert.ToInt32(at.Text) + " ) and ( RealState.area >=" + Convert.ToInt32(af.Text) + " and RealState.area >=" + Convert.ToInt32(af.Text) + ")";
                    prametrs += "(RealState.area >=" + Convert.ToInt32(txtAreaFrom.Text.Trim()) + ") and (RealState.area <=" + Convert.ToInt32(txtAreaTo.Text.Trim()) + " )";
                }
                else
                {

                    prametrs += " RealState.area =" + Convert.ToInt32(txtAreaFrom.Text.Trim()) + "";
                }

                prametrs += " and ";
            }


            if (txtPriceFrom.Text != "")
            {

                if (txtPriceTo.Text != "")
                {
                    //prametrs += "( RealState.Price >=" + Convert.ToInt32(cf.Text) + " and ( RealState.Price <=" + Convert.ToInt32(ct.Text) +") and ( RealState. Price >=" + Convert.ToInt32(ct.Text) + " and RealState. Price >=" + Convert.ToInt32(ct.Text)+")";
                    prametrs += "( RealState.Price >=" + Convert.ToInt32(txtPriceFrom.Text.Trim()) + ") and ( RealState.Price <=" + Convert.ToInt32(txtPriceTo.Text) + ")";
                }
                else
                {

                    prametrs += " RealState.Price =" + Convert.ToInt32(txtPriceFrom.Text.Trim()) + "";
                }
                prametrs += " and ";
            }


            if (cmbRentalMethod.SelectedItem != null)
           {
                way = cmbRentalMethod.SelectedItem.ToString();

                if (way == "مفروش")
                {
                    prametrs += "( RealState.WayOfRent= 1 or RealState.WayOfRent= 3 ) ";
                }
                if (way == "غير مفروش")
                {   
                    prametrs += " ( RealState.WayOfRent= 2 or RealState.WayOfRent= 3 ) ";
                }
                if (way == "كلتا الحالتين")
                {
                    prametrs += " ( RealState.WayOfRent= 3 or RealState.WayOfRent= 2 or RealState.WayOfRent= 1) ";
                }

                // prametrs += " RealState.WayOfRent=" + Convert.ToInt32(wayofrentcobmo.SelectedValue.ToString()) + "";
                prametrs += " and ";

            }

            if (cmbStatus.SelectedItem != null)
            {

                statuc = cmbStatus.SelectedItem.ToString();
                if (statuc == "مؤجر")
                {
                    if (txtRentalExpiryDate.Text != "" && txtRentalExpiryDate.Text != null)
                    {
                        prametrs += " RealState.Status_ID = 1 and RealState.RemainingDay <=" + Convert.ToInt32(txtRentalExpiryDate.Text) + "";
                    }
                    else
                    {
                        prametrs += " RealState.Status_ID = 1";
                    }

                    prametrs += " and ";
                }

                if (statuc == "غير مؤجر")
                {
                    prametrs += " (RealState.Status_ID =2";
                    prametrs += " or  (RealState.Status_ID =1 and RealState.RemainingDay <=" + Utils.RemainderingPeriodEmpty + "))";
                    prametrs += " and ";
                }

                if (statuc == "كلتا الحالتين")
                {
                    if (txtRentalExpiryDate.Text != "" && txtRentalExpiryDate.Text != null)
                    {
                        prametrs += "RealState.RemainingDay <=" + Convert.ToInt32(txtRentalExpiryDate.Text) + "";
                        prametrs += " and ";
                    }
                }


            }

            if (txtHomeOwner.Text != "")
            {

                prametrs += "( RealState.Owner like '%" + txtHomeOwner.Text.Trim() + "%' or ";

                string trimed = txtHomeOwner.Text.Trim();

                string Hmza = txtHomeOwner.Text.Trim().Replace("أ", "ا");
                prametrs += " RealState.Owner like '%" + Hmza + "%' or ";
                trimed = Hmza.Trim().Replace("ه", "ة");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ة", "ه");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ي", "ى");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ى", "ي");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ا", "ه");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ه", "ا");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";


                string Alftriemd = txtHomeOwner.Text.Trim().Replace("ا", "أ");
                prametrs += " RealState.Owner like '%" + Alftriemd + "%' or ";
                trimed = Alftriemd.Trim().Replace("ه", "ة");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ة", "ه");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ي", "ى");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ى", "ي");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ا", "ه");
                prametrs += " RealState.Owner like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ه", "ا");
                prametrs += " RealState.Owner like '%" + trimed + "%' )  ";


                prametrs += " and ";

            }

            if (p1.Text != "")
            {
                prametrs += " ( ";
                prametrs += " RealState.Phone_one like '%" + p1.Text.Trim() + "%'";
                prametrs += " or ";
                prametrs += " RealState.Phone_Two like '%" + p1.Text.Trim() + "%'";
                prametrs += " or ";
                prametrs += " RealState.Mobile like '%" + p1.Text.Trim() + "%'";
                prametrs += " or ";
                prametrs += " RealState.Mobile2 like '%" + p1.Text.Trim() + "%'";
                prametrs += " or ";
                prametrs += " RealState.Other like '%" + p1.Text.Trim() + "%'";
                prametrs += " ) ";
                prametrs += " and ";
            }
            //if (p2.Text != "")
            //{
            //    prametrs += " RealState.Phone_Two like '%" + p2.Text + "%'";
            //    prametrs += " and ";
            //}

            //if (mop.Text != "")
            //{
            //    prametrs += " RealState.Mobile like '%" + mop.Text + "%'";
            //    prametrs += " and ";
            //}

            //if (other.Text != "")
            //{
            //    prametrs += " RealState.Other like '%" + other.Text + "%'";
            //    prametrs += " and ";

            //}

            if (chkInArchive.Checked == true)
            {
                prametrs += " RealState.active=0";
                prametrs += " and ";
            }
            else
            {
                prametrs += " RealState.active=1";
                prametrs += " and ";

            }
            //hadi
            if (txtInEvent.Text != "")
            {
                prametrs += " Event.Event like '%" + txtInEvent.Text + "%'";
                prametrs += " and ";
            }

            // ✅ شرط الصور المرفقة
            if (checkBox1.Checked)
            {
                prametrs += " EXISTS (SELECT * FROM Attachment A WHERE A.RealState_ID = RealState.ID AND NOT (A.Comment LIKE '%ارفاق الي%' OR A.Comment LIKE '%ارفاق آلي%' OR A.Comment LIKE '%صورة كراج البناء%'))";
                prametrs += " and ";
            }


            prametrs = prametrs.Substring(0, prametrs.LastIndexOf("and"));

           

            if (statuc == "غير مؤجر")
                prametrs += " order by RealState.Status_ID desc,RealState.RemainingDay; ";
            else
               prametrs += " order by RealState.Status_ID,RealState.RemainingDay; ";

         
            return prametrs;
        }

        void DoQuery(string clouse)
        {
            //SearchParameter sp = new SearchParameter(clouse);

            Appointsearch sp = new Appointsearch(clouse);
            if (sp.y == 1)
            {

                sp.ShowDialog();
                //ShowModalExcept(sp, MainForm.searchForm);

            }
            else if (sp.y != 2)
            {
                MessageBox.Show("لا توجد معلومات");
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



        string name = "";
        string type = "";

        public void getcustomer()
        {

            insertintophone.am = "rent";
            insertintophone.ShowMe();
            name = Utils.NameOfCustomer;

            type = "new";
            Utils.appdate = insertintophone.appdate;
            Utils.apptime = insertintophone.apptime;
            Gp1.BackColor = System.Drawing.Color.Red;
            Gp1.ForeColor = System.Drawing.Color.Red;

            if (name == "" || name == null)
            {
                Utils.RentRecord = false;
                Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            }

        }

        void FillBuildingType()
        {
            try
            {
                DataTable buildingTypes = clsBuildingType.GetAllBuildingTypes();
               
                cmbBuildingType.DataSource = null; 
                cmbBuildingType.DisplayMember = "Building_Type";
                cmbBuildingType.ValueMember = "ID";
                cmbBuildingType.DataSource = buildingTypes;

                cmbBuildingType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل أنواع المباني:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void always_Load(object sender, EventArgs e)
        {
            
            FillBuildingType();
            // TODO: This line of code loads data into the 'dSrealstate.RealState' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dSregion.Region' table. You can move, or remove it, as needed.
            this.regionTableAdapter.Fill(this.dSregion.Region);
            this.m_wndToolTip = new System.Windows.Forms.ToolTip(this.components);
            m_wndToolTip.ShowAlways = true;

            cmbStatus.SelectedIndex = 1;
            cmbRegion.Text = null;
            cmbBuildingType.Text = null;
            cmbRegion.Focus();


            // Not used 
            //_Timer.Interval = 1000;

            //_Timer.Tick += new EventHandler(_Timer_Tick);

            //_Timer.Start();

            ////
            RefreshUserUI();

        }


        private void buildingTextBox_KeyUp(object sender, KeyEventArgs e)
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

        private void entranceTextBox_MouseClick(object sender, MouseEventArgs e)
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


                if (al != "")
                    m_wndToolTip.SetToolTip(this.ActiveControl, al);
            }
        }

        private void p1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar.ToString() == "+")
            {
                this.ActiveControl.Text += "000";
            }

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

        }

        private void always_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //13 = enter
                button1.PerformClick();

            if (e.KeyData == Keys.F12)
                btnDischarge.PerformClick();

        }

        private void statuscombo_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (cmbStatus.SelectedItem != null)
            {

                string statuc = cmbStatus.SelectedItem.ToString();
                if (statuc == "مؤجر")
                {
                    txtRentalExpiryDate.ReadOnly = false;
                }
                if (statuc == "غير مؤجر")
                {
                    txtRentalExpiryDate.ReadOnly = true;
                }
                if (statuc == "كلتا الحالتين")
                {
                    txtRentalExpiryDate.ReadOnly = false;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtID.Text= "";
            cmbRegion.SelectedIndex = -1;
            txtSubregion.Text = "";
            txtBuilding.Text ="";
            txtFloor.Text = "";
            txtFloorComment.Text = "";
            cmbBuildingType.SelectedIndex = -1;
            txtAreaFrom.Text = "";
            txtPriceFrom.Text = "";
            txtAreaTo.Text = "";
            txtPriceTo.Text = "";
            txtNumberOfRooms.Text = "";
            cmbRentalMethod.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            txtHomeOwner.Text = "";
            p1.Text = "";
            chkInArchive.Checked = false;
            checkBox2.Checked = false;
            checkBox1.Checked = false;
            txtInEvent.Text = "";
            txtRentalExpiryDate.Text = "";
            //****
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {


            if (keyData == Keys.F12)
            {
                btnDischarge.PerformClick();
                return true;
            }
            if (keyData == Keys.F11)
            {
                Utils.EncryptMode = !Utils.EncryptMode;

                //if (Utils.EncryptMode)
                //{

                //    MainForm.Imagencrypt.Visible = true;
                //    MainForm.Imagencrypt2.Visible = true;
                //}
                //if (!Utils.EncryptMode)
                //{
                //    MainForm.Imagencrypt.Visible = false;
                //    MainForm.Imagencrypt2.Visible = false;
                //}
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
            if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.F10) == Keys.F10))
            {
                return true;
            }

            if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.PageDown) == Keys.PageDown))
            {
                return true;
            }
            if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.PageUp) == Keys.PageUp))
            {
                return true;
            }

            return false;

        }

        private void always_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F12)
            {
                btnDischarge.PerformClick();

            }
        }


        private void button3_Click(object sender, EventArgs e)
        {


            if (Utils.RentRecord == false)
            {
                Utils.RentRecord = true;

                if (Utils.NameOfCustomer == "")
                {
                    getcustomer();
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (Utils.RentRecord == true && Utils.SortdDTRealAppointinfo.Count > 0)
            {

                //AppointmentsNumbersTableAdapter.Insert("rent");
                //              phoneEventTableAdapter.Insert(Utils.PhoneID, DateTime.Now, Utils.current_user, Utils.appdate + " " + Utils.apptime + "تم موعد في ");
                PrintGried gd = new PrintGried("rent");
                //gd.Name = Utils.NameOfCustomer;
                //gd.date = Utils.appdate;
                //gd.time = Utils.apptime;
                gd.ShowDialog();
                //ShowModalExcept(gd, MainForm.searchForm);


                Utils.RentRecord = false;
                Utils.NameOfCustomer = "";
                Utils.NameOfCustomer = "";
                Utils.CustPhon = "";
                Utils.CustMobile = "";
                Utils.CusOther = "";
                Utils.SortdDTRealAppointinfo.Clear();

                Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }

        }


        private void TextNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // يسمح بالأرقام فقط
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show(
                                     "الرجاء ادخال ارقام فقط",
                                     "خطأ",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error,
                                     MessageBoxDefaultButton.Button3,
                                     MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                                 );
            }
        }

        private void PanelUserColo_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void user_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Added Code
        /// </summary>
        /// 

        private void SetUserColorFromCache()
        {
            try
            {
                var user = Utils.cachedUsers.FirstOrDefault(u => u.UserName == Utils.current_user);

                if (user != null)
                {
                    PanelUserColo.BackColor = ColorTranslator.FromHtml(user.Color); // أو PanelUserColo على حسب اسم العنصر
                }
                else
                {
                    PanelUserColo.BackColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل اللون من الكاش: " + ex.Message);
                PanelUserColo.BackColor = Color.Gray;
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {


            // نعرض نفس فورم تسجيل الدخول الحالية
            LoginMsg loginMsg = new LoginMsg();

            //// نوقف تنفيذ الكود لحين ما المستخدم يختار اسم ويدوس "دخول"
            if (loginMsg.ShowDialog() == DialogResult.OK)
            {
                // تحديث اسم المستخدم الجديد من فورم تسجيل الدخول
                string newUsername = Utils.current_user; // من المفترض أن LoginForm يكتب الاسم في Utils.current_user

                // تحديث الاسم في الفورم الرئيسية
                this.user.Text = "مرحبًا " + newUsername;

                // إعادة تحميل الصلاحيات (لو مرتبطة بالمستخدم)
                if (MainForm.Instance != null)
                {
                    MainForm.Instance.ReloadUserPermissions();
                    MainForm.Instance.RefreshAllTabs();
                }
            }
        }

        public void RefreshUserUI()
        {
            user.Text = "مرحبًا " + Utils.current_user;
            SetUserColorFromCache();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }

}
