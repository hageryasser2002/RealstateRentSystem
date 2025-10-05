using RealStateSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RealStateRentSystem_Buisness
{
    public class clsAttachmentOwn
    {
        public long ID { get; set; }
        public long RealStateOwnID { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public int Type { get; set; }
        public string Comment { get; set; }
        public DateTime DateOFAttash { get; set; }
        public int Visible { get; set; }

        public static List<string> GetExistingAttachmentKeys()
        {
            List<string> keys = new List<string>();
            DataTable dt = clsAttachmentOwnData.GetAllAttachmentKeys();

            foreach (DataRow row in dt.Rows)
            {
                long id = Convert.ToInt64(row["RealState_ID"]);
                string comment = row["Comment"].ToString();
                keys.Add($"{id}_{comment}");
            }

            return keys;
        }

        public static void BulkAddAttachments(List<clsAttachmentOwn> attachments)
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
                    attachment.RealStateOwnID,
                    attachment.FileName,
                    attachment.Path,
                    attachment.Comment,
                    attachment.Type,
                    attachment.DateOFAttash
                );
            }

            clsAttachmentOwnData.BulkInsertAttachments(attachmentTable);
        }

        public static List<clsAttachmentOwn> GetOwnAttachmentsForRealState(long RealStateOWnID)
        {
            List<clsAttachmentOwn> OwnAttachments = new List<clsAttachmentOwn>();
            DataTable dt = clsAttachmentOwnData.GetOwnAttachmentsForRealState(RealStateOWnID);

            foreach (DataRow row in dt.Rows)
            {
                clsAttachmentOwn ownAttachment = new clsAttachmentOwn();

                ownAttachment.ID = Convert.ToInt64(row["ID"]);
                ownAttachment.RealStateOwnID = Convert.ToInt64(row["RealState_ID"]);
                ownAttachment.FileName = row["FileName"].ToString();
                ownAttachment.Path = row["Path"].ToString();
                ownAttachment.Comment = row["Comment"].ToString();
                ownAttachment.Type = (ownAttachment.Comment.Contains("إرفاق آلي") || ownAttachment.Comment.Contains("إرفاق الي")
                                    || ownAttachment.Comment.Contains("ارفاق آلي")
                                    || ownAttachment.Comment.Contains("صورة كراج البناء")) ? 2 : 1;


                OwnAttachments.Add(ownAttachment);

            }

            return OwnAttachments;
        }

        public static bool Exists(long realStateID, string comment)
        {
            List<clsAttachmentOwn> attachments = GetOwnAttachmentsForRealState(realStateID);

            return attachments.Any(att =>
                att.Comment.Trim().Equals(comment.Trim(), StringComparison.OrdinalIgnoreCase));
        }



        public void Delete()
        {
            clsAttachmentOwnData.DeleteOwnAttachment(this.ID);
        }

        public static void AddAttachment(clsAttachmentOwn attachment)
        {
            clsAttachmentOwnData.InsertAttachment(
                (int)attachment.RealStateOwnID,
                attachment.FileName,
                attachment.Path,
                attachment.Comment,
                attachment.Type,
                attachment.DateOFAttash
            );
        }

        public static List<clsAttachmentOwn> GetAttachmentsForRealState(long RealStateID)
        {
            List<clsAttachmentOwn> attachments = new List<clsAttachmentOwn>();
            DataTable dt = clsAttachmentOwnData.GetAttachmentsForRealState(RealStateID);

            foreach (DataRow row in dt.Rows)
            {
                clsAttachmentOwn attachment = new clsAttachmentOwn();

                attachment.ID = Convert.ToInt64(row["ID"]);
                attachment.RealStateOwnID = Convert.ToInt64(row["RealState_ID"]);
                attachment.FileName = row["FileName"].ToString();
                attachment.Path = row["Path"].ToString();
                attachment.Comment = row["Comment"].ToString();
                attachment.Type = (attachment.Comment.Contains("إرفاق آلي") || attachment.Comment.Contains("إرفاق الي")
                                    || attachment.Comment.Contains("ارفاق آلي")
                                    || attachment.Comment.Contains("صورة كراج البناء")) ? 2 : 1;
                attachment.Visible = Convert.ToInt32(row["Visible"]);


                attachments.Add(attachment);

            }

            return attachments;
        }


    }
}
