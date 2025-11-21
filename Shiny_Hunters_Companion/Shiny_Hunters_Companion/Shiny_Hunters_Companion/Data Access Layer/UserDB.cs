using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public class UserDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
        private OleDbConnection myConnection;

        public UserDB()
        {
            myConnection = new OleDbConnection(connectionString);
        }

        public bool RegisterUser(string username, string plainTextPassword)
        {
            if (UsernameExists(username))
            {
                MessageBox.Show("Username already taken.");
                return false;
            }

            string salt = GenerateSalt();
            string hash = ComputeHash(plainTextPassword, salt);

            string strSQL = @"
                INSERT INTO tblUsers (Username, PasswordHash, Salt, JoinDate)
                VALUES (@User, @Hash, @Salt, @Date)";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(strSQL, connection))
                {
                    command.Parameters.AddWithValue("@User", username);
                    command.Parameters.AddWithValue("@Hash", hash);
                    command.Parameters.AddWithValue("@Salt", salt);
                    command.Parameters.AddWithValue("@Date", DateTime.Now.ToString());

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error registering user: " + ex.Message);
                return false;
            }
        }
        public User VerifyLogin(string username, string plainTextPassword)
        {
            User user = GetUserByUsername(username);

            if (user == null)
            {
                return null; 
            }

            string checkHash = ComputeHash(plainTextPassword, user.Salt);

            if (checkHash == user.PasswordHash)
            {
                return user; 
            }
            else
            {
                return null; 
            }
        }


        public User GetUserByUsername(string username)
        {
            string strSQL = "SELECT * FROM tblUsers WHERE Username = @User";
            User user = null;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                using (OleDbCommand cmd = new OleDbCommand(strSQL, conn))
                {
                    cmd.Parameters.AddWithValue("@User", username);
                    conn.Open();

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Salt = reader["Salt"].ToString(),
                                JoinDate = Convert.ToDateTime(reader["JoinDate"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching user: " + ex.Message);
            }

            return user;
        }
        private bool UsernameExists(string username)
        {
            string strSQL = "SELECT COUNT(*) FROM tblUsers WHERE Username = @User";
            int count = 0;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(strSQL, connection))
                {
                    command.Parameters.AddWithValue("@User", username);
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex) { }

            return count > 0;
        }

        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
        private static string ComputeHash(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] combinedBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }

}

