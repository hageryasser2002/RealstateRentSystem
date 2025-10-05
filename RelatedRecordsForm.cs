using Microsoft.Win32;
using RealStateRentSystem.DSTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class RelatedRecordsForm : Form
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

        List<string> searchNumbers = new List<string>();
        List<Form> openedForms = new List<Form>();

        string name, eventtext;
        string type;
        public string alwaysback;

        public Boolean yes = true;
        public Boolean Eventyes = true;
        public static string phone1 = "";
        public static string always = "";

        public int totalRecordsFound = 0;
        private string currentRecordId;

        public RelatedRecordsForm(List<string> numbers, string pname = "", string peventtext = "", string ptype = "0", string currentId = "")
        {
            // Push current ID to stack when form is created
            RealStateIdScope.PushCurrentId();

            searchNumbers = numbers;
            name = pname;
            eventtext = peventtext;
            type = ptype;
            currentRecordId = currentId;  // ✅ store current record id

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            load();
            encrypt();
            ChangeBorderColor();
            FillWidthColumns();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Pop the ID from stack to restore previous value when form closes
            RealStateIdScope.PopId();
        }

        private void FillWidthColumns()
        {
            dataGridView1.Columns["Column8"].Width = 80;
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
            }
        }

        private void load()
        {
            if (type == "0")
                NotExact();
            else
                exact();
        }

        private void ClearAllDataTables()
        {
            dtphone.Clear();
            dtrent.Clear();
            dtown.Clear();
            dtcareer.Clear();
            odt.Clear();
        }

        private void RemoveDuplicateRows(DataTable dataTable, string keyColumn)
        {
            var seenKeys = new HashSet<string>();
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                string key = dataTable.Rows[i][keyColumn].ToString();
                if (seenKeys.Contains(key))
                {
                    dataTable.Rows.RemoveAt(i);
                }
                else
                {
                    seenKeys.Add(key);
                }
            }
        }

        private void NotExact()
        {
            ClearAllDataTables();
            if (name != "" || eventtext != "" || searchNumbers.Count > 0)
            {
                foreach (string number in searchNumbers)
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
                        DataTable tempDt = get(phonequery.Substring(0, phonequery.LastIndexOf("and")));
                        dtphone.Merge(tempDt, true);
                    }
                    if (realrentquesry != "")
                    {
                        DataTable tempDt = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("and")));
                        dtrent.Merge(tempDt, true);
                    }
                    if (realownquesry != "")
                    {
                        DataTable tempDt = get(realownquesry.Substring(0, realownquesry.LastIndexOf("and")));
                        dtown.Merge(tempDt, true);
                    }
                    if (careerquery != "")
                    {
                        DataTable tempDt = get(careerquery.Substring(0, careerquery.LastIndexOf("and")));
                        dtcareer.Merge(tempDt, true);
                    }
                }

                RemoveDuplicateRows(dtphone, "id");
                RemoveDuplicateRows(dtrent, "id");
                RemoveDuplicateRows(dtown, "id");
                RemoveDuplicateRows(dtcareer, "id");

                odt.Merge(dtrent, true);
                odt.Merge(dtphone, true);
                odt.Merge(dtown, true);
                odt.Merge(dtcareer, true);
                odt.AcceptChanges();

                // NEW: filter out the currently opened record from ALL tables
                if (!string.IsNullOrEmpty(currentRecordId))
                {
                    RemoveById(dtphone, currentRecordId);
                    RemoveById(dtrent, currentRecordId);
                    RemoveById(dtown, currentRecordId);
                    RemoveById(dtcareer, currentRecordId);
                    RemoveById(odt, currentRecordId);
                }

                // NEW: compute real total to add to the grid
                int totalToShow = dtphone.Rows.Count + dtcareer.Rows.Count + dtrent.Rows.Count + dtown.Rows.Count;
                totalRecordsFound = totalToShow;

                if (totalToShow > 0)
                {
                    int counter = 0;
                    int number = 1;

                    // IMPORTANT: clear and add the exact count we will fill
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(totalToShow);

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
                        // NEW: guard event column
                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtphone.Columns.Contains("event")) ? dtphone.Rows[y]["event"].ToString() : "";
                        dataGridView1.Rows[counter].Cells[9].Value = "الهاتف";
                        counter++; number++;
                    }

                    for (int y = 0; y < dtcareer.Rows.Count; y++)
                    {
                        dataGridView1.Rows[counter].Cells[1].Value = dtcareer.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtcareer.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtcareer.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtcareer.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtcareer.Rows[y]["o"].ToString();
                        // NEW: guard event column
                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtcareer.Columns.Contains("event")) ? dtcareer.Rows[y]["event"].ToString() : "";
                        dataGridView1.Rows[counter].Cells[9].Value = "مهن";
                        counter++; number++;
                    }

                    for (int y = 0; y < dtrent.Rows.Count; y++)
                    {
                        dataGridView1.Rows[counter].Cells[1].Value = dtrent.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtrent.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtrent.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtrent.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtrent.Rows[y]["ptwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtrent.Rows[y]["o"].ToString();
                        // NEW: guard event column
                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtrent.Columns.Contains("event")) ? dtrent.Rows[y]["event"].ToString() : "";
                        dataGridView1.Rows[counter].Cells[9].Value = (dtrent.Rows[y]["active"].ToString() == "1") ? "اجار" : "اجار ارشيف";
                        counter++; number++;
                    }

                    for (int y = 0; y < dtown.Rows.Count; y++)
                    {
                        dataGridView1.Rows[counter].Cells[1].Value = dtown.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtown.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtown.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtown.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtown.Rows[y]["ptwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtown.Rows[y]["o"].ToString();
                        // NEW: guard event column
                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtown.Columns.Contains("event")) ? dtown.Rows[y]["event"].ToString() : "";
                        dataGridView1.Rows[counter].Cells[9].Value = (dtown.Rows[y]["active"].ToString() == "1") ? "بيع" : "بيع ارشيف";
                        counter++; number++;
                    }
                }
                else
                {
                    yes = false;
                    alwaysback = "back";
                }

                dataGridView1.Refresh();

            }
            else
            {
                yes = false;
                alwaysback = "back";
            }
        }

        private void exact()
        {
            ClearAllDataTables();
            if (name != "" || eventtext != "" || searchNumbers.Count > 0)
            {
                foreach (string number in searchNumbers)
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
                        DataTable tempDt = get(phonequery.Substring(0, phonequery.LastIndexOf("and")));
                        dtphone.Merge(tempDt, true);
                    }
                    if (realrentquesry != "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event , Realstate.active as active FROM RealState left JOIN Event ON Event.RealStateID = RealState.ID  where ")
                    {
                        DataTable tempDt = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("and")));
                        dtrent.Merge(tempDt, true);
                    }
                    if (realownquesry != "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM RealstateOwne left JOIN eventown eventown ON  eventown.RealStateID = RealstateOwne.ID where ")
                    {
                        DataTable tempDt = get(realownquesry.Substring(0, realownquesry.LastIndexOf("and")));
                        dtown.Merge(tempDt, true);
                    }
                    if (careerquery != "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on careerEvent.careerID = career.id where ")
                    {
                        DataTable tempDt = get(careerquery.Substring(0, careerquery.LastIndexOf("and")));
                        dtcareer.Merge(tempDt, true);
                    }
                }

                RemoveDuplicateRows(dtphone, "id");
                RemoveDuplicateRows(dtrent, "id");
                RemoveDuplicateRows(dtown, "id");
                RemoveDuplicateRows(dtcareer, "id");

                odt.Merge(dtrent, true);
                odt.Merge(dtphone, true);
                odt.Merge(dtown, true);
                odt.Merge(dtcareer, true);
                odt.AcceptChanges();

                // NEW: filter out the currently opened record from ALL tables
                if (!string.IsNullOrEmpty(currentRecordId))
                {
                    RemoveById(dtphone, currentRecordId);
                    RemoveById(dtrent, currentRecordId);
                    RemoveById(dtown, currentRecordId);
                    RemoveById(dtcareer, currentRecordId);
                    RemoveById(odt, currentRecordId);
                }

                // NEW: compute real total to add to the grid
                int totalToShow = dtphone.Rows.Count + dtcareer.Rows.Count + dtrent.Rows.Count + dtown.Rows.Count;
                totalRecordsFound = totalToShow;

                if (totalToShow > 0)
                {
                    int counter = 0;
                    int number = 1;

                    // IMPORTANT: clear and add the exact count we will fill
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(totalToShow);

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
                        // NEW: guard event column
                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtphone.Columns.Contains("event")) ? dtphone.Rows[y]["event"].ToString() : "";
                        dataGridView1.Rows[counter].Cells[9].Value = "الهاتف";
                        counter++; number++;
                    }

                    for (int y = 0; y < dtcareer.Rows.Count; y++)
                    {
                        dataGridView1.Rows[counter].Cells[1].Value = dtcareer.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtcareer.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtcareer.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtcareer.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtcareer.Rows[y]["o"].ToString();
                        // NEW: guard event column
                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtcareer.Columns.Contains("event")) ? dtcareer.Rows[y]["event"].ToString() : "";
                        dataGridView1.Rows[counter].Cells[9].Value = "مهن";
                        counter++; number++;
                    }

                    for (int y = 0; y < dtrent.Rows.Count; y++)
                    {
                        dataGridView1.Rows[counter].Cells[1].Value = dtrent.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtrent.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtrent.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtrent.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtrent.Rows[y]["ptwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtrent.Rows[y]["o"].ToString();
                        // NEW: guard event column
                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtrent.Columns.Contains("event")) ? dtrent.Rows[y]["event"].ToString() : "";
                        dataGridView1.Rows[counter].Cells[9].Value = (dtrent.Rows[y]["active"].ToString() == "1") ? "اجار" : "اجار ارشيف";
                        counter++; number++;
                    }

                    for (int y = 0; y < dtown.Rows.Count; y++)
                    {
                        dataGridView1.Rows[counter].Cells[1].Value = dtown.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[0].Value = number;
                        dataGridView1.Rows[counter].Cells[2].Value = dtown.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtown.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtown.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtown.Rows[y]["ptwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtown.Rows[y]["o"].ToString();
                        // NEW: guard event column
                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtown.Columns.Contains("event")) ? dtown.Rows[y]["event"].ToString() : "";
                        dataGridView1.Rows[counter].Cells[9].Value = (dtown.Rows[y]["active"].ToString() == "1") ? "بيع" : "بيع ارشيف";
                        counter++; number++;
                    }
                }
                else
                {
                    yes = false;
                    alwaysback = "back";
                }

                dataGridView1.Refresh();

            }
            else
            {
                yes = false;
                alwaysback = "back";
            }
        }
        private static void RemoveById(DataTable dt, string id)
        {
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(id)) return;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i].Table.Columns.Contains("id") &&
                    dt.Rows[i]["id"].ToString() == id)
                {
                    dt.Rows.RemoveAt(i);
                }
            }
            dt.AcceptChanges();
        }

        public static DataTable get(string SqlStatement)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
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
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if this form is already opened to avoid infinite loops
            if (IsFormAlreadyOpened()) return;

            RealstateOwner own = new RealstateOwner();
            Realstate rent = new Realstate();
            phone phone = new phone();
            career car = new career();

            try
            {
                if (e.ColumnIndex == 0)
                {
                    string recordType = dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString();
                    int recordId = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[1].Value.ToString());

                    // Add this form to opened forms list
                    openedForms.Add(this);

                    if (recordType == "اجار" || recordType == "اجار ارشيف")
                    {
                        this.RealStateTableAdaptersearch.UpdateQuery(DateTime.Now.Date, recordId);
                        rent.recored_id = recordId;
                        rent.am = "Search";
                        rent.Text = "بحث";
                        rent.ShowDialog();

                        if (rent.back == "back")
                        {
                            alwaysback = "back";
                            this.Close();
                        }
                    }
                    else if (recordType == "بيع" || recordType == "بيع ارشيف")
                    {
                        this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date, recordId);
                        own.recored_id = recordId;
                        own.am = "Search";
                        own.Text = "بحث";
                        own.ShowDialog();

                        if (own.back == "back")
                        {
                            alwaysback = "back";
                            this.Close();
                        }
                    }
                    else if (recordType == "الهاتف")
                    {
                        phone.recored_id = recordId;
                        phone.am = "Search";
                        phone.Text = "بحث";
                        phone.ShowDialog();

                        if (phone.back == "back")
                        {
                            alwaysback = "back";
                            this.Close();
                        }
                    }
                    else if (recordType == "مهن")
                    {
                        car.recored_id = recordId;
                        car.am = "Search";
                        car.Text = "بحث";
                        car.ShowDialog();

                        if (car.back == "back")
                        {
                            alwaysback = "back";
                            this.Close();
                        }
                    }

                    // Remove this form from opened forms list after dialog closes
                    openedForms.Remove(this);
                }
            }
            catch
            {
                openedForms.Remove(this);
            }
        }

        private bool IsFormAlreadyOpened()
        {
            // Check if this form is already in the opened forms list
            return openedForms.Contains(this);
        }

        public static void ShowModalExcept(Form modalForm, Form exceptionForm)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f != modalForm && f != exceptionForm)
                {
                    f.Enabled = false;
                }
            }

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



//using Microsoft.Win32;
//using RealStateRentSystem.DSTables;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Configuration;
//using System.Data;
//using System.Data.OleDb;
//using System.Data.SqlClient;
//using System.Diagnostics;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//namespace RealStateRentSystem
//{
//    public partial class RelatedRecordsForm : Form
//    {
//        private DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter realStateTableAdapter = new DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter();
//        private DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter RealStateTableAdaptersearch = new DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter();
//        DSTables.DSphoneTableAdapters.PhoneTableAdapter PhoneTableAdapter = new DSTables.DSphoneTableAdapters.PhoneTableAdapter();
//        DSTables.DSrealstateTableAdapters.RealStateTableAdapter RealStateTableAdapter = new DSTables.DSrealstateTableAdapters.RealStateTableAdapter();
//        DSTables.DScareerTableAdapters.careerTableAdapter careerTableAdapter = new DSTables.DScareerTableAdapters.careerTableAdapter();

//        DataTable odt = new DataTable();
//        DataTable dtphone = new DataTable();
//        DataTable dtrent = new DataTable();
//        DataTable dtown = new DataTable();
//        DataTable dtcareer = new DataTable();

//        List<string> searchNumbers = new List<string>();
//        List<Form> openedForms = new List<Form>();

//        string name, eventtext;
//        string type;
//        public string alwaysback;

//        public Boolean yes = true;
//        public Boolean Eventyes = true;
//        public static string phone1 = "";
//        public static string always = "";

//        public int totalRecordsFound = 0;
//        private string currentRecordId;

//        public RelatedRecordsForm(List<string> numbers, string pname = "", string peventtext = "", string ptype = "0", string currentId = "")
//        {
//            searchNumbers = numbers;
//            name = pname;
//            eventtext = peventtext;
//            type = ptype;
//            currentRecordId = currentId;  // ✅ store current record id

//            InitializeComponent();
//            this.StartPosition = FormStartPosition.CenterScreen;

//            load();
//            encrypt();
//            ChangeBorderColor();
//            FillWidthColumns();
//        }



//        private void FillWidthColumns()
//        {
//            dataGridView1.Columns["Column8"].Width = 80;
//        }

//        private void ChangeBorderColor()
//        {
//            this.Size = new Size(MainForm.MainForm_Size.Width - 20, MainForm.MainForm_Size.Height - 100);
//            this.Location = new Point(MainForm.MainForm_Location.X + 10, MainForm.MainForm_Location.Y + 100);
//            Color color = Color.FromArgb(0, 119, 182);
//            panel_top.BackColor = color;
//            panel_bottom.BackColor = color;
//            panel_left.BackColor = color;
//            panel_right.BackColor = color;
//        }

//        public void encrypt()
//        {
//            if (Utils.EncryptMode)
//            {
//                Column1.Visible = false;
//                Column2.Visible = false;
//                Column3.Visible = false;
//                Column4.Visible = false;
//                Column5.Visible = false;
//                Column6.Visible = false;
//                Column10.Visible = false;
//            }
//            if (!Utils.EncryptMode)
//            {
//                Column1.Visible = true;
//                Column2.Visible = true;
//                Column3.Visible = true;
//                Column4.Visible = true;
//                Column5.Visible = true;
//                Column6.Visible = true;
//                Column10.Visible = true;
//            }
//        }

//        private void load()
//        {
//            if (type == "0")
//                NotExact();
//            else
//                exact();

//        }


//        private void ClearAllDataTables()
//        {
//            dtphone.Clear();
//            dtrent.Clear();
//            dtown.Clear();
//            dtcareer.Clear();
//            odt.Clear();
//        }

//        private void RemoveDuplicateRows(DataTable dataTable, string keyColumn)
//        {
//            var seenKeys = new HashSet<string>();
//            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
//            {
//                string key = dataTable.Rows[i][keyColumn].ToString();
//                if (seenKeys.Contains(key))
//                {
//                    dataTable.Rows.RemoveAt(i);
//                }
//                else
//                {
//                    seenKeys.Add(key);
//                }
//            }
//        }

//        private void NotExact()
//        {
//            ClearAllDataTables();
//            if (name != "" || eventtext != "" || searchNumbers.Count > 0)
//            {
//                foreach (string number in searchNumbers)
//                {
//                    string phonequery = "";
//                    string realrentquesry = "";
//                    string realownquesry = "";
//                    string careerquery = "";

//                    if (eventtext != "")
//                    {
//                        phonequery = " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o , phoneEvent.Event as event FROM ( Phone left JOIN phoneEvent phoneEvent ON Phone.ID = phoneEvent.PhoneID ) where ";
//                        realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event ,Realstate.active as active FROM RealState left JOIN Event ON RealState.ID = Event.RealStateID where ";
//                        realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM RealstateOwne left JOIN eventown eventown ON RealstateOwne.ID = eventown.RealStateID where ";
//                        careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on career.id=careerEvent.careerID where ";

//                        phonequery += " ( phoneEvent.Event like '%" + eventtext + "%' ) and ";
//                        realrentquesry += "(   Event.Event like '%" + eventtext + "%') and ";
//                        realownquesry += " (   eventown.Event like '%" + eventtext + "%' ) and ";
//                        careerquery += "( careerEvent.Event like '%" + eventtext + "%' ) and ";
//                    }
//                    else
//                    {
//                        phonequery = " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o FROM  Phone where ";
//                        realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Realstate.active as active FROM RealState where ";
//                        realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , RealstateOwne.active as active FROM  RealstateOwne where ";
//                        careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o FROM career  where ";

//                        Eventyes = false;
//                    }

//                    int index = number.ToString().IndexOf("*");

//                    if (index > 0 && index != 0)
//                    {
//                        string newvalue = number.Substring(0, index);

//                        realrentquesry += " ( ( Phone_one like '" + newvalue + "%' ) or (   Phone_Two like '" + newvalue + "%')  or (   Mobile like '" + newvalue + "%') or (   Mobile2 like '" + newvalue + "%') or (other like '" + newvalue + "%') ) and ";
//                        realownquesry += "  ( (  Phone_one like '" + newvalue + "%' ) or (   Phone_Two like '" + newvalue + "%' ) or (    Mobile like '" + newvalue + "%' ) or (    Mobile2 like '" + newvalue + "%' )  or (other like '" + newvalue + "%') ) and  ";
//                        phonequery += "  ( ( p1 like '" + newvalue + "%' ) or ( p2 like '" + newvalue + "%' ) or ( m2 like '" + newvalue + "%' ) or (m3 like '" + newvalue + "%' ) or ( other like '" + newvalue + "%' ) ) and ";
//                        careerquery += " ( (  p like '" + newvalue + "%' ) or (   m like '" + newvalue + "%') or (other like '" + newvalue + "%') ) and ";
//                    }
//                    else if (index == 0)
//                    {
//                        string newvalue = number.Substring(index + 1);
//                        realrentquesry += " ( ( Phone_one like '%" + newvalue + "' ) or (   Phone_Two like '%" + newvalue + "')  or (   Mobile like '%" + newvalue + "') or (   Mobile2 like '%" + newvalue + "') or (other like '%" + newvalue + "') ) and ";
//                        realownquesry += "  ( (  Phone_one like '%" + newvalue + "' ) or (   Phone_Two like '%" + newvalue + "' ) or (    Mobile like '%" + newvalue + "' ) or (    Mobile2 like '%" + newvalue + "' )  or (other like '%" + newvalue + "') ) and  ";
//                        phonequery += "  (( p1 like '%" + newvalue + "' ) or ( p2 like '%" + newvalue + "')  or ( m2 like '%" + newvalue + "' ) or ( m3 like '%" + newvalue + "') or (other like '%" + newvalue + "' ) ) and ";
//                        careerquery += " ( (  p like '%" + newvalue + "' ) or (   m like '%" + newvalue + "') or (other like '%" + newvalue + "') ) and ";
//                    }
//                    else
//                    {
//                        if (number != "")
//                        {
//                            realrentquesry += " ( ( Phone_one like '%" + number + "%' ) or (   Phone_Two like '%" + number + "%')  or (   Mobile like '%" + number + "%') or (   Mobile2 like '%" + number + "%') or (other like '%" + number + "%') ) and ";
//                            realownquesry += "  ( (  Phone_one like '%" + number + "%' ) or (   Phone_Two like '%" + number + "%' ) or (    Mobile like '%" + number + "%' ) or (    Mobile2 like '%" + number + "%' )  or (other like '%" + number + "%') ) and  ";
//                            phonequery += "  (( p1 like '%" + number + "%' ) or ( p2 like '%" + number + "%')  or ( m2 like '%" + number + "%') or ( m3 like '%" + number + "%') or (other like '%" + number + "%' )) and ";
//                            careerquery += " ( (  p like '%" + number + "%' ) or (   m like '%" + number + "%') or (other like '%" + number + "%') ) and ";
//                        }
//                    }

//                    if (name != "")
//                    {
//                        realrentquesry += "  ( other like '%" + name + "%' or   Owner like '%" + name + "%'   or ";
//                        realownquesry += " (  other like '%" + name + "%' or Owner like '%" + name + "%'  or ";
//                        phonequery += " ( other like '%" + name + "%' or Name like '%" + name + "%'   or ";
//                        careerquery += "( other like '%" + name + "%' or Name like '%" + name + "%'   or ";


//                        string trimed = name.Trim();


//                        string Hmza = name.Trim().Replace("أ", "ا");
//                        realrentquesry += " Owner like '%" + Hmza + "%' or ";
//                        trimed = Hmza.Trim().Replace("ه", "ة");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = Hmza.Trim().Replace("ة", "ه");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = Hmza.Trim().Replace("ي", "ى");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = Hmza.Trim().Replace("ى", "ي");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = Hmza.Trim().Replace("ا", "ه");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = Hmza.Trim().Replace("ه", "ا");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        string Alftriemd = name.Trim().Replace("ا", "أ");
//                        realrentquesry += " Owner like '%" + Alftriemd + "%' or ";
//                        trimed = Alftriemd.Trim().Replace("ه", "ة");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = Alftriemd.Trim().Replace("ة", "ه");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = Alftriemd.Trim().Replace("ي", "ى");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = Alftriemd.Trim().Replace("ى", "ي");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = Alftriemd.Trim().Replace("ا", "ه");
//                        realrentquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = Alftriemd.Trim().Replace("ه", "ا");
//                        realrentquesry += " Owner like '%" + trimed + "%'  ) and ";


//                        string RoHmza = name.Trim().Replace("أ", "ا");
//                        realownquesry += " Owner like '%" + RoHmza + "%' or ";
//                        trimed = RoHmza.Trim().Replace("ه", "ة");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = RoHmza.Trim().Replace("ة", "ه");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = RoHmza.Trim().Replace("ي", "ى");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = RoHmza.Trim().Replace("ى", "ي");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = RoHmza.Trim().Replace("ا", "ه");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = RoHmza.Trim().Replace("ه", "ا");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        string RoAlftriemd = name.Trim().Replace("ا", "أ");
//                        realownquesry += " Owner like '%" + RoAlftriemd + "%' or ";
//                        trimed = RoAlftriemd.Trim().Replace("ه", "ة");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = RoAlftriemd.Trim().Replace("ة", "ه");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = RoAlftriemd.Trim().Replace("ي", "ى");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = RoAlftriemd.Trim().Replace("ى", "ي");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = RoAlftriemd.Trim().Replace("ا", "ه");
//                        realownquesry += " Owner like '%" + trimed + "%' or ";
//                        trimed = RoAlftriemd.Trim().Replace("ه", "ا");
//                        realownquesry += " Owner like '%" + trimed + "%'  ) and ";


//                        string PHHmza = name.Trim().Replace("أ", "ا");
//                        phonequery += " Name like '%" + PHHmza + "%' or ";
//                        trimed = PHHmza.Trim().Replace("ه", "ة");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        trimed = PHHmza.Trim().Replace("ة", "ه");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        trimed = PHHmza.Trim().Replace("ي", "ى");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        trimed = PHHmza.Trim().Replace("ى", "ي");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        trimed = PHHmza.Trim().Replace("ا", "ه");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        trimed = PHHmza.Trim().Replace("ه", "ا");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        string PHAlftriemd = name.Trim().Replace("ا", "أ");
//                        phonequery += " Name like '%" + PHAlftriemd + "%' or ";
//                        trimed = PHAlftriemd.Trim().Replace("ه", "ة");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        trimed = PHAlftriemd.Trim().Replace("ة", "ه");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        trimed = PHAlftriemd.Trim().Replace("ي", "ى");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        trimed = PHAlftriemd.Trim().Replace("ى", "ي");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        trimed = PHAlftriemd.Trim().Replace("ا", "ه");
//                        phonequery += " Name like '%" + trimed + "%' or ";
//                        trimed = PHAlftriemd.Trim().Replace("ه", "ا");
//                        phonequery += " Name like '%" + trimed + "%'  ) and ";


//                        string CarHmza = name.Trim().Replace("أ", "ا");
//                        careerquery += " Name like '%" + CarHmza + "%' or ";
//                        trimed = CarHmza.Trim().Replace("ه", "ة");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        trimed = CarHmza.Trim().Replace("ة", "ه");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        trimed = CarHmza.Trim().Replace("ي", "ى");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        trimed = CarHmza.Trim().Replace("ى", "ي");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        trimed = CarHmza.Trim().Replace("ا", "ه");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        trimed = CarHmza.Trim().Replace("ه", "ا");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        string CarAlftriemd = name.Trim().Replace("ا", "أ");
//                        careerquery += " Name like '%" + CarAlftriemd + "%' or ";
//                        trimed = CarAlftriemd.Trim().Replace("ه", "ة");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        trimed = CarAlftriemd.Trim().Replace("ة", "ه");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        trimed = CarAlftriemd.Trim().Replace("ي", "ى");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        trimed = CarAlftriemd.Trim().Replace("ى", "ي");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        trimed = CarAlftriemd.Trim().Replace("ا", "ه");
//                        careerquery += " Name like '%" + trimed + "%' or ";
//                        trimed = CarAlftriemd.Trim().Replace("ه", "ا");
//                        careerquery += " Name like '%" + trimed + "%'  ) and ";

//                    }

//                    if (phonequery != "")
//                    {
//                        DataTable tempDt = get(phonequery.Substring(0, phonequery.LastIndexOf("and")));
//                        dtphone.Merge(tempDt, true);
//                    }
//                    if (realrentquesry != "")
//                    {
//                        DataTable tempDt = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("and")));
//                        dtrent.Merge(tempDt, true);
//                    }
//                    if (realownquesry != "")
//                    {
//                        DataTable tempDt = get(realownquesry.Substring(0, realownquesry.LastIndexOf("and")));
//                        dtown.Merge(tempDt, true);
//                    }
//                    if (careerquery != "")
//                    {
//                        DataTable tempDt = get(careerquery.Substring(0, careerquery.LastIndexOf("and")));
//                        dtcareer.Merge(tempDt, true);
//                    }
//                }

//                RemoveDuplicateRows(dtphone, "id");
//                RemoveDuplicateRows(dtrent, "id");
//                RemoveDuplicateRows(dtown, "id");
//                RemoveDuplicateRows(dtcareer, "id");

//                odt.Merge(dtrent, true);
//                odt.Merge(dtphone, true);
//                odt.Merge(dtown, true);
//                odt.Merge(dtcareer, true);
//                odt.AcceptChanges();

//                // NEW: filter out the currently opened record from ALL tables
//                if (!string.IsNullOrEmpty(currentRecordId))
//                {
//                    RemoveById(dtphone, currentRecordId);
//                    RemoveById(dtrent, currentRecordId);
//                    RemoveById(dtown, currentRecordId);
//                    RemoveById(dtcareer, currentRecordId);
//                    RemoveById(odt, currentRecordId);
//                }

//                // NEW: compute real total to add to the grid
//                int totalToShow = dtphone.Rows.Count + dtcareer.Rows.Count + dtrent.Rows.Count + dtown.Rows.Count;
//                totalRecordsFound = totalToShow;

//                if (totalToShow > 0)
//                {
//                    int counter = 0;
//                    int number = 1;

//                    // IMPORTANT: clear and add the exact count we will fill
//                    dataGridView1.Rows.Clear();
//                    dataGridView1.Rows.Add(totalToShow);

//                    for (int y = 0; y < dtphone.Rows.Count; y++)
//                    {
//                        dataGridView1.Rows[counter].Cells[1].Value = dtphone.Rows[y]["id"].ToString();
//                        dataGridView1.Rows[counter].Cells[0].Value = number;
//                        dataGridView1.Rows[counter].Cells[2].Value = dtphone.Rows[y]["n"].ToString();
//                        dataGridView1.Rows[counter].Cells[3].Value = dtphone.Rows[y]["pone"].ToString();
//                        dataGridView1.Rows[counter].Cells[4].Value = dtphone.Rows[y]["mone"].ToString();
//                        dataGridView1.Rows[counter].Cells[5].Value = dtphone.Rows[y]["ptwo"].ToString();
//                        dataGridView1.Rows[counter].Cells[6].Value = dtphone.Rows[y]["mtwo"].ToString();
//                        dataGridView1.Rows[counter].Cells[7].Value = dtphone.Rows[y]["o"].ToString();
//                        // NEW: guard event column
//                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtphone.Columns.Contains("event")) ? dtphone.Rows[y]["event"].ToString() : "";
//                        dataGridView1.Rows[counter].Cells[9].Value = "الهاتف";
//                        counter++; number++;
//                    }

//                    for (int y = 0; y < dtcareer.Rows.Count; y++)
//                    {
//                        dataGridView1.Rows[counter].Cells[1].Value = dtcareer.Rows[y]["id"].ToString();
//                        dataGridView1.Rows[counter].Cells[0].Value = number;
//                        dataGridView1.Rows[counter].Cells[2].Value = dtcareer.Rows[y]["n"].ToString();
//                        dataGridView1.Rows[counter].Cells[3].Value = dtcareer.Rows[y]["pone"].ToString();
//                        dataGridView1.Rows[counter].Cells[4].Value = dtcareer.Rows[y]["mone"].ToString();
//                        dataGridView1.Rows[counter].Cells[7].Value = dtcareer.Rows[y]["o"].ToString();
//                        // NEW: guard event column
//                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtcareer.Columns.Contains("event")) ? dtcareer.Rows[y]["event"].ToString() : "";
//                        dataGridView1.Rows[counter].Cells[9].Value = "مهن";
//                        counter++; number++;
//                    }

//                    for (int y = 0; y < dtrent.Rows.Count; y++)
//                    {
//                        dataGridView1.Rows[counter].Cells[1].Value = dtrent.Rows[y]["id"].ToString();
//                        dataGridView1.Rows[counter].Cells[0].Value = number;
//                        dataGridView1.Rows[counter].Cells[2].Value = dtrent.Rows[y]["n"].ToString();
//                        dataGridView1.Rows[counter].Cells[3].Value = dtrent.Rows[y]["pone"].ToString();
//                        dataGridView1.Rows[counter].Cells[4].Value = dtrent.Rows[y]["mone"].ToString();
//                        dataGridView1.Rows[counter].Cells[5].Value = dtrent.Rows[y]["ptwo"].ToString();
//                        dataGridView1.Rows[counter].Cells[7].Value = dtrent.Rows[y]["o"].ToString();
//                        // NEW: guard event column
//                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtrent.Columns.Contains("event")) ? dtrent.Rows[y]["event"].ToString() : "";
//                        dataGridView1.Rows[counter].Cells[9].Value = (dtrent.Rows[y]["active"].ToString() == "1") ? "اجار" : "اجار ارشيف";
//                        counter++; number++;
//                    }

//                    for (int y = 0; y < dtown.Rows.Count; y++)
//                    {
//                        dataGridView1.Rows[counter].Cells[1].Value = dtown.Rows[y]["id"].ToString();
//                        dataGridView1.Rows[counter].Cells[0].Value = number;
//                        dataGridView1.Rows[counter].Cells[2].Value = dtown.Rows[y]["n"].ToString();
//                        dataGridView1.Rows[counter].Cells[3].Value = dtown.Rows[y]["pone"].ToString();
//                        dataGridView1.Rows[counter].Cells[4].Value = dtown.Rows[y]["mone"].ToString();
//                        dataGridView1.Rows[counter].Cells[5].Value = dtown.Rows[y]["ptwo"].ToString();
//                        dataGridView1.Rows[counter].Cells[7].Value = dtown.Rows[y]["o"].ToString();
//                        // NEW: guard event column
//                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtown.Columns.Contains("event")) ? dtown.Rows[y]["event"].ToString() : "";
//                        dataGridView1.Rows[counter].Cells[9].Value = (dtown.Rows[y]["active"].ToString() == "1") ? "بيع" : "بيع ارشيف";
//                        counter++; number++;
//                    }
//                }
//                else
//                {
//                    yes = false;
//                    alwaysback = "back";
//                }

//                dataGridView1.Refresh();

//            }
//            else
//            {
//                yes = false;
//                alwaysback = "back";
//            }
//        }

//        private void exact()
//        {
//            ClearAllDataTables();
//            if (name != "" || eventtext != "" || searchNumbers.Count > 0)
//            {
//                foreach (string number in searchNumbers)
//                {
//                    string phonequery = "";
//                    string realrentquesry = "";
//                    string realownquesry = "";
//                    string careerquery = "";

//                    if (eventtext != "")
//                    {
//                        phonequery = " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o , phoneEvent.Event as event FROM ( Phone left JOIN phoneEvent phoneEvent ON Phone.ID = phoneEvent.PhoneID ) where ";
//                        realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event ,Realstate.active as active FROM RealState left JOIN Event ON RealState.ID = Event.RealStateID where ";
//                        realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM RealstateOwne left JOIN eventown eventown ON RealstateOwne.ID = eventown.RealStateID where ";
//                        careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on career.id=careerEvent.careerID where ";

//                        phonequery += "( phoneEvent.Event ='" + eventtext + "' ) and ";
//                        realrentquesry += "(   Event.Event ='" + eventtext + "') and ";
//                        realownquesry += " (   eventown.Event ='" + eventtext + "' ) and ";
//                        careerquery += "( careerEvent.Event = '" + eventtext + "' ) and ";
//                    }
//                    else
//                    {
//                        phonequery = " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o FROM  Phone where ";
//                        realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Realstate.active as active FROM RealState where ";
//                        realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , RealstateOwne.active as active FROM  RealstateOwne where ";
//                        careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o FROM career  where ";

//                        Eventyes = false;
//                    }

//                    if (name != "")
//                    {
//                        realrentquesry += "  ((   Owner='" + name + "' ) ) and  ";
//                        realownquesry += " ( (  Owner='" + name + "')) and ";
//                        phonequery += "( ( Name = '" + name + "' ) ) and ";
//                        careerquery += "( ( Name = '" + name + "' ) ) and ";
//                    }

//                    if (number != "")
//                    {
//                        realrentquesry += " ( (   Phone_one= '" + number + "' ) or (   Phone_Two= '" + number + "')  or (   Mobile= '" + number + "') or (   Mobile2= '" + number + "') or ( other = '" + number + "' )) and ";
//                        realownquesry += " ( (   Phone_one= '" + number + "' ) or (   Phone_Two= '" + number + "' ) or (    Mobile= '" + number + "' ) or (    Mobile2= '" + number + "' ) or ( other = '" + number + "' ) ) and ";
//                        phonequery += " ( p1= '" + number + "' or p2= '" + number + "'  or m2= '" + number + "' or m3= '" + number + "'  or other = '" + number + "'  ) and  ";
//                        careerquery += " ((  p = '" + number + "' ) or (   m = '" + number + "') or ( other = '" + number + "' )  )and ";
//                    }

//                    if (phonequery != "SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o , phoneEvent.Event as event FROM Phone left JOIN phoneEvent phoneEvent ON  phoneEvent.PhoneID = Phone.ID  where ")
//                    {
//                        DataTable tempDt = get(phonequery.Substring(0, phonequery.LastIndexOf("and")));
//                        dtphone.Merge(tempDt, true);
//                    }
//                    if (realrentquesry != "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event , Realstate.active as active FROM RealState left JOIN Event ON Event.RealStateID = RealState.ID  where ")
//                    {
//                        DataTable tempDt = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("and")));
//                        dtrent.Merge(tempDt, true);
//                    }
//                    if (realownquesry != "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM RealstateOwne left JOIN eventown eventown ON  eventown.RealStateID = RealstateOwne.ID where ")
//                    {
//                        DataTable tempDt = get(realownquesry.Substring(0, realownquesry.LastIndexOf("and")));
//                        dtown.Merge(tempDt, true);
//                    }
//                    if (careerquery != "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on careerEvent.careerID = career.id where ")
//                    {
//                        DataTable tempDt = get(careerquery.Substring(0, careerquery.LastIndexOf("and")));
//                        dtcareer.Merge(tempDt, true);
//                    }
//                }

//                RemoveDuplicateRows(dtphone, "id");
//                RemoveDuplicateRows(dtrent, "id");
//                RemoveDuplicateRows(dtown, "id");
//                RemoveDuplicateRows(dtcareer, "id");

//                odt.Merge(dtrent, true);
//                odt.Merge(dtphone, true);
//                odt.Merge(dtown, true);
//                odt.Merge(dtcareer, true);
//                odt.AcceptChanges();

//                // NEW: filter out the currently opened record from ALL tables
//                if (!string.IsNullOrEmpty(currentRecordId))
//                {
//                    RemoveById(dtphone, currentRecordId);
//                    RemoveById(dtrent, currentRecordId);
//                    RemoveById(dtown, currentRecordId);
//                    RemoveById(dtcareer, currentRecordId);
//                    RemoveById(odt, currentRecordId);
//                }

//                // NEW: compute real total to add to the grid
//                int totalToShow = dtphone.Rows.Count + dtcareer.Rows.Count + dtrent.Rows.Count + dtown.Rows.Count;
//                totalRecordsFound = totalToShow;

//                if (totalToShow > 0)
//                {
//                    int counter = 0;
//                    int number = 1;

//                    // IMPORTANT: clear and add the exact count we will fill
//                    dataGridView1.Rows.Clear();
//                    dataGridView1.Rows.Add(totalToShow);

//                    for (int y = 0; y < dtphone.Rows.Count; y++)
//                    {
//                        dataGridView1.Rows[counter].Cells[1].Value = dtphone.Rows[y]["id"].ToString();
//                        dataGridView1.Rows[counter].Cells[0].Value = number;
//                        dataGridView1.Rows[counter].Cells[2].Value = dtphone.Rows[y]["n"].ToString();
//                        dataGridView1.Rows[counter].Cells[3].Value = dtphone.Rows[y]["pone"].ToString();
//                        dataGridView1.Rows[counter].Cells[4].Value = dtphone.Rows[y]["mone"].ToString();
//                        dataGridView1.Rows[counter].Cells[5].Value = dtphone.Rows[y]["ptwo"].ToString();
//                        dataGridView1.Rows[counter].Cells[6].Value = dtphone.Rows[y]["mtwo"].ToString();
//                        dataGridView1.Rows[counter].Cells[7].Value = dtphone.Rows[y]["o"].ToString();
//                        // NEW: guard event column
//                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtphone.Columns.Contains("event")) ? dtphone.Rows[y]["event"].ToString() : "";
//                        dataGridView1.Rows[counter].Cells[9].Value = "الهاتف";
//                        counter++; number++;
//                    }

//                    for (int y = 0; y < dtcareer.Rows.Count; y++)
//                    {
//                        dataGridView1.Rows[counter].Cells[1].Value = dtcareer.Rows[y]["id"].ToString();
//                        dataGridView1.Rows[counter].Cells[0].Value = number;
//                        dataGridView1.Rows[counter].Cells[2].Value = dtcareer.Rows[y]["n"].ToString();
//                        dataGridView1.Rows[counter].Cells[3].Value = dtcareer.Rows[y]["pone"].ToString();
//                        dataGridView1.Rows[counter].Cells[4].Value = dtcareer.Rows[y]["mone"].ToString();
//                        dataGridView1.Rows[counter].Cells[7].Value = dtcareer.Rows[y]["o"].ToString();
//                        // NEW: guard event column
//                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtcareer.Columns.Contains("event")) ? dtcareer.Rows[y]["event"].ToString() : "";
//                        dataGridView1.Rows[counter].Cells[9].Value = "مهن";
//                        counter++; number++;
//                    }

//                    for (int y = 0; y < dtrent.Rows.Count; y++)
//                    {
//                        dataGridView1.Rows[counter].Cells[1].Value = dtrent.Rows[y]["id"].ToString();
//                        dataGridView1.Rows[counter].Cells[0].Value = number;
//                        dataGridView1.Rows[counter].Cells[2].Value = dtrent.Rows[y]["n"].ToString();
//                        dataGridView1.Rows[counter].Cells[3].Value = dtrent.Rows[y]["pone"].ToString();
//                        dataGridView1.Rows[counter].Cells[4].Value = dtrent.Rows[y]["mone"].ToString();
//                        dataGridView1.Rows[counter].Cells[5].Value = dtrent.Rows[y]["ptwo"].ToString();
//                        dataGridView1.Rows[counter].Cells[7].Value = dtrent.Rows[y]["o"].ToString();
//                        // NEW: guard event column
//                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtrent.Columns.Contains("event")) ? dtrent.Rows[y]["event"].ToString() : "";
//                        dataGridView1.Rows[counter].Cells[9].Value = (dtrent.Rows[y]["active"].ToString() == "1") ? "اجار" : "اجار ارشيف";
//                        counter++; number++;
//                    }

//                    for (int y = 0; y < dtown.Rows.Count; y++)
//                    {
//                        dataGridView1.Rows[counter].Cells[1].Value = dtown.Rows[y]["id"].ToString();
//                        dataGridView1.Rows[counter].Cells[0].Value = number;
//                        dataGridView1.Rows[counter].Cells[2].Value = dtown.Rows[y]["n"].ToString();
//                        dataGridView1.Rows[counter].Cells[3].Value = dtown.Rows[y]["pone"].ToString();
//                        dataGridView1.Rows[counter].Cells[4].Value = dtown.Rows[y]["mone"].ToString();
//                        dataGridView1.Rows[counter].Cells[5].Value = dtown.Rows[y]["ptwo"].ToString();
//                        dataGridView1.Rows[counter].Cells[7].Value = dtown.Rows[y]["o"].ToString();
//                        // NEW: guard event column
//                        dataGridView1.Rows[counter].Cells[8].Value = (Eventyes && dtown.Columns.Contains("event")) ? dtown.Rows[y]["event"].ToString() : "";
//                        dataGridView1.Rows[counter].Cells[9].Value = (dtown.Rows[y]["active"].ToString() == "1") ? "بيع" : "بيع ارشيف";
//                        counter++; number++;
//                    }
//                }
//                else
//                {
//                    yes = false;
//                    alwaysback = "back";
//                }

//                dataGridView1.Refresh();

//            }
//            else
//            {
//                yes = false;
//                alwaysback = "back";
//            }
//        }

//        private static void RemoveById(DataTable dt, string id)
//        {
//            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(id)) return;
//            for (int i = dt.Rows.Count - 1; i >= 0; i--)
//            {
//                if (dt.Rows[i].Table.Columns.Contains("id") &&
//                    dt.Rows[i]["id"].ToString() == id)
//                {
//                    dt.Rows.RemoveAt(i);
//                }
//            }
//            dt.AcceptChanges();
//        }

//        public static DataTable get(string SqlStatement)
//        {
//            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
//            OleDbConnection conn = new OleDbConnection(serverConnectionString);
//            try
//            {
//                conn.Open();
//                OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
//                DataTable dt = new DataTable();
//                sda.Fill(dt);
//                conn.Close();
//                conn.Dispose();
//                sda.Dispose();
//                return dt;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {
//            // Check if this form is already opened to avoid infinite loops
//            if (IsFormAlreadyOpened()) return;

//            RealstateOwner own = new RealstateOwner();
//            Realstate rent = new Realstate();
//            phone phone = new phone();
//            career car = new career();

//            try
//            {
//                if (e.ColumnIndex == 0)
//                {
//                    string recordType = dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString();
//                    int recordId = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[1].Value.ToString());

//                    // Add this form to opened forms list
//                    openedForms.Add(this);

//                    if (recordType == "اجار" || recordType == "اجار ارشيف")
//                    {
//                        this.RealStateTableAdaptersearch.UpdateQuery(DateTime.Now.Date, recordId);
//                        rent.recored_id = recordId;
//                        rent.am = "Search";
//                        rent.Text = "بحث";
//                        rent.ShowDialog();

//                        if (rent.back == "back")
//                        {
//                            alwaysback = "back";
//                            this.Close();
//                        }
//                    }
//                    else if (recordType == "بيع" || recordType == "بيع ارشيف")
//                    {
//                        this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date, recordId);
//                        own.recored_id = recordId;
//                        own.am = "Search";
//                        own.Text = "بحث";
//                        own.ShowDialog();

//                        if (own.back == "back")
//                        {
//                            alwaysback = "back";
//                            this.Close();
//                        }
//                    }
//                    else if (recordType == "الهاتف")
//                    {
//                        phone.recored_id = recordId;
//                        phone.am = "Search";
//                        phone.Text = "بحث";
//                        phone.ShowDialog();

//                        if (phone.back == "back")
//                        {
//                            alwaysback = "back";
//                            this.Close();
//                        }
//                    }
//                    else if (recordType == "مهن")
//                    {
//                        car.recored_id = recordId;
//                        car.am = "Search";
//                        car.Text = "بحث";
//                        car.ShowDialog();

//                        if (car.back == "back")
//                        {
//                            alwaysback = "back";
//                            this.Close();
//                        }
//                    }

//                    // Remove this form from opened forms list after dialog closes
//                    openedForms.Remove(this);
//                }
//            }
//            catch
//            {
//                openedForms.Remove(this);
//            }
//        }

//        private bool IsFormAlreadyOpened()
//        {
//            // Check if this form is already in the opened forms list
//            return openedForms.Contains(this);
//        }

//        public static void ShowModalExcept(Form modalForm, Form exceptionForm)
//        {
//            foreach (Form f in Application.OpenForms)
//            {
//                if (f != modalForm && f != exceptionForm)
//                {
//                    f.Enabled = false;
//                }
//            }

//            modalForm.FormClosed += (s, e) =>
//            {
//                foreach (Form f in Application.OpenForms)
//                {
//                    f.Enabled = true;
//                }
//            };

//            modalForm.Show();
//        }

//        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
//        {
//            for (int i = 0; i < dataGridView1.Rows.Count; i++)
//            {
//                dataGridView1.Rows[i].Cells["Column8"].Value = i + 1;
//            }
//        }

//        private void Close_btn_Click(object sender, EventArgs e)
//        {
//            this.Close();
//            //Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

//        }

//        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
//        {
//            const int WM_KEYDOWN = 0x100;
//            if (msg.Msg == WM_KEYDOWN)
//            {
//                if (keyData == Keys.Escape)
//                {
//                    this.Close();
//                    return true;
//                }

//                if (keyData == Keys.F11)
//                {
//                    Utils.EncryptMode = !Utils.EncryptMode;
//                    encrypt();
//                    return true;
//                }

//                if (keyData == Keys.F1)
//                {
//                    alwaysback = "back";
//                    this.Close();
//                }
//            }

//            return true;
//        }
//    }
//}