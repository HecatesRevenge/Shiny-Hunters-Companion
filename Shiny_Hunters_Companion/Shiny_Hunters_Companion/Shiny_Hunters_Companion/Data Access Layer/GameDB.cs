using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public class GameDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ShinyCompanion.accdb;";
        private OleDbConnection myConnection;
        private OleDbDataAdapter myDataAdapter;
        public DataSet GameDataSet { get; set; }

        public GameDB()
        {
            GameDataSet = new DataSet("ShinyGameDB");
        }

        private Game GetGameFromRow(DataRow row)
        {
            return new Game
            {
                GameID = Convert.ToInt32(row["GameID"]),
                GameName = row["GameName"].ToString(),
                Generation = row["Generation"].ToString(),
                Platform = row["Platform"].ToString(),
                RegionName = row["RegionName"].ToString(),
                ReleaseDate = Convert.ToDateTime(row["ReleaseDate"]),

                //Kept here incase I want to add this functionality later
                BoxArtURL = row["BoxArtURL"] != DBNull.Value ? row["BoxArtURL"].ToString() : ""
            };
        }

        public List<Game> GetAllGames()
        {
            List<Game> results = new List<Game>();
            myConnection = new OleDbConnection(connectionString);
            string strSQL = "SELECT * FROM tblGames ORDER BY ReleaseDate";

            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            DataTable gameTable = new DataTable();

            myDataAdapter.Fill(gameTable);

            foreach (DataRow row in gameTable.Rows)
            {
                results.Add(GetGameFromRow(row));
            }

            return results;
        }

        public Game GetGameDetails(int gameID)
        {
            myConnection = new OleDbConnection(connectionString);
            string strSQL = "SELECT * FROM tblGames"; 

            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            DataTable gameTable = new DataTable();
            myDataAdapter.Fill(gameTable);

            foreach (DataRow row in gameTable.Rows)
            {
                if (Convert.ToInt32(row["GameID"]) == gameID)
                {
                    return GetGameFromRow(row);
                }
            }

            return null;
        }
    }
}
    
    
    
    
    

    

