using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Shiny_Hunters_Companion
{
    public class PokemonDB
    {

        //Connection string to Access Database file incase it needs to be changed
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";

        private OleDbConnection myConnection;
        private OleDbDataAdapter myDataAdapter;
        private OleDbCommand myCommand;
        private DataSet myDataSet;
        private string strSql;

        public PokemonDB()
        {

            myConnection = new OleDbConnection(connectionString);

        }
        private List<PokemonForm> DatabaseSelectQuery(string query, Dictionary<string, object> parameters = null)
        {
            List<PokemonForm> results = new List<PokemonForm>();

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
                        foreach (var p in parameters)
                        {
                            command.Parameters.AddWithValue(p.Key, p.Value);
                        }
                    }

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(GetPokemonFromReader(reader));

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error");
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

        private PokemonForm GetPokemonFromReader(OleDbDataReader reader)
        {
            /*Adjust how information is converted if need be */
            Pokemon basePokemon = new Pokemon
            {
                PokemonID = Convert.ToInt32(reader["PokemonID"]),
                PokedexNumber = Convert.ToInt32(reader["PokedexNumber"]),
                BaseName = reader["BaseName"].ToString()
            };
            return new PokemonForm
            {
                FormID = Convert.ToInt32(reader["FormID"]),
                FormName = reader["FormName"].ToString(),
                DisplayName = reader["DisplayName"].ToString(),
                SpriteURL = reader["SpriteURL"].ToString(),
                BasePokemon = basePokemon
            };
        }

        public List<PokemonForm> GetAllPokemonForms()
        {
            List<PokemonForm> pokemonForms = new List<PokemonForm>();

            strSql = @"
            SELECT
                f.FormID,
                f.FormName,
                f.DisplayName,
                f.SpriteURL,
                p.PokedexNumber,
                p.PokemonName,
                p.BaseName
            FROM
                tblPokemonForms AS f
            INNER JOIN
                tblPokemon AS p ON f.PokemonID_FK = p.PokemonID
            ORDER BY
                p.PokedexNumber, f.FormID";

            return DatabaseSelectQuery(strSql);
        }

        public PokemonForm GetPokemonFormByID(int formID)
        {
            strSql = @"
            SELECT
                f.FormID,
                f.FormName,
                f.DisplayName,
                f.SpriteURL,
                p.PokemonID,
                p.PokedexNumber,
                p.BaseName
            FROM
                tblPokemonForms AS f
            INNER JOIN
                tblPokemon as p ON f.PokemonID_FK=p.PokemonID
            WHERE
                f.FormID=@FormID
            ";

            var parameters = new Dictionary<string, object>
            {
                {"@FormID", formID }
            };

           List<PokemonForm> results = DatabaseSelectQuery(strSql, parameters);

            if (results.Count > 0)
            {
                return results[0];
            }
            else
            {
                return null;
            }

        }

        //TODO: Add a way to get pokemon from a game by gameID
        //Might need to add a way to insert into DB but this should work for now.
    }
}


