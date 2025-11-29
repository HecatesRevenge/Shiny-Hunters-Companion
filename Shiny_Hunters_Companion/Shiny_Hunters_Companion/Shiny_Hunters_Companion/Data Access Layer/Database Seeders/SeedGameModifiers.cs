using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;


namespace Shiny_Hunters_Companion
{
    public static class SeedGameModifiers
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

                    // 1. Shiny Charm (Standard) - ID 1
                    // Available in Gen 5 (BW2), Gen 6, Gen 7, Gen 8 (SwSh, BDSP), Gen 9
                    // NOT in: Gen 1-4, Let's Go, or PLA
                    LinkModifierToGenerations(conn, 1, new[] { "Gen 6", "Gen 7", "Gen 9" }, ref linksAdded);
                    LinkModifierToGames(conn, 1, new[] { 19, 20, 31, 32, 34, 35 }, ref linksAdded); // BW2 + SwSh + BDSP

                    // 2. Shiny Charm (PLA) - ID 2
                    LinkModifierToGames(conn, 2, new[] { 33 }, ref linksAdded); // Legends Arceus

                    // 3. Oval Charm - ID 3
                    // Available Gen 5 (BW2) onwards
                    LinkModifierToGenerations(conn, 3, new[] { "Gen 6", "Gen 7", "Gen 9" }, ref linksAdded);
                    LinkModifierToGames(conn, 3, new[] { 19, 20, 31, 32, 34, 35 }, ref linksAdded);

                    // 4. Mark Charm - ID 4
                    // Available Gen 8 (SwSh DLC), Gen 9
                    LinkModifierToGenerations(conn, 4, new[] { "Gen 9" }, ref linksAdded);
                    LinkModifierToGames(conn, 4, new[] { 31, 32 }, ref linksAdded);

                    // 10. Lure (Let's Go) - ID 10
                    LinkModifierToGames(conn, 10, new[] { 29, 30 }, ref linksAdded);

                    // 11-13. Sparkling Powers (SV) - IDs 11, 12, 13
                    int[] svIds = { 36, 37 };
                    LinkModifierToGames(conn, 11, svIds, ref linksAdded);
                    LinkModifierToGames(conn, 12, svIds, ref linksAdded);
                    LinkModifierToGames(conn, 13, svIds, ref linksAdded);

                    // 20. Diglett Bonus (BDSP) - ID 20
                    LinkModifierToGames(conn, 20, new[] { 34, 35 }, ref linksAdded);

                    // 21. Lucky Power (Gen 5) - ID 21
                    LinkModifierToGames(conn, 21, new[] { 17, 18, 19, 20 }, ref linksAdded); // BW + BW2

                    MessageBox.Show($"Successfully linked {linksAdded} Modifiers to Games.");
                }
                catch (Exception ex) { MessageBox.Show("Error Linking Modifiers: " + ex.Message); }
            }
        }

        // --- HELPERS ---

        private static void LinkModifierToGenerations(OleDbConnection conn, int modID, string[] generations, ref int counter)
        {
            foreach (string gen in generations)
            {
                var gameIds = new List<int>();
                using (OleDbCommand cmd = new OleDbCommand("SELECT GameID FROM tblGames WHERE Generation = @Gen", conn))
                {
                    cmd.Parameters.AddWithValue("@Gen", gen);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) gameIds.Add(reader.GetInt32(0));
                    }
                }
                LinkModifierToGames(conn, modID, gameIds.ToArray(), ref counter);
            }
        }

        private static void LinkModifierToGames(OleDbConnection conn, int modID, int[] gameIds, ref int counter)
        {
            using (OleDbCommand cmd = new OleDbCommand("", conn))
            {
                foreach (int gameID in gameIds)
                {
                    // Check if link exists
                    // We assume table is 'tblGameModifiers'
                    cmd.CommandText = "SELECT COUNT(*) FROM tblGameModifiers WHERE GameID_FK = @GID AND ModifierID_FK = @MID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@GID", gameID);
                    cmd.Parameters.AddWithValue("@MID", modID);

                    if ((int)cmd.ExecuteScalar() == 0)
                    {
                        cmd.CommandText = "INSERT INTO tblGameModifiers (GameID_FK, ModifierID_FK) VALUES (@GID, @MID)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@GID", gameID);
                        cmd.Parameters.AddWithValue("@MID", modID);
                        cmd.ExecuteNonQuery();
                        counter++;
                    }
                }
            }
        }
    }
}