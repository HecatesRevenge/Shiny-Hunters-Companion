using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public class GameDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
        private OleDbConnection myConnection;

        public GameDB()
        {
            myConnection = new OleDbConnection(connectionString);

        }

        private Game GetGameFromReader(OleDbDataReader reader)
        {
            return new Game
            {
                GameID = Convert.ToInt32(reader["GameID"]),
                GameName = reader["GameName"].ToString(),
                Generation = reader["Generation"].ToString(),
                Platform = reader["platform"].ToString(),
                RegionName = reader["RegionName"].ToString(),
                ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]),
                BoxArtURL = reader["BoxArtURL"].ToString()

            };


        }

        private List<Game> DatabaseSelectQuery(string query, Dictionary<string, object> parameters = null)
        {
            List<Game> results = new List<Game>();
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
                            results.Add(GetGameFromReader(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
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

        public List<Game> GetAllGames()
        {
            string strSQL = @"
                SELECT * 
                FROM tblGames 
                ORDER BY ReleaseDate";
            return DatabaseSelectQuery(strSQL);
        }

        public Game GetGameDetails(int gameID)
        {
            string strSQL = @"
                SELECT * 
                FROM tblGames 
                WHERE GameID = @GameID";
            var parameters = new Dictionary<string, object>
            {
                { "@GameID", gameID }
            };

            List<Game> results = DatabaseSelectQuery(strSQL, parameters);

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

        //TODO: UpdateGameDetails with API call to update game details in the database



    }


