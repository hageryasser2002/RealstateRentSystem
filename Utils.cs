using IWshRuntimeLibrary;
using Microsoft.Win32;
using RealStateRentSystem.DSTables;
using RealStateRentSystem_Buisness;
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
using System.Management;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace RealStateRentSystem
{

    public class Utils
    {

        public static string CustPhon;
        public static string CustMobile;
        public static string CusOther;
        public static Boolean RentRecord = false;
        public static DateTime IncRealtime;
        public static DateTime appdate;
        public static DateTime apptime;
        public static string NameOfCustomer = "";
        public static DataTable DTRealAppointinfo;
        public static SortedList<int, string> SortdDTRealAppointinfo = new SortedList<int, string>();
        /// ////////////////////////////////////////////////
        public static string OCustPhon;
        public static string OCustMobile;
        public static string OCusOther;
        public static Boolean ORentRecord = false;
        public static DateTime OIncRealtime;
        public static DateTime Oappdate;
        public static DateTime Oapptime;
        public static string ONameOfCustomer = "";
        public static DataTable ODTRealAppointinfo;
        public static SortedList<int, string> OSortdDTRealAppointinfo = new SortedList<int, string>();
        /// ////////////////////////////////////////////////
        public static string CallName;
        public static string CallPlace;
        public static string CallPlaceID;
        /// ////////////////////////////////////////////////

        public static Boolean EncryptMode = false;

        public static string currentRealstateId;

        public static string current_user;
        public static string current_color;
        public static bool IsAdmin= false;

        public static List<clsUser> cachedUsers = new List<clsUser>();

        
        public static string whichfield;
        private static WshShellClass WshShell;
        /////////////////
        public static int RemainderingDays;
        public static int RemainderingPeriod;
        public static int RemainderingPeriodEmpty;
        public static DateTime BackUpTime;
        public static DateTime LastStaticAccess;
        public static DateTime RealLastStaticAccess;
        public static string BackUpPath;
        public static string BackUpName;
        public static string ProjectName;
        public static bool HasModem;
        public static int realstateid;
        public static int realstateidowner;
        public static int PhoneID;
        public static int CareerID;
        public static string DataFolderPath;
        ///////////////////////////////////
        public static int EnterPeriodToStaic;
        public static int EnterPeriodOwnerToHouses;
        public static int EnterPeriodOwnerToEvents;

        ///////////////////////////////////
        public static int EnterPeriodRentToHouses;
        public static int EnterPeriodRentToEvents;

        public static Modem mode;
        /////////////////

        //public static DateTime CallsBackArchiveone = Convert.ToDateTime("9/21/2010 01:00:00 am");
        // public static DateTime CallsBackArchivetwo = Convert.ToDateTime("9/21/2010 05:00:00 PM");

        public static DateTime CallsBackArchiveone = DateTime.Today.AddHours(01);
        public static DateTime CallsBackArchivetwo = DateTime.Today.AddHours(17);

        /////////////////

        public static DateTime SBackUpTime;
        public static string SBackUpPath;
        ///////////////////////////
        public static string OSVersion;
        public static string Version;
        public static Boolean alert = true;
        public static Boolean backup = true;


        public static int PhoneNumerLength;
        public static int MobileNumerLength;
        public static string Portname;


        public static string CurrentTabName = "";
        public static bool CheckOtherRecord = false;
        ////////////////////
        public static DSTables.DSCallsTableAdapters.CallsRegistrayTableAdapter CallsRegistrayTableAdapter = new DSTables.DSCallsTableAdapters.CallsRegistrayTableAdapter();
        public static DSTables.DSCallsTableAdapters.ArchiveCallRegistrayTableAdapter ArchiveCallRegistrayTableAdapter = new DSTables.DSCallsTableAdapters.ArchiveCallRegistrayTableAdapter();

        private static DSTables.DSsettingTableAdapters.SettingTableAdapter settingTableAdapter = new DSTables.DSsettingTableAdapters.SettingTableAdapter();
        private static DSTables.DSsettingTableAdapters.PCinfoTableAdapter PCinfoTableAdapter = new DSTables.DSsettingTableAdapters.PCinfoTableAdapter();

        private static DSTables.DSrealstateTableAdapters.RealStateTableAdapter RealStateTableAdapter = new DSTables.DSrealstateTableAdapters.RealStateTableAdapter();
        private static DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter RealStateTableAdaptersearch = new DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter();
        private static DSTables.DSrealstateTableAdapters.AttachmentTableAdapter AttachmentTableAdapter = new DSTables.DSrealstateTableAdapters.AttachmentTableAdapter();
        private static DSTables.DSrealstateTableAdapters.EventTableAdapter EventTableAdapter = new DSTables.DSrealstateTableAdapters.EventTableAdapter();
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();


        /// /////////////////////////////////////////////////////////////////

        private static DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter RealStateTableAdaptersearchown = new DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter();
        private static DSTables.DSrealownerTableAdapters.attachmentOwnTableAdapter AttachmentTableAdapterOwn = new DSTables.DSrealownerTableAdapters.attachmentOwnTableAdapter();
        private static DSTables.DSrealownerTableAdapters.eventownTableAdapter EventTableAdapterOwn = new DSTables.DSrealownerTableAdapters.eventownTableAdapter();
        private static DSTables.DSsettingTableAdapters.StaticTableAdapter StaticTableAdapter = new DSTables.DSsettingTableAdapters.StaticTableAdapter();
        private static DSTables.DSsettingTableAdapters.RealStaticTableAdapter RealStaticTableAdapter = new DSTables.DSsettingTableAdapters.RealStaticTableAdapter();
        private static DSTables.DSrealownerTableAdapters.OwnSettingTableAdapter OwnSettingTableAdapter = new DSTables.DSrealownerTableAdapters.OwnSettingTableAdapter();
        private static DSTables.DSrealownerTableAdapters.RealstateOwneTableAdapter RealstateOwneTableAdapter = new DSTables.DSrealownerTableAdapters.RealstateOwneTableAdapter();
        ////////////////////////////////////////////////////////////////////
        private static DSTables.DSphoneSearchTableAdapters.PhoneTableAdapter PhoneTableAdapter = new DSTables.DSphoneSearchTableAdapters.PhoneTableAdapter();
        private static DSTables.DSphoneTableAdapters.PhoneAttachTableAdapter PhoneAttachTableAdapter = new DSTables.DSphoneTableAdapters.PhoneAttachTableAdapter();
        private static DSTables.DSphoneTableAdapters.phoneEventTableAdapter phoneEventTableAdapter = new DSTables.DSphoneTableAdapters.phoneEventTableAdapter();
        /// ////////////////////////////
        private static DSTables.DScareersearchTableAdapters.careerTableAdapter careerTableAdaptersearch = new DSTables.DScareersearchTableAdapters.careerTableAdapter();
        private static DSTables.DScareerTableAdapters.careerAttachTableAdapter careerAttachTableAdapter = new DSTables.DScareerTableAdapters.careerAttachTableAdapter();
        private static DSTables.DScareerTableAdapters.careerEventTableAdapter careerEventTableAdapter = new DSTables.DScareerTableAdapters.careerEventTableAdapter();
        

        public static void CreateDataTableAnswers()
        {
            DTRealAppointinfo = new DataTable();
            DTRealAppointinfo.Columns.Add("RealID", typeof(int));
            DTRealAppointinfo.Columns.Add("apppointdate", typeof(DateTime));
            //DTRealAppointinfo .Columns.Add("apppointTime", typeof(DateTime));


            ODTRealAppointinfo = new DataTable();
            ODTRealAppointinfo.Columns.Add("RealID", typeof(int));
            ODTRealAppointinfo.Columns.Add("apppointdate", typeof(DateTime));
            //ODTRealAppointinfo.Columns.Add("apppointTime", typeof(DateTime));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public static int LastInsertedId(OleDbConnection conn, OleDbTransaction transaction)
        {
            using (var cmd = new OleDbCommand("SELECT @@IDENTITY", conn, transaction))
            {
                object result = cmd.ExecuteScalar();
                return (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
            }
        }

        public static int LastID()
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT max(id) as MID FROM RealState ";
            OleDbConnection conn = new OleDbConnection(serverConnectionString);

            try
            {
                conn.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
                conn.Dispose();
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt16(dt.Rows[0]["MID"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;

            }

            finally
            {


                conn.Close();
                conn.Dispose();
            }


        }
        public static int LastIDApp()
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT max(id) as MID FROM AppointmentsNumbers ";
            OleDbConnection conn = new OleDbConnection(serverConnectionString);

            try
            {

                conn.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
                conn.Dispose();
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    return (Convert.ToInt32(dt.Rows[0]["MID"]));
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;

            }

            finally
            {


                conn.Close();
                conn.Dispose();
            }


        }

        public static int LastIDCustoApp()
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT max(id) as MID FROM Customer_appointment ";
            OleDbConnection conn = new OleDbConnection(serverConnectionString);

            try
            {

                conn.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
                conn.Dispose();
                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt16(dt.Rows[0]["MID"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;

            }

            finally
            {


                conn.Close();
                conn.Dispose();
            }


        }

        public static int LastIDOwn()
        {


            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            string SqlStatement = "SELECT max(id) as MID FROM RealstateOwne ";

            try
            {

                conn.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
                conn.Dispose();
                conn.Close();
                if (dt.Rows.Count > 0)
                    return Convert.ToInt16(dt.Rows[0]["MID"].ToString());
                else
                    return 0;
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {


                conn.Close();
                conn.Dispose();
            }
        }
        public static int LastIDCall()
        {


            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            string SqlStatement = "SELECT max(id) as MID FROM CallsRegistray ";

            try
            {

                conn.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
                conn.Dispose();
                conn.Close();
                if (dt.Rows.Count > 0)
                    return Convert.ToInt16(dt.Rows[0]["MID"].ToString());
                else
                    return 0;
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {


                conn.Close();
                conn.Dispose();
            }
        }
        public static DataTable Check(string name, string pass)
        {

            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "";
            OleDbConnection conn = new OleDbConnection(serverConnectionString);

            try
            {

                conn.Open();
                //OleDbDataAdapter
                OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sda.Dispose();
                conn.Dispose();
                conn.Close();
                //foreach (DataRow dr in dt.Rows)
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    return dt;
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {


                conn.Close();
                conn.Dispose();
            }

        }

        public static void SetDataFolderPath(string path)
        {
            DataTable dt = new DataTable();
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            try
            {
                string SqlStatementUpdate = "";
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                OleDbTransaction Tran;
                Tran = conn.BeginTransaction();

                SqlStatementUpdate = "UPDATE Setting SET DataFolderPath ='" + path + "'";
                cmd = new OleDbCommand(SqlStatementUpdate, conn);
                cmd.Transaction = Tran;
                cmd.ExecuteNonQuery();
                Tran.Commit();
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {

                conn.Close();
                conn.Dispose();

            }
        }
        //public static string GetDataFolderPath()
        //{
        //    DataTable dt = new DataTable();
        //    dt = settingTableAdapter.GetData();
        //    return dt.Rows[0]["DataFolderPath"].ToString();
        //}
        public static void getsetting()
        {
            DataTable dt = new DataTable();
            dt = settingTableAdapter.GetData();

            if (dt.Rows.Count > 0)
            {
                RemainderingDays = Convert.ToInt16(dt.Rows[0]["RemainderingDays"].ToString());
                RemainderingPeriod = Convert.ToInt16(dt.Rows[0]["RemainderingPeriod"].ToString());
                RemainderingPeriodEmpty = Convert.ToInt16(dt.Rows[0]["RemainderingPeriodEmpty"].ToString());
                BackUpTime = Convert.ToDateTime(dt.Rows[0]["BackUpTime"].ToString());
                BackUpPath = dt.Rows[0]["BackUpPath"].ToString();
                BackUpName = dt.Rows[0]["BackUpName"].ToString();
                SBackUpPath = dt.Rows[0]["SBackUpPath"].ToString();
                SBackUpTime = Convert.ToDateTime(dt.Rows[0]["SBackUpTime"].ToString());

                PhoneNumerLength = Convert.ToInt16(dt.Rows[0]["PhoneNumerLength"].ToString());
                MobileNumerLength = Convert.ToInt16(dt.Rows[0]["MobileNumerLength"].ToString());
                Portname = dt.Rows[0]["Portname"].ToString();
                DataFolderPath = dt.Rows[0]["DataFolderPath"].ToString();
               // HasModem = Convert.ToBoolean(dt.Rows[0]["HasModem"]);
                HasModem = clsDeviceSettings.HasModem();


            }


            DataTable dts = new DataTable();
            dts = StaticTableAdapter.GetData();

            if (dts.Rows.Count > 0)
            {
                LastStaticAccess = Convert.ToDateTime(dts.Rows[0]["AccessDate"].ToString()).Date;

            }

            DataTable rdts = new DataTable();
            rdts = RealStaticTableAdapter.GetData();

            if (rdts.Rows.Count > 0)
            {
                RealLastStaticAccess = Convert.ToDateTime(rdts.Rows[0]["AccessDate"].ToString()).Date;

            }

            DataTable owsetting = new DataTable();
            owsetting = OwnSettingTableAdapter.GetData();

            if (owsetting.Rows.Count > 0)
            {
                EnterPeriodToStaic = Convert.ToInt16(owsetting.Rows[0]["EnterPeriodToStaic"].ToString());
                EnterPeriodOwnerToHouses = Convert.ToInt16(owsetting.Rows[0]["EnterPeriodToHouses"].ToString());
                EnterPeriodOwnerToEvents = Convert.ToInt16(owsetting.Rows[0]["EnterPeriodToEvents"].ToString());
            }

            if (owsetting.Rows.Count > 1)
            {

                EnterPeriodRentToHouses = Convert.ToInt16(owsetting.Rows[1]["EnterPeriodToHouses"].ToString());
                EnterPeriodRentToEvents = Convert.ToInt16(owsetting.Rows[1]["EnterPeriodToEvents"].ToString());
            }

            DataTable pcinfo = new DataTable();
            pcinfo = PCinfoTableAdapter.GetDataByexist(Utils.macaddreass);
            if (pcinfo.Rows.Count > 0)
            {
                alert = Convert.ToBoolean(pcinfo.Rows[0]["alert"].ToString());
                backup = Convert.ToBoolean(pcinfo.Rows[0]["backup"].ToString());
            }

        }
     
        public static void update_auto()
        {


            DataTable dt = new DataTable();
            dt = RealStateTableAdapter.GetAuto();
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            try
            {


                string SqlStatementUpdate = "";
                conn.Open();
                if (dt.Rows.Count > 0)
                {

                    for (int y = 0; y < dt.Rows.Count; y++)
                    {

                        if (dt.Rows[y]["Status_ID"].ToString() == "2")
                        {
                            OleDbCommand cmd = new OleDbCommand();
                            cmd.Connection = conn;
                            OleDbTransaction Tran;
                            Tran = conn.BeginTransaction();

                            SqlStatementUpdate = "UPDATE RealState SET RemainingDay =0, StartRentDate ='" + DateTime.Now.Date + "', EndRendDate ='" + DateTime.Now.Date + "' WHERE (ID = " + dt.Rows[y]["ID"] + ")";
                            cmd = new OleDbCommand(SqlStatementUpdate, conn);
                            cmd.Transaction = Tran;
                            cmd.ExecuteNonQuery();
                            Tran.Commit();

                        }//end if
                        else if (dt.Rows[y]["Status_ID"].ToString() == "1")
                        {


                            OleDbCommand cmd = new OleDbCommand();
                            cmd.Connection = conn;
                            OleDbTransaction Tran;
                            Tran = conn.BeginTransaction();

                            int days = GetDates.DateDiffDays(DateTime.Now.Date, Convert.ToDateTime(dt.Rows[y]["EndRendDate"].ToString()).Date);
                            SqlStatementUpdate = "UPDATE RealState SET RemainingDay =" + days + ", StartRentDate ='" + Convert.ToDateTime(dt.Rows[y]["StartRentDate"].ToString()).Date + "', EndRendDate ='" + Convert.ToDateTime(dt.Rows[y]["EndRendDate"].ToString()).Date + "' WHERE (ID = " + dt.Rows[y]["ID"] + ")";
                            cmd = new OleDbCommand(SqlStatementUpdate, conn);
                            cmd.Transaction = Tran;
                            cmd.ExecuteNonQuery();
                            Tran.Commit();

                        }

                    }//end of for

                    conn.Close();
                    conn.Dispose();

                }// end if row count

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {

                conn.Close();
                conn.Dispose();

            }




        }

        public static void update_auto_calls()
        {
            DataTable dt = new DataTable();

            //DateTime det = DateTime.Now;

            //string mon =det.AddMonths(-1).Month.ToString();
            //string day = det.Day.ToString();
            //string year = det.Year.ToString();
            //string query = " select ID, [number], [date], name, place, placeID, numbertype, [note], [time] FROM CallsRegistray WHERE ([date] <=#" + mon + "/" + day + "/" + year + "#)";
            //dt = get(query);
            dt = CallsRegistrayTableAdapter.GetDataAuto(DateTime.Now.AddMonths(-1));
            try
            {
                if (dt.Rows.Count > 0)
                {

                    for (int y = 0; y < dt.Rows.Count; y++)
                    {

                        ArchiveCallRegistrayTableAdapter.Insert(
                            dt.Rows[y]["number"].ToString(),
                            Convert.ToDateTime(dt.Rows[y]["date"]),
                            dt.Rows[y]["name"].ToString(),
                            dt.Rows[y]["place"].ToString(),
                            dt.Rows[y]["placeID"].ToString(),
                            dt.Rows[y]["numbertype"].ToString(),
                            dt.Rows[y]["note"].ToString(),
                            Convert.ToDateTime(dt.Rows[y]["time"]));

                        CallsRegistrayTableAdapter.DeleteQuery(Convert.ToInt32(dt.Rows[y]["id"]));
                    }//end of for

                }// end if row count

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {

            }






        }

        //public static Boolean CheckCall(DateTime Date, string number)
        //{
        //    DataTable dt = new DataTable();

        //    string query = " select ID, [number], [date], name, place, placeID, numbertype, [note], [time] FROM CallsRegistray WHERE ([date] =#" + string.Format("mm/dd/yyyy", Date) + "# and [number]='" + number + "')";
        //    dt = get(query);
        //    try
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            return false;
        //        }
        //        else
        //        {

        //            return true;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }

        //    return false;






        //}

        public static DataTable get(string SqlStatement)
        {

            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
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
            finally
            {

                conn.Close();
                conn.Dispose();
            }

        }
        public static void deleteattch(int id)
        {

            AttachmentTableAdapter.UpdateQuery(id);
            EventTableAdapter.UpdateQuery(id);
        }

        public static void deleteattchowne(int id)
        {

            AttachmentTableAdapterOwn.UpdateQuery(id);
            EventTableAdapterOwn.UpdateQuery(id);


        }

        public static void copyDirectory(string Src, string Dst)
        {
            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                // Sub directories

                if (Directory.Exists(Element))
                    copyDirectory(Element, Dst + Path.GetFileName(Element));
                // Files in directory

                else
                    System.IO.File.Copy(Element, Dst + Path.GetFileName(Element), true);
            }
        }


        //public static void project(string connetion)
        //{
        //    string DbConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + connetion + ";Jet OLEDB:Database Password=admin;Persist Security Info=False;OLE DB Services=-1;User ID=admin";
        //    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    //ConnectionStringsSection mySection = (ConnectionStringsSection)config.GetSection(global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString);
        //    //config.ConnectionStrings.ConnectionStrings["RealStateRentSystem.Properties.Settings.db1ConnectionString"].ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + connetion + ";Persist Security Info=True;";
        //    config.ConnectionStrings.ConnectionStrings["RealStateRentSystem.Properties.Settings.db1ConnectionString"].ConnectionString = DbConnectionString;
        //    config.Save(ConfigurationSaveMode.Modified);

        //    ConfigurationManager.RefreshSection("connectionStrings");

        //    //Properties.Settings.Default["db1ConnectionString"] = DbConnectionString;
        //    //Properties.Settings.Default.Save();

        //}

        public static void project(string connection)
        {
            // توليد سلسلة الاتصال الجديدة
            string DbConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + connection + ";Jet OLEDB:Database Password=admin;Persist Security Info=False;OLE DB Services=-1;User ID=admin";

            try
            {
                // تحميل ملف الإعدادات الحالي
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // التأكد من وجود سلسلة الاتصال
                var connStr = config.ConnectionStrings.ConnectionStrings["RealStateRentSystem.Properties.Settings.db1ConnectionString"];
                if (connStr != null)
                {
                    connStr.ConnectionString = DbConnectionString;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");
                }
                else
                {
                    MessageBox.Show("سلسلة الاتصال غير موجودة في الإعدادات!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحديث سلسلة الاتصال:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SetPath()

        {
            //Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Documents and Settings\Administrator\My Documents\Visual Studio 2008\Projects\RealStateRentSystem\RealStateRentSystem\bin\Debug\db1.mdb           
            //|DataDirectory|db1.mdb
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ////ConnectionStringsSection mySection = (ConnectionStringsSection)config.GetSection(global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString);
            string gg = config.ConnectionStrings.ConnectionStrings["RealStateRentSystem.Properties.Settings.db1ConnectionString"].ConnectionString;
            //var spl1 = gg.Split(';')[1].Split('=')[1];
            //if (spl1 == "|DataDirectory|"+ DbName)
            //{

            project(CustomPath.GetDBFullPath());

            if (Utils.DataFolderPath == "")
            {
                string dir = Directory.GetCurrentDirectory();
                ProjectName = Directory.GetCurrentDirectory() + "\\attachment";

                SetDataFolderPath(ProjectName);
            }
            else
                ProjectName = Utils.DataFolderPath;


            //}
            //else
            //{
            //    gg=gg.Substring(0,gg.LastIndexOf("\\"));
            //    ProjectName = gg;

            //}
        }

        public static Boolean checkRegion(int id)
        {

            DataTable dt = new DataTable();
            dt = RealStateTableAdapter.GetDataByRegion(id);

            if (dt.Rows[0]["IDS"].ToString() == "0")
                return false;
            else
                return true;

        }

        public static int getRegionID(string name)
        {

            DSTables.DSregionTableAdapters.RegionTableAdapter RegionTableAdapter = new DSTables.DSregionTableAdapters.RegionTableAdapter();
            DataTable dt = new DataTable();

            dt = RegionTableAdapter.GetId(name);


            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["ID"]);

            }
            else
            {
                return 0;
            }
        }

        public static DataTable checkexist(string g, string build, int floor, int id)
        {
            DSrealstatesearch.RealStateDataTable dt = new DSrealstatesearch.RealStateDataTable();
            //  DataTable dt = new DataTable();
            dt = RealStateTableAdaptersearch.GetDataByCheck(build, floor, g, id);

            return dt;

        }

        public static DataTable checkexistPhone(string name, string p1, string p2, string m1, string m2, int id)
        {

            DSphoneSearch.PhoneDataTable dt = new DSphoneSearch.PhoneDataTable();

            string statment = "SELECT ID, Name, dataofchanged, m2, m3, notes, other, p1, p2, [user] FROM Phone WHERE ";

            if (name != "")
            {
                statment += "  (ID <> " + id + " AND  Name='" + name + "') or ";
            }

            if (p1 != "")
            {
                statment += "  ( ( ID <> " + id + " AND p1= '" + p1 + "') or ( ID <> " + id + " AND  p2= '" + p1 + "') or ( ID <> " + id + " AND  m2= '" + p1 + "') or ( ID <> " + id + " AND  m3= '" + p1 + "')) or";
            }

            if (p2 != "")
            {
                statment += "  (( ID <> " + id + " AND p1= '" + p2 + "') or (ID <> " + id + " AND p2= '" + p2 + "') or (ID <> " + id + " AND m2= '" + p2 + "') or (ID <> " + id + " AND m3= '" + p2 + "')) or";
            }
            if (m1 != "")
            {
                statment += " ((ID <> " + id + " AND p1= '" + m1 + "') or (ID <> " + id + " AND p2= '" + m1 + "') or (ID <> " + id + " AND m2= '" + m1 + "') or (ID <> " + id + " AND m3= '" + m1 + "')) or";

            }

            if (m2 != "")
            {
                statment += " ((ID <> " + id + " AND p1= '" + m2 + "') or (ID <> " + id + " AND p2= '" + m2 + "') or (ID <> " + id + " AND m2= '" + m2 + "') or (ID <> " + id + " AND m3= '" + m2 + "') ) or";
            }

            if (statment != "SELECT ID, Name, dataofchanged, m2, m3, notes, other, p1, p2, [user] FROM Phone WHERE ")
            {
                string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
                OleDbConnection conn = new OleDbConnection(serverConnectionString);

                try
                {

                    conn.Open();
                    OleDbDataAdapter sda = new OleDbDataAdapter(statment.Substring(0, statment.LastIndexOf("or")), conn);
                    sda.Fill(dt);
                    sda.Dispose();
                    conn.Dispose();
                    conn.Close();

                }
                catch (Exception)
                {
                    throw;

                }
                finally
                {

                    conn.Close();
                    conn.Dispose();
                }
            }

            return dt;
        }


        public static DataTable checkexistOwner(string g, string build, int floor, int id)
        {

            DSrealsearchown.RealstateOwneDataTable dt = new DSrealsearchown.RealstateOwneDataTable();
            //  DataTable dt = new DataTable();
            dt = RealStateTableAdaptersearchown.GetDataBySearch(build, floor, g, id);

            return dt;


        }

        public static DataTable checkexistcareer(string name, string p1, string m1, int id)
        {

            DScareersearch.careerDataTable dt = new DScareersearch.careerDataTable();
            //          dt = careerTableAdaptersearch.GetDataSearch(id,name,id,p,id, m, id);



            //SELECT     ID, Name, careertype, p, m, other, notes, category, dataofchanged, [user]
            //FROM         career
            //ORDER BY dataofchanged DESC

            //            DSphoneSearch.PhoneDataTable dt = new DSphoneSearch.PhoneDataTable();

            string statment = "SELECT ID, Name, p, m, other  FROM career WHERE ";

            if (name != "")
            {
                statment += "  (ID <> " + id + " AND  Name='" + name + "') or ";
            }

            if (p1 != "")
            {
                statment += "  ( ( ID <> " + id + " AND p= '" + p1 + "') or ( ID <> " + id + " AND  p= '" + p1 + "') or ( ID <> " + id + " AND  m= '" + p1 + "') or ( ID <> " + id + " AND  m= '" + p1 + "')) or";
            }

            if (m1 != "")
            {
                statment += " ((ID <> " + id + " AND p= '" + m1 + "') or (ID <> " + id + " AND p= '" + m1 + "') or (ID <> " + id + " AND m= '" + m1 + "') or (ID <> " + id + " AND m= '" + m1 + "')) or";

            }

            if (statment != "SELECT ID, Name, p, m, other  FROM career WHERE ")
            {
                string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
                OleDbConnection conn = new OleDbConnection(serverConnectionString);

                try
                {

                    conn.Open();
                    OleDbDataAdapter sda = new OleDbDataAdapter(statment.Substring(0, statment.LastIndexOf("or")), conn);
                    sda.Fill(dt);
                    sda.Dispose();
                    conn.Dispose();
                    conn.Close();

                }
                catch (Exception)
                {
                    throw;

                }
                finally
                {

                    conn.Close();
                    conn.Dispose();
                }
            }

            return dt;


        }



        public static void shortcut(string one, string two)
        {

            try
            {

                //// استخدم PowerShell لإنشاء الاختصار
                //string psCommand = $@"
                //    $WshShell = New-Object -ComObject WScript.Shell
                //    $Shortcut = $WshShell.CreateShortcut(""{two+".lnk"}"")
                //    $Shortcut.TargetPath = ""{one}""
                //    $Shortcut.Save()
                //    ";

                //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                //{
                //    FileName = "powershell.exe",
                //    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{psCommand}\"",
                //    UseShellExecute = false,
                //    CreateNoWindow = true
                //});

                //string shortcutName =Path.GetFileName(two) +".lnk";

                //// مسار مؤقت للاختصار على سطح المكتب
                //string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //string shortcutPath = Path.Combine(desktop, shortcutName);

                //IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                //IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);

                //shortcut.TargetPath = one;
                //shortcut.WorkingDirectory = Path.GetDirectoryName(one);
                //shortcut.Save();

                //// تحرير الموارد
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(shortcut);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(shell);


                //// (اختياري) نقل الاختصار إلى الشبكة إذا أردت
                //string finalNetworkPath =two;
                //System.IO.File.Copy(shortcutPath, finalNetworkPath, overwrite: true);

                //// (اختياري) حذف النسخة المؤقتة من سطح المكتب
                //System.IO.File.Delete(shortcutPath);

                one = one.Replace("بناء", "");
                two = two.Replace("بناء", "");
                // Create a new instance of WshShellClass
                WshShell = new WshShellClass();

                // Create the shortcut
                IWshRuntimeLibrary.IWshShortcut MyShortcut;

                // Choose the path for the shortcut
                MyShortcut = (IWshRuntimeLibrary.IWshShortcut)WshShell.CreateShortcut(two + ".lnk");

                // Where the shortcut should point to
                MyShortcut.TargetPath = one;

                // Description for the shortcut
                //          MyShortcut.Description = "Launch My Application";

                // Location for the shortcut's icon
                //            MyShortcut.IconLocation = Application.StartupPath + @"\App.ico";

                // Create the shortcut at the given path
                MyShortcut.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        public static void insertrealapp(int ID_appointment, int ID_real, DateTime Date, DateTime Time)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            string sqlstatmen = " INSERT INTO Appointment_Real" +
                      "(ID_appointment, ID_real, [Date], [Time], active)" +
                      " VALUES     (" + ID_appointment + ", " + ID_real + ", '" + Date + "','" + Time + "','1')";

            try
            {

                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                OleDbTransaction Tran;
                Tran = conn.BeginTransaction();
                cmd = new OleDbCommand(sqlstatmen, conn);
                cmd.Transaction = Tran;
                cmd.ExecuteNonQuery();
                Tran.Commit();
                conn.Dispose();
                conn.Close();

            }
            catch
            {

            }
        }
        //public static void ToOwncopy(int id, double salary, string wayofrent, string region)
        //{
        //    DataTable dt = new DataTable();
        //    dt = RealStateTableAdapter.GetAll(id);

        //    string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
        //    OleDbConnection conn = new OleDbConnection(serverConnectionString);

        //    try
        //    {

        //        conn.Open();

        //        if (dt.Rows.Count > 0)
        //        {
        //            //string insertstatment = "INSERT INTO `RealstateOwne` (`Region_ID`, `SubResgionID`, `Building`, `Floor`, `FloorComment`, `Entrance`, `Distance`, " +
        //            //    "`Building_Type_ID`, `Owner`, `Phone_one`, `Phone_Two`, `Mobile`, `Mobile2`, `Other`, `DateOfEnter`, `UserID`, `area`," +
        //            //    "`Price`, `investiture`, `WayOFOwner`,`Note`, `Info_Source`, `active`,`DateOchange`,`DateOchangeEvent`) " +
        //            //    "VALUES (" + region +
        //            //    ",'" + dt.Rows[0]["SubResgionID"].ToString() +
        //            //    "','" + dt.Rows[0]["Building"].ToString() +
        //            //    "'," + Convert.ToInt32(dt.Rows[0]["Floor"].ToString()) +
        //            //    ",'" + dt.Rows[0]["FloorComment"].ToString() +
        //            //    "','" + dt.Rows[0]["Entrance"].ToString() +
        //            //    "','" + dt.Rows[0]["Distance"].ToString() +
        //            //    "'," + Convert.ToInt32(dt.Rows[0]["Building_Type_ID"].ToString()) +
        //            //    "','" + dt.Rows[0]["Owner"].ToString() +
        //            //    "','" + dt.Rows[0]["Phone_one"].ToString() +
        //            //    "','" + dt.Rows[0]["Phone_two"].ToString() +
        //            //    "','" + dt.Rows[0]["Mobile"].ToString() +
        //            //    "','" + dt.Rows[0]["Mobile2"].ToString() +
        //            //    "','" + dt.Rows[0]["Other"].ToString() +
        //            //    "','" + DateTime.Now.Date + "', '" + Utils.current_user +
        //            //    "'," + Convert.ToInt32(dt.Rows[0]["area"].ToString()) + "," + salary +
        //            //    "," + Convert.ToInt32(dt.Rows[0]["investiture"].ToString()) + "," + wayofrent +
        //            //    ",'" + dt.Rows[0]["Note"].ToString() +
        //            //    "','" + dt.Rows[0]["Info_Source"].ToString() + "', 1,'" + DateTime.Now.Date + "','" + DateTime.Now.Date + "')";

        //            string insertstatment = "INSERT INTO RealstateOwne " +
        //            "([Region_ID], [SubResgionID], [Building], [Floor], [FloorComment], [Entrance], [Distance], " +
        //            "[Building_Type_ID], [Owner], [Phone_one], [Phone_Two], [Mobile], [Mobile2], [Other], " +
        //            "[DateOfEnter], [UserID], [area], [Price], [investiture], [WayOFOwner], [Note], [Info_Source], " +
        //            "[active], [DateOchange], [DateOchangeEvent]) " +
        //            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

        //            using (var cmdd = new OleDbCommand(insertstatment, conn))
        //            {
        //                cmdd.Parameters.AddWithValue("@Region_ID", region);
        //                cmdd.Parameters.AddWithValue("@SubResgionID", dt.Rows[0]["SubResgionID"].ToString());
        //                cmdd.Parameters.AddWithValue("@Building", dt.Rows[0]["Building"].ToString());
        //                cmdd.Parameters.AddWithValue("@Floor", Convert.ToInt32(dt.Rows[0]["Floor"]));
        //                cmdd.Parameters.AddWithValue("@FloorComment", dt.Rows[0]["FloorComment"].ToString());
        //                cmdd.Parameters.AddWithValue("@Entrance", dt.Rows[0]["Entrance"].ToString());
        //                cmdd.Parameters.AddWithValue("@Distance", dt.Rows[0]["Distance"].ToString());
        //                cmdd.Parameters.AddWithValue("@Building_Type_ID", Convert.ToInt32(dt.Rows[0]["Building_Type_ID"]));
        //                cmdd.Parameters.AddWithValue("@Owner", dt.Rows[0]["Owner"].ToString());
        //                cmdd.Parameters.AddWithValue("@Phone_one", dt.Rows[0]["Phone_one"].ToString());
        //                cmdd.Parameters.AddWithValue("@Phone_Two", dt.Rows[0]["Phone_two"].ToString());
        //                cmdd.Parameters.AddWithValue("@Mobile", dt.Rows[0]["Mobile"].ToString());
        //                cmdd.Parameters.AddWithValue("@Mobile2", dt.Rows[0]["Mobile2"].ToString());
        //                cmdd.Parameters.AddWithValue("@Other", dt.Rows[0]["Other"].ToString());
        //                cmdd.Parameters.AddWithValue("@DateOfEnter", DateTime.Now.Date);
        //                cmdd.Parameters.AddWithValue("@UserID", Utils.current_user);
        //                cmdd.Parameters.AddWithValue("@area", Convert.ToInt32(dt.Rows[0]["area"]));
        //                cmdd.Parameters.AddWithValue("@Price", salary);
        //                cmdd.Parameters.AddWithValue("@investiture", Convert.ToInt32(dt.Rows[0]["investiture"]));
        //                cmdd.Parameters.AddWithValue("@WayOFOwner", wayofrent);
        //                cmdd.Parameters.AddWithValue("@Note", dt.Rows[0]["Note"].ToString());
        //                cmdd.Parameters.AddWithValue("@Info_Source", dt.Rows[0]["Info_Source"].ToString());
        //                cmdd.Parameters.AddWithValue("@active", 1);
        //                cmdd.Parameters.AddWithValue("@DateOchange", DateTime.Now.Date);
        //                cmdd.Parameters.AddWithValue("@DateOchangeEvent", DateTime.Now.Date);

        //                cmdd.ExecuteNonQuery();
        //            }




        //            //OleDbCommand cmd = new OleDbCommand();
        //            //cmd.Connection = conn;
        //            //OleDbTransaction Tran;
        //            //Tran = conn.BeginTransaction();
        //            //cmd = new OleDbCommand(insertstatment, conn);
        //            //cmd.Transaction = Tran;
        //            //cmd.ExecuteNonQuery();
        //            //Tran.Commit();
        //            //conn.Dispose();
        //            //conn.Close();
        //            int newid = LastIDOwn();

        //            DataTable dtattachment = new DataTable();
        //            dtattachment = AttachmentTableAdapter.GetDataByCheck(id);

        //            if (dtattachment.Rows.Count > 0)
        //            {
        //                for (int g = 0; g < dtattachment.Rows.Count; g++)
        //                {

        //                    int Type = (dtattachment.Rows[g]["Comment"].ToString().Contains("إرفاق آلي") || dtattachment.Rows[g]["Comment"].ToString().Contains("إرفاق الي")
        //                              || dtattachment.Rows[g]["Comment"].ToString().Contains("ارفاق آلي")
        //                              || dtattachment.Rows[g]["Comment"].ToString().Contains("ارفاق الي")
        //                              || dtattachment.Rows[g]["Comment"].ToString().Contains("صورة كراج البناء")) ? 2 : 1;

        //                    string FileName = dtattachment.Rows[g]["FileName"].ToString();
        //                    bool isVisible = Convert.ToBoolean(dtattachment.Rows[g]["Visible"]);

        //                    //string ext = FileName.Substring(FileName.LastIndexOf("."));
        //                    //string yy = FileName.Substring(0, FileName.LastIndexOf(id.ToString()));

        //                    string fileName = dtattachment.Rows[g]["FileName"].ToString();
        //                    string ext = Path.GetExtension(fileName);  // أسهل وأضمن
        //                    int index = fileName.LastIndexOf(id.ToString());

        //                    string yy = "";
        //                    if (index > 0)
        //                    {
        //                        yy = fileName.Substring(0, index);
        //                    }
        //                    else
        //                    {
        //                        // fallback لو id مش موجود
        //                        yy = Path.GetFileNameWithoutExtension(fileName);
        //                    }



        //                    string fullname = yy + newid + ext;
        //                    //string temp = FileName.Substring(0, 1);
        //                    if(Type== 2)
        //                    {
        //                        AttachmentTableAdapterOwn.Insert(newid, fullname, "", DateTime.Now, dtattachment.Rows[g]["Comment"].ToString(), 1, 2, isVisible);
        //                    }
        //                    else
        //                    {
        //                        AttachmentTableAdapterOwn.Insert(newid, fullname, "", DateTime.Now, dtattachment.Rows[g]["Comment"].ToString(), 1, 1, isVisible);
        //                        System.IO.File.Copy(Utils.ProjectName + "\\" + FileName, Utils.ProjectName + "\\OwAttach\\" + fullname);
        //                    }
        //                    //if (System.IO.File.Exists(Utils.ProjectName + "\\" + FileName) && temp != "T")
        //                    //{
        //                    //    System.IO.File.Copy(Utils.ProjectName + "\\" + FileName, Utils.ProjectName + "\\OwAttach\\" + fullname);
        //                    //}
        //                    //else if (temp == "T")
        //                    //{
        //                    //    Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + yy + ext, Utils.ProjectName + "\\OwAttach\\" + fullname);
        //                    //}
        //                }
        //            }

        //            DataTable devent = new DataTable();
        //            devent = EventTableAdapter.Gebyreal(id);

        //            if (devent.Rows.Count > 0)
        //            {
        //                for (int g = 0; g < devent.Rows.Count; g++)
        //                {
        //                    EventTableAdapterOwn.Insert(newid, Convert.ToDateTime(devent.Rows[g]["Date"]), devent.Rows[g]["User"].ToString(), devent.Rows[g]["Event"].ToString(), 1);
        //                }

        //            }

        //            conn.Dispose();
        //            conn.Close();


        //        }

        //    }
        //    catch
        //    {


        //    }
        //    finally
        //    {

        //        conn.Close();
        //        conn.Dispose();
        //    }

        //}
        public static void ToOwncopy(int id, double salary, string wayofrent, string region)
        {
            DataTable dt = RealStateTableAdapter.GetAll(id);
            if (dt.Rows.Count == 0) return;

            string connStr = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                OleDbTransaction tran = conn.BeginTransaction();

                try
                {
                    // Insert main record
                    string insertstatment = "INSERT INTO RealstateOwne " +
                               "([Region_ID], [SubResgionID], [Building], [Floor], [FloorComment], [Entrance], [Distance], " +
                               "[Building_Type_ID], [Owner], [Phone_one], [Phone_Two], [Mobile], [Mobile2], [Other], " +
                               "[DateOfEnter], [UserID], [area], [Price], [investiture], [WayOFOwner], [Note], [Info_Source], " +
                               "[active], [DateOchange], [DateOchangeEvent]) " +
                               "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    using (var cmdd = new OleDbCommand(insertstatment, conn, tran))
                    {
                        cmdd.Parameters.AddWithValue("@Region_ID", region);
                        cmdd.Parameters.AddWithValue("@SubResgionID", dt.Rows[0]["SubResgionID"].ToString());
                        cmdd.Parameters.AddWithValue("@Building", dt.Rows[0]["Building"].ToString());
                        cmdd.Parameters.AddWithValue("@Floor", Convert.ToInt32(dt.Rows[0]["Floor"]));
                        cmdd.Parameters.AddWithValue("@FloorComment", dt.Rows[0]["FloorComment"].ToString());
                        cmdd.Parameters.AddWithValue("@Entrance", dt.Rows[0]["Entrance"].ToString());
                        cmdd.Parameters.AddWithValue("@Distance", dt.Rows[0]["Distance"].ToString());
                        cmdd.Parameters.AddWithValue("@Building_Type_ID", Convert.ToInt32(dt.Rows[0]["Building_Type_ID"]));
                        cmdd.Parameters.AddWithValue("@Owner", dt.Rows[0]["Owner"].ToString());
                        cmdd.Parameters.AddWithValue("@Phone_one", dt.Rows[0]["Phone_one"].ToString());
                        cmdd.Parameters.AddWithValue("@Phone_Two", dt.Rows[0]["Phone_two"].ToString());
                        cmdd.Parameters.AddWithValue("@Mobile", dt.Rows[0]["Mobile"].ToString());
                        cmdd.Parameters.AddWithValue("@Mobile2", dt.Rows[0]["Mobile2"].ToString());
                        cmdd.Parameters.AddWithValue("@Other", dt.Rows[0]["Other"].ToString());
                        cmdd.Parameters.AddWithValue("@DateOfEnter", DateTime.Now.Date);
                        cmdd.Parameters.AddWithValue("@UserID", Utils.current_user);
                        cmdd.Parameters.AddWithValue("@area", Convert.ToInt32(dt.Rows[0]["area"]));
                        cmdd.Parameters.AddWithValue("@Price", salary);
                        cmdd.Parameters.AddWithValue("@investiture", Convert.ToInt32(dt.Rows[0]["investiture"]));
                        cmdd.Parameters.AddWithValue("@WayOFOwner", wayofrent);
                        cmdd.Parameters.AddWithValue("@Note", dt.Rows[0]["Note"].ToString());
                        cmdd.Parameters.AddWithValue("@Info_Source", dt.Rows[0]["Info_Source"].ToString());
                        cmdd.Parameters.AddWithValue("@active", 1);
                        cmdd.Parameters.AddWithValue("@DateOchange", DateTime.Now.Date);
                        cmdd.Parameters.AddWithValue("@DateOchangeEvent", DateTime.Now.Date);

                        cmdd.ExecuteNonQuery();
                    }

                    int newid = LastInsertedId(conn, tran);  // ✅ safe id

                    // Copy attachments
                    DataTable dtattachment = AttachmentTableAdapter.GetDataByCheck(id);
                    foreach (DataRow row in dtattachment.Rows)
                    {
                        string fileName = row["FileName"].ToString();
                        string ext = Path.GetExtension(fileName);
                        string baseName = Path.GetFileNameWithoutExtension(fileName);
                        string fullname = baseName.Replace(id.ToString(), newid.ToString()) + ext;

                        bool isVisible = Convert.ToBoolean(row["Visible"]);
                        int type = row["Comment"].ToString().Contains("إرفاق") ? 2 : 1;

                        AttachmentTableAdapterOwn.Insert(newid, fullname, "", DateTime.Now, row["Comment"].ToString(), 1, type, isVisible);

                        if (type == 1)
                        {
                            System.IO.File.Copy(Utils.ProjectName + "\\" + fileName,
                                      Utils.ProjectName + "\\OwAttach\\" + fullname, true);
                        }
                    }

                    // Copy events
                    DataTable devent = EventTableAdapter.Gebyreal(id);
                    foreach (DataRow row in devent.Rows)
                    {
                        EventTableAdapterOwn.Insert(newid,
                            Convert.ToDateTime(row["Date"]),
                            row["User"].ToString(),
                            row["Event"].ToString(),
                            1);
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }


        //public static void ToRentcopy(int id, int region, double salary, int wayofrent, int statuse, DateTime start, DateTime end, string period, string remaring)
        //{
        //    DataTable dt = new DataTable();

        //    dt = RealstateOwneTableAdapter.GetDataAll(id);


        //    string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
        //    OleDbConnection conn = new OleDbConnection(serverConnectionString);


        //    try
        //    {

        //        conn.Open();

        //        if (dt.Rows.Count > 0)
        //        {

        //            string insertstatment = "INSERT INTO `RealState` (`Region_ID`, `SubResgionID`, `Building`, `Floor`, " +
        //            "`FloorComment`, `Entrance`, `Distance`, " +
        //            "`Building_Type_ID`, `Owner`, `Phone_one`, `Phone_Two`, `Mobile`, `Mobile2`, `Other`, `DateOfEnter`, `UserID`,`area`, " +
        //            "`Price`, `investiture`, `WayOfRent`, `Note`, `Info_Source`, `Status_ID`, `StartRentDate`, " +
        //            "`EndRendDate`,`Period`, `RemainingDay`, `active`, `RDateOchange`, `RDateOchangeEvent`) " +   // <<<<<< حذفت Mobile2 التانية
        //            "VALUES (" + region +
        //            ",'" + dt.Rows[0]["SubResgionID"].ToString() +
        //            "','" + dt.Rows[0]["Building"].ToString() +
        //            "'," + Convert.ToInt32(dt.Rows[0]["Floor"].ToString()) +
        //            ",'" + dt.Rows[0]["FloorComment"].ToString() +
        //            "','" + dt.Rows[0]["Entrance"].ToString() +
        //            "','" + dt.Rows[0]["Distance"].ToString() +
        //            "'," + Convert.ToInt32(dt.Rows[0]["Building_Type_ID"].ToString()) +
        //            ",'" + dt.Rows[0]["Owner"].ToString() +
        //            "','" + dt.Rows[0]["Phone_one"].ToString() +
        //            "','" + dt.Rows[0]["Phone_two"].ToString() +
        //            "','" + dt.Rows[0]["Mobile"].ToString() +
        //            "','" + dt.Rows[0]["Mobile2"].ToString() +      // هنا Mobile2 مظبوطة
        //            "','" + dt.Rows[0]["Other"].ToString() +
        //            "','" + DateTime.Now.Date + "', '" + Utils.current_user +
        //            "'," + Convert.ToInt32(dt.Rows[0]["area"].ToString()) + "," + salary +
        //            "," + Convert.ToInt32(dt.Rows[0]["investiture"].ToString()) + "," + wayofrent +
        //            ",'" + dt.Rows[0]["Note"].ToString() +
        //            "','" + dt.Rows[0]["Info_Source"].ToString() + "'," + statuse +
        //            ",'" + start + "','" + end + "','" + period + "'," + remaring +
        //            ", 1,'" + DateTime.Now.Date + "','" + DateTime.Now.Date + "')";

        //            OleDbCommand cmd = new OleDbCommand();
        //            cmd.Connection = conn;
        //            OleDbTransaction Tran;
        //            Tran = conn.BeginTransaction();
        //            cmd = new OleDbCommand(insertstatment, conn);
        //            cmd.Transaction = Tran;
        //            cmd.ExecuteNonQuery();
        //            Tran.Commit();
        //            conn.Dispose();
        //            conn.Close();
        //            int newid = LastID();

        //            DataTable dtattachment = new DataTable();
        //            dtattachment = AttachmentTableAdapterOwn.GetDataByCheck(id);

        //            if (dtattachment.Rows.Count > 0)
        //            {
        //                for (int g = 0; g < dtattachment.Rows.Count; g++)
        //                {
        //                    int Type = (dtattachment.Rows[g]["Comment"].ToString().Contains("إرفاق آلي") || dtattachment.Rows[g]["Comment"].ToString().Contains("إرفاق الي")
        //                              || dtattachment.Rows[g]["Comment"].ToString().Contains("ارفاق آلي")
        //                              || dtattachment.Rows[g]["Comment"].ToString().Contains("ارفاق الي")
        //                              || dtattachment.Rows[g]["Comment"].ToString().Contains("صورة كراج البناء")) ? 2 : 1;

        //                    string FileName = dtattachment.Rows[g]["FileName"].ToString();
        //                    bool isVisible = Convert.ToBoolean(dtattachment.Rows[g]["Visible"]);
        //                    string fileName = dtattachment.Rows[g]["FileName"].ToString();
        //                    string ext = Path.GetExtension(fileName);  // أسهل وأضمن
        //                    int index = fileName.LastIndexOf(id.ToString());
        //                    string yy = "";
        //                    if (index > 0)
        //                    {
        //                        yy = fileName.Substring(0, index);
        //                    }
        //                    else
        //                    {
        //                        // fallback لو id مش موجود
        //                        yy = Path.GetFileNameWithoutExtension(fileName);
        //                    }



        //                    string fullname = yy + newid + ext;
        //                    if (Type == 2)
        //                    {
        //                        AttachmentTableAdapter.Insert(newid, fullname, "", DateTime.Now, dtattachment.Rows[g]["Comment"].ToString(), 1, 2, isVisible);
        //                    }
        //                    else
        //                    {
        //                        AttachmentTableAdapter.Insert(newid, fullname, "", DateTime.Now, dtattachment.Rows[g]["Comment"].ToString(), 1, 1, isVisible);
        //                        System.IO.File.Copy(Utils.ProjectName + "\\OwAttach\\" + FileName, Utils.ProjectName + "\\" + fullname);
        //                    }
        //                    //string FileName = dtattachment.Rows[g]["FileName"].ToString();
        //                    //string ext = FileName.Substring(FileName.LastIndexOf("."));
        //                    //string yy = FileName.Substring(0, FileName.LastIndexOf(id.ToString()));
        //                    //string fullname = yy + newid + ext;
        //                    //string temp = FileName.Substring(0, 1);
        //                    //AttachmentTableAdapter.Insert(newid, fullname, "", DateTime.Now, dtattachment.Rows[g]["Comment"].ToString(), 1, 2, false);
        //                    //if (System.IO.File.Exists(Utils.ProjectName + "\\OwAttach\\" + FileName) && temp != "T")
        //                    //{
        //                    //    System.IO.File.Copy(Utils.ProjectName + "\\OwAttach\\" + FileName, Utils.ProjectName + "\\" + fullname);
        //                    //}
        //                    //else if (temp == "T")
        //                    //{
        //                    //    Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + yy + ext, Utils.ProjectName + "\\" + fullname);
        //                    //}
        //                }
        //            }


        //            DataTable devent = new DataTable();
        //            devent = EventTableAdapterOwn.Getbyreal(id);

        //            if (devent.Rows.Count > 0)
        //            {
        //                for (int g = 0; g < devent.Rows.Count; g++)
        //                {

        //                    EventTableAdapter.Insert(newid, Convert.ToDateTime(devent.Rows[g]["Date"]), devent.Rows[g]["User"].ToString(), devent.Rows[g]["Event"].ToString(), 1);
        //                    //EventTableAdapter.Update(devent.);
        //                }

        //            }


        //        }

        //    }
        //    catch
        //    {


        //    }
        //    finally
        //    {

        //        conn.Close();
        //        conn.Dispose();


        //    }

        //}
        public static void ToRentcopy(int id, int region, double salary, int wayofrent, int statuse,
                        DateTime start, DateTime end, string period, string remaining)
        {
            DataTable dt = RealstateOwneTableAdapter.GetDataAll(id);
            if (dt.Rows.Count == 0) return;

            string connStr = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                OleDbTransaction tran = conn.BeginTransaction();

                try
                {
                    // جملة الإدراج زي القديمة
                    string insertstatment = "INSERT INTO `RealState` (`Region_ID`, `SubResgionID`, `Building`, `Floor`, " +
                    "`FloorComment`, `Entrance`, `Distance`, " +
                    "`Building_Type_ID`, `Owner`, `Phone_one`, `Phone_Two`, `Mobile`, `Mobile2`, `Other`, `DateOfEnter`, `UserID`,`area`, " +
                    "`Price`, `investiture`, `WayOfRent`, `Note`, `Info_Source`, `Status_ID`, `StartRentDate`, " +
                    "`EndRendDate`,`Period`, `RemainingDay`, `active`, `RDateOchange`, `RDateOchangeEvent`) " +   // <<<<<< حذفت Mobile2 التانية
                    "VALUES (" + region +
                    ",'" + dt.Rows[0]["SubResgionID"].ToString() +
                    "','" + dt.Rows[0]["Building"].ToString() +
                    "'," + Convert.ToInt32(dt.Rows[0]["Floor"].ToString()) +
                    ",'" + dt.Rows[0]["FloorComment"].ToString() +
                    "','" + dt.Rows[0]["Entrance"].ToString() +
                    "','" + dt.Rows[0]["Distance"].ToString() +
                    "'," + Convert.ToInt32(dt.Rows[0]["Building_Type_ID"].ToString()) +
                    ",'" + dt.Rows[0]["Owner"].ToString() +
                    "','" + dt.Rows[0]["Phone_one"].ToString() +
                    "','" + dt.Rows[0]["Phone_two"].ToString() +
                    "','" + dt.Rows[0]["Mobile"].ToString() +
                    "','" + dt.Rows[0]["Mobile2"].ToString() +      // هنا Mobile2 مظبوطة
                    "','" + dt.Rows[0]["Other"].ToString() +
                    "','" + DateTime.Now.Date + "', '" + Utils.current_user +
                    "'," + Convert.ToInt32(dt.Rows[0]["area"].ToString()) + "," + salary +
                    "," + Convert.ToInt32(dt.Rows[0]["investiture"].ToString()) + "," + wayofrent +
                    ",'" + dt.Rows[0]["Note"].ToString() +
                    "','" + dt.Rows[0]["Info_Source"].ToString() + "'," + statuse +
                    ",'" + start + "','" + end + "','" + period + "'," + remaining +
                    ", 1,'" + DateTime.Now.Date + "','" + DateTime.Now.Date + "')";

                    // تنفيذ الإدراج بالـ transaction
                    using (OleDbCommand cmd = new OleDbCommand(insertstatment, conn, tran))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // الحصول على آخر ID داخل نفس الـ transaction
                    int newid = LastInsertedId(conn, tran);

                    // نسخ الـ Attachments
                    DataTable dtattachment = AttachmentTableAdapterOwn.GetDataByCheck(id);
                    if (dtattachment.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtattachment.Rows)
                        {
                            int Type = (row["Comment"].ToString().Contains("إرفاق آلي") ||
                                        row["Comment"].ToString().Contains("إرفاق الي") ||
                                        row["Comment"].ToString().Contains("ارفاق آلي") ||
                                        row["Comment"].ToString().Contains("ارفاق الي") ||
                                        row["Comment"].ToString().Contains("صورة كراج البناء")) ? 2 : 1;

                            string fileName = row["FileName"].ToString();
                            bool isVisible = Convert.ToBoolean(row["Visible"]);
                            string ext = Path.GetExtension(fileName);
                            int index = fileName.LastIndexOf(id.ToString());
                            string yy = (index > 0) ? fileName.Substring(0, index) : Path.GetFileNameWithoutExtension(fileName);
                            string fullname = yy + newid + ext;

                            if (Type == 2)
                            {
                                AttachmentTableAdapter.Insert(newid, fullname, "", DateTime.Now, row["Comment"].ToString(), 1, 2, isVisible);
                            }
                            else
                            {
                                AttachmentTableAdapter.Insert(newid, fullname, "", DateTime.Now, row["Comment"].ToString(), 1, 1, isVisible);
                                System.IO.File.Copy(Utils.ProjectName + "\\OwAttach\\" + fileName, Utils.ProjectName + "\\" + fullname, true);
                            }
                        }
                    }

                    // نسخ الـ Events
                    DataTable devent = EventTableAdapterOwn.Getbyreal(id);
                    if (devent.Rows.Count > 0)
                    {
                        foreach (DataRow row in devent.Rows)
                        {
                            EventTableAdapter.Insert(newid,
                                Convert.ToDateTime(row["Date"]),
                                row["User"].ToString(),
                                row["Event"].ToString(), 1);
                        }
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }


        public static void deleteventattachphon(int id)
        {

            PhoneAttachTableAdapter.DeleteQuery(id);
            phoneEventTableAdapter.DeleteQuery(id);
        }

        public static void careerdeleteventattach(int id)
        {
            careerEventTableAdapter.DeleteQuery(id);
            careerAttachTableAdapter.DeleteQuery(id);

        }


        public static string macaddreass;
        public static void getMacaddres()
        {


            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");

            try
            {
                foreach (ManagementObject share in searcher.Get())
                {
                    foreach (PropertyData PC in share.Properties)
                    {
                        if (PC.Name == "SystemName")
                        {

                            macaddreass = PC.Value.ToString();

                        }

                    }
                }
            }

            catch (Exception exp)
            {

            }



        }




    }
}





