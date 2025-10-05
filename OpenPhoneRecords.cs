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
    public partial class OpenPhoneRecords : Form
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
        string name,number,eventtext;
        string type;
        public string alwaysback;
        
        public Boolean yes=true;
        public Boolean Eventyes = true;

            string [] realid;
            string [] phoneid;
            string []  ownid;
            string [] careerid;

            string phonequery = "";
            string realrentquesry = "";
            string realownquesry = "";
            string careerquery = "";

            //realid, ownid, careerid, phoneid
        public OpenPhoneRecords(string prealid, string   pownid,string pcareerid,string pphoneid)
        {

            InitializeComponent();

            exact(prealid, pownid, pcareerid, pphoneid);
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

   
        private void exact(string prealid, string   pownid,string pcareerid,string pphoneid)
        {


                    phonequery = " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o FROM  Phone where ";
                    realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Realstate.active as active FROM RealState where ";
                    realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , RealstateOwne.active as active FROM  RealstateOwne where ";
                    careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o FROM career  where ";

            

            realid = prealid.Split(',');
            phoneid = pphoneid.Split(',');
            ownid = pownid.Split(',');
            careerid = pcareerid.Split(',');

            if (realid.Length > 0)
            {
                for (int t = 0; t < realid.Length; t++)
                {
                    if (realid[t] != "")
                        realrentquesry += " id=" + realid[t] + " or ";

                }

            }

            if (ownid.Length > 0)
            {
                for (int t = 0; t < ownid.Length; t++)
                {
                    if (ownid[t] != "")
                        realownquesry += " id=" + ownid[t] + " or ";

                }

            }


            if (careerid.Length > 0)
            {
                for (int t = 0; t < careerid.Length; t++)
                {
                    if (careerid[t] != "")
                        careerquery += " id=" + careerid[t] + " or ";

                }

            }


            

            
            if(phoneid.Length>0)
            {
              for(int t=0;t<phoneid.Length;t++)
               {

                  if(phoneid[t]!="")
                     phonequery+=" id="+phoneid[t] +" or ";

                }

            }
    if (phonequery != " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o FROM  Phone where ")
                {
                    dtphone = get(phonequery.Substring(0, phonequery.LastIndexOf("or")));
                }
                if (realrentquesry != "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Realstate.active as active FROM RealState where ")
                {
                    dtrent = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("or")));
                }
                if (realownquesry != "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , RealstateOwne.active as active FROM  RealstateOwne where ")
                {
                    dtown = get(realownquesry.Substring(0, realownquesry.LastIndexOf("or")));
                }

                if (careerquery != "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o FROM career  where ")
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

                        dataGridView1.Rows[counter].Cells[0].Value = dtphone.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[2].Value = dtphone.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtphone.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtphone.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtphone.Rows[y]["ptwo"].ToString();
                        dataGridView1.Rows[counter].Cells[6].Value = dtphone.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtphone.Rows[y]["o"].ToString();
                        dataGridView1.Rows[counter].Cells[9].Value = "الهاتف";
                        counter = counter + 1;
                    }

                    for (int y = 0; y < dtcareer.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[0].Value = dtcareer.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[2].Value = dtcareer.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtcareer.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtcareer.Rows[y]["mone"].ToString();
                        //dataGridView1.Rows[counter].Cells[5].Value = dtcareer.Rows[y]["ptwo"].ToString();
                        //dataGridView1.Rows[counter].Cells[6].Value = dtcareer.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtcareer.Rows[y]["o"].ToString();
                        dataGridView1.Rows[counter].Cells[9].Value = "مهن";

                        counter = counter + 1;
                    }
                    for (int y = 0; y < dtrent.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[0].Value = dtrent.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[2].Value = dtrent.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtrent.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtrent.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtrent.Rows[y]["ptwo"].ToString();
                        //dataGridView1.Rows[counter].Cells[6].Value = dtrent.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtrent.Rows[y]["o"].ToString();
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


                    for (int y = 0; y < dtown.Rows.Count; y++)
                    {

                        dataGridView1.Rows[counter].Cells[0].Value = dtown.Rows[y]["id"].ToString();
                        dataGridView1.Rows[counter].Cells[2].Value = dtown.Rows[y]["n"].ToString();
                        dataGridView1.Rows[counter].Cells[3].Value = dtown.Rows[y]["pone"].ToString();
                        dataGridView1.Rows[counter].Cells[4].Value = dtown.Rows[y]["mone"].ToString();
                        dataGridView1.Rows[counter].Cells[5].Value = dtown.Rows[y]["ptwo"].ToString();
                        // dataGridView1.Rows[counter].Cells[6].Value = dtown.Rows[y]["mtwo"].ToString();
                        dataGridView1.Rows[counter].Cells[7].Value = dtown.Rows[y]["o"].ToString();

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
                        this.RealStateTableAdaptersearch.UpdateQuery(DateTime.Now.Date, Convert.ToInt32(Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString())));

                        rent.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString());
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

                        own.recored_id = Convert.ToInt32(dataGridView1.CurrentCell.OwningRow.Cells[0].Value.ToString());
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
