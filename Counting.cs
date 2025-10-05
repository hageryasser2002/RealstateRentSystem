using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;
using System.Security;

namespace RealStateRentSystem
{
    public partial class Counting : Form
    {
        public Counting()
        {
            InitializeComponent();
        }

        private void Counting_Load(object sender, EventArgs e)
        {
            textBox1.Text = getBuilding("RealState", 1).ToString();
            textBox2.Text = getBuilding("RealState", 0).ToString();
            textBox3.Text = getBuilding("RealstateOwne", 1).ToString();
            textBox4.Text = getBuilding("RealstateOwne", 0).ToString();
            textBox5.Text = getcoun("career").ToString();
            textBox6.Text = getcoun("phone").ToString();
            

        }

        public int getBuilding(string table,int active)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT count(id) as ids FROM "+table+" where active="+active;
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
                if (dt.Rows.Count > 0)
                {

                    return Convert.ToInt32(dt.Rows[0]["ids"].ToString());

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

           
        }

        public int getcoun(string table)
        {
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT count(id) as ids FROM " + table;
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
                if (dt.Rows.Count > 0)
                {

                    return Convert.ToInt32(dt.Rows[0]["ids"].ToString());

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
                return base.ProcessDialogKey(keyData);

        }



    }
}
