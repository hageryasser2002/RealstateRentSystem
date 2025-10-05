using IWshRuntimeLibrary;
using Newtonsoft.Json;
using RealStateRentSystem.Classes;
using RealStateRentSystem.DSTables;
using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using File = System.IO.File;


namespace RealStateRentSystem
{
    public partial class RealstateOwner : Form
    {
        public RealstateOwner()
        {
            InitializeComponent();

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
        private static DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter RSsearchown = new DSTables.DSrealsearchownTableAdapters.RealstateOwneTableAdapter();
        private System.Windows.Forms.ToolTip m_wndToolTip;
        public Boolean chechupdatestate = true;

        List<string> suggestions = new List<string>();
        string lastText = string.Empty;
        static bool textChanging = false;
        private CustomSource autoComplete;

        List<string> Buildingngsuggestions = new List<string>();
        string BuildinglastText = string.Empty;
        static bool BuildingtextChanging = false;
        private CustomSource BuildingautoComplete;

        public string toDo = "";
        public string toDophne = "";
        public string toDomop = "";
        public string toDoother = "";
        public string PublicFileName;


        RelatedRecordsForm f;

        //========Added Code=======
        private bool AttachmentExists(int realStateId, string fileName)
        {
            try
            {
                // استخدام أسماء الأعمدة الصحيحة التي ظهرت لك
                string realStateIdColumnName = "RealState_ID"; // هذا هو العمود الصحيح
                string fileNameColumnName = "FileName"; // هذا هو العمود الصحيح

                // الآن استخدم اسم العمود الصحيح
                var rows = dsrealowner.attachmentOwn.Select($"{realStateIdColumnName} = {realStateId} AND {fileNameColumnName} = '{fileName.Replace("'", "''")}'");
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
                string typeColumn = "typee";
                string idColumn = "ID";

                var rows = dsrealowner.attachmentOwn.Select($"{idColumn} = {attachmentId}");
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


        //public class TempDeletedAttachment
        //{
        //    public string FileName { get; set; }
        //    public string Comment { get; set; }
        //}

        //private List<TempDeletedAttachment> deletedAutoAttachments = new List<TempDeletedAttachment>();



        private void realStateBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            bool wasPublished = false;
            int floor;
            string g = "";
            if (floorTextBox.Text != "")
            {
                floor = Convert.ToInt32(floorTextBox.Text);

            }
            else
            {
                floor = 0;
            }

            if (string.IsNullOrEmpty(roomsTextBox.Text.Trim()))
                roomsTextBox.Text = "0";



            int esra2;
            if (clicked == "clicked") // إذا كان المستخدم قد ضغط على "إضافة جديد"
            {
                soso = false; // لا داعي للتحقق من التكرار
                esra2 = 0;
            }
            else
            {
                soso = checkduplicate(); // التحقق من التكرار في حالة التعديل
                esra2 = Utils.realstateidowner;
            }

            if (!soso) // إذا لم يكن هناك تكرار
            {
                if (((Utils.checkexistOwner(subResgionIDTextBox.Text, buildingTextBox.Text, floor, esra2).Rows.Count <= 0) // إذا لم يتم العثور على عقار مكرر
                    || continues) // أو إذا وافق المستخدم على المتابعة رغم التكرار (continues = true)
                    || gnon == "del") // أو إذا كانت العملية حذفًا (gnon = "del")
                {
                    //tempmlate
                    //continues = false;
                    if (!checkdTemplate() && clicked != "clicked" && !continues && gnon != "del")
                    {
                        DataTable dt = new DataTable();
                        dt = TempTableAdapterManager.GetDataBy(comboBox1.Text, subResgionIDTextBox.Text, buildingTextBox.Text);
                        if (dt.Rows.Count > 0)
                        {
                            int id;
                            id = ((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID;
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
                                string Comment = dt.Rows[s]["comment"].ToString();
                                string ext = FileName.Substring(FileName.LastIndexOf("."));
                                string yy = FileName.Substring(0, FileName.LastIndexOf("."));
                                string fullname = yy + ext;
                                string fullnameWithId = yy + id + ext;
                                bool isVisible = Convert.ToBoolean(dt.Rows[s]["Visible"]);

                                if (!GetFileExisting(fullname, fullnameWithId))
                                {

                                    if (am == "archive")
                                    {
                                        this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now, Comment, 0, 2, isVisible);
                                        //Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\OwAttach\\" + fullname);
                        
                                        this.attachmentTableAdapter.FillByArchive(this.dsrealowner.attachmentOwn);
                                    }
                                    else
                                    {
                                        this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now, Comment, 1, 2, isVisible);
                                        //Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\OwAttach\\" + fullname);
                                        this.attachmentTableAdapter.Fill(this.dsrealowner.attachmentOwn);
                                    }
                                }
                            }//loop
                        }

                    }
                    userIDTextBox.Text = Utils.current_user.ToString();
                    dateOfEnterDateTimePicker.Value = DateTime.Now;

                    this.Validate();
                    this.eventownBindingSource.EndEdit();
                    this.realStateBindingSource.EndEdit();
                    this.tableAdapterManager.attachmentOwnTableAdapter.Adapter.ContinueUpdateOnError = true;
                    this.tableAdapterManager.RealstateOwneTableAdapter.Adapter.ContinueUpdateOnError = true;
                    this.tableAdapterManager.eventownTableAdapter.Adapter.ContinueUpdateOnError = true;
                    this.tableAdapterManager.UpdateAll(this.dsrealowner);

                    //Insert Case
                    int pos = realStateBindingSource.Position;
                    if (pos >= 0 && pos < dsrealowner.RealstateOwne.Rows.Count)
                    {
                        ((DSrealowner.RealstateOwneRow)dsrealowner.RealstateOwne.Rows[pos]).published = false;
                    }


                    if (saved.Visible != true)
                    {
                        saved.Visible = true;
                    }
                    if (am == "archive")
                    {
                        this.realStateTableAdapter.FillArchive(this.dsrealowner.RealstateOwne);
                        Utils.realstateidowner = Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID);
                        this.eventownTableAdapter.FillByArchive(this.dsrealowner.eventown);

                    }
                    else if (gnon != "del")
                    {

                        this.realStateTableAdapter.Fill(this.dsrealowner.RealstateOwne);
                        Utils.realstateidowner = Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID);
                        this.eventownTableAdapter.Fill(this.dsrealowner.eventown);


                    }

                    if (recored_id > 0)
                    {
                        this.realStateTableAdapter.FillAll(this.dsrealowner.RealstateOwne, recored_id);
                        this.eventownTableAdapter.FillBy(this.dsrealowner.eventown, recored_id);
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

                    this.eventownBindingSource.ResumeBinding();

                    //eventTextBox.ReadOnly = true;


                    //      realStateBindingNavigatorSaveItem.Enabled = false;

                    chechupdatestate = true;

                }

                else // إذا وجد تكرارًا ولم يوافق المستخدم على المتابعة
                {
                    DSrealsearchown.RealstateOwneDataTable dt = (DSrealsearchown.RealstateOwneDataTable)Utils.checkexistOwner(subResgionIDTextBox.Text, buildingTextBox.Text, Convert.ToInt32(floorTextBox.Text), esra2);
                    Check.who = "own"; // تعيين نوع التحقق (بيع)
                    g = Check.ShowMeOWN(dt); // عرض تحذير للمستخدم ("kml" أو "cancel")
                    if (g == "kml")
                    {
                        continues = true; // يُسمح بالحفظ رغم التشابه
                        realStateBindingNavigatorSaveItem.PerformClick(); // يتم استدعاء الحفظ مرة أخرى
                    }
                    if (g == "cancel")
                    {
                        continues = false; // يتم إلغاء العملية
                        subResgionIDTextBox.Focus(); // التركيز على حقل الإدخال
                        saved.Visible = false; // إخفاء رسالة "تم الحفظ"
                    }

                    //   MessageBox.Show("متشابه");
                    saved.Visible = false;
                    continues = false;
                }

            }//soso
            else
            {
                userIDTextBox.Text = Utils.current_user.ToString();
                dateOfEnterDateTimePicker.Value = DateTime.Now;
                wasPublished = clsRealStateOwn.GetPublishedValuetoRealstate(Utils.realstateidowner);

                this.Validate();
                this.eventownBindingSource.EndEdit();
                this.realStateBindingSource.EndEdit();
                this.attachmentBindingSource.EndEdit();
                //this.tableAdapterManager.attachmentOwnTableAdapter.Adapter.ContinueUpdateOnError = true;
                //this.tableAdapterManager.RealstateOwneTableAdapter.Adapter.ContinueUpdateOnError = true;
                //this.tableAdapterManager.eventownTableAdapter.Adapter.ContinueUpdateOnError = true;
                this.tableAdapterManager.UpdateAll(this.dsrealowner);
                this.eventownTableAdapter.Update(this.dsrealowner.eventown);

                if (saved.Visible != true)
                {
                    saved.Visible = true;
                }
                if (am == "archive")
                {
                    this.realStateTableAdapter.FillArchive(this.dsrealowner.RealstateOwne);
                    Utils.realstateidowner = Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID);
                    this.eventownTableAdapter.FillByArchive(this.dsrealowner.eventown);

                }
                else if (gnon != "del")
                {

                    this.realStateTableAdapter.Fill(this.dsrealowner.RealstateOwne);
                    Utils.realstateidowner = Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID);
                    this.eventownTableAdapter.Fill(this.dsrealowner.eventown);
                }

                if (recored_id > 0 && gnon != "del")
                {
                    this.realStateTableAdapter.FillAll(this.dsrealowner.RealstateOwne, recored_id);
                    this.eventownTableAdapter.FillBy(this.dsrealowner.eventown, recored_id);

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

                this.eventownBindingSource.ResumeBinding();

                //eventTextBox.ReadOnly = true;

                //realStateBindingNavigatorSaveItem.Enabled = false;

                chechupdatestate = true;

            }

            if (clicked == "clicked" && g != "cancel")
            {

                DataTable dt = new DataTable();
                dt = TempTableAdapterManager.GetDataBy(comboBox1.Text, subResgionIDTextBox.Text, buildingTextBox.Text);
                if (dt.Rows.Count > 0)
                {
                    int id;
                    id = ((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID;
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

                        string Comment = dt.Rows[s]["comment"].ToString();
                        string ext = FileName.Substring(FileName.LastIndexOf("."));
                        string yy = FileName.Substring(0, FileName.LastIndexOf("."));
                        string fullname = yy + ext;
                        string fullnameWithId = yy + id + ext;
                        bool isVisible = Convert.ToBoolean(dt.Rows[s]["Visible"]);


                        //if (!GetFileExisting(fullname, fullnameWithId) || g == "")
                        if ((!AttachmentExistsByName(id, fullname, fullnameWithId)) || g=="")

                        {
                            this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now, Comment, 1, 2, isVisible);
                            // File.Copy(Utils.ProjectName + "\\attachment\\TempAttachment\\" + FileName, Utils.ProjectName + "\\attachment\\OwAttach\\" + fullname);
                            //Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\OwAttach\\" + fullname);
                            if (am == "archive")
                            {

                                this.attachmentTableAdapter.FillByArchive(this.dsrealowner.attachmentOwn);
                            }
                            else
                            {
                                this.attachmentTableAdapter.Fill(this.dsrealowner.attachmentOwn);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"الملف {fullname} موجود");
                        }
                    }//looop
                }
                clicked = "dd";
            }//if new


            if (clicked != "clicked" && g == "kml")
            {

                DataTable dt = new DataTable();
                dt = TempTableAdapterManager.GetDataBy(comboBox1.Text, subResgionIDTextBox.Text, buildingTextBox.Text);
                if (dt.Rows.Count > 0)
                {
                    int id;
                    id = ((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID;
                    for (int s = 0; s < dt.Rows.Count; s++)
                    {
                        string FileName = dt.Rows[s]["FileName"].ToString();
                        string Comment = dt.Rows[s]["comment"].ToString();
                        string ext = FileName.Substring(FileName.LastIndexOf("."));
                        string yy = FileName.Substring(0, FileName.LastIndexOf("."));
                        string fullnameWithId = yy + id + ext;
                        string fullname = yy + ext;

                        bool isVisible = Convert.ToBoolean(dt.Rows[s]["Visible"]);

                        //if (GetFileExisting(fullname) )
                        //{

                        //}
                        //if (!GetFileExisting(fullname))
                        if ((!AttachmentExistsByName(id, fullname, fullnameWithId)))
                        {
                            this.attachmentTableAdapter.Insert(id, fullname, "", DateTime.Now, Comment, 1, 2, isVisible);
                            // File.Copy(Utils.ProjectName + "\\attachment\\TempAttachment\\" + FileName, Utils.ProjectName + "\\attachment\\OwAttach\\" + fullname);
                            //Utils.shortcut(Utils.ProjectName + "\\TempAttachment\\" + FileName, Utils.ProjectName + "\\OwAttach\\" + fullname);
                            if (am == "archive")
                            {

                                this.attachmentTableAdapter.FillByArchive(this.dsrealowner.attachmentOwn);
                            }
                            else
                            {
                                this.attachmentTableAdapter.Fill(this.dsrealowner.attachmentOwn);
                            }
                        }
                        else
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
                            {
                                Process.Start("explorer.exe", $"/select,\"{Utils.ProjectName + "\\OwAttach\\" + fullname}\"");
                            }


                        }
                    }//looop
                }
                clicked = "dd";

            }//if duplicate


            HandlePendingAttachmentsForCurrentRealState();

            saved.Visible = true;
            chechupdatestate = true;

            int currentId = Utils.realstateidowner;

            // نجيب السجل الحالي
            if (realStateBindingSource.Current is DataRowView currentRow)
            {
               //Convert.ToBoolean(currentRow["published"]);
                bool isChecked = Published.Checked;

                // الحالة 3: مش منشور + المستخدم عمل تشيك → انشر
                if (!wasPublished && isChecked)
                {
                    currentRow["published"] = true;
                    currentRow.EndEdit();
                    realStateBindingSource.EndEdit();
                    this.realStateTableAdapter.Update(this.dsrealowner.RealstateOwne);

                    PublishRecord();
                }
                // الحالة 2: كان منشور + المستخدم لغى التشيك → الغي النشر
                else if (wasPublished && !isChecked)
                {
                    currentRow["published"] = false;
                    currentRow.EndEdit();
                    realStateBindingSource.EndEdit();
                    this.realStateTableAdapter.Update(this.dsrealowner.RealstateOwne);

                    UpdateActiveAndPublish(currentId);
                }
                else if (wasPublished && isChecked)
                {
                    currentRow["published"] = true;
                    currentRow.EndEdit();
                    realStateBindingSource.EndEdit();
                    this.realStateTableAdapter.Update(this.dsrealowner.RealstateOwne);

                    PublishRecord();
                }
                // الحالة 1: (مش منشور + مش متعلم) → تجاهل
            }

            if (g == "cancel")
            {

                saved.Visible = false;
                chechupdatestate = true;
            }


            Utils.CallName = ownerTextBox.Text;
            Utils.CallPlaceID = ",o" + Utils.realstateidowner;
            Utils.CallPlace = "," + "بيع";


            //var wasPublished = clsRealStateOwn.GetPublishedValuetoRealstate(Utils.realstateid);
            //var isChecked = Published.Checked;

            //// الحالة 3: المستخدم عايز ينشر دلوقتي
            //if (isChecked)
            //{
            //    clsRealStateOwn.MarkAsPublished(Utils.realstateid, true);
            //    PublishRecord();
            //}
            //// الحالة 2: كان منشور قبل كده والمستخدم لغى التشيك
            //else if (wasPublished)
            //{
            //    clsRealStateOwn.MarkAsPublished(Utils.realstateid, false);
            //    UpdateActiveAndPublish();
            //}
            //// الحالة 1: أول مرة ولسه مش منشور والمستخدم مش عامل تشيك
            //else
            //{
            //    // ولا حاجة تتعمل
            //}


            //var pubilshed = Convert.ToBoolean(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).published);
            //var isChecked = Published.Checked;
            //clsRealStateOwn.MarkAsPublished(Utils.realstateidowner, isChecked);


            //// الحالة 3: المستخدم عايز ينشر دلوقتي
            //if (!pubilshed && isChecked)
            //{
            //    PublishRecord();
            //}
            //// الحالة 2: كان منشور قبل كده والمستخدم لغى التشيك
            //else if (pubilshed && !isChecked)
            //{
            //    UpdateActiveAndPublish(Utils.realstateidowner);

            //}
            //// الحالة 1: أول مرة ولسه مش منشور والمستخدم مش عامل تشيك
            //else if (!pubilshed && !isChecked)
            //{
            //    return;
            //    //PublishRecord();
            //}
            //else if (pubilshed && isChecked)
            //{
            //    PublishRecord();
            //}

        }

        private bool formLoaded = false;
        public void Realstate_Load(object sender, EventArgs e)
        {
            formLoaded = true;

            //// ✅ إضافة هذا الكود لتحميل حالة النشر عند فتح السجل
            //if (this.realStateBindingSource.Count > 0)
            //{
            //    var row = (DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position];

            //    // تحميل حالة النشر من قاعدة البيانات وتعيينها للـ CheckBox
            //    Published.Checked = !row.IspublishedNull() && row.published;

            //    Utils.realstateidowner = row.ID;
            //}

            btnCallOwn1.Tag = (phone_oneTextBox, phone_oneLabel);
            btnCallOwn2.Tag = (mobileTextBox, mobileLabel);
            btnCallOwn3.Tag = (phone_TwoTextBox, phone_TwoLabel);
            btnCallOwn4.Tag = (mobileTextBox2, label5);
            btnCallOwn5.Tag = (otherTextBox, otherLabel);

            

            mobileTextBox.TextChanged += mobileTextBox_TextChanged;
            mobileTextBox.TextChanged += (s, ev) => CheckOtherRecords();

            // استدعاء أول مرة للتحقق عند التحميل
            CheckOtherRecords();


            Top_panel.BackColor = Color.FromArgb(45, 216, 129);

            this.buildingTypeTableAdapter.Fill(this.dSregion.BuildingType);
            this.regionTableAdapter.Fill(this.dSregion.Region);
            this.ownInvestitureTableAdapter.Fill(this.dsrealowner.OwnInvestiture);
            this.wayOFOwnerTableAdapter.Fill(this.dsrealowner.WayOFOwner);

            if (recored_id > 0)
            {
                this.realStateTableAdapter.FillAll(this.dsrealowner.RealstateOwne, recored_id);
                this.attachmentTableAdapter.FillByCheck(this.dsrealowner.attachmentOwn, recored_id);
                this.eventownTableAdapter.FillBy(this.dsrealowner.eventown, recored_id);


                bindingNavigatorAddNewItem.Enabled = false;

                if ((((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).active.ToString() == "0"))
                {
                    am = "archive";
                    this.realStateTableAdapter.FillAll(this.dsrealowner.RealstateOwne, recored_id);
                    this.attachmentTableAdapter.FillByCheck(this.dsrealowner.attachmentOwn, recored_id);
                    this.eventownTableAdapter.FillBy(this.dsrealowner.eventown, recored_id);
                    bindingNavigatorAddNewItem.Enabled = false;
                    bindingNavigatorDeleteItem.Enabled = false;
                    button2.Visible = false;
                    Restore.Visible = true;
                    if (this.realStateBindingSource.Count > 0)
                    {
                        Utils.realstateidowner = Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID);
                

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
                        bindingNavigatorDeleteItem.Enabled = false;
                    }
                }

                Utils.realstateidowner = recored_id;
            }

            else
            {

                //this.realstateOwneTableAdapter.Fill(this.dSrealsearchown.RealstateOwne);
                this.realStateTableAdapter.Fill(this.dsrealowner.RealstateOwne);
                this.attachmentTableAdapter.Fill(this.dsrealowner.attachmentOwn);
                this.eventownTableAdapter.Fill(this.dsrealowner.eventown);
                if (am == "archive" || (((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).active.ToString() == "0"))
                {
                    am = "archive";
                    this.attachmentTableAdapter.FillByArchive(this.dsrealowner.attachmentOwn);
                    this.eventownTableAdapter.FillByArchive(this.dsrealowner.eventown);
                    this.realStateTableAdapter.FillArchive(this.dsrealowner.RealstateOwne);


                    bindingNavigatorAddNewItem.Enabled = false;
                    bindingNavigatorDeleteItem.Enabled = false;

                    button2.Visible = false;

                    Restore.Visible = true;
                    if (this.realStateBindingSource.Count > 0)
                    {
                        Utils.realstateidowner = Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID);

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
                        bindingNavigatorDeleteItem.Enabled = false;
                    }
                }

            }

            CheckWebsiteIdAndToggleButton(Utils.realstateidowner);

            actived = true;


            if (am == "view" || am == "search")
            {
                this.Text = "العقار";
                bindingNavigatorAddNewItem.Enabled = false;
            }

            this.m_wndToolTip = new System.Windows.Forms.ToolTip(this.components);
            m_wndToolTip.ShowAlways = true;

            if (this.realStateBindingSource.Count > 0)
            {
                Utils.realstateidowner = Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID);
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

            encrypt();


            DataAccess dataAccess = new DataAccess();
            autoComplete = new CustomSource(dataAccess.GetNames().ToArray());
            ownerTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            ownerTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            autoComplete.Bind(ownerTextBox);


            BuildingautoComplete = new CustomSource(dataAccess.GetBuilding().ToArray());
            buildingTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            buildingTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            BuildingautoComplete.Bind(buildingTextBox);


            chechupdatestate = true;


            if (toDo == "new")
            {
                bindingNavigatorAddNewItem.PerformClick();
                phone_oneTextBox.Text = toDophne;
                otherTextBox.Text = toDoother;
                mobileTextBox.Text = toDomop;

            }

            if (string.IsNullOrEmpty(roomsTextBox.Text.Trim()))
                roomsTextBox.Text = "0";

            Buttons_toolStrip();


            noteTextBox.PreviewKeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Tab)
                {
                    ev.IsInputKey = true;
                    eventownBindingNavigator.Focus(); // الفوكس على البايندنج نافيجيتور
                    eventownBindingNavigator.Items[0].Select(); // أول زر (toolStripButton1 مثلاً)
                }
            };


            SessionManager.AddOpenedRecord("بيع", Utils.realstateidowner);

            // Check for related records on form load
            CheckOtherRecords();

        }


        private void CheckOtherRecords()
        {
            Utils.CheckOtherRecord = true;

            // Collect all numbers from the textboxes
            List<string> numbers = new List<string>();
            if (!string.IsNullOrWhiteSpace(otherTextBox.Text)) numbers.Add(otherTextBox.Text.Trim());
            if (!string.IsNullOrWhiteSpace(mobileTextBox2.Text)) numbers.Add(mobileTextBox2.Text.Trim());
            if (!string.IsNullOrWhiteSpace(phone_TwoTextBox.Text)) numbers.Add(phone_TwoTextBox.Text.Trim());
            if (!string.IsNullOrWhiteSpace(mobileTextBox.Text)) numbers.Add(mobileTextBox.Text.Trim());

            if (numbers.Count > 0)
            {
                // Pass the list of numbers to Form1
                f = new RelatedRecordsForm(numbers, "", "", "0", Utils.realstateidowner.ToString());

                if (f.totalRecordsFound > 0) // Use new property in Form1
                {
                    otherRecordsBtn.Visible = true;
                    otherRecordsBtn.Text = $"سجلات أخري ({f.totalRecordsFound})"; // Show record count
                }
                else
                {
                    otherRecordsBtn.Visible = false;
                }
            }
            else
            {
                otherRecordsBtn.Visible = false;
            }
        }

        public void encrypt()
        {
            if (Utils.EncryptMode)
            {

                buildingTextBox.ForeColor = Color.White;
                ownerTextBox.ForeColor = Color.White;
                phone_oneTextBox.ForeColor = Color.White;
                phone_TwoTextBox.ForeColor = Color.White;
                mobileTextBox.ForeColor = Color.White;
                otherTextBox.ForeColor = Color.White;
                info_SourceTextBox.ForeColor = Color.White;
                noteTextBox.ForeColor = Color.White;

                eventTextBox.ReadOnly = false;
                eventTextBox.ForeColor = Color.White;
                dataGridViewTextBoxColumn14.Visible = false;

                //MainForm.Imagencrypt.Visible = true;
                //MainForm.Imagencrypt2.Visible = true;


            }
            if (!Utils.EncryptMode)
            {

                buildingTextBox.ForeColor = Color.Black;
                ownerTextBox.ForeColor = Color.Black;
                phone_oneTextBox.ForeColor = Color.Black;
                phone_TwoTextBox.ForeColor = Color.Black;
                mobileTextBox.ForeColor = Color.Black;
                otherTextBox.ForeColor = Color.Black;
                info_SourceTextBox.ForeColor = Color.Black;
                noteTextBox.ForeColor = Color.Black;

                eventTextBox.ReadOnly = true;
                eventTextBox.ForeColor = Color.Black;
                dataGridViewTextBoxColumn14.Visible = true;

                //MainForm.Imagencrypt.Visible = false;
                //MainForm.Imagencrypt2.Visible = false;
            }

        }

        //private void button3_Click(object sender, EventArgs e)
        //{

        //    if (this.dsrealowner.RealstateOwne.Rows.Count >= realStateBindingSource.Count)
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
        //            string fullname = yy + Utils.realstateidowner + ext;
        //            if (!(GetFileExisting(fullname)))
        //            {
        //                textBox4.Text = Utils.ProjectName + "\\OwAttach\\" + fdlg.SafeFileName;
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
            if (this.dsrealowner.RealstateOwne.Rows.Count >= realStateBindingSource.Count)
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
                        textBox4.AppendText(Utils.ProjectName + "\\OwAttach\\" + Path.GetFileName(filePath) + Environment.NewLine);
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
            if (System.IO.File.Exists(Utils.ProjectName + "\\TempAttachment\\" + filename))
            {
                return true;
            }
            else if (System.IO.File.Exists(Utils.ProjectName + "\\OwAttach\\" + fileNameWithId))
            {
                return true;
            }
            else if (temp == "T")
            {
                int start = filename.IndexOf(Utils.realstateidowner.ToString());
                //string ext = filename.Substring(filename.LastIndexOf("."));
                // string t = filename.Substring(0, start);

                if (System.IO.File.Exists(Utils.ProjectName + "\\OwAttach\\" + filename + ".lnk"))
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


        //private void button4_Click(object sender, EventArgs e)
        //{
        //    AttachComment.ShowMe();
        //    string result = AttachComment.Button_Clicked;
        //    if (result != "")
        //    {

        //        if (textBox4.Text != null && textBox4.Text != "")
        //        {
        //            string filename = fdlg.SafeFileName;
        //            string ext = filename.Substring(filename.LastIndexOf("."));
        //            string yy = filename.Substring(0, filename.LastIndexOf("."));
        //            string fullname = yy + Utils.realstateidowner + ext;
        //            int id = ((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID;
        //            //if (this.attachmentTableAdapter.GetDataByCheck(id).Rows.Count < 0)
        //            //{
        //            if (am == "archive")
        //            {
        //                this.attachmentTableAdapter.Insert(id, fullname, fdlg.FileName, DateTime.Now.Date, result, 0);
        //                File.Copy(fdlg.FileName, Utils.ProjectName + "\\OwAttach\\" + fullname);
        //            }
        //            else
        //            {
        //                this.attachmentTableAdapter.Insert(id, fullname, fdlg.FileName, DateTime.Now.Date, result, 1);
        //                File.Copy(fdlg.FileName, Utils.ProjectName + "\\OwAttach\\" + fullname);
        //            }


        //            MessageBox.Show("تم الحفظ");
        //            if (am == "archive")
        //                this.attachmentTableAdapter.FillByArchive(this.dsrealowner.attachmentOwn);
        //            else
        //                this.attachmentTableAdapter.Fill(this.dsrealowner.attachmentOwn);



        //            this.realStateBindingSource.ResumeBinding();
        //            textBox4.Text = "";
        //        }

        //        else
        //        {
        //            int idatt = Convert.ToInt32(attachmentOwnDataGridView.CurrentRow.Cells[0].Value);

        //            if (am == "archive")
        //            {
        //                this.attachmentTableAdapter.UpdateQueryExist(result, 0, idatt);
        //                this.attachmentTableAdapter.FillByArchive(this.dsrealowner.attachmentOwn);

        //            }
        //            else
        //            {
        //                this.attachmentTableAdapter.UpdateQueryExist(result, 1, idatt);
        //                this.attachmentTableAdapter.Fill(this.dsrealowner.attachmentOwn);

        //            }

        //        }
        //    }

        //    else
        //    {

        //        MessageBox.Show("الرجاء ادخال النص");
        //    }
        //}


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
        //    // عرض نافذة التعليق وجلب النتيجة
        //    AttachComment.ShowMe();
        //    string comment = AttachComment.Button_Clicked;

        //    if (string.IsNullOrEmpty(comment))
        //    {
        //        MessageBox.Show("الرجاء إدخال نص التعليق");
        //        return;
        //    }

        //    // حالة إضافة مرفق جديد
        //    if (!string.IsNullOrEmpty(textBox4.Text))
        //    {
        //        AddNewAttachment(comment);
        //        Buttons_toolStrip();
        //    }
        //    // حالة تعديل تعليق مرفق موجود
        //    else
        //    {
        //        UpdateAttachmentComment(comment);
        //    }
        //}

        private void AddNewAttachmentMulti(string filePath, string comment)
        {
            try
            {
                string uniqueFileName = CustomPath.UniqueFileName(Path.GetFileName(filePath), Utils.realstateid);
                bool isCreated = CustomPath.CreateAttachment(filePath, uniqueFileName, "OwAttach", Utils.realstateid);
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

        private void AddNewAttachment(string comment)
        {
            try
            {
                string uniqueFileName = CustomPath.UniqueFileName(fdlg.SafeFileName, Utils.realstateidowner);
                bool isCreated = CustomPath.CreateAttachment(fdlg.FileName, uniqueFileName, "OwAttach", Utils.realstateidowner);
                if (!isCreated) return;


                int propertyId = GetCurrentPropertyId();

                bool isArchive = (am == "archive");
                int activeStatus = isArchive ? 0 : 1;
                int type = 1;

                this.attachmentTableAdapter.Insert(
                    propertyId,
                    uniqueFileName,
                    fdlg.FileName,
                    DateTime.Now.Date,
                    comment,
                    activeStatus,
                    type,
                    false
                );

                RefreshAttachmentGrid(isArchive);
                ClearAttachmentForm();

                MessageBox.Show(
                            "تم حفظ المرفق بنجاح",
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
                           $"حدث خطأ أثناء حفظ المرفق: {ex.Message}",
                              "خطأ",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error,
                              MessageBoxDefaultButton.Button3,
                              MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                          );
            }
        }

        private void UpdateAttachmentComment(string comment)
        {
            try
            {
                if (attachmentOwnDataGridView.CurrentRow == null)
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

                int attachmentId = Convert.ToInt32(attachmentOwnDataGridView.CurrentRow.Cells[0].Value);

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
            return ((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne
                   .Rows[realStateBindingSource.Position]).ID;
        }


        private void RefreshAttachmentGrid(bool isArchive)
        {
            // دالة مساعدة لتحديث عرض المرفقات
            if (isArchive)
                this.attachmentTableAdapter.FillByArchive(this.dsrealowner.attachmentOwn);
            else
                this.attachmentTableAdapter.Fill(this.dsrealowner.attachmentOwn);
        }


        private void ClearAttachmentForm()
        {
            // دالة مساعدة لمسح حقول المرفق
            textBox4.Text = "";
            this.realStateBindingSource.ResumeBinding();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = ((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID;
            if (am == "archive")

                this.eventownTableAdapter.Fillsearch(this.dsrealowner.eventown, id, "%" + searchtext.Text + "%", "%" + searchtext.Text + "%", 0);
            else
                this.eventownTableAdapter.Fillsearch(this.dsrealowner.eventown, id, "%" + searchtext.Text + "%", "%" + searchtext.Text + "%", 1);

        }


        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (this.dsrealowner.RealstateOwne.Rows.Count > 0)
            {
                var row = (DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position];
                Published.Checked = row.published;

                // مزامنة القيمة مع قاعدة البيانات
                clsRealStateOwn.MarkAsPublished(row.ID, row.published);
            }

            Utils.realstateidowner = Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID);
            if (am == "archive")
            {
                this.eventownTableAdapter.FillByArchive(this.dsrealowner.eventown);
                //                realStateBindingNavigatorSaveItem.Enabled = false;
                bindingNavigatorAddNewItem.Enabled = false;
                bindingNavigatorDeleteItem.Enabled = false;
            }
            else
            {
                this.eventownTableAdapter.Fill(this.dsrealowner.eventown);
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



            //////////////////
            //if (this.ActiveControl.Name == "ownerTextBox")
            //{
            //    getNames();
            //    string text = ownerTextBox.Text;
            //    if (!textChanging)
            //    {
            //        textChanging = true;
            //        string prefix = "";
            //        //                        string text = ownerTextBox.Text;

            //        if (ownerTextBox.Text.Length > 0)
            //        {
            //            text += ownerTextBox.Text.Trim();
            //        }
            //        else
            //        {
            //            text = ownerTextBox.Text;
            //        }
            //        bool changed = false;

            //        if (lastText.Length < text.Length && text.EndsWith(" "))
            //        {
            //            prefix = text;
            //            changed = true;
            //        }
            //        else if (lastText.Length < text.Length && lastText.EndsWith(" ") && text.Contains(' '))
            //        {
            //            prefix = text.Substring(0, text.LastIndexOf(' '));
            //            changed = true;
            //        }

            //        if (changed)
            //        {
            //            autoComplete.ReleaseAutoComplete();
            //            autoComplete = new CustomSource(suggestions.Select(t => prefix + t).ToArray());
            //            autoComplete.Bind(ownerTextBox);
            //        }

            //        textChanging = false;
            //    }
            //}

            //if (this.ActiveControl.Name == "buildingTextBox")
            //{
            //    getBuilding();
            //    string text = buildingTextBox.Text;
            //    if (!BuildingtextChanging)
            //    {
            //        BuildingtextChanging = true;
            //        string prefix = "";
            //        //string text = "";
            //        if (buildingTextBox.Text.Length > 0)
            //        {
            //            text += buildingTextBox.Text.Trim();
            //        }
            //        else
            //        {
            //            text = buildingTextBox.Text;
            //        }


            //        bool changed = false;

            //        if (BuildinglastText.Length < text.Length && text.EndsWith(" "))
            //        {
            //            prefix = text;
            //            changed = true;
            //        }
            //        else if (BuildinglastText.Length < text.Length && BuildinglastText.EndsWith(" ") && text.Contains(' '))
            //        {
            //            prefix = text.Substring(0, text.LastIndexOf(' '));
            //            changed = true;
            //        }

            //        if (changed)
            //        {
            //            BuildingautoComplete.ReleaseAutoComplete();
            //            BuildingautoComplete = new CustomSource(Buildingngsuggestions.Select(t => prefix + t).ToArray());
            //            BuildingautoComplete.Bind(buildingTextBox);
            //        }

            //        BuildingtextChanging = false;
            //    }
            //}


            if (this.ActiveControl.Name == "areaTextBox" || this.ActiveControl.Name == "priceTextBox")
            {
                chechupdatestate = false;


            }
        }


        #region
        //private void attachmentOwnDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //string path = attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
        //    //    string temp = path.Substring(0, 1);
        //    //    if ((GetFileExisting(path)))
        //    //    {
        //    //        if (temp != "T")
        //    //        {
        //    //            if (File.Exists(@"d:\myFile.txt"))
        //    //            {
        //    //                File.Delete(@"d:\myFile.txt");
        //    //            }
        //    //            using (StreamWriter w = File.AppendText(@"d:\myFile.txt"))
        //    //            {
        //    //                w.WriteLine(Utils.ProjectName + "\\OwAttach\\" + path);
        //    //            }
        //    //            System.Diagnostics.Process.Start(Utils.ProjectName + "\\OwAttach\\" + path);
        //    //            File.SetAttributes(@"d:\myFile.txt", FileAttributes.Hidden);
        //    //        }
        //    //        else
        //    //        {
        //    //            //int start = path.IndexOf(Utils.realstateidowner.ToString());
        //    //            //string ext = path.Substring(path.LastIndexOf("."));
        //    //            // string t = path.Substring(0, start);
        //    //            //if (File.Exists(@"d:\myFile.txt"))
        //    //            //{
        //    //            //    File.Delete(@"d:\myFile.txt");
        //    //            //}
        //    //            //using (StreamWriter w = File.AppendText(@"d:\myFile.txt"))
        //    //            //{
        //    //            //    w.WriteLine(Utils.ProjectName + "\\OwAttach\\" + path + ".lnk");
        //    //            //}

        //    //            Utils.OpenFile(Utils.ProjectName + "\\OwAttach\\" + path + ".lnk");
        //    //            //File.SetAttributes(@"d:\myFile.txt", FileAttributes.Hidden);


        //    //            //if (temp != "T")
        //    //            //{
        //    //            //    System.Diagnostics.Process.Start(Utils.ProjectName + "\\attachment\\OwAttach\\" + path);
        //    //            //}
        //    //            //else
        //    //            //{
        //    //            //    int start = path.IndexOf(Utils.realstateidowner.ToString());
        //    //            //    string ext = path.Substring(path.LastIndexOf("."));
        //    //            //   // string t = path.Substring(0, start);
        //    //            //    System.Diagnostics.Process.Start(Utils.ProjectName + "\\attachment\\OwAttach\\" + path + ".lnk");

        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        MessageBox.Show("الملف غير موجود");
        //    //    }
        //}
        #endregion
        private void attachmentOwnDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 2) return; // التأكد من أن النقر كان على عمود الملفات

            string fileName = attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
            string isShortcut = fileName.Substring(0, 1);
            int attachmentId = Convert.ToInt32(attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[0].Value);
            string recordId = attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[1].Value.ToString();

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
                //    CustomPath.OpenAttachmentShortcut(fileName, "OwAttach");
                //else
                CustomPath.OpenAttachment(fileNameOriginal, "OwAttach", fileName);
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
            //Published.Checked = false;

            if (clicked == "clicked")
            {
                realStateBindingNavigatorSaveItem.PerformClick();
                bindingNavigatorAddNewItem.PerformClick();
                this.clicked = "clicked";

            }
            else
            {
                activeTextBox1.Text = "1";
                comboBox4.SelectedIndex = 9;

                dateOfEnterDateTimePicker.Value = DateTime.Now.AddDays(-2).AddMonths(-2).AddYears(-2);
                dateOfEnterDateTimePicker.Value = DateTime.Now;

                dateOchangeDateTimePicker.Value = DateTime.Now.Date.AddDays(-2).AddMonths(-2).AddYears(-2);
                dateOchangeDateTimePicker.Value = DateTime.Now.Date;

                comboBox1.Text = "مشروع دمر";
                bindingNavigatorMovePreviousItem.Enabled = false;
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorDeleteItem.Enabled = false;

                realStateBindingNavigatorSaveItem.Enabled = true;
                Restore.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;

                chechupdatestate = false;
                this.clicked = "clicked";



            }

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
        //    if (keyData == Keys.F11)
        //    {
        //        Utils.EncryptMode = !Utils.EncryptMode;
        //        encrypt();
        //        return true;

        //    }
        //    if (keyData == Keys.F2)
        //    {
        //        saved.Visible = true;
        //        realStateBindingNavigatorSaveItem.PerformClick();
        //        // realStateBindingNavigatorSaveItem.Enabled = false;

        //        return true;

        //    }

        //    if (keyData == Keys.F5)
        //    {

        //        realStateBindingNavigatorSaveItem.PerformClick();
        //        bindingNavigatorAddNewItem.PerformClick();
        //        comboBox1.Focus();
        //        return true;

        //    }

        //    if (keyData == Keys.F1)
        //    {

        //        back = "back";
        //        this.Close();
        //        return true;

        //    }
        //    //}
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

        private void Published_CheckedChanged(object sender, EventArgs e)
        {
            //int recordId = Utils.realstateid;
            //bool isChecked = ((CheckBox)sender).Checked;

            //// ✅ أولاً: حدّث في قاعدة البيانات
            //clsRealState.MarkAsPublished(recordId, isChecked);
            //currentRow["published"] = isChecked;
            // ✅ ثانيًا: استدعي API
            //await UpdatePublishStateInAPI(recordId, isChecked);


            if (realStateBindingSource.Current is DataRowView currentRow)
            {
                bool isChecked = ((CheckBox)sender).Checked;

                // ✅ مجرد تحديث في DataSet
                currentRow["published"] = isChecked;
            }


        }

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
                        // منع الإغلاق والبقاء في الفورم
                        return true;
                    }
                }
                else
                {
                    close = "closed";
                    this.Close();
                }

                return true; // منع أي تنفيذ إضافي للزر ESC
            }

            if (keyData == Keys.F11)
            {
                Utils.EncryptMode = !Utils.EncryptMode;
                encrypt();
                return true;
            }

            if (keyData == Keys.F2)
            {
                saved.Visible = true;
                realStateBindingNavigatorSaveItem.PerformClick();
                return true;
            }

            if (keyData == Keys.F5)
            {
                realStateBindingNavigatorSaveItem.PerformClick();
                bindingNavigatorAddNewItem.PerformClick();
                comboBox1.Focus();
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

        private void Restore_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("هل تريد استعاده العقار ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

            if (result1 == DialogResult.Yes)
            {

                //this.realStateTableAdapter.UpdateRestor(Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID));
                //this.attachmentTableAdapter.UpdateQueryRestor(Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID));
                //this.eventownTableAdapter.UpdateQueryRestore(Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID));

                this.realStateTableAdapter.UpdateRestor(Utils.realstateidowner);
                this.attachmentTableAdapter.UpdateQueryRestor(Utils.realstateidowner, Utils.realstateidowner);
                this.eventownTableAdapter.UpdateQueryRestore(Utils.realstateidowner);


                this.realStateTableAdapter.FillArchive(this.dsrealowner.RealstateOwne);

                if (this.realStateBindingSource.Count == 0)
                {
                    bindingNavigatorAddNewItem.Enabled = false;
                    realStateBindingNavigatorSaveItem.Enabled = false;
                    //                    saved.Visible = true;
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
                int currentId = Utils.realstateidowner;

                // حذف العقار من قاعدة البيانات
                bool isDeleted = clsRealStateOwn.SetRealStateOwnInactive(currentId);
                if (isDeleted)
                {
                    // Active = 0 ونسيب IsPublished زي ماهو
                    UpdateActiveAndPublish(currentId);

                    // تحديث الـ DB بآخر قيمة لـ Published
                    clsRealStateOwn.MarkAsPublished(currentId, Published.Checked);
                }
                //var pubilshed = clsRealStateOwn.GetPublishedValuetoRealstate(currentId);// Convert.ToBoolean(((DSrealstate.RealStateRow)this.dSrealstate.RealState.Rows[realStateBindingSource.Position]).published);

                if (isDeleted)
                {
                    MessageBox.Show("تم حذف العقار (تفعيل غير نشط) بنجاح.", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    // إعادة تحميل البيانات
                    this.realStateTableAdapter.Fill(this.dsrealowner.RealstateOwne);

                    // إعادة ربط الـ BindingSource (احتياطي)
                    realstateOwneBindingSource.DataSource = this.dsrealowner.RealstateOwne;


                    // نحاول نرجع على أول سجل بعد الحذف
                    if (realstateOwneBindingSource.Count > 0)
                    {
                        // نحاول نلاقي أقرب سجل بعد ID المحذوف
                        bool found = false;

                        foreach (DataRowView rowView in realstateOwneBindingSource)
                        {
                            DSrealowner.RealstateOwneRow row = (DSrealowner.RealstateOwneRow)rowView.Row;
                            if (row.ID > currentId)
                            {
                                realstateOwneBindingSource.Position = realstateOwneBindingSource.Find("ID", row.ID);
                                Utils.realstateidowner = row.ID;
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            // لو مفيش سجل ID أكبر منه، نرجع للسجل الأخير
                            realstateOwneBindingSource.Position = realstateOwneBindingSource.Count - 1;
                            Utils.realstateidowner = Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realstateOwneBindingSource.Position]).ID);
                        }
                    }
                    else
                    {
                        // مفيش سجلات خالص
                        Utils.realstateidowner = 0;
                    }


                  
                    //if (pubilshed)
                    //{
                    //    UpdateActiveAndPublish(currentId);
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


            //    DialogResult result = MessageBox.Show(
            //   "هل أنت متأكد من حذف العقار؟",
            //   "تنبيه",
            //   MessageBoxButtons.OKCancel,
            //   MessageBoxIcon.Question,
            //   MessageBoxDefaultButton.Button2, // الافتراضي على "إلغاء"
            //   MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
            //    );

            //    if (result == DialogResult.OK)
            //    {
            //        // تنفيذ الحذف وتحديث البيانات
            //        bool isDeleted = clsRealStateOwn.SetRealStateOwnInactive(Utils.realstateidowner);

            //        if (isDeleted)
            //        {
            //            MessageBox.Show(
            //                "تم حذف العقار (تفعيل غير نشط) بنجاح.",
            //                "نجاح",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Information,
            //                MessageBoxDefaultButton.Button1,
            //                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
            //            );
            //            // ضع هنا كود إعادة تحميل أو تحديث البيانات في الواجهة بعد الحذف
            //        }
            //        else
            //    {
            //        MessageBox.Show(
            //            "تعذر حذف العقار لوجود بيانات مرتبطة به.",
            //            "خطأ",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Error,
            //            MessageBoxDefaultButton.Button1,
            //            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
            //        );
            //    }
            //}

        }

        string gnon = "";
        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {

        }
        string basePath = Utils.ProjectName;
        bool hasUnlinked = false;
        private bool HandlePendingAttachmentsForCurrentRealState()
        {
            // Get current real estate info
            var currentRow = (DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position];
            long currentID = currentRow.ID;
            //string currentRegionName = currentRow.Region_ID?.Trim();
            string currentRegionName = null;
            if (!currentRow.IsRegion_IDNull())
            {
                currentRegionName = currentRow.Region_ID.Trim();
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
                    if (!clsAttachmentOwn.Exists(currentID, temp.Comment)) // مش مربوط
                    {
                        string filePath = Path.Combine(basePath, "TempAttachment", temp.FileName);
                        clsAttachmentOwn newAttach = new clsAttachmentOwn()
                        {
                            RealStateOwnID = currentID,
                            FileName = temp.FileName,
                            Path = filePath,
                            Comment = temp.Comment,
                            Type = 2,
                            DateOFAttash = DateTime.Now
                        };
                        clsAttachmentOwn.AddAttachment(newAttach);
                        hasUnlinked = true;
                    }
                }
            }

            if (hasUnlinked)
                RefreshAttachmentGrid(false);

            return hasUnlinked;
        }

        //private void Realstate_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (close != "closed")
        //    {
        //        if (SnewMessageBox != null)
        //        {

        //            SnewMessageBox.Dispose();
        //            AlarmSound.main_timer.Start();
        //            AlarmSound.player.Play();
        //        }

        //        if (!chechupdatestate || !checkupdate())// || HandlePendingAttachmentsForCurrentRealState())
        //        {

        //            DialogResult  result1 = MessageBox.Show(
        //                   "هل تريد الحفظ ", "تنبيه",
        //                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk,
        //                   MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);



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

        //    }
        //    close = "";
        //}
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

                if (!chechupdatestate || !checkupdate()) // || HandlePendingAttachmentsForCurrentRealState())
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
                    else if (result1 == DialogResult.No)
                    {
                        close = "closed";
                        this.Close();
                    }
                    else if (result1 == DialogResult.Cancel)
                    {
                        e.Cancel = true; // يمنع الفورم من الإغلاق
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
            //            realStateBindingNavigatorSaveItem.Enabled = true;
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
            // events
            DialogResult result1 = MessageBox.Show("هل تريد حذف الحدث ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            DialogResult result2;

            if (result1 == DialogResult.Yes)
            {
                result2 = MessageBox.Show("هل انت متأكد من حذف الحدث ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (result2 == DialogResult.Yes)
                    toolStripButton2.PerformClick();

            }
        }

        private void attachmentOwnDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //string path = attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
            //File.Delete(Utils.ProjectName + "\\attachment\\OwAttach\\" + path);
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

        private void toolStripButton4_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult result2 = MessageBox.Show("هل انت متأكد من حذف المرفق؟", "تنبيه",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,
            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

            if (result2 != DialogResult.Yes)
                return;


            string fileNameWithId = attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
            int attachmentId = Convert.ToInt32(attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[0].Value);
            string recordId = attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[1].Value.ToString();

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

            bool isFromTemp = System.IO.File.Exists(tempPath);

            // حذف من قاعدة البيانات
            clsAttachmentOwn attachment = new clsAttachmentOwn();
            attachment.ID = attachmentId;
            attachment.Delete();

            this.attachmentTableAdapter.Fill(this.dsrealowner.attachmentOwn);

            //attachmentOwnDataGridView.Rows.Remove(attachmentOwnDataGridView.CurrentRow);
            RefreshAttachmentGrid(false);

            System.IO.File.Delete(Utils.ProjectName + "\\OwAttach\\" + fileNameWithId);

            //if (isFromTemp)
            //{
            //    var tempAttachment = clsTempAttachment.GetTempFileByName(finalFileName);

            //    if (tempAttachment != null)
            //    {
            //        deletedAutoAttachments.Add(new TempDeletedAttachment
            //        {
            //            FileName = finalFileName,
            //            Comment = tempAttachment.Comment
            //        });
            //    }
            //}
            //else
            //{
            //    System.IO.File.Delete(Utils.ProjectName + "\\OwAttach\\" + fileNameWithId);
            //}

            //chechupdatestate = false;

            ///TaskDeletedAttachments
            //foreach (var att in deletedAutoAttachments)
            //{
            //    string ext2 = Path.GetExtension(att.FileName);
            //    string yy = Path.GetFileNameWithoutExtension(att.FileName);
            //    string fullname = yy + Utils.realstateidowner + ext2;

            //    if (!GetFileExisting(fullname)) // احتمال تصحيحها: fullname بدل yy
            //    {
            //        attachmentTableAdapter.Insert(Utils.realstateidowner, fullname, "", DateTime.Now.Date, att.Comment, (am == "archive" ? 0 : 1), 2, false);

            //        if (am == "archive")
            //            attachmentTableAdapter.FillByArchive(this.dsrealowner.attachmentOwn);
            //        else
            //            attachmentTableAdapter.Fill(this.dsrealowner.attachmentOwn);
            //    }
            //}
            //deletedAutoAttachments.Clear();

            //DialogResult result2 = MessageBox.Show("هل انت متأكد من حذف المرفق ", "تنبيه",
            //     MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,
            //       MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            //if (result2 == DialogResult.Yes)
            //{
            //    string path = attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
            //    string temp = path.Substring(0, 1);

            //    if (System.IO.File.Exists(Utils.ProjectName + "\\OwAttach\\" + path) && temp != "T")
            //    {
            //        System.IO.File.Delete(Utils.ProjectName + "\\OwAttach\\" + path);
            //        chechupdatestate = false;

            //        toolStripButton4.PerformClick();
            //        realStateBindingNavigatorSaveItem.PerformClick();
            //    }
            //    else if (temp == "T")
            //    {
            //        System.IO.File.Delete(Utils.ProjectName + "\\OwAttach\\" + path + ".lnk");
            //        chechupdatestate = false;
            //        toolStripButton4.PerformClick();
            //        realStateBindingNavigatorSaveItem.PerformClick();
            //    }
            //    else
            //    {
            //        MessageBox.Show("الملف غير موجود");
            //    }
            //}

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
            Boolean key;
            string notetext;
            string info;
            //  string rooms;

            ////////////////////////////////////////////////////////////////////////////
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT ID from RealstateOwne WHERE ";
            try
            {

                //if (comboBox1.SelectedValue.ToString() != "")
                if (comboBox1.SelectedValue != null && comboBox1.SelectedValue.ToString() != "")
                {
                    //  region = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                    SqlStatement += " RealstateOwne.Region_ID = '" + comboBox1.Text + "'";
                    SqlStatement += " and ";
                }

                if (subResgionIDTextBox.Text != "")
                {
                    subregion = subResgionIDTextBox.Text;
                    SqlStatement += " RealstateOwne.SubResgionID = '" + subregion + "'";
                    SqlStatement += " and ";

                }

                if (buildingTextBox.Text != "")
                {
                    building = buildingTextBox.Text;
                    //SqlStatement += " RealstateOwne.Building = '%" + building + "%'";
                    SqlStatement += " RealstateOwne.Building LIKE '%" + building + "%'";

                    SqlStatement += " and ";


                }
                if (floorTextBox.Text.ToString() != "")
                {
                    floor = Convert.ToInt32(floorTextBox.Text);
                    SqlStatement += " RealstateOwne.Floor = " + Convert.ToInt32(floor) + "";
                    SqlStatement += " and ";

                }

                if (floorCommentTextBox.Text != "")
                {
                    fcomment = floorCommentTextBox.Text;
                    SqlStatement += " RealstateOwne.FloorComment = '" + fcomment + "'";
                    SqlStatement += " and ";

                }

                if (entranceTextBox.Text != "")
                {
                    md5al = entranceTextBox.Text;
                    SqlStatement += " RealstateOwne.Entrance = '" + md5al + "'";
                    SqlStatement += " and ";
                }
                if (distanceTextBox.Text != "")
                {
                    eljha = distanceTextBox.Text;
                    SqlStatement += " RealstateOwne.Distance = '" + eljha + "'";
                    SqlStatement += " and ";
                }

                if (comboBox2.SelectedValue != null && comboBox2.SelectedValue != "")
                {
                    buildingtype = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                    SqlStatement += " RealstateOwne.Building_Type_ID= " + buildingtype;
                    SqlStatement += " and ";
                }

                if (comboBox4.Text != "")
                {
                    SqlStatement += " RealstateOwne.WayOFOwner= '" + comboBox4.Text + "'";
                    SqlStatement += " and ";
                }

                if (ownerTextBox.Text != "")
                {
                    owner = ownerTextBox.Text;
                    SqlStatement += " RealstateOwne.Owner = '" + owner + "'";
                    SqlStatement += " and ";
                }



                //if (roomsTextBox.Text != "")
                //{
                //    rooms = roomsTextBox.Text;
                //    SqlStatement += " RealstateOwne.Rooms = '" + rooms + "'";
                //    SqlStatement += " and ";
                //}


                if (phone_oneTextBox.Text != "")
                {
                    phoneone = phone_oneTextBox.Text;
                    SqlStatement += " RealstateOwne.Phone_one = '" + phoneone + "'";
                    SqlStatement += " and ";
                }

                if (phone_TwoTextBox.Text != "")
                {
                    phonetow = phone_TwoTextBox.Text;
                    SqlStatement += " RealstateOwne.Phone_Two = '" + phonetow + "'";
                    SqlStatement += " and ";
                }
                if (mobileTextBox.Text != "")
                {
                    mobile = mobileTextBox.Text;
                    SqlStatement += " RealstateOwne.Mobile = '" + mobile + "'";
                    SqlStatement += " and ";
                }

                if (mobileTextBox2.Text != "")
                {
                    mobile2 = mobileTextBox.Text;
                    SqlStatement += " RealstateOwne.Mobile2 = '" + mobile2 + "'";
                    SqlStatement += " and ";
                }

                if (otherTextBox.Text != "")
                {
                    othertext = otherTextBox.Text;
                    SqlStatement += " RealstateOwne.Other = '" + othertext + "'";
                    SqlStatement += " and ";
                }

                if (comboBox3.SelectedValue != null)
                {
                    eksa2 = Convert.ToInt32(comboBox3.SelectedValue.ToString());
                    SqlStatement += " RealstateOwne.investiture= " + eksa2;
                    SqlStatement += " and ";
                }



                if (keyCheckBox.Checked != null)
                {
                    key = keyCheckBox.Checked;
                    SqlStatement += " RealstateOwne.Key = " + key;
                    SqlStatement += " and ";

                }


                if (noteTextBox.Text != "")
                {
                    notetext = noteTextBox.Text;
                    SqlStatement += " RealstateOwne.Note= '" + notetext + "'";
                    SqlStatement += " and ";
                }

                if (info_SourceTextBox.Text != "")
                {
                    info = info_SourceTextBox.Text;
                    SqlStatement += " RealstateOwne.Info_Source = '" + info + "'";
                    SqlStatement += " and ";
                }

            }
            catch
            {
            }
            //////////////////////////////////////////////////////////////////////////////
            if (SqlStatement != "SELECT ID from RealstateOwne WHERE ")
            {
                SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and")) + "and id=" + Utils.realstateidowner;
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
            string SqlStatement = "SELECT ID from RealstateOwne WHERE ";

            if (subResgionIDTextBox.Text != "")
            {
                subregion = subResgionIDTextBox.Text;
                SqlStatement += " RealstateOwne.SubResgionID = '" + subregion + "'";
                SqlStatement += " and ";

            }

            if (buildingTextBox.Text != "")
            {
                building = buildingTextBox.Text;
                SqlStatement += " RealstateOwne.Building like '%" + building + "%'";
                SqlStatement += " and ";


            }
            if (floorTextBox.Text.ToString() != "")
            {
                floor = Convert.ToInt32(floorTextBox.Text);
                SqlStatement += " RealstateOwne.Floor = " + Convert.ToInt32(floor) + "";
                SqlStatement += " and ";

            }

            //////////////////////////////////////////////////////////////////////////////
            if (SqlStatement != "SELECT ID from RealstateOwne WHERE ")
            {
                //if (clicked == "clicked")
                //{
                //    SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and"));
                //}
                //else
                //{
                SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and")) + "and id=" + Utils.realstateidowner;
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
            string SqlStatement = "SELECT ID from RealstateOwne WHERE ";

            try
            {

                if (comboBox1.SelectedValue.ToString() != "")
                {
                    //  region = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                    SqlStatement += " RealstateOwne.Region_ID = '" + comboBox1.Text + "'";
                    SqlStatement += " and ";
                }

                if (subResgionIDTextBox.Text != "")
                {
                    subregion = subResgionIDTextBox.Text;
                    SqlStatement += " RealstateOwne.SubResgionID = '" + subregion + "'";
                    SqlStatement += " and ";

                }

                if (buildingTextBox.Text != "")
                {
                    building = buildingTextBox.Text;
                    SqlStatement += " RealstateOwne.Building like '%" + building + "%'";
                    SqlStatement += " and ";
                }



                if (am == "archive")
                {
                    SqlStatement += "   RealstateOwne.active=0";
                    SqlStatement += " and ";

                }
                else
                {
                    SqlStatement += "   RealstateOwne.active=1";
                    SqlStatement += " and ";
                }
            }
            catch
            {
            }

            //////////////////////////////////////////////////////////////////////////////
            if (SqlStatement != "SELECT ID from RealstateOwne WHERE ")
            {
                SqlStatement = SqlStatement.Substring(0, SqlStatement.LastIndexOf("and")) + " and id=" + Utils.realstateidowner;
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



        private void realStateBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (!formLoaded) return;  // ما تشغلش الكود قبل ما الفورم يخلص Load
            if (Published == null) return; // اتأكد إن الـ CheckBox موجود

            if (realStateBindingSource.Position >= 0 &&
                realStateBindingSource.Position < this.dsrealowner.RealstateOwne.Rows.Count)
            {
                var row = (DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position];

                // لو العمود published ممكن يكون Null
                Published.Checked = !row.IsNull("published") && row.published;
            }
            else
            {
                Published.Checked = false;
                Utils.realstateid = 0;
            }
            //            Utils.realstateidowner = Convert.ToInt32(((DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position]).ID);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.dsrealowner.RealstateOwne.Rows.Count >= realStateBindingSource.Count)
            {

                userTextBox.Text = Utils.current_user.ToString();
                eventTextBox.ReadOnly = false;
                eventTextBox.Focus();
                if (am == "archive")
                {
                    activeTextBox.Text = "0";
                    dateDateTimePicker.Value = DateTime.Now.AddDays(-2).AddMonths(-2).AddYears(-2);
                    dateDateTimePicker.Value = DateTime.Now;

                    dateOchangeEventDateTimePicker1.Value = DateTime.Now.Date.AddDays(-2).AddMonths(-2).AddYears(-2);
                    dateOchangeEventDateTimePicker1.Value = DateTime.Now.Date;
                    chechupdatestate = false;

                }
                else
                {
                    activeTextBox.Text = "1";
                    dateDateTimePicker.Value = DateTime.Now.AddDays(-2).AddMonths(-2).AddYears(-2);
                    dateDateTimePicker.Value = DateTime.Now;

                    dateOchangeEventDateTimePicker1.Value = DateTime.Now.Date.AddDays(-2).AddMonths(-2).AddYears(-2);
                    dateOchangeEventDateTimePicker1.Value = DateTime.Now.Date;
                    chechupdatestate = false;

                }

                dateOchangeEventDateTimePicker.Value = DateTime.Now;

            }
            else
            {
                realStateBindingNavigatorSaveItem.PerformClick();
                toolStripButton1.PerformClick();
                //MessageBox.Show("قم بالحفظ قبل");
            }
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (comboBox3.Text == "ضمن البناء" || comboBox3.Text == "ضمن الاكساء")
            {
                investitureRateComboBox.Enabled = true;
                saved.Visible = false;
            }
            else
            {
                investitureRateComboBox.Enabled = false;
                investitureRateComboBox.Text = "";
                saved.Visible = false;
            }
        }

        Boolean copycontinues = false;
        private void button2_Click(object sender, EventArgs e)
        {


            if ((comboBox3.Text != "ضمن البناء" && comboBox3.Text != "ضمن الاكساء") && areaTextBox.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && floorTextBox.Text != "")
            {
                if ((Utils.checkexist(subResgionIDTextBox.Text, buildingTextBox.Text, Convert.ToInt32(floorTextBox.Text), 0).Rows.Count <= 0) || copycontinues)
                {

                    int regiog = Utils.getRegionID(comboBox1.Text);
                    if (regiog > 0)
                    {
                        ToRentPrametr top = new ToRentPrametr(Utils.realstateidowner, regiog);
                        top.ShowDialog();
                        //ShowModalExcept(top, MainForm.searchForm);
                    }

                }
                else
                {

                    DSrealstatesearch.RealStateDataTable dt = (DSrealstatesearch.RealStateDataTable)Utils.checkexist(subResgionIDTextBox.Text, buildingTextBox.Text, Convert.ToInt32(floorTextBox.Text), 0);
                    Check.who = "rent";
                    string g = Check.ShowMe(dt);
                    if (g == "kml")
                    {
                        copycontinues = true;
                        button2.PerformClick();
                    }
                    if (g == "cancel")
                    {
                        copycontinues = false;
                        button2.Focus();
                    }


                }
            }
            else
            {

                MessageBox.Show(" لا يمكن النسخ الرجاء ملئ الحقول التالية : المنطقة - نوع البناء - الوضع الداخلي  - المساحة - الطابق - (أو العقار ضمن البناء او ضمن الاكساء) ");

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



        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            saved.Visible = false;


        }


        private void button5_Click_1(object sender, EventArgs e)
        {
            if (attachmentOwnDataGridView.RowCount > 0)
            {
                string path = attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
                string temp = path.Substring(0, 1);
                path = PublicFileName;
                if ((GetFileExisting(path)))
                {

                    string filePath = Utils.ProjectName + "\\OwAttach\\" + path;
                    Process.Start("rundll32.exe", $"shell32.dll,OpenAs_RunDLL {filePath}");


                    //if (temp != "T")
                    //{
                    //    OpenAs(Utils.ProjectName + "\\OwAttach\\" + path);
                    //}
                    //else
                    //{
                    //    int start = path.IndexOf(Utils.realstateidowner.ToString());
                    //    string ext = path.Substring(path.LastIndexOf("."));
                    //    string t = path.Substring(0, start);
                    //    OpenAs(Utils.ProjectName + "\\OwAttach\\" + path + ".lnk");

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

        private void mobileTextBox_TextChanged(object sender, EventArgs e)
        {
            if (phone_oneTextBox.Text.Length == Utils.PhoneNumerLength)
            {
                Gp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gp1.BackColor = System.Drawing.Color.Red;
                Gp1.ForeColor = System.Drawing.Color.Red;
            }

            if (phone_TwoTextBox.Text.Length == Utils.PhoneNumerLength)
            {
                Gp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gp2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gp2.BackColor = System.Drawing.Color.Red;
                Gp2.ForeColor = System.Drawing.Color.Red;
            }


            if (mobileTextBox.Text.Length == Utils.MobileNumerLength)
            {
                Gm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gm1.BackColor = System.Drawing.Color.Red;
                Gm1.ForeColor = System.Drawing.Color.Red;
            }

            if (mobileTextBox2.Text.Length == Utils.MobileNumerLength)
            {
                Gm2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                Gm2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            }
            else
            {
                Gm2.BackColor = System.Drawing.Color.Red;
                Gm2.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void eventTextBox_TextChanged(object sender, EventArgs e)
        {
            chechupdatestate = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Utils.mode != null)
            {
                if (phone_oneTextBox.Text.Length == Utils.PhoneNumerLength)
                {
                    double Num;
                    bool isNum = double.TryParse(phone_oneTextBox.Text, out Num);
                    if (isNum)
                    {
                        Utils.mode.Call(phone_oneTextBox.Text);
                        Redail.ShowMe();
                    }

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Utils.mode != null)
            {
                if (phone_TwoTextBox.Text.Length == Utils.PhoneNumerLength)
                {
                    double Num;
                    bool isNum = double.TryParse(phone_TwoTextBox.Text, out Num);
                    if (isNum)
                    {
                        Utils.mode.Call(phone_TwoTextBox.Text);
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
            string rawPhone = mobileTextBox.Text;


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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string rawPhone = otherTextBox.Text;

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

        private void roomsLabel_Click(object sender, EventArgs e)
        {

        }

        private void roomsTextBox_TextChanged(object sender, EventArgs e)
        {

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
            if (attachmentOwnDataGridView.Rows.Count == 0)
                downloadFile_toolStrip.Enabled = false;
            else
                downloadFile_toolStrip.Enabled = true;
        }

        //private void downloadFile_toolStrip_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string fileName = attachmentOwnDataGridView.CurrentCell.OwningRow.Cells[2].Value.ToString();
        //        if (!string.IsNullOrEmpty(fileName) && attachmentOwnDataGridView.Rows.Count != 0)
        //            CustomPath.DownloadFile(fileName, "OwAttach");
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

                // تحديد السجل الحالي
                var roww = (DSrealowner.RealstateOwneRow)this.dsrealowner.RealstateOwne.Rows[realStateBindingSource.Position];
                Utils.realstateidowner = roww.ID;

                // 📂 إنشاء مجلد لتجميع الملفات
                string collectedFolder = Path.Combine(desktopPath, $"CollectedFiles_Owner_{Utils.realstateidowner}");
                if (!Directory.Exists(collectedFolder))
                {
                    Directory.CreateDirectory(collectedFolder);
                }

                foreach (DataGridViewRow row in attachmentOwnDataGridView.SelectedRows)
                {
                    string fileName = row.Cells[2].Value?.ToString();

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        CustomPath.DownloadFileToFolderOwn(fileName, collectedFolder, Utils.realstateidowner);
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string rawPhone = mobileTextBox2.Text;


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

            //Timer timer = new System.Threading.Timer();
            //timer.Interval = 5000; // 3 ثواني
            //timer.Tick += (s, e) =>
            //{
            //    this.Controls.Remove(lbl);
            //    timer.Stop();
            //    timer.Dispose();
            //};
            //timer.Start();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000; // 5 seconds
            timer.Tick += (s, e) =>
            {
                this.Controls.Remove(lbl);
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        #endregion

        private void otherRecordsBtn_Click(object sender, EventArgs e)
        {
            f.ShowDialog();
            //ShowRelatedRecords();
        }


        //#region Publishing Code
        //private async void PublishRecord()
        //{
        //    int Rs_ID = Utils.realstateidowner; // رقم الريسكورد
        //    string RsTypeSymbol = "ب";

        //    try
        //    {
        //        string apiUrl = GetPublishingApiUrl();
        //        if (string.IsNullOrEmpty(apiUrl))
        //        {
        //            MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): API URL not found.");
        //            return;
        //        }

        //        var attachments = clsAttachmentOwn.GetAttachmentsForRealState(Rs_ID)
        //                                      .Where(a => a.Visible == 1).ToList();
        //        var recordData = clsRealStateOwn.GetRecordDataForRealState(Rs_ID);

        //        using (var client = new HttpClient { Timeout = TimeSpan.FromHours(1) })
        //        using (var form = new MultipartFormDataContent())
        //        {
        //            void AddIfNotEmpty(string key, object value)
        //            {
        //                if (value == null) return;
        //                if (value is string str && string.IsNullOrWhiteSpace(str)) return;
        //                form.Add(new StringContent(value.ToString()), key);
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
        //            AddIfNotEmpty("last_event",
        //                recordData.LastEvent?.ToString("yyyy-MM-dd HH:mm:ss"));
        //            AddIfNotEmpty("active", recordData.Active);
        //            AddIfNotEmpty("Rs_type", "sell");
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
        //                       : Path.Combine(Utils.ProjectName, "OwAttach", att.FileName);
        //                }
        //                if (!System.IO.File.Exists(path))
        //                {
        //                    MessageBox.Show($"⚠ File not found for ID {Rs_ID} ({RsTypeSymbol}): {att.FileName}");
        //                    continue;
        //                }

        //                var stream = System.IO.File.OpenRead(path);
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
        //    int Rs_ID = currentId;// Utils.realstateidowner; // رقم الريسكورد
        //    string RsTypeSymbol = "ب";

        //    try
        //    {
        //        string apiUrl = GetPublishingApiUrl();
        //        if (string.IsNullOrEmpty(apiUrl))
        //        {
        //            MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): API URL not found.");
        //            return;
        //        }

        //        //var attachments = clsAttachmentOwn.GetAttachmentsForRealState(Rs_ID)
        //        //                              .Where(a => a.Visible == 1).ToList();
        //        var recordData = clsRealStateOwn.GetRecordDataForRealState(Rs_ID);

        //        using (var client = new HttpClient { Timeout = TimeSpan.FromHours(1) })
        //        using (var form = new MultipartFormDataContent())
        //        {
        //            void AddIfNotEmpty(string key, object value)
        //            {
        //                if (value == null) return;
        //                if (value is string str && string.IsNullOrWhiteSpace(str)) return;
        //                form.Add(new StringContent(value.ToString()), key);
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
        //            //AddIfNotEmpty("last_event",
        //            //    recordData.LastEvent?.ToString("yyyy-MM-dd HH:mm:ss"));
        //            AddIfNotEmpty("active", 0);
        //            //AddIfNotEmpty("Rs_type", "sell");
        //            AddIfNotEmpty("secret", "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il");
        //            form.Add(new StringContent("1"), "ddd");

        //            //foreach (var att in attachments)
        //            //{
        //            //    string path = att.Type == 2
        //            //        ? Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName)
        //            //        : Path.Combine(Utils.ProjectName, att.FileName);

        //            //    if (!System.IO.File.Exists(path))
        //            //    {
        //            //        MessageBox.Show($"⚠ File not found for ID {Rs_ID} ({RsTypeSymbol}): {att.FileName}");
        //            //        continue;
        //            //    }

        //            //    var stream = System.IO.File.OpenRead(path);
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
        //                    MessageBox.Show($"✅ Update Success for ID {Rs_ID} ({RsTypeSymbol})");
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
        //    return clsSettingsCalling.LoadSettings().publishing_sell;
        //}


        //#endregion


        //#region Publishing Code
        //// 🔁 Helper function for retry logic
        //private async Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> operation, int maxRetries = 10, int delayMs = 2000)
        //{
        //    for (int attempt = 1; attempt <= maxRetries; attempt++)
        //    {
        //        try
        //        {
        //            return await operation();
        //        }
        //        catch (HttpRequestException ex) // network error
        //        {
        //            Console.WriteLine($"⚠ Network error (Attempt {attempt}/{maxRetries}): {ex.Message}");
        //            if (attempt == maxRetries)
        //                throw;
        //        }
        //        catch (TaskCanceledException ex) // timeout
        //        {
        //            Console.WriteLine($"⚠ Timeout (Attempt {attempt}/{maxRetries}): {ex.Message}");
        //            if (attempt == maxRetries)
        //                throw;
        //        }

        //        // wait before retry
        //        await Task.Delay(delayMs);
        //    }

        //    throw new Exception("Unexpected error in ExecuteWithRetryAsync.");
        //}

        //private async void PublishRecord()
        //{
        //    int Rs_ID = Utils.realstateidowner; // رقم الريكورد
        //    string RsTypeSymbol = "ب";

        //    // 1- إرسال البيانات الأساسية بدون مرفقات
        //    bool dataSent = await PublishRecordDataAsync(Rs_ID);
        //    if (dataSent)
        //    {
        //        MessageBox.Show($"✅ Data published successfully for ID {Rs_ID} ({RsTypeSymbol})");

        //        // 2- إرسال المرفقات واحد واحد
        //        await PublishAttachmentsAsync(Rs_ID);
        //    }
        //}

        //private async Task<bool> PublishRecordDataAsync(int Rs_ID)
        //{
        //    string RsTypeSymbol = "ب";
        //    try
        //    {
        //        string apiUrl = GetPublishingApiUrl();
        //        if (string.IsNullOrEmpty(apiUrl))
        //        {
        //            MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): API URL not found.");
        //            return false;
        //        }

        //        var recordData = clsRealStateOwn.GetRecordDataForRealState(Rs_ID);

        //        using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(5) })
        //        using (var form = new MultipartFormDataContent())
        //        {
        //            void AddIfNotEmpty(string key, object value)
        //            {
        //                if (value == null) return;
        //                if (value is string str && string.IsNullOrWhiteSpace(str)) return;
        //                form.Add(new StringContent(value.ToString()), key);
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
        //            AddIfNotEmpty("active", recordData.Active);
        //            AddIfNotEmpty("Rs_type", "sell");
        //            AddIfNotEmpty("secret", "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il");
        //            form.Add(new StringContent("1"), "ddd");

        //            HttpResponseMessage response = await ExecuteWithRetryAsync(
        //                () => client.PostAsync(apiUrl, form));

        //            string resp = await response.Content.ReadAsStringAsync();

        //            if (response.IsSuccessStatusCode)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                MessageBox.Show($"❌ Failed (Data) for ID {Rs_ID}: {(int)response.StatusCode} {response.StatusCode}\n{resp}");
        //                return false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"⚠ Error sending data for ID {Rs_ID}: {ex.Message}");
        //        return false;
        //    }
        //}

        //private async Task PublishAttachmentsAsync(int Rs_ID)
        //{
        //    string RsTypeSymbol = "ب";
        //    var attachments = clsAttachmentOwn.GetAttachmentsForRealState(Rs_ID)
        //                                      .Where(a => a.Visible == 1).ToList();

        //    string apiUrl = GetAttachmentApiUrl();
        //    if (string.IsNullOrEmpty(apiUrl))
        //    {
        //        MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Attachment API URL not found.");
        //        return;
        //    }

        //    using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(5) })
        //    {
        //        foreach (var att in attachments)
        //        {
        //            try
        //            {
        //                string path = (System.IO.File.Exists(Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName)))
        //                    ? Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName)
        //                    : Path.Combine(Utils.ProjectName, "OwAttach", att.FileName);

        //                if (!System.IO.File.Exists(path))
        //                {
        //                    MessageBox.Show($"⚠ File not found for ID {Rs_ID} ({RsTypeSymbol}): {att.FileName}");
        //                    continue;
        //                }

        //                using (var form = new MultipartFormDataContent())
        //                {
        //                    form.Add(new StringContent(Rs_ID.ToString()), "internal_id");
        //                    form.Add(new StringContent("sale"), "type");
        //                    form.Add(new StringContent("gfsh561r6hrtrty6eg3r1tger6tqweiukl1il"), "secret");

        //                    var stream = System.IO.File.OpenRead(path);
        //                    var streamContent = new StreamContent(stream);
        //                    streamContent.Headers.ContentType =
        //                        new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

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

        //private async void UpdateActiveAndPublish(int currentId)
        //{
        //    int Rs_ID = currentId;
        //    string RsTypeSymbol = "ب";

        //    try
        //    {
        //        string apiUrl = GetPublishingApiUrl();
        //        if (string.IsNullOrEmpty(apiUrl))
        //        {
        //            MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): API URL not found.");
        //            return;
        //        }

        //        var recordData = clsRealStateOwn.GetRecordDataForRealState(Rs_ID);

        //        using (var client = new HttpClient { Timeout = TimeSpan.FromHours(1) })
        //        using (var form = new MultipartFormDataContent())
        //        {
        //            void AddIfNotEmpty(string key, object value)
        //            {
        //                if (value == null) return;
        //                if (value is string str && string.IsNullOrWhiteSpace(str)) return;
        //                form.Add(new StringContent(value.ToString()), key);
        //            }

        //            AddIfNotEmpty("internal_id", Rs_ID);
        //            AddIfNotEmpty("region", recordData.Region);
        //            AddIfNotEmpty("active", 0);
        //            AddIfNotEmpty("secret", "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il");
        //            form.Add(new StringContent("1"), "ddd");

        //            HttpResponseMessage response = await ExecuteWithRetryAsync(
        //                () => client.PostAsync(apiUrl, form));

        //            string resp = await response.Content.ReadAsStringAsync();

        //            if (response.IsSuccessStatusCode)
        //            {
        //                MessageBox.Show($"✅ Update Success for ID {Rs_ID} ({RsTypeSymbol})");
        //            }
        //            else
        //            {
        //                MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): Server error {(int)response.StatusCode} {response.StatusCode}\n{resp}");
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
        //    return clsSettingsCalling.LoadSettings().publishing_sell;
        //}

        //private string GetAttachmentApiUrl()
        //{
        //    return clsSettingsCalling.LoadSettings().publishing_attachment;
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

                await Task.Delay(delayMs);
            }

            throw new Exception("Unexpected error in ExecuteWithRetryAsync.");
        }

        private async void PublishRecord()
        {
            int Rs_ID = Utils.realstateidowner; // رقم الريكورد
            string RsTypeSymbol = "ب";

            bool dataSent = await PublishRecordDataAsync(Rs_ID);
            if (dataSent)
            {
                MessageBox.Show($"✅ Data published successfully for ID {Rs_ID} ({RsTypeSymbol})");
                await PublishAttachmentsAsync(Rs_ID);
            }

            CheckWebsiteIdAndToggleButton(Rs_ID);
        }

        private async Task<bool> PublishRecordDataAsync(int Rs_ID)
        {
            string RsTypeSymbol = "ب";
            try
            {
                string apiUrl = GetPublishingApiUrl();
                if (string.IsNullOrEmpty(apiUrl))
                {
                    MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): API URL not found.");
                    return false;
                }

                var recordData = clsRealStateOwn.GetRecordDataForRealState(Rs_ID);

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

                    if (string.IsNullOrEmpty(recordData.Condition))
                        AddIfNotEmpty("condition_", recordData.investitureName + " " + recordData.investitureRate);
                    else
                        AddIfNotEmpty("condition_", recordData.Condition);

                    AddIfNotEmpty("ownership_", recordData.OwnerShip);
                    AddIfNotEmpty("notes", recordData.Notes);
                    AddIfNotEmpty("last_event", recordData.LastEvent?.ToString("yyyy-MM-dd HH:mm:ss"));
                    AddIfNotEmpty("active", recordData.Active);
                    AddIfNotEmpty("Rs_type", "sell");
                    AddIfNotEmpty("secret", "gfsh561r6hrtrty6eg3r1tger6tqweiukl1il");
                    form.Add(new StringContent("1"), "ddd");

                    HttpResponseMessage response = await ExecuteWithRetryAsync(
                        () => client.PostAsync(apiUrl, form));

                    string resp = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            var json = Newtonsoft.Json.Linq.JObject.Parse(resp);
                            var websiteId = json["website_id"]?.ToString();

                            if (!string.IsNullOrEmpty(websiteId))
                            {
                                setWebsiteId(websiteId, Rs_ID);
                                Console.WriteLine($"✅ Website ID {websiteId} stored for record {Rs_ID}");
                            }
                        }
                        catch (Exception parseEx)
                        {
                            Console.WriteLine($"⚠ Could not parse website_id: {parseEx.Message}");
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

        private async Task PublishAttachmentsAsync(int Rs_ID)
        {
            string RsTypeSymbol = "ب";
            var attachments = clsAttachmentOwn.GetAttachmentsForRealState(Rs_ID)
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

                async Task<bool> TryUploadAsync(string filePath, string fileName)
                {
                    try
                    {
                        Func<Task<HttpResponseMessage>> operation = async () =>
                        {
                            using (var form = new MultipartFormDataContent())
                            {
                                form.Add(new StringContent(Rs_ID.ToString()), "internal_id");
                                form.Add(new StringContent("sale"), "type");
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

                foreach (var att in attachments)
                {
                    string pathTemp = Path.Combine(Utils.ProjectName, "TempAttachment", att.FileName);
                    string pathMain = Path.Combine(Utils.ProjectName, "OwAttach", att.FileName);
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

                if (failedFiles.Any())
                {
                    summaryLogs.Add("🔄 Retrying failed files...");
                    var stillFailed = new List<string>();

                    foreach (var fileName in failedFiles)
                    {
                        string pathTemp = Path.Combine(Utils.ProjectName, "TempAttachment", fileName);
                        string pathMain = Path.Combine(Utils.ProjectName, "OwAttach", fileName);
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

        // Helper for Http retries
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

                    if (response.IsSuccessStatusCode)
                        return response;

                    int code = (int)response.StatusCode;

                    if (code == 429)
                    {
                        if (response.Headers.TryGetValues("Retry-After", out var values))
                        {
                            var ra = values.FirstOrDefault();
                            if (int.TryParse(ra, out int raSeconds))
                                await Task.Delay(TimeSpan.FromSeconds(raSeconds)).ConfigureAwait(false);
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
                            await Task.Delay(delayMs).ConfigureAwait(false);
                            delayMs = Math.Min(delayMs * 2, 30_000);
                        }

                        if (attempt >= maxRetries)
                            return response;

                        continue;
                    }

                    if (code >= 500 && attempt < maxRetries)
                    {
                        await Task.Delay(delayMs).ConfigureAwait(false);
                        delayMs = Math.Min(delayMs * 2, 30_000);
                        continue;
                    }

                    return response;
                }
                catch (HttpRequestException ex) when (attempt < maxRetries)
                {
                    Console.WriteLine($"HttpRequestException attempt {attempt}: {ex.Message}");
                    await Task.Delay(delayMs).ConfigureAwait(false);
                    delayMs = Math.Min(delayMs * 2, 30_000);
                    continue;
                }
                catch (TaskCanceledException ex) when (attempt < maxRetries)
                {
                    Console.WriteLine($"Timeout attempt {attempt}: {ex.Message}");
                    await Task.Delay(delayMs).ConfigureAwait(false);
                    delayMs = Math.Min(delayMs * 2, 30_000);
                    continue;
                }
                catch
                {
                    throw;
                }
            }
        }

        // Mime helper
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

        private string Truncate(string s, int maxLen)
        {
            if (s == null) return string.Empty;
            if (s.Length <= maxLen) return s;
            return s.Substring(0, maxLen) + "...";
        }


        //private async Task PublishAttachmentsAsync(int Rs_ID)
        //{
        //    string RsTypeSymbol = "ب";
        //    var attachments = clsAttachmentOwn.GetAttachmentsForRealState(Rs_ID)
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
        //                    : Path.Combine(Utils.ProjectName, "OwAttach", att.FileName);

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
        //                    form.Add(new StringContent("sale"), "type");
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

        //                     string resp = await response.Content.ReadAsStringAsync();

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

        private async void UpdateActiveAndPublish(int currentId)
        {
            int Rs_ID = currentId;
            string RsTypeSymbol = "ب";

            try
            {
                string apiUrl = GetPublishingApiUrl();
                if (string.IsNullOrEmpty(apiUrl))
                {
                    MessageBox.Show($"❌ Failed for ID {Rs_ID} ({RsTypeSymbol}): API URL not found.");
                    return;
                }

                var recordData = clsRealStateOwn.GetRecordDataForRealState(Rs_ID);

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
            return clsSettingsCalling.LoadSettings().publishing_sell;
        }

        private string GetAttachmentApiUrl()
        {
            return clsSettingsCalling.LoadSettings().publishing_attachment;
        }

        public static void setWebsiteId(string websiteId, int recordId)
        {
            clsRealStateOwn.setWebsiteId(websiteId, recordId);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Tag != null)
            {
                int websiteId = (int)button8.Tag;
                string main_website_address = clsSettingsCalling.get_main_website_address();

                string url = $"https://{main_website_address}/property/sale/{websiteId}";

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
            int websiteId = clsRealStateOwn.getWebsiteId(recordId);

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








        private void btnSlideshow_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. تحديد مسار الملف النصي
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // يكوّن المسار الكامل للملف جوه نفس فولدر exe
                string txtPath = Path.Combine(exeDirectory, "attachments.txt");
                //string txtPath = @"D:\Eng.Somer Rutub Project\SlideShow\MediaSlideshowAppV3\MediaSlideshowApp\MediaSlideshowApp\bin\Debug\net8.0-windows\attachmentOwns.txt";

                // 2. مسح أي محتوى قديم
                System.IO.File.WriteAllText(txtPath, string.Empty);

                // 3. جلب مرفقات السجل الحالي
                int realStateId = Utils.realstateidowner;
                List<clsAttachmentOwn> attachments = clsAttachmentOwn.GetAttachmentsForRealState(realStateId);

                foreach (clsAttachmentOwn att in attachments)
                {
                    if (System.IO.File.Exists(Utils.ProjectName + "\\TempAttachment\\" + att.FileName))
                    {
                        continue;
                    }

                    if (att.Type == 2) continue; // استبعاد المرفقات التلقائية
                    if (att.Visible == 0) continue;
                    // لو العمود Path في الجدول بيخزن المسار الكامل استخدمه مباشرة
                    string filePath = Utils.ProjectName + "\\OwAttach\\" + att.FileName;
                    //!string.IsNullOrEmpty(att.Path)
                    //                    ? att.Path
                    //                    : Path.Combine(Utils.ProjectName, att.FileName);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.AppendAllText(txtPath, filePath + Environment.NewLine);
                    }
                }

                // 4. تشغيل برنامج السلايد شو مع إعطائه ملف النص كـ Argument
                //string slideshowExe = @"D:\Eng.Somer Rutub Project\SlideShow\MediaSlideshowAppV3\MediaSlideshowApp\MediaSlideshowApp\bin\Debug\net8.0-windows\MediaSlideshowApp.exe";
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

   

        //private void ShowRelatedRecords()
        //{
        //    // Get current record ID
        //    int currentRecordId = Utils.realstateidowner;

        //    // Extract and normalize phone numbers
        //    List<string> phoneNumbers = PhoneNormalizer.ExtractNormalizedNumbers(this);

        //    // Find related records
        //    DataTable relatedRecords = RelatedRecordsService.FindRelatedRecords(phoneNumbers, "إيجار", currentRecordId);

        //    // Update button text
        //    otherRecordsBtn.Text = $"سجلات أخرى ({relatedRecords.Rows.Count})";

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
        //    int currentRecordId = Utils.realstateidowner;

        //    // Extract and normalize phone numbers
        //    List<string> phoneNumbers = PhoneNormalizer.ExtractNormalizedNumbers(this);

        //    // Find related records
        //    DataTable relatedRecords = RelatedRecordsService.FindRelatedRecords(  phoneNumbers, "بيع", currentRecordId, "", "");



        //    // Update button text
        //    otherRecordsBtn.Text = $"سجلات أخرى ({relatedRecords.Rows.Count})";

        //    // Disable button if no records
        //    otherRecordsBtn.Enabled = relatedRecords.Rows.Count > 0 ? true : false;
        //}

        //private void PhoneTextChanged(object sender, EventArgs e)
        //{
        //    CheckRelatedRecords();
        //}

    }
}




