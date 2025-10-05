using System;
using System.Data.OleDb;

namespace RealStateSystem_DataAccess
{
    public class clsDeviceSettingsData
    {

        public static string  GetSlideShowPath(string addressOFDevice)
        {
            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT slideShow_path FROM PCinfo WHERE AddressOFDevice = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", addressOFDevice);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                }
            }
            return null; // default if not found
        }


        public static bool GetHasModem(string addressOFDevice)
        {
            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT HasModem FROM PCinfo WHERE AddressOFDevice = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", addressOFDevice);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToBoolean(result);
                    }
                }
            }
            return false; // default if not found
        }
        public static bool GetCanSaveCalls(string addressOFDevice)
        {
            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();
                string query = "SELECT CanSaveCalls FROM PCinfo WHERE AddressOFDevice = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", addressOFDevice);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToBoolean(result);
                    }
                }
            }
            return false; // default if not found
        }

        public static void SaveOrUpdateDevice(string macAddress, bool alert, bool backup, string addressOFDevice, bool canSaveCalls, bool hasModem)
        {
            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();

                // Check if exists
                string checkQuery = "SELECT COUNT(*) FROM PCinfo WHERE AddressOFDevice = ?";
                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("?", addressOFDevice);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Update
                        string updateQuery = "UPDATE PCinfo SET CanSaveCalls = ?, HasModem = ? WHERE AddressOFDevice = ?";
                        using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("?", canSaveCalls);
                            updateCmd.Parameters.AddWithValue("?", hasModem);
                            updateCmd.Parameters.AddWithValue("?", addressOFDevice);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Insert
                        string insertQuery = "INSERT INTO PCinfo (MacAddress, alert, backup, AddressOFDevice, CanSaveCalls, HasModem) VALUES (?, ?, ?, ?, ?, ?)";
                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("?", macAddress);
                            insertCmd.Parameters.AddWithValue("?", alert);
                            insertCmd.Parameters.AddWithValue("?", backup);
                            insertCmd.Parameters.AddWithValue("?", addressOFDevice);
                            insertCmd.Parameters.AddWithValue("?", canSaveCalls);
                            insertCmd.Parameters.AddWithValue("?", hasModem);


                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
