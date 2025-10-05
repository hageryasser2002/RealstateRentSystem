using RealStateRentSystem.DSTables;
using RealStateRentSystem_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealStateRentSystem
{
    public partial class ownerSetting : Form
    {

        public bool IsOwner { get; set; }
        public ownerSetting()
        {
            InitializeComponent();
        }

        private void ownerSetting_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSrealowner.OwnSetting' table. You can move, or remove it, as needed.
            if (IsOwner == true)
            {
                this.ownSettingTableAdapter.FillBy(this.dSrealowner.OwnSetting, 1);
            }
            else {
                this.Text = "اعدادات العقارات المهملة";
                this.ownSettingTableAdapter.FillBy(this.dSrealowner.OwnSetting, 2);
            }

        }

        private void ownSettingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.ownSettingBindingSource.EndEdit();

            if (string.IsNullOrEmpty(enterPeriodToStaicTextBox.Text)) enterPeriodToStaicTextBox.Text = "0";
            if (string.IsNullOrEmpty(enterPeriodToHousesTextBox.Text)) enterPeriodToHousesTextBox.Text = "0";
            if (string.IsNullOrEmpty(enterPeriodToEventsTextBox.Text)) enterPeriodToEventsTextBox.Text = "0";

            int enterPeriodToStaic = Convert.ToInt32(enterPeriodToStaicTextBox.Text);
            int enterPeriodToHouses = Convert.ToInt32(enterPeriodToHousesTextBox.Text);
            int enterPeriodToEvents = Convert.ToInt32(enterPeriodToEventsTextBox.Text);

            int FindId =0;
            if (IsOwner == true)
            {
                FindId = (int)this.ownSettingTableAdapter.ScalarQuery(1);
                if (FindId == 1)
                    this.ownSettingTableAdapter.UpdateQuery(enterPeriodToStaic,
                        enterPeriodToHouses, enterPeriodToEvents, 1);
                else
                    this.ownSettingTableAdapter.InsertQuery(enterPeriodToStaic,
                       enterPeriodToHouses, enterPeriodToEvents,1);

                Utils.EnterPeriodToStaic = enterPeriodToStaic;
                Utils.EnterPeriodOwnerToHouses = enterPeriodToHouses;
                Utils.EnterPeriodOwnerToEvents = enterPeriodToEvents;
            }
            else {
                FindId = (int)this.ownSettingTableAdapter.ScalarQuery(2);
                if (FindId == 1)
                    this.ownSettingTableAdapter.UpdateQuery(enterPeriodToStaic,
                        enterPeriodToHouses, enterPeriodToEvents, 2);
                else
                    this.ownSettingTableAdapter.InsertQuery(enterPeriodToStaic,
                       enterPeriodToHouses, enterPeriodToEvents,2);

                Utils.EnterPeriodRentToHouses = enterPeriodToHouses;
                Utils.EnterPeriodRentToEvents = enterPeriodToEvents;
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

            if ((keyData & Keys.Alt) == Keys.Alt)
                return true;
            else
                return base.ProcessDialogKey(keyData);

        }


        /// <summary>
        /// First Task (Button Attachment)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //////////////////////First Step//////////////////////
            ///Delete temporary Files from attachment and own attachment folders
            string basePath = Utils.ProjectName;

            // Realstate
            DataTable realStates = clsRealState.GetAllRealStates();
            foreach (DataRow realState in realStates.Rows)
            {
                long realStateID = Convert.ToInt64(realState["ID"]);
                var attachments = clsAttachment.GetAttachmentsForRealState(realStateID);

                for (int i = attachments.Count - 1; i >= 0; i--)
                {
                    var attachment = attachments[i];

                    if (!string.IsNullOrEmpty(attachment.Comment) &&
                        (attachment.Comment.Contains("ارفاق آلي") || attachment.Comment.Contains("ارفاق الي") || attachment.Comment.Contains("صورة كراج البناء")))
                    {
                        string fileName = attachment.FileName;

                        if (!string.IsNullOrWhiteSpace(fileName) && !fileName.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase))
                            fileName += ".lnk";

                        string fullPath = Path.Combine(basePath, fileName);

                        if (File.Exists(fullPath))
                        {
                            try
                            {
                                File.Delete(fullPath);
                                Console.WriteLine("File deleted: " + fullPath);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error deleting file: " + ex.Message);
                            }
                        }

                        attachment.Delete();
                    }
                }
            }

            // RealsateOwne
            DataTable realStatesOwns = clsRealStateOwn.GetAllRealStateOwns();
            foreach (DataRow realStateOwn in realStatesOwns.Rows)
            {
                long realStateOwnID = Convert.ToInt64(realStateOwn["ID"]);
                var ownAttachments = clsAttachmentOwn.GetOwnAttachmentsForRealState(realStateOwnID);

                for (int i = ownAttachments.Count - 1; i >= 0; i--)
                {
                    var OwnAttachment = ownAttachments[i];

                    if (!string.IsNullOrEmpty(OwnAttachment.Comment) &&
                        (OwnAttachment.Comment.Contains("ارفاق آلي") || OwnAttachment.Comment.Contains("ارفاق الي") || OwnAttachment.Comment.Contains("صورة كراج البناء")))
                    {
                        string fileName = OwnAttachment.FileName;

                        if (!string.IsNullOrWhiteSpace(fileName) && !fileName.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase))
                            fileName += ".lnk";

                        string fullPath = Path.Combine(basePath, "OwAttach", fileName);

                        if (File.Exists(fullPath))
                        {
                            try
                            {
                                File.Delete(fullPath);
                                Console.WriteLine("File deleted: " + fullPath);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error deleting file: " + ex.Message);
                            }
                        }

                        OwnAttachment.Delete();
                    }
                }
            }

            //////////////////////Second Step//////////////////////

            List<clsTempAttachment> tempAttachments = clsTempAttachment.GetAllTempAttachments();
            foreach (var tempAttachment in tempAttachments)
            {
                string regionName = tempAttachment.Region?.Trim();
                string subRegion = tempAttachment.SubRegion?.Trim();
                string building = tempAttachment.Building?.Trim();

               // Console.WriteLine($"Processing attachment: {tempAttachment.FileName}, Region: {regionName}, SubRegion: {subRegion}, Building: {building}");

                if (string.IsNullOrEmpty(regionName) || string.IsNullOrEmpty(subRegion) || string.IsNullOrEmpty(building))
                {
                    //Console.WriteLine("Skipping due to missing region/subregion/building.");
                    continue;
                }

                long? regionID = clsRegion.GetRegionIDByName(regionName);
                if (regionID == null)
                {
                    //Console.WriteLine($"Region not found: {regionName}");
                    continue;
                }

                // Realstate
                var matchingRealStates = realStates.Rows
                        .Cast<DataRow>()
                        .Where(rs =>
                            rs["Region_ID"] != DBNull.Value &&
                            Convert.ToInt64(rs["Region_ID"]) == regionID &&
                            rs["SubResgionID"].ToString().Trim() == subRegion &&
                            rs["Building"].ToString().Trim() == building)
                        .ToList();

                if (!matchingRealStates.Any())
                {
                    //Console.WriteLine($"No matching real state found for: RegionID={regionID}, SubRegion={subRegion}, Building={building}");
                    continue;
                }

                foreach (var Row in matchingRealStates)
                {
                    long realStateID = Convert.ToInt64(Row["ID"]);
                    string fileName = tempAttachment.FileName;
                    string comment = tempAttachment.Comment;
                    string path = Path.Combine(basePath, "TempAttachment", fileName);

                    clsAttachment newAttach = new clsAttachment()
                    {
                        RealStateID = realStateID,
                        FileName = fileName,
                        Path = path,
                        Comment = comment,
                        Type = 2,
                        DateOFAttash = DateTime.Now
                    };

                    clsAttachment.AddAttachment(newAttach);
                   // Console.WriteLine($"Attachment added for RealStateID: {realStateID}, Insert success");
                }


                // RealstateOwn
                var matchingRealStateOwn = realStatesOwns.Rows
                    .Cast<DataRow>()
                    .Where(rs =>
                        rs["Region_ID"].ToString().Trim() == regionName &&
                        rs["SubResgionID"].ToString().Trim() == subRegion &&
                        rs["Building"].ToString().Trim() == building).ToList();

                if (!matchingRealStateOwn.Any())
                {
                    //Console.WriteLine($"No matching real state own found for: {regionName}, {subRegion}, {building}");
                    continue;
                }

                foreach (var ownRow in matchingRealStateOwn)
                {
                    long realStateOwnID = Convert.ToInt64(ownRow["ID"]);
                    string fileNameOwn = tempAttachment.FileName;
                    string commentOwn = tempAttachment.Comment;
                    string pathOwn = Path.Combine(basePath, "TempAttachment", fileNameOwn);

                    clsAttachmentOwn newAttachOwn = new clsAttachmentOwn()
                    {
                        RealStateOwnID = realStateOwnID,
                        FileName = fileNameOwn,
                        Path = pathOwn,
                        Comment = commentOwn,
                        Type = 2,
                        DateOFAttash = DateTime.Now
                    };

                    clsAttachmentOwn.AddAttachment(newAttachOwn);
                    //Console.WriteLine($"AttachmentOwn added for RealStateOwnID: {realStateOwnID}, Insert success");
                }
            }


            MessageBox.Show("تمت إضافة كل المرفقات الآلية بنجاح");

        }
    }
}
