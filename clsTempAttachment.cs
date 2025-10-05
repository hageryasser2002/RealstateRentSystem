using RealStateSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateRentSystem_Buisness
{
    public class clsTempAttachment
    {
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public string Building { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Comment { get; set; }
        public long ID { get; set; }
        public DateTime DateOFAttash { get; set; }
        public int Type { get; set; }

      
        public static clsTempAttachment GetTempFileByName(string fileName)
        {
            DataRow row = clsTempAttachmentData.GetTempFileRowByName(fileName);

            if (row == null)
                return null;

            return new clsTempAttachment
            {
                ID = row["ID"] != DBNull.Value ? Convert.ToInt64(row["ID"]) : 0,
                FileName = row["FileName"] != DBNull.Value ? row["FileName"].ToString() : "",
                Region = row["Region"] != DBNull.Value ? row["Region"].ToString() : "",
                SubRegion = row["subregion"] != DBNull.Value ? row["subregion"].ToString() : "",
                Building = row["building"] != DBNull.Value ? row["building"].ToString() : "",
                Comment = row["comment"] != DBNull.Value ? row["comment"].ToString() : "",
                DateOFAttash = row["DateOFAttash"] != DBNull.Value ? Convert.ToDateTime(row["DateOFAttash"]) : DateTime.Now
                // Type = row["Type"] != DBNull.Value ? Convert.ToInt32(row["Type"]) : 0
            };

        }

        public static List<clsTempAttachment> GetAllTempAttachments()
        {
            List<clsTempAttachment> list = new List<clsTempAttachment>();
            DataTable dt = clsTempAttachmentData.GetAll();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new clsTempAttachment
                {
                    Region = row["Region"].ToString().Trim(),
                    SubRegion = row["subregion"].ToString().Trim(),
                    Building = row["building"].ToString().Trim(),
                    FileName = row["FileName"].ToString().Trim(),
                    Path = row["path"].ToString().Trim(),
                    Comment = row["comment"].ToString().Trim()
                });
            }

            return list;
        }

    }
}
