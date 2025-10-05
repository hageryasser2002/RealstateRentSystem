using RealStateSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateRentSystem_Buisness
{
    public class clsAttachment
    {
        public long ID { get; set; }
        public long RealStateID { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public int Type { get; set; }
        public int Visible { get; set; }
        public string Comment { get; set; }
        public DateTime DateOFAttash { get; set; }
        public static List<string> GetExistingAttachmentKeys()
        {
            List<string> keys = new List<string>();
            DataTable dt = clsAttachmentData.GetAllAttachmentKeys();

            foreach (DataRow row in dt.Rows)
            {
                long id = Convert.ToInt64(row["RealState_ID"]);
                string comment = row["Comment"].ToString();
                keys.Add($"{id}_{comment}");
            }

            return keys;
        }

        public static void BulkAddAttachments(List<clsAttachment> attachments)
        {
            DataTable attachmentTable = new DataTable();
            attachmentTable.Columns.Add("RealState_ID", typeof(long));
            attachmentTable.Columns.Add("FileName", typeof(string));
            attachmentTable.Columns.Add("Path", typeof(string));
            attachmentTable.Columns.Add("Comment", typeof(string));
            attachmentTable.Columns.Add("Type", typeof(int));
            attachmentTable.Columns.Add("DateOFAttash", typeof(DateTime));

            foreach (var attachment in attachments)
            {
                attachmentTable.Rows.Add(
                    attachment.RealStateID,
                    attachment.FileName,
                    attachment.Path,
                    attachment.Comment,
                    attachment.Type,
                    attachment.DateOFAttash
                );
            }

            clsAttachmentData.BulkInsertAttachments(attachmentTable);
        }

        public static List<clsAttachment> GetAttachmentsForRealState(long RealStateID)
        {
            List<clsAttachment> attachments = new List<clsAttachment>();
            DataTable dt = clsAttachmentData.GetAttachmentsForRealState(RealStateID);

            foreach (DataRow row in dt.Rows)
            {
                clsAttachment attachment = new clsAttachment();

                attachment.ID = Convert.ToInt64(row["ID"]);
                attachment.RealStateID = Convert.ToInt64(row["RealState_ID"]);
                attachment.FileName = row["FileName"].ToString();
                attachment.Path = row["Path"].ToString();
                attachment.Comment = row["Comment"].ToString();
                attachment.Type = (attachment.Comment.Contains("إرفاق آلي") || attachment.Comment.Contains("إرفاق الي")
                                    || attachment.Comment.Contains("ارفاق آلي")
                                    || attachment.Comment.Contains("ارفاق الي")
                                    || attachment.Comment.Contains("صورة كراج البناء")) ? 2 : 1;
                attachment.Visible = Convert.ToInt32(row["Visible"]);


                attachments.Add(attachment);

            }

            return attachments;
        }

        public static bool Exists(long realStateID, string comment)
        {
            List<clsAttachment> attachments = GetAttachmentsForRealState(realStateID);

            return attachments.Any(att =>
                att.Comment.Trim().Equals(comment.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public void UpdateType()
        {
            clsAttachmentData.UpdateType(this.ID, this.Type);
        }

        public void Delete()
        {
            clsAttachmentData.DeleteAttachment(this.ID);
        }

        public static void AddAttachment(clsAttachment attachment)
        {
            clsAttachmentData.InsertAttachment(
                (int)attachment.RealStateID,
                attachment.FileName,
                attachment.Path,
                attachment.Comment,
                attachment.Type,
                attachment.DateOFAttash
            );
        }

        

    }
}
