using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateSystem_DataAccess
{
    public class clsAttachmentOwnData
    {
        public static DataTable GetAllAttachmentKeys()
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                using (OleDbCommand command = new OleDbCommand("SELECT RealState_ID, Comment FROM Attachments", connection))
                {
                    DataTable dt = new DataTable();
                    connection.Open();
                    dt.Load(command.ExecuteReader());
                    return dt;
                }
            }
        }

        public static void BulkInsertAttachments(DataTable attachments)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                connection.Open();
                using (OleDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (OleDbCommand command = new OleDbCommand())
                        {
                            command.Connection = connection;
                            command.Transaction = transaction;
                            command.CommandText = "INSERT INTO Attachments (RealState_ID, FileName, Path, Comment, Type, DateOFAttash) " +
                                                   "VALUES (@RealState_ID, @FileName, @Path, @Comment, @Type, @DateOFAttash)";

                            command.Parameters.Add("@RealState_ID", OleDbType.BigInt);
                            command.Parameters.Add("@FileName", OleDbType.VarChar);
                            command.Parameters.Add("@Path", OleDbType.VarChar);
                            command.Parameters.Add("@Comment", OleDbType.VarChar);
                            command.Parameters.Add("@Type", OleDbType.Integer);
                            command.Parameters.Add("@DateOFAttash", OleDbType.Date);

                            foreach (DataRow row in attachments.Rows)
                            {
                                command.Parameters["@RealState_ID"].Value = row["RealState_ID"];
                                command.Parameters["@FileName"].Value = row["FileName"];
                                command.Parameters["@Path"].Value = row["Path"];
                                command.Parameters["@Comment"].Value = row["Comment"];
                                command.Parameters["@Type"].Value = row["Type"];
                                command.Parameters["@DateOFAttash"].Value = row["DateOFAttash"];
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        public static DataTable GetOwnAttachmentsForRealState(long RealStateOwnID)
        {
            DataTable dt = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM attachmentOwn WHERE RealState_ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.Integer, Value = RealStateOwnID });


                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        dt.Load(reader);

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading attachments: " + ex.Message);
                }
            }

            return dt;
        }

        public static void DeleteOwnAttachment(long id)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM attachmentOwn WHERE ID = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", (int)id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void InsertAttachment(long realStateID, string fileName, string path, string comment, long type, DateTime dateOFAttash)
        {
            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "INSERT INTO attachmentOwn (RealState_ID, FileName, Path, DateOFAttash, Comment, typee) VALUES (?, ?, ?, ?, ?, ?)";
                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.Integer, Value = realStateID });
                command.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.VarWChar, Value = fileName ?? "" });
                command.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.VarWChar, Value = path ?? "" });
                command.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.Date, Value = dateOFAttash });
                command.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.VarWChar, Value = comment ?? "" });
                command.Parameters.Add(new OleDbParameter { OleDbType = OleDbType.Integer, Value = type });


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static DataTable GetAttachmentsForRealState(long RealStateID)
        {
            DataTable dt = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM attachmentOwn WHERE RealState_ID = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // استخدم Integer لأنه الأنسب لـ Access لو العمود Number
                    command.Parameters.Add(new OleDbParameter
                    {
                        OleDbType = OleDbType.Integer,
                        Value = RealStateID
                    });

                    try
                    {
                        connection.Open();
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error loading attachments: " + ex.Message);
                        throw; // ممكن ترمي الاستثناء عشان تتابعه
                    }
                }
            }

            return dt;
        }

    }
}
