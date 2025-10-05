using RealStateSystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static RealStateSystem_DataAccess.clsRealStateData;

namespace RealStateRentSystem_Buisness
{
   
        public class clsRealState
        {
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode = enMode.AddNew;

            public long ID { set; get; }
            public long Region_ID { set; get; }
            public string SubResgionID { set; get; }
            public string Building { set; get; }
            public long Floor { set; get; }
            public string FloorComment { set; get; }
            public string Entrance { set; get; }
            public string Distance { set; get; }
            public long Building_Type_ID { set; get; }
            public string Owner { set; get; }
            public string Phone_one { set; get; }
            public string Phone_Two { set; get; }
            public string Mobile { set; get; }
            public string Other { set; get; }
            public DateTime? DateOfEnter { set; get; }
            public string UserID { set; get; }
            public long area { set; get; }
            public double Price { set; get; }
            public long investiture { set; get; }
            public long WayOfRent { set; get; }
            public bool Key { set; get; }
            public string Note { set; get; }
            public string Info_Source { set; get; }
            public long Status_ID { set; get; }
            public DateTime? StartRentDate { set; get; }
            public DateTime? EndRendDate { set; get; }
            public string Period { set; get; }
            public long RemainingDay { set; get; }
            public long active { set; get; }
            public DateTime? RDateOchange { set; get; }
            public DateTime? RDateOchangeEvent { set; get; }
            public long Rooms { set; get; }
            public string Mobile2 { set; get; }

        /// <summary>
        /// Added Code
        /// </summary>
            public string region { set; get; }
            public string street { set; get; }
            public string floor { set; get; }
            public string direction { set; get; }
            public string building_type { set; get; }
            public string rooms { set; get; }
            public string price { set; get; }
            public string ownerShip { set; get; }
            public string notes { set; get; }
            public string rent_status { set; get; }
            public string condition { set; get; }




        public clsRealState()
            {
                this.ID = 0;
                this.Region_ID = 0;
                this.SubResgionID = "";
                this.Building = "";
                this.Floor = 0;
                this.FloorComment = "";
                this.Entrance = "";
                this.Distance = "";
                this.Building_Type_ID = 0;
                this.Owner = "";
                this.Phone_one = "";
                this.Phone_Two = "";
                this.Mobile = "";
                this.Other = "";
                this.DateOfEnter = null;
                this.UserID = "";
                this.area = 0;
                this.Price = 0;
                this.investiture = 0;
                this.WayOfRent = 0;
                this.Key = false;
                this.Note = "";
                this.Info_Source = "";
                this.Status_ID = 0;
                this.StartRentDate = null;
                this.EndRendDate = null;
                this.Period = "";
                this.RemainingDay = 0;
                this.active = 0;
                this.RDateOchange = null;
                this.RDateOchangeEvent = null;
                this.Rooms = 0;
                this.Mobile2 = "";
                
                Mode = enMode.AddNew;
            }
        public static List<LightRealState> GetLightweightRealStates()
        {
            List<LightRealState> lightStates = new List<LightRealState>();
            DataTable dt = clsRealStateData.GetLightweightRealStates();

            foreach (DataRow row in dt.Rows)
            {
                lightStates.Add(new LightRealState
                {
                    ID = Convert.ToInt64(row["ID"]),
                    RegionID = row["Region_ID"] != DBNull.Value ? Convert.ToInt64(row["Region_ID"]) : (long?)null,
                    SubRegion = row["SubResgionID"].ToString().Trim(),
                    Building = row["Building"].ToString().Trim()
                });
            }

            return lightStates;
        }

        public class LightRealState
        {
            public long ID { get; set; }
            public long? RegionID { get; set; }
            public string SubRegion { get; set; }
            public string Building { get; set; }
        }

        private clsRealState(long id, long region_ID, string subResgionID, string building, long floor, string floorComment, string entrance, string distance, long building_Type_ID,
                string owner, string phone_one, string phone_Two, string mobile, string other, DateTime? dateOfEnter, string userID, long area, double price,
                long investiture, long wayOfRent, bool key, string note, string info_Source, long status_ID, DateTime? startRentDate, DateTime? endRendDate,
                string period, long remainingDay, long active, DateTime? rDateOchange, DateTime? rDateOchangeEvent, long rooms, string mobile2)
            {
                this.ID = id;
                this.Region_ID = region_ID;
                this.SubResgionID = subResgionID;
                this.Building = building;
                this.Floor = floor;
                this.FloorComment = floorComment;
                this.Entrance = entrance;
                this.Distance = distance;
                this.Building_Type_ID = building_Type_ID;
                this.Owner = owner;
                this.Phone_one = phone_one;
                this.Phone_Two = phone_Two;
                this.Mobile = mobile;
                this.Other = other;
                this.DateOfEnter = dateOfEnter;
                this.UserID = userID;
                this.area = area;
                this.Price = price;
                this.investiture = investiture;
                this.WayOfRent = wayOfRent;
                this.Key = key;
                this.Note = note;
                this.Info_Source = info_Source;
                this.Status_ID = status_ID;
                this.StartRentDate = startRentDate;
                this.EndRendDate = endRendDate;
                this.Period = period;
                this.RemainingDay = remainingDay;
                this.active = active;
                this.RDateOchange = rDateOchange;
                this.RDateOchangeEvent = rDateOchangeEvent;
                this.Rooms = rooms;
                this.Mobile2 = mobile2;

                Mode = enMode.Update;
            }


            public static string GetFloorCommentById(string id)
            {
                string comment = clsRealStateData.GetFloorCommentById(id);

                return comment;
            }

            private bool _AddNewRealState()
            {
                this.ID = clsRealStateData.AddNewRealState(this.Region_ID, this.SubResgionID, this.Building, this.Floor, this.FloorComment, this.Entrance, this.Distance, this.Building_Type_ID,
                    this.Owner, this.Phone_one, this.Phone_Two, this.Mobile, this.Other, this.DateOfEnter, this.UserID, this.area, this.Price, this.investiture, this.WayOfRent, this.Key, this.Note,
                    this.Info_Source, this.Status_ID, this.StartRentDate, this.EndRendDate, this.Period, this.RemainingDay, this.active, this.RDateOchange, this.RDateOchangeEvent, this.Rooms, this.Mobile2);
                return (this.ID != 0);
            }

            private bool _UpdateRealState()
            {
                return clsRealStateData.UpdateRealState(this.ID, this.Region_ID, this.SubResgionID, this.Building, this.Floor, this.FloorComment, this.Entrance, this.Distance, this.Building_Type_ID,
                    this.Owner, this.Phone_one, this.Phone_Two, this.Mobile, this.Other, this.DateOfEnter, this.UserID, this.area, this.Price, this.investiture, this.WayOfRent, this.Key, this.Note,
                    this.Info_Source, this.Status_ID, this.StartRentDate, this.EndRendDate, this.Period, this.RemainingDay, this.active, this.RDateOchange, this.RDateOchangeEvent, this.Rooms, this.Mobile2);
            }

            public static clsRealState Find(long id)
            {
                long region_ID = 0;
                string subResgionID = "";
                string building = "";
                long floor = 0;
                string floorComment = "";
                string entrance = "";
                string distance = "";
                long building_Type_ID = 0;
                string owner = "";
                string phone_one = "";
                string phone_Two = "";
                string mobile = "";
                string other = "";
                DateTime? dateOfEnter = null;
                string userID = "";
                long area = 0;
                double price = 0;
                long investiture = 0;
                long wayOfRent = 0;
                bool key = false;
                string note = "";
                string info_Source = "";
                long status_ID = 0;
                DateTime? startRentDate = null;
                DateTime? endRendDate = null;
                string period = "";
                long remainingDay = 0;
                long active = 0;
                DateTime? rDateOchange = null;
                DateTime? rDateOchangeEvent = null;
                long rooms = 0;
                string mobile2 = "";


                bool isFound = clsRealStateData.GetRealStateInfoByID(id, ref region_ID, ref subResgionID, ref building, ref floor, ref floorComment, ref entrance, ref distance, ref building_Type_ID,
                    ref owner, ref phone_one, ref phone_Two, ref mobile, ref other, ref dateOfEnter, ref userID, ref area, ref price, ref investiture, ref wayOfRent, ref key, ref note, ref info_Source, ref status_ID,
                    ref startRentDate, ref endRendDate, ref period, ref remainingDay, ref active, ref rDateOchange, ref rDateOchangeEvent, ref rooms, ref mobile2);

                if (isFound)
                    return new clsRealState(id, region_ID, subResgionID, building, floor, floorComment, entrance, distance, building_Type_ID, owner, phone_one, phone_Two, mobile, other, dateOfEnter, userID, area, price, investiture, wayOfRent, key, note, info_Source, status_ID, startRentDate, endRendDate, period, remainingDay, active, rDateOchange, rDateOchangeEvent, rooms, mobile2);
                else
                    return null;
            }

            public bool Save()
            {
                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewRealState())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        return false;

                    case enMode.Update:
                        return _UpdateRealState();
                }
                return false;
            }

            public static DataTable GetAllRealStates()
            {
                return clsRealStateData.GetAllRealStates();
            }

            public static bool DeleteRealState(long id)
            {
                return clsRealStateData.DeleteRealState(id);
            }
           
            public static bool SetRealStateInactive(int ID)
        {
            return clsRealStateData.SetRealStateInactive(ID);
        }

            public static bool CheckIfFileExistsForRealState(long realStateID, string fileName)
        {
            return clsRealStateData.CheckIfFileExistsForRealState(realStateID, fileName);
        }


        public static bool GetPublishedValuetoRealstate(long realStateID)
        {
            return clsRealStateData.GetPublishedValuetoRealstate(realStateID);
        }

        public static void MarkAsPublished(long realStateID, bool published)
        {
            clsRealStateData.MarkAsPublished(realStateID, published);
        }

        public static void setWebsiteId(string websiteId, int recordId)
        {
            clsRealStateData.setWebsiteId(websiteId, recordId);
        }

        public static int getWebsiteId(int recordId)
        {
            return clsRealStateData.getWebsiteId(recordId);
        }

        public class RealStateRecord
        {
            public string Region { get; set; }
            public string Street { get; set; }
            public string Floor { get; set; }
            public string Direction { get; set; }
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
            string building_type = "";
            long rooms = 0;
            double price = 0;
            string ownerShip = "";
            string notes = "";
            string rent_status = "";
            string condition = "";
            long area = 0;
            long active = 0;
            DateTime? last_event = null;

            // ننده على DataAccess
            clsRealStateData.GetRecordDataForRealState(realStateID,
                ref region, ref street, ref floor, ref direction,
                ref building_type, ref rooms, ref price, ref ownerShip,
                ref notes, ref rent_status, ref condition,
                ref area, ref active, ref last_event);

            // نرجع Object للـ UI
            return new RealStateRecord
            {
                Region = region,
                Street = street,
                Floor = floor,
                Direction = direction,
                BuildingType = building_type,
                Rooms = rooms,
                Price = price,
                OwnerShip = ownerShip,
                Notes = notes,
                RentStatus = rent_status,
                Condition = condition,
                Area = area,
                Active = active,
                LastEvent = last_event.HasValue ? last_event.Value.Date : (DateTime?)null
            };
        }


    }
}
