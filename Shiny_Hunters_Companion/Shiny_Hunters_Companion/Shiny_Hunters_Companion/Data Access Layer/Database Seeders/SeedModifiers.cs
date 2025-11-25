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
                    int count = 0;

                    var items = new List<ModifierData>
                    {
                        // --- KEY ITEMS ---
                        new ModifierData(1, "Shiny Charm (Standard)", 3.0, "Key Item. Available in Gen 5+. Adds 2 extra shiny rolls to encounters (approx 3x odds)."),
                        new ModifierData(2, "Shiny Charm (PLA)", 4.0, "Key Item. In Legends: Arceus, the charm adds 3 extra rolls instead of the standard 2 (4x odds)."),
                        new ModifierData(3, "Oval Charm", 1.0, "Key Item. Increases the speed of finding Eggs at the Nursery. Does NOT affect shiny odds."),
                        new ModifierData(4, "Mark Charm", 1.0, "Key Item. Increases the chance of finding Pokemon with Marks. Does NOT affect shiny odds."),

                        // --- CONSUMABLES (Gen 7.5 - Let's Go) ---
                        new ModifierData(10, "Lure (Let's Go)", 2.0, "Consumable. Using any Lure (Standard, Super, Max) in Let's Go adds 1 extra shiny roll (2x odds)."),

                        // --- CONSUMABLES (Gen 9 - Scarlet/Violet) ---
                        new ModifierData(11, "Sparkling Power Lv. 1 (SV)", 2.0, "Sandwich Power. Adds 1 extra shiny roll (2x odds)."),
                        new ModifierData(12, "Sparkling Power Lv. 2 (SV)", 3.0, "Sandwich Power. Adds 2 extra shiny rolls (3x odds)."),
                        new ModifierData(13, "Sparkling Power Lv. 3 (SV)", 4.0, "Sandwich Power. Adds 3 extra shiny rolls (4x odds)."),

                        // --- WORLD STATES / POWERS ---
                        new ModifierData(20, "Diglett Bonus (BDSP)", 2.0, "Active State. After collecting 40 Digletts in the Grand Underground, shiny odds double (1/2048) for 4 minutes."),
                        new ModifierData(21, "Lucky Power S (Gen 5)", 2.0, "Pass Power. In Black 2/White 2, this Pass Power increases the shiny rate of wild encounters (approx 2x).")
                    };

                    using (OleDbCommand cmd = new OleDbCommand("", conn))
                    {
                        foreach (var item in items)
                        {
                            cmd.CommandText = "SELECT COUNT(*) FROM tblModifiers WHERE ModifierID = @ID";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ID", item.ID);

                            if ((int)cmd.ExecuteScalar() == 0)
                            {
                                cmd.CommandText = "INSERT INTO tblModifiers (ModifierID, ModifierName, OddsMultiplier, Description) VALUES (@ID, @Name, @Mult, @Desc)";
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

        private class ModifierData
        {
            public int ID; public string Name; public double Multi; public string Desc;
            public ModifierData(int id, string name, double multi, string desc)
            { ID = id; Name = name; Multi = multi; Desc = desc; }
        }
    }
}