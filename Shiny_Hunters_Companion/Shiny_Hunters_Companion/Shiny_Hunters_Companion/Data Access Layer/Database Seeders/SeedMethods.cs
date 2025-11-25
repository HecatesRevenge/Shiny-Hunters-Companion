using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public static class SeedMethods
    {
        // Ensure this matches your connection string
        private static string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";

        public static void Run()
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    int count = 0;

                    var methods = new List<MethodData>
                    {
                        // --- STANDARD ENCOUNTERS ---
                        new MethodData(1, "Full Odds (Gen 2-5)", 8192, 0, "Standard wild encounter in older games."),
                        new MethodData(2, "Full Odds (Gen 6-9)", 4096, 0, "Standard wild encounter in modern games."),
                        
                        // --- BREEDING METHODS ---
                        new MethodData(3, "Breeding (Gen 2 Shiny Parent)", 64, 0, "Breeding with a shiny parent in Gen 2 yields incredibly high odds (1/64)."),
                        new MethodData(4, "Masuda Method (Gen 4-5)", 1638, 0, "Breeding two Pokemon from different languages (Old Odds)."),
                        new MethodData(5, "Masuda Method (Gen 6+)", 683, 0, "Breeding two Pokemon from different languages (Modern Odds)."),
                        new MethodData(6, "Odd Egg (Crystal)", 7, 0, "The special egg received from the Day Care Man has a 14% shiny chance."),

                        // --- GENERATION 4 (DPPt/HGSS) ---
                        new MethodData(7, "Pokeradar (Gen 4 - Chain 40)", 200, 0, "Reaching a chain of 40 with the Pokeradar maximizes odds to 1/200."),
                        new MethodData(8, "Cute Charm Glitch (Gen 4)", 5, 0, "Using a specific TID/SID combo allows Cute Charm to force shiny encounters (approx 21%)."),

                        // --- GENERATION 6 (XY/ORAS) ---
                        new MethodData(9, "Chain Fishing (Gen 6)", 100, 0, "Consecutive successful hooks increase odds (Max at chain 20)."),
                        new MethodData(10, "Friend Safari (XY)", 512, 0, "Encounters in the Friend Safari have a flat 1/512 shiny rate."),
                        new MethodData(11, "Horde Encounter (Gen 6)", 4096, 0, "Encounters 5 Pokemon at once. Base odds apply to each, effectively 5x faster."),
                        new MethodData(12, "DexNav (ORAS)", 512, 0, "Using DexNav search provides a flat boost plus Chain bonuses."),

                        // --- GENERATION 7 (SM/USUM) ---
                        new MethodData(13, "SOS Calling (Gen 7 - Chain 31+)", 273, 0, "After calling 30 allies, the odds maximize at approx 1/273."),
                        new MethodData(14, "Ultra Wormhole (USUM)", 100, 0, "Traveling far into the wormhole increases odds up to 36% for non-legendaries."),
                        
                        // --- GENERATION 7.5 (Let's Go Pikachu/Eevee) ---
                        new MethodData(15, "Catch Combo 31+ (LGPE)", 341, 0, "Catching 31 of the same species maximizes spawn odds."),

                        // --- GENERATION 8 (Sword/Shield) ---
                        new MethodData(16, "Number Battled 500+ (SwSh)", 512, 0, "Defeating 500+ of a species gives a chance for extra shiny rolls (Brilliant Aura)."),
                        new MethodData(17, "Dynamax Adventures (SwSh)", 300, 0, "1/300 base odds for all Pokemon including Legendaries (1/100 with Charm)."),
                        
                        // --- GENERATION 8 (BDSP) ---
                        new MethodData(18, "Pokeradar (BDSP - Chain 40)", 99, 0, "Reaching a chain of 40 in the remakes grants 1/99 odds."),
                        new MethodData(19, "Grand Underground (Diglett Bonus)", 2048, 0, "Collecting 40 Digletts boosts odds to 1/2048 for 4 minutes."),

                        // --- GENERATION 8 (Legends: Arceus) ---
                        new MethodData(20, "Mass Outbreak (PLA)", 158, 0, "Standard Mass Outbreak odds."),
                        new MethodData(21, "Massive Mass Outbreak (PLA)", 315, 0, "Slightly lower odds than standard outbreaks, but more variety."),
                        new MethodData(22, "Research Level 10 (PLA)", 2048, 0, "Completing Pokedex tasks to Level 10 doubles the shiny roll."),
                        new MethodData(23, "Research Perfect (PLA)", 1024, 0, "Completing all tasks for a species quadruples the shiny roll."),

                        // --- GENERATION 9 (Scarlet/Violet) ---
                        new MethodData(24, "Mass Outbreak 60+ (SV)", 1365, 0, "Defeating 60 Pokemon in an outbreak grants +2 shiny rolls."),
                        new MethodData(25, "Sandwich Sparkling Power 3 (SV)", 1024, 0, "Eating a Sparkling Power Lv. 3 sandwich grants +3 shiny rolls."),
                        new MethodData(26, "Tera Raid Battle (SV)", 4103, 0, "Fixed odds for Tera Raids (Shiny Charm does not apply)."),
                        new MethodData(27, "Isolated Encounter (SV)", 4096, 0, "Using type sandwiches to force specific spawns (Standard odds, but high volume).")
                    };

                    using (OleDbCommand cmd = new OleDbCommand("", conn))
                    {
                        foreach (var m in methods)
                        {
                            // Check if exists
                            cmd.CommandText = "SELECT COUNT(*) FROM tblMethods WHERE MethodID = @ID";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ID", m.ID);

                            if ((int)cmd.ExecuteScalar() == 0)
                            {
                                cmd.CommandText = "INSERT INTO tblMethods (MethodID, MethodName, BaseOdds, OddsModifier, Description) VALUES (@ID, @Name, @Odds, @Mod, @Desc)";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ID", m.ID);
                                cmd.Parameters.AddWithValue("@Name", m.Name);
                                cmd.Parameters.AddWithValue("@Odds", m.BaseOdds);
                                cmd.Parameters.AddWithValue("@Mod", m.Modifier);
                                cmd.Parameters.AddWithValue("@Desc", m.Desc);
                                cmd.ExecuteNonQuery();
                                count++;
                            }
                        }
                    }
                    MessageBox.Show($"Seeded {count} Hunting Methods.");
                }
                catch (Exception ex) { MessageBox.Show("Error Seeding Methods: " + ex.Message); }
            }
        }

        private class MethodData
        {
            public int ID; public string Name; public int BaseOdds; public int Modifier; public string Desc;
            public MethodData(int id, string name, int odds, int mod, string desc)
            { ID = id; Name = name; BaseOdds = odds; Modifier = mod; Desc = desc; }
        }
    }
}