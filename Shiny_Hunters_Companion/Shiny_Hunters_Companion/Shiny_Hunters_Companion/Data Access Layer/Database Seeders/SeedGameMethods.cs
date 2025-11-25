using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public static class SeedGameMethods
    {
        private static string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";

        public static void Run()
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    int linksAdded = 0;

                    // We use a dictionary to map Methods (by ID) to specific Generations/Games
                    // NOTE: These IDs must match what you defined in SeedMethods.cs

                    // 1. Link "Full Odds (Old)" (ID 1) to Gen 2-5
                    LinkMethodToGenerations(conn, 1, new[] { "Gen 2", "Gen 3", "Gen 4", "Gen 5" }, ref linksAdded);

                    // 2. Link "Full Odds (New)" (ID 2) to Gen 6-9
                    LinkMethodToGenerations(conn, 2, new[] { "Gen 6", "Gen 7", "Gen 8", "Gen 9" }, ref linksAdded);

                    // 3. Masuda Method (Old) (ID 4) -> Gen 4, 5
                    LinkMethodToGenerations(conn, 4, new[] { "Gen 4", "Gen 5" }, ref linksAdded);

                    // 4. Masuda Method (New) (ID 5) -> Gen 6, 7, 8, 9
                    LinkMethodToGenerations(conn, 5, new[] { "Gen 6", "Gen 7", "Gen 8", "Gen 9" }, ref linksAdded);

                    // --- SPECIFIC MECHANICS ---

                    // Pokeradar (Gen 4) (ID 7) -> Diamond, Pearl, Platinum
                    LinkMethodToGames(conn, 7, new[] { 12, 13, 14, 34, 35 }, ref linksAdded); // DPPt + BDSP

                    // Chain Fishing (ID 9) -> Gen 6 (XY, ORAS)
                    LinkMethodToGenerations(conn, 9, new[] { "Gen 6" }, ref linksAdded);

                    // Friend Safari (ID 10) -> Pokemon X (21), Pokemon Y (22)
                    LinkMethodToGames(conn, 10, new[] { 21, 22 }, ref linksAdded);

                    // DexNav (ID 12) -> Omega Ruby (23), Alpha Sapphire (24)
                    LinkMethodToGames(conn, 12, new[] { 23, 24 }, ref linksAdded);

                    // SOS Calling (ID 13) -> Gen 7 (Sun, Moon, US, UM)
                    LinkMethodToGenerations(conn, 13, new[] { "Gen 7" }, ref linksAdded);

                    // Catch Combo (ID 15) -> Let's Go Pikachu/Eevee
                    LinkMethodToGames(conn, 15, new[] { 29, 30 }, ref linksAdded);

                    // Dynamax Adventures (ID 17) -> Sword/Shield
                    LinkMethodToGames(conn, 17, new[] { 31, 32 }, ref linksAdded);

                    // Mass Outbreak PLA (ID 20) -> Legends Arceus
                    LinkMethodToGames(conn, 20, new[] { 33 }, ref linksAdded);

                    // Sandwich / Tera Raid (ID 25, 26) -> Scarlet/Violet
                    LinkMethodToGames(conn, 25, new[] { 36, 37 }, ref linksAdded);
                    LinkMethodToGames(conn, 26, new[] { 36, 37 }, ref linksAdded);

                    MessageBox.Show($"Successfully linked {linksAdded} Methods to Games.");
                }
                catch (Exception ex) { MessageBox.Show("Error Linking Games: " + ex.Message); }
            }
        }

        // Helper to link a method to entire Generations
        private static void LinkMethodToGenerations(OleDbConnection conn, int methodID, string[] generations, ref int counter)
        {
            foreach (string gen in generations)
            {
                // Find all games in this generation
                string getGamesSql = "SELECT GameID FROM tblGames WHERE Generation = @Gen";
                var gameIds = new List<int>();

                using (OleDbCommand cmd = new OleDbCommand(getGamesSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Gen", gen);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) gameIds.Add(reader.GetInt32(0));
                    }
                }

                // Link them
                LinkMethodToGames(conn, methodID, gameIds.ToArray(), ref counter);
            }
        }

        // Helper to link a method to specific Game IDs
        private static void LinkMethodToGames(OleDbConnection conn, int methodID, int[] gameIds, ref int counter)
        {
            using (OleDbCommand cmd = new OleDbCommand("", conn))
            {
                foreach (int gameID in gameIds)
                {
                    // Check if link exists
                    cmd.CommandText = "SELECT COUNT(*) FROM tblGameMethods WHERE GameID_FK = @GID AND MethodID_FK = @MID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@GID", gameID);
                    cmd.Parameters.AddWithValue("@MID", methodID);

                    if ((int)cmd.ExecuteScalar() == 0)
                    {
                        cmd.CommandText = "INSERT INTO tblGameMethods (GameID_FK, MethodID_FK) VALUES (@GID, @MID)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@GID", gameID);
                        cmd.Parameters.AddWithValue("@MID", methodID);
                        cmd.ExecuteNonQuery();
                        counter++;
                    }
                }
            }
        }
    }
}