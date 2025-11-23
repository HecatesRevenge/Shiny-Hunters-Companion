using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
   public class AchievementDB
    {
        private OleDbCommand myConnection;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
       
        public AchievementDB()
        {
            myConnection = new OleDbCommand(connectionString);
        }

}

        public List<Achievement> GetAchievementsForUser(int userId)
        {
            List<Achievement> list = new List<Achievement>();

            // LEFT JOIN allows us to see ALL achievements, even ones the user doesn't have yet.
            string strSQL = @"
                SELECT 
                    A.AchievementID, 
                    A.Name, 
                    A.Description, 
                    A.ConditionType, 
                    A.Threshold, 
                    A.ImageURL, 
                    UA.UnlockDate
                FROM 
                    tblAchievements AS A
                LEFT JOIN 
                    tblUserAchievements AS UA 
                ON 
                    (A.AchievementID = UA.AchievementID_FK) AND (UA.UserID_FK = @UserID)
                ORDER BY 
                    A.Threshold, A.Name";

            try
            {
                using (OleDbConnection connect = new OleDbConnection(myConnection))
                using (OleDbCommand command = new OleDbCommand(strSQL, conn))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    connect.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Achievement a = new Achievement();
                            a.AchievementID = Convert.ToInt32(reader["AchievementID"]);
                            a.Name = reader["Name"].ToString();
                            a.Description = reader["Description"].ToString();
                            a.ConditionType = reader["ConditionType"].ToString();
                            a.Threshold = Convert.ToInt32(reader["Threshold"]);
                            a.ImageURL = reader["ImageURL"].ToString();

                            if (reader["UnlockDate"] != DBNull.Value)
                            {
                                a.IsUnlocked = true;
                                a.UnlockDate = Convert.ToDateTime(reader["UnlockDate"]);
                            }
                            else
                            {
                                a.IsUnlocked = false;
                            }

                            list.Add(a);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading achievements: " + ex.Message);
            }

            return list;
        }
    }