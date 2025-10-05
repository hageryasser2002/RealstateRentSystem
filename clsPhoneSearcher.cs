using RealStateSystem_DataAccess;
using System.Data.OleDb;

namespace RealStateRentSystem_Buisness
{
    public class clsPhoneSearcher
    {
        public static string SearchByNumber(string phoneNumber)
        {
            using (OleDbConnection conn = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                conn.Open();
                string[] tables = { "بيع", "أجار", "أرشيف", "هاتف" };
                foreach (var table in tables)
                {
                    string query = $"SELECT TOP 1 Name, Place FROM {table} WHERE Phone = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", phoneNumber);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return $"{reader["Name"]} - {reader["Place"]}";
                            }
                        }
                    }
                }
            }
            return "غير موجود في النظام";
        }
    }
}
