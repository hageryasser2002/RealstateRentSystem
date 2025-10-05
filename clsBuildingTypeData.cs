using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateSystem_DataAccess
{

    public class clsBuildingTypeData
    {
        public static bool GetBuildingTypeInfoByID(long ID, ref string Building_Type)
        {
            bool isFound = false;

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM BuildingType WHERE ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", ID);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        Building_Type = reader["Building_Type"].ToString();
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

        public static string GetBuildingTypeInfoByID(long ID)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM BuildingType WHERE ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.Add("?", OleDbType.Integer).Value = (int)ID;

                try
                { 
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                       return reader["Building_Type"].ToString();
                    }

                    reader.Close();
                }
                catch
                {

                }
            }
            return null;
        }

        public static long AddNewBuildingType(string Building_Type)
        {
            long ID = 0;

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO BuildingType (Building_Type)
                                 VALUES (?);";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", Building_Type);

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

        public static bool UpdateBuildingType(long ID, string Building_Type)
        {
            int rowsAffected = 0;

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE BuildingType
                                 SET Building_Type = ?
                                 WHERE ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", Building_Type);
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

        public static DataTable GetAllBuildingTypes()
        {
            DataTable dt = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM BuildingType ORDER BY ID";
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

        public static bool DeleteBuildingType(long ID)
        {
            int rowsAffected = 0;

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM BuildingType WHERE ID = ?";
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

    }
}
