using RealStateRentSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class alwaysOwner : Form
    {
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
        private DSTables.DSappointmentTableAdapters.AppointmentsNumbersTableAdapter AppointmentsNumbersTableAdapter = new DSTables.DSappointmentTableAdapters.AppointmentsNumbersTableAdapter();
        private System.Windows.Forms.ToolTip m_wndToolTip;
        private CustomSource BuildingautoComplete;
        private bool isLoaded = false;


        public alwaysOwner()
        {
            InitializeComponent();
            
            groupBox2.BackColor = Color.FromArgb(45, 216, 129);
            Clock c = new Clock();
            c.TopLevel = false;
            c.MdiParent = this.MdiParent;
            //this.Controls.Add(c);
            //c.Show();

            //DataAccess dataAccess = new DataAccess();
            //BuildingautoComplete = new CustomSource(dataAccess.GetBuilding().ToArray());
            //building.AutoCompleteMode = AutoCompleteMode.Suggest;
            //building.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //BuildingautoComplete.Bind(building);
            if (BuildingautoComplete == null)
            {
                DataAccess dataAccess = new DataAccess();
                BuildingautoComplete = new CustomSource(dataAccess.GetBuilding().ToArray());
                building.AutoCompleteMode = AutoCompleteMode.Suggest;
                building.AutoCompleteSource = AutoCompleteSource.CustomSource;
                BuildingautoComplete.Bind(building);
            }

            ///
            CenterControlsHorizontally();
            this.Resize += new EventHandler(Form1_Resize);

            //CenterControls();
            //this.Resize += (s, e) => CenterControls();
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



        //private void CenterControls()
        //{
        //    // احسبي مركز الفورم
        //    int formCenterX = this.ClientSize.Width / 2;
        //    int formCenterY = this.ClientSize.Height / 2;

        //    // نحط الكنترولات حوالين المركز

        //    // توسيط pictureBox1 في الأعلى
        //    pictureBox1.Left = formCenterX - pictureBox1.Width / 2;
        //    pictureBox1.Top = formCenterY - 150;

        //    // توسيط label1 تحت الصورة
        //    label1.Left = formCenterX - label1.Width / 2;
        //    label1.Top = pictureBox1.Bottom + 10;

        //    // label2 تحت label1
        //    label2.Left = formCenterX - label2.Width / 2;
        //    label2.Top = label1.Bottom + 10;

        //    // label3 تحت label2
        //    label3.Left = formCenterX - label3.Width / 2;
        //    label3.Top = label2.Bottom + 10;
        //}


        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                if (textBox1.Text != "")
                {
                    DoQuery(" SELECT RealstateOwne.ID, RealstateOwne.Region_ID, RealstateOwne.SubResgionID," +
                    " RealstateOwne.Building, RealstateOwne.Floor," +
                    " RealstateOwne.FloorComment, " +
                    " RealstateOwne.Entrance, RealstateOwne.Distance, " +
                    " RealstateOwne.Building_Type_ID,RealstateOwne.Owner, " +
                    " RealstateOwne.Phone_one, RealstateOwne.Phone_Two," +
                    " RealstateOwne.Mobile, RealstateOwne.Other, " +
                    " RealstateOwne.DateOfEnter, RealstateOwne.UserID, " +
                    " RealstateOwne.area,RealstateOwne.Rooms, RealstateOwne.Price," +
                    " RealstateOwne.investiture, RealstateOwne.WayOFOwner," +
                    " RealstateOwne.[Key], RealstateOwne.[Note]," +
                    " RealstateOwne.Info_Source, RealstateOwne.active," +
                    " RealstateOwne.DateOchange," +
                    " RealstateOwne.Mobile2, " +
                    " bt.Building_Type, i.Investiture_Name, Users.User_Name" +
                    " FROM (((( RealstateOwne LEFT JOIN" +
                    " BuildingType bt ON bt.ID =  RealstateOwne.Building_Type_ID) LEFT  JOIN" +
                    " OwnInvestiture i ON i.ID =  RealstateOwne.investiture) LEFT  JOIN" +
                    " Users ON  RealstateOwne.ID = Users.ID) LEFT JOIN " +
                    " eventown eventown ON RealstateOwne.ID = eventown.RealStateID )" +
                     whereClouse() + "");

                }
                else
                {
                    DoQuery(" SELECT RealstateOwne.ID, RealstateOwne.Region_ID, RealstateOwne.SubResgionID," +
                             " RealstateOwne.Building, RealstateOwne.Floor," +
                             " RealstateOwne.FloorComment, " +
                             " RealstateOwne.Entrance, RealstateOwne.Distance, " +
                             " RealstateOwne.Building_Type_ID,RealstateOwne.Owner, " +
                             " RealstateOwne.Phone_one, RealstateOwne.Phone_Two," +
                             " RealstateOwne.Mobile, RealstateOwne.Other, " +
                             " RealstateOwne.DateOfEnter, RealstateOwne.UserID, " +
                             " RealstateOwne.area,RealstateOwne.Rooms, RealstateOwne.Price," +
                             " RealstateOwne.investiture, RealstateOwne.WayOFOwner," +
                             " RealstateOwne.[Key], RealstateOwne.[Note]," +
                             " RealstateOwne.Info_Source, RealstateOwne.active," +
                             " RealstateOwne.DateOchange," +
                             " RealstateOwne.Mobile2, " +
                             " bt.Building_Type, i.Investiture_Name, Users.User_Name" +
                             " FROM ((( RealstateOwne LEFT JOIN" +
                             " BuildingType bt ON bt.ID =  RealstateOwne.Building_Type_ID) LEFT  JOIN" +
                             " OwnInvestiture i ON i.ID =  RealstateOwne.investiture) LEFT  JOIN" +
                             " Users ON  RealstateOwne.ID = Users.ID)"
                             + whereClouse() + "");

                }
            }
            else
            {
                if (textBox1.Text != "")
                {
                    DoQuery(" SELECT RealstateOwne.ID, RealstateOwne.Region_ID, RealstateOwne.SubResgionID," +
                            " RealstateOwne.Building, RealstateOwne.Floor," +
                            " RealstateOwne.FloorComment, " +
                            " RealstateOwne.Entrance, RealstateOwne.Distance, " +
                            " RealstateOwne.Building_Type_ID,RealstateOwne.Owner, " +
                            " RealstateOwne.Phone_one, RealstateOwne.Phone_Two," +
                            " RealstateOwne.Mobile, RealstateOwne.Other, " +
                            " RealstateOwne.DateOfEnter, RealstateOwne.UserID, " +
                            " RealstateOwne.area,RealstateOwne.Rooms, RealstateOwne.Price," +
                            " RealstateOwne.investiture, RealstateOwne.WayOFOwner," +
                            " RealstateOwne.[Key], RealstateOwne.[Note]," +
                            " RealstateOwne.Info_Source, RealstateOwne.active," +
                            " RealstateOwne.DateOchange," +
                            " RealstateOwne.Mobile2, " +
                            " bt.Building_Type, i.Investiture_Name, Users.User_Name" +
                            " FROM (((( RealstateOwne LEFT JOIN" +
                            " BuildingType bt ON bt.ID =  RealstateOwne.Building_Type_ID) LEFT  JOIN" +
                            " OwnInvestiture i ON i.ID =  RealstateOwne.investiture) LEFT  JOIN" +
                            " Users ON  RealstateOwne.ID = Users.ID) LEFT JOIN " +
                            " eventown eventown ON RealstateOwne.ID = eventown.RealStateID )"
                            + whereClouseexact() + "");
                }
                else
                {
                    DoQuery(" SELECT RealstateOwne.ID, RealstateOwne.Region_ID, RealstateOwne.SubResgionID," +
                                                " RealstateOwne.Building, RealstateOwne.Floor," +
                                                " RealstateOwne.FloorComment, " +
                                                " RealstateOwne.Entrance, RealstateOwne.Distance, " +
                                                " RealstateOwne.Building_Type_ID,RealstateOwne.Owner, " +
                                                " RealstateOwne.Phone_one, RealstateOwne.Phone_Two," +
                                                " RealstateOwne.Mobile, RealstateOwne.Other, " +
                                                " RealstateOwne.DateOfEnter, RealstateOwne.UserID, " +
                                                " RealstateOwne.area,RealstateOwne.Rooms, RealstateOwne.Price," +
                                                " RealstateOwne.investiture, RealstateOwne.WayOFOwner," +
                                                " RealstateOwne.[Key], RealstateOwne.[Note]," +
                                                " RealstateOwne.Info_Source, RealstateOwne.active," +
                                                " RealstateOwne.DateOchange," +
                                                " RealstateOwne.Mobile2, " +
                                                " bt.Building_Type, i.Investiture_Name, Users.User_Name" +
                                                " FROM ((( RealstateOwne LEFT JOIN" +
                                                " BuildingType bt ON bt.ID =  RealstateOwne.Building_Type_ID) LEFT  JOIN" +
                                                " OwnInvestiture i ON i.ID =  RealstateOwne.investiture) LEFT  JOIN" +
                                                " Users ON  RealstateOwne.ID = Users.ID)"
                                                + whereClouseexact() + "");
                }


            }


        }
        public string whereClouseexact()
        {
            //Utils.getsetting();
            string prametrs = " where ";
            string buildingtype = "";
            string way = "";

            if (regioncompo.SelectedValue != null)
            {
                prametrs += " RealstateOwne.Region_ID= '" + regioncompo.Text + "'";
                prametrs += " and ";
            }


            if (subregioncombo.Text != "")
            {
                string[] prameter = subregioncombo.Text.Split('-');
                //prametrs += "(";
                if (prameter.Length > 1)
                {
                    foreach (string f in prameter)
                    {

                        prametrs += "( RealstateOwne.SubResgionID = '" + f + "' )";
                        prametrs += " or ";
                    }

                    prametrs = prametrs.Substring(0, prametrs.LastIndexOf("or"));
                    prametrs += ")";
                }
                else
                {

                    prametrs += " RealstateOwne.SubResgionID='" + subregioncombo.Text + "'";
                }
                prametrs += " and ";


            }


            if (building.Text != "")
            {
                prametrs += " RealstateOwne.Building like '%" + building.Text.Trim() + "%'";
                prametrs += " and ";
            }

            if (roomsTextBox.Text.Trim() != "")
            {
                prametrs += " RealstateOwne.Rooms=" + Convert.ToInt32(roomsTextBox.Text.Trim()) + "";
                prametrs += " and ";
            }

            if (floor.Text != "")
            {
                prametrs += " RealstateOwne.Floor=" + Convert.ToInt32(floor.Text.Trim()) + "";
                prametrs += " and ";
            }
            if (floorComment.Text != "")
            {
                prametrs += " RealstateOwne.FloorComment = '" + floorComment.Text.Trim() + "'";
                prametrs += " and ";
            }

            if (buildingtypecombp.SelectedItem != null)
            {
                buildingtype = buildingtypecombp.SelectedItem.ToString();
                if (buildingtype == "برجي")
                {
                    prametrs += " RealstateOwne.Building_Type_ID= 1 ";
                }
                if (buildingtype == "طابقي")
                {
                    prametrs += " RealstateOwne.Building_Type_ID= 2 ";
                }

                if (buildingtype == "تراسي")
                {
                    prametrs += " RealstateOwne.Building_Type_ID= 3 ";
                }
                if (buildingtype == "ارض")
                {
                    prametrs += " RealstateOwne.Building_Type_ID= 4 ";
                }

                if (buildingtype == "سوق تجاري")
                {
                    prametrs += " RealstateOwne.Building_Type_ID= 5 ";
                }
                prametrs += " and ";

            }

            if (af.Text != "")
            {

                if (at.Text != "")
                {

                    prametrs += "(RealstateOwne.area >=" + Convert.ToInt32(af.Text.Trim()) + ") and (RealstateOwne.area <=" + Convert.ToInt32(at.Text.Trim()) + " )";
                }
                else
                {

                    prametrs += " RealstateOwne.area =" + Convert.ToInt32(af.Text.Trim()) + "";
                }

                prametrs += " and ";
            }


            if (cf.Text != "")
            {

                if (ct.Text != "")
                {
                    //prametrs += "( RealState.Price >=" + Convert.ToInt32(cf.Text) + " and ( RealState.Price <=" + Convert.ToInt32(ct.Text) +") and ( RealState. Price >=" + Convert.ToInt32(ct.Text) + " and RealState. Price >=" + Convert.ToInt32(ct.Text)+")";
                    prametrs += "( RealstateOwne.Price >=" + Convert.ToDouble(cf.Text.Trim()) + ") and ( RealstateOwne.Price <=" + Convert.ToDouble(ct.Text) + ")";
                }
                else
                {

                    prametrs += " RealstateOwne.Price =" + Convert.ToDouble(cf.Text.Trim()) + "";
                }
                prametrs += " and ";
            }


            if (wayofrentcobmo.SelectedItem != null)
            {
                way = wayofrentcobmo.SelectedItem.ToString();

                prametrs += " RealstateOwne.WayOFOwner= '" + way + "'";
                prametrs += " and ";
            }


            if (owner.Text != "")
            {

                prametrs += " RealstateOwne.Owner = '" + owner.Text.Trim() + "'";
                prametrs += " and ";
            }

            if (p1.Text != "")
            {
                prametrs += " ( ";
                prametrs += " RealstateOwne.Phone_one = '" + p1.Text.Trim() + "'";
                prametrs += " or ";
                prametrs += " RealstateOwne.Phone_Two = '" + p1.Text.Trim() + "'";
                prametrs += " or ";
                prametrs += " RealstateOwne.Mobile = '" + p1.Text.Trim() + "'";
                prametrs += " or ";
                prametrs += " RealstateOwne.Mobile2 = '" + p1.Text.Trim() + "'";
                prametrs += " or ";
                prametrs += " RealstateOwne.Other = '" + p1.Text.Trim() + "'";
                prametrs += " ) ";
                prametrs += " and ";
            }

            //if (other.Text != "")
            //{
            //    prametrs += " RealstateOwne.Other = '" + other.Text + "'";
            //    prametrs += " and ";

            //}

            if (checkBox1.Checked == true)
            {
                prametrs += " RealstateOwne.active=0";
                prametrs += " and ";
            }
            else
            {
                prametrs += " RealstateOwne.active=1";
                prametrs += " and ";

            }

            //hadi
            if (textBox1.Text != "")
            {
                prametrs += " eventown.Event = '" + textBox1.Text + "'";
                prametrs += " and ";

            }


            // ✅ شرط الصور المرفقة
            if (checkBox3.Checked)
            {
                prametrs += " EXISTS (SELECT * FROM attachmentOwn A WHERE A.RealState_ID = RealstateOwne.ID AND NOT (A.Comment LIKE '%ارفاق الي%' OR A.Comment LIKE '%ارفاق آلي%' OR A.Comment LIKE '%صورة كراج البناء%'))";
                prametrs += " and ";
            }

            return prametrs.Substring(0, prametrs.LastIndexOf("and"));
        }

        public string whereClouse()
        {
            //Utils.getsetting();
            string prametrs = " where ";

            string buildingtype = "";
            string way = "";

            if (IDTextBox.Text != "")
            {
                prametrs += " RealstateOwne.ID =" + IDTextBox.Text;
                return prametrs;
            }

            if (regioncompo.SelectedValue != null)
            {
                prametrs += " RealstateOwne.Region_ID= '" + regioncompo.Text + "'";
                prametrs += " and ";
            }


            if (subregioncombo.Text != "")
            {
                string[] prameter = subregioncombo.Text.Split('-');
                if (prameter.Length > 1)
                {
                    prametrs += "(";
                    foreach (string f in prameter)
                    {
                        prametrs += "( RealstateOwne.SubResgionID like '%" + f.Trim() + "%' )";
                        //  prametrs += "( RealstateOwne.SubResgionID = '" + f.Trim() + "' )";
                        prametrs += " or ";
                    }

                    prametrs = prametrs.Substring(0, prametrs.LastIndexOf("or"));

                    prametrs += ")";
                }
                else
                {
                    prametrs += " RealstateOwne.SubResgionID like  '%" + subregioncombo.Text.Trim() + "%'";
                    //prametrs += " RealstateOwne.SubResgionID =  '" + subregioncombo.Text.Trim() + "'";
                }
                prametrs += " and ";


            }


            if (building.Text != "")
            {
                prametrs += " RealstateOwne.Building like '%" + building.Text.Trim() + "%'";
                prametrs += " and ";
            }

            if (roomsTextBox.Text.Trim() != "")
            {
                prametrs += " RealstateOwne.Rooms=" + Convert.ToInt32(roomsTextBox.Text.Trim()) + "";
                prametrs += " and ";
            }

            if (floor.Text != "")
            {
                prametrs += " RealstateOwne.Floor=" + Convert.ToInt32(floor.Text.Trim()) + "";
                prametrs += " and ";
            }
            if (floorComment.Text != "")
            {
                prametrs += " RealstateOwne.FloorComment = '" + floorComment.Text.Trim() + "'";
                prametrs += " and ";
            }

            if (buildingtypecombp.SelectedItem != null)
            {
                buildingtype = buildingtypecombp.SelectedItem.ToString();
                if (buildingtype == "برجي")
                {
                    prametrs += " RealstateOwne.Building_Type_ID= 1 ";
                }
                if (buildingtype == "طابقي")
                {
                    prametrs += " RealstateOwne.Building_Type_ID= 2 ";
                }

                if (buildingtype == "تراسي")
                {
                    prametrs += " RealstateOwne.Building_Type_ID= 3 ";
                }
                if (buildingtype == "ارض")
                {
                    prametrs += " RealstateOwne.Building_Type_ID= 4 ";
                }
                if (buildingtype == "سوق تجاري")
                {
                    prametrs += " RealstateOwne.Building_Type_ID= 5 ";
                }
                prametrs += " and ";

            }
            //WHERE (RealState.Building_Type_ID = 1) AND (RealState.area = 140) OR (RealState.area <= 150) AND (RealState.active = 1)
            if (af.Text != "")
            {

                if (at.Text != "")
                {
                    //                    prametrs += "(RealState.area >=" + Convert.ToInt32(af.Text) + " and RealState.area <=" + Convert.ToInt32(at.Text) + " ) and ( RealState.area >=" + Convert.ToInt32(af.Text) + " and RealState.area >=" + Convert.ToInt32(af.Text) + ")";
                    prametrs += "(RealstateOwne.area >=" + Convert.ToInt32(af.Text.Trim()) + ") and (RealstateOwne.area <=" + Convert.ToInt32(at.Text.Trim()) + " )";
                }
                else
                {

                    prametrs += " RealstateOwne.area =" + Convert.ToInt32(af.Text.Trim()) + "";
                }

                prametrs += " and ";
            }


            if (cf.Text != "")
            {

                if (ct.Text != "")
                {
                    //prametrs += "( RealState.Price >=" + Convert.ToInt32(cf.Text) + " and ( RealState.Price <=" + Convert.ToInt32(ct.Text) +") and ( RealState. Price >=" + Convert.ToInt32(ct.Text) + " and RealState. Price >=" + Convert.ToInt32(ct.Text)+")";
                    prametrs += "( RealstateOwne.Price >=" + Convert.ToDouble(cf.Text.Trim()) + ") and ( RealstateOwne.Price <=" + Convert.ToDouble(ct.Text.Trim()) + ")";
                }
                else
                {

                    prametrs += " RealstateOwne.Price =" + Convert.ToDouble(cf.Text.Trim()) + "";
                }
                prametrs += " and ";
            }


            if (wayofrentcobmo.SelectedItem != null)
            {
                way = wayofrentcobmo.Text;
                prametrs += " RealstateOwne.WayOfOwner= '" + way.Trim() + "'";
                prametrs += " and ";
            }


            if (owner.Text != "")
            {
                prametrs += "( RealstateOwne.Owner like '%" + owner.Text.Trim() + "%' or ";

                string trimed = owner.Text.Trim();

                string Hmza = owner.Text.Trim().Replace("أ", "ا");
                prametrs += " RealstateOwne.Owner like '%" + Hmza + "%' or ";
                trimed = Hmza.Trim().Replace("ه", "ة");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ة", "ه");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ي", "ى");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ى", "ي");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ا", "ه");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                trimed = Hmza.Trim().Replace("ه", "ا");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";


                string Alftriemd = owner.Text.Trim().Replace("ا", "أ");
                prametrs += " RealstateOwne.Owner like '%" + Alftriemd + "%' or ";
                trimed = Alftriemd.Trim().Replace("ه", "ة");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ة", "ه");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ي", "ى");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ى", "ي");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ا", "ه");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                trimed = Alftriemd.Trim().Replace("ه", "ا");
                prametrs += " RealstateOwne.Owner like '%" + trimed + "%' )  ";

                prametrs += " and ";

            }

            if (p1.Text != "")
            {
                prametrs += " ( ";
                prametrs += " RealstateOwne.Phone_one like '%" + p1.Text.Trim() + "%'";
                prametrs += " or ";
                prametrs += " RealstateOwne.Phone_Two like '%" + p1.Text.Trim() + "%'";
                prametrs += " or ";
                prametrs += " RealstateOwne.Mobile like '%" + p1.Text.Trim() + "%'";
                prametrs += " or ";
                prametrs += " RealstateOwne.Mobile2 like '%" + p1.Text.Trim() + "%'";
                prametrs += " or ";
                prametrs += " RealstateOwne.Other like '%" + p1.Text.Trim() + "%'";
                prametrs += " ) ";
                prametrs += " and ";
            }
            //if (other.Text != "")
            //{
            //    prametrs += " RealstateOwne.Other like '%" + other.Text + "%'";
            //    prametrs += " and ";

            //}

            if (checkBox1.Checked == true)
            {
                prametrs += " RealstateOwne.active=0";
                prametrs += " and ";
            }
            else
            {
                prametrs += " RealstateOwne.active=1";
                prametrs += " and ";

            }
            //hadi
            if (textBox1.Text != "")
            {
                prametrs += " eventown.Event like '%" + textBox1.Text + "%'";
                prametrs += " and ";

            }

            // ✅ شرط الصور المرفقة
            if (checkBox3.Checked)
            {
                prametrs += " EXISTS (SELECT * FROM attachmentOwn A WHERE A.RealState_ID = RealstateOwne.ID AND NOT (A.Comment LIKE '%ارفاق الي%' OR A.Comment LIKE '%ارفاق آلي%' OR A.Comment LIKE '%صورة كراج البناء%'))";
                prametrs += " and ";
            }

            return prametrs.Substring(0, prametrs.LastIndexOf("and"));
        }

        void DoQuery(string clouse)
        {
            OWNSearchParameter sp = new OWNSearchParameter(clouse);
            //   eventtext.Text = "";
            if (sp.y == 1)
                sp.ShowDialog();
            //ShowModalExcept(sp, MainForm.searchForm);
            else if (sp.y != 2)
                MessageBox.Show("لا توجد معلومات");
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



        //private void always_Load(object sender, EventArgs e)
        //{
        //    // TODO: This line of code loads data into the 'dSrealowner.WayOFOwner' table. You can move, or remove it, as needed.
        //    this.wayOFOwnerTableAdapter.Fill(this.dSrealowner.WayOFOwner);
        //    // TODO: This line of code loads data into the 'dSrealstate.RealState' table. You can move, or remove it, as needed.

        //    // TODO: This line of code loads data into the 'dSregion.Region' table. You can move, or remove it, as needed.
        //    this.regionTableAdapter.Fill(this.dSregion.Region);
        //    this.m_wndToolTip = new System.Windows.Forms.ToolTip(this.components);
        //    m_wndToolTip.ShowAlways = true;




        //    wayofrentcobmo.Text = null;
        //    regioncompo.Text = null;
        //    buildingtypecombp.Text = null;

        //    regioncompo.Focus();

        //    ///
        //    RefreshUserUI();
        //}
        private void always_Load(object sender, EventArgs e)
        {
            if (!isLoaded)
            {
                try
                {
                    this.wayOFOwnerTableAdapter.Fill(this.dSrealowner.WayOFOwner);
                    this.regionTableAdapter.Fill(this.dSregion.Region);
                    isLoaded = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ أثناء تحميل البيانات: " + ex.Message);
                }
            }

            this.m_wndToolTip = new System.Windows.Forms.ToolTip(this.components);
            m_wndToolTip.ShowAlways = true;

            wayofrentcobmo.Text = null;
            regioncompo.Text = null;
            buildingtypecombp.Text = null;

            regioncompo.Focus();

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
            //only allow numbers and control keys
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

        }



        private void button2_Click(object sender, EventArgs e)
        {

            regioncompo.Text = null;

            textBox1.Text = "";

            subregioncombo.Text = "";
            building.Text = "";
            floor.Text = "";
            floorComment.Text = "";

            buildingtypecombp.Text = null;
            af.Text = "";
            cf.Text = "";

            at.Text = "";
            ct.Text = "";


            wayofrentcobmo.Text = null;

            owner.Text = "";
            p1.Text = "";
            //p2.Text = "";
            //mop.Text = "";
            //other.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;



        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {

                if (keyData == Keys.F12)
                {
                    button2.PerformClick();

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


        string name = "";
        string type = "";

        public void getcustomer()
        {

            insertintophone.am = "own";
            insertintophone.ShowMe();

            name = insertintophone.Button_Clicked;

            type = "new";
            Utils.Oappdate = insertintophone.appdate;
            Utils.Oapptime = insertintophone.apptime;
            Gp1.BackColor = System.Drawing.Color.Red;
            Gp1.ForeColor = System.Drawing.Color.Red;

            if (name == "" || name == null)
            {
                Utils.ORentRecord = false;
                Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (Utils.ORentRecord == false)
            {
                Utils.ORentRecord = true;

                if (Utils.ONameOfCustomer == "")
                {
                    getcustomer();
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (Utils.ORentRecord == true && Utils.OSortdDTRealAppointinfo.Count > 0)
            {

                //    AppointmentsNumbersTableAdapter.Insert("own");
                //phoneEventTableAdapter.Insert(Utils.PhoneID, DateTime.Now, Utils.current_user, Utils.appdate + " " + Utils.apptime + "تم موعد في ");
                PrintGried gd = new PrintGried("own");
                //gd.Name = Utils.ONameOfCustomer;
                //gd.date = Utils.Oappdate;
                //gd.time = Utils.Oapptime;
                gd.ShowDialog();
                //ShowModalExcept(gd, MainForm.searchForm);


                Utils.ORentRecord = false;
                Utils.ONameOfCustomer = "";
                Utils.ONameOfCustomer = "";
                Utils.OCustPhon = "";
                Utils.OCustMobile = "";
                Utils.OCusOther = "";
                Utils.OSortdDTRealAppointinfo.Clear();

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

        /// <summary>
        /// Added Code
        /// </summary>
        private void SetUserColorFromCache()
        {
            try
            {
                var user = Utils.cachedUsers.FirstOrDefault(u => u.UserName == Utils.current_user);

                if (user != null)
                {
                    panel1.BackColor = ColorTranslator.FromHtml(user.Color); // أو PanelUserColo على حسب اسم العنصر
                }
                else
                {
                    panel1.BackColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل اللون من الكاش: " + ex.Message);
                panel1.BackColor = Color.Gray;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            // نعرض نفس فورم تسجيل الدخول الحالية
            //LoginMsg loginMsg = new LoginMsg();

            //// نوقف تنفيذ الكود لحين ما المستخدم يختار اسم ويدوس "دخول"
            //if (loginMsg.ShowDialog() == DialogResult.OK)
            //{
            if (LoginMsg.ShowMe() == "ok")
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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void floorComment_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
