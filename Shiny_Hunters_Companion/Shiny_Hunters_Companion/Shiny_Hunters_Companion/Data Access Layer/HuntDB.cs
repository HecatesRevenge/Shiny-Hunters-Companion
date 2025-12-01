using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public class HuntDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
        private OleDbConnection myConnection;

        public HuntDB()
        {
            myConnection = new OleDbConnection(connectionString);
        }

        private Hunt GetHuntFromReader(OleDbDataReader reader)
        {
            return new Hunt
            {
                HuntID = Convert.ToInt32(reader["HuntID"]),
                UserID = Convert.ToInt32(reader["UserID_FK"]),
                GameID = Convert.ToInt32(reader["GameID_FK"]),
                FormID = Convert.ToInt32(reader["FormID_FK"]),
                MethodID = Convert.ToInt32(reader["MethodID_FK"]),
                EncounterCount = Convert.ToInt32(reader["EncounterCount"]),
                TotalTimeSeconds = Convert.ToInt32(reader["TotalTimeSeconds"]),
                isActive = Convert.ToBoolean(reader["isActive"])

            };
        }

        private List<Hunt> DatabaseSelectQuery(string query, Dictionary<string, object> parameters = null)
        {
            List<Hunt> result = new List<Hunt>();
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
                            result.Add(GetHuntFromReader(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error (HuntDB: " + ex.Message);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            return result;
        }

        private int DatabaseNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            int rows = 0;

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
                    rows = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error (HuntDB: " + ex.Message);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            return rows;
        }

        private int DataInsertWithTransaction(string insertSQL, Dictionary<string, object> parameters, List<PlayerModifier> modifiers)
        {
            {
                int newID = -1;
                try
                {
                    if (myConnection.State != ConnectionState.Open)
                    {
                        myConnection.Open();
                    }
                    using (OleDbTransaction trans = myConnection.BeginTransaction())
                    {
                        try
                        {
                            using (OleDbCommand command = new OleDbCommand(insertSQL, myConnection, trans))
                            {
                                if (parameters != null)
                                {
                                    foreach (var p in parameters)
                                    {
                                        command.Parameters.AddWithValue(p.Key, p.Value);
                                    }
                                }


                                command.ExecuteNonQuery();
                              

                                command.CommandText = "SELECT @@IDENTITY";
                                command.Parameters.Clear();
                                newID = (int)command.ExecuteScalar();
                            }

                            if (modifiers != null && modifiers.Count > 0)

                                if (modifiers != null && modifiers.Count > 0)
                            {
                                string modifierSQL = "INSERT INTO tblHuntModifiers (HuntID_FK, ModifierID_FK) VALUES (@HuntID, @ModID)";
                                using (OleDbCommand modifierCommand = new OleDbCommand(modifierSQL, myConnection, trans))
                                {
                                    foreach (var m in modifiers)
                                    {
                                        modifierCommand.Parameters.Clear();
                                        modifierCommand.Parameters.AddWithValue("@HuntID", newID);
                                        modifierCommand.Parameters.AddWithValue("@ModID", m.ModifierID);
                                        modifierCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting record: " + ex.Message);
                    return -1;
                }
                finally
                {
                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Close();
                    }
                }
                return newID;
            }
        }

        public List<Hunt> GetActiveHunts(int userID)
        {
            string strSQL = @"
                SELECT *
                FROM tblHunts
                WHERE UserID_FK= @UserID AND IsActive=TRUE
                ORDER BY HuntID DESC";
            //Make sure this format is something I can use
            var parameters = new Dictionary<string, object> { { "UserID", userID } };
            return DatabaseSelectQuery(strSQL, parameters);
        }

        public Hunt GetHunt(int huntID)
        {
            string strSQL = @"
                SELECT *
                FROM tblHunts
                WHERE HuntID=@HuntID";
            var parameters = new Dictionary<string, object> { { "@HuntID", huntID } };
            List<Hunt> results = DatabaseSelectQuery(strSQL, parameters);

            if (results.Count > 0)
            {
                return results[0];
            }
            else
            {
                return null;
            }
        }

        public List<PlayerModifier> GetModifiersForHunt(int huntID)
        {
            ModifierDB modifierDB=new ModifierDB();
            return modifierDB.GetModifiersByHunt(huntID);
        }

        public int CreateHunt(Hunt newHunt)
        {
            string strSql = @"
                INSERT INTO tblHunts 
                (UserID_FK, GameID_FK, FormID_FK, MethodID_FK, EncounterCount, TotalTimeSeconds, IsActive) 
                 VALUES (@UserID, @GameID, @FormID, @MethodID, @Count, @Time, @Active)
                ";
            var parameter = new Dictionary<string, object> {
                {"@UserID",newHunt.UserID},
                {"@GameID", newHunt.GameID },
                {"@FormID", newHunt.FormID},
                {"@MethodID", newHunt.MethodID},
                {"@Count", newHunt.EncounterCount},
                {"@Time", newHunt.TotalTimeSeconds},
                {"@Active", newHunt.isActive }
            };

            return DataInsertWithTransaction(strSql, parameter, newHunt.ActiveModifiers);
        }

        public void UpdateHuntCount(int huntID, int count, int time)
        {
            string strSQL = @"
                UPDATE tblHunts
                SET EncounterCount=@Count, TotalTimeSeconds=@Time WHERE HuntID=@HuntID";
            var parameters = new Dictionary<string, object> {
                {"@Count", count },
                {"@Time", time},
                {"@HuntID", huntID }
            };
            DatabaseNonQuery(strSQL, parameters);
        }

        public void CompleteHunt(int huntID)
        {
            string strSQL = @"
                UPDATE tblHunts 
                SET IsActive = False 
                WHERE HuntID = @HuntID";

            var parameters = new Dictionary<string, object>
            {
                { "@HuntID", huntID }
            };
            DatabaseNonQuery(strSQL, parameters);
        }

    }

}
