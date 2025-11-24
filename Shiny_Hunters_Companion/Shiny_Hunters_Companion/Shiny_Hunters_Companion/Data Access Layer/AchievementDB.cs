using System;
using System.Collections.Generic;
using System.Data.OleDb;

using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public class AchievementDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
        private OleDbConnection myConnection;
        public AchievementDB()
        {
            myConnection = new OleDbConnection(connectionString);
        }



        public List<Achievement> GetAchievementsForUser(int userId)
        {
            List<Achievement> list = new List<Achievement>();

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
                using (OleDbConnection connect = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(strSQL, connect))
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
        public void CheckAndUnlock(int userId, string metricType, int currentValue)
        {
            string strSQL = @"
                SELECT AchievementID, Name 
                FROM tblAchievements 
                WHERE ConditionType = @Type 
                AND Threshold <= @Val
                AND AchievementID NOT IN (SELECT AchievementID_FK FROM tblUserAchievements WHERE UserID_FK = @UserID)";

            List<Achievement> newUnlocks = new List<Achievement>();

            try
            {
                using (OleDbConnection connect = new OleDbConnection(connectionString))
                {
                    connect.Open();

                    using (OleDbCommand cmd = new OleDbCommand(strSQL, connect))
                    {
                        cmd.Parameters.AddWithValue("@Type", metricType);
                        cmd.Parameters.AddWithValue("@Val", currentValue);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Achievement a = new Achievement();
                                a.AchievementID = Convert.ToInt32(reader["AchievementID"]);
                                a.Name = reader["Name"].ToString();
                                newUnlocks.Add(a);
                            }
                        }
                    }

                    foreach (var ach in newUnlocks)
                    {
                        UnlockAchievement(userId, ach.AchievementID);
                        MessageBox.Show($"Achievement Unlocked: {ach.Name}!", "Congratulations");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UnlockAchievement(int userId, int achievementId)
        {
            string insertSQL = "INSERT INTO tblUserAchievements (UserID_FK, AchievementID_FK, UnlockDate) VALUES (@User, @Ach, @Date)";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(insertSQL, conn))
            {
                cmd.Parameters.AddWithValue("@User", userId);
                cmd.Parameters.AddWithValue("@Ach", achievementId);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}