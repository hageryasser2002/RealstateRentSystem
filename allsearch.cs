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
    public partial class allsearch : Form
    {
        private DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter realStateTableAdapter = new DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter();
        private DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter RealStateTableAdaptersearch = new DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter();

        DSTables.DSphoneTableAdapters.PhoneTableAdapter PhoneTableAdapter = new DSTables.DSphoneTableAdapters.PhoneTableAdapter();
        DSTables.DSrealstateTableAdapters.RealStateTableAdapter RealStateTableAdapter = new DSTables.DSrealstateTableAdapters.RealStateTableAdapter();
        DSTables.DScareerTableAdapters.careerTableAdapter careerTableAdapter = new DSTables.DScareerTableAdapters.careerTableAdapter();
        DSTables.DSregionTableAdapters.RegionTableAdapter RegionTableAdapter = new DSTables.DSregionTableAdapters.RegionTableAdapter();

        DataTable odt = new DataTable();
        DataTable dtphone = new DataTable();
        DataTable dtrent = new DataTable();
        DataTable dtown = new DataTable();
        DataTable dtcareer = new DataTable();

        string value;
        public string alwaysback;

        public Boolean yes = true;

        public allsearch(string pvalue)
        {
            value = pvalue;
            InitializeComponent();
            load();
            encrypt();

         
        }

        public allsearch(string pvalue,string phone)
        {
            value = pvalue;
            InitializeComponent();
            loadCall();
            encrypt();
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

        private void loadCall()
        {
            string[] prameter = value.Split('-');
            if (prameter.Length > 1)
            {
                loadWithDach(value);

            }
            else
            {

                if (value != "" && value != null)
                {

                    string phonequery = "SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o  FROM phone  WHERE";

                    string realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o  ,Realstate.active as active FROM  RealState  where ";
                    string realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o ,RealstateOwne.active as active FROM  RealstateOwne  where ";

                    string careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o  FROM career where ";

                    string trimed = value.Trim();

                    string Hmza = value.Trim().Replace("أ", "ا");
                    phonequery += " phone.Name like '%" + Hmza + "%' or ";
                    trimed = Hmza.Trim().Replace("ه", "ة");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ة", "ه");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ي", "ى");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ى", "ي");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ا", "ه");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ه", "ا");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";


                    string Alftriemd = value.Trim().Replace("ا", "أ");
                    phonequery += " phone.Name like '%" + Alftriemd + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ه", "ة");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ة", "ه");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ي", "ى");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ى", "ي");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ا", "ه");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ه", "ا");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";

                    phonequery += "(phone.Name like '%" + value + "%') or (phone.p1 like '%" + value + "%') or (phone.p2 like '%" + value + "%') or " +
                    " (phone.m2 like '%" + value + "%') or (phone.m3 like '%" + value + "%') or (phone.other like '%" + value + "%') or (phone.notes like '%" + value + "%') or";

                    /////////////////////////////////////////////////////////////////////////////////////

                    DSTables.DSregionTableAdapters.RegionTableAdapter RegionTableAdapter = new DSTables.DSregionTableAdapters.RegionTableAdapter();
                    DataTable dt = new DataTable();

                    dt = RegionTableAdapter.GetId(value);
                    int regionid = 0;
                    if (dt.Rows.Count > 0)
                    {
                        regionid = Convert.ToInt32(dt.Rows[0]["ID"]);

                    }
                    string ReHmza = value.Trim().Replace("أ", "ا");
                    realrentquesry += " RealState.Owner like '%" + ReHmza + "%' or ";
                    trimed = ReHmza.Trim().Replace("ه", "ة");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReHmza.Trim().Replace("ة", "ه");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReHmza.Trim().Replace("ي", "ى");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReHmza.Trim().Replace("ى", "ي");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReHmza.Trim().Replace("ا", "ه");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReHmza.Trim().Replace("ه", "ا");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";


                    string ReAlftriemd = value.Trim().Replace("ا", "أ");
                    realrentquesry += " RealState.Owner like '%" + ReAlftriemd + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ه", "ة");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ة", "ه");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ي", "ى");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ى", "ي");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ا", "ه");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ه", "ا");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";


                    realrentquesry += " (RealState.Region_ID = " + regionid + ") or (RealState.SubResgionID LIKE '%" + value + "%') or (RealState.Building LIKE '%" + value + "%') or (RealState.FloorComment LIKE '%" + value + "%') or (RealState.Entrance LIKE '%" + value + "%') or " +
                                      " (RealState.Distance LIKE '%" + value + "%') or (RealState.Owner LIKE '%" + value + "%') or (RealState.Phone_one LIKE '%" + value + "%') or " +
                                      " (RealState.Phone_Two LIKE '%" + value + "%') or (RealState.Mobile LIKE '%" + value + "%') or (RealState.Other LIKE '%" + value + "%') or " +
                                      " (Realstate.Mobile2 LIKE '%" + value + "%') or " +
                                      " (RealState.[Note] LIKE '%" + value + "%') or (RealState.Info_Source LIKE '%" + value + "%') or ";


                    /////////////////////////////////////////////////////////////////////////////

                    string ReoHmza = value.Trim().Replace("أ", "ا");
                    realownquesry += " RealstateOwne.Owner like '%" + ReoHmza + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ه", "ة");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ة", "ه");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ي", "ى");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ى", "ي");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ا", "ه");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ه", "ا");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";


                    string ReoAlftriemd = value.Trim().Replace("ا", "أ");
                    realownquesry += " RealstateOwne.Owner like '%" + ReoAlftriemd + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ه", "ة");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ة", "ه");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ي", "ى");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ى", "ي");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ا", "ه");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ه", "ا");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";


                    realownquesry += "(RealstateOwne.Region_ID LIKE '%" + value + "%') or (RealstateOwne.SubResgionID LIKE '%" + value + "%') or (RealstateOwne.Building LIKE '%" + value + "%') or (RealstateOwne.FloorComment LIKE '%" + value + "%') or (RealstateOwne.Entrance LIKE '%" + value + "%') or " +
                     " (RealstateOwne.Distance LIKE '%" + value + "%') or (RealstateOwne.Owner LIKE '%" + value + "%') or (RealstateOwne.Phone_one LIKE '%" + value + "%') or " +
                     " (RealstateOwne.Phone_Two LIKE '%" + value + "%') or (RealstateOwne.Mobile LIKE '%" + value + "%') or (RealstateOwne.Other LIKE '%" + value + "%') or " +
                     " (RealstateOwne.Mobile2 LIKE '%" + value + "%') or " +
                     " (RealstateOwne.[Note] LIKE '%" + value + "%') or (RealstateOwne.Info_Source LIKE '%" + value + "%') or ";
                   

                    ///////////////////////////////////////////////////////////////////////////////////

                    string CarHmza = value.Trim().Replace("أ", "ا");
                    careerquery += " career.Name like '%" + CarHmza + "%' or ";
                    trimed = CarHmza.Trim().Replace("ه", "ة");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ة", "ه");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ي", "ى");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ى", "ي");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ا", "ه");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ه", "ا");
                    careerquery += " career.Name like '%" + trimed + "%' or ";


                    string CarAlftriemd = value.Trim().Replace("ا", "أ");
                    careerquery += " career.Name like '%" + CarAlftriemd + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ه", "ة");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ة", "ه");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ي", "ى");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ى", "ي");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ا", "ه");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ه", "ا");
                    careerquery += " career.Name like '%" + trimed + "%' or ";

                    careerquery += " (career.Name LIKE '%" + value + "%') OR " +
                  " (career.careertype LIKE '%" + value + "%') OR " +
                  " (career.p LIKE '%" + value + "%') OR " +
                  " (career.m LIKE '%" + value + "%') OR " +
                  " (career.other LIKE '%" + value + "%') OR " +
                  " (career.notes LIKE '%" + value + "%') OR " +
                  " (career.category LIKE '%" + value + "%') or";



                    
                   

                    



                    if (phonequery != "SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o  FROM phone  WHERE")
                    {
                        dtphone = get(phonequery.Substring(0, phonequery.LastIndexOf("or")));
                    }
                    if (realrentquesry != "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o  ,Realstate.active as active FROM  RealState  where ")
                    {
                        dtrent = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("or")));
                    }
                    if (realownquesry != "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o ,RealstateOwne.active as active FROM  RealstateOwne  where ")
                    {
                        dtown = get(realownquesry.Substring(0, realownquesry.LastIndexOf("or")));
                    }

                    if (careerquery != "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o  FROM career where ")
                    {
                        dtcareer = get(careerquery.Substring(0, careerquery.LastIndexOf("or")));
                    }


                    odt.Merge(dtrent, true);
                    odt.Merge(dtphone, true);
                    odt.Merge(dtown, true);
                    odt.Merge(dtcareer, true);
                    odt.AcceptChanges();

                    if (odt.Rows.Count > 0)
                    {
                        int counter = 0;
                        dataGridView1.Rows.Add(odt.Rows.Count);
                        for (int y = 0; y < dtphone.Rows.Count; y++)
                        {
                            if (checkrecored(dtphone.Rows[y]["id"].ToString(), "الهاتف"))
                            {
                                dataGridView1.Rows[counter].Cells[0].Value = dtphone.Rows[y]["id"].ToString();
                                dataGridView1.Rows[counter].Cells[2].Value = dtphone.Rows[y]["n"].ToString();
                                dataGridView1.Rows[counter].Cells[3].Value = dtphone.Rows[y]["pone"].ToString();
                                dataGridView1.Rows[counter].Cells[4].Value = dtphone.Rows[y]["mone"].ToString();
                                dataGridView1.Rows[counter].Cells[5].Value = dtphone.Rows[y]["ptwo"].ToString();
                                dataGridView1.Rows[counter].Cells[6].Value = dtphone.Rows[y]["mtwo"].ToString();
                                dataGridView1.Rows[counter].Cells[7].Value = dtphone.Rows[y]["o"].ToString();
                               // dataGridView1.Rows[counter].Cells[8].Value = dtphone.Rows[y]["event"].ToString();
                                dataGridView1.Rows[counter].Cells[9].Value = "الهاتف";

                                counter = counter + 1;
                            }
                        }


                        for (int y = 0; y < dtcareer.Rows.Count; y++)
                        {

                            if (checkrecored(dtcareer.Rows[y]["id"].ToString(), "مهن"))
                            {
                                dataGridView1.Rows[counter].Cells[0].Value = dtcareer.Rows[y]["id"].ToString();
                                dataGridView1.Rows[counter].Cells[2].Value = dtcareer.Rows[y]["n"].ToString();
                                dataGridView1.Rows[counter].Cells[3].Value = dtcareer.Rows[y]["pone"].ToString();
                                dataGridView1.Rows[counter].Cells[4].Value = dtcareer.Rows[y]["mone"].ToString();
                                //dataGridView1.Rows[counter].Cells[5].Value = dtcareer.Rows[y]["ptwo"].ToString();
                                //dataGridView1.Rows[counter].Cells[6].Value = dtcareer.Rows[y]["mtwo"].ToString();
                                dataGridView1.Rows[counter].Cells[7].Value = dtcareer.Rows[y]["o"].ToString();
                               // dataGridView1.Rows[counter].Cells[8].Value = dtcareer.Rows[y]["event"].ToString();
                                dataGridView1.Rows[counter].Cells[9].Value = "مهن";

                                counter = counter + 1;

                            }
                        }

                        for (int y = 0; y < dtrent.Rows.Count; y++)
                        {
                            if (checkrecored(dtrent.Rows[y]["id"].ToString(), "اجار"))
                            {
                                dataGridView1.Rows[counter].Cells[0].Value = dtrent.Rows[y]["id"].ToString();
                                dataGridView1.Rows[counter].Cells[2].Value = dtrent.Rows[y]["n"].ToString();
                                dataGridView1.Rows[counter].Cells[3].Value = dtrent.Rows[y]["pone"].ToString();
                                dataGridView1.Rows[counter].Cells[4].Value = dtrent.Rows[y]["mone"].ToString();
                                dataGridView1.Rows[counter].Cells[5].Value = dtrent.Rows[y]["ptwo"].ToString();
                                //dataGridView1.Rows[counter].Cells[6].Value = dtrent.Rows[y]["mtwo"].ToString();
                                dataGridView1.Rows[counter].Cells[7].Value = dtrent.Rows[y]["o"].ToString();
                               // dataGridView1.Rows[counter].Cells[8].Value = dtrent.Rows[y]["event"].ToString();
                                if (dtrent.Rows[y]["active"].ToString() == "1")
                                {
                                    dataGridView1.Rows[counter].Cells[9].Value = "اجار";
                                }
                                else
                                {
                                    dataGridView1.Rows[counter].Cells[9].Value = "اجار ارشيف";
                                }
                                counter = counter + 1;
                            }
                        }


                        for (int y = 0; y < dtown.Rows.Count; y++)
                        {
                            if (checkrecored(dtown.Rows[y]["id"].ToString(), "بيع"))
                            {
                                dataGridView1.Rows[counter].Cells[0].Value = dtown.Rows[y]["id"].ToString();
                                dataGridView1.Rows[counter].Cells[2].Value = dtown.Rows[y]["n"].ToString();
                                dataGridView1.Rows[counter].Cells[3].Value = dtown.Rows[y]["pone"].ToString();
                                dataGridView1.Rows[counter].Cells[4].Value = dtown.Rows[y]["mone"].ToString();
                                dataGridView1.Rows[counter].Cells[5].Value = dtown.Rows[y]["ptwo"].ToString();
                                //dataGridView1.Rows[counter].Cells[6].Value = dtown.Rows[y]["mtwo"].ToString();
                                dataGridView1.Rows[counter].Cells[7].Value = dtown.Rows[y]["o"].ToString();
                                //dataGridView1.Rows[counter].Cells[8].Value = dtown.Rows[y]["event"].ToString();

                                if (dtown.Rows[y]["active"].ToString() == "1")
                                {
                                    dataGridView1.Rows[counter].Cells[9].Value = "بيع";
                                }
                                else
                                {
                                    dataGridView1.Rows[counter].Cells[9].Value = "بيع ارشيف";
                                }
                                counter = counter + 1;
                            }
                        }


                        for (int u = 0; u < dataGridView1.Rows.Count; u++)
                        {
                            if ((dataGridView1.Rows[u].Cells[0].Value == null))
                            {
                                try
                                {
                                    dataGridView1.Rows[u].Visible = false;
                                }
                                catch
                                {

                                }
                            }
                        }

                    }
                    else
                    {
                        if (!Utils.CheckOtherRecord)
                        {
                            MessageBox.Show("لا يوجد نتائج");
                        }
                        yes = false;
                    }

                    dataGridView1.Refresh();


                }
                else
                {

                    MessageBox.Show("الرجاء ادخال كلمة البحث");
                    yes = false;
                }


            }

        }

        private void load()
        {


            string[] prameter = value.Split('-');
            if (prameter.Length > 1)
            {
                loadWithDach(value);

            }
            else
            {

                if (value != "" && value != null)
                {

                    string phonequery = "SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o , phoneEvent.Event as event FROM (phone LEFT OUTER JOIN phoneEvent ON phoneEvent.PhoneID = phone.ID) WHERE";

                    string realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event ,Realstate.active as active FROM ( RealState left OUTER JOIN Event ON Event.RealStateID=RealState.ID )  where ";
                    string realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM ( RealstateOwne left OUTER JOIN eventown eventown ON eventown.RealStateID = RealstateOwne.ID  ) where ";

                    string careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on career.id=careerEvent.careerID where ";

                    string trimed = value.Trim();

                    string Hmza = value.Trim().Replace("أ", "ا");
                    phonequery += " phone.Name like '%" + Hmza + "%' or ";
                    trimed = Hmza.Trim().Replace("ه", "ة");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ة", "ه");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ي", "ى");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ى", "ي");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ا", "ه");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Hmza.Trim().Replace("ه", "ا");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";


                    string Alftriemd = value.Trim().Replace("ا", "أ");
                    phonequery += " phone.Name like '%" + Alftriemd + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ه", "ة");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ة", "ه");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ي", "ى");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ى", "ي");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ا", "ه");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";
                    trimed = Alftriemd.Trim().Replace("ه", "ا");
                    phonequery += " phone.Name like '%" + trimed + "%' or ";

                    phonequery += "(phone.Name like '%" + value + "%') or (phoneEvent.Event like '%" + value + "%') or (phone.p1 like '%" + value + "%') or (phone.p2 like '%" + value + "%') or " +
                    " (phone.m2 like '%" + value + "%') or (phone.m3 like '%" + value + "%') or (phone.other like '%" + value + "%') or (phone.notes like '%" + value + "%') or";

                    /////////////////////////////////////////////////////////////////////////////////////

                    DSTables.DSregionTableAdapters.RegionTableAdapter RegionTableAdapter = new DSTables.DSregionTableAdapters.RegionTableAdapter();
                    DataTable dt = new DataTable();

                    dt = RegionTableAdapter.GetId(value);
                    int regionid = 0;
                    if (dt.Rows.Count > 0)
                    {
                        regionid = Convert.ToInt32(dt.Rows[0]["ID"]);

                    }
                    string ReHmza = value.Trim().Replace("أ", "ا");
                    realrentquesry += " RealState.Owner like '%" + ReHmza + "%' or ";
                    trimed = ReHmza.Trim().Replace("ه", "ة");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReHmza.Trim().Replace("ة", "ه");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReHmza.Trim().Replace("ي", "ى");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReHmza.Trim().Replace("ى", "ي");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReHmza.Trim().Replace("ا", "ه");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReHmza.Trim().Replace("ه", "ا");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";


                    string ReAlftriemd = value.Trim().Replace("ا", "أ");
                    realrentquesry += " RealState.Owner like '%" + ReAlftriemd + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ه", "ة");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ة", "ه");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ي", "ى");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ى", "ي");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ا", "ه");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                    trimed = ReAlftriemd.Trim().Replace("ه", "ا");
                    realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";


                    realrentquesry += " (RealState.Region_ID = " + regionid + ") or (RealState.SubResgionID LIKE '%" + value + "%') or (RealState.Building LIKE '%" + value + "%') or (RealState.FloorComment LIKE '%" + value + "%') or (RealState.Entrance LIKE '%" + value + "%') or " +
                                      " (RealState.Distance LIKE '%" + value + "%') or (RealState.Owner LIKE '%" + value + "%') or (RealState.Phone_one LIKE '%" + value + "%') or " +
                                      " (RealState.Phone_Two LIKE '%" + value + "%') or (RealState.Mobile LIKE '%" + value + "%') or (RealState.Other LIKE '%" + value + "%') or " +
                                      " (Realstate.Mobile2 LIKE '%" + value + "%') or " +
                                      " (RealState.[Note] LIKE '%" + value + "%') or (RealState.Info_Source LIKE '%" + value + "%') or " +
                                      " (Event.Event LIKE '%" + value + "%') or ";

                    /////////////////////////////////////////////////////////////////////////////

                    string ReoHmza = value.Trim().Replace("أ", "ا");
                    realownquesry += " RealstateOwne.Owner like '%" + ReoHmza + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ه", "ة");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ة", "ه");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ي", "ى");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ى", "ي");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ا", "ه");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoHmza.Trim().Replace("ه", "ا");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";


                    string ReoAlftriemd = value.Trim().Replace("ا", "أ");
                    realownquesry += " RealstateOwne.Owner like '%" + ReoAlftriemd + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ه", "ة");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ة", "ه");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ي", "ى");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ى", "ي");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ا", "ه");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                    trimed = ReoAlftriemd.Trim().Replace("ه", "ا");
                    realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";


                    realownquesry += "(RealstateOwne.Region_ID LIKE '%" + value + "%') or (RealstateOwne.SubResgionID LIKE '%" + value + "%') or (RealstateOwne.Building LIKE '%" + value + "%') or (RealstateOwne.FloorComment LIKE '%" + value + "%') or (RealstateOwne.Entrance LIKE '%" + value + "%') or " +
                     " (RealstateOwne.Distance LIKE '%" + value + "%') or (RealstateOwne.Owner LIKE '%" + value + "%') or (RealstateOwne.Phone_one LIKE '%" + value + "%') or " +
                     " (RealstateOwne.Phone_Two LIKE '%" + value + "%') or (RealstateOwne.Mobile LIKE '%" + value + "%') or (RealstateOwne.Other LIKE '%" + value + "%') or " +
                     " (RealstateOwne.Mobile2 LIKE '%" + value + "%') or " +
                     " (RealstateOwne.[Note] LIKE '%" + value + "%') or (RealstateOwne.Info_Source LIKE '%" + value + "%') or " +
                     " (eventown.Event LIKE '%" + value + "%') or ";

                    ///////////////////////////////////////////////////////////////////////////////////

                    string CarHmza = value.Trim().Replace("أ", "ا");
                    careerquery += " career.Name like '%" + CarHmza + "%' or ";
                    trimed = CarHmza.Trim().Replace("ه", "ة");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ة", "ه");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ي", "ى");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ى", "ي");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ا", "ه");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarHmza.Trim().Replace("ه", "ا");
                    careerquery += " career.Name like '%" + trimed + "%' or ";


                    string CarAlftriemd = value.Trim().Replace("ا", "أ");
                    careerquery += " career.Name like '%" + CarAlftriemd + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ه", "ة");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ة", "ه");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ي", "ى");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ى", "ي");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ا", "ه");
                    careerquery += " career.Name like '%" + trimed + "%' or ";
                    trimed = CarAlftriemd.Trim().Replace("ه", "ا");
                    careerquery += " career.Name like '%" + trimed + "%' or ";

                    careerquery += " (career.Name LIKE '%" + value + "%') OR " +
                  " (career.careertype LIKE '%" + value + "%') OR " +
                  " (career.p LIKE '%" + value + "%') OR " +
                  " (career.m LIKE '%" + value + "%') OR " +
                  " (career.other LIKE '%" + value + "%') OR " +
                  " (career.notes LIKE '%" + value + "%') OR " +
                  " (career.category LIKE '%" + value + "%') or" +
                  "  (careerEvent.event LIKE '%" + value + "%') or";



                    if (phonequery != "SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o , phoneEvent.Event as event FROM Phone left JOIN phoneEvent phoneEvent ON Phone.ID = phoneEvent.PhoneID where ")
                    {
                        dtphone = get(phonequery.Substring(0, phonequery.LastIndexOf("or")));
                    }
                    if (realrentquesry != "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event ,Realstate.active as active FROM RealState left JOIN Event ON RealState.ID = Event.RealStateID where ")
                    {
                        dtrent = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("or")));
                    }
                    if (realownquesry != "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM RealstateOwne left JOIN eventown eventown ON RealstateOwne.ID = eventown.RealStateID where ")
                    {
                        dtown = get(realownquesry.Substring(0, realownquesry.LastIndexOf("or")));
                    }

                    if (careerquery != "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on career.id=careerEvent.careerID where ")
                    {
                        dtcareer = get(careerquery.Substring(0, careerquery.LastIndexOf("or")));
                    }


                    odt.Merge(dtrent, true);
                    odt.Merge(dtphone, true);
                    odt.Merge(dtown, true);
                    odt.Merge(dtcareer, true);
                    odt.AcceptChanges();

                    if (odt.Rows.Count > 0)
                    {
                        int counter = 0;
                        dataGridView1.Rows.Add(odt.Rows.Count);
                        for (int y = 0; y < dtphone.Rows.Count; y++)
                        {
                            if (checkrecored(dtphone.Rows[y]["id"].ToString(), "الهاتف"))
                            {
                                dataGridView1.Rows[counter].Cells[0].Value = dtphone.Rows[y]["id"].ToString();
                               
                                dataGridView1.Rows[counter].Cells[2].Value = dtphone.Rows[y]["n"].ToString();
                                dataGridView1.Rows[counter].Cells[3].Value = dtphone.Rows[y]["pone"].ToString();
                                dataGridView1.Rows[counter].Cells[4].Value = dtphone.Rows[y]["mone"].ToString();
                                dataGridView1.Rows[counter].Cells[5].Value = dtphone.Rows[y]["ptwo"].ToString();
                                dataGridView1.Rows[counter].Cells[6].Value = dtphone.Rows[y]["mtwo"].ToString();
                                dataGridView1.Rows[counter].Cells[7].Value = dtphone.Rows[y]["o"].ToString();
                                dataGridView1.Rows[counter].Cells[8].Value = dtphone.Rows[y]["event"].ToString();
                                dataGridView1.Rows[counter].Cells[9].Value = "الهاتف";

                                counter = counter + 1;
                            }
                        }


                        for (int y = 0; y < dtcareer.Rows.Count; y++)
                        {

                            if (checkrecored(dtcareer.Rows[y]["id"].ToString(), "مهن"))
                            {
                                dataGridView1.Rows[counter].Cells[0].Value = dtcareer.Rows[y]["id"].ToString();
                               
                                dataGridView1.Rows[counter].Cells[2].Value = dtcareer.Rows[y]["n"].ToString();
                                dataGridView1.Rows[counter].Cells[3].Value = dtcareer.Rows[y]["pone"].ToString();
                                dataGridView1.Rows[counter].Cells[4].Value = dtcareer.Rows[y]["mone"].ToString();
                                //dataGridView1.Rows[counter].Cells[5].Value = dtcareer.Rows[y]["ptwo"].ToString();
                                //dataGridView1.Rows[counter].Cells[6].Value = dtcareer.Rows[y]["mtwo"].ToString();
                                dataGridView1.Rows[counter].Cells[7].Value = dtcareer.Rows[y]["o"].ToString();
                                dataGridView1.Rows[counter].Cells[8].Value = dtcareer.Rows[y]["event"].ToString();
                                dataGridView1.Rows[counter].Cells[9].Value = "مهن";

                                counter = counter + 1;

                            }
                        }

                        for (int y = 0; y < dtrent.Rows.Count; y++)
                        {
                            if (checkrecored(dtrent.Rows[y]["id"].ToString(), "اجار"))
                            {
                                dataGridView1.Rows[counter].Cells[0].Value = dtrent.Rows[y]["id"].ToString();
                              
                                dataGridView1.Rows[counter].Cells[2].Value = dtrent.Rows[y]["n"].ToString();
                                dataGridView1.Rows[counter].Cells[3].Value = dtrent.Rows[y]["pone"].ToString();
                                dataGridView1.Rows[counter].Cells[4].Value = dtrent.Rows[y]["mone"].ToString();
                                dataGridView1.Rows[counter].Cells[5].Value = dtrent.Rows[y]["ptwo"].ToString();
                                //dataGridView1.Rows[counter].Cells[6].Value = dtrent.Rows[y]["mtwo"].ToString();
                                dataGridView1.Rows[counter].Cells[7].Value = dtrent.Rows[y]["o"].ToString();
                                dataGridView1.Rows[counter].Cells[8].Value = dtrent.Rows[y]["event"].ToString();
                                if (dtrent.Rows[y]["active"].ToString() == "1")
                                {
                                    dataGridView1.Rows[counter].Cells[9].Value = "اجار";
                                }
                                else
                                {
                                    dataGridView1.Rows[counter].Cells[9].Value = "اجار ارشيف";
                                }
                                counter = counter + 1;
                            }
                        }


                        for (int y = 0; y < dtown.Rows.Count; y++)
                        {
                            if (checkrecored(dtown.Rows[y]["id"].ToString(), "بيع"))
                            {
                                dataGridView1.Rows[counter].Cells[0].Value = dtown.Rows[y]["id"].ToString();
                                
                                dataGridView1.Rows[counter].Cells[2].Value = dtown.Rows[y]["n"].ToString();
                                dataGridView1.Rows[counter].Cells[3].Value = dtown.Rows[y]["pone"].ToString();
                                dataGridView1.Rows[counter].Cells[4].Value = dtown.Rows[y]["mone"].ToString();
                                dataGridView1.Rows[counter].Cells[5].Value = dtown.Rows[y]["ptwo"].ToString();
                                //dataGridView1.Rows[counter].Cells[6].Value = dtown.Rows[y]["mtwo"].ToString();
                                dataGridView1.Rows[counter].Cells[7].Value = dtown.Rows[y]["o"].ToString();
                                dataGridView1.Rows[counter].Cells[8].Value = dtown.Rows[y]["event"].ToString();

                                if (dtown.Rows[y]["active"].ToString() == "1")
                                {
                                    dataGridView1.Rows[counter].Cells[9].Value = "بيع";
                                }
                                else
                                {
                                    dataGridView1.Rows[counter].Cells[9].Value = "بيع ارشيف";
                                }
                                counter = counter + 1;
                            }
                        }


                        for (int u = 0; u < dataGridView1.Rows.Count; u++)
                        {
                            if ((dataGridView1.Rows[u].Cells[0].Value == null))
                            {
                                try
                                {
                                    dataGridView1.Rows[u].Visible = false;
                                }
                                catch
                                {

                                }
                            }
                        }

                    }
                    else
                    {

                        if (!Utils.CheckOtherRecord)
                        {
                            MessageBox.Show("لا يوجد نتائج");
                        }
                        yes = false;
                    }

                    dataGridView1.Refresh();


                }
                else
                {

                    MessageBox.Show("الرجاء ادخال كلمة البحث");
                    yes = false;
                }


            }

        }
        private void loadWithDach(string pvalue)
        {


            string phonequery = "SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o , phoneEvent.Event as event FROM (phone LEFT OUTER JOIN phoneEvent ON phoneEvent.PhoneID = phone.ID) WHERE";

            string realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event ,Realstate.active as active FROM ( RealState left OUTER JOIN Event ON Event.RealStateID=RealState.ID )  where ";
            string realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM ( RealstateOwne left OUTER JOIN eventown eventown ON eventown.RealStateID = RealstateOwne.ID  ) where ";

            string careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on career.id=careerEvent.careerID where ";


            string[] prameter = pvalue.Split('-');
            if (prameter.Length > 1)
            {
                foreach (string value in prameter)
                {

                    if (value != "" && value != null)
                    {



                        string trimed = value.Trim();

                        string Hmza = value.Trim().Replace("أ", "ا");
                        phonequery += " ( phone.Name like '%" + Hmza + "%' or ";
                        trimed = Hmza.Trim().Replace("ه", "ة");
                        phonequery += " phone.Name like '%" + trimed + "%' or ";
                        trimed = Hmza.Trim().Replace("ة", "ه");
                        phonequery += " phone.Name like '%" + trimed + "%' or ";
                        trimed = Hmza.Trim().Replace("ي", "ى");
                        phonequery += " phone.Name like '%" + trimed + "%' or ";
                        trimed = Hmza.Trim().Replace("ى", "ي");
                        phonequery += " phone.Name like '%" + trimed + "%' or ";
                        trimed = Hmza.Trim().Replace("ا", "ه");
                        phonequery += " phone.Name like '%" + trimed + "%' or ";
                        trimed = Hmza.Trim().Replace("ه", "ا");
                        phonequery += " phone.Name like '%" + trimed + "%' ) and ";


                        string Alftriemd = value.Trim().Replace("ا", "أ");
                        phonequery += " ( phone.Name like '%" + Alftriemd + "%' or ";
                        trimed = Alftriemd.Trim().Replace("ه", "ة");
                        phonequery += " phone.Name like '%" + trimed + "%' or ";
                        trimed = Alftriemd.Trim().Replace("ة", "ه");
                        phonequery += " phone.Name like '%" + trimed + "%' or ";
                        trimed = Alftriemd.Trim().Replace("ي", "ى");
                        phonequery += " phone.Name like '%" + trimed + "%' or ";
                        trimed = Alftriemd.Trim().Replace("ى", "ي");
                        phonequery += " phone.Name like '%" + trimed + "%' or ";
                        trimed = Alftriemd.Trim().Replace("ا", "ه");
                        phonequery += " phone.Name like '%" + trimed + "%' or ";
                        trimed = Alftriemd.Trim().Replace("ه", "ا");
                        phonequery += " phone.Name like '%" + trimed + "%' ) and ";

                        phonequery += "( (phone.Name like '%" + value + "%') or (phoneEvent.Event like '%" + value + "%') or (phone.p1 like '%" + value + "%') or (phone.p2 like '%" + value + "%') or " +
                        " (phone.m2 like '%" + value + "%') or (phone.m3 like '%" + value + "%') or (phone.other like '%" + value + "%') or (phone.notes like '%" + value + "%')  ) and ";

                        /////////////////////////////////////////////////////////////////////////////////////

                        DSTables.DSregionTableAdapters.RegionTableAdapter RegionTableAdapter = new DSTables.DSregionTableAdapters.RegionTableAdapter();
                        DataTable dt = new DataTable();

                        dt = RegionTableAdapter.GetId(value);
                        int regionid = 0;
                        if (dt.Rows.Count > 0)
                        {
                            regionid = Convert.ToInt32(dt.Rows[0]["ID"]);

                        }
                        string ReHmza = value.Trim().Replace("أ", "ا");
                        realrentquesry += "( RealState.Owner like '%" + ReHmza + "%' or ";
                        trimed = ReHmza.Trim().Replace("ه", "ة");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                        trimed = ReHmza.Trim().Replace("ة", "ه");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                        trimed = ReHmza.Trim().Replace("ي", "ى");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                        trimed = ReHmza.Trim().Replace("ى", "ي");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                        trimed = ReHmza.Trim().Replace("ا", "ه");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                        trimed = ReHmza.Trim().Replace("ه", "ا");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' ) and ";


                        string ReAlftriemd = value.Trim().Replace("ا", "أ");
                        realrentquesry += "( RealState.Owner like '%" + ReAlftriemd + "%' or ";
                        trimed = ReAlftriemd.Trim().Replace("ه", "ة");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                        trimed = ReAlftriemd.Trim().Replace("ة", "ه");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                        trimed = ReAlftriemd.Trim().Replace("ي", "ى");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                        trimed = ReAlftriemd.Trim().Replace("ى", "ي");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                        trimed = ReAlftriemd.Trim().Replace("ا", "ه");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' or ";
                        trimed = ReAlftriemd.Trim().Replace("ه", "ا");
                        realrentquesry += " RealState.Owner like '%" + trimed + "%' ) and ";


                        realrentquesry += " ( (RealState.Region_ID = " + regionid + ") or (RealState.SubResgionID LIKE '%" + value + "%') or (RealState.Building LIKE '%" + value + "%') or (RealState.FloorComment LIKE '%" + value + "%') or (RealState.Entrance LIKE '%" + value + "%') or " +
                                          " (RealState.Distance LIKE '%" + value + "%') or (RealState.Owner LIKE '%" + value + "%') or (RealState.Phone_one LIKE '%" + value + "%') or " +
                                          " (RealState.Phone_Two LIKE '%" + value + "%') or (RealState.Mobile LIKE '%" + value + "%') or (RealState.Other LIKE '%" + value + "%') or " +
                                          " (Realstate.Mobile2 LIKE '%" + value + "%') or " +
                                          " (RealState.[Note] LIKE '%" + value + "%') or (RealState.Info_Source LIKE '%" + value + "%') or " +
                                          " (Event.Event LIKE '%" + value + "%') ) and ";

                        /////////////////////////////////////////////////////////////////////////////

                        string ReoHmza = value.Trim().Replace("أ", "ا");
                        realownquesry += " ( RealstateOwne.Owner like '%" + ReoHmza + "%' or ";
                        trimed = ReoHmza.Trim().Replace("ه", "ة");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                        trimed = ReoHmza.Trim().Replace("ة", "ه");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                        trimed = ReoHmza.Trim().Replace("ي", "ى");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                        trimed = ReoHmza.Trim().Replace("ى", "ي");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                        trimed = ReoHmza.Trim().Replace("ا", "ه");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                        trimed = ReoHmza.Trim().Replace("ه", "ا");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' ) and ";


                        string ReoAlftriemd = value.Trim().Replace("ا", "أ");
                        realownquesry += "  ( RealstateOwne.Owner like '%" + ReoAlftriemd + "%' or ";
                        trimed = ReoAlftriemd.Trim().Replace("ه", "ة");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                        trimed = ReoAlftriemd.Trim().Replace("ة", "ه");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                        trimed = ReoAlftriemd.Trim().Replace("ي", "ى");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                        trimed = ReoAlftriemd.Trim().Replace("ى", "ي");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                        trimed = ReoAlftriemd.Trim().Replace("ا", "ه");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' or ";
                        trimed = ReoAlftriemd.Trim().Replace("ه", "ا");
                        realownquesry += " RealstateOwne.Owner like '%" + trimed + "%' ) and ";


                        realownquesry += "( (RealstateOwne.Region_ID LIKE '%" + value + "%') or (RealstateOwne.SubResgionID LIKE '%" + value + "%') or (RealstateOwne.Building LIKE '%" + value + "%') or (RealstateOwne.FloorComment LIKE '%" + value + "%') or (RealstateOwne.Entrance LIKE '%" + value + "%') or " +
                         " (RealstateOwne.Distance LIKE '%" + value + "%') or (RealstateOwne.Owner LIKE '%" + value + "%') or (RealstateOwne.Phone_one LIKE '%" + value + "%') or " +
                         " (RealstateOwne.Phone_Two LIKE '%" + value + "%') or (RealstateOwne.Mobile LIKE '%" + value + "%') or (RealstateOwne.Other LIKE '%" + value + "%') or " +
                         " (RealstateOwne.Mobile2 LIKE '%" + value + "%') or " +
                         " (RealstateOwne.[Note] LIKE '%" + value + "%') or (RealstateOwne.Info_Source LIKE '%" + value + "%') or " +
                         " (eventown.Event LIKE '%" + value + "%') ) and ";

                        ///////////////////////////////////////////////////////////////////////////////////

                        string CarHmza = value.Trim().Replace("أ", "ا");
                        careerquery += "( career.Name like '%" + CarHmza + "%' or ";
                        trimed = CarHmza.Trim().Replace("ه", "ة");
                        careerquery += " career.Name like '%" + trimed + "%' or ";
                        trimed = CarHmza.Trim().Replace("ة", "ه");
                        careerquery += " career.Name like '%" + trimed + "%' or ";
                        trimed = CarHmza.Trim().Replace("ي", "ى");
                        careerquery += " career.Name like '%" + trimed + "%' or ";
                        trimed = CarHmza.Trim().Replace("ى", "ي");
                        careerquery += " career.Name like '%" + trimed + "%' or ";
                        trimed = CarHmza.Trim().Replace("ا", "ه");
                        careerquery += " career.Name like '%" + trimed + "%' or ";
                        trimed = CarHmza.Trim().Replace("ه", "ا");
                        careerquery += " career.Name like '%" + trimed + "%' ) and ";


                        string CarAlftriemd = value.Trim().Replace("ا", "أ");
                        careerquery += " ( career.Name like '%" + CarAlftriemd + "%' or ";
                        trimed = CarAlftriemd.Trim().Replace("ه", "ة");
                        careerquery += " career.Name like '%" + trimed + "%' or ";
                        trimed = CarAlftriemd.Trim().Replace("ة", "ه");
                        careerquery += " career.Name like '%" + trimed + "%' or ";
                        trimed = CarAlftriemd.Trim().Replace("ي", "ى");
                        careerquery += " career.Name like '%" + trimed + "%' or ";
                        trimed = CarAlftriemd.Trim().Replace("ى", "ي");
                        careerquery += " career.Name like '%" + trimed + "%' or ";
                        trimed = CarAlftriemd.Trim().Replace("ا", "ه");
                        careerquery += " career.Name like '%" + trimed + "%' or ";
                        trimed = CarAlftriemd.Trim().Replace("ه", "ا");
                        careerquery += " career.Name like '%" + trimed + "%' ) and ";

                        careerquery += " ((career.Name LIKE '%" + value + "%') or " +
                      " (career.careertype LIKE '%" + value + "%') or " +
                      " (career.p LIKE '%" + value + "%') or " +
                      " (career.m LIKE '%" + value + "%') or " +
                      " (career.other LIKE '%" + value + "%') or " +
                      " (career.notes LIKE '%" + value + "%') or " +
                      " (career.category LIKE '%" + value + "%') or " +
                      "  (careerEvent.event LIKE '%" + value + "%')  ) and ";


                    }
                }
            }

            if (phonequery != "SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o , phoneEvent.Event as event FROM Phone left JOIN phoneEvent phoneEvent ON Phone.ID = phoneEvent.PhoneID where ")
            {
                dtphone = get(phonequery.Substring(0, phonequery.LastIndexOf("and")));
            }
            if (realrentquesry != "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Event.Event as event ,Realstate.active as active FROM RealState left JOIN Event ON RealState.ID = Event.RealStateID where ")
            {
                dtrent = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("and")));
            }
            if (realownquesry != "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , eventown.Event as event ,RealstateOwne.active as active FROM RealstateOwne left JOIN eventown eventown ON RealstateOwne.ID = eventown.RealStateID where ")
            {
                dtown = get(realownquesry.Substring(0, realownquesry.LastIndexOf("and")));
            }

            if (careerquery != "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o ,careerEvent.Event as event FROM career left join careerEvent careerEvent on career.id=careerEvent.careerID where ")
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
                dataGridView1.Rows.Add(odt.Rows.Count);
                for (int y = 0; y < dtphone.Rows.Count; y++)
                {
                    if (checkrecored(dtphone.Rows[y]["id"].ToString(), "الهاتف"))
                    {
                        dataGridView1.Rows[counter].Cells[0].Value = dtphone.Rows[y]["id"].ToString();

                        dataGridView1.Rows[counter].Cells[2].Value = dtphone.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtphone.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtphone.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtphone.Rows[y]["ptwo"].ToString();
                        dataGridView1.Rows[counter].Cells[6].Value = dtphone.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtphone.Rows[y]["o"].ToString();
                        dataGridView1.Rows[counter].Cells[8].Value = dtphone.Rows[y]["event"].ToString();
                        dataGridView1.Rows[counter].Cells[9].Value = "الهاتف";

                        counter = counter + 1;
                    }
                }


                for (int y = 0; y < dtcareer.Rows.Count; y++)
                {

                    if (checkrecored(dtcareer.Rows[y]["id"].ToString(), "مهن"))
                    {
                        dataGridView1.Rows[counter].Cells[0].Value = dtcareer.Rows[y]["id"].ToString();

                        dataGridView1.Rows[counter].Cells[2].Value = dtcareer.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtcareer.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtcareer.Rows[y]["mone"].ToString();
                        //dataGridView1.Rows[counter].Cells[5].Value = dtcareer.Rows[y]["ptwo"].ToString();
                        //dataGridView1.Rows[counter].Cells[6].Value = dtcareer.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtcareer.Rows[y]["o"].ToString();
                        dataGridView1.Rows[counter].Cells[8].Value = dtcareer.Rows[y]["event"].ToString();
                        dataGridView1.Rows[counter].Cells[9].Value = "مهن";

                        counter = counter + 1;

                    }
                }

                for (int y = 0; y < dtrent.Rows.Count; y++)
                {
                    if (checkrecored(dtrent.Rows[y]["id"].ToString(), "اجار"))
                    {
                        dataGridView1.Rows[counter].Cells[0].Value = dtrent.Rows[y]["id"].ToString();

                        dataGridView1.Rows[counter].Cells[2].Value = dtrent.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtrent.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtrent.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtrent.Rows[y]["ptwo"].ToString();
                        //dataGridView1.Rows[counter].Cells[6].Value = dtrent.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtrent.Rows[y]["o"].ToString();
                        dataGridView1.Rows[counter].Cells[8].Value = dtrent.Rows[y]["event"].ToString();
                        if (dtrent.Rows[y]["active"].ToString() == "1")
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "اجار";
                        }
                        else
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "اجار ارشيف";
                        }
                        counter = counter + 1;
                    }
                }


                for (int y = 0; y < dtown.Rows.Count; y++)
                {
                    if (checkrecored(dtown.Rows[y]["id"].ToString(), "بيع"))
                    {
                        dataGridView1.Rows[counter].Cells[0].Value = dtown.Rows[y]["id"].ToString();

                        dataGridView1.Rows[counter].Cells[2].Value = dtown.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtown.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtown.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtown.Rows[y]["ptwo"].ToString();
                        //dataGridView1.Rows[counter].Cells[6].Value = dtown.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtown.Rows[y]["o"].ToString();
                        dataGridView1.Rows[counter].Cells[8].Value = dtown.Rows[y]["event"].ToString();

                        if (dtown.Rows[y]["active"].ToString() == "1")
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "بيع";
                        }
                        else
                        {
                            dataGridView1.Rows[counter].Cells[9].Value = "بيع ارشيف";
                        }
                        counter = counter + 1;
                    }
                }


                for (int u = 0; u < dataGridView1.Rows.Count; u++)
                {
                    if ((dataGridView1.Rows[u].Cells[0].Value == null))
                    {
                        try
                        {
                            dataGridView1.Rows[u].Visible = false;
                        }
                        catch
                        {

                        }
                    }
                }

            }
            else
            {

                if (!Utils.CheckOtherRecord)
                {
                    MessageBox.Show("لا يوجد نتائج");
                }
                yes = false;
            }

            dataGridView1.Refresh();


        }
        //        else
        //        {

        //            MessageBox.Show("الرجاء ادخال كلمة البحث");
        //            yes = false;
        //        }

        //    }
        //}
        // }

        public Boolean checkrecored(string id, string type)
        {
            //ResGridView.Rows[

            for (int u = 0; u < dataGridView1.Rows.Count; u++)
            {
                if ((Convert.ToInt32(dataGridView1.Rows[u].Cells[0].Value) == Convert.ToInt32(id)) && (dataGridView1.Rows[u].Cells[9].Value == type))
                {
                    return false;
                }
            }
            return true;


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

                if (e.ColumnIndex == 1)
                {


                    if (dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "اجار" || dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "اجار ارشيف")
                    {
                        rent.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString());
                        rent.am = "Search";
                        rent.Text = "بحث";
                        rent.ShowDialog();
                        //ShowModalExcept(rent, MainForm.searchForm);


                        this.RealStateTableAdaptersearch.UpdateQuery(DateTime.Now.Date, Convert.ToInt32(Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString())));
                        if (rent.back == "back")
                        {
                            alwaysback = "back";
                            this.Close();
                        }
                    }
                    else if (dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "بيع" || dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "بيع ارشيف")
                    {
                        own.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString());
                        own.am = "Search";
                        own.Text = "بحث";
                        own.ShowDialog();
                        //ShowModalExcept(own, MainForm.searchForm);

                        this.realStateTableAdapter.UpdateQuery(DateTime.Now.Date, Convert.ToInt32(Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString())));

                        if (own.back == "back")
                        {
                            alwaysback = "back";
                            this.Close();
                        }
                    }
                    else if (dataGridView1.CurrentCell.OwningRow.Cells[9].Value.ToString() == "الهاتف")
                    {
                        phone.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString());
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

                        car.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString());
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



        private void Form1_Load(object sender, EventArgs e)
        {
        }





        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {

                if (keyData == Keys.Escape)
                {
                    //MainForm.textBox1.Text = "";
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

    }
}
