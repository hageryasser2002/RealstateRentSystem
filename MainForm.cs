using RealStateRentSystem.Classes;
using RealStateRentSystem.DSTables;
using RealStateRentSystem.DSTables.DSCallsTableAdapters;
using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using ApiManager = RealStateRentSystem_Buisness.ApiManager;

namespace RealStateRentSystem
{

    public partial class MainForm : Form
    {
        private bool _isProcessingAttachments = false;
        public static System.Windows.Forms.ToolTip m_wndToolTip = new System.Windows.Forms.ToolTip();


        public int childFormNumber;
        public static string whatTab = "tab1";

        private static DSTables.DSrealstateTableAdapters.RealStateTableAdapter RealStateTableAdapter = new DSTables.DSrealstateTableAdapters.RealStateTableAdapter();
        private DSTables.DSsettingTableAdapters.StaticTableAdapter StaticTableAdapter = new DSTables.DSsettingTableAdapters.StaticTableAdapter();
        private DSTables.DSsettingTableAdapters.RealStaticTableAdapter RealStaticTableAdapter = new DSTables.DSsettingTableAdapters.RealStaticTableAdapter();
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();


        /// ////////////////////

        public Modem mod = null;
        public Modem.SetCallback call;
        public static Size MainForm_Size { set; get; }
        public static Point MainForm_Location { set; get; }

        public bool init = true;

        private Timer _Timer = new Timer();
        public TabControl MainTabs => tabControl1;

        public static MainForm Instance;

        FrmAlways u;
        alwaysOwner uo;
        AlwaysPhone up;
        alwaysCareer uc;
        FollowUp.FollowUp fp;


        //// حطي الكود ده كمتغير عام في MainForm
        //PhoneFloatingSearchForm searchForm;


        private TextBox txtSearch;
        //private SearchForm searchForm = null;

        private Timer _autoAttachTimer;

        public static SearchForm searchForm;


        //private Timer _timer;
        //private CallImporter _callImporter;

        public MainForm()
        {
            InitializeComponent();
            InitApiPolling();


            this.FormClosing += MainForm_FormClosing;
            //this.Activated += MainForm_Activated;
            //this.Deactivate += MainForm_Deactivate;

            this.KeyPreview = false;

            Instance = this;
            Utils.getsetting();

            ///
            //InitSearchBar();

            if (Utils.HasModem == true)
            // if (clsDeviceSettings.HasModem())
            {
                try
                {
                    CheckForModem();
                    call = new Modem.SetCallback(this.TakeControl);
                    mod = new Modem(new SerialPort(), Utils.Portname, this.call);
                    Utils.mode = mod;
                }
                catch
                {

                    MessageBox.Show(
                                      "الرجاء اعداد المودم الى البورت الصحيح واعادة تشغيل البرنامج",
                                      "خطأ",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error,
                                      MessageBoxDefaultButton.Button3,
                                      MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                                  );
                }
            }


            if (!Directory.Exists(Utils.ProjectName)) {
                MessageBox.Show(
                                     $"مسار المجلدات غير موجود يرجى التحقق من المسار \r\n {Utils.ProjectName}",
                                     "خطأ",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error,
                                     MessageBoxDefaultButton.Button3,
                                     MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                                 );

            }

            // Active Please

            main_timer.Start();
            main_timer.Tick += new EventHandler(RunAlarm);
            main_timer.Interval = Utils.RemainderingPeriod * 60000;


            if (Utils.alert == true)
            {
                // notify();
                //System.Timers.Timer timer = new System.Timers.Timer(5000);
                System.Timers.Timer timer = new System.Timers.Timer(300000); //After 5 Minutes Run HMessageBox
                timer.Elapsed += (sender, e) =>
                {
                    timer.Stop(); // stop it after it fires once
                    notify();
                };
                timer.Start();
            }
            timer1.Start();
            timer1.Tick += new EventHandler(RunAlarmStatic);
            //timer1.Interval = (Utils.RemainderingPeriod + 1) * 60000;
            timer1.Interval = (Utils.RemainderingPeriod + 1) * 15 * 60 * 1000;
            // Staticnotify();


            timer2.Start();
            timer2.Tick += new EventHandler(RealRunAlarmStatic);
            //timer2.Interval = (Utils.RemainderingPeriod + 2) * 60000;
            timer2.Interval = (Utils.RemainderingPeriod + 1) * 15 * 60 * 1000;
            //RealStaticnotify();
        }


        private System.Windows.Forms.Timer apiTimer;

        private void InitApiPolling()
        {
            var settings = clsSettingsCalling.LoadSettings();
            if (settings.Interval <= 0) return;

            apiTimer = new System.Windows.Forms.Timer();
            apiTimer.Interval = settings.Interval * 1000;
            apiTimer.Tick += async (s, e) =>
            {
                var result = await ApiManager.ImportCall(settings.ImportLink, "line1", "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il");
                var callerInfo = display(result.phoneNumber);
                if (!string.IsNullOrEmpty(result.phoneNumber))
                {
                    //string info = clsPhoneSearcher.SearchByNumber(result.phoneNumber);

                    //Notification note = new Notification($"{result.phoneNumber}\n{info}", 0);
                    //note.Show();

                    string callType = result.phoneType; // "W" أو "N"
                    Notification note = new Notification(result.phoneNumber, Utils.LastIDCall(), callType, result.phoneName);
                    note.Show();
                }
            };
            apiTimer.Start();
        }

        private void InitializeOdt()
        {
            if (odt.Columns.Count == 0) // عشان ما نضيفش الأعمدة أكتر من مرة
            {
                odt.Columns.Add("number", typeof(string));
                odt.Columns.Add("date", typeof(DateTime));
                odt.Columns.Add("name", typeof(string));
                odt.Columns.Add("place", typeof(string));
                odt.Columns.Add("placeID", typeof(string));
                odt.Columns.Add("numbertype", typeof(string));
            }
        }


        #region Fields
        DSTables.DSCallsTableAdapters.CallsRegistrayTableAdapter CallsRegistrayTableAdapter = new DSTables.DSCallsTableAdapters.CallsRegistrayTableAdapter();


        DataTable odt = new DataTable();
        DataTable dtphone = new DataTable();
        DataTable dtrent = new DataTable();
        DataTable dtown = new DataTable();
        DataTable dtcareer = new DataTable();

        Notification notifForm;
        string Createname = "";
        string Createplace = "";
        string CreateplaceIds = "";
        string cleanenumber = "";
        #endregion
        public CallerInfo display(string number)
        {
            if (string.IsNullOrEmpty(number))
                return null;
            if (number.StartsWith("09"))
            {
                exact(number, "mop", DateTime.Now);
            }
            else if (number.StartsWith("011"))
            {
                if (number.Length == 3 + Utils.PhoneNumerLength)
                {
                    exact(number.Remove(0, 3), "land", DateTime.Now);
                }
                else if (number.Length == 3 + Utils.PhoneNumerLength + 1)
                {
                    exact(number, "other", DateTime.Now);
                }
            }
            else if (number.StartsWith("+") || number.StartsWith("00"))
            {
                exact(number, "other", DateTime.Now);
            }
            else
            {
                exact(number, "other", DateTime.Now);
            }

            // Build CallerInfo object
            var info = new CallerInfo
            {
                Number = number,
                Name = Createname,
                Place = Createplace.Trim(','),
                PlaceIds = CreateplaceIds,
                Type = cleanenumber
            };

            // reset internal fields for next use
            Createname = "";
            Createplace = "";
            CreateplaceIds = "";
            cleanenumber = "";

            return info;
        }


        private void exact(string number, string type, DateTime date)
        {
            cleanenumber = number;
            Createname = "";
            Createplace = "";

            if (odt.Rows.Count > 0)
            {
                odt.Clear();

            }

            //odt .Columns.Add("apppointTime", typeof(DateTime));

            if (number != "")
            {
                string phonequery = "";
                string realrentquesry = "";
                string realownquesry = "";
                string careerquery = "";


                phonequery = " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o FROM  Phone where ";
                realrentquesry = "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Realstate.active as active FROM RealState where ";
                realownquesry = "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , RealstateOwne.active as active FROM  RealstateOwne where ";
                careerquery = "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o FROM career  where ";

                if (number.StartsWith("00"))
                {
                    realrentquesry += " ( (   Phone_one= '" + number + "' ) or (   Phone_Two= '" + number + "')  or (   Mobile= '" + number + "') or (   Mobile2= '" + number + "') or ( other = '" + "+" + number.Remove(0, 2) + "' ) ) or ";
                    realownquesry += " ( (   Phone_one= '" + number + "' ) or (   Phone_Two= '" + number + "' ) or (    Mobile= '" + number + "' ) or (    Mobile2= '" + number + "' ) or ( other = '" + "+" + number.Remove(0, 2) + "' ) ) or ";
                    phonequery += " ( p1= '" + number + "' or p2= '" + number + "'  or m2= '" + number + "' or m3= '" + number + "'  or other = '" + "+" + number.Remove(0, 2) + "'  ) or  ";
                    careerquery += " ((  p = '" + number + "' ) or (   m = '" + number + "') or ( other = '" + "+" + number.Remove(0, 2) + "' )  ) or ";
                }
                else if (number.StartsWith("+"))
                {
                    realrentquesry += " ( (   Phone_one= '" + number + "' ) or (   Phone_Two= '" + number + "')  or (   Mobile= '" + number + "') or (   Mobile2= '" + number + "') or ( other = '" + "00" + number.Remove(0, 1) + "' ) ) or ";
                    realownquesry += " ( (   Phone_one= '" + number + "' ) or (   Phone_Two= '" + number + "' ) or (    Mobile= '" + number + "' ) or (    Mobile2= '" + number + "' ) or ( other = '" + "00" + number.Remove(0, 1) + "' ) ) or ";
                    phonequery += " ( p1= '" + number + "' or p2= '" + number + "'  or m2= '" + number + "' or m3= '" + number + "'  or other = '" + "00" + number.Remove(0, 1) + "'  ) or  ";
                    careerquery += " ((  p = '" + number + "' ) or (   m = '" + number + "') or ( other = '" + "00" + number.Remove(0, 1) + "' )  ) or ";

                }



                realrentquesry += " ( (   Phone_one= '" + number + "' ) or (   Phone_Two= '" + number + "')  or (   Mobile= '" + number + "') or (   Mobile2= '" + number + "') or ( other = '" + number + "' ) ) and ";
                realownquesry += " ( (   Phone_one= '" + number + "' ) or (   Phone_Two= '" + number + "' ) or (    Mobile= '" + number + "' ) or (    Mobile2= '" + number + "' ) or ( other = '" + number + "' ) ) and ";
                phonequery += " ( p1= '" + number + "' or p2= '" + number + "'  or m2= '" + number + "' or m3= '" + number + "'  or other = '" + number + "'  ) and  ";
                careerquery += " ((  p = '" + number + "' ) or (   m = '" + number + "') or ( other = '" + number + "' )  )and ";


                if (phonequery != " SELECT Phone.id ,Name as n , p1 as pone, m2 as mone, p2 as ptwo, m3 as mtwo, other as o FROM  Phone where ")
                {
                    dtphone = get(phonequery.Substring(0, phonequery.LastIndexOf("and")));
                }
                if (realrentquesry != "SELECT Realstate.id , Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , Realstate.active as active FROM RealState where ")
                {
                    dtrent = get(realrentquesry.Substring(0, realrentquesry.LastIndexOf("and")));
                }
                if (realownquesry != "SELECT RealstateOwne.id ,Owner as n , Phone_one as pone, Mobile as mone, Phone_Two as ptwo, Mobile2 as mtwo, Other as o , RealstateOwne.active as active FROM  RealstateOwne where ")
                {
                    dtown = get(realownquesry.Substring(0, realownquesry.LastIndexOf("and")));
                }

                if (careerquery != "SELECT career.ID, Name as n, p as pone, m as mone, p as ptwo, m as mtwo, other as o FROM career  where ")
                {
                    dtcareer = get(careerquery.Substring(0, careerquery.LastIndexOf("and")));
                }

                //  int counter = 0;
                //dataGridView1.Rows.Add(odt.Rows.Count);
                /////////////////////////////???
                for (int y = 0; y < dtrent.Rows.Count; y++)
                {
                    InitializeOdt();

                    DataRow newrow = odt.NewRow();
                    newrow["number"] = number;
                    newrow["date"] = date;
                    newrow["name"] = dtrent.Rows[y]["n"].ToString();

                    if (dtrent.Rows[y]["active"].ToString() == "1")
                    {
                        newrow["place"] = "اجار";
                        Createplace += "," + "اجار";
                    }
                    else
                    {
                        newrow["place"] = "اجار ارشيف";
                        Createplace += "," + "اجار ارشيف";

                    }

                    newrow["placeID"] = dtrent.Rows[y]["id"].ToString();
                    newrow["numbertype"] = type;
                    odt.Rows.Add(newrow);



                    Createname = dtrent.Rows[y]["n"].ToString();
                    CreateplaceIds += ",r" + dtrent.Rows[y]["id"].ToString();


                }


                for (int y = 0; y < dtown.Rows.Count; y++)
                {
                    InitializeOdt();

                    DataRow newrow = odt.NewRow();
                    newrow["number"] = number;
                    newrow["date"] = date;
                    newrow["name"] = dtown.Rows[y]["n"].ToString();


                    if (dtown.Rows[y]["active"].ToString() == "1")
                    {
                        newrow["place"] = "بيع";
                        Createplace += "," + "بيع";
                    }
                    else
                    {
                        newrow["place"] = "بيع ارشيف";
                        Createplace += "," + "بيع";
                    }

                    newrow["placeID"] = dtown.Rows[y]["id"].ToString();
                    newrow["numbertype"] = type;
                    odt.Rows.Add(newrow);


                    if (Createname == "")
                    {
                        Createname = dtown.Rows[y]["n"].ToString();
                    }

                    CreateplaceIds += ",o" + dtown.Rows[y]["id"].ToString();

                }


                if (dtphone.Rows.Count > 0)
                {

                    for (int y = 0; y < dtphone.Rows.Count; y++)
                    {
                        InitializeOdt();

                        DataRow newrow = odt.NewRow();
                        newrow["number"] = number;
                        newrow["date"] = date;
                        newrow["name"] = dtphone.Rows[y]["n"].ToString();
                        newrow["place"] = "الهاتف";
                        newrow["placeID"] = dtphone.Rows[y]["id"].ToString();
                        newrow["numbertype"] = type;
                        odt.Rows.Add(newrow);

                        Createplace += "," + "الهاتف";
                        if (Createname == "")
                        {
                            Createname = dtphone.Rows[y]["n"].ToString();
                        }


                        CreateplaceIds += ",p" + dtphone.Rows[y]["id"].ToString();
                    }



                }

                for (int y = 0; y < dtcareer.Rows.Count; y++)
                {
                    InitializeOdt();

                    DataRow newrow = odt.NewRow();
                    newrow["number"] = number;
                    newrow["date"] = date;
                    newrow["name"] = dtcareer.Rows[y]["n"].ToString();
                    newrow["place"] = "مهن";
                    newrow["placeID"] = dtcareer.Rows[y]["id"].ToString();
                    newrow["numbertype"] = type;
                    odt.Rows.Add(newrow);

                    Createplace += "," + "مهن";
                    if (Createname == "")
                    {
                        Createname = dtcareer.Rows[y]["n"].ToString();
                    }

                    CreateplaceIds += ",m" + dtcareer.Rows[y]["id"].ToString();

                }


            }

            
            DateTime tt = DateTime.Now;
            if (Utils.backup == true) // backup with deplicate number
                {
                    if (!clsDeviceSettings.CanSaveCalls())
                        return;

                   
                    CallsRegistrayTableAdapter.Insert(
                    cleanenumber,
                    tt,
                    Createname,
                    Createplace,
                    CreateplaceIds,
                    type
                    , " ", tt);


                 
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
            finally
            {

                conn.Close();
                conn.Dispose();
            }

        }





        private Timer _focusCheckTimer;

        private void StartAppFocusMonitor()
        {
            _focusCheckTimer = new Timer();
            _focusCheckTimer.Interval = 100; // Check every 500ms
            _focusCheckTimer.Tick += FocusCheckTimer_Tick;
            _focusCheckTimer.Start();
        }

        private bool _wasFocused = true;

        private void FocusCheckTimer_Tick(object sender, EventArgs e)
        {
            bool isAppFocused = AppFocusHelper.IsAppActive();

            if (isAppFocused && !_wasFocused)
            {
                // App came back to focus
                SearchFormLauncher.ShowSearchForm();
            }
            else if (!isAppFocused && _wasFocused)
            {
                // App lost focus
               SearchFormLauncher.HideSearchForm();
            }

            _wasFocused = isAppFocused;
        }

        /// <summary>
        /// Added Attachment Automatic Property
        /// </summary>
        //private void TryAutoAttachFromRealsate()
        //{
        //    string basePath = Utils.ProjectName;

        //    var realStatesOwns = clsRealStateOwn.GetAllRealStateOwns();
        //    var realStates = clsRealState.GetLightweightRealStates();

        //    List<clsTempAttachment> tempAttachments = clsTempAttachment.GetAllTempAttachments();

        //    foreach (var tempAttachment in tempAttachments)
        //    {
        //        string regionName = tempAttachment.Region?.Trim();
        //        string subRegion = tempAttachment.SubRegion?.Trim();
        //        string building = tempAttachment.Building?.Trim();

        //        if (string.IsNullOrEmpty(regionName) || string.IsNullOrEmpty(subRegion) || string.IsNullOrEmpty(building))
        //            continue;

        //        long? regionID = clsRegion.GetRegionIDByName(regionName);
        //        if (regionID == null)
        //            continue;

        //        var matchingRealStates = realStates
        //            .Where(rs =>
        //                rs.RegionID == regionID &&
        //                rs.SubRegion?.Trim() == subRegion &&
        //                rs.Building?.Trim() == building)
        //            .ToList();

        //        if (!matchingRealStates.Any())
        //            continue;

        //        foreach (var Row in matchingRealStates)
        //        {
        //            long realStateID = Row.ID;
        //            string fileName = tempAttachment.FileName;
        //            string comment = tempAttachment.Comment;
        //            string path = Path.Combine(basePath, "TempAttachment", fileName);

        //            // 🔍 تحقق هل المرفق موجود مسبقًا لهذا العقار
        //            if (!clsAttachment.Exists(realStateID, fileName))
        //            {
        //                clsAttachment newAttach = new clsAttachment()
        //                {
        //                    RealStateID = realStateID,
        //                    FileName = fileName,
        //                    Path = path,
        //                    Comment = comment,
        //                    Type = 2,
        //                    DateOFAttash = DateTime.Now
        //                };

        //                clsAttachment.AddAttachment(newAttach);
        //            }
        //        }

        //        var matchingRealStateOwn = realStatesOwns.Rows
        //            .Cast<DataRow>()
        //            .Where(rs =>
        //                rs["Region_ID"].ToString().Trim() == regionName &&
        //                rs["SubResgionID"].ToString().Trim() == subRegion &&
        //                rs["Building"].ToString().Trim() == building)
        //            .ToList();

        //        if (!matchingRealStateOwn.Any())
        //            continue;

        //        foreach (var ownRow in matchingRealStateOwn)
        //        {
        //            long realStateOwnID = Convert.ToInt64(ownRow["ID"]);
        //            string fileNameOwn = tempAttachment.FileName;
        //            string commentOwn = tempAttachment.Comment;
        //            string pathOwn = Path.Combine(basePath, "TempAttachment", fileNameOwn);

        //            // 🔍 تحقق هل المرفق موجود مسبقًا لهذا العقار المملوك
        //            if (!clsAttachmentOwn.Exists(realStateOwnID, fileNameOwn))
        //            {
        //                clsAttachmentOwn newAttachOwn = new clsAttachmentOwn()
        //                {
        //                    RealStateOwnID = realStateOwnID,
        //                    FileName = fileNameOwn,
        //                    Path = pathOwn,
        //                    Comment = commentOwn,
        //                    Type = 2,
        //                    DateOFAttash = DateTime.Now
        //                };

        //                clsAttachmentOwn.AddAttachment(newAttachOwn);
        //            }
        //        }
        //    }
        //}

        //private void TryAutoAttachFromTemp()
        //{
        //    string basePath = Utils.ProjectName;

        //    //var tempAttachments = clsTempAttachment.GetAllTempAttachments();
        //    //if (tempAttachments == null || tempAttachments.Count == 0) return;

        //    //// تحميل البيانات مره واحده
        //    //var allRealStates = clsRealState.GetAllRealStates().AsEnumerable()
        //    //    .Where(r => r["Region_ID"] != DBNull.Value)
        //    //    .ToList();

        //    //var allOwns = clsRealStateOwn.GetAllRealStateOwns().AsEnumerable().ToList();

        //    //var realStatesByKey = allRealStates.ToLookup(r => (
        //    //    RegionID: Convert.ToInt64(r["Region_ID"]),
        //    //    SubRegion: r["SubResgionID"].ToString().Trim(),
        //    //    Building: r["Building"].ToString().Trim()
        //    //));

        //    //var realStateOwnsByKey = allOwns.ToLookup(r => (
        //    //    RegionName: r["Region_ID"].ToString().Trim(),
        //    //    SubRegion: r["SubResgionID"].ToString().Trim(),
        //    //    Building: r["Building"].ToString().Trim()
        //    //));

        //    //// كاش مؤقت لتقليل استعلامات Exists
        //    //var existingRealStateAttachments = new HashSet<string>();
        //    //var existingOwnAttachments = new HashSet<string>();

        //    //foreach (var temp in tempAttachments)
        //    //{
        //    //    string regionName = temp.Region?.Trim();
        //    //    string subRegion = temp.SubRegion?.Trim();
        //    //    string building = temp.Building?.Trim();
        //    //    string fileName = temp.FileName;
        //    //    string comment = temp.Comment;

        //    //    if (string.IsNullOrWhiteSpace(regionName) || string.IsNullOrWhiteSpace(subRegion) || string.IsNullOrWhiteSpace(building))
        //    //        continue;

        //    //    var regionID = clsRegion.GetRegionIDByName(regionName);
        //    //    if (regionID == null) continue;

        //    //    string path = Path.Combine(basePath, "TempAttachment", fileName);

        //    //    // Attach to RealState
        //    //    var realStates = realStatesByKey[(regionID.Value, subRegion, building)];
        //    //    foreach (var row in realStates)
        //    //    {
        //    //        long id = Convert.ToInt64(row["ID"]);
        //    //        string key = $"{id}_{comment}";

        //    //        if (!existingRealStateAttachments.Contains(key) && !clsAttachment.Exists(id, comment))
        //    //        {
        //    //            clsAttachment.AddAttachment(new clsAttachment
        //    //            {
        //    //                RealStateID = id,
        //    //                FileName = fileName,
        //    //                Path = path,
        //    //                Comment = comment,
        //    //                Type = 2,
        //    //                DateOFAttash = DateTime.Now
        //    //            });

        //    //            existingRealStateAttachments.Add(key);
        //    //        }
        //    //    }

        //    //    // Attach to RealStateOwn
        //    //    var owns = realStateOwnsByKey[(regionName, subRegion, building)];
        //    //    foreach (var row in owns)
        //    //    {
        //    //        long id = Convert.ToInt64(row["ID"]);
        //    //        string key = $"{id}_{comment}";

        //    //        if (!existingOwnAttachments.Contains(key) && !clsAttachmentOwn.Exists(id, comment))
        //    //        {
        //    //            clsAttachmentOwn.AddAttachment(new clsAttachmentOwn
        //    //            {
        //    //                RealStateOwnID = id,
        //    //                FileName = fileName,
        //    //                Path = path,
        //    //                Comment = comment,
        //    //                Type = 2,
        //    //                DateOFAttash = DateTime.Now
        //    //            });

        //    //            existingOwnAttachments.Add(key);
        //    //        }
        //    //    }
        //    //}
        //    DataTable realStatesOwns = clsRealStateOwn.GetAllRealStateOwns();
        //    DataTable realStates = clsRealState.GetAllRealStates();
        //    List<clsTempAttachment> tempAttachments = clsTempAttachment.GetAllTempAttachments();
        //    foreach (var tempAttachment in tempAttachments)
        //    {
        //        string regionName = tempAttachment.Region?.Trim();
        //        string subRegion = tempAttachment.SubRegion?.Trim();
        //        string building = tempAttachment.Building?.Trim();

        //        // Console.WriteLine($"Processing attachment: {tempAttachment.FileName}, Region: {regionName}, SubRegion: {subRegion}, Building: {building}");

        //        if (string.IsNullOrEmpty(regionName) || string.IsNullOrEmpty(subRegion) || string.IsNullOrEmpty(building))
        //        {
        //            //Console.WriteLine("Skipping due to missing region/subregion/building.");
        //            continue;
        //        }

        //        long? regionID = clsRegion.GetRegionIDByName(regionName);
        //        if (regionID == null)
        //        {
        //            //Console.WriteLine($"Region not found: {regionName}");
        //            continue;
        //        }

        //        // Realstate
        //        var matchingRealStates = realStates.Rows
        //                .Cast<DataRow>()
        //                .Where(rs =>
        //                    rs["Region_ID"] != DBNull.Value &&
        //                    Convert.ToInt64(rs["Region_ID"]) == regionID &&
        //                    rs["SubResgionID"].ToString().Trim() == subRegion &&
        //                    rs["Building"].ToString().Trim() == building)
        //                .ToList();

        //        if (!matchingRealStates.Any())
        //        {
        //            //Console.WriteLine($"No matching real state found for: RegionID={regionID}, SubRegion={subRegion}, Building={building}");
        //            continue;
        //        }

        //        foreach (var Row in matchingRealStates)
        //        {
        //            long realStateID = Convert.ToInt64(Row["ID"]);
        //            string fileName = tempAttachment.FileName;
        //            string comment = tempAttachment.Comment;
        //            string path = Path.Combine(basePath, "TempAttachment", fileName);

        //            clsAttachment newAttach = new clsAttachment()
        //            {
        //                RealStateID = realStateID,
        //                FileName = fileName,
        //                Path = path,
        //                Comment = comment,
        //                Type = 2,
        //                DateOFAttash = DateTime.Now
        //            };

        //            clsAttachment.AddAttachment(newAttach);
        //            // Console.WriteLine($"Attachment added for RealStateID: {realStateID}, Insert success");
        //        }


        //        // RealstateOwn
        //        var matchingRealStateOwn = realStatesOwns.Rows
        //            .Cast<DataRow>()
        //            .Where(rs =>
        //                rs["Region_ID"].ToString().Trim() == regionName &&
        //                rs["SubResgionID"].ToString().Trim() == subRegion &&
        //                rs["Building"].ToString().Trim() == building).ToList();

        //        if (!matchingRealStateOwn.Any())
        //        {
        //            //Console.WriteLine($"No matching real state own found for: {regionName}, {subRegion}, {building}");
        //            continue;
        //        }

        //        foreach (var ownRow in matchingRealStateOwn)
        //        {
        //            long realStateOwnID = Convert.ToInt64(ownRow["ID"]);
        //            string fileNameOwn = tempAttachment.FileName;
        //            string commentOwn = tempAttachment.Comment;
        //            string pathOwn = Path.Combine(basePath, "TempAttachment", fileNameOwn);

        //            clsAttachmentOwn newAttachOwn = new clsAttachmentOwn()
        //            {
        //                RealStateOwnID = realStateOwnID,
        //                FileName = fileNameOwn,
        //                Path = pathOwn,
        //                Comment = commentOwn,
        //                Type = 2,
        //                DateOFAttash = DateTime.Now
        //            };

        //            clsAttachmentOwn.AddAttachment(newAttachOwn);
        //            //Console.WriteLine($"AttachmentOwn added for RealStateOwnID: {realStateOwnID}, Insert success");
        //        }
        //    }


        //}



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void ReloadUserPermissions()
        {
            bool isAdmin = Utils.current_user.ToLower() == "administrator";

            اعداداتالنظامToolStripMenuItem.Enabled = isAdmin;
            APItoolStripMenuItem.Enabled = isAdmin;
            تعريفالمستخدمينToolStripMenuItem.Enabled = isAdmin;
            administratorToolStripMenuItem.Enabled = isAdmin;
            مناطقToolStripMenuItem.Enabled = isAdmin;
            مفاتيحإختصارToolStripMenuItem.Enabled = isAdmin;
            النماذجالمرفقهToolStripMenuItem.Enabled = isAdmin;
            انواعالمهنToolStripMenuItem.Enabled = isAdmin;
            تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem.Enabled = isAdmin;

            if (tabControl1.SelectedTab == this.tabPage1)
            {
                اعداداتنظامالايجارToolStripMenuItem.Visible = isAdmin;
                اعداداتنظامالايجارToolStripMenuItem.Enabled = isAdmin;
            }


            if (tabControl1.SelectedTab == this.tabPage2)
            {
                طرقالبيعToolStripMenuItem.Visible = isAdmin;
                طرقالبيعToolStripMenuItem.Enabled = isAdmin;

                اعداداتالنظامالبيعToolStripMenuItem.Visible = isAdmin;
                اعداداتالنظامالبيعToolStripMenuItem.Enabled = isAdmin;
            }
        }

        public void RefreshAllTabs()
            {
                if (tabPage1.Controls.Count > 0)
                {
                    FrmAlways u = tabPage1.Controls[0] as FrmAlways;
                    if (u != null) u.RefreshUserUI();
                }

                if (tabPage2.Controls.Count > 0)
                {
                    alwaysOwner uo = tabPage2.Controls[0] as alwaysOwner;
                    if (uo != null) uo.RefreshUserUI();
                }

                if (tabPage3.Controls.Count > 0)
                {
                    alwaysCareer uc = tabPage3.Controls[0] as alwaysCareer;
                    if (uc != null) uc.RefreshUserUI();
                }

                if (tabPage4.Controls.Count > 0)
                {
                    AlwaysPhone up = tabPage4.Controls[0] as AlwaysPhone;
                    if (up != null) up.RefreshUserUI();
                }
            }

        public void UpdateOpenFormsUserInfo()
        {
            foreach (Form child in this.MdiChildren)
            {
                var refreshMethod = child.GetType().GetMethod("RefreshUserUI");
                if (refreshMethod != null)
                {
                    refreshMethod.Invoke(child, null);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearUtils()
        {
            Utils.ORentRecord = false;
            Utils.ONameOfCustomer = "";
            Utils.OCustPhon = "";
            Utils.OCustMobile = "";
            Utils.OCusOther = "";
            Utils.ODTRealAppointinfo.Rows.Clear();
            Utils.OSortdDTRealAppointinfo.Clear();

            Utils.RentRecord = false;
            Utils.NameOfCustomer = "";
            Utils.CustPhon = "";
            Utils.CustMobile = "";
            Utils.CusOther = "";
            Utils.DTRealAppointinfo.Rows.Clear();
            Utils.SortdDTRealAppointinfo.Clear();
        }

        //private void MainForm_VisibleChanged(object sender, EventArgs e)
        //{
        //    if (searchForm == null || searchForm.IsDisposed)
        //        return;

        //    // لو الفورم الرئيسية اختفت، اخفي SearchForm كمان
        //    searchForm.Visible = this.Visible;
        //}
        public void PositionSearchForm()
                {

                    if (searchForm == null || searchForm.IsDisposed)
                        return;

                    // دايمًا تكون 100 بكسل يمين من المين فورم و 30 بكسل من فوق
                    int x = this.Left + 900;
                    int y = this.Top + 40;

                    searchForm.Location = new Point(x, y);

                    // لو عاوزاها تصغر وتكبر مع المين فورم
                    searchForm.Width = this.Width - 200; // أقل شوية من المين
                    searchForm.Height = 60; // ارتفاع ثابت مثلاً
                    //// نخليها تظهر بجانب المين فورم أو داخلها حسب ما تحبي
                    //searchForm.Location = new Point(this.Left + 20, this.Top + 20);
                    //searchForm.Size = new Size(this.Width - 40, 60); // الطول ثابت - العرض يتبع المين
                }
                //PhoneFloatingSearchForm floatingForm;
        private void MainForm_Load(object sender, EventArgs e)
        {
            StartAppFocusMonitor();

            SearchFormLauncher.StartSearchForm();
          

            Utils.cachedUsers = clsUser.GetAllActiveUsers();
            //clsUser.ResetAllLoginStatus(); // في البداية نعمل Reset

            // Active Please
            _Timer.Interval = 1000;
            _Timer.Tick += new EventHandler(_Timer_Tick);
            _Timer.Start();



            m_wndToolTip.BackColor = Color.White;
            m_wndToolTip.UseAnimation = true;
            m_wndToolTip.UseFading = true;
            m_wndToolTip.ForeColor = Color.Red;


            m_wndToolTip.OwnerDraw = true;

            m_wndToolTip.Draw += new DrawToolTipEventHandler(m_wndToolTip_Draw);

            m_wndToolTip.Popup += new PopupEventHandler(m_wndToolTip_Popup);

            m_wndToolTip.ShowAlways = true;


            //Microsoft.Win32.RegistryKey m_RegKey = Microsoft.Win32.Registry.LocalMachine;
            //m_RegKey = m_RegKey.OpenSubKey(@"HARDWARE\DEVICEMAP\SERIALCOMM");
            ////get all the entried there
            //string[] szComPorts = m_RegKey.GetValueNames();
            //for (int i = 0; i <= szComPorts.GetUpperBound(0); i++)
            //{
            //    //list the port
            //    Utils.Portname=m_RegKey.GetValue(szComPorts[i]).ToString();
            //}
            //m_RegKey.Close();





            if (Utils.current_user.ToLower() == "administrator")
            {
                اعداداتالنظامToolStripMenuItem.Enabled = true;
                APItoolStripMenuItem.Enabled = true; 
                تعريفالمستخدمينToolStripMenuItem.Enabled = true;
                administratorToolStripMenuItem.Enabled = true;
                مناطقToolStripMenuItem.Enabled = true;
                مفاتيحإختصارToolStripMenuItem.Enabled = true;
                النماذجالمرفقهToolStripMenuItem.Enabled = true;
                انواعالمهنToolStripMenuItem.Enabled = true;

                تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem.Enabled = true;
            }

            if (whatTab == "tab1")
            {
                FrmAlways u = new FrmAlways();

                u.MdiParent = this;
                this.tabPage1.Controls.Add(u);
                Utils.RentRecord = false;
                Utils.NameOfCustomer = "";
                Utils.CustPhon = "";
                Utils.CustMobile = "";
                Utils.CusOther = "";
                Utils.DTRealAppointinfo.Rows.Clear();

                u.Show();
                this.Text = " " + "طموحات العقارية - ايجار";

            }


            //_autoAttachTimer = new Timer();
            ////_autoAttachTimer.Interval = 1000; // 5 minutes instead of 1
            //_autoAttachTimer.Interval = 1 * 60 * 1000; // 5 minutes

            //_autoAttachTimer.Tick += async (s, ev) =>
            //{
            //    if (!_isProcessingAttachments)
            //    {
            //        _isProcessingAttachments = true;
            //        try
            //        {
            //            await Task.Run(() => TryAutoAttachFromRealsate());
            //        }
            //        finally
            //        {
            //            _isProcessingAttachments = false;
            //        }
            //    }
            //};
            //_autoAttachTimer.Start();

            //this.Load += (s, ev) =>
            //{
            //    var tab = tabPage2.Parent as TabControl;
            //    if (tab == null) return;

            //    tab.DrawMode = TabDrawMode.OwnerDrawFixed;
            //    tab.SizeMode = TabSizeMode.Fixed;
            //    tab.ItemSize = new Size(tab.ItemSize.Width, Math.Max(tab.ItemSize.Height, 90));

            //    tab.DrawItem += (snd, drawEv) =>
            //    {
            //        var page = tab.TabPages[drawEv.Index];
            //        var rect = drawEv.Bounds;
            //        bool isSelected = (tab.SelectedIndex == drawEv.Index);

            //        using (var back = new SolidBrush(isSelected ? SystemColors.ControlLightLight : SystemColors.Control))
            //            drawEv.Graphics.FillRectangle(back, rect);

            //        Font f = (page == tabPage2)
            //                 ? new Font(tab.Font.FontFamily, 30f, FontStyle.Bold)
            //                 : tab.Font;

            //        TextRenderer.DrawText(
            //            drawEv.Graphics,
            //            page.Text,
            //            f,
            //            rect,
            //            SystemColors.ControlText,
            //            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            //        );

            //        if (page == tabPage2) f.Dispose();
            //    };
            //};


        }








        private void MainForm_Move(object sender, EventArgs e)
        {
            UpdateSearchPosition();
        }

        private void UpdateSearchPosition()
        {
            SearchFormLauncher.UpdateSearchFormPosition(new Point(this.Location.X + 1000, this.Location.Y + 35), this.Size);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //searchForm?.Close();
            SearchFormLauncher.CloseSearchForm();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //searchForm?.Close();
            SearchFormLauncher.CloseSearchForm();
        }

       
        private void MainForm_Resize(object sender, EventArgs e)
        {
            MainForm_Size = this.Size;
            MainForm_Location = this.Location;

            if (this.WindowState == FormWindowState.Minimized)
            {
                SearchFormLauncher.HideSearchForm();
                UpdateSearchPosition();

            }
            else if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                SearchFormLauncher.ShowSearchForm();
                UpdateSearchPosition();
            }

        }


        //private void MainForm_Activated(object sender, EventArgs e)
        //{
        //    SearchFormLauncher.ShowSearchForm();
        //}

        //private void MainForm_Deactivate(object sender, EventArgs e)
        //{
        //    SearchFormLauncher.HideSearchForm();
        //}

        //private void MainForm_VisibleChanged(object sender, EventArgs e)
        //{
        //    if (this.Visible)
        //        SearchFormLauncher.ShowSearchForm();
        //    else
        //        SearchFormLauncher.HideSearchForm();
        //}

        //private void TryAutoAttachFromTemp()
        //{
        //    try
        //    {
        //        string basePath = Utils.ProjectName;

        //        // 1. Load temp attachments (only once)
        //        var tempAttachments = clsTempAttachment.GetAllTempAttachments();
        //        if (tempAttachments == null || tempAttachments.Count == 0)
        //            return;

        //        // 2. Pre-cache all region names to avoid repeated DB calls
        //        var distinctRegions = tempAttachments
        //            .Select(t => t.Region?.Trim())
        //            .Where(name => !string.IsNullOrWhiteSpace(name))
        //            .Distinct()
        //            .ToList();

        //        var regionNameToId = distinctRegions
        //            .ToDictionary(
        //                name => name,
        //                name => clsRegion.GetRegionIDByName(name)
        //            );

        //        // 3. Load only necessary data with minimal columns
        //        var allRealStates = clsRealState.GetLightweightRealStates()
        //            .Where(r => r.RegionID.HasValue)
        //            .ToList();

        //        var allOwns = clsRealStateOwn.GetLightweightRealStateOwns()
        //            .ToList();

        //        // 4. Create optimized lookup structures
        //        var realStatesLookup = allRealStates
        //            .GroupBy(r => (r.RegionID.Value, r.SubRegion, r.Building))
        //            .ToDictionary(g => g.Key, g => g.ToList());

        //        var ownsLookup = allOwns
        //            .GroupBy(o => (o.RegionName, o.SubRegion, o.Building))
        //            .ToDictionary(g => g.Key, g => g.ToList());

        //        // 5. Batch load existing attachments
        //        var existingRealStateAttachments = new HashSet<string>(
        //            clsAttachment.GetExistingAttachmentKeys());

        //        var existingOwnAttachments = new HashSet<string>(
        //            clsAttachmentOwn.GetExistingAttachmentKeys());

        //        // 6. Prepare batch collections
        //        var attachmentsToAdd = new List<clsAttachment>();
        //        var ownAttachmentsToAdd = new List<clsAttachmentOwn>();

        //        // 7. Process each temp attachment
        //        foreach (var temp in tempAttachments)
        //        {
        //            if (string.IsNullOrWhiteSpace(temp.Region) ||
        //                string.IsNullOrWhiteSpace(temp.SubRegion) ||
        //                string.IsNullOrWhiteSpace(temp.Building))
        //                continue;

        //            string regionName = temp.Region?.Trim();
        //            string subRegion = temp.SubRegion?.Trim();
        //            string building = temp.Building?.Trim();
        //            string fileName = temp.FileName;
        //            string comment = temp.Comment;

        //            // 8. Check region mapping
        //            if (!regionNameToId.TryGetValue(regionName, out var regionId) || !regionId.HasValue)
        //                continue;

        //            string path = Path.Combine(basePath, "TempAttachment", fileName);

        //            // 9. Process RealState attachments
        //            var realStateKey = (regionId.Value, subRegion, building);
        //            if (realStatesLookup.TryGetValue(realStateKey, out var matchingRealStates))
        //            {
        //                foreach (var realState in matchingRealStates)
        //                {
        //                    string attachmentKey = $"{realState.ID}_{comment}";
        //                    if (!existingRealStateAttachments.Contains(attachmentKey))
        //                    {
        //                        attachmentsToAdd.Add(new clsAttachment
        //                        {
        //                            RealStateID = realState.ID,
        //                            FileName = fileName,
        //                            Path = path,
        //                            Comment = comment,
        //                            Type = 2,
        //                            DateOFAttash = DateTime.Now
        //                        });
        //                        existingRealStateAttachments.Add(attachmentKey);
        //                    }
        //                }
        //            }

        //            // 10. Process Own attachments
        //            var ownKey = (regionName, subRegion, building);
        //            if (ownsLookup.TryGetValue(ownKey, out var matchingOwns))
        //            {
        //                foreach (var own in matchingOwns)
        //                {
        //                    string attachmentKey = $"{own.ID}_{comment}";
        //                    if (!existingOwnAttachments.Contains(attachmentKey))
        //                    {
        //                        ownAttachmentsToAdd.Add(new clsAttachmentOwn
        //                        {
        //                            RealStateOwnID = own.ID,
        //                            FileName = fileName,
        //                            Path = path,
        //                            Comment = comment,
        //                            Type = 2,
        //                            DateOFAttash = DateTime.Now
        //                        });
        //                        existingOwnAttachments.Add(attachmentKey);
        //                    }
        //                }
        //            }
        //        }

        //        // 11. Bulk insert all new attachments
        //        if (attachmentsToAdd.Count > 0)
        //            clsAttachment.BulkAddAttachments(attachmentsToAdd);

        //        if (ownAttachmentsToAdd.Count > 0)
        //            clsAttachmentOwn.BulkAddAttachments(ownAttachmentsToAdd);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log error
        //        Console.WriteLine("Error in TryAutoAttachFromTemp", ex);
        //    }
        //}


        //private void TxtPhoneSearch_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        string phone = txtPhoneSearch.Text.Trim();

        //        if (string.IsNullOrEmpty(phone))
        //        {
        //                MessageBox.Show("من فضلك ادخل رقم الهاتف.");
        //                return;
        //        }

        //            // فتح الفورم الخاصة بعرض بيانات الرقم
        //         Form1 f = new Form1("", phone, "", "0");

        //         if (f.yes)
        //         {
        //                f.Show();
        //         }

        //         textBox1.Text = "";       // مسح الرقم
        //         textBox1.Focus();         // يرجع الفوكس على خانة الرقم




        //        e.Handled = true;
        //        e.SuppressKeyPress = true; // يمنع صوت التنبيه
        //    }
        //}


        //private void MainForm_Shown(object sender, EventArgs e)
        //{

        //}

        private void CheckForModem()
        {
            try
            {
                //string modemName = "";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_POTSModem");

                foreach (ManagementObject obj in searcher.Get())
                {
                    //modemName = obj["Name"]?.ToString();
                    //string status = obj["Status"]?.ToString();
                    string attachedPort = obj["AttachedTo"]?.ToString();

                    Utils.Portname = attachedPort;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for modem: " + ex.Message);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter && this.ActiveControl == txtPhoneSearch)
            {
                // دع الحدث يمر إلى TextBox
                return false;
            }

            if ((keyData & Keys.Alt) == Keys.Alt)
            {
                return true;
            }

            if (keyData == Keys.F11)
            {
                Utils.EncryptMode = !Utils.EncryptMode;

                if (Utils.EncryptMode)
                {
                    Imagencrypt.Visible = true;
                    Imagencrypt2.Visible = true;
                }
                if (!Utils.EncryptMode)

                {
                    Imagencrypt.Visible = false;
                    Imagencrypt2.Visible = false;
                }


                return true;

            }
            if (keyData == Keys.F6)
            {
                Realstate re = new Realstate();
                re.Text = "ادخال التأجير";
                tabControl1.SelectedTab = this.tabPage1;
                tabchange();
                re.ShowDialog();
                //re.Show();

                return true;

            }

            if (keyData == Keys.F7)
            {
                RealstateOwner re = new RealstateOwner();
                re.Text = " ادخال البيع";
                tabControl1.SelectedTab = this.tabPage2;
                tabchange();
                re.ShowDialog();
                //re.Show();

                return true;

            }

            if (keyData == Keys.F8)
            {


                career re = new career();
                tabControl1.SelectedTab = this.tabPage3;
                tabchange();
                re.ShowDialog();
                //re.Show();

            }


            if (keyData == Keys.F9)
            {

                phone re = new phone();
                tabControl1.SelectedTab = this.tabPage4;
                tabchange();
                re.ShowDialog();
                //re.Show();

            }

            if (((keyData & Keys.Shift) == Keys.Shift) && ((keyData & Keys.F10) == Keys.F10))
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

            return base.ProcessDialogKey(keyData);

        }

        string time = "1";
        private void RunAlarm(object sender, EventArgs eArgs)
        {
            //Utils.getsetting();
            if (Utils.alert == true)
            {
                if (HMessageBox.actived == false && time == "1")
                {
                    notify();

                }
            }
            else
            {

                time = "2";
            }

            if (StaticMessageBox.actived == false && time == "2")
            {
                Staticnotify();

            }

            if (RealStaticMessageBox.actived == false && time == "3")
            {
                RealStaticnotify();

            }





        }
        private void RealRunAlarmStatic(object sender, EventArgs eArgs)
        {
            if (RealStaticMessageBox.actived == false && time == "3")
            {
                RealStaticnotify();
            }

        }
        private void RunAlarmStatic(object sender, EventArgs eArgs)
        {
            if (StaticMessageBox.actived == false && time == "2")
            {
                Staticnotify();
            }

        }
     
        private void RealStaticnotify()
        {
            time = "1";
            //Utils.getsetting();
            timer2.Interval = (Utils.RemainderingPeriod + 1 / 2) * 60000;

            RealStaticMessageBox newMessageBox = new RealStaticMessageBox();
            string result = "";
            int days = GetDates.DateDiffDays(Utils.RealLastStaticAccess, DateTime.Now.Date);

            if (days >= Utils.EnterPeriodToStaic && RealStaticMessageBox.actived == false && StaticMessageBox.actived == false && HMessageBox.actived == false)
            {

                RealStaticAlarmSound.go();
                result = newMessageBox.ShowBox();
                if (result == "Cancel")
                {
                    time = "1";
                    RealStaticMessageBox.actived = false;
                }

            }

        }
        private void Staticnotify()
        {
            time = "3";
            //Utils.getsetting();
            timer1.Interval = (Utils.RemainderingPeriod + 1) * 60000;
            StaticMessageBox newMessageBox = new StaticMessageBox();

            string result = "";
            int days = GetDates.DateDiffDays(Utils.LastStaticAccess, DateTime.Now.Date);

            if (days >= Utils.EnterPeriodToStaic && RealStaticMessageBox.actived == false && StaticMessageBox.actived == false && HMessageBox.actived == false)
            {

                StaticAlarmSound.go();
                result = newMessageBox.ShowBox();
                if (result == "Cancel")
                {
                    StaticMessageBox.actived = false;
                    time = "3";
                }
            }

        }
        private void notify()
        {
            time = "2";
            //Utils.getsetting();
            main_timer.Interval = Utils.RemainderingPeriod * 60000;
            List<int> building = new List<int>();
            DataTable dt = new DataTable();
            dt = RealStateTableAdapter.GetRemaingBy(Convert.ToInt32(Utils.RemainderingDays));
            if (dt.Rows.Count > 0)
            {
                for (int t = 0; t < dt.Rows.Count; t++)
                    building.Add(Convert.ToInt32(dt.Rows[t]["id"]));

            }
            if (HMessageBox.actived == false)
            {

                HMessageBox hm = new HMessageBox();

                string returnedtype = "gofirsttime";
                int counter = building.Count;
                for (int t = 1; t <= building.Count; t++)
                {

                    if (returnedtype == "gofirsttime")
                    {
                        AlarmSound.go();

                        string result = hm.ShowBox(this,Convert.ToInt32(building[0]), counter);
                        HMessageBox.actived = true;
                        returnedtype = result;
                        counter = counter - 1;
                    }

                    if (returnedtype == "Agnoring")
                    {
                        if (counter > 0)
                        {
                            string result = hm.ShowBox(this,Convert.ToInt32(building[t]), counter);
                            HMessageBox.actived = true;
                            returnedtype = result;
                            counter = counter - 1;

                        }
                        else
                        {
                            HMessageBox.actived = false;
                            AlarmSound.main_timer.Stop();
                            AlarmSound.player.Stop();
                            time = "2";
                            break;
                        }


                    }
                    if (returnedtype == "Cancel")
                    {
                        HMessageBox.actived = false;
                        AlarmSound.main_timer.Stop();
                        AlarmSound.player.Stop();
                        time = "2";
                        break;
                        //  returnedtype = result;
                    }


                    if (returnedtype == "Cancel" || counter == 0)
                    {
                        Staticnotify();
                        HMessageBox.actived = false;
                        time = "2";

                    }
                }


            }

        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
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

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            //clsUser.ResetAllLoginStatus();
            this.Close();
        }

        
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void تعريفالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            //u.MdiParent = this;
            u.ShowDialog();
            //ShowModalExcept(u, MainForm.searchForm);
        }
        private void مفاتيحإختصارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShortCutKeys stc = new ShortCutKeys();

            stc.ShowDialog();
            //ShowModalExcept(stc, MainForm.searchForm);

        }
        private void مناطقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Region region = new Region();

            region.ShowDialog();
            //ShowModalExcept(region, MainForm.searchForm);
        }
        private void اعداداتالنظامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting u = new Setting();
            u.ShowDialog();
            //ShowModalExcept(u, MainForm.searchForm);
        }

        private void APIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APISetting api = new APISetting();
            api.ShowDialog();
        }

        private void العقاراتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Realstate re = new Realstate();
            re.Text = "ادخال التأجير";
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);
        }

        //void _Timer_Tick(object sender, EventArgs e)
        //{
        //    this.label1.Text = DateTime.Now.ToLongTimeString();
        //}

        void _Timer_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("hh:mm tt");
            this.label3.Text = DateTime.Now.ToString("HH:mm");
        }

        void m_wndToolTip_Popup(object sender, PopupEventArgs e)
        {
            using (Font f = new Font("Tahoma", 12))
            {
                e.ToolTipSize = TextRenderer.MeasureText(
                    m_wndToolTip.GetToolTip(e.AssociatedControl), f);
            }
        }

        void m_wndToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            Graphics g = e.Graphics;

            System.Drawing.Drawing2D.LinearGradientBrush b = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds,
                Color.OrangeRed, Color.LightCoral, 45f);


            g.FillRectangle(b, e.Bounds);

            g.DrawRectangle(new Pen(Brushes.SteelBlue, 2), new Rectangle(e.Bounds.X, e.Bounds.Y,
                e.Bounds.Width - 1, e.Bounds.Height - 1));

            g.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.Silver,
                new PointF(e.Bounds.X + 32, e.Bounds.Y + 6)); // shadow layer
            g.DrawString(e.ToolTipText, new Font(e.Font, FontStyle.Bold), Brushes.White,
                new PointF(e.Bounds.X + 32, e.Bounds.Y + 6)); // top layer

            b.Dispose();


        }

        public void TakeControl(Modem modcall)
        {
            if (this.InvokeRequired)
            {
                Modem.SetCallback d = new Modem.SetCallback(TakeControl);
                this.Invoke(d, new object[] { modcall });
            }
            else
            {
                //       this.txtInicializavimas.Text = modcall.ModemAnswer;

            }
        }

        public static void UpToolTip(Notification notifForm)
        {

           // label2.Invoke((MethodInvoker)delegate { m_wndToolTip.Show(text, label2); });
            //label2.Invoke((MethodInvoker)delegate { notifForm.Show(); });


        }

        public static void DownToolTip(Notification notifForm)
        {

            //label2.Invoke((MethodInvoker)delegate { m_wndToolTip.Show(text, label2); });
            //label2.Invoke((MethodInvoker)delegate { notifForm.Close(); });
        }

        private void الأرشيفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Realstate arre = new Realstate();
            //  u.MdiParent = this;
            arre.am = "archive";
            arre.Text = "أرشيف التأجير";
            arre.ShowDialog();
            //ShowModalExcept(arre, MainForm.searchForm);

        }

        private void administratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            ad.ShowDialog();
            //ShowModalExcept(ad, MainForm.searchForm);

        }
        private void حولToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog();
            //ShowModalExcept(f, MainForm.searchForm);


        }
        private void النماذجالمرفقهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TempAttach f = new TempAttach();
            f.ShowDialog();
            //ShowModalExcept(f, MainForm.searchForm);
        }


      

        //FrmAlways u = new FrmAlways();
        //alwaysOwner uo = new alwaysOwner();
        //AlwaysPhone up = new AlwaysPhone();
        //alwaysCareer uc = new alwaysCareer();
        //private void tabControl1_Click(object sender, EventArgs e)
        //{
        //    ClearUtils();

        //    //always.Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        //    //always.Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        //    //alwaysOwner.Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        //    //alwaysOwner.Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

        //    //Utils.ORentRecord = false;
        //    //Utils.ONameOfCustomer = "";
        //    //Utils.OCustPhon = "";
        //    //Utils.OCustMobile = "";
        //    //Utils.OCusOther = "";
        //    //Utils.ODTRealAppointinfo.Rows.Clear();
        //    //Utils.OSortdDTRealAppointinfo.Clear();



        //    //Utils.RentRecord = false;
        //    //Utils.NameOfCustomer = "";
        //    //Utils.CustPhon = "";
        //    //Utils.CustMobile = "";
        //    //Utils.CusOther = "";
        //    //Utils.DTRealAppointinfo.Rows.Clear();
        //    //Utils.SortdDTRealAppointinfo.Clear();


        //    if (tabControl1.SelectedTab == this.tabPage1)
        //    {

        //        whatTab = "tab1";
        //        //always.Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        //        u.MdiParent = this;
        //        this.tabPage1.Controls.Add(u);
        //        u.Show();


        //        الاحصائياتToolStripMenuItem.Visible = false;
        //        interToolStripMenuItem.Visible = false;
        //        archiveToolStripMenuItem.Visible = false;

        //        العقاراتToolStripMenuItem1.Visible = true;
        //        الأرشيفToolStripMenuItem.Visible = true;
        //        الاحصائياتToolStripMenuItem1.Visible = true;


        //        الهاتفToolStripMenuItem.Visible = false;
        //        طرقالبيعToolStripMenuItem.Visible = false;
        //        اعداداتالنظامالبيعToolStripMenuItem.Visible = false;


        //        if (Utils.current_user.ToLower() == "administrator")
        //        {
        //            اعداداتنظامالايجارToolStripMenuItem.Visible = true;
        //            اعداداتنظامالايجارToolStripMenuItem.Enabled = true;

        //        }
        //        else
        //        {
        //            اعداداتنظامالايجارToolStripMenuItem.Enabled = false;
        //            اعداداتنظامالايجارToolStripMenuItem.Visible = false;
        //        }


        //        انواعالمهنToolStripMenuItem.Visible = false;
        //        المهنToolStripMenuItem.Visible = false;

        //        this.Text = " " + "الطموحات العقارية - ايجار";
        //    }

        //    if (tabControl1.SelectedTab == this.tabPage2)
        //    {
        //        whatTab = "tab2";


        //        uo.MdiParent = this;
        //        this.tabPage2.Controls.Add(uo);
        //        uo.Show();


        //        الاحصائياتToolStripMenuItem.Visible = true;
        //        interToolStripMenuItem.Visible = true;
        //        archiveToolStripMenuItem.Visible = true;

        //        العقاراتToolStripMenuItem1.Visible = false;
        //        الأرشيفToolStripMenuItem.Visible = false;
        //        الاحصائياتToolStripMenuItem1.Visible = false;

        //        الهاتفToolStripMenuItem.Visible = false;
        //        المهنToolStripMenuItem.Visible = false;
        //        انواعالمهنToolStripMenuItem.Visible = false;

        //        اعداداتنظامالايجارToolStripMenuItem.Visible = false;

        //        if (Utils.current_user.ToLower() == "administrator")
        //        {
        //            طرقالبيعToolStripMenuItem.Visible = true;
        //            طرقالبيعToolStripMenuItem.Enabled = true;

        //            اعداداتالنظامالبيعToolStripMenuItem.Visible = true;
        //            اعداداتالنظامالبيعToolStripMenuItem.Enabled = true;

        //        }
        //        else
        //        {
        //            طرقالبيعToolStripMenuItem.Visible = false;
        //            طرقالبيعToolStripMenuItem.Enabled = false;

        //            اعداداتالنظامالبيعToolStripMenuItem.Visible = false;
        //            اعداداتالنظامالبيعToolStripMenuItem.Enabled = false;
        //        }

        //        انواعالمهنToolStripMenuItem.Visible = false;

        //        this.Text = " " + "الطموحات العقارية - بيع";
        //    }

        //    if (tabControl1.SelectedTab == this.tabPage4)
        //    {

        //        whatTab = "tab4";


        //        up.MdiParent = this;
        //        this.tabPage4.Controls.Add(up);


        //        up.Show();

        //        الاحصائياتToolStripMenuItem1.Visible = false;
        //        الهاتفToolStripMenuItem.Visible = true;

        //        الاحصائياتToolStripMenuItem.Visible = false;
        //        interToolStripMenuItem.Visible = false;
        //        archiveToolStripMenuItem.Visible = false;
        //        العقاراتToolStripMenuItem1.Visible = false;
        //        الأرشيفToolStripMenuItem.Visible = false;
        //        طرقالبيعToolStripMenuItem.Visible = false;
        //        اعداداتالنظامالبيعToolStripMenuItem.Visible = false;
        //        المهنToolStripMenuItem.Visible = false;
        //        انواعالمهنToolStripMenuItem.Visible = false;

        //        this.Text = " " + "الطموحات العقارية - الهاتف";
        //    }

        //    if (tabControl1.SelectedTab == this.tabPage3)
        //    {

        //        whatTab = "tab3";


        //        uc.MdiParent = this;
        //        this.tabPage3.Controls.Add(uc);
        //        uc.Show();

        //        الاحصائياتToolStripMenuItem1.Visible = false;
        //        المهنToolStripMenuItem.Visible = true;
        //        انواعالمهنToolStripMenuItem.Visible = true;

        //        الهاتفToolStripMenuItem.Visible = false;
        //        الاحصائياتToolStripMenuItem.Visible = false;
        //        interToolStripMenuItem.Visible = false;
        //        archiveToolStripMenuItem.Visible = false;
        //        العقاراتToolStripMenuItem1.Visible = false;
        //        الأرشيفToolStripMenuItem.Visible = false;
        //        طرقالبيعToolStripMenuItem.Visible = false;
        //        اعداداتالنظامالبيعToolStripMenuItem.Visible = false;

        //        this.Text = " " + "الطموحات العقارية - المهن";
        //    }


        //}
        private void tabControl1_Click(object sender, EventArgs e)
        {
            ClearUtils();

            if (tabControl1.SelectedTab == this.tabPage1)
            {
                whatTab = "tab1";
                if (u == null || u.IsDisposed)
                {
                    u = new FrmAlways();
                    u.MdiParent = this;
                    u.Dock = DockStyle.Fill;
                    tabPage1.Controls.Add(u);
                }
                u.Show();

                ToggleMenuForTab1();
                this.Text = " طموحات العقارية - ايجار";
            }
            else if (tabControl1.SelectedTab == this.tabPage2)
            {
                whatTab = "tab2";
                if (uo == null || uo.IsDisposed)
                {
                    uo = new alwaysOwner();
                    uo.MdiParent = this;
                    uo.Dock = DockStyle.Fill;
                    tabPage2.Controls.Add(uo);
                }
                uo.Show();

                ToggleMenuForTab2();
                this.Text = " طموحات العقارية - بيع";
            }
            else if (tabControl1.SelectedTab == this.tabPage4)
            {
                whatTab = "tab4";
                if (up == null || up.IsDisposed)
                {
                    up = new AlwaysPhone();
                    up.MdiParent = this;
                    up.Dock = DockStyle.Fill;
                    tabPage4.Controls.Add(up);
                }
                up.Show();

                ToggleMenuForTab4();
                this.Text = " طموحات العقارية - الهاتف";
            }

            else if (tabControl1.SelectedTab == this.tabPage3)
            {
                whatTab = "tab3";
                if (uc == null || uc.IsDisposed)
                {
                    uc = new alwaysCareer();
                    uc.MdiParent = this;
                    uc.Dock = DockStyle.Fill;
                    tabPage3.Controls.Add(uc);
                }
                uc.Show();

                ToggleMenuForTab3();
                this.Text = " طموحات العقارية - المهن";
            }
            else if (tabControl1.SelectedTab == this.tabPage6)
            {
                whatTab = "tab6";
                if (fp == null || fp.IsDisposed)
                {
                    fp = new FollowUp.FollowUp();
                    fp.MdiParent = this;
                    fp.Dock = DockStyle.Fill;
                    tabPage6.Controls.Add(fp);
                }
                fp.Show();

                ToggleMenuForTab6();
                this.Text = " طموحات العقارية - المتابعه";
            }
        }

        private void ToggleMenuForTab1()
        {
            الاحصائياتToolStripMenuItem.Visible = false;
            interToolStripMenuItem.Visible = false;
            archiveToolStripMenuItem.Visible = false;
            العقاراتToolStripMenuItem1.Visible = true;
            الأرشيفToolStripMenuItem.Visible = true;
            الاحصائياتToolStripMenuItem1.Visible = true;
            الهاتفToolStripMenuItem.Visible = false;
            طرقالبيعToolStripMenuItem.Visible = false;
            اعداداتالنظامالبيعToolStripMenuItem.Visible = false;
            انواعالمهنToolStripMenuItem.Visible = false;
            المهنToolStripMenuItem.Visible = false;

            if (Utils.current_user.ToLower() == "administrator")
            {
                اعداداتنظامالايجارToolStripMenuItem.Visible = true;
                اعداداتنظامالايجارToolStripMenuItem.Enabled = true;
            }
            else
            {
                اعداداتنظامالايجارToolStripMenuItem.Enabled = false;
                اعداداتنظامالايجارToolStripMenuItem.Visible = false;
            }

        }

        private void ToggleMenuForTab2()
        {
            الاحصائياتToolStripMenuItem.Visible = true;
            interToolStripMenuItem.Visible = true;
            archiveToolStripMenuItem.Visible = true;
            العقاراتToolStripMenuItem1.Visible = false;
            الأرشيفToolStripMenuItem.Visible = false;
            الاحصائياتToolStripMenuItem1.Visible = false;
            الهاتفToolStripMenuItem.Visible = false;
            المهنToolStripMenuItem.Visible = false;
            انواعالمهنToolStripMenuItem.Visible = false;
            اعداداتنظامالايجارToolStripMenuItem.Visible = false;

            if (Utils.current_user.ToLower() == "administrator")
            {
                طرقالبيعToolStripMenuItem.Visible = true;
                طرقالبيعToolStripMenuItem.Enabled = true;

                اعداداتالنظامالبيعToolStripMenuItem.Visible = true;
                اعداداتالنظامالبيعToolStripMenuItem.Enabled = true;

            }
            else
            {
                طرقالبيعToolStripMenuItem.Visible = false;
                طرقالبيعToolStripMenuItem.Enabled = false;

                اعداداتالنظامالبيعToolStripMenuItem.Visible = false;
                اعداداتالنظامالبيعToolStripMenuItem.Enabled = false;
            }

        }
        private void ToggleMenuForTab3()
        {
            المهنToolStripMenuItem.Visible = true;
            انواعالمهنToolStripMenuItem.Visible = true;
            الهاتفToolStripMenuItem.Visible = false;
            الاحصائياتToolStripMenuItem.Visible = false;
            interToolStripMenuItem.Visible = false;
            archiveToolStripMenuItem.Visible = false;
            العقاراتToolStripMenuItem1.Visible = false;
            الأرشيفToolStripMenuItem.Visible = false;
            طرقالبيعToolStripMenuItem.Visible = false;
            اعداداتالنظامالبيعToolStripMenuItem.Visible = false;
        }

        private void ToggleMenuForTab4()
        {
            الهاتفToolStripMenuItem.Visible = true;
            الاحصائياتToolStripMenuItem.Visible = false;
            interToolStripMenuItem.Visible = false;
            archiveToolStripMenuItem.Visible = false;
            العقاراتToolStripMenuItem1.Visible = false;
            الأرشيفToolStripMenuItem.Visible = false;
            طرقالبيعToolStripMenuItem.Visible = false;
            اعداداتالنظامالبيعToolStripMenuItem.Visible = false;
            المهنToolStripMenuItem.Visible = false;
            انواعالمهنToolStripMenuItem.Visible = false;
        }

        private void ToggleMenuForTab6()
        {
            المهنToolStripMenuItem.Visible = true;
            انواعالمهنToolStripMenuItem.Visible = true;
            الهاتفToolStripMenuItem.Visible = false;
            الاحصائياتToolStripMenuItem.Visible = false;
            interToolStripMenuItem.Visible = false;
            archiveToolStripMenuItem.Visible = false;
            العقاراتToolStripMenuItem1.Visible = false;
            الأرشيفToolStripMenuItem.Visible = false;
            طرقالبيعToolStripMenuItem.Visible = false;
            اعداداتالنظامالبيعToolStripMenuItem.Visible = false;
        }
        private void tabchange()
        {
            //always.Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            //always.Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            //alwaysOwner.Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            //alwaysOwner.Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));


            Utils.ORentRecord = false;
            Utils.ONameOfCustomer = "";
            Utils.OCustPhon = "";
            Utils.OCustMobile = "";
            Utils.OCusOther = "";
            Utils.ODTRealAppointinfo.Rows.Clear();
            Utils.OSortdDTRealAppointinfo.Clear();



            Utils.RentRecord = false;
            Utils.NameOfCustomer = "";
            Utils.CustPhon = "";
            Utils.CustMobile = "";
            Utils.CusOther = "";
            Utils.DTRealAppointinfo.Rows.Clear();
            Utils.SortdDTRealAppointinfo.Clear();


            if (tabControl1.SelectedTab == this.tabPage1)
            {
                whatTab = "tab1";


                //always.Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                u.MdiParent = this;
                this.tabPage1.Controls.Add(u);


                u.Show();

                الاحصائياتToolStripMenuItem.Visible = false;
                interToolStripMenuItem.Visible = false;
                archiveToolStripMenuItem.Visible = false;
                العقاراتToolStripMenuItem1.Visible = true;
                الأرشيفToolStripMenuItem.Visible = true;


                الهاتفToolStripMenuItem.Visible = false;
                طرقالبيعToolStripMenuItem.Visible = false;
                اعداداتالنظامالبيعToolStripMenuItem.Visible = false;
                انواعالمهنToolStripMenuItem.Visible = false;

                this.Text = " " + "طموحات العقارية - ايجار";
            }

            if (tabControl1.SelectedTab == this.tabPage2)
            {
                whatTab = "tab2";


                uo.MdiParent = this;
                this.tabPage2.Controls.Add(uo);

                uo.Show();


                الاحصائياتToolStripMenuItem.Visible = true;
                interToolStripMenuItem.Visible = true;
                archiveToolStripMenuItem.Visible = true;

                العقاراتToolStripMenuItem1.Visible = false;
                الأرشيفToolStripMenuItem.Visible = false;

                الهاتفToolStripMenuItem.Visible = false;
                المهنToolStripMenuItem.Visible = false;

                if (Utils.current_user.ToLower() == "administrator")
                {
                    طرقالبيعToolStripMenuItem.Visible = true;
                    طرقالبيعToolStripMenuItem.Enabled = true;

                    اعداداتالنظامالبيعToolStripMenuItem.Visible = true;
                    اعداداتالنظامالبيعToolStripMenuItem.Enabled = true;
                }
                else
                {

                    طرقالبيعToolStripMenuItem.Visible = true;
                    اعداداتالنظامالبيعToolStripMenuItem.Visible = true;
                }

                انواعالمهنToolStripMenuItem.Visible = false;

                this.Text = " " + "طموحات العقارية - بيع";
            }

            if (tabControl1.SelectedTab == this.tabPage4)
            {

                whatTab = "tab4";


                up.MdiParent = this;
                this.tabPage4.Controls.Add(up);
                up.Show();


                الهاتفToolStripMenuItem.Visible = true;

                الاحصائياتToolStripMenuItem.Visible = false;
                interToolStripMenuItem.Visible = false;
                archiveToolStripMenuItem.Visible = false;
                العقاراتToolStripMenuItem1.Visible = false;
                الأرشيفToolStripMenuItem.Visible = false;
                طرقالبيعToolStripMenuItem.Visible = false;
                اعداداتالنظامالبيعToolStripMenuItem.Visible = false;
                المهنToolStripMenuItem.Visible = false;
                انواعالمهنToolStripMenuItem.Visible = false;

                this.Text = " " + "طموحات العقارية - الهاتف";
            }




            if (tabControl1.SelectedTab == this.tabPage3)
            {

                whatTab = "tab3";


                uc.MdiParent = this;
                this.tabPage3.Controls.Add(uc);
                uc.Show();


                المهنToolStripMenuItem.Visible = true;
                انواعالمهنToolStripMenuItem.Visible = true;

                الهاتفToolStripMenuItem.Visible = false;
                الاحصائياتToolStripMenuItem.Visible = false;
                interToolStripMenuItem.Visible = false;
                archiveToolStripMenuItem.Visible = false;
                العقاراتToolStripMenuItem1.Visible = false;
                الأرشيفToolStripMenuItem.Visible = false;
                طرقالبيعToolStripMenuItem.Visible = false;
                اعداداتالنظامالبيعToolStripMenuItem.Visible = false;

                this.Text = " " + "طموحات العقارية - المهن";
            }


        }

        private void interToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealstateOwner re = new RealstateOwner();
            re.Text = " ادخال البيع";
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);

        }

        private void طرقالبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wayofown re = new wayofown();
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);
        }

        private void archiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealstateOwner arre = new RealstateOwner();
            //  u.MdiParent = this;
            arre.am = "archive";
            arre.Text = "أرشيف البيع";
            arre.ShowDialog();
            //ShowModalExcept(arre, MainForm.searchForm);
        }

        private void اعداداتالنظامالبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ownerSetting re = new ownerSetting();
            re.IsOwner = true;
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);
        }

        private void اعداداتنظامالايجارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ownerSetting re = new ownerSetting();
            re.IsOwner = false;
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);
        }

        private void الاحصائياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StaticTableAdapter.UpdateQueryAccess(DateTime.Now.Date);
            Statics re = new Statics();
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);


        }

        private void الهاتفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phone re = new phone();
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);
        }

        private void المهنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            career re = new career();
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);

        }

        private void انواعالمهنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CareerType re = new CareerType();
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {


            allsearch f = new allsearch(textBox1.Text);
            if (f.yes)
            {
                f.ShowDialog();
                //ShowModalExcept(f, MainForm.searchForm);
            }
            else
            {
                textBox1.Text = "";

            }


            if (!f.yes)
            {
                textBox1.Text = "";
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //13 = enter
            {

                button1.PerformClick();

            }
        }

        private void الاحصائياتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.RealStaticTableAdapter.UpdateQuery(DateTime.Now.Date);
            RealStatics re = new RealStatics();
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);
        }

        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Counting re = new Counting();
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
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

        private void تفيعلالتنبيهوالنسخةالاحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activesetting re = new activesetting();
            re.ShowDialog();
            //ShowModalExcept(re, MainForm.searchForm);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //13 = enter
            {
                if (textBox2.Text == "h")
                {
                    //    mod.SendCommandToModem("AT+VCID=1\r");
                }
                else
                {
                    mod.display(textBox2.Text);
                    //    mod.SendCommandToModem("ATD 0956690669\r");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calls c = new Calls();
            c.ShowDialog();
            //ShowModalExcept(c, MainForm.searchForm);
        }

        private void التنبيهاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notify();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage tabPage = tabControl.TabPages[e.Index];
            int currentTab = tabControl.SelectedIndex;
            bool isSelected = (tabControl.SelectedIndex == e.Index);

            Color color = Color.LightBlue;
            if (currentTab == 0)
                color = Color.FromArgb(188, 71, 73);
            else if (currentTab == 1)
                color = Color.FromArgb(45, 216, 129);
            else if (currentTab == 2)
                color = Color.FromArgb(250, 163, 7);
            else if (currentTab == 3)
                color = Color.FromArgb(0, 180, 216);
            else if (currentTab == 4)
                color = Color.FromArgb(153, 88, 42);
            else if (currentTab == 5)
                color = Color.FromArgb(0, 119, 182);
   

            Color backColor = isSelected ? color : SystemColors.Control;
            Color foreColor = isSelected ? Color.White : SystemColors.ControlText;
            Font font = isSelected ? new Font("Tahoma",9F, FontStyle.Bold) : new Font("Tahoma", 8F, FontStyle.Bold);

            using (Brush brush = new SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, e.Bounds);


            // تعديل الموضع: أضف padding داخلي (مثلاً للأسفل)
            Rectangle paddedBounds = new Rectangle(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height);

            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(e.Graphics, tabPage.Text, font,paddedBounds, foreColor, flags);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
