using System;
using System.IO; // For reading the file
using System.Data.OleDb; // For talking to Access
using System.Collections.Generic; // For the Dictionary

public class DataImporter
{
    private static string _connectionString =
        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\YourProject\ShinyCompanion.accdb";

   
    private static Dictionary<string, int> _pokemonCache = new Dictionary<string, int>();

    public static void RunImport()
    {
        string csvFilePath = @"C:\YourProject\pokemon_import.csv";

     
        string[] allLines = File.ReadAllLines(csvFilePath);

   
        for (int i = 1; i < allLines.Length; i++)
        {
            string line = allLines[i];
            string[] columns = line.Split(',');

     
            int pokedexNum = int.Parse(columns[0]);
            string baseName = columns[1];
            string formName = columns[2];
            string displayName = columns[3];
            string spriteURL = columns[4];

            int parentPokemonID = GetOrCreateParentPokemon(baseName, pokedexNum);

  
            InsertPokemonForm(parentPokemonID, formName, displayName, spriteURL);

            Console.WriteLine($"Successfully imported: {displayName}");
        }
        Console.WriteLine("Import Complete!");
    }

  
    private static int GetOrCreateParentPokemon(string baseName, int pokedexNum)
    {
        if (_pokemonCache.ContainsKey(baseName))
        {
            return _pokemonCache[baseName];
        }

     
        string sql = "INSERT INTO tblPokemon (PokedexNum, BaseName) VALUES (@PokedexNum, @BaseName);";
        string sql_identity = "SELECT @@IDENTITY;";

        using (OleDbConnection conn = new OleDbConnection(_connectionString))
        {
            conn.Open();

  
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PokedexNum", pokedexNum);
                cmd.Parameters.AddWithValue("@BaseName", baseName);
                cmd.ExecuteNonQuery();
            }

            // 2. Get the new ID
            using (OleDbCommand cmd_id = new OleDbCommand(sql_identity, conn))
            {
                int newID = (int)cmd_id.ExecuteScalar();

            
                _pokemonCache.Add(baseName, newID);
                return newID;
            }
        }
    }

   
    private static void InsertPokemonForm(int parentID, string formName, string displayName, string spriteURL)
    {
        string sql = @"
            INSERT INTO tblPokemonForms (PokemonID_FK, FormName, DisplayName, SpriteURL) 
            VALUES (@PokemonID_FK, @FormName, @DisplayName, @SpriteURL)";

        using (OleDbConnection conn = new OleDbConnection(_connectionString))
        {
            conn.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@PokemonID_FK", parentID);
                cmd.Parameters.AddWithValue("@FormName", formName);
                cmd.Parameters.AddWithValue("@DisplayName", displayName);
                cmd.Parameters.AddWithValue("@SpriteURL", spriteURL);
                cmd.ExecuteNonQuery();
            }
        }
    }
}