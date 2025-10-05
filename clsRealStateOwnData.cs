using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateSystem_DataAccess
{
    public class clsRealStateOwnData
    {

        public static DataTable GetLightweightRealStateOwns()
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand(
                    "SELECT ID, Region_ID, SubResgionID, Building FROM RealStateOwne",
                    connection))
                {
                    DataTable dt = new DataTable();
                    connection.Open();
                    dt.Load(command.ExecuteReader());
                    return dt;
                }
            }
        }

        public static bool SetRealStateOwnInactive(int ID)
        {
            bool isSuccess = false;

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE RealStateOwne SET active = 0 WHERE ID = ?";
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


        public static DataTable GetAllRealStateOwns()
        {
            DataTable dt = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM RealStateOwne ORDER BY ID";
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


        public static string GetFloorCommentById(string id)
        {
            string comment = "";
            string query = "SELECT FloorComment FROM RealStateOwne WHERE ID = @ID";

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




        public static void GetRecordDataForRealState(
           long ID,
           ref string region, ref string street, ref string floor,
           ref string direction, ref string investitureRate, ref string investitureName,
           ref string building_type,
           ref long rooms, ref double price, ref string ownerShip_,
           ref string notes, ref string condition_,
           ref long area, ref long active, ref DateTime? last_event)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM RealStateOwne WHERE ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.Add("?", OleDbType.Integer).Value = (int)ID;

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        region = reader["Region_ID"] != DBNull.Value
                            ? reader["Region_ID"].ToString()
                            : "";

                        street = reader["SubResgionID"] != DBNull.Value
                            ? reader["SubResgionID"].ToString()
                            : "";

                        floor = (reader["Floor"] != DBNull.Value ? reader["Floor"].ToString() : "")
                              + " " + (reader["FloorComment"] != DBNull.Value ? reader["FloorComment"].ToString() : "");

                        direction = reader["Distance"] != DBNull.Value
                            ? reader["Distance"].ToString()
                            : "";

                        investitureRate = reader["investitureRate"] != DBNull.Value
                            ? reader["investitureRate"].ToString()
                            : "";

                        investitureName = reader["investiture"] != DBNull.Value
                            ? GetInvestratorOwnNameByID(Convert.ToInt32(reader["investiture"]))
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

                        ownerShip_ = reader["WayOFOwner"] != DBNull.Value
                             ? reader["WayOFOwner"].ToString()
                             : "";

                        notes = reader["Note"] != DBNull.Value
                            ? reader["Note"].ToString()
                            : "";

                        // ✅ هنا التاريخ من غير وقت
                        last_event = reader["DateOchangeEvent"] != DBNull.Value
                            ? (DateTime?)Convert.ToDateTime(reader["DateOchangeEvent"]).Date
                            : (DateTime?)null;


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
        public static string GetInvestratorOwnNameByID(int investratorId)
        {
            if (investratorId <= 0)
                return null;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
                {
                    const string query = "SELECT Investiture_Name FROM OwnInvestiture WHERE ID = @ID";

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

        public static bool GetPublishedValuetoRealstate(long realstateId)
        {
            using (OleDbConnection con = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Published FROM RealStateOwne WHERE ID = ?";

                OleDbCommand cmd = new OleDbCommand(query, con);
                // ✅ ID يترسل Integer (Long في Access = 32-bit)
                cmd.Parameters.Add("?", OleDbType.Integer).Value = (int)realstateId;


                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Published عمود Yes/No بيرجع 0 أو -1 (أحيانًا في Access)
                        return Convert.ToBoolean(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error getting Published: " + ex.Message);
                }
            }
            return false; // لو مفيش قيمة، رجّع false
        }

        public static void MarkAsPublished(long realstateId, bool published)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "UPDATE RealStateOwne SET published = ? WHERE ID = ?";
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


        public static void setWebsiteId(string websiteId, int recordId)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                const string query = "UPDATE RealstateOwne SET website_id = ? WHERE ID = ?";

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
                string query = "SELECT website_id FROM RealstateOwne WHERE ID = ?";

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
