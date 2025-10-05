using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RealStateSystem_DataAccess
{
    public class clsRealStateData
    {

        public static DataTable GetLightweightRealStates()
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand(
                    "SELECT ID, Region_ID, SubResgionID, Building FROM RealState WHERE Region_ID IS NOT NULL",
                    connection))
                {
                    DataTable dt = new DataTable();
                    connection.Open();
                    dt.Load(command.ExecuteReader());
                    return dt;
                }
            }
        }

        public static bool GetRealStateInfoByID(long ID, ref long Region_ID, ref string SubResgionID, ref string Building, ref long Floor, ref string FloorComment, ref string Entrance, ref string Distance, ref long Building_Type_ID,
          ref string Owner, ref string Phone_one, ref string Phone_Two, ref string Mobile, ref string Other, ref DateTime? DateOfEnter, ref string UserID, ref long area, ref double Price, ref long investiture, ref long WayOfRent, ref bool Key, ref string Note, ref string Info_Source, ref long Status_ID,
          ref DateTime? StartRentDate, ref DateTime? EndRendDate, ref string Period, ref long RemainingDay, ref long active, ref DateTime? RDateOchange, ref DateTime? RDateOchangeEvent, ref long Rooms, ref string Mobile2)
        {
            bool isFound = false;

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM RealState WHERE ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", ID);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        Region_ID = Convert.ToInt64(reader["Region_ID"]);
                        SubResgionID = reader["SubResgionID"].ToString();
                        Building = reader["Building"].ToString();
                        Floor = Convert.ToInt64(reader["Floor"]);
                        FloorComment = reader["FloorComment"].ToString();
                        Entrance = reader["Entrance"].ToString();
                        Distance = reader["Distance"].ToString();
                        Building_Type_ID = Convert.ToInt64(reader["Building_Type_ID"]);
                        Owner = reader["Owner"].ToString();
                        Phone_one = reader["Phone_one"].ToString();
                        Phone_Two = reader["Phone_Two"].ToString();
                        Mobile = reader["Mobile"].ToString();
                        Other = reader["Other"].ToString();
                        DateOfEnter = reader["DateOfEnter"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["DateOfEnter"]) : null;
                        UserID = reader["UserID"].ToString();
                        area = Convert.ToInt64(reader["area"]);
                        Price = Convert.ToDouble(reader["Price"]);
                        investiture = Convert.ToInt64(reader["investiture"]);
                        WayOfRent = Convert.ToInt64(reader["WayOfRent"]);
                        Key = reader["Key"] != DBNull.Value ? Convert.ToBoolean(reader["Key"]) : false;
                        Note = reader["Note"].ToString();
                        Info_Source = reader["Info_Source"].ToString();
                        Status_ID = Convert.ToInt64(reader["Status_ID"]);
                        StartRentDate = reader["StartRentDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["StartRentDate"]) : null;
                        EndRendDate = reader["EndRendDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["EndRendDate"]) : null;
                        Period = reader["Period"].ToString();
                        RemainingDay = Convert.ToInt64(reader["RemainingDay"]);
                        active = Convert.ToInt64(reader["active"]);
                        RDateOchange = reader["RDateOchange"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["RDateOchange"]) : null;
                        RDateOchangeEvent = reader["RDateOchangeEvent"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["RDateOchangeEvent"]) : null;
                        Rooms = Convert.ToInt64(reader["Rooms"]);
                        Mobile2 = reader["Mobile2"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    isFound = false;
                }
            }
            return isFound;
        }

        public static long AddNewRealState(long Region_ID, string SubResgionID, string Building, long Floor, string FloorComment, string Entrance, string Distance, long Building_Type_ID,
            string Owner, string Phone_one, string Phone_Two, string Mobile, string Other, DateTime? DateOfEnter, string UserID, long area, double Price, long investiture, long WayOfRent, bool Key, string Note, string Info_Source, long Status_ID,
            DateTime? StartRentDate, DateTime? EndRendDate, string Period, long RemainingDay, long active, DateTime? RDateOchange, DateTime? RDateOchangeEvent, long Rooms, string Mobile2)
        {
            long ID = 0;

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO RealState (Region_ID, SubResgionID, Building, Floor, FloorComment, Entrance, Distance, Building_Type_ID,
                    Owner, Phone_one, Phone_Two, Mobile, Other, DateOfEnter, UserID, area, Price, investiture, WayOfRent, Key, Note, Info_Source, Status_ID,
                    StartRentDate, EndRendDate, Period, RemainingDay, active, RDateOchange, RDateOchangeEvent, Rooms, Mobile2)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("?", Region_ID);
                command.Parameters.AddWithValue("?", SubResgionID);
                command.Parameters.AddWithValue("?", Building);
                command.Parameters.AddWithValue("?", Floor);
                command.Parameters.AddWithValue("?", FloorComment);
                command.Parameters.AddWithValue("?", Entrance);
                command.Parameters.AddWithValue("?", Distance);
                command.Parameters.AddWithValue("?", Building_Type_ID);
                command.Parameters.AddWithValue("?", Owner);
                command.Parameters.AddWithValue("?", Phone_one);
                command.Parameters.AddWithValue("?", Phone_Two);
                command.Parameters.AddWithValue("?", Mobile);
                command.Parameters.AddWithValue("?", Other);
                command.Parameters.AddWithValue("?", DateOfEnter.HasValue ? (object)DateOfEnter.Value : DBNull.Value);
                command.Parameters.AddWithValue("?", UserID);
                command.Parameters.AddWithValue("?", area);
                command.Parameters.AddWithValue("?", Price);
                command.Parameters.AddWithValue("?", investiture);
                command.Parameters.AddWithValue("?", WayOfRent);
                command.Parameters.AddWithValue("?", Key);
                command.Parameters.AddWithValue("?", Note);
                command.Parameters.AddWithValue("?", Info_Source);
                command.Parameters.AddWithValue("?", Status_ID);
                command.Parameters.AddWithValue("?", StartRentDate.HasValue ? (object)StartRentDate.Value : DBNull.Value);
                command.Parameters.AddWithValue("?", EndRendDate.HasValue ? (object)EndRendDate.Value : DBNull.Value);
                command.Parameters.AddWithValue("?", Period);
                command.Parameters.AddWithValue("?", RemainingDay);
                command.Parameters.AddWithValue("?", active);
                command.Parameters.AddWithValue("?", RDateOchange.HasValue ? (object)RDateOchange.Value : DBNull.Value);
                command.Parameters.AddWithValue("?", RDateOchangeEvent.HasValue ? (object)RDateOchangeEvent.Value : DBNull.Value);
                command.Parameters.AddWithValue("?", Rooms);
                command.Parameters.AddWithValue("?", Mobile2);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    OleDbCommand cmdID = new OleDbCommand("SELECT @@IDENTITY", connection);
                    object result = cmdID.ExecuteScalar();
                    if (result != null)
                        ID = Convert.ToInt64(result);
                }
                catch (Exception ex)
                {
                    // Handle/log error
                }
            }
            return ID;
        }

        public static bool UpdateRealState(long ID, long Region_ID, string SubResgionID, string Building, long Floor, string FloorComment, string Entrance, string Distance, long Building_Type_ID,
            string Owner, string Phone_one, string Phone_Two, string Mobile, string Other, DateTime? DateOfEnter, string UserID, long area, double Price, long investiture, long WayOfRent, bool Key, string Note, string Info_Source, long Status_ID,
            DateTime? StartRentDate, DateTime? EndRendDate, string Period, long RemainingDay, long active, DateTime? RDateOchange, DateTime? RDateOchangeEvent, long Rooms, string Mobile2)
        {
            int rowsAffected = 0;

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE RealState SET
                    Region_ID = ?, SubResgionID = ?, Building = ?, Floor = ?, FloorComment = ?, Entrance = ?, Distance = ?, Building_Type_ID = ?,
                    Owner = ?, Phone_one = ?, Phone_Two = ?, Mobile = ?, Other = ?, DateOfEnter = ?, UserID = ?, area = ?, Price = ?, investiture = ?, WayOfRent = ?, Key = ?, Note = ?, Info_Source = ?, Status_ID = ?,
                    StartRentDate = ?, EndRendDate = ?, Period = ?, RemainingDay = ?, active = ?, RDateOchange = ?, RDateOchangeEvent = ?, Rooms = ?, Mobile2 = ?
                    WHERE ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("?", Region_ID);
                command.Parameters.AddWithValue("?", SubResgionID);
                command.Parameters.AddWithValue("?", Building);
                command.Parameters.AddWithValue("?", Floor);
                command.Parameters.AddWithValue("?", FloorComment);
                command.Parameters.AddWithValue("?", Entrance);
                command.Parameters.AddWithValue("?", Distance);
                command.Parameters.AddWithValue("?", Building_Type_ID);
                command.Parameters.AddWithValue("?", Owner);
                command.Parameters.AddWithValue("?", Phone_one);
                command.Parameters.AddWithValue("?", Phone_Two);
                command.Parameters.AddWithValue("?", Mobile);
                command.Parameters.AddWithValue("?", Other);
                command.Parameters.AddWithValue("?", DateOfEnter.HasValue ? (object)DateOfEnter.Value : DBNull.Value);
                command.Parameters.AddWithValue("?", UserID);
                command.Parameters.AddWithValue("?", area);
                command.Parameters.AddWithValue("?", Price);
                command.Parameters.AddWithValue("?", investiture);
                command.Parameters.AddWithValue("?", WayOfRent);
                command.Parameters.AddWithValue("?", Key);
                command.Parameters.AddWithValue("?", Note);
                command.Parameters.AddWithValue("?", Info_Source);
                command.Parameters.AddWithValue("?", Status_ID);
                command.Parameters.AddWithValue("?", StartRentDate.HasValue ? (object)StartRentDate.Value : DBNull.Value);
                command.Parameters.AddWithValue("?", EndRendDate.HasValue ? (object)EndRendDate.Value : DBNull.Value);
                command.Parameters.AddWithValue("?", Period);
                command.Parameters.AddWithValue("?", RemainingDay);
                command.Parameters.AddWithValue("?", active);
                command.Parameters.AddWithValue("?", RDateOchange.HasValue ? (object)RDateOchange.Value : DBNull.Value);
                command.Parameters.AddWithValue("?", RDateOchangeEvent.HasValue ? (object)RDateOchangeEvent.Value : DBNull.Value);
                command.Parameters.AddWithValue("?", Rooms);
                command.Parameters.AddWithValue("?", Mobile2);
                command.Parameters.AddWithValue("?", ID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle/log error
                }
            }
            return (rowsAffected > 0);
        }

        public static DataTable GetAllRealStates()
        {
            DataTable dt = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM RealState ORDER BY ID";
                OleDbCommand command = new OleDbCommand(query, connection);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle/log error
                }
            }
            return dt;
        }

        public static bool DeleteRealState(long ID)
        {
            int rowsAffected = 0;

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM RealState WHERE ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", ID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle/log error
                }
            }
            return (rowsAffected > 0);
        }

        public static bool SetRealStateInactive(int ID)
        {
            bool isSuccess = false;

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE RealState SET active = 0 WHERE ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", ID);

                try
                {
                    connection.Open();
                    int affectedRows = command.ExecuteNonQuery();
                    isSuccess = affectedRows > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("خطأ أثناء التنفيذ: " + ex.Message);
                    isSuccess = false;
                }
            }

            return isSuccess;
        }

        public static bool CheckIfFileExistsForRealState(long realStateID, string fileName)
        {
            string query = "SELECT COUNT(*) FROM Attachment WHERE RealState_ID = ? AND FileName = ?";

            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("?", realStateID);
                cmd.Parameters.AddWithValue("?", fileName);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }


        public static string GetFloorCommentById(string id)
        {
            string comment = "";
            string query = "SELECT FloorComment FROM RealState WHERE ID = @ID";

            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();

                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    comment = result.ToString();
            }

            return comment;
        }


        public static bool GetPublishedValuetoRealstate(long realstateId)
        {
            using (OleDbConnection con = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Published FROM RealState WHERE ID = ?";

                OleDbCommand cmd = new OleDbCommand(query, con);
                // ✅ استخدام النوع الصحيح لـ Access
                cmd.Parameters.Add("ID", OleDbType.Integer).Value = (int)realstateId;

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        return false;
                    }

                    // ✅ معالجة صحيحة لقيم Yes/No في Access
                    if (result is bool boolValue)
                    {
                        return boolValue;
                    }

                    if (result is int intValue)
                    {
                        // في Access، -1 = true، 0 = false
                        return intValue != 0;
                    }

                    if (result is short shortValue)
                    {
                        return shortValue != 0;
                    }

                    // ✅ محاولة التحويل الآمن
                    return Convert.ToBoolean(result);
                }
                catch (Exception ex)
                {
                    // ✅ تسجيل الخطأ بشكل أفضل
                    Console.WriteLine($"Error getting Published value for RealState ID {realstateId}: {ex.Message}");
                    // ✅ يمكنك إضافة logging هنا إذا كان متوفرًا
                    return false;
                }
            }
        }

        public static void MarkAsPublished(long realstateId, bool published)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE RealState SET published = ? WHERE ID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.Add("?", OleDbType.Boolean).Value = published;
                    // ✅ ID يترسل Integer (Long في Access = 32-bit)
                    cmd.Parameters.Add("?", OleDbType.Integer).Value = (int)realstateId;


                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error updating Published: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public class RealStateRecord
        {
            public long ID { get; set; }
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


        public static void GetRecordDataForRealState(
           long ID,
           ref string region, ref string street, ref string floor,
           ref string direction, ref string building_type,
           ref long rooms, ref double price, ref string ownerShip_,
           ref string notes, ref string rent_status, ref string condition_,
           ref long area, ref long active, ref DateTime? last_event)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM RealState WHERE ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.Add("?", OleDbType.Integer).Value = (int)ID;

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        region = reader["Region_ID"] != DBNull.Value
                            ? clsRegionData.GetRegionNameByID(Convert.ToInt32(reader["Region_ID"]))
                            : "";

                        street = reader["SubResgionID"] != DBNull.Value
                            ? reader["SubResgionID"].ToString()
                            : "";

                        floor = (reader["Floor"] != DBNull.Value ? reader["Floor"].ToString() : "")
                              + " " + (reader["FloorComment"] != DBNull.Value ? reader["FloorComment"].ToString() : "");

                        direction = reader["Distance"] != DBNull.Value
                            ? reader["Distance"].ToString()
                            : "";

                        building_type = reader["Building_Type_ID"] != DBNull.Value
                            ? clsBuildingTypeData.GetBuildingTypeInfoByID(Convert.ToInt64(reader["Building_Type_ID"]))
                            : "";

                        area = reader["area"] != DBNull.Value
                            ? Convert.ToInt64(reader["area"])
                            : 0;

                        rooms = reader["Rooms"] != DBNull.Value
                            ? Convert.ToInt64(reader["Rooms"])
                            : 0;

                        price = reader["Price"] != DBNull.Value
                            ? Convert.ToDouble(reader["Price"])
                            : 0.0;

                        condition_ = reader["investiture"] != DBNull.Value
                            ? GetInvestratorNameByID(Convert.ToInt32(reader["investiture"]))
                            : "";

                        ownerShip_ = reader["WayOfRent"] != DBNull.Value
                             ? GetWayNameByIDreader(Convert.ToInt32(reader["WayOfRent"]))
                             : "";

                        notes = reader["Note"] != DBNull.Value
                            ? reader["Note"].ToString()
                            : "";

                        // ✅ هنا التاريخ من غير وقت
                        last_event = reader["RDateOchangeEvent"] != DBNull.Value
                            ? (DateTime?)Convert.ToDateTime(reader["RDateOchangeEvent"]).Date
                            : (DateTime?)null;

                        rent_status = reader["Status_ID"] != DBNull.Value
                            ? GetStatueNameByID(Convert.ToInt32(reader["Status_ID"]))
                            : "";

                        active = reader["active"] != DBNull.Value
                            ? Convert.ToInt64(reader["active"])
                            : 0;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public static string GetStatueNameByID(int statusId)
        {
            if (statusId <= 0) return null;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT StatusName FROM StatusType WHERE ID = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("?", OleDbType.Integer).Value = statusId;
                        connection.Open();

                        var result = command.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in GetStatusNameByID: {ex.Message}");
                return null;
            }
        }


        public static string GetWayNameByIDreader(int wayId)
        {
            if (wayId <= 0) return null;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT WayOfRent FROM WayOfRent WHERE ID = ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("?", OleDbType.Integer).Value = wayId;
                        connection.Open();

                        var result = command.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in GetStatusNameByID: {ex.Message}");
                return null;
            }
        }


        public static string GetInvestratorNameByID(int investratorId)
        {
            if (investratorId <= 0)
                return null;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
                {
                    const string query = "SELECT Investiture_Name FROM Investiture WHERE ID = @ID";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // استخدام النوع الصحيح الذي يتوافق مع قاعدة البيانات
                        command.Parameters.Add("@ID", OleDbType.Integer).Value = investratorId;

                        connection.Open();

                        var result = command.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // تسجيل الخطأ للتصحيح
                System.Diagnostics.Debug.WriteLine($"Error in GetInvestratorNameByID: {ex.Message}");
                return null;
            }
        }

        public static void setWebsiteId(string websiteId, int recordId)
        {
             using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
                {
                    const string query = "UPDATE RealState SET website_id = ? WHERE ID = ?";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("?", OleDbType.VarChar).Value = websiteId;
                        command.Parameters.Add("?", OleDbType.Integer).Value = (int)recordId;

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error updating WebsiteId: " + ex.Message);
                            throw;
                        }
                    }
                }
            }

        public static int getWebsiteId(int recordId)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT website_id FROM Realstate WHERE ID = ?";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("?", OleDbType.Integer).Value = recordId;

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("⚠ Error getting website_id: " + ex.Message);
                        return 0;
                    }
                }
            }
            return 0;
        }

    }

}

