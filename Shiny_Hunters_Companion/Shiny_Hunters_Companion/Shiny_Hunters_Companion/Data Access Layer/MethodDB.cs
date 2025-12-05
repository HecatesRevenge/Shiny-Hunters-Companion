using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public class MethodDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ShinyCompanion.accdb;";
        private OleDbConnection myConnection;
        private OleDbDataAdapter myDataAdapter;
        public DataSet MethodDataSet { get; set; }

        public MethodDB()
        {
            MethodDataSet = new DataSet("ShinyMethodDB");
            myConnection = new OleDbConnection(connectionString);
        }

        private Method GetMethodFromRow(DataRow row)
        {
            return new Method
            {
                MethodID = Convert.ToInt32(row["MethodID"]),
                MethodName = row["MethodName"].ToString(),
                BaseOdds = Convert.ToInt32(row["BaseOdds"]),
                OddsModifier = Convert.ToInt32(row["OddsModifier"]),
                Description = row["Description"].ToString()
            };
        }

        public List<Method> GetAllMethods()
        {
            List<Method> results = new List<Method>();
            string strSQL = "SELECT * FROM tblMethods ORDER BY MethodName";

            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            DataTable methodTable = new DataTable();

            myDataAdapter.Fill(methodTable);

            foreach (DataRow row in methodTable.Rows)
            {
                results.Add(GetMethodFromRow(row));
            }

            return results;
        }

        public List<Method> GetMethodsFromGame(int gameId)
        {
            List<Method> results = new List<Method>();

            string strSQL = @"
                SELECT m.* FROM tblMethods AS m
                INNER JOIN tblGameMethods AS gm ON m.MethodID = gm.MethodID_FK
                WHERE gm.GameID_FK = @GameID
                ORDER BY m.MethodName";

            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            myDataAdapter.SelectCommand.Parameters.AddWithValue("@GameID", gameId);

            DataTable methodTable = new DataTable();
            myDataAdapter.Fill(methodTable);

            foreach (DataRow row in methodTable.Rows)
            {
                results.Add(GetMethodFromRow(row));
            }

            return results;
        }
        public Method GetMethodDetails(int methodID)
        {

            string strSQL = "SELECT * FROM tblMethods";

            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            DataTable methodTable = new DataTable();
            myDataAdapter.Fill(methodTable);

            foreach (DataRow row in methodTable.Rows)
            {
                if (Convert.ToInt32(row["MethodID"]) == methodID)
                {
                    return GetMethodFromRow(row);
                }
            }

            return null;
        }

        public string GetMethodName(int methodID)
        {
            Method method = GetMethodDetails(methodID);

            if (method == null)
            {
                return "Unknown Method";
            }
            else
            {
                return method.MethodName;
            }
        }
    }
}