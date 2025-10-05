using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Data.OleDb;
using RealStateRentSystem_Buisness;


namespace RealStateRentSystem
{
    /// <summary>
    /// Base class for communication with modem. 
    /// All concrete model modem sub-classes should inherit this base class.
    /// </summary>
    public class Modem
    {
        #region structs

        private DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter realStateTableAdapter = new DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter();
        private DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter RealStateTableAdaptersearch = new DSTables.DSrealstatesearchTableAdapters.RealStateTableAdapter();
        DSTables.DSphoneTableAdapters.PhoneTableAdapter PhoneTableAdapter = new DSTables.DSphoneTableAdapters.PhoneTableAdapter();
        DSTables.DSrealstateTableAdapters.RealStateTableAdapter RealStateTableAdapter = new DSTables.DSrealstateTableAdapters.RealStateTableAdapter();
        DSTables.DScareerTableAdapters.careerTableAdapter careerTableAdapter = new DSTables.DScareerTableAdapters.careerTableAdapter();
        DSTables.DSCallsTableAdapters.CallsRegistrayTableAdapter CallsRegistrayTableAdapter = new DSTables.DSCallsTableAdapters.CallsRegistrayTableAdapter();


        DataTable odt = new DataTable();
        DataTable dtphone = new DataTable();
        DataTable dtrent = new DataTable();
        DataTable dtown = new DataTable();
        DataTable dtcareer = new DataTable();

        public struct AttachedModem
        {
            public string Port;
            public string ModemModel;
        }

        #endregion

        #region private fields

        private SerialPort _port;
        private string _pname = "";
        private int _boudrate = 0;
        private string _answer;
        private SetCallback _call = null;

        #endregion

        #region delegates

        public delegate void SetCallback(Modem modcall);

        #endregion

        #region properties

        // COM port name
        public string PortNumber
        {
            get { return _pname; }
            set { _pname = value; }
        }

        // Port Boudrate
        public string PortBoudrate
        {
            get { return _boudrate.ToString(); }
            set { _boudrate = int.Parse(value); }
        }

        // Default boudrate read-only
        public virtual int DefaultBoudrate
        {
            get { return 9600; }
        }

        // Modem answer to command, field only read-only
        public string ModemAnswer
        {
            get { return _answer; }
        }

        #endregion

        #region constructors

        // First constructor
        public Modem(SerialPort prt, SetCallback c)
        {
            
            _call = c;
            _port = prt;
            _port.DataReceived += new SerialDataReceivedEventHandler(this.DataReceived);
            if (_pname == "") _pname = Modem.FirstAttachedModem().Port;
            if (_boudrate == 0) _boudrate = this.DefaultBoudrate;



            OpenModem();

            
        }
        // Second constructor
        public Modem(SerialPort prt, string prtnum, SetCallback c)
        {
            _call = c;
            _port = prt;
            _port.DataReceived += new SerialDataReceivedEventHandler(this.DataReceived);
            this.PortNumber = prtnum;
            this.PortBoudrate = this.DefaultBoudrate.ToString();
            OpenModem();


            odt = new DataTable();
            odt.Columns.Add("number", typeof(string));
            odt.Columns.Add("date", typeof(DateTime));
            odt.Columns.Add("name", typeof(string));
            odt.Columns.Add("place", typeof(string));
            odt.Columns.Add("placeID", typeof(string));
            odt.Columns.Add("numbertype", typeof(string));


        }
        /*
        Third constructor parameterless - this means that there will be no
        modem answer delegate (null). This in turn results that UI will not 
        see modem initialization and answer events.
        */
        public Modem() : this(new SerialPort(), null) { }

        #endregion

        #region non-virtual methods

        // Method which will call delegate. This delegate 
        // can be fired not on every DataReceived event.
        private void AnalyzeAnswer()
        {
            if (_answer.Length > 0 && _call != null)
            {
                _call(this);
            }
        }

        // Opening modem port
        private void OpenModem()
        {
            this.CloseModem();
            _port.PortName = _pname;
            _port.BaudRate = _boudrate;


            _port.Open();
            //MessageBox.Show("Port is open ");



            this.InitializeModem();

           

        }

        // Closing modem port
        public void CloseModem()
        {
            if (_port.IsOpen) _port.Close();
        }

        // Sending command to modem port, needs to be marked as 'protected'
        // for being seen in sub-classes
        public void SendCommandToModem(string command)
        {
            _answer = "";
            if (!_port.IsOpen) this.OpenModem();
            _port.Write(command);
        }

        #endregion

        #region virtual methods

        // Modem initialization, basic AT commands. E0 means echo off.
        protected virtual void InitializeModem()
        {
            this.SendCommandToModem("AT+VCID=1\r");
        }

        // Finding modem manufacturer, AT command I4.
        public virtual void GetManufacturer()
        {
            this.SendCommandToModem("ATI4\r");
        }

        // Finding modem product Id, AT command I0.
        public virtual void GetProductId()
        {
            this.SendCommandToModem("ATI0\r");
        }

        #endregion

        #region static methods

        // Method for searching connected modem on COM ports.
        // Returns modem manufacturer, modem chipset version
        // (with AT commands I4I3) and COM port on which modem exists.
        public static AttachedModem FirstAttachedModem()
        {
            AttachedModem am = new AttachedModem();
            SerialPort sp = new SerialPort();
            string port, answer;

            for (int i = 1; i <= 8; i++)
            {
                port = "COM" + i.ToString();
                sp.PortName = port;
                sp.BaudRate = 9600;

                try
                {
                    sp.Open();
                    if (sp.IsOpen)
                    {
                        sp.Write("ATE0\r");
                        Thread.Sleep(200);
                        answer = sp.ReadExisting().Replace("ATE0", "").Trim().ToUpper();
                        if (answer == "OK")
                        {
                            sp.Write("ATI4I3\r");
                            Thread.Sleep(200);
                            answer = sp.ReadExisting().Trim().ToUpper().Replace("\r\nOK", "").Trim().Replace("\r\n", "");
                            am.Port = port;
                            am.ModemModel = answer;
                            sp.Close();
                            break;
                        }
                    }
                    if (sp.IsOpen) sp.Close();
                }
                catch (Exception) { }
            }

            return am;
        }

        #endregion

        #region events


        public void Call(string number)
        {
            this.SendCommandToModem("ATD " + number + "\r");
        }

        public void CancelCall()
        {
            this.SendCommandToModem("AT+VCID=1\r");
        }

        // Event when signal is received on COM port data pins. Usually 8 pins.
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //_answer = _port.ReadExisting().Trim().Replace("\r\n\r\n","\r\n");
            //this.AnalyzeAnswer();

            display(_port.ReadExisting());
        }


        Notification notifForm;
        string Createname = "";
        string Createplace = "";
        string CreateplaceIds = "";
        string cleanenumber = "";

        public void display(string Data)
        {

            //Console.WriteLine(Data);
            string[] tt = Data.Split(' ');
            //MessageBox.Show(tt[0]);

            if (tt.Length >= 6)
            {

                if (Data != "" && Data != null)
                {
                    string number = tt[6].Substring(0, tt[6].LastIndexOf("\r"));
            //          string number = Data;
                    double Num;
                    bool isNum = double.TryParse(number, out Num);
                    if (isNum)
                    {
                        if (number.StartsWith("09"))
                        {
                            //  MessageBox.Show("Its Mobile " + number);
                            exact(number, "mop", DateTime.Now);
                        }
                        else if (number.StartsWith("011"))
                        {
                            if (number.Length == 3 + Utils.PhoneNumerLength)
                            {
                                //MessageBox.Show("Its LandLine " + number.Remove(0,3));
                                exact(number.Remove(0, 3), "land", DateTime.Now);
                            }
                            else if (number.Length == 3 + Utils.PhoneNumerLength + 1)
                            {
                                //MessageBox.Show("other " + number);
                                exact(number, "other", DateTime.Now);
                            }

                        }
                        else if (number.StartsWith("+") || number.StartsWith("00"))
                        {
                            //MessageBox.Show("Other");
                            exact(number, "other", DateTime.Now);
                        }
                        else
                        {
                            //MessageBox.Show("Other");
                            exact(number, "other", DateTime.Now);
                        }

                        string value = " الرقم   : " + cleanenumber + "\n الاسم  : " + Createname + "\n الموقع : " + Createplace.Trim(',');


                        if (Notification.active == true)
                        {
                            MainForm.DownToolTip(notifForm);
                            notifForm = new Notification(value,Utils.LastIDCall());
                            MainForm.UpToolTip(notifForm);
                        }
                        if (Notification.active == false)
                        {
                            notifForm = new Notification(value, Utils.LastIDCall());
                            MainForm.UpToolTip(notifForm);
                        }

                        
                        notifForm.ShowDialog();

                        Createname = "";
                        Createplace = "";
                        CreateplaceIds = "";
                        cleanenumber = "";

                    }// if not number


                }


            }


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

            // deplicate
           // if (odt.Rows.Count > 0)
            {
                DateTime tt = DateTime.Now;
                //if (CallsRegistrayTableAdapter.GetDataCheck(tt, cleanenumber).Count <= 0)
                if (Utils.backup == true) // backup with deplicate number
                {
                    if (!clsDeviceSettings.CanSaveCalls())
                        return;

                   // if (CallsRegistrayTableAdapter.GetDataBychecktwo(tt.AddSeconds(-55), tt.AddSeconds(-55), cleanenumber).Count <= 0)
                   // {
                        CallsRegistrayTableAdapter.Insert(
                        cleanenumber,
                        tt,
                        Createname,
                        Createplace,
                        CreateplaceIds,
                        type
                        , " ", tt);
                  //  }


                    //else
                    //{

                      //  CallsRegistrayTableAdapter.Insert(
                      //  cleanenumber,
                      //  DateTime.Now,
                      //  "",
                      //  "",
                      //  type, " ", DateTime.Now);

                   // }
                }

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
        #endregion
    }
}
