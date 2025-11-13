using System;
using System.IO;
using System.Data.OleDb;
using System.Collections.Generic;


public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Pokémon data import...");

      
        DataImporter.RunImport();

        Console.WriteLine("...Import finished! Press any key to exit.");
        Console.ReadKey();
    }
}


public class DataImporter
{
    //were the database is located
    private static string _connectionString =
        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Downloads\reactObjList_Sample\reactObjList_Sample\Shiny-Hunters-Companion\Database\ShinyHuntersCompanion.accdb";

    //Update to import pokemon from a csv file
    private static string _csvFilePath = @"H:\3309\PokemonDataStuff\CompletePokemonCSV.csv";


    private static Dictionary<string, int> _pokemonCache = new Dictionary<string, int>();

    public static void RunImport()
    {
        if (!File.Exists(_csvFilePath))
        {
            Console.WriteLine($"ERROR: Cannot find CSV file at: {_csvFilePath}");
            return;
        }

        string[] allLines = File.ReadAllLines(_csvFilePath);

        for (int i = 1; i < allLines.Length; i++)
        {
            string line = allLines[i];

            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] columns = line.Split(',');

            try
            {
                int pokedexNum = int.Parse(columns[0]);
                string baseName = columns[1];
                string formName = columns[2];
                string displayName = columns[3];
                string spriteURL = columns[4];

                int parentPokemonID = GetOrCreateParentPokemon(baseName, pokedexNum);
                InsertPokemonForm(parentPokemonID, formName, displayName, spriteURL);

                Console.WriteLine($"Successfully imported: {displayName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to import line {i + 1}: '{line}'. Error: {ex.Message}");
            }
        }
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