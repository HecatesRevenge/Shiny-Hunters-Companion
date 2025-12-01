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
                    int modifiersAdded = 0;

                    var modifiers = new List<PlayerModifier>
                    {
                        // Standard Shiny Charm (Gen 5+, not PLA/Let's Go)
                        new PlayerModifier(1, "Shiny Charm", 3.0, "Key Item that increases the chance of finding a Shiny Pokemon."),
                        
                        // PLA Shiny Charm (Different mechanics often warrant a separate entry or just treated as same ID if logic allows)
                        new PlayerModifier(2, "Shiny Charm (PLA)", 3.0, "Increases shiny odds in Hisui. Requires Pokedex level 10 for all entries."),
                        
                        // Oval Charm (Gen 5+) - Increases egg production, technically not shiny odds but often tracked
                        new PlayerModifier(3, "Oval Charm", 1.0, "Increases the chance of finding an Egg at the Nursery."),
                        
                        // Mark Charm (Gen 8+) - Increases mark chance, not shiny odds
                        new PlayerModifier(4, "Mark Charm", 1.0, "Increases the chance of finding a Pokemon with a Mark."),

                        // Let's Go Lure
                        new PlayerModifier(10, "Lure (Let's Go)", 2.0, "Increases shiny odds while active in Let's Go Pikachu/Eevee."),

                        // Scarlet/Violet Sandwiches (Sparkling Power)
                        // Note: These add rolls (Lv1=+1, Lv2=+2, Lv3=+3). 
                        // If your math logic is BaseOdds / Multiplier, Lv3 is roughly 4x odds (1 base + 3 rolls).
                        new PlayerModifier(11, "Sparkling Power Lv. 1", 2.0, "Sandwich power. Adds 1 extra shiny roll."),
                        new PlayerModifier(12, "Sparkling Power Lv. 2", 3.0, "Sandwich power. Adds 2 extra shiny rolls."),
                        new PlayerModifier(13, "Sparkling Power Lv. 3", 4.0, "Sandwich power. Adds 3 extra shiny rolls."),

                        // BDSP Diglett Bonus
                        new PlayerModifier(20, "Diglett Bonus", 2.0, "Slightly increases shiny odds in the Grand Underground when 40 Digletts are collected."),

                        // Gen 5 Pass Power
                        new PlayerModifier(21, "Lucky Power", 1.5, "Pass Power that increases the chance of finding a Shiny Pokemon.")
                    };

                    using (OleDbCommand cmd = new OleDbCommand("", conn))
                    {
                        foreach (var mod in modifiers)
                        {
                            // Check if exists
                            cmd.CommandText = "SELECT COUNT(*) FROM tblModifiers WHERE ModifierID = @ID";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ID", mod.ModifierID);

                            if ((int)cmd.ExecuteScalar() == 0)
                            {
                                cmd.CommandText = "INSERT INTO tblModifiers (ModifierID, ModifierName, OddsMultiplier, Description) VALUES (@ID, @Name, @Odds, @Desc)";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ID", mod.ModifierID);
                                cmd.Parameters.AddWithValue("@Name", mod.ModifierName);
                                cmd.Parameters.AddWithValue("@Odds", mod.OddsMultiplier);
                                cmd.Parameters.AddWithValue("@Desc", mod.Description);
                                cmd.ExecuteNonQuery();
                                modifiersAdded++;
                            }
                        }
                    }
                    MessageBox.Show($"Success! Added {modifiersAdded} new Modifiers.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Seeding Modifiers: " + ex.Message);
                }
            }
        }
    }
}