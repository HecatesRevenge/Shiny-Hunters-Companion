using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion.Data_Access_Layer
{
    public class UserPokedexDB
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
        private OleDbConnection myConnection;

        public UserPokedexDB()
        {
            myConnection = new OleDbConnection(connectionString);
        }
        public HashSet<int> GetCaughtPokemonIDs(int userID)
        {
            HashSet<int> caughtIds = new HashSet<int>();
            string query = "SELECT PokemonID FROM tblUserPokedex WHERE UserID = @UserID";
            var parameters = new Dictionary<string, object> 
            { 
                { "@UserID", userID } 
            };

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
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            caughtIds.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            finally
            {
               
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }

            return caughtIds;
        }

        public void UpdateCaughtStatus(int userID, int pokemonID, bool isCaught)
        {
            try
            {
                if (myConnection.State != ConnectionState.Open)
                {
                    myConnection.Open();
                }

                using (OleDbCommand command = new OleDbCommand("", myConnection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@PokemonID", pokemonID);

                    if (isCaught)
                    {

                        command.CommandText = "SELECT COUNT(*) FROM tblUserPokedex WHERE UserID = @UserID AND PokemonID = @PokemonID";
                        int count = (int)command.ExecuteScalar();

                        if (count == 0)
                        {
                            command.Parameters.Clear();
                            command.CommandText = "INSERT INTO tblUserPokedex (UserID, PokemonID, DateCaught) VALUES (@UserID, @PokemonID, @Date)";
                            command.Parameters.AddWithValue("@UserID", userID);
                            command.Parameters.AddWithValue("@PokemonID", pokemonID);
                            command.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        
                        command.CommandText = "DELETE FROM tblUserPokedex WHERE UserID = @UserID AND PokemonID = @PokemonID";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
        }
    }
    
}
       
