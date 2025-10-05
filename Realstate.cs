using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealStateRentSystem.Classes;
using RealStateRentSystem.DSTables;
using RealStateRentSystem.DSTables.DSsettingTableAdapters;
using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static RealStateRentSystem_Buisness.clsSettingsCalling;
using static System.Windows.Forms.MonthCalendar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace RealStateRentSystem
{
    public partial class Realstate : Form
    {
        public Realstate()
        {
            InitializeComponent();

            // القائمة الأولى: أرقام الهواتف
            menuPhones = new ContextMenuStrip();
            menuPhones.ItemClicked += MenuTypes_ItemClicked;

            this.BringToFront();
            this.Activate();
            this.IDLabel.DataBindings["Text"].Format += (s, e) =>
            {
                if (e.DesiredType == typeof(string) && e.Value != null)
                {
                    e.Value = e.Value.ToString().Replace(",", "");
                }
            };
        }

        public string back;
        public string savecliced = "";
        public static string close = "";
        public Boolean actived = false;
        public Boolean soso = false;
        public HMessageBox SnewMessageBox;
        public string clicked = "";
        public string ss = "go";
        public int recored_id;
        public string am;
        public static Boolean continues = false;
        public Boolean change = false;
        private OpenFileDialog fdlg = new OpenFileDialog();
        private DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter shorCutKeysTableAdapter = new DSTables.DSsettingTableAdapters.ShorCutKeysTableAdapter();
        private DSTables.DSTempAttchTableAdapters.TempAttachmentTableAdapter TempTableAdapterManager = new DSTables.DSTempAttchTableAdapters.TempAttachmentTableAdapter();
        private System.Windows.Forms.ToolTip m_wndToolTip;
        public Boolean chechupdatestate = true;
        ///////////////////
        string lastText = string.Empty;
        static bool textChanging = false;
        private CustomSource autoComplete;

        string BuildinglastText = string.Empty;
        static bool BuildingtextChanging = false;
        private CustomSource BuildingautoComplete;
        public string toDo = "";
        public string toDophne = "";
        public string toDomop = "";
        public string toDomop2 = "";
        public string toDoother = "";
        public bool flagg = false;
        public string PublicFileName;
        RelatedRecordsForm f;
        //========Added Code=======
        
        public int RS_ID;
        public string RS_Type;
        private bool publishedChanged = false;
        private bool lastPublishedState = false;

        public class TempDeletedAttachment
        {
            public string FileName { get; set; }
            public string Comment { get; set; }
        }

        private List<TempDeletedAttachment> deletedAutoAttachments = new List<TempDeletedAttachment>();


        private bool AttachmentExists(int realStateId, string fileName)
        {
            try
            {
                // استخدام أسماء الأعمدة الصحيحة التي ظهرت لك
                string realStateIdColumnName = "RealState_ID"; // هذا هو العمود الصحيح
                string fileNameColumnName = "FileName"; // هذا هو العمود الصحيح

                // الآن استخدم اسم العمود الصحيح
                var rows = dSrealstate.Attachment.Select($"{realStateIdColumnName} = {realStateId} AND {fileNameColumnName} = '{fileName.Replace("'", "''")}'");
                return rows.Length > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في البحث عن المرفق: {ex.Message}");
                return false;
            }
        }

        private bool AttachmentExistsByName(int realStateId, string fileNameWithoutId, string fileNameWithId)
        {
            return AttachmentExists(realStateId, fileNameWithId) || AttachmentExists(realStateId, fileNameWithoutId);
        }

        private bool IsAutoAttachment(int attachmentId)
        {
            try
            {
                // استخدام اسم العمود الصحيح للنوع
                string typeColumn = "Type";
                string idColumn = "ID";

                var rows = dSrealstate.Attachment.Select($"{idColumn} = {attachmentId}");
                if (rows.Length > 0)
                {
                    object typeValue = rows[0][typeColumn];
                    return typeValue != DBNull.Value && Convert.ToInt32(typeValue) == 2;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        private  void realStateBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            bool wasPublished = false;
            int floor;
            string g = "";//flag to 
            if (txtFloor.Text != "")
            {
                floor = Convert.ToInt32(txtFloor.Text);
            }
            else
            {
                floor = 0;
            }

            if (string.IsNullOrEmpty(roomsTextBox.Text.Trim()))
                roomsTextBox.Text = "0";

            int esra2;
            if (clicked == "clicked")
            {
                soso = false;
                esra2 = 0;
            }
            else
            {
                soso = checkduplicate();
                esra2 = Utils.realstateid;
            }

            if (!soso)
            {
                if (((Utils.checkexist(txtSubResgion.Text, txtBuilding.Text, floor, esra2).Rows.Count <= 0) || continues) || gnon == "del")
                {
                    //tempmlate
                    //  continues = false;       lulu            
                    if (!checkdTemplate() && clicked != "clicked" && !continues && gnon != "del")
                    {
                        DataTable dt = new DataTable();
                        dt = TempTableAdapterManager.GetDataBy(cmbRegion.Text.Trim(), txtSubResgion.Text.Trim(), txtBuilding.Text.Trim());
                        if (dt.Rows.Count > 0)
                        {
                            int id;
                            id = ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID;

                            for (int s = 0; s < dt.Rows.Count; s++)
                            {
                                string FileName = dt.Rows[s]["FileName"].ToString();
                                string TempPath = Utils.ProjectName + "\\TempAttachment\\" + FileName;
                                if (!System.IO.File.Exists(TempPath))
                                {
                                    DialogResult dialogResult = MessageBox.Show(
                                               $"الملف {TempPath} غير موجود",
                                               "خطأ",
                                               MessageBoxButtons.OK,
                                               MessageBoxIcon.Error,
                                               MessageBoxDefaultButton.Button3,
                                               MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                                           );

                                    continue;
                                }

                                bool IsVisible = Convert.ToBoolean(dt.Rows[s]["Visible"]);
                                string Comment = dt.Rows[s]["comment"].ToString();
                                string ext = FileName.Substring(FileName.LastIndexOf("."));
                                string yy = FileName.Substring(0, FileName.LastIndexOf("."));
                                string fullname = yy + id + ext;
                                if (!GetFileExisting(fullname))
                                {

                                    if (am == "archive")
                                    {
                                        this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now.Date, Comment, 0, 2, IsVisible);
                                        // File.Copy(Utils.ProjectName + "\\attachment\\TempAttachment\\" + FileName, Utils.ProjectName + "\\attachment\\" + fullname);
                                        // Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\" + fullname);
                                        this.attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
                                    }
                                    else
                                    {

                                        this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now.Date, Comment, 1, 2, IsVisible);
                                        // File.Copy(Utils.ProjectName + "\\attachment\\TempAttachment\\" + FileName, Utils.ProjectName + "\\attachment\\" + fullname);

                                        // Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\" + fullname);

                                        this.attachmentTableAdapter.Fill(this.dSrealstate.Attachment);
                                    }
                                }
                            }//loop

                        }

                    }//end of if new
                    // if new
                    txtUserName.Text = Utils.current_user.ToString();
                    dtpDateOfModification.Value = DateTime.Now;
                    DateTime d1 = startRentDateDateTimePicker.Value.Date;
                    DateTime d2 = endRendDateDateTimePicker.Value.Date;
                    if (periodTextBox.Text == "" || periodTextBox.Text == null || periodTextBox.Text == "0")
                    {
                        int M = Math.Abs((d1.Year - d2.Year));
                        int months = ((M * 12) + Math.Abs((d1.Month - d2.Month)));
                        periodTextBox.Text = months.ToString();
                        remainingDayTextBox.Text = GetDates.DateDiffDays(DateTime.Now.Date, endRendDateDateTimePicker.Value.Date).ToString();
                    }
                    if (d1.Date <= d2.Date)
                    {
                       
                        this.Validate();
                        this.eventBindingSource.EndEdit();
                        this.realStateBindingSource.EndEdit();
                        this.tableAdapterManager.AttachmentTableAdapter.Adapter.ContinueUpdateOnError = true;
                        this.tableAdapterManager.EventTableAdapter.Adapter.ContinueUpdateOnError = true;
                        this.tableAdapterManager.RealStateTableAdapter.Adapter.ContinueUpdateOnError = true;
                        this.tableAdapterManager.UpdateAll(this.dSrealstate);
                        
                        //Insert Case
                        int pos = realStateBindingSource.Position;
                        if (pos >= 0 && pos < dSrealstate.RealState.Rows.Count)
                        {
                            ((DSrealstate.RealStateRow)dSrealstate.RealState.Rows[pos]).published = false;
                        }


                        if (am == "archive")
                        {
                            this.realStateTableAdapter.FillArchive(this.dSrealstate.RealState);
                            Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);
                            this.eventTableAdapter.FillByArchive(this.dSrealstate.Event);

                        }
                        else if (gnon != "del" && recored_id == 0)
                        {

                            this.realStateTableAdapter.Fill(this.dSrealstate.RealState);
                            Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);
                            this.eventTableAdapter.Fill(this.dSrealstate.Event);
                        }


                        /////////////////////
                        ///
                        // تحديث مصدر الربط
                        this.realStateBindingSource.ResetCurrentItem();
                        this.eventBindingSource.ResetBindings(false);




                        if (recored_id > 0)
                        {
                            this.realStateTableAdapter.FillAll(this.dSrealstate.RealState, recored_id);
                            // Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);
                            this.eventTableAdapter.FillBy(this.dSrealstate.Event, recored_id);

                        }


                        if (this.realStateBindingSource.Count == 1)
                        {
                            this.realStateBindingSource.ResumeBinding();

                        }

                        if (am == "archive")
                        {
                            bindingNavigatorAddNewItem.Enabled = false;
                            bindingNavigatorDeleteItem.Enabled = false;
                        }
                        else if (am == "View")
                        {
                            bindingNavigatorAddNewItem.Enabled = false;
                        }
                        else if (am == "Search")
                        {
                            bindingNavigatorAddNewItem.Enabled = false;
                        }
                        else
                        {
                            bindingNavigatorMovePreviousItem.Enabled = true;
                            bindingNavigatorMoveFirstItem.Enabled = true;
                            bindingNavigatorDeleteItem.Enabled = true;
                        }

                        this.eventBindingSource.ResumeBinding();

                        //eventTextBox.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("خطأ بالتواريخ");
                        startRentDateDateTimePicker.Focus();

                    }

                    //realStateBindingNavigatorSaveItem.Enabled = false;
                    //      saved.Visible = true;


                }//end if not duplicate

                else
                {
                    DSrealstatesearch.RealStateDataTable dt = (DSrealstatesearch.RealStateDataTable)Utils.checkexist(txtSubResgion.Text, txtBuilding.Text, Convert.ToInt32(txtFloor.Text), esra2);
                    Check.who = "rent";
                    g = Check.ShowMe(dt);
                    if (g == "kml")
                    {
                        continues = true;
                        realStateBindingNavigatorSaveItem.PerformClick();
                    }
                    if (g == "cancel")
                    {
                        continues = false;
                        txtSubResgion.Focus();
                    }

                    //   MessageBox.Show("متشابه");
                    continues = false;
                }

            }//soso
            else
            {
                txtUserName.Text = Utils.current_user.ToString();
                dtpDateOfModification.Value = DateTime.Now;
                dateDateTimePicker.Value = DateTime.Now;
                DateTime d1 = startRentDateDateTimePicker.Value.Date;
                DateTime d2 = endRendDateDateTimePicker.Value.Date;
                if (periodTextBox.Text == "" || periodTextBox.Text == null || periodTextBox.Text == "0")
                {


                    int M = Math.Abs((d1.Year - d2.Year));
                    int months = ((M * 12) + Math.Abs((d1.Month - d2.Month)));
                    periodTextBox.Text = months.ToString();
                    remainingDayTextBox.Text = GetDates.DateDiffDays(DateTime.Now.Date, endRendDateDateTimePicker.Value.Date).ToString();
                }
                if (d1.Date <= d2.Date)
                {
                    wasPublished = clsRealState.GetPublishedValuetoRealstate(Utils.realstateid);

                    this.Validate();
                    this.eventBindingSource.EndEdit();
                    this.realStateBindingSource.EndEdit();

                    this.tableAdapterManager.AttachmentTableAdapter.Adapter.ContinueUpdateOnError = false;
                    this.tableAdapterManager.EventTableAdapter.Adapter.ContinueUpdateOnError = true;
                    this.tableAdapterManager.RealStateTableAdapter.Adapter.ContinueUpdateOnError = true;

                    this.attachmentTableAdapter.Update(this.dSrealstate.Attachment);
                    //endRendDateDateTimePicker.DataBindings[0].WriteValue();
                    this.tableAdapterManager.UpdateAll(this.dSrealstate);


                    #region Commented Code


                    //// 🔁 استرجاع مرفقات الملفات القديمة المفقودة في حالة كانت محفوظة فعليًا في TempAttachment
                    //int realStateId = Utils.realstateid;
                    //string tempFolderPath = Path.Combine(Utils.ProjectName, "TempAttachment");
                    //string[] allFiles = Directory.GetFiles(tempFolderPath);

                    //foreach (var fullFilePath in allFiles)
                    //{
                    //    string fileName = Path.GetFileName(fullFilePath);
                    //    string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                    //    string ext = Path.GetExtension(fileName);

                    //    // هنفترض إن اسم الملف من نوع: something + ID → مثلاً: رسم1 + 123 → رسم1123.pdf
                    //    if (nameWithoutExt.EndsWith(realStateId.ToString()))
                    //    {
                    //        // تأكد الملف مش موجود أصلًا في قاعدة البيانات
                    //        if (!GetFileExisting(fileName))
                    //        {
                    //            string comment = ""; // ممكن تجيبيه من جدول مؤقت لو متاح

                    //            // إضافة للجدول
                    //            if (am == "archive")
                    //            {
                    //                this.attachmentTableAdapter.Insert(realStateId, fileName, "", DateTime.Now.Date, comment, 0);
                    //                Utils.shortcut(fullFilePath, Path.Combine(Utils.ProjectName, fileName));
                    //                this.attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
                    //            }
                    //            else
                    //            {
                    //                this.attachmentTableAdapter.Insert(realStateId, fileName, "", DateTime.Now.Date, comment, 1);
                    //                Utils.shortcut(fullFilePath, Path.Combine(Utils.ProjectName, fileName));
                    //                this.attachmentTableAdapter.Fill(this.dSrealstate.Attachment);
                    //            }
                    //        }
                    //    }
                    //}


                    //if (saved.Visible != true)
                    //{
                    //    saved.Visible = true;

                    //} 
                    #endregion

                    if (am == "archive")
                    {
                        this.realStateTableAdapter.FillArchive(this.dSrealstate.RealState);
                        Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);
                        this.eventTableAdapter.FillByArchive(this.dSrealstate.Event);
                    }
                    else if (gnon != "del" && recored_id == 0)
                    {

                        this.realStateTableAdapter.Fill(this.dSrealstate.RealState);
                        Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);
                        this.eventTableAdapter.Fill(this.dSrealstate.Event);
                    }



                    if (recored_id > 0 && gnon != "del")
                    {
                        this.realStateTableAdapter.FillAll(this.dSrealstate.RealState, recored_id);
                        Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);
                        this.eventTableAdapter.FillBy(this.dSrealstate.Event, recored_id);


                    }


                    if (this.realStateBindingSource.Count == 1)
                    {
                        this.realStateBindingSource.ResumeBinding();

                    }

                    if (am == "archive")
                    {
                        bindingNavigatorAddNewItem.Enabled = false;
                        bindingNavigatorDeleteItem.Enabled = false;
                    }
                    else if (am == "View")
                    {
                        bindingNavigatorAddNewItem.Enabled = false;
                    }
                    else if (am == "Search")
                    {
                        bindingNavigatorAddNewItem.Enabled = false;
                    }
                    else
                    {
                        bindingNavigatorMovePreviousItem.Enabled = true;
                        bindingNavigatorMoveFirstItem.Enabled = true;
                        bindingNavigatorDeleteItem.Enabled = true;
                    }

                    this.eventBindingSource.ResumeBinding();

                    //eventTextBox.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("خطأ بالتواريخ");
                    startRentDateDateTimePicker.Focus();

                }

                //realStateBindingNavigatorSaveItem.Enabled = false;

                chechupdatestate = true;

            }

            if (clicked == "clicked" && g != "cancel")
            {
                DataTable dt = new DataTable();
                dt = TempTableAdapterManager.GetDataBy(cmbRegion.Text.Trim(), txtSubResgion.Text.Trim(), txtBuilding.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    int id;
                    id = ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID;

                    for (int s = 0; s < dt.Rows.Count; s++)
                    {
                        string FileName = dt.Rows[s]["FileName"].ToString();
                        string TempPath = Utils.ProjectName + "\\TempAttachment\\" + FileName;
                        if (!File.Exists(TempPath))
                        {
                            DialogResult dialogResult = MessageBox.Show(
                                       $"الملف {TempPath} غير موجود",
                                       "خطأ",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error,
                                       MessageBoxDefaultButton.Button3,
                                       MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                                   );

                            continue;
                        }

                        string Comment = dt.Rows[s]["comment"].ToString();
                        string ext = FileName.Substring(FileName.LastIndexOf("."));
                        string yy = FileName.Substring(0, FileName.LastIndexOf("."));
                        string fullnameWithId = yy + id + ext;
                        string fullname = yy + ext;
                        bool IsVisible = Convert.ToBoolean(dt.Rows[s]["Visible"]);


                        //if (!GetFileExisting(fullname, fullnameWithId) || flagg)
                        if ((!AttachmentExistsByName(id, fullname, fullnameWithId)) || flagg)
                        {

                            if (am == "archive")
                            {
                                this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now.Date, Comment, 0, 2, IsVisible);
                                // File.Copy(Utils.ProjectName + "\\attachment\\TempAttachment\\" + FileName, Utils.ProjectName + "\\attachment\\" + fullname);
                                // Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\" + fullname);
                                this.attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
                            }
                            else
                            {

                                this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now.Date, Comment, 1, 2, IsVisible);

                                // File.Copy(Utils.ProjectName + "\\attachment\\TempAttachment\\" + FileName, Utils.ProjectName + "\\attachment\\" + fullname);
                                // Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\" + fullname);


                                this.attachmentTableAdapter.Fill(this.dSrealstate.Attachment);
                            }
                        }
                        else if (!flagg)
                        {
                            DialogResult dialogResult = MessageBox.Show(
                                     $"الملف {fullname} موجود \r\n هل تريد التوجه للملف؟؟",
                                     "خطأ",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Error,
                                     MessageBoxDefaultButton.Button3,
                                     MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                                 );
                            if (dialogResult == DialogResult.Yes)
                                Process.Start("explorer.exe", $"/select,\"{Utils.ProjectName + "\\" + fullname}\"");
                        }
                    }
                }
                clicked = "dd";
            }//end if new

            if (clicked != "clicked" && g == "kml")
            {
                DataTable dt = new DataTable();
                dt = TempTableAdapterManager.GetDataBy(cmbRegion.Text, txtSubResgion.Text, txtBuilding.Text);
                if (dt.Rows.Count > 0)
                {
                    int id;
                    id = ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID;

                    for (int s = 0; s < dt.Rows.Count; s++)
                    {
                        string FileName = dt.Rows[s]["FileName"].ToString();
                        string Comment = dt.Rows[s]["comment"].ToString();
                        bool IsVisible = Convert.ToBoolean(dt.Rows[s]["Visible"]);

                        string ext = FileName.Substring(FileName.LastIndexOf("."));
                        string yy = FileName.Substring(0, FileName.LastIndexOf("."));
                        string fullnameWithId = yy + id + ext;
                        string fullname = yy + ext;
                        //if (!GetFileExisting(fullname, fullnameWithId))
                        if ((!AttachmentExistsByName(id, fullname, fullnameWithId)) || flagg)
                        {

                            if (am == "archive")
                            {
                                this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now.Date, Comment, 0, 2, IsVisible);
                                // File.Copy(Utils.ProjectName + "\\attachment\\TempAttachment\\" + FileName, Utils.ProjectName + "\\attachment\\" + fullname);
                                // Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\" + fullname);
                                this.attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
                            }
                            else
                            {
                                this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now.Date, Comment, 1, 2, IsVisible);
                                // File.Copy(Utils.ProjectName + "\\attachment\\TempAttachment\\" + FileName, Utils.ProjectName + "\\attachment\\" + fullname);
                                // Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\" + fullname);
                                this.attachmentTableAdapter.Fill(this.dSrealstate.Attachment);
                            }
                        }
                        else if (g == "kml")
                        {
                            if (am == "archive")
                            {
                                this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now.Date, Comment, 0, 2, IsVisible);
                                // File.Copy(Utils.ProjectName + "\\attachment\\TempAttachment\\" + FileName, Utils.ProjectName + "\\attachment\\" + fullname);
                                // Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\" + fullname);
                                this.attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
                            }
                            else
                            {

                                this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now.Date, Comment, 1, 2, IsVisible);

                                // File.Copy(Utils.ProjectName + "\\attachment\\TempAttachment\\" + FileName, Utils.ProjectName + "\\attachment\\" + fullname);
                                // Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\" + fullname);


                                this.attachmentTableAdapter.Fill(this.dSrealstate.Attachment);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"الملف {fullname} موجود");
                        }
                    }
                }
                clicked = "dd";
            }//end if new


            HandlePendingAttachmentsForCurrentRealState();

            saved.Visible = true;
            chechupdatestate = true;


            // ✅ تحديث حالة النشر بعد الحفظ
            int currentId = Utils.realstateid;

            // نجيب السجل الحالي من BindingSource
            if (realStateBindingSource.Current is DataRowView currentRow)
            {
                // Convert.ToBoolean(currentRow["published"]); // الحالة القديمة
                bool isChecked = Published.Checked; // الحالة الجديدة (من الـ CheckBox)

                // الحالة 3: مش منشور + المستخدم عمل تشيك → انشر
                if (status_IDListBox.SelectedValue != null && status_IDListBox.SelectedValue.ToString() == "1")
                {   if (isChecked)
                    {
                        UpdateActiveAndPublish(Utils.realstateid);
                    }
                    //else
                    //{
                    //    // مؤجر بس مفيش نشر → يبقى بس تحديث حالة Active
                    //    UpdateActiveAndPublish(Utils.realstateid);
                    //}
                    //UpdateActiveAndPublish(Utils.realstateid);
                }
                else if (!wasPublished && isChecked)
                {
                    currentRow["published"] = true;
                    currentRow.EndEdit();
                    realStateBindingSource.EndEdit();
                    this.realStateTableAdapter.Update(this.dSrealstate.RealState);

                    PublishRecord();
                }
                // الحالة 2: كان منشور + المستخدم لغى التشيك → الغي النشر
                else if (wasPublished && !isChecked)
                {
                    currentRow["published"] = false;
                    currentRow.EndEdit();
                    realStateBindingSource.EndEdit();
                    this.realStateTableAdapter.Update(this.dSrealstate.RealState);

                    UpdateActiveAndPublish(currentId);
                }
                else if (wasPublished && isChecked)
                {
                    currentRow["published"] = true;
                    currentRow.EndEdit();
                    realStateBindingSource.EndEdit();
                    this.realStateTableAdapter.Update(this.dSrealstate.RealState);

                    PublishRecord();
                }
                // الحالة 1: (مش منشور + مش متعلم) → تجاهل
            }

            #region commentedCode
            /////TaskDeletedAttachments
            //foreach (var att in deletedAutoAttachments)
            //{
            //    string ext = Path.GetExtension(att.FileName);
            //    string yy = Path.GetFileNameWithoutExtension(att.FileName);
            //    string fullname = yy + Utils.realstateid + ext;

            //    if (!GetFileExisting(yy)) // احتمال تصحيحها: fullname بدل yy
            //    {
            //        attachmentTableAdapter.Insert(Utils.realstateid, fullname, "", DateTime.Now.Date, att.Comment, (am == "archive" ? 0 : 1), 2);

            //        if (am == "archive")
            //            attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
            //        else
            //            attachmentTableAdapter.Fill(this.dSrealstate.Attachment);
            //    }
            //}
            //deletedAutoAttachments.Clear();  
            #endregion


            if (g == "cancel")
            {

                saved.Visible = false;
                chechupdatestate = true;
            }


            Utils.CallName = txtOwner.Text;
            Utils.CallPlaceID = ",r" + Utils.realstateid;
            Utils.CallPlace = "," + "اجار";

            #region commentedCode
            //attachmentDataGridView.DataSource = dSrealstate.Attachment;
            //attachmentDataGridView.Refresh();


            //clsRealState.MarkAsPublished(Utils.realstateid, Published.Checked);



            //var pubilshed = clsRealState.GetPublishedValuetoRealstate(Utils.realstateid);// Convert.ToBoolean(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).published);
            //var isChecked = Published.Checked;
            //clsRealState.MarkAsPublished(Utils.realstateid, isChecked);

            //if (status_IDListBox.SelectedValue != null && status_IDListBox.SelectedValue.ToString() == "1" && pubilshed)
            //{
            //    UpdateActiveAndPublish(Utils.realstateid);
            //}
            //// الحالة 3: المستخدم عايز ينشر دلوقتي
            //else if (!pubilshed && isChecked)
            //{
            //    PublishRecord();
            //}
            //// الحالة 2: كان منشور قبل كده والمستخدم لغى التشيك
            //else if (pubilshed && !isChecked)
            //{
            //    UpdateActiveAndPublish(Utils.realstateid);

            //}
            //else if (pubilshed && isChecked)
            //{
            //    PublishRecord();
            //}

            //UpdatePublishedStatus();

            #endregion


        }
        private void ReloadCurrentRow(int realStateId, string am)
        {
            try
            {
                Console.WriteLine($"🔄 جاري إعادة تحميل البيانات للسجل ID = {realStateId}, Mode = {am}");

                if (am == "archive")
                {
                    // تحميل الأرشيف
                    this.realStateTableAdapter.FillArchive(this.dSrealstate.RealState);
                    Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)
                        this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

                    this.eventTableAdapter.FillByArchive(this.dSrealstate.Event);
                }
                else if (recored_id > 0 && gnon != "del")
                {
                    // تحميل سجل محدد بالـ ID
                    this.realStateTableAdapter.FillAll(this.dSrealstate.RealState, recored_id);
                    Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)
                        this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

                    this.eventTableAdapter.FillBy(this.dSrealstate.Event, recored_id);
                }
                else if (gnon != "del" && recored_id == 0)
                {
                    // تحميل عادي لكل البيانات
                    this.realStateTableAdapter.Fill(this.dSrealstate.RealState);
                    Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)
                        this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

                    this.eventTableAdapter.Fill(this.dSrealstate.Event);
                }

                // تحديث حالة الـ BindingSource
                if (this.realStateBindingSource.Count == 1)
                {
                    this.realStateBindingSource.ResumeBinding();
                }

                this.eventBindingSource.ResumeBinding();

                Console.WriteLine("✅ تمت إعادة تحميل البيانات بنجاح.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ خطأ أثناء إعادة تحميل البيانات: {ex.Message}");
                MessageBox.Show("⚠ حدث خطأ أثناء إعادة تحميل البيانات.\n" + ex.Message,
                                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void UpdatePublishedStatus()
        //{
        //    try
        //    {
        //        if (realStateBindingSource.Current == null || realStateBindingSource.Count <= 0)
        //        {
        //            Published.Checked = false;
        //            return;
        //        }

        //        // الطريقة الصحيحة للوصول إلى الصف
        //        DataRowView rowView = (DataRowView)realStateBindingSource.Current;

        //        if (rowView.Row is DSrealstate.RealStateRow row)
        //        {
        //            int currentId = Convert.ToInt32(row.ID);
        //            Published.Checked = clsRealState.GetPublishedValuetoRealstate(currentId);
        //            Utils.realstateid = currentId;

        //            // للتأكد من أن القيمة معروضة بشكل صحيح
        //            Console.WriteLine($"Updated Published Status: ID={currentId}, Published={Published.Checked}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in UpdatePublishedStatus: {ex.Message}");
        //        Published.Checked = false;
        //    }
        //}

        void FillBuildingType()
        {
            try
            {
                DataTable buildingTypes = clsBuildingType.GetAllBuildingTypes();

                cmbBuildingType.DataSource = null;
                cmbBuildingType.DisplayMember = "Building_Type";
                cmbBuildingType.ValueMember = "ID";
                cmbBuildingType.DataSource = buildingTypes;

                cmbBuildingType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل أنواع المباني:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void realStateBindingSource_CurrentChanged(object sender, EventArgs e)
        //{
        //    // تأكد من أن هناك سجل حالي قبل التحديث
        //    if (realStateBindingSource.Current != null)
        //    {
        //        //UpdatePublishedStatus();
        //    }
        //}
        private bool formLoaded = false;
        public void Realstate_Load(object sender, EventArgs e)
        {
            formLoaded = true;

            // ✅ إضافة هذا الكود لتحميل حالة النشر عند فتح السجل
            //if (this.realStateBindingSource.Count > 0)
            //{
            //    var row = (DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position];

            //    // تحميل حالة النشر من قاعدة البيانات وتعيينها للـ CheckBox
            //    Published.Checked = !row.IspublishedNull() && row.published;

            //    Utils.realstateid = row.ID;
            //}

            btnCall1.Tag = (txtPhoneOne, phone_oneLabel);
            btnCall2.Tag = (txtMobile, mobileLabel);
            btnCall3.Tag = (txtPhoneTow, phone_TwoLabel);
            btnCall4.Tag = (txtMobile2, label2);
            btnCall5.Tag = (txtOther, otherLabel);


            bindingNavigatorDeleteItem.Enabled = true;

            FillBuildingType();
            Top_panel.BackColor = Color.FromArgb(188, 71, 73);
            this.wayOfRentTableAdapter.Fill(this.dSregion.WayOfRent);
            this.statusTypeTableAdapter.Fill(this.dSregion.StatusType);
            this.investitureTableAdapter.Fill(this.dSregion.Investiture);
            this.buildingTypeTableAdapter.FillByrent(this.dSregion.BuildingType);
            this.realStateBindingSource.DataSource = this.dSrealstate.RealState;

            this.regionTableAdapter.Fill(this.dSregion.Region);
            if (recored_id > 0)
            {
                this.realStateTableAdapter.FillAll(this.dSrealstate.RealState, recored_id);
                if (this.dSrealstate.RealState.Rows.Count > 0)
                {
                    Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

                    // أضف هذا السطر لتحديد الخيار الصحيح في الكمبوبوكس
                    //int buildingTypeId = ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).Building_Type_ID;
                    // Solve Problem
                    DSrealstate.RealStateRow row = (DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position];

                    int buildingTypeId = 0;
                    if (!row.IsBuilding_Type_IDNull())
                    {
                        buildingTypeId = row.Building_Type_ID;
                    }
                    else
                    {
                        buildingTypeId = 0;
                    }
                    cmbBuildingType.SelectedValue = buildingTypeId;
                }
                this.eventTableAdapter.FillBy(this.dSrealstate.Event, recored_id);
                this.attachmentTableAdapter.FillBy(this.dSrealstate.Attachment, recored_id);

                bindingNavigatorAddNewItem.Enabled = false;
                if (((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ToString() != null)
                {
                    if (((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).active.ToString() == "0")
                    {
                        am = "archive";
                        this.realStateTableAdapter.FillAll(this.dSrealstate.RealState, recored_id);
                        if (this.dSrealstate.RealState.Rows.Count > 0)
                        {
                            Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

                            // أضف هذا السطر لتحديد الخيار الصحيح في الكمبوبوكس
                            //int buildingTypeId = ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).Building_Type_ID;
                            // Solve Problem
                            DSrealstate.RealStateRow row = (DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position];

                            int buildingTypeId = 0;
                            if (!row.IsBuilding_Type_IDNull())
                            {
                                buildingTypeId = row.Building_Type_ID;
                            }
                            else
                            {
                                buildingTypeId = 0;
                            }
                            cmbBuildingType.SelectedValue = buildingTypeId;
                        }
                        this.eventTableAdapter.FillBy(this.dSrealstate.Event, recored_id);
                        this.attachmentTableAdapter.FillBy(this.dSrealstate.Attachment, recored_id);
                        bindingNavigatorAddNewItem.Enabled = false;
                        bindingNavigatorDeleteItem.Enabled = false;
                        this.button2.Visible = false;
                        Restore.Visible = true;
                        if (this.realStateBindingSource.Count > 0)
                        {
                            Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);
                        }

                        else
                        {
                            realStateBindingNavigatorSaveItem.Enabled = false;
                            Restore.Enabled = false;
                            button1.Enabled = false;
                            button3.Enabled = false;
                            button4.Enabled = false;
                            toolStripButton1.Enabled = false;
                            toolStripButton2.Enabled = false;
                        }
                    }
                }
                Utils.realstateid = recored_id;
            }
            else
            {
                this.realStateTableAdapter.Fill(this.dSrealstate.RealState);
                if (this.dSrealstate.RealState.Rows.Count > 0)
                {
                    Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

                    // أضف هذا السطر لتحديد الخيار الصحيح في الكمبوبوكس
                    //int buildingTypeId = ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).Building_Type_ID;
                    DSrealstate.RealStateRow row = (DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position];

                    // Solve Problem
                    int buildingTypeId = 0;
                    if (!row.IsBuilding_Type_IDNull())
                    {
                        buildingTypeId = row.Building_Type_ID;
                    }
                    else
                    {
                        buildingTypeId = 0;
                    }

                    cmbBuildingType.SelectedValue = buildingTypeId;
                }
                this.eventTableAdapter.Fill(this.dSrealstate.Event);
                this.attachmentTableAdapter.Fill(this.dSrealstate.Attachment);

                if ((am == "archive" || ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).active.ToString() == "0"))
                {
                    am = "archive";
                    this.attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
                    this.realStateTableAdapter.FillArchive(this.dSrealstate.RealState);
                    this.eventTableAdapter.FillByArchive(this.dSrealstate.Event);

                    bindingNavigatorAddNewItem.Enabled = false;
                    bindingNavigatorDeleteItem.Enabled = false;
                    this.button2.Visible = false;

                    Restore.Visible = true;
                    if (this.realStateBindingSource.Count > 0)
                    {
                        Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);
                    }

                    else
                    {
                        realStateBindingNavigatorSaveItem.Enabled = false;
                        Restore.Enabled = false;
                        button1.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        toolStripButton1.Enabled = false;
                        toolStripButton2.Enabled = false;
                    }
                }

            }


            CheckWebsiteIdAndToggleButton(Utils.realstateid);

            actived = true;

            if (am == "View")
            {
                this.Text = "العقار";
                //empty.Visible = true;
                bindingNavigatorAddNewItem.Enabled = false;
            }

            this.m_wndToolTip = new System.Windows.Forms.ToolTip(this.components);
            m_wndToolTip.ShowAlways = true;

            if (this.realStateBindingSource.Count > 0)
            {
                Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);
            }
            else
            {
                realStateBindingNavigatorSaveItem.Enabled = false;
                bindingNavigatorDeleteItem.Enabled = false;
                Restore.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
            }

            encrypt();

            DataAccess dataAccess = new DataAccess();

            autoComplete = new CustomSource(dataAccess.GetNames().ToArray());
            txtOwner.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtOwner.AutoCompleteSource = AutoCompleteSource.CustomSource;
            autoComplete.Bind(txtOwner);


            BuildingautoComplete = new CustomSource(dataAccess.GetBuilding().ToArray());
            txtBuilding.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuilding.AutoCompleteSource = AutoCompleteSource.CustomSource;
            BuildingautoComplete.Bind(txtBuilding);

            chechupdatestate = true;

            if (toDo == "new")
            {
                bindingNavigatorAddNewItem.PerformClick();
                txtPhoneOne.Text = toDophne;
                txtOther.Text = toDoother;
                txtMobile.Text = toDomop;
                txtMobile2.Text = toDomop2;


            }

            if (string.IsNullOrEmpty(roomsTextBox.Text.Trim()))
                roomsTextBox.Text = "0";

            Buttons_toolStrip();


            // من الـ DateTimePicker → ToolStripButton
            endRendDateDateTimePicker.PreviewKeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Tab)
                {
                    ev.IsInputKey = true;
                    eventBindingNavigator.Focus(); // الفوكس على البايندنج نافيجيتور
                    eventBindingNavigator.Items[0].Select(); // أول زر (toolStripButton1 مثلاً)
                }
            };

            // Update button visibility based on current status
            UpdateButtonVisibility();


            txtMobile.TextChanged += phone_oneTextBox_TextChanged;
            txtMobile.TextChanged += (s, ev) => CheckOtherRecords();

            txtPhoneOne.TextChanged += (s, ev) => CheckOtherRecords();

            txtPhoneTow.TextChanged += (s, ev) => CheckOtherRecords();

            txtMobile2.TextChanged += (s, ev) => CheckOtherRecords();

            txtOther.TextChanged += (s, ev) => CheckOtherRecords();




            // استدعاء أول مرة للتحقق عند التحميل
            //CheckOtherRecords();

            //SessionManager.AddOpenedRecord("إيجار", Utils.realstateid);

            CheckOtherRecords();
        }


        private void CheckOtherRecords()
        {

            // Collect all numbers from the textboxes
            List<string> numbers = new List<string>();
            if (!string.IsNullOrWhiteSpace(txtPhoneOne.Text)) numbers.Add(txtPhoneOne.Text.Trim());
            if (!string.IsNullOrWhiteSpace(txtMobile.Text)) numbers.Add(txtMobile.Text.Trim());
            if (!string.IsNullOrWhiteSpace(txtPhoneTow.Text)) numbers.Add(txtPhoneTow.Text.Trim());
            if (!string.IsNullOrWhiteSpace(txtMobile2.Text)) numbers.Add(txtMobile2.Text.Trim());
            if (!string.IsNullOrWhiteSpace(txtOther.Text)) numbers.Add(txtOther.Text.Trim());

            if (numbers.Count > 0)
            {
                // Pass the list of numbers to Form1
                f = new RelatedRecordsForm(numbers, "", "", "0", Utils.realstateid.ToString());

                if (f.totalRecordsFound > 0) // Use new property in Form1
                {
                    otherRecords.Visible = true;
                    otherRecords.Text = $"سجلات أخري ({f.totalRecordsFound})"; // Show record count
                }
                else
                {
                    otherRecords.Visible = false;
                }
            }
            else
            {
                otherRecords.Visible = false;
            }
        }


        #region Export calling

        private ContextMenuStrip menuPhones;
        private string targetPhoneNumber;
        private string exportCallingLink = clsSettingsCalling.LoadSettings().ExportLink;
        private string secretKey = "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il"; // TODO: من الإعدادات

        private void BtnCall_Click(object sender, EventArgs e)
        {
            menuPhones.Items.Clear();

            var currentUser = clsSettingsCalling.GetUserByName(Utils.current_user);
            if (currentUser == null) return;

            List<clsSettingsCalling.UserPhoneInfo> finalList;
            if (currentUser.PhoneRestriction)
            {
                finalList = new List<clsSettingsCalling.UserPhoneInfo> { currentUser };
            }
            else
            {
                finalList = clsSettingsCalling.GetAllUsers();
                finalList.RemoveAll(u => u.UserName == currentUser.UserName);
                finalList.Insert(0, currentUser);
            }

            var btn = sender as System.Windows.Forms.Button;
            if (btn == null) return;

            var related = ((System.Windows.Forms.TextBox textBox, Label label))btn.Tag;
            System.Windows.Forms.TextBox relatedTextBox = related.textBox;
            Label relatedLabel = related.label;

            // ✅ Remove duplicates based on PhoneName
            var distinctPhones = finalList
                .Where(u => !string.IsNullOrWhiteSpace(u.PhoneName))
                .GroupBy(u => u.PhoneName)
                .Select(g => g.First()) // Take first occurrence for each PhoneName
                .ToList();

            foreach (var user in distinctPhones)
            {
                var phoneItem = new ToolStripMenuItem($"{user.PhoneName}")
                {
                    ForeColor = Color.Black
                };

                if (!relatedLabel.Text.Contains("هاتف"))
                {
                    var wItem = new ToolStripMenuItem("W")
                    {
                        Tag = (user.PhoneName, "W", btn)
                    };
                    wItem.Click += MenuTypes_ItemClicked;
                    phoneItem.DropDownItems.Add(wItem);
                }

                var nItem = new ToolStripMenuItem("N")
                {
                    Tag = (user.PhoneName, "N", btn)
                };
                nItem.Click += MenuTypes_ItemClicked;
                phoneItem.DropDownItems.Add(nItem);

                menuPhones.Items.Add(phoneItem);
            }

            menuPhones.RightToLeft = RightToLeft.No;
            this.Update();
            menuPhones.Show(btn, new Point(btn.Width + menuPhones.Width, 0));
        }

        private void MenuTypes_ItemClicked(object sender, EventArgs e)
        {
            var clickedItem = sender as ToolStripMenuItem;
            if (clickedItem == null) return;

            var tag = ((string phoneName, string numberType, System.Windows.Forms.Button btn))clickedItem.Tag;
            string phoneName = tag.phoneName;
            string numberType = tag.numberType;
            System.Windows.Forms.Button btn = tag.btn;

            if (btn == null) return;

            var related = ((System.Windows.Forms.TextBox textBox, Label label))btn.Tag;
            System.Windows.Forms.TextBox relatedTextBox = related.textBox;
            Label relatedLabel = related.label;

            if (relatedTextBox == null || string.IsNullOrEmpty(relatedTextBox.Text))
                return;

            targetPhoneNumber = relatedTextBox.Text;

            if (relatedLabel.Text.Contains("هاتف"))
            {
                targetPhoneNumber = "011" + targetPhoneNumber;
            }

            // Call API
            bool success = ApiManager.ExportCall(exportCallingLink, targetPhoneNumber, phoneName, numberType, secretKey);

            if (success)
                ShowTempMessage("تم إرسال الاتصال بنجاح", Color.Green);
            else
                ShowTempMessage("تعذر إرسال الطلب", Color.Red);
        }


        private void ShowTempMessage(string text, Color color)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.AutoSize = true;
            lbl.ForeColor = color;
            lbl.BackColor = Color.FromArgb(200, Color.White); // شفاف جزئياً مع خلفية
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // ضع الرسالة في منتصف الفورم أو حسب حاجتك
            lbl.Location = new Point((this.ClientSize.Width - lbl.PreferredWidth) / 2, 10);
            lbl.BringToFront(); // اجعلها فوق كل شيء
            this.Controls.Add(lbl);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000; // 3 ثواني
            timer.Tick += (s, e) =>
            {
                this.Controls.Remove(lbl);
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        #endregion


        public void encrypt()
        {
            if (Utils.EncryptMode)
            {

                txtBuilding.ForeColor = Color.White;
                txtOwner.ForeColor = Color.White;
                txtPhoneOne.ForeColor = Color.White;
                txtPhoneTow.ForeColor = Color.White;
                txtMobile.ForeColor = Color.White;
                txtMobile2.ForeColor = Color.White;
                txtOther.ForeColor = Color.White;
                info_SourceTextBox.ForeColor = Color.White;
                noteTextBox.ForeColor = Color.White;

                eventTextBox.ReadOnly = false;
                eventTextBox.ForeColor = Color.White;
                dataGridViewTextBoxColumn11.Visible = false;

                //MainForm.Imagencrypt.Visible = true;
                //MainForm.Imagencrypt2.Visible = true;
            }
            if (!Utils.EncryptMode)
            {


                txtBuilding.ForeColor = Color.Black;
                txtOwner.ForeColor = Color.Black;
                txtPhoneOne.ForeColor = Color.Black;
                txtPhoneTow.ForeColor = Color.Black;
                txtMobile.ForeColor = Color.Black;
                txtMobile2.ForeColor = Color.Black;
                txtOther.ForeColor = Color.Black;
                info_SourceTextBox.ForeColor = Color.Black;
                noteTextBox.ForeColor = Color.Black;

                eventTextBox.ReadOnly = true;
                eventTextBox.ForeColor = Color.Black;
                dataGridViewTextBoxColumn11.Visible = true;

                //MainForm.Imagencrypt.Visible = false;
                //MainForm.Imagencrypt2.Visible = false;
            }

        }


        //private void button3_Click(object sender, EventArgs e)
        //{

        //    if (this.dSrealstate.RealState.Rows.Count >= realStateBindingSource.Count)
        //    {
        //        fdlg.Title = "Attach file";
        //        fdlg.InitialDirectory = @"c:\";
        //        fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
        //        fdlg.FilterIndex = 2;
        //        fdlg.RestoreDirectory = true;

        //        if (fdlg.ShowDialog() == DialogResult.OK)
        //        {
        //            string filename = fdlg.SafeFileName;
        //            string ext = filename.Substring(filename.LastIndexOf("."));
        //            string yy = filename.Substring(0, filename.LastIndexOf("."));
        //            string fullname = yy + Utils.realstateid + ext;
        //            if (!(GetFileExisting(fullname)))
        //            {
        //                textBox4.Text = Utils.ProjectName + "\\" + fdlg.SafeFileName;
        //            }
        //            else
        //            {
        //                MessageBox.Show("الملف موجود من قبل");
        //            }
        //        }


        //    }
        //    else
        //    {

        //        MessageBox.Show("قم بالحفظ قبل");
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dSrealstate.RealState.Rows.Count >= realStateBindingSource.Count)
            {
                fdlg.Title = "Attach files";
                fdlg.InitialDirectory = @"c:\";
                fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
                fdlg.FilterIndex = 2;
                fdlg.RestoreDirectory = true;
                fdlg.Multiselect = true; // ✅ السماح باختيار أكثر من ملف

                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    // عرض كل الملفات في TextBox للتأكيد
                    textBox4.Clear();
                    foreach (string filePath in fdlg.FileNames)
                    {
                        textBox4.AppendText(Utils.ProjectName + "\\" + Path.GetFileName(filePath) + Environment.NewLine);
                    }
                }
            }
            else
            {
                MessageBox.Show("قم بالحفظ قبل");
            }
        }

        private bool GetFileExisting(string filename, string fileNameWithId = "")
        {

            string temp = filename.Substring(0, 1);

            if (File.Exists(Utils.ProjectName + "\\TempAttachment\\" + filename))
            {
                return true;
            }
            else if (File.Exists(Utils.ProjectName + "\\" + fileNameWithId))
            {
                return true;
            }
            else if (temp == "T")
            {
                int start = filename.IndexOf(Utils.realstateid.ToString());
                //string ext = filename.Substring(filename.LastIndexOf("."));
                //string t = filename.Substring(0, start);

                if (File.Exists(Utils.ProjectName + "\\" + filename + ".lnk"))
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }
            else
            {
                return false;
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            AttachComment.ShowMe();
            string comment = AttachComment.Button_Clicked;

            if (string.IsNullOrEmpty(comment))
            {
                MessageBox.Show(
                        "الرجاء إدخال نص التعليق",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button3,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                        );
                return;
            }

            if (fdlg.FileNames != null && fdlg.FileNames.Length > 0)
            {
                foreach (string filePath in fdlg.FileNames)
                {
                    string fileComment = comment;

                    // ✅ لو الامتداد Zip أو Rar يضيف "ملف مضغوط:"
                    string ext = Path.GetExtension(filePath).ToLower();
                    if (ext == ".zip" || ext == ".rar")
                    {
                        fileComment = "ملف مضغوط: " + comment;
                    }

                    AddNewAttachmentMulti(filePath, fileComment);
                }

                Buttons_toolStrip();
                MessageBox.Show("تم حفظ جميع الملفات بنجاح");
            }
            else
            {
                UpdateAttachmentComment(comment);
            }
        }


        //private void button4_Click(object sender, EventArgs e)
        //{
        //    AttachComment.ShowMe();
        //    string comment = AttachComment.Button_Clicked;

        //    if (string.IsNullOrEmpty(comment))
        //    {
        //        MessageBox.Show(
        //                "الرجاء إدخال نص التعليق",
        //                    "خطأ",
        //                    MessageBoxButtons.OK,
        //                    MessageBoxIcon.Error,
        //                    MessageBoxDefaultButton.Button3,
        //                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
        //                );
        //        return;
        //    }

        //    if (!string.IsNullOrEmpty(textBox4.Text))
        //    {
        //        AddNewAttachment(comment);
        //        Buttons_toolStrip();
        //    }
        //    else
        //    {
        //        UpdateAttachmentComment(comment);
        //    }

        //    #region
        //    //if (string.IsNullOrEmpty(comment))
        //    //{
        //    //    if (textBox4.Text != null && textBox4.Text != "")
        //    //    {
        //    //        string filename = fdlg.SafeFileName;
        //    //        string ext = filename.Substring(filename.LastIndexOf("."));
        //    //        string yy = filename.Substring(0, filename.LastIndexOf("."));
        //    //        string fullname = yy + Utils.realstateid + ext;
        //    //        int id = ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID;
        //    //        //if (this.attachmentTableAdapter.GetDataByCheck(id).Rows.Count < 0)
        //    //        //{
        //    //        if (am == "archive")
        //    //        {

        //    //            this.attachmentTableAdapter.Insert(id, fullname, fdlg.FileName, DateTime.Now.Date, result, 0);
        //    //            File.Copy(fdlg.FileName, Utils.ProjectName + "\\" + fullname);
        //    //        }
        //    //        else
        //    //        {
        //    //            this.attachmentTableAdapter.Insert(id, fullname, fdlg.FileName, DateTime.Now.Date, result, 1);
        //    //            File.Copy(fdlg.FileName, Utils.ProjectName + "\\" + fullname);
        //    //        }


        //    //        MessageBox.Show("تم الحفظ");
        //    //        if (am == "archive")
        //    //            this.attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
        //    //        else
        //    //            this.attachmentTableAdapter.Fill(this.dSrealstate.Attachment);


        //    //        //this.realStateBindingSource.ResumeBinding();
        //    //        textBox4.Text = "";
        //    //    }

        //    //    else
        //    //    {
        //    //        int idatt = Convert.ToInt32(attachmentDataGridView.CurrentRow.Cells[0].Value);

        //    //        if (am == "archive")
        //    //        {
        //    //            this.attachmentTableAdapter.UpdateQueryExist(result, 0, idatt);
        //    //            this.attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);

        //    //        }
        //    //        else
        //    //        {
        //    //            this.attachmentTableAdapter.UpdateQueryExist(result, 1, idatt);
        //    //            this.attachmentTableAdapter.Fill(this.dSrealstate.Attachment);

        //    //        }

        //    //    }
        //    //}
        //    //else { 
        //    //    MessageBox.Show("الرجاء إدخال نص التعليق");
        //    //    return;
        //    //}
        //    #endregion

        //}
        private void AddNewAttachmentMulti(string filePath, string comment)
        {
            try
            {
                string uniqueFileName = CustomPath.UniqueFileName(Path.GetFileName(filePath), Utils.realstateid);
                bool isCreated = CustomPath.CreateAttachment(filePath, uniqueFileName, "", Utils.realstateid);
                if (!isCreated) return;

                int propertyId = GetCurrentPropertyId();
                bool isVisible = false;

                bool isArchive = (am == "archive");
                int activeStatus = isArchive ? 0 : 1;
                int type = 1;

                this.attachmentTableAdapter.Insert(
                    propertyId,
                    uniqueFileName,
                    filePath,
                    DateTime.Now.Date,
                    comment,
                    activeStatus,
                    type,
                    isVisible
                );

                RefreshAttachmentGrid(isArchive);
                ClearAttachmentForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                           $"حدث خطأ أثناء حفظ المرفق: {ex.Message}",
                              "خطأ",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error,
                              MessageBoxDefaultButton.Button3,
                              MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                          );
            }
        }

        //private void AddNewAttachment(string comment)
        //{
        //    try
        //    {
        //        string uniqueFileName = CustomPath.UniqueFileName(fdlg.SafeFileName, Utils.realstateid);
        //        bool isCreated = CustomPath.CreateAttachment(fdlg.FileName, uniqueFileName, "", Utils.realstateid);
        //        if (!isCreated) return;

        //        int propertyId = GetCurrentPropertyId();
        //        bool isVisible = false;

        //        bool isArchive = (am == "archive");
        //        int activeStatus = isArchive ? 0 : 1;
        //        int type = 1;

        //        this.attachmentTableAdapter.Insert(
        //            propertyId,
        //            uniqueFileName,
        //            fdlg.FileName,
        //            DateTime.Now.Date,
        //            comment,
        //            activeStatus,
        //            type,
        //            isVisible
        //        );

        //        RefreshAttachmentGrid(isArchive);
        //        ClearAttachmentForm();


        //        MessageBox.Show(
        //                    "تم حفظ المرفق بنجاح",
        //                      "",
        //                      MessageBoxButtons.OK,
        //                      MessageBoxIcon.Information,
        //                      MessageBoxDefaultButton.Button3,
        //                      MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
        //                  );
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(
        //                   $"حدث خطأ أثناء حفظ المرفق: {ex.Message}",
        //                      "خطأ",
        //                      MessageBoxButtons.OK,
        //                      MessageBoxIcon.Error,
        //                      MessageBoxDefaultButton.Button3,
        //                      MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
        //                  );
        //    }
        //}
        private void UpdateAttachmentComment(string comment)
        {
            try
            {
                if (attachmentDataGridView.CurrentRow == null)
                {
                    MessageBox.Show(
                         "الرجاء تحديد مرفق لتعديله",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button3,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                        );

                    return;
                }

                int attachmentId = Convert.ToInt32(attachmentDataGridView.CurrentRow.Cells[0].Value);
                bool isArchive = (am == "archive");
                int activeStatus = isArchive ? 0 : 1;

                this.attachmentTableAdapter.UpdateQueryExist(comment, activeStatus, attachmentId);
                RefreshAttachmentGrid(isArchive);

                MessageBox.Show(
                            "تم تحديث التعليق بنجاح",
                              "",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information,
                              MessageBoxDefaultButton.Button3,
                              MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                          );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                         $"حدث خطأ أثناء تحديث التعليق: {ex.Message}",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button3,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                        );
            }
        }
        private int GetCurrentPropertyId()
        {
            // دالة مساعدة للحصول على ID العقار الحالي
            return ((DSrealstate.RealStateRow)this.dSrealstate.RealState
                   .Rows[realStateBindingSource.Position]).ID;
        }
        private void RefreshAttachmentGrid(bool isArchive)
        {

            // دالة مساعدة لتحديث عرض المرفقات
            if (isArchive)
                this.attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
            else
                this.attachmentTableAdapter.Fill(this.dSrealstate.Attachment);
        }
        private void ClearAttachmentForm()
        {
            // دالة مساعدة لمسح حقول المرفق
            textBox4.Text = "";
            this.realStateBindingSource.ResumeBinding();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID;
            if (am == "archive")

                this.eventTableAdapter.Fillsearch(this.dSrealstate.Event, id, "%" + searchtext.Text + "%", "%" + searchtext.Text + "%", 0);
            else
                this.eventTableAdapter.Fillsearch(this.dSrealstate.Event, id, "%" + searchtext.Text + "%", "%" + searchtext.Text + "%", 1);

        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

            if (this.dSrealstate.RealState.Rows.Count > 0)
            {
                var row = (DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position];
                Published.Checked = row.published;

                // مزامنة القيمة مع قاعدة البيانات
                clsRealState.MarkAsPublished(row.ID, row.published);
            }

            if (am == "archive")
            {
                this.eventTableAdapter.FillByArchive(this.dSrealstate.Event);
                //realStateBindingNavigatorSaveItem.Enabled = false;
                bindingNavigatorAddNewItem.Enabled = false;
                bindingNavigatorDeleteItem.Enabled = false;
            }
            else
            {
                this.eventTableAdapter.Fill(this.dSrealstate.Event);
            }

            if (this.dSrealstate.RealState.Rows.Count > 0)
            {
                var row = (DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position];
                Published.Checked = row.published;
            }

        }

        private void buildingTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //realStateBindingNavigatorSaveItem.Enabled = true;
            saved.Visible = false;

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
                            ((System.Windows.Forms.TextBox)this.ActiveControl).SelectionStart = this.ActiveControl.Text.Length + 1;

                        }
                        else
                        {
                            this.ActiveControl.Text += t.Rows[0]["Text"].ToString();
                            ((System.Windows.Forms.TextBox)this.ActiveControl).SelectionStart = this.ActiveControl.Text.Length + 1;

                        }


                    }
                }
                catch
                {

                }
            }

            if (this.ActiveControl.Name == "areaTextBox" || this.ActiveControl.Name == "priceTextBox")
            {
                chechupdatestate = false;

            }

        }

        #region
        //private void attachmentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //hadi

        //    if (attachmentDataGridView.CurrentCell.OwningColumn.Index == 2)
        //    {
        //        string path = attachmentDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
        //        string temp = path.Substring(0, 1);
        //        if ((GetFileExisting(path)))
        //        {
        //            //if (temp != "T")
        //            //{
        //            //    System.Diagnostics.Process.Start(Utils.ProjectName + "\\attachment\\" + path);
        //            //}
        //            //else
        //            //{
        //            //    int start = path.IndexOf(Utils.realstateid.ToString());
        //            //    string ext = path.Substring(path.LastIndexOf("."));
        //            //    string t = path.Substring(0, start);
        //            //    System.Diagnostics.Process.Start(Utils.ProjectName + "\\attachment\\" + path+".lnk");

        //            //}

        //            if (temp != "T")
        //            {
        //                if (File.Exists(@"d:\myFile.txt"))
        //                {
        //                    File.Delete(@"d:\myFile.txt");
        //                }
        //                using (StreamWriter w = File.AppendText(@"d:\myFile.txt"))
        //                {
        //                    w.WriteLine(Utils.ProjectName + "\\" + path);
        //                }
        //                System.Diagnostics.Process.Start(Utils.ProjectName + "\\" + path);
        //                File.SetAttributes(@"d:\myFile.txt", FileAttributes.Hidden);
        //            }
        //            else
        //            {
        //                int start = path.IndexOf(Utils.realstateid.ToString());
        //                string ext = path.Substring(path.LastIndexOf("."));
        //                string t = path.Substring(0, start);
        //                if (File.Exists(@"d:\myFile.txt"))
        //                {
        //                    File.Delete(@"d:\myFile.txt");
        //                }


        //                string PathFile = Utils.ProjectName + "\\" + path + ".lnk";

        //                string kmzPath = Path.Combine(Utils.ProjectName, $"{PathFile}");

        //                using (StreamWriter w = File.AppendText(@"d:\myFile.txt"))
        //                {
        //                    w.WriteLine(PathFile);
        //                }

        //                if (Path.GetExtension(path) == ".kmz")
        //                {

        //                    OpenGoogleEarthPath(path);
        //                }
        //                else
        //                    System.Diagnostics.Process.Start(PathFile);

        //                File.SetAttributes(@"d:\myFile.txt", FileAttributes.Hidden);

        //            }

        //        }
        //        else
        //        {
        //            MessageBox.Show("الملف غير موجود");
        //        }
        //    }
        //}

        //private void OpenGoogleEarthPath(string path)
        //{
        //    string googleEarthPath = @"C:\Program Files\Google\Google Earth Pro\client\googleearth.exe";

        //    if (!File.Exists(googleEarthPath))
        //    {
        //        MessageBox.Show("Google Earth Pro is not installed or the path is incorrect.");
        //        return;
        //    }

        //    if (!File.Exists(path))
        //    {
        //        MessageBox.Show("الملف غير موجود");
        //        return;
        //    }

        //    var psi = new System.Diagnostics.ProcessStartInfo
        //    {
        //        FileName = googleEarthPath,
        //        Arguments = $"\"{path}\"",
        //        UseShellExecute = true
        //    };

        //    System.Diagnostics.Process.Start(psi);
        //}
        #endregion

        private void attachmentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 2) return;

            string fileName = attachmentDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
            string isShortcut = fileName.Substring(0, 1);
            int attachmentId = Convert.ToInt32(attachmentDataGridView.CurrentCell.OwningRow.Cells[0].Value);
            string recordId = attachmentDataGridView.CurrentCell.OwningRow.Cells[1].Value.ToString();

            string ext = Path.GetExtension(fileName);

            string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

            string originalFileName = nameWithoutExt;
            if (nameWithoutExt.EndsWith(recordId))
            {
                originalFileName = nameWithoutExt.Substring(0, nameWithoutExt.Length - recordId.Length);
            }

            string fileNameOriginal = originalFileName + ext;
            if ((GetFileExisting(fileNameOriginal, fileName)))
            {
                //if (isShortcut == "T")
                //    CustomPath.OpenAttachmentShortcut(fileNameOriginal, "");
                //else
                CustomPath.OpenAttachment(fileNameOriginal, "", fileName);
            }
            else
            {
                MessageBox.Show(
                                  $"الملف {fileName} غير موجود في المسار ",
                                   "خطأ",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button3,
                                   MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                               );

            }

        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            flagg = true;
            if (clicked == "clicked")
            {
                realStateBindingNavigatorSaveItem.PerformClick();
                bindingNavigatorAddNewItem.PerformClick();
                this.clicked = "clicked";
            }
            else
            {

                startRentDateDateTimePicker.Value = DateTime.Now;
                endRendDateDateTimePicker.Value = DateTime.Now;

                dtpDateOfModification.Value = DateTime.Now.Date.AddDays(-2).AddMonths(-2).AddYears(-2);
                dtpDateOfModification.Value = DateTime.Now;


                rDateOchangeDateTimePicker.Value = DateTime.Now.Date.AddDays(-2).AddMonths(-2).AddYears(-2);
                rDateOchangeDateTimePicker.Value = DateTime.Now.Date;

                cmbRegion.SelectedValue = 15;
                status_IDListBox.SelectedValue = 2;
                bindingNavigatorMovePreviousItem.Enabled = false;
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorDeleteItem.Enabled = false;
                //realStateBindingNavigatorSaveItem.Enabled = true;

                Restore.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                saved.Visible = false;
                chechupdatestate = false;
                this.clicked = "clicked";

            }

        }

        private void status_IDListBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //realStateBindingNavigatorSaveItem.Enabled = true;
            saved.Visible = false;
            //if (status_IDListBox.SelectedValue.ToString() == "2")
            //{
            //    startRentDateDateTimePicker.Value = DateTime.Now;
            //    endRendDateDateTimePicker.Value = DateTime.Now;
            //    remainingDayTextBox.Text = "0";
            //    periodTextBox.Text = "0";

            //}

            if (status_IDListBox.SelectedValue != null && status_IDListBox.SelectedValue.ToString() == "2")
            {
                startRentDateDateTimePicker.Value = DateTime.Now;
                endRendDateDateTimePicker.Value = DateTime.Now;
                remainingDayTextBox.Text = "0";
                periodTextBox.Text = "0";
            }


            chechupdatestate = false;

        }

        private void empty_Click(object sender, EventArgs e)
        {

            //            this.realStateTableAdapter.UpdateQuery(2, recored_id);
            status_IDListBox.SelectedValue = 2;
            startRentDateDateTimePicker.Value = DateTime.Now;
            endRendDateDateTimePicker.Value = DateTime.Now;
            remainingDayTextBox.Text = "0";
            periodTextBox.Text = "0";
            //realStateBindingNavigatorSaveItem.Enabled = true;
            saved.Visible = false;
        }

        string basePath = Utils.ProjectName;
        bool hasUnlinked = false;
        private bool HandlePendingAttachmentsForCurrentRealState()
        {
            // Get current real estate info
            var currentRow = (DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position];
            long currentID = currentRow.ID;
            //string currentRegionName = clsRegion.GetRegionNameByID(currentRow.Region_ID)?.Trim();

            string currentRegionName = null;
            if (!currentRow.IsRegion_IDNull())
            {
                currentRegionName = clsRegion.GetRegionNameByID(currentRow.Region_ID)?.Trim();
            }
            //string currentSubRegion = currentRow.SubResgionID?.Trim();
            string currentSubRegion = null;
            if (!currentRow.IsSubResgionIDNull())
            {
                currentSubRegion = currentRow.SubResgionID.Trim();
            }
            //string currentBuilding = currentRow.Building?.Trim();
            string currentBuilding = null;
            if (!currentRow.IsBuildingNull())
            {
                currentBuilding = currentRow.Building.Trim();
            }


            if (string.IsNullOrWhiteSpace(currentRegionName) ||
                string.IsNullOrWhiteSpace(currentSubRegion) ||
                string.IsNullOrWhiteSpace(currentBuilding))
                return false;

            var tempAttachments = clsTempAttachment.GetAllTempAttachments();
            if (tempAttachments == null || tempAttachments.Count == 0)
                return false;


            foreach (var temp in tempAttachments)
            {
                if (temp.Region?.Trim() == currentRegionName &&
                    temp.SubRegion?.Trim() == currentSubRegion &&
                    temp.Building?.Trim() == currentBuilding)
                {
                    if (!clsAttachment.Exists(currentID, temp.Comment)) // مش مربوط
                    {
                        string filePath = Path.Combine(basePath, "TempAttachment", temp.FileName);
                        clsAttachment newAttach = new clsAttachment()
                        {
                            RealStateID = currentID,
                            FileName = temp.FileName,
                            Path = filePath,
                            Comment = temp.Comment,
                            Type = 2,
                            DateOFAttash = DateTime.Now
                        };
                        clsAttachment.AddAttachment(newAttach);
                        hasUnlinked = true;
                    }
                }
            }

            if (hasUnlinked)
                RefreshAttachmentGrid(false);

            return hasUnlinked;
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{

        //    //const int WM_KEYDOWN = 0x100;
        //    //if (msg.Msg == WM_KEYDOWN)
        //    //{
        //    if (keyData == Keys.Escape)
        //    {
        //        if (SnewMessageBox != null)
        //        {

        //            SnewMessageBox.Dispose();
        //            AlarmSound.main_timer.Start();
        //            AlarmSound.player.Play();
        //        }

        //        if (!chechupdatestate || !checkupdate())
        //        {

        //            DialogResult result1 = MessageBox.Show("هل تريد الحفظ ", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

        //            if (result1 == DialogResult.Yes)
        //            {
        //                realStateBindingNavigatorSaveItem.PerformClick();
        //                close = "closed";
        //                this.Close();
        //            }
        //            if (result1 == DialogResult.No)
        //            {

        //                close = "closed";
        //                this.Close();
        //            }


        //        }
        //        else
        //        {

        //            close = "closed";
        //            this.Close();
        //        }
        //    }

        //    if (keyData == Keys.F2)
        //    {

        //        realStateBindingNavigatorSaveItem.PerformClick();
        //        return false;
        //    }

        //    if (keyData == Keys.F5)
        //    {
        //        realStateBindingNavigatorSaveItem.PerformClick();
        //        bindingNavigatorAddNewItem.PerformClick();
        //        cmbRegion.Focus();
        //        return true;
        //    }

        //    if (keyData == Keys.F11)
        //    {
        //        Utils.EncryptMode = !Utils.EncryptMode;
        //        encrypt();
        //        return true;

        //    }

        //    if (keyData == Keys.F1)
        //    {

        //        back = "back";
        //        this.Close();
        //        return true;

        //    }

        //    if (((keyData & Keys.Alt) == Keys.Alt))
        //    {
        //        return true;
        //    }

        //    if (((keyData & Keys.Shift) == Keys.Shift) && ((keyData & Keys.F10) == Keys.F10))
        //    {
        //        return true;
        //    }

        //    if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.F10) == Keys.F10))
        //    {
        //        return true;
        //    }

        //    return false;
        //}
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (SnewMessageBox != null)
                {
                    SnewMessageBox.Dispose();
                    AlarmSound.main_timer.Start();
                    AlarmSound.player.Play();
                }

                if (!chechupdatestate || !checkupdate())
                {
                    DialogResult result1 = MessageBox.Show(
                        "هل تريد الحفظ ",
                        "تنبيه",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Asterisk,
                        MessageBoxDefaultButton.Button2,
                        MessageBoxOptions.RightAlign);

                    if (result1 == DialogResult.Yes)
                    {
                        realStateBindingNavigatorSaveItem.PerformClick();
                        close = "closed";
                        this.Close();
                    }
                    else if (result1 == DialogResult.No)
                    {
                        close = "closed";
                        this.Close();
                    }
                    else if (result1 == DialogResult.Cancel)
                    {
                        // إلغاء الإغلاق والبقاء في نفس الفورم
                        return true;
                    }
                }
                else
                {
                    close = "closed";
                    this.Close();
                }

                return true; // منع أي معالجة أخرى للـ ESC
            }

            if (keyData == Keys.F2)
            {
                realStateBindingNavigatorSaveItem.PerformClick();
                return false;
            }

            if (keyData == Keys.F5)
            {
                realStateBindingNavigatorSaveItem.PerformClick();
                bindingNavigatorAddNewItem.PerformClick();
                cmbRegion.Focus();
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
                back = "back";
                this.Close();
                return true;
            }

            if (((keyData & Keys.Alt) == Keys.Alt))
                return true;

            if (((keyData & Keys.Shift) == Keys.Shift) && ((keyData & Keys.F10) == Keys.F10))
                return true;

            if (((keyData & Keys.Control) == Keys.Control) && ((keyData & Keys.F10) == Keys.F10))
                return true;

            return false;
        }


        private void periodTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //realStateBindingNavigatorSaveItem.Enabled = true;
            saved.Visible = false;
            if (periodTextBox.Text != "" && periodTextBox.Text != null && periodTextBox.Text != "0")
            {
                ss = "not go";
                //                startRentDateDateTimePicker.Value = DateTime.Now.Date;
                endRendDateDateTimePicker.Value = DateTime.Now.Date;
                endRendDateDateTimePicker.Value = startRentDateDateTimePicker.Value.Date.AddMonths(Convert.ToInt32(periodTextBox.Text));
                remainingDayTextBox.Text = GetDates.DateDiffDays(DateTime.Now.Date, endRendDateDateTimePicker.Value.Date).ToString();
                if (remainingDayTextBox.Text == "0")
                {
                    status_IDListBox.SelectedValue = 2;
                    //empty.Visible = true;
                }
                else
                {
                    status_IDListBox.SelectedValue = 1;
                    //empty.Visible = false;

                }
            }
            else
            {
                ss = "not go";
                if (this.dSrealstate.RealState.Rows.Count >= realStateBindingSource.Count)
                {
                    startRentDateDateTimePicker.Value = ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).StartRentDate.Date;
                    endRendDateDateTimePicker.Value = ((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).EndRendDate.Date;
                    remainingDayTextBox.Text = GetDates.DateDiffDays(DateTime.Now.Date, endRendDateDateTimePicker.Value.Date).ToString();
                }
                if (remainingDayTextBox.Text == "0")
                {
                    status_IDListBox.SelectedValue = 2;
                    //empty.Visible = true;

                }
                else
                {
                    status_IDListBox.SelectedValue = 1;
                    //empty.Visible = false;

                }
            }
            ss = "go";

            chechupdatestate = false;
        }

        private void startRentDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

            if (ss == "go")
            {

                DateTime d1 = startRentDateDateTimePicker.Value.Date;
                DateTime d2 = endRendDateDateTimePicker.Value.Date;
                if (d1.Date <= d2.Date)
                {

                    int monthsApart = 12 * (d1.Year - d2.Year) +
                    d1.Month - d2.Month;
                    int months = Math.Abs(monthsApart);
                    periodTextBox.Text = months.ToString();

                    remainingDayTextBox.Text = GetDates.DateDiffDays(DateTime.Now.Date, endRendDateDateTimePicker.Value.Date).ToString();

                    if (remainingDayTextBox.Text == "0")
                    {
                        status_IDListBox.SelectedValue = 2;
                        //empty.Visible = true;


                    }
                    else
                    {
                        status_IDListBox.SelectedValue = 1;
                        //empty.Visible = false;

                    }

                }
                else
                {

                    // MessageBox.Show("خطأ بالتواريخ");
                    // startRentDateDateTimePicker.Focus();
                }



                startRentDateDateTimePicker.Value = startRentDateDateTimePicker.Value.Date;
                endRendDateDateTimePicker.Value = endRendDateDateTimePicker.Value.Date;
            }


        }

        private void startRentDateDateTimePicker_KeyUp(object sender, KeyEventArgs e)
        {
            //hadi
            //realStateBindingNavigatorSaveItem.Enabled = true;
            saved.Visible = false;

            if (ss == "go")
            {

                DateTime d1 = startRentDateDateTimePicker.Value.Date;
                DateTime d2 = endRendDateDateTimePicker.Value.Date;

                int M = Math.Abs((d1.Year - d2.Year));
                //                int months = ((M * 12) + Math.Abs((d1.Month - d2.Month)));



                int monthsApart = 12 * (d1.Year - d2.Year) +
                d1.Month - d2.Month;
                int months = Math.Abs(monthsApart);
                periodTextBox.Text = months.ToString();
                remainingDayTextBox.Text = GetDates.DateDiffDays(DateTime.Now.Date, endRendDateDateTimePicker.Value.Date).ToString();

                if (remainingDayTextBox.Text == "0")
                {
                    status_IDListBox.SelectedValue = 2;
                    //empty.Visible = true;

                }
                else
                {
                    status_IDListBox.SelectedValue = 1;
                    //empty.Visible = false;

                }



            }
        }

        private void Restore_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("هل تريد استعاده العقار ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

            if (result1 == DialogResult.Yes)
            {
                this.realStateTableAdapter.UpdateRestore(Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID));

                
                this.attachmentTableAdapter.UpdateQueryRestore(Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID));
                this.eventTableAdapter.UpdateQueryRestore(Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID));
                this.realStateTableAdapter.FillArchive(this.dSrealstate.RealState);

                if (this.realStateBindingSource.Count == 0)
                {
                    bindingNavigatorAddNewItem.Enabled = false;
                    //realStateBindingNavigatorSaveItem.Enabled = false;
                    saved.Visible = true;
                    Restore.Enabled = false;
                    button1.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }

            }
        }

        private void entranceTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == MouseButtons.Middle.ToString())
            {
                DataTable dt = new DataTable();
                dt = this.shorCutKeysTableAdapter.GetData();
                string al = "";
                if (dt.Rows.Count > 0)
                {
                    for (int h = 0; h < dt.Rows.Count; h++)
                    {

                        al += dt.Rows[h]["Key_Two"] + " + " + dt.Rows[h]["Key_One"] + " = " + dt.Rows[h]["Text"] + "\n";
                    }

                }

                m_wndToolTip.SetToolTip(this.ActiveControl, al);
            }
        }


        string gnon = "";
        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result1 = MessageBox.Show("هل تريد حذف العقار ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            DialogResult result2;

            if (result1 == DialogResult.Yes)
            {
                result2 = MessageBox.Show("هل انت متأكد من حذف العقار ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (result2 == DialogResult.Yes)
                {
                    Utils.deleteattch(Utils.realstateid);
                    bindingNavigatorDeleteItem.PerformClick();
                    //continues = true;
                    gnon = "del";

                    realStateBindingNavigatorSaveItem.PerformClick();



                }

            }

        }

        /// <summary>
        /// ///////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Realstate_FormClosing(object sender, FormClosingEventArgs e)
        {
   

            if (close != "closed")
            {
                if (SnewMessageBox != null)
                {

                    SnewMessageBox.Dispose();
                    AlarmSound.main_timer.Start();
                    AlarmSound.player.Play();
                }

                if (!chechupdatestate || !checkupdate())//|| HandlePendingAttachmentsForCurrentRealState())
                {
                    DialogResult result1 = MessageBox.Show(
                            "هل تريد الحفظ ", "تنبيه",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk,
                            MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);


                    if (result1 == DialogResult.Yes)
                    {
                        realStateBindingNavigatorSaveItem.PerformClick();
                        close = "closed";
                        this.Close();
                    }
                    if (result1 == DialogResult.No)
                    {

                        close = "closed";
                        this.Close();
                    }
                    if (result1 == DialogResult.Cancel)
                    {
                        // منع الإغلاق والبقاء في نفس الفورم
                        e.Cancel = true;
                        return;
                    }

                }

            }
            close = "";

          
        }

        private void phone_oneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.ActiveControl.Name == "areaTextBox")
            {
                if (this.ActiveControl.Text.Length <= 1)
                {
                    if (e.KeyChar.ToString() == "+")
                    {
                        this.ActiveControl.Text += "000";
                    }
                }
            }
            else
            {

                if (e.KeyChar.ToString() == "+")
                {
                    this.ActiveControl.Text += "000";
                }
            }
            //realStateBindingNavigatorSaveItem.Enabled = true;
            saved.Visible = false;

            //only allow numbers and control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                //   MessageBox.Show("رقم الهاتف غير كامل");
            }
        }

        private void toolStripButton2_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result1 = MessageBox.Show("هل تريد حذف الحدث ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            DialogResult result2;

            if (result1 == DialogResult.Yes)
            {
                result2 = MessageBox.Show("هل انت متأكد من حذف الحدث ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (result2 == DialogResult.Yes)
                    toolStripButton2.PerformClick();

            }
        }

        private void attachmentDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //string path = attachmentDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
            //File.Delete(Utils.ProjectName + "\\attachment\\" + path);
            //3 = false;
        }

        private void eventTextBox_Leave(object sender, EventArgs e)
        {
            eventTextBox.ReadOnly = true;
            saved.Visible = false;
            chechupdatestate = false;
        }

        private void eventDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            eventTextBox.ReadOnly = false;

        }

        //private void toolStripButton4_MouseDown(object sender, MouseEventArgs e)
        //{
        //    DialogResult result2 = MessageBox.Show("هل انت متأكد من حذف المرفق ", "تنبيه",
        //        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,
        //          MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        //    if (result2 == DialogResult.Yes)
        //    {
        //        string path = attachmentDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
        //        string temp = path.Substring(0, 1);

        //        if (File.Exists(Utils.ProjectName + "\\" + path) && temp != "T")
        //        {
        //            File.Delete(Utils.ProjectName + "\\" + path);
        //            chechupdatestate = false;
        //            toolStripButton4.PerformClick();
        //            realStateBindingNavigatorSaveItem.PerformClick();
        //        }
        //        else if (temp == "T")
        //        {
        //            File.Delete(Utils.ProjectName + "\\" + path + ".lnk");
        //            chechupdatestate = false;
        //            toolStripButton4.PerformClick();
        //            realStateBindingNavigatorSaveItem.PerformClick();
        //        }
        //        else
        //        {
        //            MessageBox.Show(
        //                      "الملف غير موجود",
        //                       "خطأ",
        //                       MessageBoxButtons.OK,
        //                       MessageBoxIcon.Error,
        //                       MessageBoxDefaultButton.Button3,
        //                       MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
        //                   );
        //        }
        //    }
        //}
        //private void toolStripButton4_MouseDown(object sender, MouseEventArgs e)
        //{
        //    DialogResult result2 = MessageBox.Show("هل انت متأكد من حذف المرفق؟", "تنبيه",
        //    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,
        //    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

        //    if (result2 != DialogResult.Yes)
        //        return;


        //    string fileNameWithId = attachmentDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
        //    int attachmentId = Convert.ToInt32(attachmentDataGridView.CurrentCell.OwningRow.Cells[0].Value);
        //    string recordId = attachmentDataGridView.CurrentCell.OwningRow.Cells[1].Value.ToString();

        //    // استخراج الامتداد
        //    string ext = Path.GetExtension(fileNameWithId);

        //    // حذف الامتداد مؤقتًا علشان نشتغل على اسم الملف
        //    string nameWithoutExt = Path.GetFileNameWithoutExtension(fileNameWithId);

        //    // إزالة رقم الريكورد من نهاية الاسم
        //    string originalFileName = nameWithoutExt;
        //    if (nameWithoutExt.EndsWith(recordId))
        //    {
        //        originalFileName = nameWithoutExt.Substring(0, nameWithoutExt.Length - recordId.Length);
        //    }

        //    // لو حابة ترجعي الاسم كامل بالامتداد بدون رقم الريكورد
        //    string finalFileName = originalFileName + ext;

        //    PublicFileName = finalFileName;
        //    // تحقق من مصدر الملف
        //    string tempPath = Utils.ProjectName + "\\TempAttachment\\" + finalFileName;

        //    bool isFromTemp = File.Exists(tempPath);

        //    // حذف من قاعدة البيانات
        //    clsAttachment attachment = new clsAttachment();
        //    attachment.ID = attachmentId;
        //    attachment.Delete();

        //    attachmentDataGridView.Rows.Remove(attachmentDataGridView.CurrentRow);

        //    if (isFromTemp)
        //    {
        //        var tempAttachment = clsTempAttachment.GetTempFileByName(finalFileName);

        //        if (tempAttachment != null)
        //        {
        //            deletedAutoAttachments.Add(new TempDeletedAttachment
        //            {
        //                FileName = finalFileName,
        //                Comment = tempAttachment.Comment
        //            });
        //        }
        //    }
        //    else
        //    {
        //        File.Delete(Utils.ProjectName + "\\" + fileNameWithId);
        //    }

        //    chechupdatestate = false;

        //    ///TaskDeletedAttachments
        //    foreach (var att in deletedAutoAttachments)
        //    {
        //        string ext2 = Path.GetExtension(att.FileName);
        //        string yy = Path.GetFileNameWithoutExtension(att.FileName);
        //        string fullname = yy + Utils.realstateid + ext2;

        //        if (!GetFileExisting(yy)) // احتمال تصحيحها: fullname بدل yy
        //        {
        //            attachmentTableAdapter.Insert(Utils.realstateid, fullname, "", DateTime.Now.Date, att.Comment, (am == "archive" ? 0 : 1), 2, false);

        //            if (am == "archive")
        //                attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
        //            else
        //                attachmentTableAdapter.Fill(this.dSrealstate.Attachment);
        //        }
        //    }
        //    deletedAutoAttachments.Clear();
        //}


        private async void toolStripButton4_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result2 = MessageBox.Show("هل انت متأكد من حذف المرفق؟", "تنبيه",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,
            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

            if (result2 != DialogResult.Yes)
                return;


            string fileNameWithId = attachmentDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
            int attachmentId = Convert.ToInt32(attachmentDataGridView.CurrentCell.OwningRow.Cells[0].Value);
            string recordId = attachmentDataGridView.CurrentCell.OwningRow.Cells[1].Value.ToString();

            // التحقق إذا كان المرفق أوتوماتيكي (النوع 2) ومنع حذفه
            if (IsAutoAttachment(attachmentId))
            {
                MessageBox.Show("لا يمكن حذف المرفقات الأوتوماتيكية.", "تنبيه",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            // استخراج الامتداد
            string ext = Path.GetExtension(fileNameWithId);

            // حذف الامتداد مؤقتًا علشان نشتغل على اسم الملف
            string nameWithoutExt = Path.GetFileNameWithoutExtension(fileNameWithId);

            // إزالة رقم الريكورد من نهاية الاسم
            string originalFileName = nameWithoutExt;
            if (nameWithoutExt.EndsWith(recordId))
            {
                originalFileName = nameWithoutExt.Substring(0, nameWithoutExt.Length - recordId.Length);
            }

            // لو حابة ترجعي الاسم كامل بالامتداد بدون رقم الريكورد
            string finalFileName = originalFileName + ext;

            PublicFileName = finalFileName;
            // تحقق من مصدر الملف
            string tempPath = Utils.ProjectName + "\\TempAttachment\\" + finalFileName;

            bool isFromTemp = File.Exists(tempPath);

            // حذف من قاعدة البيانات
            clsAttachment attachment = new clsAttachment();
            attachment.ID = attachmentId;
            attachment.Delete();


            this.attachmentTableAdapter.Fill(this.dSrealstate.Attachment);

            //attachmentDataGridView.Rows.Remove(attachmentDataGridView.CurrentRow);

            RefreshAttachmentGrid(false);

            File.Delete(Utils.ProjectName + "\\" + fileNameWithId);


            //chechupdatestate = false;

            ///TaskDeletedAttachments
            //foreach (var att in deletedAutoAttachments)
            //{
            //    string ext2 = Path.GetExtension(att.FileName);
            //    string yy = Path.GetFileNameWithoutExtension(att.FileName);
            //    string fullname = yy + Utils.realstateid + ext2;
            //    bool IsVisible = att.visible;
            //    if (!GetFileExisting(yy)) // احتمال تصحيحها: fullname بدل yy
            //    {
            //        attachmentTableAdapter.Insert(Utils.realstateid, fullname, "", DateTime.Now.Date, att.Comment, (am == "archive" ? 0 : 1), 2, IsVisible);

            //        if (am == "archive")
            //            attachmentTableAdapter.FillByArchive(this.dSrealstate.Attachment);
            //        else
            //            attachmentTableAdapter.Fill(this.dSrealstate.Attachment);
            //    }
            //}
            //deletedAutoAttachments.Clear();
        }


        private void UpdateButtonVisibility()
        {
            if (status_IDListBox.SelectedValue != null)
            {
                // If "غير مؤجر" (status = 2), hide button, else show it
                if (status_IDListBox.SelectedValue.ToString() == "2")
                {
                    empty.Visible = false;
                }
                else
                {
                    empty.Visible = true;
                }
            }
        }

        private void status_IDListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (status_IDListBox.SelectedValue != null && status_IDListBox.SelectedValue.ToString() == "1")
                {
                    status_IDListBox.BackColor = Color.Red;
                    status_IDListBox.ForeColor = Color.White;

                }
                else
                {
                    status_IDListBox.BackColor = Color.White;
                    status_IDListBox.ForeColor = Color.Black;

                }

                UpdateButtonVisibility();
            }
            catch
            {

            }
        }


        public Boolean checkupdate()
        {
            Boolean forme = true;

            string subregion = "";
            string building = "";
            int floor = 0;
            string fcomment = "";
            string md5al;
            string eljha;
            int buildingtype;
            string owner;
            string phoneone;
            string phonetow;
            string mobile;
            string mobile2;
            string othertext;
            int eksa2;
            int rental;
            Boolean key;
            string notetext;
            string info;
            int statuc;

            ////////////////////////////////////////////////////////////////////////////
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT ID from RealState WHERE ";
            try
            {

                //if (cmbRegion.SelectedValue.ToString() != "")
                if (cmbRegion.SelectedValue != null && cmbRegion.SelectedValue.ToString() != "")
                {
                    //  region = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                    SqlStatement += " RealState.Region_ID = " + Convert.ToInt32(cmbRegion.SelectedValue.ToString()) + "";
                    SqlStatement += " and ";
                }

                if (txtSubResgion.Text != "")
                {
                    subregion = txtSubResgion.Text;
                    SqlStatement += " RealState.SubResgionID = '" + subregion + "'";
                    SqlStatement += " and ";

                }

                if (txtBuilding.Text != "")
                {
                    building = txtBuilding.Text;
                    SqlStatement += " RealState.Building like '%" + building + "%'";
                    SqlStatement += " and ";


                }
                if (txtFloor.Text.ToString() != "")
                {
                    floor = Convert.ToInt32(txtFloor.Text);
                    SqlStatement += " RealState.Floor = " + Convert.ToInt32(floor) + "";
                    SqlStatement += " and ";

                }

                if (txtFloorComment.Text != "")
                {
                    fcomment = txtFloorComment.Text;
                    SqlStatement += " RealState.FloorComment = '" + fcomment + "'";
                    SqlStatement += " and ";

                }

                if (txtEntrance.Text != "")
                {
                    md5al = txtEntrance.Text;
                    SqlStatement += " RealState.Entrance = '" + md5al + "'";
                    SqlStatement += " and ";
                }
                if (txtDistance.Text != "")
                {
                    eljha = txtDistance.Text;
                    SqlStatement += " RealState.Distance = '" + eljha + "'";
                    SqlStatement += " and ";
                }

                if (cmbBuildingType.SelectedValue != null)
                {
                    buildingtype = Convert.ToInt32(cmbBuildingType.SelectedValue.ToString());
                    SqlStatement += " RealState.Building_Type_ID= " + buildingtype;
                    SqlStatement += " and ";
                }

                if (txtOwner.Text != "")
                {
                    owner = txtOwner.Text;
                    SqlStatement += " RealState.Owner = '" + owner + "'";
                    SqlStatement += " and ";
                }




                if (txtPhoneOne.Text != "")
                {
                    phoneone = txtPhoneOne.Text;
                    SqlStatement += " RealState.Phone_one = '" + phoneone + "'";
                    SqlStatement += " and ";
                }

                if (txtPhoneTow.Text != "")
                {
                    phonetow = txtPhoneTow.Text;
                    SqlStatement += " RealState.Phone_Two = '" + phonetow + "'";
                    SqlStatement += " and ";
                }
                if (txtMobile.Text != "")
                {
                    mobile = txtMobile.Text;
                    SqlStatement += " RealState.Mobile = '" + mobile + "'";
                    SqlStatement += " and ";
                }

                if (txtMobile2.Text != "")
                {
                    mobile2 = txtMobile2.Text;
                    SqlStatement += " RealState.Mobile2 = '" + mobile2 + "'";
                    SqlStatement += " and ";
                }

                if (txtOther.Text != "")
                {
                    othertext = txtOther.Text;
                    SqlStatement += " RealState.Other = '" + othertext + "'";
                    SqlStatement += " and ";
                }

                if (comboBox3.SelectedValue != null)
                {
                    eksa2 = Convert.ToInt32(comboBox3.SelectedValue.ToString());
                    SqlStatement += " RealState.investiture= " + eksa2;
                    SqlStatement += " and ";
                }

                if (comboBox4.SelectedValue != null)
                {
                    rental = Convert.ToInt32(comboBox4.SelectedValue.ToString());
                    SqlStatement += " RealState.WayOfRent= " + rental;
                    SqlStatement += " and ";
                }

                if (keyCheckBox.Checked != null)
                {
                    key = keyCheckBox.Checked;
                    SqlStatement += " RealState.Key = " + key;
                    SqlStatement += " and ";

                }


                if (noteTextBox.Text != "")
                {
                    notetext = noteTextBox.Text;
                    SqlStatement += " RealState.Note= '" + notetext + "'";
                    SqlStatement += " and ";
                }

                if (info_SourceTextBox.Text != "")
                {
                    info = info_SourceTextBox.Text;
                    SqlStatement += " RealState.Info_Source = '" + info + "'";
                    SqlStatement += " and ";
                }

                if (status_IDListBox.SelectedValue != null)
                {
                    statuc = Convert.ToInt32(status_IDListBox.SelectedValue.ToString());
                    SqlStatement += " RealState.Status_ID = " + statuc;
                    SqlStatement += " and ";

                }



            }
            catch
            {
            }
            //////////////////////////////////////////////////////////////////////////////
            if (SqlStatement != "SELECT ID from RealState WHERE ")
            {
                SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and")) + "and id=" + Utils.realstateid;
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
                        forme = true;
                    else
                        forme = false;
                }
                catch (Exception)
                {
                    throw;

                }
            }

            return forme;

        }
        public Boolean checkduplicate()
        {
            Boolean forme = true;
            string subregion = "";
            string building = "";
            int floor = 0;
            ////////////////////////////////////////////////////////////////////////////
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT ID from RealState WHERE ";

            if (txtSubResgion.Text != "")
            {
                subregion = txtSubResgion.Text;
                SqlStatement += " RealState.SubResgionID = '" + subregion + "'";
                SqlStatement += " and ";

            }

            if (txtBuilding.Text != "")
            {
                building = txtBuilding.Text;
                SqlStatement += " RealState.Building like '%" + building + "%'";
                SqlStatement += " and ";


            }
            if (txtFloor.Text.ToString() != "")
            {
                floor = Convert.ToInt32(txtFloor.Text);
                SqlStatement += " RealState.Floor = " + Convert.ToInt32(floor) + "";
                SqlStatement += " and ";

            }

            //////////////////////////////////////////////////////////////////////////////
            if (SqlStatement != "SELECT ID from RealState WHERE ")
            {
                //if (clicked == "clicked")
                //{
                //    SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and"));
                //}
                //else
                //{
                SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and")) + "and id=" + Utils.realstateid;
                // }
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
                        forme = true;
                    else
                        forme = false;
                }
                catch (Exception)
                {
                    throw;

                }
            }

            return forme;

        }

        public Boolean checkdTemplate()
        {
            Boolean forme = true;
            string subregion = "";
            string building = "";

            ////////////////////////////////////////////////////////////////////////////
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT ID from RealState WHERE ";

            try
            {

                //if (cmbRegion.SelectedValue.ToString() != "")
                //{
                //    //  region = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                //    SqlStatement += " RealState.Region_ID = " + Convert.ToInt32(cmbRegion.SelectedValue.ToString()) + "";
                //    SqlStatement += " and ";
                //}
                if (cmbRegion.SelectedValue != null && !string.IsNullOrEmpty(cmbRegion.SelectedValue.ToString()))
                {
                    SqlStatement += " RealState.Region_ID = " + Convert.ToInt32(cmbRegion.SelectedValue) + "";
                    SqlStatement += " and ";
                }

                if (txtSubResgion.Text != "")
                {
                    subregion = txtSubResgion.Text;
                    SqlStatement += " RealState.SubResgionID = '" + subregion + "'";
                    SqlStatement += " and ";

                }

                if (txtBuilding.Text != "")
                {
                    building = txtBuilding.Text;
                    SqlStatement += " RealState.Building like '%" + building + "%'";
                    SqlStatement += " and ";


                }

                if (am == "archive")
                {
                    SqlStatement += "   RealState.active=0";
                    SqlStatement += " and ";

                }
                else
                {
                    SqlStatement += "   RealState.active=1";
                    SqlStatement += " and ";
                }

                //lulu
            }
            catch
            {
            }

            //////////////////////////////////////////////////////////////////////////////
            if (SqlStatement != "SELECT ID from RealState WHERE ")
            {
                SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and")) + "and id=" + Utils.realstateid;
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
                        forme = true;
                    else
                        forme = false;
                }
                catch (Exception)
                {
                    throw;

                }
            }

            return forme;

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox4.SelectedValue != null && comboBox4.SelectedValue.ToString() == "1")
                {
                    //mafrosh
                    comboBox4.ForeColor = Color.Green;
                }
                else if (comboBox4.SelectedValue != null && comboBox4.SelectedValue.ToString() == "2")
                {

                    comboBox4.ForeColor = Color.Blue;

                }
            }
            catch
            {
            }
        }





        private void realStateBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (!formLoaded) return;  // ما تشغلش الكود قبل ما الفورم يخلص Load
            if (Published == null) return; // اتأكد إن الـ CheckBox موجود

            if (realStateBindingSource.Position >= 0 &&
                realStateBindingSource.Position < this.dSrealstate.RealState.Rows.Count)
            {
                var row = (DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position];

                // لو العمود published ممكن يكون Null
                Published.Checked = !row.IsNull("published") && row.published;
            }
            else
            {
                Published.Checked = false;
                //Utils.realstateid = 0;
            }
        }

        private void Published_CheckedChanged(object sender, EventArgs e)
        {
            if (realStateBindingSource.Current is DataRowView currentRow)
            {
                bool isChecked = ((CheckBox)sender).Checked;

                // ✅ مجرد تحديث في DataSet
                currentRow["published"] = isChecked;
            }

            chechupdatestate = false;
            saved.Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.dSrealstate.RealState.Rows.Count >= realStateBindingSource.Count)
            {

                userTextBox.Text = Utils.current_user.ToString();
                eventTextBox.ReadOnly = false;
                eventTextBox.Focus();
                if (am == "archive")
                {
                    activeTextBox.Text = "0";

                    dateDateTimePicker.Value = DateTime.Now.AddDays(-2).AddMonths(-2).AddYears(-2);
                    dateDateTimePicker.Value = DateTime.Now;

                    rDateOchangeEventDateTimePicker.Value = DateTime.Now.Date.AddDays(-2).AddMonths(-2).AddYears(-2);
                    rDateOchangeEventDateTimePicker.Value = DateTime.Now.Date;

                    chechupdatestate = false;

                }
                else
                {
                    activeTextBox.Text = "1";

                    dateDateTimePicker.Value = DateTime.Now.AddDays(-2).AddMonths(-2).AddYears(-2);
                    dateDateTimePicker.Value = DateTime.Now;

                    rDateOchangeEventDateTimePicker.Value = DateTime.Now.Date.AddDays(-2).AddMonths(-2).AddYears(-2);
                    rDateOchangeEventDateTimePicker.Value = DateTime.Now.Date;

                    chechupdatestate = false;

                }


            }
            else
            {
                realStateBindingNavigatorSaveItem.PerformClick();
                toolStripButton1.PerformClick();
                //MessageBox.Show("قم بالحفظ قبل");
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




        Boolean copycontinues = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbRegion.Text != "" && cmbBuildingType.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && areaTextBox.Text != "" && txtFloor.Text != "")
            {
                if ((Utils.checkexistOwner(txtSubResgion.Text, txtBuilding.Text, Convert.ToInt32(txtFloor.Text), 0).Rows.Count <= 0) || copycontinues)
                {

                    ToOwnPrametr top = new ToOwnPrametr(Utils.realstateid, cmbRegion.Text);
                    top.ShowDialog();
                    //ShowModalExcept(top, MainForm.searchForm);

                }
                else
                {
                    DSrealsearchown.RealstateOwneDataTable dt = (DSrealsearchown.RealstateOwneDataTable)Utils.checkexistOwner(txtSubResgion.Text, txtBuilding.Text, Convert.ToInt32(txtFloor.Text), 0);
                    Check.who = "own";
                    string g = Check.ShowMeOWN(dt);
                    if (g == "kml")
                    {
                        copycontinues = true;
                        button2.PerformClick();

                    }
                    if (g == "cancel")
                    {
                        copycontinues = false;

                    }


                }

            }
            else
            {

                //comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && areaTextBox.Text != "" && floorTextBox.Text != ""
                MessageBox.Show(" لا يمكن النسخ الرجاء ملئ الحقول التالية : المنطقة - نوع البناء - الوضع الداخلي - طريقة التأجير - المساحة - الطابق ");
            }

        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (attachmentDataGridView.RowCount > 0)
            {
                string path = attachmentDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
                string temp = path.Substring(0, 1);
                path = PublicFileName;
                if ((GetFileExisting(path)))
                {
                    string filePath = Utils.ProjectName + "\\" + path;
                    Process.Start("rundll32.exe", $"shell32.dll,OpenAs_RunDLL {filePath}");

                    //if (temp != "T")
                    //{
                    //    OpenAs(Utils.ProjectName + "\\" + path);
                    //}
                    //else
                    //{
                    //    int start = path.IndexOf(Utils.realstateid.ToString());
                    //    string ext = path.Substring(path.LastIndexOf("."));
                    //    string t = path.Substring(0, start);
                    //    OpenAs(Utils.ProjectName + "\\" + path + ".lnk");

                    //}
                }
                else
                {
                    MessageBox.Show("الملف غير موجود");
                }
            }
            else
            {
                MessageBox.Show("الرجاء تحديد ملف");
            }

        }

        [Serializable]
        public struct ShellExecuteInfo
        {
            public int Size;
            public uint Mask;
            public IntPtr hwnd;
            public string Verb;
            public string File;
            public string Parameters;
            public string Directory;
            public uint Show;
            public IntPtr InstApp;
            public IntPtr IDList;
            public string Class;
            public IntPtr hkeyClass;
            public uint HotKey;
            public IntPtr Icon;
            public IntPtr Monitor;
        }
        [DllImport("shell32.dll", SetLastError = true)]
        extern public static bool ShellExecuteEx(ref ShellExecuteInfo lpExecInfo);
        public const uint SW_NORMAL = 1;
        static void OpenAs(string file)
        {
            ShellExecuteInfo sei = new ShellExecuteInfo();
            sei.Size = Marshal.SizeOf(sei);
            sei.Verb = "openas";
            sei.File = file;
            sei.Show = SW_NORMAL;
            if (!ShellExecuteEx(ref sei))
                throw new System.ComponentModel.Win32Exception();
        }


        private void phone_oneTextBox_TextChanged(object sender, EventArgs e)
        {
            if (txtPhoneOne.Text.Length == Utils.PhoneNumerLength)
            {
                Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));


            }
            else
            {
                Gp1.BackColor = System.Drawing.Color.Red;
                Gp1.ForeColor = System.Drawing.Color.Red;



            }

            if (txtPhoneTow.Text.Length == Utils.PhoneNumerLength)
            {
                Gp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gp2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gp2.BackColor = System.Drawing.Color.Red;
                Gp2.ForeColor = System.Drawing.Color.Red;
            }

            if (txtMobile.Text.Length == Utils.MobileNumerLength)
            {
                Gm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gm1.BackColor = System.Drawing.Color.Red;
                Gm1.ForeColor = System.Drawing.Color.Red;
            }

            if (txtMobile2.Text.Length == Utils.MobileNumerLength)
            {
                Gm2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gm2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gm2.BackColor = System.Drawing.Color.Red;
                Gm2.ForeColor = System.Drawing.Color.Red;
            }
            //{0:0.00}

        }

        private void eventTextBox_TextChanged(object sender, EventArgs e)
        {
            chechupdatestate = false;
        }

        private void phone_oneTextBox_Leave(object sender, EventArgs e)
        {

            //if(phone_oneTextBox.Text!="" && phone_oneTextBox.Text!=null)
            //((String)phone_oneTextBox.Text.ToString()).fo("{0:#,###0}", Convert.ToInt32(phone_oneTextBox.Text.Replace(',', ' ')));

        }



        private void button6_Click(object sender, EventArgs e)
        {

            if (Utils.mode != null)
            {
                if (txtPhoneOne.Text.Length == Utils.PhoneNumerLength)
                {
                    double Num;
                    bool isNum = double.TryParse(txtPhoneOne.Text, out Num);
                    if (isNum)
                    {
                        Utils.mode.Call(txtPhoneOne.Text);
                        Redail.ShowMe();

                    }

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (Utils.mode != null)
            {
                if (txtPhoneTow.Text.Length == Utils.PhoneNumerLength)
                {
                    double Num;
                    bool isNum = double.TryParse(txtPhoneTow.Text, out Num);
                    if (isNum)
                    {
                        Utils.mode.Call(txtPhoneTow.Text);
                        Redail.ShowMe();
                    }

                }
            }

        }

        public static string NormalizePhoneNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            input = input.Trim();
            input = new string(input.Where(c => Char.IsDigit(c)).ToArray());  // إزالة أي رموز غير الأرقام

            if (input.StartsWith("09"))
            {
                return "963" + input.Substring(1);
            }
            else if (input.StartsWith("00"))
            {
                return input.Substring(2);
            }
            else if (input.StartsWith("++"))
            {
                return input.Substring(2);
            }
            else if (input.StartsWith("+"))
            {
                return input.Substring(1);
            }
            else
            {
                return input;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string rawPhone = txtMobile.Text;

            if (string.IsNullOrEmpty(rawPhone))
            {
                MessageBox.Show("من فضلك أدخل رقم الهاتف أولاً.");
                return;
            }

            string phone = NormalizePhoneNumber(rawPhone);
            string currentUsername = Utils.current_user;

            string message = $"مرحبا معك  {currentUsername} من طموحات العقارية";
            string encodedMessage = Uri.EscapeDataString(message);

            string url = $"https://wa.me/{phone}?text={encodedMessage}";

            try
            {
                Clipboard.SetText(url);
                //MessageBox.Show("تم نسخ رابط الواتساب إلى الحافظة.");
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء فتح الرابط: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string rawPhone = txtOther.Text;

            if (string.IsNullOrEmpty(rawPhone))
            {
                MessageBox.Show("من فضلك أدخل رقم الهاتف أولاً.");
                return;
            }

            string phone = NormalizePhoneNumber(rawPhone);
            string currentUsername = Utils.current_user;

            string message = $"مرحبا معك {currentUsername} من طموحات العقارية";
            string encodedMessage = Uri.EscapeDataString(message);

            string url = $"https://wa.me/{phone}?text={encodedMessage}";

            try
            {
                Clipboard.SetText(url);
                //MessageBox.Show("تم نسخ رابط الواتساب إلى الحافظة.");
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء فتح الرابط: " + ex.Message);
            }
        }



        private void roomsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // يسمح بالأرقام فقط
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show(
                                     "الرجاء ادخال ارقام فقط",
                                     "خطأ",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error,
                                     MessageBoxDefaultButton.Button3,
                                     MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                                 );
            }

        }

        private void Buttons_toolStrip()
        {
            if (attachmentDataGridView.Rows.Count == 0)
                downloadFile_toolStrip.Enabled = false;
            else
                downloadFile_toolStrip.Enabled = true;
        }

        //private void downloadFile_toolStrip_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string fileName = attachmentDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();


        //        if (!string.IsNullOrEmpty(fileName))
        //            CustomPath.DownloadFile(fileName, "");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(
        //                       $"{ex.Message}",
        //                         "خطأ",
        //                         MessageBoxButtons.OK,
        //                         MessageBoxIcon.Error,
        //                         MessageBoxDefaultButton.Button3,
        //                         MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
        //                     );
        //    }

        //}

        private void downloadFile_toolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                var roww = (DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position];
                Utils.realstateid = roww.ID;

                // 📂 إنشاء مجلد لتجميع الملفات
                string collectedFolder = Path.Combine(desktopPath, $"CollectedFiles_{Utils.realstateid}");
                if (!Directory.Exists(collectedFolder))
                {
                    Directory.CreateDirectory(collectedFolder);
                }

                foreach (DataGridViewRow row in attachmentDataGridView.SelectedRows)
                {
                    string fileName = row.Cells[2].Value?.ToString();

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        CustomPath.DownloadFileToFolder(fileName, collectedFolder, Utils.realstateid);
                    }
                }

                MessageBox.Show(
                    $"✅ تم تنزيل جميع الملفات المحددة في المجلد:\n{collectedFolder}",
                    "معلومة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"{ex.Message}",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                );
            }
        }


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                  "هل أنت متأكد من حذف العقار؟",
                  "تنبيه",
                  MessageBoxButtons.OKCancel,
                  MessageBoxIcon.Question,
                  MessageBoxDefaultButton.Button2,
                  MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
           );

            if (result == DialogResult.OK)
            {
                int currentId = Utils.realstateid;

                // حذف العقار من قاعدة البيانات
                bool isDeleted = clsRealState.SetRealStateInactive(currentId);
                if (isDeleted)
                {
                    // Active = 0 ونسيب IsPublished زي ماهو
                    UpdateActiveAndPublish(currentId);

                    // تحديث الـ DB بآخر قيمة لـ Published
                    clsRealState.MarkAsPublished(currentId, Published.Checked);
                }
                //var pubilshed = clsRealState.GetPublishedValuetoRealstate(currentId);
                if (isDeleted)
                {
                    MessageBox.Show("تم حذف العقار (تفعيل غير نشط) بنجاح.", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    // Convert.ToBoolean(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).published);

                    // إعادة تحميل البيانات
                    this.realStateTableAdapter.Fill(this.dSrealstate.RealState);

                    // إعادة ربط الـ BindingSource (احتياطي)
                    realStateBindingSource.DataSource = this.dSrealstate.RealState;

                    // نحاول نرجع على أول سجل بعد الحذف
                    if (realStateBindingSource.Count > 0)
                    {
                        // نحاول نلاقي أقرب سجل بعد ID المحذوف
                        bool found = false;

                        foreach (DataRowView rowView in realStateBindingSource)
                        {
                            DSrealstate.RealStateRow row = (DSrealstate.RealStateRow)rowView.Row;
                            if (row.ID > currentId)
                            {
                                realStateBindingSource.Position = realStateBindingSource.Find("ID", row.ID);
                                Utils.realstateid = row.ID;
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            // لو مفيش سجل ID أكبر منه، نرجع للسجل الأخير
                            realStateBindingSource.Position = realStateBindingSource.Count - 1;
                            Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);
                        }
                    }
                    else
                    {
                        // مفيش سجلات خالص
                        Utils.realstateid = 0;
                    }

                    //var pubilshed = clsRealState.GetPublishedValuetoRealstate(Utils.realstateid);// Convert.ToBoolean(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).published);

                    //var pubilshed = clsRealState.GetPublishedValuetoRealstate(Utils.realstateid);// Convert.ToBoolean(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).published);
                    //if (pubilshed)
                    //{
                    //    //UpdateActiveAndPublish(currentId);
                    //}

                  
                }
                else
                {
                    MessageBox.Show("تعذر حذف العقار لوجود بيانات مرتبطة به.", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            //DialogResult result1 = MessageBox.Show("هل تريد حذف العقار ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            //DialogResult result2;

            //if (result1 == DialogResult.Yes)
            //{
            //    result2 = MessageBox.Show("هل انت متأكد من حذف العقار ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            //    if (result2 == DialogResult.Yes)
            //    {
            //        Utils.deleteattch(Utils.realstateid);
            //        bindingNavigatorDeleteItem.PerformClick();
            //        //continues = true;
            //        gnon = "del";

            //        realStateBindingNavigatorSaveItem.PerformClick();


            //    }

            //}


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtOther_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string rawPhone = txtMobile2.Text;

            if (string.IsNullOrEmpty(rawPhone))
            {
                MessageBox.Show("من فضلك أدخل رقم الهاتف أولاً.");
                return;
            }

            string phone = NormalizePhoneNumber(rawPhone);
            string currentUsername = Utils.current_user;

            string message = $"مرحبا معك  {currentUsername} من طموحات العقارية";
            string encodedMessage = Uri.EscapeDataString(message);

            string url = $"https://wa.me/{phone}?text={encodedMessage}";

            try
            {
                Clipboard.SetText(url);
                //MessageBox.Show("تم نسخ رابط الواتساب إلى الحافظة.");
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء فتح الرابط: " + ex.Message);
            }
        }


        private void otherRecords_Click(object sender, EventArgs e)
        {
            f.ShowDialog();

            //ShowRelatedRecords();
        }


        //#region Publish Code


        //private async void PublishRecord()
        //{
        //    int Rs_ID = Utils.realstateid; // رقم الريسكورد
        //    string RsTypeSymbol = "ي";

        //    try
        //    {
        //        string apiUrl = GetPublishingApiUrl();
        //        if (string.IsNullOrEmpty(apiUrl))
        //        {
        //            MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): API URL not found.");
        //            return;
        //        }

        //        var attachments = clsAttachment.GetAttachmentsForRealState(Rs_ID)
        //                                      .Where(a => a.Visible == 1).ToList();
        //        var recordData = clsRealState.GetRecordDataForRealState(Rs_ID);

        //        using (var client = new HttpClient { Timeout = TimeSpan.FromHours(1) })
        //        using (var form = new MultipartFormDataContent())
        //        {
        //            void AddIfNotEmpty(string key, object value)
        //            {
        //                if (value == null) return;
        //                if (value is string str && string.IsNullOrWhiteSpace(str)) return;
        //                form.Add(new StringContent(value.ToString()), key);
        //                Console.WriteLine($"Added => {key}: {value}");
        //            }

        //            AddIfNotEmpty("internal_id", Rs_ID);
        //            AddIfNotEmpty("region", recordData.Region);
        //            AddIfNotEmpty("street", recordData.Street);
        //            AddIfNotEmpty("floor", recordData.Floor);
        //            AddIfNotEmpty("direction", recordData.Direction);
        //            AddIfNotEmpty("building_type", recordData.BuildingType);
        //            AddIfNotEmpty("area", recordData.Area);
        //            AddIfNotEmpty("rooms", recordData.Rooms);
        //            AddIfNotEmpty("price", recordData.Price);
        //            AddIfNotEmpty("condition_", recordData.Condition);
        //            AddIfNotEmpty("ownership_", recordData.OwnerShip);
        //            AddIfNotEmpty("notes", recordData.Notes);
        //            AddIfNotEmpty("last_event", recordData.LastEvent?.ToString("yyyy-MM-dd HH:mm:ss"));
        //            AddIfNotEmpty("rent_status", recordData.RentStatus);
        //            AddIfNotEmpty("active", recordData.Active);
        //            AddIfNotEmpty("Rs_type", "rent"); // "rent" أو "sale"
        //            AddIfNotEmpty("secret", "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il");
        //            form.Add(new StringContent("1"), "ddd");

        //            // الملفات
        //            foreach (var att in attachments)
        //            {
        //                string path;
        //                if (System.IO.File.Exists(Utils.ProjectName + "\\TempAttachment\\" + att.FileName))
        //                {
        //                    path = Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName);
        //                }
        //                else
        //                {
        //                    path = att.Type == 2
        //                       ? Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName)
        //                       : Path.Combine(Utils.ProjectName, att.FileName);
        //                }

        //                if (!File.Exists(path))
        //                {
        //                    MessageBox.Show($"⚠ File not found for ID {Rs_ID} ({RsTypeSymbol}): {att.FileName}");
        //                    continue;
        //                }

        //                var stream = File.OpenRead(path);
        //                var streamContent = new StreamContent(stream);
        //                streamContent.Headers.ContentType =
        //                    new System.Net.Http.Headers.MediaTypeHeaderValue(att.Type == 2 ? "video/mp4" : "image/jpeg");

        //                form.Add(streamContent, "photos[]", att.FileName);
        //            }

        //            try
        //            {
        //                HttpResponseMessage response = await client.PostAsync(apiUrl, form);
        //                string resp = await response.Content.ReadAsStringAsync();

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    MessageBox.Show($"✅ Success for ID {Rs_ID} ({RsTypeSymbol})");
        //                }
        //                else
        //                {
        //                    MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Server error {(int)response.StatusCode} {response.StatusCode}\n{resp}");
        //                }
        //            }
        //            catch (HttpRequestException httpEx)
        //            {
        //                MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Network error\n{httpEx.Message}");
        //            }
        //            catch (TaskCanceledException timeoutEx)
        //            {
        //                MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Timeout\n{timeoutEx.Message}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // مشكلة عامة
        //        Console.WriteLine($"⚠ Failed for ID {Rs_ID} ({RsTypeSymbol}): Unexpected error\n{ex.Message}");
        //    }
        //}

        //private async void UpdateActiveAndPublish(int currentId)
        //{
        //    int Rs_ID = currentId; // رقم الريسكورد
        //    string RsTypeSymbol = "ي";

        //    try
        //    {
        //        string apiUrl = GetPublishingApiUrl();
        //        if (string.IsNullOrEmpty(apiUrl))
        //        {
        //            MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): API URL not found.");
        //            return;
        //        }

        //        //var attachments = clsAttachment.GetAttachmentsForRealState(Rs_ID)
        //        //                              .Where(a => a.Visible == 1).ToList();
        //        var recordData = clsRealState.GetRecordDataForRealState(Rs_ID);

        //        using (var client = new HttpClient { Timeout = TimeSpan.FromHours(1) })
        //        using (var form = new MultipartFormDataContent())
        //        {
        //            void AddIfNotEmpty(string key, object value)
        //            {
        //                if (value == null) return;
        //                if (value is string str && string.IsNullOrWhiteSpace(str)) return;
        //                form.Add(new StringContent(value.ToString()), key);
        //                Console.WriteLine($"Added => {key}: {value}");
        //            }

        //            AddIfNotEmpty("internal_id", Rs_ID);
        //            AddIfNotEmpty("region", recordData.Region);
        //            //AddIfNotEmpty("street", recordData.Street);
        //            //AddIfNotEmpty("floor", recordData.Floor);
        //            //AddIfNotEmpty("direction", recordData.Direction);
        //            //AddIfNotEmpty("building_type", recordData.BuildingType);
        //            //AddIfNotEmpty("area", recordData.Area);
        //            //AddIfNotEmpty("rooms", recordData.Rooms);
        //            //AddIfNotEmpty("price", recordData.Price);
        //            //AddIfNotEmpty("condition_", recordData.Condition);
        //            //AddIfNotEmpty("ownership_", recordData.OwnerShip);
        //            //AddIfNotEmpty("notes", recordData.Notes);
        //            //AddIfNotEmpty("last_event", recordData.LastEvent?.ToString("yyyy-MM-dd HH:mm:ss"));
        //            //AddIfNotEmpty("rent_status", recordData.RentStatus);
        //            AddIfNotEmpty("active", 0); // تعطيل العقار
        //            //AddIfNotEmpty("Rs_type", "rent");
        //            AddIfNotEmpty("secret", "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il");
        //            form.Add(new StringContent("1"), "ddd");

        //            //foreach (var att in attachments)
        //            //{
        //            //    string path = att.Type == 2
        //            //        ? Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName)
        //            //        : Path.Combine(Utils.ProjectName, att.FileName);

        //            //    if (!File.Exists(path))
        //            //    {
        //            //        MessageBox.Show($"⚠ File not found for ID {Rs_ID} ({RsTypeSymbol}): {att.FileName}");
        //            //        continue;
        //            //    }

        //            //    var stream = File.OpenRead(path);
        //            //    var streamContent = new StreamContent(stream);
        //            //    streamContent.Headers.ContentType =
        //            //        new System.Net.Http.Headers.MediaTypeHeaderValue(att.Type == 2 ? "video/mp4" : "image/jpeg");

        //            //    form.Add(streamContent, "photos[]", att.FileName);
        //            //}

        //            try
        //            {
        //                HttpResponseMessage response = await client.PostAsync(apiUrl, form);
        //                string resp = await response.Content.ReadAsStringAsync();

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    MessageBox.Show($"✅ Updated Success for ID {Rs_ID} ({RsTypeSymbol})");
        //                }
        //                else
        //                {
        //                    MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Server error {(int)response.StatusCode} {response.StatusCode}\n{resp}");
        //                }
        //            }
        //            catch (HttpRequestException httpEx)
        //            {
        //                MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Network error\n{httpEx.Message}");
        //            }
        //            catch (TaskCanceledException timeoutEx)
        //            {
        //                MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Timeout\n{timeoutEx.Message}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"⚠ Failed for ID {Rs_ID} ({RsTypeSymbol}): Unexpected error\n{ex.Message}");
        //    }
        //}

        //private string GetPublishingApiUrl()
        //{
        //    return clsSettingsCalling.LoadSettings().publishing_rent;
        //}



        //#endregion


        #region Publishing Code

        private async Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> operation, int maxRetries = 10, int delayMs = 2000)
        {
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    return await operation();
                }
                catch (HttpRequestException ex) // network error
                {
                    Console.WriteLine($"⚠ Network error (Attempt {attempt}/{maxRetries}): {ex.Message}");
                    if (attempt == maxRetries)
                        throw;
                }
                catch (TaskCanceledException ex) // timeout
                {
                    Console.WriteLine($"⚠ Timeout (Attempt {attempt}/{maxRetries}): {ex.Message}");
                    if (attempt == maxRetries)
                        throw;
                }

                // wait before retry
                await Task.Delay(delayMs);
            }

            throw new Exception("Unexpected error in ExecuteWithRetryAsync.");
        }

        private async void PublishRecord()
        {
            int Rs_ID = Utils.realstateid; // رقم الريكورد
            string RsTypeSymbol = "ي";

            // 1- إرسال البيانات الأساسية بدون مرفقات
            bool dataSent = await PublishRecordDataAsync(Rs_ID);
            if (dataSent)
            {
                MessageBox.Show($"✅ Data published successfully for ID {Rs_ID} ({RsTypeSymbol})");

                // 2- إرسال المرفقات واحد واحد
                await PublishAttachmentsAsync(Rs_ID);
            }

            // ✅ تحديث حالة الزرار بعد النشر
            CheckWebsiteIdAndToggleButton(Rs_ID);
        }

        private async Task<bool> PublishRecordDataAsync(int Rs_ID)
        {
            string RsTypeSymbol = "ي";
            try
            {
                string apiUrl = GetPublishingApiUrl();
                if (string.IsNullOrEmpty(apiUrl))
                {
                    MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): API URL not found.");
                    return false;
                }

                var recordData = clsRealState.GetRecordDataForRealState(Rs_ID);

                using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(30) })
                using (var form = new MultipartFormDataContent())
                {
                    void AddIfNotEmpty(string key, object value)
                    {
                        if (value == null) return;
                        if (value is string str && string.IsNullOrWhiteSpace(str)) return;
                        form.Add(new StringContent(value.ToString()), key);
                    }

                    AddIfNotEmpty("internal_id", Rs_ID);
                    AddIfNotEmpty("region", recordData.Region);
                    AddIfNotEmpty("street", recordData.Street);
                    AddIfNotEmpty("floor", recordData.Floor);
                    AddIfNotEmpty("direction", recordData.Direction);
                    AddIfNotEmpty("building_type", recordData.BuildingType);
                    AddIfNotEmpty("area", recordData.Area);
                    AddIfNotEmpty("rooms", recordData.Rooms);
                    AddIfNotEmpty("price", recordData.Price);
                    AddIfNotEmpty("condition_", recordData.Condition);
                    AddIfNotEmpty("ownership_", recordData.OwnerShip);
                    AddIfNotEmpty("notes", recordData.Notes);
                    AddIfNotEmpty("last_event", recordData.LastEvent?.ToString("yyyy-MM-dd HH:mm:ss"));
                    AddIfNotEmpty("rent_status", recordData.RentStatus);
                    AddIfNotEmpty("active", recordData.Active);
                    AddIfNotEmpty("Rs_type", "rent");
                    AddIfNotEmpty("secret", "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il");
                    form.Add(new StringContent("1"), "ddd");

                    HttpResponseMessage response = await ExecuteWithRetryAsync(
                        () => client.PostAsync(apiUrl, form));

                    string resp = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            // Parse JSON response to get website_id
                            var json = Newtonsoft.Json.Linq.JObject.Parse(resp);
                            var websiteId = json["website_id"]?.ToString();

                            if (!string.IsNullOrEmpty(websiteId))
                            {
                                // Update database with website_id
                                setWebsiteId(websiteId, Rs_ID);
                                Console.WriteLine($"✅ Website ID {websiteId} stored for record {Rs_ID}");
                            }
                        }
                        catch (Exception parseEx)
                        {
                            Console.WriteLine($"⚠ Could not parse website_id from response: {parseEx.Message}");
                        }

                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"❌ Failed (Data) for ID {Rs_ID}: {(int)response.StatusCode} {response.StatusCode}\n{resp}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"⚠ Error sending data for ID {Rs_ID}: {ex.Message}");
                return false;
            }
        }


    //    private async Task PublishAttachmentsAsync(int Rs_ID)
    //{
    //    string RsTypeSymbol = "ي"; // ي = إيجار
    //    var attachments = clsAttachment.GetAttachmentsForRealState(Rs_ID)
    //                                  .Where(a => a.Visible == 1).ToList();

    //    string apiUrl = GetAttachmentApiUrl();
    //    if (string.IsNullOrEmpty(apiUrl))
    //    {
    //        MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Attachment API URL not found.");
    //        return;
    //    }

    //    var summaryLogs = new List<string>();
    //    using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(30) })
    //    {
    //        // set a default user-agent if needed
    //        client.DefaultRequestHeaders.UserAgent.ParseAdd("MyUploader/1.0");

    //        foreach (var att in attachments)
    //        {
    //            try
    //            {
    //                string pathTemp = Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName);
    //                string pathMain = Path.Combine(Utils.ProjectName, att.FileName);
    //                string path = File.Exists(pathTemp) ? pathTemp : pathMain;

    //                if (!File.Exists(path))
    //                {
    //                    summaryLogs.Add($"⚠ File not found for ID {Rs_ID} ({RsTypeSymbol}): {att.FileName}");
    //                    continue;
    //                }

    //                // Use a function that does the actual POST and returns HttpResponseMessage
    //                Func<Task<HttpResponseMessage>> operation = async () =>
    //                {
    //                    // create the form and stream inside the operation so each retry rebuilds them cleanly
    //                    using (var form = new MultipartFormDataContent())
    //                    {
    //                        form.Add(new StringContent(Rs_ID.ToString()), "internal_id");
    //                        form.Add(new StringContent("rent"), "type");
    //                        form.Add(new StringContent("gfsh561r6hrtrty6eg3r1tger6tqweiukl1il"), "secret");

    //                        // open the file stream on a background thread to reduce UI blocking
    //                        var stream = await Task.Run(() => (Stream)File.OpenRead(path)).ConfigureAwait(false);
    //                        // Note: do not use 'using' for stream here because StreamContent will dispose it when disposed below.
    //                        var streamContent = new StreamContent(stream);
    //                        streamContent.Headers.ContentType = new MediaTypeHeaderValue(GetMimeType(path));
    //                        form.Add(streamContent, "photo", att.FileName);

    //                        // PostAsync will use the HttpClient
    //                        var responsee = await client.PostAsync(apiUrl, form).ConfigureAwait(false);
    //                        // HttpResponseMessage will be returned to caller (not disposed here)
    //                        return responsee;
    //                    }
    //                };

    //                // Use specialized retry that knows how to handle HttpResponseMessage codes (including 429)
    //                HttpResponseMessage response = await ExecuteWithHttpRetryAsync(operation,
    //                                                                              maxRetries: 5,
    //                                                                              initialDelayMs: 1000)
    //                                               .ConfigureAwait(false);

    //                // Read content (switch back to UI context only to log or show UI later)
    //                string respText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

    //                if (response.IsSuccessStatusCode)
    //                {
    //                    // Optionally mark the attachment as uploaded in DB so you don't try again later:
    //                    // clsAttachment.MarkAsUploaded(att.Id); // <-- implement this in your data layer
    //                    summaryLogs.Add($"✅ Uploaded: {att.FileName}");
    //                }
    //                else
    //                {
    //                    summaryLogs.Add($"❌ Failed (Attachment) for {att.FileName}: {(int)response.StatusCode} {response.StatusCode} - {Truncate(respText, 300)}");
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                summaryLogs.Add($"⚠ Error uploading {att.FileName}: {ex.Message}");
    //            }

    //            // small delay between uploads to reduce chance of rate-limiting
    //            await Task.Delay(800).ConfigureAwait(false);
    //        }
    //    }

    //    // Show a concise summary on UI thread
    //    var final = string.Join(Environment.NewLine, summaryLogs);
    //    MessageBox.Show(final, $"Upload summary for ID {Rs_ID}", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //}

        private async Task PublishAttachmentsAsync(int Rs_ID)
        {
            string RsTypeSymbol = "ي"; // ي = إيجار
            var attachments = clsAttachment.GetAttachmentsForRealState(Rs_ID)
                                          .Where(a => a.Visible == 1).ToList();

            string apiUrl = GetAttachmentApiUrl();
            if (string.IsNullOrEmpty(apiUrl))
            {
                MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Attachment API URL not found.");
                return;
            }

            var summaryLogs = new List<string>();
            var failedFiles = new List<string>();

            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(30) })
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("MyUploader/1.0");

                // function that uploads a single file
                async Task<bool> TryUploadAsync(string filePath, string fileName)
                {
                    try
                    {
                        Func<Task<HttpResponseMessage>> operation = async () =>
                        {
                            using (var form = new MultipartFormDataContent())
                            {
                                form.Add(new StringContent(Rs_ID.ToString()), "internal_id");
                                form.Add(new StringContent("rent"), "type");
                                form.Add(new StringContent("gfsh561r6hrtrty6eg3r1tger6tqweiukl1il"), "secret");

                                var stream = await Task.Run(() => (Stream)File.OpenRead(filePath)).ConfigureAwait(false);
                                var streamContent = new StreamContent(stream);
                                streamContent.Headers.ContentType = new MediaTypeHeaderValue(GetMimeType(filePath));
                                form.Add(streamContent, "photo", fileName);

                                return await client.PostAsync(apiUrl, form).ConfigureAwait(false);
                            }
                        };

                        HttpResponseMessage response = await ExecuteWithHttpRetryAsync(operation,
                                                                                      maxRetries: 5,
                                                                                      initialDelayMs: 1000)
                                                       .ConfigureAwait(false);

                        string respText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            summaryLogs.Add($"✅ Uploaded: {fileName}");
                            return true;
                        }
                        else
                        {
                            summaryLogs.Add($"❌ Failed (Attachment) for {fileName}: {(int)response.StatusCode} {response.StatusCode} - {Truncate(respText, 300)}");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        summaryLogs.Add($"⚠ Error uploading {fileName}: {ex.Message}");
                        return false;
                    }
                }

                // first pass
                foreach (var att in attachments)
                {
                    string pathTemp = Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName);
                    string pathMain = Path.Combine(Utils.ProjectName, att.FileName);
                    string path = File.Exists(pathTemp) ? pathTemp : pathMain;

                    if (!File.Exists(path))
                    {
                        summaryLogs.Add($"⚠ File not found for ID {Rs_ID} ({RsTypeSymbol}): {att.FileName}");
                        continue;
                    }

                    bool success = await TryUploadAsync(path, att.FileName);
                    if (!success)
                        failedFiles.Add(att.FileName);

                    await Task.Delay(800).ConfigureAwait(false);
                }

                // second pass for failed files
                if (failedFiles.Any())
                {
                    summaryLogs.Add("🔄 Retrying failed files...");
                    var stillFailed = new List<string>();

                    foreach (var fileName in failedFiles)
                    {
                        string pathTemp = Path.Combine(Utils.ProjectName, "TempAttachment", fileName);
                        string pathMain = Path.Combine(Utils.ProjectName, fileName);
                        string path = File.Exists(pathTemp) ? pathTemp : pathMain;

                        if (!File.Exists(path))
                        {
                            summaryLogs.Add($"⚠ Retry skipped, file not found: {fileName}");
                            continue;
                        }

                        bool success = await TryUploadAsync(path, fileName);
                        if (!success)
                            stillFailed.Add(fileName);

                        await Task.Delay(800).ConfigureAwait(false);
                    }

                    if (stillFailed.Any())
                        summaryLogs.Add($"❌ Final failed files: {string.Join(", ", stillFailed)}");
                    else
                        summaryLogs.Add("✅ All files uploaded after retry!");
                }
            }

            var final = string.Join(Environment.NewLine, summaryLogs);
            MessageBox.Show(final, $"Upload summary for ID {Rs_ID}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// Retry wrapper specialized for HttpResponseMessage-producing operations.
        /// - Retries on network errors, timeouts or 5xx responses
        /// - For 429: perform exponential backoff (based on Retry-After header if provided)
        /// - For 4xx (except 429) we do NOT retry
        /// </summary>
        private async Task<HttpResponseMessage> ExecuteWithHttpRetryAsync(
            Func<Task<HttpResponseMessage>> operation,
            int maxRetries = 5,
            int initialDelayMs = 1000)
        {
            int attempt = 0;
            int delayMs = initialDelayMs;

            while (true)
            {
                attempt++;
                try
                {
                    var response = await operation().ConfigureAwait(false);

                    // If success => return
                    if (response.IsSuccessStatusCode)
                        return response;

                    int code = (int)response.StatusCode;

                    // Rate limit => 429. Look for Retry-After header or do exponential backoff.
                    if (code == 429)
                    {
                        // read Retry-After header if present
                        if (response.Headers.TryGetValues("Retry-After", out var values))
                        {
                            var ra = values.FirstOrDefault();
                            if (int.TryParse(ra, out int raSeconds))
                            {
                                await Task.Delay(TimeSpan.FromSeconds(raSeconds)).ConfigureAwait(false);
                            }
                            else if (DateTimeOffset.TryParse(ra, out var raDate))
                            {
                                var wait = raDate - DateTimeOffset.Now;
                                if (wait > TimeSpan.Zero) await Task.Delay(wait).ConfigureAwait(false);
                            }
                            else
                            {
                                await Task.Delay(delayMs).ConfigureAwait(false);
                                delayMs *= 2;
                            }
                        }
                        else
                        {
                            // No header -> exponential backoff
                            await Task.Delay(delayMs).ConfigureAwait(false);
                            delayMs = Math.Min(delayMs * 2, 30_000); // cap to 30s
                        }

                        // If reached max attempts, return response (caller will log)
                        if (attempt >= maxRetries)
                            return response;

                        // else retry
                        continue;
                    }

                    // Server-side error (5xx) -> retry
                    if (code >= 500 && attempt < maxRetries)
                    {
                        await Task.Delay(delayMs).ConfigureAwait(false);
                        delayMs = Math.Min(delayMs * 2, 30_000);
                        continue;
                    }

                    // Client-side error (4xx but not 429) => do not retry
                    return response;
                }
                catch (HttpRequestException ex) when (attempt < maxRetries)
                {
                    // network/transient error -> retry
                    Console.WriteLine($"HttpRequestException attempt {attempt}: {ex.Message}");
                    await Task.Delay(delayMs).ConfigureAwait(false);
                    delayMs = Math.Min(delayMs * 2, 30_000);
                    continue;
                }
                catch (TaskCanceledException ex) when (attempt < maxRetries)
                {
                    // likely timeout -> retry
                    Console.WriteLine($"Timeout attempt {attempt}: {ex.Message}");
                    await Task.Delay(delayMs).ConfigureAwait(false);
                    delayMs = Math.Min(delayMs * 2, 30_000);
                    continue;
                }
                catch
                {
                    // non-retriable exceptions bubble up
                    throw;
                }
            }
        }

        /// <summary>
        /// Basic mime type helper.
        /// </summary>
        private string GetMimeType(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            switch (ext)
            {
                case ".jpg":
                case ".jpeg": return "image/jpeg";
                case ".png": return "image/png";
                case ".gif": return "image/gif";
                case ".mp4": return "video/mp4";
                case ".mov": return "video/quicktime";
                case ".avi": return "video/x-msvideo";
                case ".pdf": return "application/pdf";
                default: return "application/octet-stream";
            }
        }

        /// <summary>
        /// Helper to truncate long response text for summary.
        /// </summary>
        private string Truncate(string s, int maxLen)
        {
            if (s == null) return string.Empty;
            if (s.Length <= maxLen) return s;
            return s.Substring(0, maxLen) + "...";
        }


    #region Secode Solution
    //private async Task PublishAttachmentsAsync(int Rs_ID)
    //{
    //    string RsTypeSymbol = "ي"; // ي = إيجار
    //    var attachments = clsAttachment.GetAttachmentsForRealState(Rs_ID)
    //                                  .Where(a => a.Visible == 1).ToList();

    //    string apiUrl = GetAttachmentApiUrl();
    //    if (string.IsNullOrEmpty(apiUrl))
    //    {
    //        MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Attachment API URL not found.");
    //        return;
    //    }

    //    using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(30) })
    //    {
    //        foreach (var att in attachments)
    //        {
    //            try
    //            {
    //                string path = (System.IO.File.Exists(Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName)))
    //                    ? Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName)
    //                    : Path.Combine(Utils.ProjectName, att.FileName);

    //                if (!System.IO.File.Exists(path))
    //                {
    //                    MessageBox.Show($"⚠ File not found for ID {Rs_ID} ({RsTypeSymbol}): {att.FileName}");
    //                    continue;
    //                }

    //                // ✅ نعيد بناء الفورم + الاستريم جوه الريتراي
    //                HttpResponseMessage response = await ExecuteWithRetryAsync(async () =>
    //                {
    //                    using (var form = new MultipartFormDataContent())
    //                    {
    //                        form.Add(new StringContent(Rs_ID.ToString()), "internal_id");
    //                        form.Add(new StringContent("rent"), "type");
    //                        form.Add(new StringContent("gfsh561r6hrtrty6eg3r1tger6tqweiukl1il"), "secret");

    //                        using (var stream = System.IO.File.OpenRead(path))
    //                        {
    //                            var streamContent = new StreamContent(stream);

    //                            // تحديد الـ MIME Type حسب الامتداد
    //                            string ext = Path.GetExtension(path).ToLower();
    //                            string mimeType = "application/octet-stream";
    //                            if (ext == ".jpg" || ext == ".jpeg") mimeType = "image/jpeg";
    //                            else if (ext == ".png") mimeType = "image/png";
    //                            else if (ext == ".mp4") mimeType = "video/mp4";
    //                            else if (ext == ".mov") mimeType = "video/quicktime";

    //                            streamContent.Headers.ContentType =
    //                                new System.Net.Http.Headers.MediaTypeHeaderValue(mimeType);

    //                            form.Add(streamContent, "photo", att.FileName);

    //                            return await client.PostAsync(apiUrl, form);
    //                        }
    //                    }
    //                });

    //                string resp = await response.Content.ReadAsStringAsync();

    //                if (response.IsSuccessStatusCode)
    //                {
    //                    Console.WriteLine($"✅ Attachment uploaded for ID {Rs_ID}: {att.FileName}");
    //                }
    //                else
    //                {
    //                    MessageBox.Show($"❌ Failed (Attachment) for {att.FileName}: {(int)response.StatusCode} {response.StatusCode}\n{resp}");
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show($"⚠ Error uploading attachment {att.FileName} for ID {Rs_ID}: {ex.Message}");
    //            }
    //        }

    //        MessageBox.Show($"✅ Attachments uploaded for ID {Rs_ID}");
    //    }
    //}

    #endregion

    #region First Solution
    //private async Task PublishAttachmentsAsync(int Rs_ID)
    //{
    //    string RsTypeSymbol = "ي";
    //    var attachments = clsAttachment.GetAttachmentsForRealState(Rs_ID)
    //                                  .Where(a => a.Visible == 1).ToList();

    //    string apiUrl = GetAttachmentApiUrl();
    //    if (string.IsNullOrEmpty(apiUrl))
    //    {
    //        MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Attachment API URL not found.");
    //        return;
    //    }

    //    using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) })
    //    {
    //        foreach (var att in attachments)
    //        {
    //            try
    //            {
    //                string path = (System.IO.File.Exists(Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName)))
    //                    ? Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName)
    //                    : Path.Combine(Utils.ProjectName, att.FileName);

    //                if (!System.IO.File.Exists(path))
    //                {
    //                    MessageBox.Show($"⚠ File not found for ID {Rs_ID} ({RsTypeSymbol}): {att.FileName}");
    //                    continue;
    //                }

    //                using (var form = new MultipartFormDataContent())
    //                using (var stream = System.IO.File.OpenRead(path))
    //                using (var streamContent = new StreamContent(stream))
    //                {
    //                    form.Add(new StringContent(Rs_ID.ToString()), "internal_id");
    //                    form.Add(new StringContent("rent"), "type");
    //                    form.Add(new StringContent("gfsh561r6hrtrty6eg3r1tger6tqweiukl1il"), "secret");

    //                    // تحديد الـ MIME Type
    //                    string ext = Path.GetExtension(path).ToLower();
    //                    string mimeType = "application/octet-stream";
    //                    if (ext == ".jpg" || ext == ".jpeg") mimeType = "image/jpeg";
    //                    else if (ext == ".png") mimeType = "image/png";
    //                    else if (ext == ".mp4") mimeType = "video/mp4";
    //                    else if (ext == ".mov") mimeType = "video/quicktime";

    //                    streamContent.Headers.ContentType =
    //                        new System.Net.Http.Headers.MediaTypeHeaderValue(mimeType);

    //                    form.Add(streamContent, "photo", att.FileName);

    //                    HttpResponseMessage response = await ExecuteWithRetryAsync(
    //                        () => client.PostAsync(apiUrl, form));

    //                    string resp = await response.Content.ReadAsStringAsync();

    //                    if (response.IsSuccessStatusCode)
    //                    {
    //                        Console.WriteLine($"✅ Attachment uploaded for ID {Rs_ID}: {att.FileName}");
    //                    }
    //                    else
    //                    {
    //                        MessageBox.Show($"❌ Failed (Attachment) for {att.FileName}: {(int)response.StatusCode} {response.StatusCode}\n{resp}");
    //                    }
    //                }

    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show($"⚠ Error uploading attachment {att.FileName} for ID {Rs_ID}: {ex.Message}");
    //            }
    //        }

    //        MessageBox.Show($"✅ Attachments uploaded for ID {Rs_ID}");
    //    }
    //}

    #endregion
        private async void UpdateActiveAndPublish(int currentId)
            {
                int Rs_ID = currentId;
                string RsTypeSymbol = "ي";

                try
                {
                    string apiUrl = GetPublishingApiUrl();
                    if (string.IsNullOrEmpty(apiUrl))
                    {
                        MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): API URL not found.");
                        return;
                    }

                    var recordData = clsRealState.GetRecordDataForRealState(Rs_ID);

                    using (var client = new HttpClient { Timeout = TimeSpan.FromHours(1) })
                    using (var form = new MultipartFormDataContent())
                    {
                        void AddIfNotEmpty(string key, object value)
                        {
                            if (value == null) return;
                            if (value is string str && string.IsNullOrWhiteSpace(str)) return;
                            form.Add(new StringContent(value.ToString()), key);
                        }

                        AddIfNotEmpty("internal_id", Rs_ID);
                        AddIfNotEmpty("region", recordData.Region);
                        AddIfNotEmpty("active", 0);
                        AddIfNotEmpty("secret", "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il");
                        form.Add(new StringContent("1"), "ddd");

                        HttpResponseMessage response = await ExecuteWithRetryAsync(
                            () => client.PostAsync(apiUrl, form));

                        string resp = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"✅ Update Success for ID {Rs_ID} ({RsTypeSymbol})");
                        }
                        else
                        {
                            MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Server error {(int)response.StatusCode} {response.StatusCode}\n{resp}");
                        }
                    }

                    // ✅ بعد التحديث لازم نراجع الزرار
                    CheckWebsiteIdAndToggleButton(Rs_ID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"⚠ Failed for ID {Rs_ID} ({RsTypeSymbol}): Unexpected error\n{ex.Message}");
                }
            }

        private string GetPublishingApiUrl()
        {
            return clsSettingsCalling.LoadSettings().publishing_rent;
        }

        private string GetAttachmentApiUrl()
        {
            return clsSettingsCalling.LoadSettings().publishing_attachment;
        }

        public static void setWebsiteId(string websiteId, int recordId)
        {
            clsRealState.setWebsiteId(websiteId, recordId);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (button8.Tag != null)
            {
                int websiteId = (int)button8.Tag;
                string main_website_address = clsSettingsCalling.get_main_website_address();

                string url = $"https://{main_website_address}/property/rent/{websiteId}";

                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"⚠ Error opening link: {ex.Message}");
                }
            }
        }

        private void CheckWebsiteIdAndToggleButton(int recordId)
        {
            int websiteId = clsRealState.getWebsiteId(recordId);

            if (websiteId > 0)
            {
                button8.Visible = true;
                button8.Tag = websiteId;
            }
            else
            {
                button8.Visible = false;
                button8.Tag = null;
            }
        }


        #endregion
       


        private void eventDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void realStateBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private DSTables.DSsettingTableAdapters.PCinfoTableAdapter PCinfoTableAdapter = new DSTables.DSsettingTableAdapters.PCinfoTableAdapter();

        private void Attachments_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. تحديد مسار الملف النصي
                // يجيب مسار exe الحالي
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // يكوّن المسار الكامل للملف جوه نفس فولدر exe
                string txtPath = Path.Combine(exeDirectory, "attachments.txt");

                //string txtPath = @"D:\Eng.Somer Rutub Project\SlideShow\MediaSlideshowAppV3\MediaSlideshowApp\MediaSlideshowApp\bin\Debug\net8.0-windows\attachments.txt";

                // 2. مسح أي محتوى قديم
                File.WriteAllText(txtPath, string.Empty);

                // 3. جلب مرفقات السجل الحالي
                int realStateId = Utils.realstateid;
                List<clsAttachment> attachments = clsAttachment.GetAttachmentsForRealState(realStateId);

                foreach (clsAttachment att in attachments)
                {
                    if (System.IO.File.Exists(Utils.ProjectName + "\\TempAttachment\\" + att.FileName))
                    {
                        continue;
                    }

                    if (att.Type == 2) continue; // استبعاد المرفقات التلقائية
                    if (att.Visible == 0) continue;
                    // لو العمود Path في الجدول بيخزن المسار الكامل استخدمه مباشرة
                    string filePath = Utils.ProjectName  +"\\" + att.FileName; 
                    //!string.IsNullOrEmpty(att.Path)
                    //                    ? att.Path
                    //                    : Path.Combine(Utils.ProjectName, att.FileName);

                    if (File.Exists(filePath))
                    {
                        File.AppendAllText(txtPath, filePath + Environment.NewLine);
                    }
                }


                string slideshowExe = clsDeviceSettings.GetSlideShowPath();

                if (string.IsNullOrEmpty(slideshowExe))
                {
                    MessageBox.Show("لا يوجد مسار للبرنامج في قاعدة البيانات.");
                    return;
                }

                // نكوّن المسار الكامل للـ exe
                slideshowExe = Path.Combine(slideshowExe, "MediaSlideshowApp.exe");

                if (System.IO.File.Exists(slideshowExe))
                {
                    Process.Start(slideshowExe, "\"" + txtPath + "\"");
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على برنامج السلايد شو.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void bindingNavigatorPositionItem_Enter(object sender, EventArgs e)
        {
            Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

        }

        private void bindingNavigatorPositionItem_Leave(object sender, EventArgs e)
        {
            Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

        }

        private void Realstate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.realstateid = Convert.ToInt32(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).ID);

        }







        //private void ShowRelatedRecords()
        //{
        //    // Get current record ID
        //    int currentRecordId = Utils.realstateid;

        //    // Extract and normalize phone numbers
        //    List<string> phoneNumbers = PhoneNormalizer.ExtractNormalizedNumbers(this);

        //    // Find related records
        //    DataTable relatedRecords = RelatedRecordsService.FindRelatedRecords(
        //        phoneNumbers, "إيجار", currentRecordId);

        //    // Update button text
        //    otherRecords.Text = $"سجلات أخرى ({relatedRecords.Rows.Count})";

        //    // Show results if any
        //    if (relatedRecords.Rows.Count > 0)
        //    {
        //        RelatedRecordsForm resultsForm = new RelatedRecordsForm(relatedRecords);
        //        resultsForm.ShowDialog();
        //    }
        //    else
        //    {
        //        MessageBox.Show("لا توجد سجلات أخرى مرتبطة");
        //    }


        //}

        //private void CheckRelatedRecords()
        //{
        //    // Get current record ID
        //    int currentRecordId = Utils.realstateid;

        //    // Extract and normalize phone numbers
        //    List<string> phoneNumbers = PhoneNormalizer.ExtractNormalizedNumbers(this);

        //    // Find related records
        //    DataTable relatedRecords = RelatedRecordsService.FindRelatedRecords(
        //        phoneNumbers, "إيجار", currentRecordId);

        //    // Update button text
        //    otherRecords.Text = $"سجلات أخرى ({relatedRecords.Rows.Count})";

        //    // Disable button if no records
        //    otherRecords.Enabled = relatedRecords.Rows.Count > 0 ? true : false;
        //}

        //private void PhoneTextChanged(object sender, EventArgs e)
        //{
        //    CheckRelatedRecords();
        //}

    }
}


