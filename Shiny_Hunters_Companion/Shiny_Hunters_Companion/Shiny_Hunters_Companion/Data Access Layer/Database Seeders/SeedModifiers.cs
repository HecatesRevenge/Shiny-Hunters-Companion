using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public static class SeedModifiers
    {
        private static string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";

        public static void Run()
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    // DIAGNOSTIC: Check for the Table and Columns
                    // We try to select one column at a time. If it fails, we know THAT name is wrong.

                    // 1. Check Table Name (and ID)
                    // If your table is named 'tblModifers' (missing i), change this line to match!
                    string tableName = "tblModifiers";

                    CheckColumn(conn, tableName, "ModifierID");
                    CheckColumn(conn, tableName, "ModifierName");
                    CheckColumn(conn, tableName, "OddsMultiplier"); // <--- Check spelling carefully!
                    CheckColumn(conn, tableName, "Description");     // <--- Check if it's "ModifierDescription"

                    // If diagnostics pass, run the real code...
                    int count = 0;
                    var items = new List<ModifierData>
            {
                new ModifierData(1, "Shiny Charm (Standard)", 3.0, "Key Item. Available in Gen 5+. Adds 2 extra shiny rolls."),
                new ModifierData(2, "Shiny Charm (PLA)", 4.0, "Key Item. In Legends: Arceus, adds 3 extra rolls."),
                new ModifierData(3, "Oval Charm", 1.0, "Key Item. Increases egg production speed."),
                new ModifierData(4, "Mark Charm", 1.0, "Key Item. Increases chance of finding Marks."),
                new ModifierData(10, "Lure (Let's Go)", 2.0, "Consumable. Adds 1 extra shiny roll."),
                new ModifierData(11, "Sparkling Power Lv. 1 (SV)", 2.0, "Sandwich Power. Adds 1 extra shiny roll."),
                new ModifierData(12, "Sparkling Power Lv. 2 (SV)", 3.0, "Sandwich Power. Adds 2 extra shiny rolls."),
                new ModifierData(13, "Sparkling Power Lv. 3 (SV)", 4.0, "Sandwich Power. Adds 3 extra shiny rolls."),
                new ModifierData(20, "Diglett Bonus (BDSP)", 2.0, "Active State. 40 Digletts doubles shiny odds."),
                new ModifierData(21, "Lucky Power S (Gen 5)", 2.0, "Pass Power. Increases shiny rate of wild encounters.")
            };

                    using (OleDbCommand cmd = new OleDbCommand("", conn))
                    {
                        foreach (var item in items)
                        {
                            // Check if exists
                            cmd.CommandText = $"SELECT COUNT(*) FROM {tableName} WHERE ModifierID = @ID";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ID", item.ID);

                            if ((int)cmd.ExecuteScalar() == 0)
                            {
                                // Insert if new
                                cmd.CommandText = $"INSERT INTO {tableName} (ModifierID, ModifierName, OddsMultiplier, Description) VALUES (@ID, @Name, @Mult, @Desc)";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ID", item.ID);
                                cmd.Parameters.AddWithValue("@Name", item.Name);
                                cmd.Parameters.AddWithValue("@Mult", item.Multi);
                                cmd.Parameters.AddWithValue("@Desc", item.Desc);
                                cmd.ExecuteNonQuery();
                                count++;
                            }
                        }
                    }
                    MessageBox.Show($"Seeded {count} Modifiers.");
                }
                catch (Exception ex) { MessageBox.Show("Error Seeding Modifiers: " + ex.Message); }
            }
        }

        // Helper to check columns
        private static void CheckColumn(OleDbConnection conn, string table, string col)
        {
            try
            {
                using (OleDbCommand cmd = new OleDbCommand($"SELECT TOP 1 [{col}] FROM [{table}]", conn))
                {
                    cmd.ExecuteReader();
                }
                System.Diagnostics.Debug.WriteLine($"[PASS] Column '{col}' found.");
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine($"!!! FAILURE !!! Column '{col}' is MISSING or MISSPELLED in table '{table}'.");
                throw new Exception($"Fix the column: {col}");
            }
        }

        private class ModifierData
        {
            public int ID; public string Name; public double Multi; public string Desc;
            public ModifierData(int id, string name, double multi, string desc)
            { ID = id; Name = name; Multi = multi; Desc = desc; }
        }
    }
}