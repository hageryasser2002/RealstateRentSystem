using RealStateSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateRentSystem_Buisness
{
    public class clsRealStateOwn
    {
        private int RealStateID;
        private int Region_ID;
        private string SubResgionID;
        private string Building;
        private int Floor;
        private string FloorComment;

        public long ID { set; get; }

        public static List<LightRealStateOwn> GetLightweightRealStateOwns()
        {
            List<LightRealStateOwn> lightOwns = new List<LightRealStateOwn>();
            DataTable dt = clsRealStateOwnData.GetLightweightRealStateOwns();

            foreach (DataRow row in dt.Rows)
            {
                lightOwns.Add(new LightRealStateOwn
                {
                    ID = Convert.ToInt64(row["ID"]),
                    RegionName = row["Region_ID"].ToString().Trim(),
                    SubRegion = row["SubResgionID"].ToString().Trim(),
                    Building = row["Building"].ToString().Trim()
                });
            }

            return lightOwns;
        }

        public class LightRealStateOwn
        {
            public long ID { get; set; }
            public string RegionName { get; set; }
            public string SubRegion { get; set; }
            public string Building { get; set; }
        }

        public static bool SetRealStateOwnInactive(int ID)
        {
            return clsRealStateOwnData.SetRealStateOwnInactive(ID);
        }

        public static string GetFloorCommentById(string id)
        {
            string comment = clsRealStateOwnData.GetFloorCommentById(id);

            return comment;
        }

     

        public static DataTable GetAllRealStateOwns()
        {
            return clsRealStateOwnData.GetAllRealStateOwns();
        }

        public class RealStateRecord
        {
            public string Region { get; set; }
            public string Street { get; set; }
            public string Floor { get; set; }
            public string Direction { get; set; }
            public string investitureName { get; set; }
            public string  investitureRate { get; set; }
            public string BuildingType { get; set; }
            public long Rooms { get; set; }
            public double Price { get; set; }
            public string OwnerShip { get; set; }
            public string Notes { get; set; }
            public string RentStatus { get; set; }
            public string Condition { get; set; }
            public long Area { get; set; }
            public long Active { get; set; }
            public DateTime? LastEvent { get; set; }
        }


        public static RealStateRecord GetRecordDataForRealState(long realStateID)
        {
            string region = "";
            string street = "";
            string floor = "";
            string direction = "";
            string investitureRate = "";
            string investitureName = "";
            string building_type = "";
            long rooms = 0;
            double price = 0;
            string ownerShip = "";
            string notes = "";
            string condition = "";
            long area = 0;
            long active = 0;
            DateTime? last_event = null;

            // ننده على DataAccess
            clsRealStateOwnData.GetRecordDataForRealState(realStateID,
                ref region, ref street, ref floor, ref direction, ref investitureRate,
                ref investitureName,
                ref building_type, ref rooms, ref price, ref ownerShip,
                ref notes, ref condition,
                ref area, ref active, ref last_event);

            // نرجع Object للـ UI
            return new RealStateRecord
            {
                Region = region,
                Street = street,
                Floor = floor,
                Direction = direction,
                investitureName = investitureName,
                investitureRate = investitureRate,
                BuildingType = building_type,
                Rooms = rooms,
                Price = price,
                OwnerShip = ownerShip,
                Notes = notes,
                Condition = condition,
                Area = area,
                Active = active,
                LastEvent = last_event.HasValue ? last_event.Value.Date : (DateTime?)null
            };
        }

        public static bool GetPublishedValuetoRealstate(long realStateID)
        {
            return clsRealStateOwnData.GetPublishedValuetoRealstate(realStateID);
        }

        public static void MarkAsPublished(long realStateID, bool published)
        {
            clsRealStateOwnData.MarkAsPublished(realStateID, published);
        }

        public static void setWebsiteId(string websiteId, int recordId)
        {
            clsRealStateOwnData.setWebsiteId(websiteId, recordId);
        }

        
        public static int getWebsiteId(int recordId)
        {
           return  clsRealStateOwnData.getWebsiteId(recordId);
        }


    }
}
