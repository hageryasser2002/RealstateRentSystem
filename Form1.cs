using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace RealStateRentSystem
{
    public partial class Form1 : Form
    {
        private DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter realStateTableAdapter = new DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter();
        private DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter RealStateTableAdaptersearch = new DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter();
        DSTables.DSphoneTableAdapters.PhoneTableAdapter PhoneTableAdapter = new DSTables.DSphoneTableAdapters.PhoneTableAdapter();
        DSTables.DSrealstateTableAdapters.RealStateTableAdapter RealStateTableAdapter = new DSTables.DSrealstateTableAdapters.RealStateTableAdapter();
        DSTables.DScareerTableAdapters.careerTableAdapter careerTableAdapter = new DSTables.DScareerTableAdapters.careerTableAdapter();

        DataTable odt = new DataTable();
        DataTable dtphone = new DataTable();
        DataTable dtrent = new DataTable();
        DataTable dtown = new DataTable();
        DataTable dtcareer = new DataTable();
        string name, number, eventtext;
        string type;
        public string alwaysback;

        public Boolean yes = true;
        public Boolean Eventyes = true;
        public static string phone1 = "";
        public static string always = "";



        public Form1(string pname, string pnumber, string peventtext, string ptype)
        {
            name = pname;
            number = pnumber;
            eventtext = peventtext;
            type = ptype;
            InitializeComponent();
            //foreach (DataGridViewColumn col in dataGridView1.Columns)
            //{
            //    Console.WriteLine($"{col.HeaderText} - Visible: {col.Visible}");
            //}
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.TopMost = true;

            load();
            encrypt();
            ChangeBorderColor();
            FillWidthColumns();

        }

        private void FillWidthColumns()
        {
            dataGridView1.Columns["Column8"].Width = 80;
            // dataGridView1.Columns["notesDataGridViewTextBoxColumn"].Width = 400;
        }

        private void ChangeBorderColor()
        {
            this.Size = new Size(MainForm.MainForm_Size.Width - 20, MainForm.MainForm_Size.Height - 100);
            this.Location = new Point(MainForm.MainForm_Location.X + 10, MainForm.MainForm_Location.Y + 100);
            Color color = Color.FromArgb(0, 119, 182);
            panel_top.BackColor = color;
            panel_bottom.BackColor = color;
            panel_left.BackColor = color;
            panel_right.BackColor = color;

        }
        public void encrypt()
        {
            if (Utils.EncryptMode)
            {

                Column1.Visible = false;
                Column2.Visible = false;
                Column3.Visible = false;
                Column4.Visible = false;
                Column5.Visible = false;
                Column6.Visible = false;
                Column10.Visible = false;

                //MainForm.Imagencrypt.Visible = true;
                //MainForm.Imagencrypt2.Visible = true;

            }
            if (!Utils.EncryptMode)
            {

                Column1.Visible = true;
                Column2.Visible = true;
                Column3.Visible = true;
                Column4.Visible = true;
                Column5.Visible = true;
                Column6.Visible = true;
                Column10.Visible = true;

                //MainForm.Imagencrypt.Visible = false;
                //MainForm.Imagencrypt2.Visible = false;

            }

        }
        private void load()
        {
            if (type == "0")
                NotExact();
            else
                exact();

        }
        private void NotExact()
        {
            if (name != "" || eventtext != "" || number != "")
            {
                string phonequery = "";
                string realrentquesry = "";
                string realownquesry = "";
                string careerquery = "";

                if (eventtext != "")
                {
                    phonequery = " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o , phoneEvent.Event as event FROM ( Phone left JOIN phoneEvent phoneEvent ON Phone.ID = phoneEvent.PhoneID ) where ";
                    realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event ,Realstate.active as active FROM RealState left JOIN Event ON RealState.ID = Event.RealStateID where ";
                    realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM RealstateOwne left JOIN eventown eventown ON RealstateOwne.ID = eventown.RealStateID where ";
                    careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on career.id=careerEvent.careerID where ";


                    phonequery += " ( phoneEvent.Event like '%" + eventtext + "%' ) and ";
                    realrentquesry += "(   Event.Event like '%" + eventtext + "%') and ";
                    realownquesry += " (   eventown.Event like '%" + eventtext + "%' ) and ";
                    careerquery += "( careerEvent.Event like '%" + eventtext + "%' ) and ";

                }
                else
                {
                    phonequery = " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o FROM  Phone where ";
                    realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Realstate.active as active FROM RealState where ";
                    realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , RealstateOwne.active as active FROM  RealstateOwne where ";
                    careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o FROM career  where ";

                    Eventyes = false;

                }

                int index = number.ToString().IndexOf("*");

                if (index > 0 && index != 0)
                {
                    string newvalue = number.Substring(0, index);

                    realrentquesry += " ( ( Phone_one like '" + newvalue + "%' ) or (   Phone_Two like '" + newvalue + "%')  or (   Mobile like '" + newvalue + "%') or (   Mobile2 like '" + newvalue + "%') or (other like '" + newvalue + "%') ) and ";
                    realownquesry += "  ( (  Phone_one like '" + newvalue + "%' ) or (   Phone_Two like '" + newvalue + "%' ) or (    Mobile like '" + newvalue + "%' ) or (    Mobile2 like '" + newvalue + "%' )  or (other like '" + newvalue + "%') ) and  ";
                    phonequery += "  ( ( p1 like '" + newvalue + "%' ) or ( p2 like '" + newvalue + "%' ) or ( m2 like '" + newvalue + "%' ) or (m3 like '" + newvalue + "%' ) or ( other like '" + newvalue + "%' ) ) and ";
                    careerquery += " ( (  p like '" + newvalue + "%' ) or (   m like '" + newvalue + "%') or (other like '" + newvalue + "%') ) and ";
                }
                else if (index == 0)
                {
                    string newvalue = number.Substring(index + 1);
                    realrentquesry += " ( ( Phone_one like '%" + newvalue + "' ) or (   Phone_Two like '%" + newvalue + "')  or (   Mobile like '%" + newvalue + "') or (   Mobile2 like '%" + newvalue + "') or (other like '%" + newvalue + "') ) and ";
                    realownquesry += "  ( (  Phone_one like '%" + newvalue + "' ) or (   Phone_Two like '%" + newvalue + "' ) or (    Mobile like '%" + newvalue + "' ) or (    Mobile2 like '%" + newvalue + "' )  or (other like '%" + newvalue + "') ) and  ";
                    phonequery += "  (( p1 like '%" + newvalue + "' ) or ( p2 like '%" + newvalue + "')  or ( m2 like '%" + newvalue + "' ) or ( m3 like '%" + newvalue + "') or (other like '%" + newvalue + "' ) ) and ";
                    careerquery += " ( (  p like '%" + newvalue + "' ) or (   m like '%" + newvalue + "') or (other like '%" + newvalue + "') ) and ";

                }
                else
                {
                    if (number != "")
                    {
                        realrentquesry += " ( ( Phone_one like '%" + number + "%' ) or (   Phone_Two like '%" + number + "%')  or (   Mobile like '%" + number + "%') or (   Mobile2 like '%" + number + "%') or (other like '%" + number + "%') ) and ";
                        realownquesry += "  ( (  Phone_one like '%" + number + "%' ) or (   Phone_Two like '%" + number + "%' ) or (    Mobile like '%" + number + "%' ) or (    Mobile2 like '%" + number + "%' )  or (other like '%" + number + "%') ) and  ";
                        phonequery += "  (( p1 like '%" + number + "%' ) or ( p2 like '%" + number + "%')  or ( m2 like '%" + number + "%') or ( m3 like '%" + number + "%') or (other like '%" + number + "%' )) and ";
                        careerquery += " ( (  p like '%" + number + "%' ) or (   m like '%" + number + "%') or (other like '%" + number + "%') ) and ";

                    }
                }

                //if (name != "")
                //{
                //    realrentquesry += "  (   other like '%" + name + "%' ) and ";
                //    realownquesry += " (   other like '%" + name + "%'  ) and ";
                //    phonequery += " (  other like '%" + name + "%'  ) and  ";
                //    careerquery += "(  other like '%" + name + "%'  ) and ";

                //}
                if (name != "")
                {
                    realrentquesry += "  ( other like '%" + name + "%' or   Owner like '%" + name + "%'   or ";
                    realownquesry += " (  other like '%" + name + "%' or Owner like '%" + name + "%'  or ";
                    phonequery += " ( other like '%" + name + "%' or Name like '%" + name + "%'   or ";
                    careerquery += "( other like '%" + name + "%' or Name like '%" + name + "%'   or ";

                    string trimed = name.Trim();


                    string Hmza = name.Trim().Replace("أ", "ا");
                    realrentquesry += " Owner like '%" + Hmza + "%' or ";
                    trimed = Hmza.Trim().Replace("ه", "ة");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ة", "ه");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ي", "ى");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ى", "ي");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ا", "ه");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ه", "ا");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    string Alftriemd = name.Trim().Replace("ا", "أ");
                    realrentquesry += " Owner like '%" + Alftriemd + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ه", "ة");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ة", "ه");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ي", "ى");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ى", "ي");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ا", "ه");
                    realrentquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ه", "ا");
                    realrentquesry += " Owner like '%" + trimed + "%'  ) and ";


                    string RoHmza = name.Trim().Replace("أ", "ا");
                    realownquesry += " Owner like '%" + RoHmza + "%' or ";
                    trimed = RoHmza.Trim().Replace("ه", "ة");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = RoHmza.Trim().Replace("ة", "ه");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = RoHmza.Trim().Replace("ي", "ى");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = RoHmza.Trim().Replace("ى", "ي");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = RoHmza.Trim().Replace("ا", "ه");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = RoHmza.Trim().Replace("ه", "ا");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    string RoAlftriemd = name.Trim().Replace("ا", "أ");
                    realownquesry += " Owner like '%" + RoAlftriemd + "%' or ";
                    trimed = RoAlftriemd.Trim().Replace("ه", "ة");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = RoAlftriemd.Trim().Replace("ة", "ه");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = RoAlftriemd.Trim().Replace("ي", "ى");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = RoAlftriemd.Trim().Replace("ى", "ي");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = RoAlftriemd.Trim().Replace("ا", "ه");
                    realownquesry += " Owner like '%" + trimed + "%' or ";
                    trimed = RoAlftriemd.Trim().Replace("ه", "ا");
                    realownquesry += " Owner like '%" + trimed + "%'  ) and ";


                    string PHHmza = name.Trim().Replace("أ", "ا");
                    phonequery += " Name like '%" + PHHmza + "%' or ";
                    trimed = PHHmza.Trim().Replace("ه", "ة");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    trimed = PHHmza.Trim().Replace("ة", "ه");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    trimed = PHHmza.Trim().Replace("ي", "ى");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    trimed = PHHmza.Trim().Replace("ى", "ي");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    trimed = PHHmza.Trim().Replace("ا", "ه");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    trimed = PHHmza.Trim().Replace("ه", "ا");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    string PHAlftriemd = name.Trim().Replace("ا", "أ");
                    phonequery += " Name like '%" + PHAlftriemd + "%' or ";
                    trimed = PHAlftriemd.Trim().Replace("ه", "ة");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    trimed = PHAlftriemd.Trim().Replace("ة", "ه");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    trimed = PHAlftriemd.Trim().Replace("ي", "ى");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    trimed = PHAlftriemd.Trim().Replace("ى", "ي");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    trimed = PHAlftriemd.Trim().Replace("ا", "ه");
                    phonequery += " Name like '%" + trimed + "%' or ";
                    trimed = PHAlftriemd.Trim().Replace("ه", "ا");
                    phonequery += " Name like '%" + trimed + "%'  ) and ";


                    string CarHmza = name.Trim().Replace("أ", "ا");
                    careerquery += " Name like '%" + CarHmza + "%' or ";
                    trimed = CarHmza.Trim().Replace("ه", "ة");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ة", "ه");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ي", "ى");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ى", "ي");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ا", "ه");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ه", "ا");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    string CarAlftriemd = name.Trim().Replace("ا", "أ");
                    careerquery += " Name like '%" + CarAlftriemd + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ه", "ة");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ة", "ه");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ي", "ى");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ى", "ي");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ا", "ه");
                    careerquery += " Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ه", "ا");
                    careerquery += " Name like '%" + trimed + "%'  ) and ";


                }




                if (phonequery != "")
                {
                    dtphone = get(phonequery.Substring(0, phonequery.LastIndexOf("and")));
                }
                if (realrentquesry != "")
                {
                    dtrent = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("and")));
                }
                if (realownquesry != "")
                {
                    dtown = get(realownquesry.Substring(0, realownquesry.LastIndexOf("and")));
                }

                if (careerquery != "")
                {
                    dtcareer = get(careerquery.Substring(0, careerquery.LastIndexOf("and")));
                }


                odt.Merge(dtrent, true);
                odt.Merge(dtphone, true);
                odt.Merge(dtown, true);
                odt.Merge(dtcareer, true);
                odt.AcceptChanges();

                if (odt.Rows.Count > 0)
                {
                    int counter = 0;
                    int number = 1;
                    dataGridView1.Rows.Add(odt.Rows.Count);

                    for (int y = 0; y < dtphone.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[1].Value = dtphone.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtphone.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtphone.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtphone.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtphone.Rows[y]["ptwo"].ToString();
                        dataGridView1.Rows[counter].Cells[6].Value = dtphone.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtphone.Rows[y]["o"].ToString();
                        if (Eventyes)
                        {
                            dataGridView1.Rows[counter].Cells[8].Value = dtphone.Rows[y]["event"].ToString();
                        }
                        dataGridView1.Rows[counter].Cells[9].Value = "الهاتف";

                        counter = counter + 1;
                        number++;
                    }

                    for (int y = 0; y < dtcareer.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[1].Value = dtcareer.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtcareer.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtcareer.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtcareer.Rows[y]["mone"].ToString();
                        //dataGridView1.Rows[counter].Cells[5].Value = dtcareer.Rows[y]["ptwo"].ToString();
                        //dataGridView1.Rows[counter].Cells[6].Value = dtcareer.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtcareer.Rows[y]["o"].ToString();
                        if (Eventyes)
                        {
                            dataGridView1.Rows[counter].Cells[8].Value = dtcareer.Rows[y]["event"].ToString();
                        }
                        dataGridView1.Rows[counter].Cells[9].Value = "مهن";

                        counter = counter + 1;
                        number++;
                    }

                    for (int y = 0; y < dtrent.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[1].Value = dtrent.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtrent.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtrent.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtrent.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtrent.Rows[y]["ptwo"].ToString();
                        //dataGridView1.Rows[counter].Cells[6].Value = dtrent.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtrent.Rows[y]["o"].ToString();
                        if (Eventyes)
                        {
                            dataGridView1.Rows[counter].Cells[8].Value = dtrent.Rows[y]["event"].ToString();
                        }
                        if (dtrent.Rows[y]["active"].ToString() == "1")
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "اجار";
                        }
                        else
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "اجار ارشيف";
                        }
                        counter = counter + 1;
                        number++;
                    }


                    for (int y = 0; y < dtown.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[1].Value = dtown.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtown.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtown.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtown.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtown.Rows[y]["ptwo"].ToString();
                        // dataGridView1.Rows[counter].Cells[6].Value = dtown.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtown.Rows[y]["o"].ToString();
                        if (Eventyes)
                        {
                            dataGridView1.Rows[counter].Cells[8].Value = dtown.Rows[y]["event"].ToString();
                        }

                        if (dtown.Rows[y]["active"].ToString() == "1")
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "بيع";
                        }
                        else
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "بيع ارشيف";
                        }
                        counter = counter + 1;
                        number++;
                    }

                }
                else
                {
                    if (!Utils.CheckOtherRecord)
                    {
                        MessageBox.Show("لا يوجد نتائج");
                    }
                    yes = false;
                    alwaysback = "back";

                }

                dataGridView1.Refresh();

            }
            else
            {

                //  MessageBox.Show("الرجاء ادخال قيمة للبحث عنها");
                yes = false;
                alwaysback = "back";

            }

        }
        private void exact()
        {
            if (name != "" || eventtext != "" || number != "")
            {
                string phonequery = "";
                string realrentquesry = "";
                string realownquesry = "";
                string careerquery = "";


                if (eventtext != "")
                {
                    phonequery = " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o , phoneEvent.Event as event FROM ( Phone left JOIN phoneEvent phoneEvent ON Phone.ID = phoneEvent.PhoneID ) where ";
                    realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event ,Realstate.active as active FROM RealState left JOIN Event ON RealState.ID = Event.RealStateID where ";
                    realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM RealstateOwne left JOIN eventown eventown ON RealstateOwne.ID = eventown.RealStateID where ";
                    careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on career.id=careerEvent.careerID where ";

                    phonequery += "( phoneEvent.Event ='" + eventtext + "' ) and ";
                    realrentquesry += "(   Event.Event ='" + eventtext + "') and ";
                    realownquesry += " (   eventown.Event ='" + eventtext + "' ) and ";
                    careerquery += "( careerEvent.Event = '" + eventtext + "' ) and ";



                }
                else
                {
                    phonequery = " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o FROM  Phone where ";
                    realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Realstate.active as active FROM RealState where ";
                    realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , RealstateOwne.active as active FROM  RealstateOwne where ";
                    careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o FROM career  where ";

                    Eventyes = false;

                }


                if (name != "")
                {
                    realrentquesry += "  ((   Owner='" + name + "' ) ) and  ";
                    realownquesry += " ( (  Owner='" + name + "')) and ";
                    phonequery += "( ( Name = '" + name + "' ) ) and ";
                    careerquery += "( ( Name = '" + name + "' ) ) and ";


                }



                if (number != "")
                {
                    realrentquesry += " ( (   Phone_one= '" + number + "' ) or (   Phone_Two= '" + number + "')  or (   Mobile= '" + number + "') or (   Mobile2= '" + number + "') or ( other = '" + number + "' )) and ";
                    realownquesry += " ( (   Phone_one= '" + number + "' ) or (   Phone_Two= '" + number + "' ) or (    Mobile= '" + number + "' ) or (    Mobile2= '" + number + "' ) or ( other = '" + number + "' ) ) and ";
                    phonequery += " ( p1= '" + number + "' or p2= '" + number + "'  or m2= '" + number + "' or m3= '" + number + "'  or other = '" + number + "'  ) and  ";
                    careerquery += " ((  p = '" + number + "' ) or (   m = '" + number + "') or ( other = '" + number + "' )  )and ";


                }


                if (phonequery != "SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o , phoneEvent.Event as event FROM Phone left JOIN phoneEvent phoneEvent ON  phoneEvent.PhoneID = Phone.ID  where ")
                {
                    dtphone = get(phonequery.Substring(0, phonequery.LastIndexOf("and")));
                }
                if (realrentquesry != "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event , Realstate.active as active FROM RealState left JOIN Event ON Event.RealStateID = RealState.ID  where ")
                {
                    dtrent = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("and")));
                }
                if (realownquesry != "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM RealstateOwne left JOIN eventown eventown ON  eventown.RealStateID = RealstateOwne.ID where ")
                {
                    dtown = get(realownquesry.Substring(0, realownquesry.LastIndexOf("and")));
                }

                if (careerquery != "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on careerEvent.careerID = career.id where ")
                {
                    dtcareer = get(careerquery.Substring(0, careerquery.LastIndexOf("and")));
                }

                odt.Merge(dtrent, true);
                odt.Merge(dtphone, true);
                odt.Merge(dtown, true);
                odt.Merge(dtcareer, true);
                odt.AcceptChanges();

                if (odt.Rows.Count > 0)
                {
                    int counter = 0;
                    int number = 1;
                    dataGridView1.Rows.Add(odt.Rows.Count);

                    for (int y = 0; y < dtphone.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[1].Value = dtphone.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtphone.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtphone.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtphone.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtphone.Rows[y]["ptwo"].ToString();
                        dataGridView1.Rows[counter].Cells[6].Value = dtphone.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtphone.Rows[y]["o"].ToString();
                        if (Eventyes)
                        {
                            dataGridView1.Rows[counter].Cells[8].Value = dtphone.Rows[y]["event"].ToString();
                        }
                        dataGridView1.Rows[counter].Cells[9].Value = "الهاتف";

                        counter = counter + 1;
                        number++;
                    }

                    for (int y = 0; y < dtcareer.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[1].Value = dtcareer.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtcareer.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtcareer.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtcareer.Rows[y]["mone"].ToString();
                        //dataGridView1.Rows[counter].Cells[5].Value = dtcareer.Rows[y]["ptwo"].ToString();
                        //dataGridView1.Rows[counter].Cells[6].Value = dtcareer.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtcareer.Rows[y]["o"].ToString();
                        if (Eventyes)
                        {
                            dataGridView1.Rows[counter].Cells[8].Value = dtcareer.Rows[y]["event"].ToString();
                        }
                        dataGridView1.Rows[counter].Cells[9].Value = "مهن";

                        counter = counter + 1;
                        number++;
                    }
                    for (int y = 0; y < dtrent.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[1].Value = dtrent.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtrent.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtrent.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtrent.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtrent.Rows[y]["ptwo"].ToString();
                        //dataGridView1.Rows[counter].Cells[6].Value = dtrent.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtrent.Rows[y]["o"].ToString();

                        //if (Eventyes)
                        //{
                        //    dataGridView1.Rows[counter].Cells[8].Value = dtrent.Rows[y]["event"].ToString();
                        //}

                        if (Eventyes && dtown.Columns.Contains("event"))
                        {
                            dataGridView1.Rows[counter].Cells[8].Value = dtown.Rows[y]["event"].ToString();
                        }
                        else
                        {
                            dataGridView1.Rows[counter].Cells[8].Value = ""; // or "No Event"
                        }


                        if (dtrent.Rows[y]["active"].ToString() == "1")
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "اجار";
                        }
                        else
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "اجار ارشيف";
                        }
                        counter = counter + 1;
                        number++;
                    }


                    for (int y = 0; y < dtown.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[1].Value = dtown.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtown.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtown.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtown.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtown.Rows[y]["ptwo"].ToString();
                        // dataGridView1.Rows[counter].Cells[6].Value = dtown.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtown.Rows[y]["o"].ToString();
                        if (Eventyes)
                        {
                            dataGridView1.Rows[counter].Cells[8].Value = dtown.Rows[y]["event"].ToString();
                        }

                        if (dtown.Rows[y]["active"].ToString() == "1")
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "بيع";
                        }
                        else
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "بيع ارشيف";
                        }
                        counter = counter + 1;
                        number++;
                    }

                }
                else
                {
                    if (!Utils.CheckOtherRecord)
                    {
                        MessageBox.Show("لا يوجد نتائج");
                    }
                    yes = false;
                    alwaysback = "back";
                }

                dataGridView1.Refresh();
            }
            else
            {

                MessageBox.Show("الرجاء ادخال قيمة للبحث عنها");
                yes = false;
                alwaysback = "back";

            }


        }

        public static DataTable get(string SqlStatement)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            // string SqlStatement = "";
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            //            SqlConnection conn = new SqlConnection(serverConnectionString);
            try
            {
                conn.Open();
                //OleDbDataAdapter
                OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conn.Close();
                conn.Dispose();
                sda.Dispose();
                //foreach (DataRow dr in dt.Rows)


                return dt;

            }
            catch (Exception)
            {
                throw;

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RealstateOwner own = new RealstateOwner();
            Realstate rent = new Realstate();
            phone phone = new phone();
            career car = new career();
            try
            {

                if (e.ColumnIndex == 0)
                {


                    if (dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "اجار" || dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "اجار ارشيف")
                    {
                        this.RealStateTableAdaptersearch.UpdateQuery(DateTime.Now.Date, Convert.ToInt32(Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString())));

                        rent.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[1].Value.ToString());
                        rent.am = "Search";
                        rent.Text = "بحث";
                        rent.ShowDialog();
                        //ShowModalExcept(rent, MainForm.searchForm);



                        if (rent.back == "back")
                        {
                            alwaysback = "back";
                            this.Close();
                        }


                    }
                    else if (dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "بيع" || dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "بيع ارشيف")
                    {
                        this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date, Convert.ToInt32(Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString())));

                        own.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[1].Value.ToString());
                        own.am = "Search";
                        own.Text = "بحث";
                        own.ShowDialog();
                        //ShowModalExcept(own, MainForm.searchForm);



                        if (own.back == "back")
                        {
                            alwaysback = "back";
                            this.Close();
                        }
                    }
                    else if (dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "الهاتف")
                    {
                        phone.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[1].Value.ToString());
                        phone.am = "Search";
                        phone.Text = "بحث";
                        phone.ShowDialog();
                        //ShowModalExcept(phone, MainForm.searchForm);

                        if (phone.back == "back")
                        {
                            alwaysback = "back";
                            this.Close();
                        }
                    }
                    else if (dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "مهن")
                    {

                        car.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[1].Value.ToString());
                        car.am = "Search";
                        car.Text = "بحث";
                        car.ShowDialog();
                        //ShowModalExcept(car, MainForm.searchForm);

                        if (car.back == "back")
                        {
                            alwaysback = "back";
                            this.Close();
                        }
                    }



                }
            }
            catch
            {
                //    u.Close();
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

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Column8"].Value = i + 1;
            }
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
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

                if (keyData == Keys.F1)
                {
                    alwaysback = "back";
                    this.Close();

                }

            }

            return true;

        }

    }
}










