using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    //This class helps add and remove shiny hunting methods but isnt used elsewhere
    public class GameMethodDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ShinyCompanion.accdb;";
        private OleDbConnection myConnection;
        private OleDbDataAdapter myDataAdapter;
        private OleDbCommandBuilder myCommandBuilder;

        public DataSet GameMethodDataSet { get; set; }

        public GameMethodDB()
        {
            GameMethodDataSet = new DataSet("ShinyGameMethodDB");
            myConnection = new OleDbConnection(connectionString);
        }

        public void AddMethodToGame(int gameID, int methodID)
        {
            string strSQL = "SELECT * FROM tblGameMethods";

            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            myCommandBuilder = new OleDbCommandBuilder(myDataAdapter);

            myCommandBuilder.QuotePrefix = "[";
            myCommandBuilder.QuoteSuffix = "]";

            DataSet tempDataSet = new DataSet();
            myDataAdapter.Fill(tempDataSet, "tblGameMethods");
            DataTable table = tempDataSet.Tables["tblGameMethods"];

            DataRow newRow = table.NewRow();
            newRow["GameID_FK"] = gameID;
            newRow["MethodID_FK"] = methodID;

            table.Rows.Add(newRow);

            myDataAdapter.Update(tempDataSet, "tblGameMethods");
        }

        public void RemoveMethodFromGame(int gameID, int methodID)
        {
            myConnection = new OleDbConnection(connectionString);
            string strSQL = "SELECT * FROM tblGameMethods";

            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            myCommandBuilder = new OleDbCommandBuilder(myDataAdapter);

            DataTable table = new DataTable();
            myDataAdapter.Fill(table);

            for (int i = table.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = table.Rows[i];
                if (Convert.ToInt32(row["GameID_FK"]) == gameID && Convert.ToInt32(row["MethodID_FK"]) == methodID)
                {
                    row.Delete();
                }
            }

            myDataAdapter.Update(table);
        }
    }

}
