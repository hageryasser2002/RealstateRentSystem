using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace RealStateSystem_DataAccess
{
    public class clsSettingsCallingData
    {
        public class UserPhoneInfo 
        {
            public string UserName { get; set; }
            public string PhoneName { get; set; }
            public bool PhoneRestriction { get; set; }
        } 
        public static void SaveOrUpdateSettings(string exportLink, string importLink, int interval)
        {
            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Setting WHERE ID = 1";

                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                {
                    object result = checkCmd.ExecuteScalar();
                    int count = 0;

                    if (result != null && result != DBNull.Value)
                        count = Convert.ToInt32(result);

                    if (count > 0)
                    {
                        string updateQuery = "UPDATE Setting SET Export_Calling_Link = ?, Import_Caller_ID_Link = ?, Interval_caller_id = ? WHERE ID = 1";
                        using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("?", exportLink);
                            updateCmd.Parameters.AddWithValue("?", importLink);
                            updateCmd.Parameters.AddWithValue("?", interval);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO Setting (ID, Export_Calling_Link, Import_Caller_ID_Link, Interval_caller_id) VALUES (1, ?, ?, ?)";
                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("?", exportLink);
                            insertCmd.Parameters.AddWithValue("?", importLink);
                            insertCmd.Parameters.AddWithValue("?", interval);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public static (string ExportLink, string ImportLink, int Interval, string publishingRent, string publishingSell, string publishing_attachment) GetSettings()
        {
            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT Export_Calling_Link, Import_Caller_ID_Link, Interval_caller_id, publishing_rent, publishing_sell, publishing_attachments FROM Setting WHERE ID = 1";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (
                            reader["Export_Calling_Link"].ToString(),
                            reader["Import_Caller_ID_Link"].ToString(),
                            Convert.ToInt32(reader["Interval_caller_id"]),
                            reader["publishing_rent"].ToString(),
                            reader["publishing_sell"].ToString(),
                            reader["publishing_attachments"].ToString()


                        );
                    }
                }
            }

            return (string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty);
        }
        public static UserPhoneInfo GetUserByName(string userName)
        {
            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT User_Name, PhoneName, Phone_restricted FROM Users WHERE User_Name = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", userName);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserPhoneInfo
                            {
                                UserName = reader["User_Name"].ToString(),
                                PhoneName = reader["PhoneName"].ToString(),
                                PhoneRestriction = Convert.ToBoolean(reader["Phone_restricted"])
                            };
                        }
                    }
                }
            }
            return null;
        }
        public static List<UserPhoneInfo> GetAllUsers()
        {
            var list = new List<UserPhoneInfo>();
            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT User_Name, PhoneName, Phone_restricted FROM Users";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserPhoneInfo
                        {
                            UserName = reader["User_Name"].ToString(),
                            PhoneName = reader["PhoneName"].ToString(),
                            PhoneRestriction = Convert.ToBoolean(reader["Phone_restricted"])
                        });
                    }
                }
            }
            return list;
        }


        public static string get_main_website_address()
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT main_website_address FROM Setting";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("⚠ Error getting website_id: " + ex.Message);
                        return null;
                    }
                }
            }
            return null;
        }


    }
}
