using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateSystem_DataAccess
{
    public class clsRegionData
    {
        public static long? GetRegionIDByName(string regionName)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT ID FROM Region WHERE Name = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", regionName.Trim());

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    return Convert.ToInt64(result);
                else
                    return null;
            }
        }


        public static string GetRegionNameByID(int regionID)
        {
            if (regionID <= 0)
                return null;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
                {
                    const string query = "SELECT Name FROM Region WHERE ID = @ID";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // استخدام النوع الصحيح الذي يتوافق مع قاعدة البيانات
                        command.Parameters.Add("@ID", OleDbType.Integer).Value = regionID;

                        connection.Open();

                        var result = command.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // تسجيل الخطأ للتصحيح
                System.Diagnostics.Debug.WriteLine($"Error in GetRegionNameByID: {ex.Message}");
                return null;
            }
        }

        //public static string GetRegionNameByID(long regionID)
        //{
        //    using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
        //    {
        //        string query = "SELECT Name FROM Region WHERE ID = ?";
        //        OleDbCommand command = new OleDbCommand(query, connection);
        //        command.Parameters.AddWithValue("?", regionID);

        //        connection.Open();
        //        object result = command.ExecuteScalar();

        //        if (result != null && result != DBNull.Value)
        //            return result.ToString();
        //        else
        //            return null;
        //    }
        //}

    }
}
