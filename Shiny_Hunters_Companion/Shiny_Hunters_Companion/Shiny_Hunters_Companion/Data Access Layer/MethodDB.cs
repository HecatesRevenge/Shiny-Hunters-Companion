using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public class MethodDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
        private OleDbConnection myConnection;
        public MethodDB()
        {
            myConnection = new OleDbConnection(connectionString);
        }

        private Method GetHuntMethodFromReader(OleDbDataReader reader)
        {
            return new Method
            {
                MethodID = Convert.ToInt32(reader["MethodID"]),
                MethodName = reader["MethodName"].ToString(),
                BaseOdds = Convert.ToInt32(reader["BaseOdds"]),
                OddsModifer = Convert.ToInt32(reader["OddsModifer"]),
                Description = reader["Description"].ToString(),

            };

        }

        private List<Method> DatabaseSelectQuery(string query, Dictionary<string, object> parameters = null)
        {
            List<Method> results = new List<Method>();
            try
            {
                if (myConnection.State != ConnectionState.Open)
                {
                    myConnection.Open();
                }

                using (OleDbCommand command = new OleDbCommand(query, myConnection))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                        {
                            command.Parameters.AddWithValue(p.Key, p.Value);
                        }
                    }

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(GetHuntMethodFromReader(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error (MethodDB): " + ex.Message);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            return results;
        }

        public List<Method> GetAllMethods()
        {
            string strString = "SELECT * FROM tblMethods ORDER BY MethodName";
            return DatabaseSelectQuery(strString);
        }

        public List<Method> GetMethodsFromGame(int gameId)
        {
            string strSQL = @"
                SELECT m.* FROM tblMethods AS m
                INNER JOIN tblGameMethods AS gm ON m.MethodID=gm.MethodID_FK
                WHERE gm.GameID_FK=@GameID
                ORDER BY m.MethodName";

            var parameters = new Dictionary<string, object>
            {
                {"@GameID", gameId }
            };

            return DatabaseSelectQuery(strSQL, parameters);
        }

        public Method GetMethodDetails(int methodID)
        {
            string strSQL = "SELECT * FROM tblMethods WHERE MethodID=@MethodID";

            var parameters = new Dictionary<string, object>
            {
                {"@MethodID", methodID},
            };
            List<Method> results = DatabaseSelectQuery(strSQL, parameters);

            if (results.Count > 0)
            {
                return results[0];
            }
            else
            {
                return null;
            }
        }


    }
}
