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
        private OleDbDataAdapter myDataAdapter;
        private OleDbCommandBuilder myCommandBuilder;
        private OleDbCommand myCommand;
        public DataSet HuntDataSet { get; set; }

        public HuntDB()
        {
            HuntDataSet = new DataSet("ShinyHuntDB");
            myConnection = new OleDbConnection(connectionString);
        }

        private Hunt GetHuntFromRow(DataRow row)
        {
            Hunt hunt = new Hunt
            {
                HuntID = Convert.ToInt32(row["HuntID"]),
                UserID = Convert.ToInt32(row["UserID_FK"]),
                GameID = Convert.ToInt32(row["GameID_FK"]),
                FormID = Convert.ToInt32(row["FormID_FK"]),
                MethodID = Convert.ToInt32(row["MethodID_FK"]),
                EncounterCount = Convert.ToInt32(row["EncounterCount"]),
                TotalTimeSeconds = Convert.ToInt32(row["TotalTimeSeconds"]),
                isActive = Convert.ToBoolean(row["isActive"])
            };
            if (row["DateCaught"] != DBNull.Value)
            {
                hunt.DateCaught = Convert.ToDateTime(row["DateCaught"]);
            }

            return hunt;
        }

        public List<Hunt> GetActiveHunts(int userID)
        {
            List<Hunt> activeHunts = new List<Hunt>();

            string strSQL = "SELECT * FROM tblHunts ORDER BY HuntID DESC";
            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);


            DataTable dataHunts = new DataTable();
            myDataAdapter.Fill(dataHunts);

            foreach (DataRow row in dataHunts.Rows)
            {
                if ((Convert.ToInt32(row["UserID_FK"]) == userID) && (Convert.ToBoolean(row["isActive"]) == true))
                {
                    activeHunts.Add(GetHuntFromRow(row));
                }
            }


            return activeHunts;
        }

        public List<Hunt> GetCompletedHunts(int userID)
        {
            List<Hunt> completedHunts = new List<Hunt>();
            myConnection = new OleDbConnection(connectionString);

            string strSQL = "SELECT * FROM tblHunts ORDER BY HuntID DESC";
            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);

            DataTable dataHunts = new DataTable();
            myDataAdapter.Fill(dataHunts);

            foreach (DataRow row in dataHunts.Rows)
            {
                if ((Convert.ToInt32(row["UserID_FK"]) == userID) && (Convert.ToBoolean(row["isActive"]) == false))
                {
                    completedHunts.Add(GetHuntFromRow(row));
                }
            }

            return completedHunts;
        }

        public Hunt GetHunt(int huntID)
        {
            myConnection = new OleDbConnection(connectionString);
            string strSQL = "SELECT * FROM tblHunts";
            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);

            DataTable dataHunts = new DataTable();
            myDataAdapter.Fill(dataHunts);

            foreach (DataRow row in dataHunts.Rows)
            {
                if (Convert.ToInt32(row["HuntID"]) == huntID)
                {
                    return GetHuntFromRow(row);
                }
            }
            return null;
        }

        public List<PlayerModifier> GetModifiersForHunt(int huntID)
        {
            ModifierDB modifierDB = new ModifierDB();
            return modifierDB.GetModifiersByHunt(huntID);
        }

        public int CreateHunt(Hunt newHunt)
        {
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();

            string strSQL = "SELECT * FROM tblHunts";
            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            myCommandBuilder = new OleDbCommandBuilder(myDataAdapter);
            myCommandBuilder.QuotePrefix = "[";
            myCommandBuilder.QuoteSuffix = "]";

            DataSet tempData = new DataSet();
            myDataAdapter.Fill(tempData, "tblHunts");
            DataTable huntTable = tempData.Tables["tblHunts"];

            DataRow newRow = huntTable.NewRow();
            newRow["UserID_FK"] = newHunt.UserID;
            newRow["GameID_FK"] = newHunt.GameID;
            newRow["FormID_FK"] = newHunt.FormID;
            newRow["MethodID_FK"] = newHunt.MethodID;
            newRow["EncounterCount"] = newHunt.EncounterCount;
            newRow["TotalTimeSeconds"] = newHunt.TotalTimeSeconds;
            newRow["isActive"] = newHunt.isActive;

            huntTable.Rows.Add(newRow);

            myDataAdapter.Update(tempData, "tblHunts");

            string strID = "SELECT MAX(HuntID) FROM tblHunts";
            myCommand = new OleDbCommand(strID, myConnection);
            int newHuntID = Convert.ToInt32(myCommand.ExecuteScalar());

            if ((newHunt.ActiveModifiers != null) && (newHunt.ActiveModifiers.Count > 0))
            {
                string strModSQL = "SELECT * FROM tblHuntModifiers";
                OleDbDataAdapter modifyAdapter = new OleDbDataAdapter(strModSQL, myConnection);
                OleDbCommandBuilder modifyBuilder = new OleDbCommandBuilder(modifyAdapter);
                modifyBuilder.QuotePrefix = "[";
                modifyBuilder.QuoteSuffix = "]";

                DataSet modifyDataSet = new DataSet();
                modifyAdapter.Fill(modifyDataSet, "tblHuntModifiers");
                DataTable modTable = modifyDataSet.Tables["tblHuntModifiers"];

                foreach (var mod in newHunt.ActiveModifiers)
                {
                    DataRow modRow = modTable.NewRow();
                    modRow["HuntID_FK"] = newHuntID;
                    modRow["ModifierID_FK"] = mod.ModifierID;
                    modTable.Rows.Add(modRow);
                }
                modifyAdapter.Update(modifyDataSet, "tblHuntModifiers");
            }

            myConnection.Close();
            return newHuntID;
        }

        public void UpdateHuntCount(int huntID, int count, int time)
        {
            myConnection = new OleDbConnection(connectionString);
            string strSQL = "SELECT * FROM tblHunts";

            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            myCommandBuilder = new OleDbCommandBuilder(myDataAdapter);

            DataTable dataTable = new DataTable();
            myDataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                if (Convert.ToInt32(row["HuntID"]) == huntID)
                {
                    row["EncounterCount"] = count;
                    row["TotalTimeSeconds"] = time;
                    break; 
                }
            }
            myDataAdapter.Update(dataTable);
        }

        public void CompleteHunt(int huntID)
        {
            myConnection = new OleDbConnection(connectionString);
            string strSQL = "SELECT * FROM tblHunts";

            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            myCommandBuilder = new OleDbCommandBuilder(myDataAdapter);

            DataTable dataTable = new DataTable();
            myDataAdapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                if (Convert.ToInt32(row["HuntID"]) == huntID)
                {
                    row["isActive"] = false;
                    row["DateCaught"] = DateTime.Now;
                    break;
                }
            }
            myDataAdapter.Update(dataTable);
        }
    }
}
        
