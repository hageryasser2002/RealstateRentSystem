using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.Collections;
using System.Configuration;
using RealStateRentSystem.DSTables;

namespace RealStateRentSystem
{
    public partial class PrintGried : Form
    {


        DataGridViewPrinter dataGridView1Printer;
        public DSTables.DSrealstateTableAdapters.RealStateTableAdapter RealStateTableAdapter = new DSTables.DSrealstateTableAdapters.RealStateTableAdapter();
        public DSTables.DSrealownerTableAdapters.RealstateOwneTableAdapter RealstateOwneTableAdapter = new DSTables.DSrealownerTableAdapters.RealstateOwneTableAdapter();

        public string name;
        public string phone;
        public string mobile;
        public string other;
        public DateTime date;
        public DateTime time;
        DataTable dt;
        string am;

        DataSet ds = null;
        DataTable dtgrid = null;


        public PrintGried(string pam)
        {
            InitializeComponent();
            am = pam;

            if (am == "rent")
            {

                name =  Utils.NameOfCustomer;
                phone = Utils.CustPhon;
                mobile = Utils.CustMobile;
                other = Utils.CusOther;
                date= Utils.appdate;
                time = Utils.apptime;
                dt = Utils.DTRealAppointinfo;

            }

            if (am == "own")
            {

                name = Utils.ONameOfCustomer;
                phone = Utils.OCustPhon;
                mobile = Utils.OCustMobile;
                other = Utils.OCusOther;
                date = Utils.Oappdate;
                time = Utils.Oapptime;
                dt = Utils.ODTRealAppointinfo;
            }
        }

        private void PrintGried_Load(object sender, EventArgs e)
        {



            DataTable Realdt;
            if (am == "rent")
            {
                dataGridView1.Rows.Add(Utils.SortdDTRealAppointinfo.Count);
                for (int h = 0; h < Utils.SortdDTRealAppointinfo.Count; h++)
                {
                    dataGridView1.Rows[h].Cells["Note"].Value = "";

                        Realdt = RealStateTableAdapter.GetAll(Convert.ToInt32(Utils.SortdDTRealAppointinfo.Keys[h]));
                    


                    if (Realdt.Rows[0]["SubResgionID"].ToString().Length > 12)
                    {
                        dataGridView1.Rows[h].Cells["st"].Value = Realdt.Rows[0]["SubResgionID"].ToString().Substring(0, 12);
                    }
                    else
                    {
                        dataGridView1.Rows[h].Cells["st"].Value = Realdt.Rows[0]["SubResgionID"].ToString();

                    }

                    if (Realdt.Rows[0]["Building"].ToString().Length > 25)
                    {
                        dataGridView1.Rows[h].Cells["b"].Value = Realdt.Rows[0]["Building"].ToString().Substring(0, 25);
                    }
                    else
                    {
                        dataGridView1.Rows[h].Cells["b"].Value = Realdt.Rows[0]["Building"].ToString();
                    }


                    if (Realdt.Rows[0]["FloorComment"].ToString().Length > 7)
                    {
                        dataGridView1.Rows[h].Cells["f"].Value = Realdt.Rows[0]["Floor"] + " " + Realdt.Rows[0]["FloorComment"].ToString().Substring(0, 9);

                    }
                    else if (Realdt.Rows[0]["FloorComment"].ToString().Length == 7)
                    {
                        dataGridView1.Rows[h].Cells["f"].Value = Realdt.Rows[0]["Floor"] + " " + Realdt.Rows[0]["FloorComment"].ToString().Substring(0, 7);
                    }
                    else
                    {

                        dataGridView1.Rows[h].Cells["f"].Value = Realdt.Rows[0]["Floor"] + " " + Realdt.Rows[0]["FloorComment"].ToString();
                    }


                    if (Realdt.Rows[0]["Owner"].ToString().Length > 11)
                    {
                        dataGridView1.Rows[h].Cells["n"].Value = Realdt.Rows[0]["Owner"].ToString().Substring(0, 11);

                    }
                    else
                    {
                        dataGridView1.Rows[h].Cells["n"].Value = Realdt.Rows[0]["Owner"].ToString();

                    }


                    dataGridView1.Rows[h].Cells["ph"].Value = Realdt.Rows[0]["Phone_one"];
                    dataGridView1.Rows[h].Cells["ph2"].Value = Realdt.Rows[0]["Phone_Two"];
                    dataGridView1.Rows[h].Cells["mop"].Value = Realdt.Rows[0]["Mobile"];
                    //dataGridView1.Rows[h].Cells["o"].Value = Realdt.Rows[0]["Other"];

                    dataGridView1.Rows[h].Cells["enter"].Value = Realdt.Rows[0]["Entrance"];
                    dataGridView1.Rows[h].Cells["dis"].Value = Realdt.Rows[0]["Distance"];

                    dataGridView1.Rows[h].Cells["a"].Value = Realdt.Rows[0]["area"];
                    dataGridView1.Rows[h].Cells["Price"].Value = Realdt.Rows[0]["Price"];
                    dataGridView1.Rows[h].Cells["da"].Value = "";


                }
            }
            else //// own
            {
                dataGridView1.Rows.Add(Utils.OSortdDTRealAppointinfo.Count);

                for (int h = 0; h < Utils.OSortdDTRealAppointinfo.Count; h++)
                {
                    dataGridView1.Rows[h].Cells["Note"].Value = "";
                        Realdt = RealstateOwneTableAdapter.GetDataAll(Convert.ToInt32(Utils.OSortdDTRealAppointinfo.Keys[h]));
                    if (Realdt.Rows[0]["SubResgionID"].ToString().Length > 12)
                    {
                        dataGridView1.Rows[h].Cells["st"].Value = Realdt.Rows[0]["SubResgionID"].ToString().Substring(0, 12);
                    }
                    else
                    {
                        dataGridView1.Rows[h].Cells["st"].Value = Realdt.Rows[0]["SubResgionID"].ToString();

                    }

                    if (Realdt.Rows[0]["Building"].ToString().Length > 25)
                    {
                        dataGridView1.Rows[h].Cells["b"].Value = Realdt.Rows[0]["Building"].ToString().Substring(0, 25);
                     } 
                    else
                    {
                        dataGridView1.Rows[h].Cells["b"].Value = Realdt.Rows[0]["Building"].ToString();
                    }


                    if (Realdt.Rows[0]["FloorComment"].ToString().Length > 7)
                    {
                        dataGridView1.Rows[h].Cells["f"].Value = Realdt.Rows[0]["Floor"] + " " + Realdt.Rows[0]["FloorComment"].ToString().Substring(0, 9);

                    }
                    else if (Realdt.Rows[0]["FloorComment"].ToString().Length == 7)
                    {
                        dataGridView1.Rows[h].Cells["f"].Value = Realdt.Rows[0]["Floor"] + " " + Realdt.Rows[0]["FloorComment"].ToString().Substring(0, 7);
                    }
                    else
                    {

                        dataGridView1.Rows[h].Cells["f"].Value = Realdt.Rows[0]["Floor"] + " " + Realdt.Rows[0]["FloorComment"].ToString();
                    }


                    if (Realdt.Rows[0]["Owner"].ToString().Length > 11)
                    {
                        dataGridView1.Rows[h].Cells["n"].Value = Realdt.Rows[0]["Owner"].ToString().Substring(0, 11);

                    }
                    else
                    {
                        dataGridView1.Rows[h].Cells["n"].Value = Realdt.Rows[0]["Owner"].ToString();

                    }


                    dataGridView1.Rows[h].Cells["ph"].Value = Realdt.Rows[0]["Phone_one"];
                    dataGridView1.Rows[h].Cells["ph2"].Value = Realdt.Rows[0]["Phone_Two"];
                    dataGridView1.Rows[h].Cells["mop"].Value = Realdt.Rows[0]["Mobile"];
                    dataGridView1.Rows[h].Cells["o"].Value = Realdt.Rows[0]["Other"];


                

                    dataGridView1.Rows[h].Cells["enter"].Value = Realdt.Rows[0]["Entrance"];
                    dataGridView1.Rows[h].Cells["dis"].Value = Realdt.Rows[0]["Distance"];

                    dataGridView1.Rows[h].Cells["a"].Value = Realdt.Rows[0]["area"];
                    dataGridView1.Rows[h].Cells["Price"].Value = Realdt.Rows[0]["Price"];
                    dataGridView1.Rows[h].Cells["da"].Value = "";


                }
            }


            

            dataGridView1.Refresh();


        }


        


     
        private void button1_Click(object sender, EventArgs e)
        {
            
                if (SetupThePrinting())
                    MyPrintDocument.Print();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
            
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dataGridView1Printer.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }


        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = true;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            //if (MyPrintDialog.ShowDialog() != DialogResult.OK)
            //    return false;

            
            MyPrintDocument.DocumentName = " ";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(2, 2, 20, 20);

            
            
            


            //\r\n
            //if (MessageBox.Show("Do you want the report to be centered on the page", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            dataGridView1Printer = new DataGridViewPrinter(dataGridView1, MyPrintDocument, true, true,"الرقم : "+ Utils.LastIDApp() + "\r\n" + date.ToShortDateString() + "," + time.ToShortTimeString() + "," + other + "," + mobile + "," + phone + "," + name, new Font("Tahoma", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Black, false);
            //else
              //  dataGridView1Printer = new DataGridViewPrinter(dataGridView1, MyPrintDocument, false, true, date.ToShortDateString() + "," + time.ToShortTimeString() + "," + other + "," + mobile + "," + phone + "," + Utils.LastIDApp() + "," + name, new Font("Tahoma", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
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


            }
            return false;

        }


        
        

       

    }
}


