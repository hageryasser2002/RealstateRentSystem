using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class Calls : Form
    {
        public Boolean go = false;
        public Calls()
        {
            InitializeComponent();
            go = true;
            ///Added Code For Change Border Color
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Padding = new Padding(2); // مسافة بسيطة للإطار الداخلي

            this.Paint += (s, e) =>
            {
                using (Pen borderPen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawRectangle(borderPen, new Rectangle(1, 1, this.ClientSize.Width - 2, this.ClientSize.Height - 2));
                }
            };
        }

        private void callsRegistrayBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //if (!Properties.Settings.Default.IsWriterDevice)
            //{
            //   // MessageBox.Show("تم تعطيل الحفظ في قاعدة البيانات من هذا الجهاز من خلال الإعدادات.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (!clsDeviceSettings.CanSaveCalls())
                return;

            this.Validate();
            this.callsRegistrayBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSCalls);

        }

        private void Calls_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSCalls.CallsRegistray' table. You can move, or remove it, as needed.
            this.callsRegistrayTableAdapter.Fill(this.dSCalls.CallsRegistray);

            mo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(198)))), ((int)(((byte)(137)))));
            mo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
            mo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));

            st1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));// System.Drawing.Color.ForestGreen;
            st2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(208)))), ((int)(((byte)(247))))); //System.Drawing.Color.LimeGreen;
            st2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(208)))), ((int)(((byte)(247))))); //System.Drawing.Color.LimeGreen;

            f1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            f1.ForeColor = System.Drawing.Color.Black;
            f2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            f2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));

            st1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));// System.Drawing.Color.ForestGreen;
            st2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(208)))), ((int)(((byte)(247))))); //System.Drawing.Color.LimeGreen;
            st2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(208)))), ((int)(((byte)(247))))); //System.Drawing.Color.LimeGreen;

            sn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(223)))), ((int)(((byte)(155)))));
            sn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(199)))), ((int)(((byte)(63)))));
            sn2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(199)))), ((int)(((byte)(63)))));

            t1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(134)))), ((int)(((byte)(190)))));
            t2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(100)))), ((int)(((byte)(169)))));
            t2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(100)))), ((int)(((byte)(169)))));


            we1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(124)))), ((int)(((byte)(82)))));
            we2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(178)))), ((int)(((byte)(154)))));
            we2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(178)))), ((int)(((byte)(154)))));

            k1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(154)))), ((int)(((byte)(194)))));// System.Drawing.Color.ForestGreen;
            k2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(110)))), ((int)(((byte)(170))))); //System.Drawing.Color.LimeGreen;
            k2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(110)))), ((int)(((byte)(170))))); //System.Drawing.Color.LimeGreen;
        }

        private void callsRegistrayDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (go)
            {
                for (int i = 0; i < callsRegistrayDataGridView.Rows.Count; i++)
                {
                    if (callsRegistrayDataGridView.Rows[i].Cells[6].Value.ToString() != "" && callsRegistrayDataGridView.Rows[i].Cells[6].Value.ToString() != null)
                    {
                        string[] places = callsRegistrayDataGridView.Rows[i].Cells[6].Value.ToString().Split(',');

                        callsRegistrayBindingSource.Position = i;

                        if (places.Length == 2)
                        {
                            callsRegistrayDataGridView.Rows[i].Cells[6].Value = places[1].ToString().Trim(',');
                        }


                    }
                }


                for (int i = 0; i < callsRegistrayDataGridView.Rows.Count; i++)
                {
                    if (callsRegistrayDataGridView.Rows[i].Cells[5].Value.ToString() != "" && callsRegistrayDataGridView.Rows[i].Cells[5].Value.ToString() != null)
                    {
                        DateTime date = Convert.ToDateTime(callsRegistrayDataGridView.Rows[i].Cells[5].Value.ToString());

                        callsRegistrayBindingSource.Position = i;

                        if (date.DayOfWeek.ToString() == "Saturday")
                        {
                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
                            {
                                if (i % 2 == 0)
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));// System.Drawing.Color.ForestGreen;
                                }
                                else
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(208)))), ((int)(((byte)(247))))); //System.Drawing.Color.LimeGreen;
                                }

                                callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

                            }



                        }
                        if (date.DayOfWeek.ToString() == "Sunday")
                        {

                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
                            {
                                if (i % 2 == 0)
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(223)))), ((int)(((byte)(155)))));
                                }
                                else
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(199)))), ((int)(((byte)(63)))));
                                }

                                callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

                            }






                        }
                        if (date.DayOfWeek.ToString() == "Monday")
                        {
                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
                            {
                                if (i % 2 == 0)
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(198)))), ((int)(((byte)(137)))));
                                }
                                else
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
                                }

                                //                            callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

                            }



                        }
                        if (date.DayOfWeek.ToString() == "Tuesday")
                        {
                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
                            {
                                if (i % 2 == 0)
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(134)))), ((int)(((byte)(190)))));
                                }
                                else
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(100)))), ((int)(((byte)(169)))));
                                }

                                //                          callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

                            }


                        }
                        if (date.DayOfWeek.ToString() == "Wednesday")
                        {
                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
                            {
                                if (i % 2 == 0)
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(124)))), ((int)(((byte)(82)))));
                                }
                                else
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(178)))), ((int)(((byte)(154)))));
                                }

                                //                        callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

                            }


                        }
                        if (date.DayOfWeek.ToString() == "Thursday")
                        {
                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
                            {
                                if (i % 2 == 0)
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(154)))), ((int)(((byte)(194)))));// System.Drawing.Color.ForestGreen;
                                }
                                else
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(110)))), ((int)(((byte)(170))))); //System.Drawing.Color.LimeGreen;
                                }

                                //                      callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

                            }

                        }

                        if (date.DayOfWeek.ToString() == "Friday")
                        {
                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
                            {
                                if (i % 2 == 0)
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                                }
                                else
                                {
                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
                                }

                                //                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

                            }


                        }
                    }
                }

                if (callsRegistrayDataGridView.Rows.Count > 0)
                {

                    callsRegistrayDataGridView.CurrentCell = callsRegistrayDataGridView[1, 0];
                    callsRegistrayDataGridView.Refresh();
                }


            }


        }


        string realid = "";
        string phoneid = "";
        string ownid = "";
        string careerid = "";

        private void callsRegistrayDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 1)
            {
                if (callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[7].Value.ToString() != "" && callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[7].Value != null)
                {

                    string[] placesid = callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[7].Value.ToString().Split(',');

                    for (int t = 0; t < placesid.Length; t++)
                    {

                        if (placesid[t].StartsWith("m"))
                        {
                            careerid += placesid[t].Remove(0, 1) + ",";

                        }

                        if (placesid[t].StartsWith("r"))
                        {
                            realid += placesid[t].Remove(0, 1) + ",";

                        }

                        if (placesid[t].StartsWith("o"))
                        {
                            ownid += placesid[t].Remove(0, 1) + ",";

                        }

                        if (placesid[t].StartsWith("p"))
                        {
                            phoneid += placesid[t].Remove(0, 1) + ",";

                        }

                    }


                    OpenPhoneRecords op = new OpenPhoneRecords(realid, ownid, careerid, phoneid);
                    op.ShowDialog();

                    realid = "";
                    phoneid = "";
                    ownid = "";
                    careerid = "";
                }

            }


            if (e.ColumnIndex == 9)
            {
                Utils.CallName = "";
                Utils.CallPlace = "";
                Utils.CallPlaceID = "";


                AddToPhone at = new AddToPhone(callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString(), callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[10].Value.ToString());
                at.ShowDialog();
                if (Utils.CallName != "" && Utils.CallPlace != "" && Utils.CallPlaceID != "")
                {
                    callsRegistrayTableAdapter.UpdateQueryphone(Utils.CallName, Utils.CallPlace, Utils.CallPlaceID, Convert.ToInt32(callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[0].Value));
                    callsRegistrayDataGridView.DataSource = this.callsRegistrayBindingSource;
                    //                    callsRegistrayBindingNavigatorSaveItem.PerformClick();
                    this.callsRegistrayTableAdapter.Fill(this.dSCalls.CallsRegistray);

                }




            }

            if (e.ColumnIndex == 11)
            {

                if (Utils.mode != null)
                {

                    double Num;
                    bool isNum = double.TryParse(callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString(), out Num);
                    if (isNum)
                    {
                        Utils.mode.Call(callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString());
                        Redail.ShowMe();

                    }


                }
            }



        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {

                if (keyData == Keys.Escape)
                {


                    this.Validate();
                    this.callsRegistrayBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.dSCalls);

                    this.Close();
                }


            }

            return false;


        }

        private void Calls_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void Calls_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (callsRegistrayBindingSource.Count > 0)
            {
                //   callsRegistrayBindingNavigatorSaveItem.PerformClick();

                this.Validate();
                this.callsRegistrayBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.dSCalls);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArchivedCalls cl = new ArchivedCalls();
            cl.ShowDialog();
        }

        private void callsRegistrayDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //string value = callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[8].Value.ToString();
            //int id = Convert.ToInt32(callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[0].Value.ToString());

            //this.callsRegistrayTableAdapter.UpdateQuery(value, id);
            //this.callsRegistrayTableAdapter.Fill(this.dSCalls.CallsRegistray);
        }

        private void callsRegistrayDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            go = false;
        }




    }
}







//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//namespace RealStateRentSystem
//{
//    public partial class Calls : Form
//    {
//        public Boolean go = false;
//        public Calls()
//        {
//            InitializeComponent();
//            go = true;

//            ///Added Code For Change Border Color
//            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
//            this.Padding = new Padding(2); // مسافة بسيطة للإطار الداخلي

//            this.Paint += (s, e) =>
//            {
//                using (Pen borderPen = new Pen(Color.Black, 2))
//                {
//                    e.Graphics.DrawRectangle(borderPen, new Rectangle(1, 1, this.ClientSize.Width - 2, this.ClientSize.Height - 2));
//                }
//            };

//        }

//        private void callsRegistrayBindingNavigatorSaveItem_Click(object sender, EventArgs e)
//        {
//            this.Validate();
//            this.callsRegistrayBindingSource.EndEdit();
//            this.tableAdapterManager.UpdateAll(this.dSCalls);

//        }

//        private void Calls_Load(object sender, EventArgs e)
//        {
//            // TODO: This line of code loads data into the 'dSCalls.CallsRegistray' table. You can move, or remove it, as needed.
//            this.callsRegistrayTableAdapter.Fill(this.dSCalls.CallsRegistray);

//            mo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(198)))), ((int)(((byte)(137)))));
//            mo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
//            mo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));

//            st1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));// System.Drawing.Color.ForestGreen;
//            st2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(208)))), ((int)(((byte)(247))))); //System.Drawing.Color.LimeGreen;
//            st2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(208)))), ((int)(((byte)(247))))); //System.Drawing.Color.LimeGreen;

//            f1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
//            f1.ForeColor = System.Drawing.Color.Black;
//            f2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
//            f2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));

//            st1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));// System.Drawing.Color.ForestGreen;
//            st2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(208)))), ((int)(((byte)(247))))); //System.Drawing.Color.LimeGreen;
//            st2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(208)))), ((int)(((byte)(247))))); //System.Drawing.Color.LimeGreen;

//            sn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(223)))), ((int)(((byte)(155)))));
//            sn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(199)))), ((int)(((byte)(63)))));
//            sn2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(199)))), ((int)(((byte)(63)))));

//            t1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(134)))), ((int)(((byte)(190)))));
//            t2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(100)))), ((int)(((byte)(169)))));
//            t2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(100)))), ((int)(((byte)(169)))));


//            we1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(124)))), ((int)(((byte)(82)))));
//            we2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(178)))), ((int)(((byte)(154)))));
//            we2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(178)))), ((int)(((byte)(154)))));

//            k1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(154)))), ((int)(((byte)(194)))));// System.Drawing.Color.ForestGreen;
//            k2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(110)))), ((int)(((byte)(170))))); //System.Drawing.Color.LimeGreen;
//            k2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(110)))), ((int)(((byte)(170))))); //System.Drawing.Color.LimeGreen;
//        }

//        private void callsRegistrayDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
//        {
//            if (go)
//            {
//                for (int i = 0; i < callsRegistrayDataGridView.Rows.Count; i++)
//                {
//                    if (callsRegistrayDataGridView.Rows[i].Cells[6].Value.ToString() != "" && callsRegistrayDataGridView.Rows[i].Cells[6].Value.ToString() != null)
//                    {
//                        string[] places = callsRegistrayDataGridView.Rows[i].Cells[6].Value.ToString().Split(',');

//                        callsRegistrayBindingSource.Position = i;

//                        if (places.Length == 2)
//                        {
//                            callsRegistrayDataGridView.Rows[i].Cells[6].Value = places[1].ToString().Trim(',');
//                        }


//                    }
//                }


//                for (int i = 0; i < callsRegistrayDataGridView.Rows.Count; i++)
//                {
//                    if (callsRegistrayDataGridView.Rows[i].Cells[5].Value.ToString() != "" && callsRegistrayDataGridView.Rows[i].Cells[5].Value.ToString() != null)
//                    {
//                        DateTime date = Convert.ToDateTime(callsRegistrayDataGridView.Rows[i].Cells[5].Value.ToString());

//                        callsRegistrayBindingSource.Position = i;

//                        if (date.DayOfWeek.ToString() == "Saturday")
//                        {
//                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
//                            {
//                                if (i % 2 == 0)
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));// System.Drawing.Color.ForestGreen;
//                                }
//                                else
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(208)))), ((int)(((byte)(247))))); //System.Drawing.Color.LimeGreen;
//                                }

//                                callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

//                            }



//                        }
//                        if (date.DayOfWeek.ToString() == "Sunday")
//                        {

//                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
//                            {
//                                if (i % 2 == 0)
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(223)))), ((int)(((byte)(155)))));
//                                }
//                                else
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(199)))), ((int)(((byte)(63)))));
//                                }

//                                callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

//                            }






//                        }
//                        if (date.DayOfWeek.ToString() == "Monday")
//                        {
//                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
//                            {
//                                if (i % 2 == 0)
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(198)))), ((int)(((byte)(137)))));
//                                }
//                                else
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
//                                }

//                                //                            callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

//                            }



//                        }
//                        if (date.DayOfWeek.ToString() == "Tuesday")
//                        {
//                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
//                            {
//                                if (i % 2 == 0)
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(134)))), ((int)(((byte)(190)))));
//                                }
//                                else
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(100)))), ((int)(((byte)(169)))));
//                                }

//                                //                          callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

//                            }


//                        }
//                        if (date.DayOfWeek.ToString() == "Wednesday")
//                        {
//                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
//                            {
//                                if (i % 2 == 0)
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(124)))), ((int)(((byte)(82)))));
//                                }
//                                else
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(178)))), ((int)(((byte)(154)))));
//                                }

//                                //                        callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

//                            }


//                        }
//                        if (date.DayOfWeek.ToString() == "Thursday")
//                        {
//                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
//                            {
//                                if (i % 2 == 0)
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(154)))), ((int)(((byte)(194)))));// System.Drawing.Color.ForestGreen;
//                                }
//                                else
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(110)))), ((int)(((byte)(170))))); //System.Drawing.Color.LimeGreen;
//                                }

//                                //                      callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

//                            }

//                        }

//                        if (date.DayOfWeek.ToString() == "Friday")
//                        {
//                            for (int y = 0; y < callsRegistrayDataGridView.Rows[i].Cells.Count; y++)
//                            {
//                                if (i % 2 == 0)
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
//                                }
//                                else
//                                {
//                                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
//                                }

//                                //                    callsRegistrayDataGridView.Rows[i].Cells[y].Style.ForeColor = System.Drawing.Color.Black;

//                            }


//                        }
//                    }
//                }

//                if (callsRegistrayDataGridView.Rows.Count > 0)
//                {

//                    callsRegistrayDataGridView.CurrentCell = callsRegistrayDataGridView[1, 0];
//                    callsRegistrayDataGridView.Refresh();
//                }


//            }


//        }


//            string realid = "";
//            string phoneid = "";
//            string  ownid="";
//            string careerid = "";

//        private void callsRegistrayDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {

//            if (e.ColumnIndex == 1)
//            {
//                if (callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[7].Value.ToString() != "" && callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[7].Value!=null)
//                {

//                    string[] placesid = callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[7].Value.ToString().Split(',');

//                    for(int t=0;t<placesid.Length;t++)
//                    {

//                        if(placesid[t].StartsWith("m"))
//                        {
//                            careerid+=placesid[t].Remove(0,1)+",";

//                        }

//                        if (placesid[t].StartsWith("r"))
//                        {
//                            realid += placesid[t].Remove(0, 1) + ",";

//                        }

//                        if (placesid[t].StartsWith("o"))
//                        {
//                            ownid += placesid[t].Remove(0, 1) + ",";

//                        }

//                        if (placesid[t].StartsWith("p"))
//                        {
//                            phoneid += placesid[t].Remove(0, 1) + ",";

//                        }

//                    }


//                    OpenPhoneRecords op = new OpenPhoneRecords(realid, ownid, careerid, phoneid);
//                    op.ShowDialog();
//                    //ShowModalExcept(op, MainForm.searchForm);

//                    realid = "";
//                    phoneid = "";
//                    ownid = "";
//                    careerid = "";
//                 }

//                }


//            if (e.ColumnIndex == 9)
//            {
//                Utils.CallName = "";
//                Utils.CallPlace = "";
//                Utils.CallPlaceID = "";


//                AddToPhone at = new AddToPhone( callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString(), callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[10].Value.ToString());
//                at.ShowDialog();
//                //ShowModalExcept(at, MainForm.searchForm);
//                if (Utils.CallName != "" && Utils.CallPlace != "" && Utils.CallPlaceID != "")
//                {
//                    callsRegistrayTableAdapter.UpdateQueryphone(Utils.CallName, Utils.CallPlace, Utils.CallPlaceID, Convert.ToInt32(callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[0].Value));
//                    callsRegistrayDataGridView.DataSource = this.callsRegistrayBindingSource;
////                    callsRegistrayBindingNavigatorSaveItem.PerformClick();
//                    this.callsRegistrayTableAdapter.Fill(this.dSCalls.CallsRegistray);

//                }




//            }

//            if (e.ColumnIndex == 11)
//            {

//                if (Utils.mode != null)
//                {

//                        double Num;
//                        bool isNum = double.TryParse(callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString(), out Num);
//                        if (isNum)
//                        {
//                            Utils.mode.Call(callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString());
//                            Redail.ShowMe();

//                        }


//                }
//            }



//            }


//        /// <summary>
//        /// Search TextBox
//        /// </summary>
//        /// 
//        //public static void ShowModalExcept(Form modalForm, Form exceptionForm)
//        //{
//        //    // إيقاف كل الفورمز ما عدا فورم البحث
//        //    foreach (Form f in Application.OpenForms)
//        //    {
//        //        if (f != modalForm && f != exceptionForm)
//        //        {
//        //            f.Enabled = false;
//        //        }
//        //    }

//        //    // لما الفورم تتقفل، نرجّع كل حاجة
//        //    modalForm.FormClosed += (s, e) =>
//        //    {
//        //        foreach (Form f in Application.OpenForms)
//        //        {
//        //            f.Enabled = true;
//        //        }
//        //    };

//        //    modalForm.Show();
//        //}


//        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
//        {

//            const int WM_KEYDOWN = 0x100;
//            if (msg.Msg == WM_KEYDOWN)
//            {

//                if (keyData == Keys.Escape)
//                {


//                    this.Validate();
//                    this.callsRegistrayBindingSource.EndEdit();
//                    this.tableAdapterManager.UpdateAll(this.dSCalls);

//                    this.Close();
//                }


//            }

//            return false;


//        }

//        private void Calls_FormClosing(object sender, FormClosingEventArgs e)
//        {


//        }

//        private void Calls_FormClosed(object sender, FormClosedEventArgs e)
//        {
//            if (callsRegistrayBindingSource.Count > 0)
//            {
//            //   callsRegistrayBindingNavigatorSaveItem.PerformClick();


//                this.Validate();
//                this.callsRegistrayBindingSource.EndEdit();
//                this.tableAdapterManager.UpdateAll(this.dSCalls);

//            }
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            ArchivedCalls cl = new ArchivedCalls();
//            cl.ShowDialog();
//            //ShowModalExcept(cl, MainForm.searchForm);
//        }



//        private void callsRegistrayDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
//        {
//            //string value = callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[8].Value.ToString();
//            //int id = Convert.ToInt32(callsRegistrayDataGridView.CurrentCell.OwningRow.Cells[0].Value.ToString());

//            //this.callsRegistrayTableAdapter.UpdateQuery(value, id);
//            //this.callsRegistrayTableAdapter.Fill(this.dSCalls.CallsRegistray);
//        }

//        private void callsRegistrayDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
//        {
//            go = false;
//        }




//        }
//    }


