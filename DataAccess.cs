using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateRentSystem.Classes
{
    public class DataAccess
    {
        public List<string> GetBuilding()
        {
            List<string> Buildingngsuggestions = new List<string>();
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT Building FROM RealState ";
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            try
            {
                conn.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conn.Close();
                conn.Dispose();
                sda.Dispose();
                if (dt.Rows.Count > 0)
                {
                    for (int y = 0; y < dt.Rows.Count; y++)
                    {
                        Buildingngsuggestions.Add(dt.Rows[y]["Building"].ToString());
                    }
                }

            }
            catch (Exception)
            {
                throw;

            }

            int count = Buildingngsuggestions.Count;
            return Buildingngsuggestions;
        }
        public List<string> GetNames()
        {
            List<string> suggestions = new List<string>();
            string serverConnectionString = global::RealStateRentSystem.Properties.Settings.Default.db1ConnectionString;
            string SqlStatement = "SELECT owner FROM RealState ";
            OleDbConnection conn = new OleDbConnection(serverConnectionString);
            try
            {
                conn.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(SqlStatement, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conn.Close();
                conn.Dispose();
                sda.Dispose();
                if (dt.Rows.Count > 0)
                {
                    for (int y = 0; y < dt.Rows.Count; y++)
                    {
                        suggestions.Add(dt.Rows[y]["owner"].ToString());
                    }
                }


            }
            catch (Exception)
            {
                throw;
            }

            int count = suggestions.Count;
            return suggestions;

        }

    }
}
