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
    public class GameMethodDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
        private OleDbConnection myConnection;

        public GameMethodDB() {
            myConnection=new OleDbConnection(connectionString);
        }

        private int DatabaseNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            int rows = 0;
            try
            {
                if (myConnection.State != ConnectionState.Open) myConnection.Open();

                using (OleDbCommand command = new OleDbCommand(query, myConnection))
                {
                    if (parameters != null)
                    {
                        foreach (var p in parameters) command.Parameters.AddWithValue(p.Key, p.Value);
                    }
                    rows = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error (GameMethodDB): " + ex.Message);
                return -1;
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open) myConnection.Close();
            }
            return rows;
        }

        private void AddMethodToGame(int gameID, int methodID)
        {
            string strSQL = "INSERT INTO tblGameMethods (GameID_FK, MethodID_FK) VALUES (@GameID, @MethodID)";

            var parameters = new Dictionary<string, object>
            {
                {"@GameID", gameID },
                {"@MethodID", methodID }
            };

            DatabaseNonQuery(strSQL, parameters);
        }

        public void RemoveMethodFromGame(int gameID, int methodID)
        {
            string strSQL = "DELETE FROM tblGameMethods WHERE GameID_FK = @GameID AND MethodID_FK = @MethodID";

            var parameters = new Dictionary<string, object>
            {
                { "@GameID", gameID },
                { "@MethodID", methodID }
            };

            DatabaseNonQuery(strSQL, parameters);
        }

        public void ClearMethodsForGame(int gameID)
        {
            string strSQL = "DELETE FROM tblGameMethods WHERE GameID_FK = @GameID";
            var parameters = new Dictionary<string, object> {
                { "@GameID", gameID }
            };
            DatabaseNonQuery(strSQL, parameters);
        }

    }

}
