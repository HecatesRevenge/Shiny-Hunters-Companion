using Shiny_Hunters_Companion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public class ModifierDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
        private OleDbConnection myConnection;
        public ModifierDB()
        {
            myConnection = new OleDbConnection(connectionString);

        }

        private PlayerModifier GetPlayerModifierFromReader(OleDbDataReader reader)
        {
            return new PlayerModifier
            {

                ModifierID = Convert.ToInt32(reader["ModifierID"]),
                ModifierName = reader["ModifierName"].ToString(),
                OddsMultiplier = Convert.ToDouble(reader["OddsMultiplier"]),
                Description = reader["Description"].ToString()
            };
        }

        private List<PlayerModifier> DatabaseSelectQuery(string query, Dictionary<string, object> parameters = null)
        {
            List<PlayerModifier> results = new List<PlayerModifier>();
            try
            {
                if (myConnection.State != ConnectionState.Open)
                {
                    myConnection.Open();
                }
                using (OleDbCommand command = new OleDbCommand(query, myConnection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(GetPlayerModifierFromReader(reader));
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


        public List<PlayerModifier> GetAllModifiers()
        {

            string strSQL = @"
                SELECT * 
                FROM tblModifiers 
                ORDER BY ModifierName";
            return DatabaseSelectQuery(strSQL);
        }

        public List<PlayerModifier> GetModifiersByGame(int gameID)
        {
            string strSQL = @"
                SELECT m.* FROM tblModifiers AS m
                INNER JOIN tblGameModifiers AS gm ON m.ModifierID = gm.ModifierID_FK
                WHERE gm.GameID_FK = @GameID
                ORDER BY m.ModifierName";

            var parameters = new Dictionary<string, object>
            {
                { "@GameID", gameID }
            };

            return DatabaseSelectQuery(strSQL, parameters);

        }

    }
}

