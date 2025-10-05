using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace RealStateSystem_DataAccess
{
    public static class clsUsersData
    {
        // 1. تسجيل الدخول وتحديث IsLoggedIn = 1
        public static DataRow LoginUser(string username, string password)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE User_Name = ? AND User_Password = ? AND Active = 1";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("?", username);
                cmd.Parameters.AddWithValue("?", password);

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    // إذا تم تسجيل الدخول بنجاح نحدّث IsLoggedIn = 1
                    //SetUserLoginStatus(username, true);
                    return dt.Rows[0];
                }

                return null;
            }
        }

        // 2. جلب كل المستخدمين النشطين
        public static List<DataRow> GetAllActiveUsers()
        {
            List<DataRow> users = new List<DataRow>();

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE Active = 1";
                OleDbCommand cmd = new OleDbCommand(query, connection);

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                    users.Add(row);

                return users;
            }
        }

        // 3. تحديث حالة مستخدم معين (تسجيل دخول/خروج)
        //public static void SetUserLoginStatus(string username, bool isLoggedIn)
        //{
        //    using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
        //    {
        //        string query = "UPDATE Users SET IsLoggedIn = ? WHERE User_Name = ?";
        //        OleDbCommand cmd = new OleDbCommand(query, connection);

        //        cmd.Parameters.AddWithValue("?", isLoggedIn ? 1 : 0);
        //        cmd.Parameters.AddWithValue("?", username);

        //        connection.Open();
        //        cmd.ExecuteNonQuery();
        //        connection.Close();
        //    }
        //}

        // 4. إعادة تعيين حالة كل المستخدمين عند تشغيل البرنامج
        //public static void ResetAllLoginStatus()
        //{
        //    using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
        //    {
        //        string query = "UPDATE Users SET IsLoggedIn = 0";
        //        OleDbCommand cmd = new OleDbCommand(query, connection);

        //        connection.Open();
        //        cmd.ExecuteNonQuery();
        //        connection.Close();
        //    }
        //}


        public static DataTable GetAdminUsers()
        {
            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE Active = 2";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }


    }
}
