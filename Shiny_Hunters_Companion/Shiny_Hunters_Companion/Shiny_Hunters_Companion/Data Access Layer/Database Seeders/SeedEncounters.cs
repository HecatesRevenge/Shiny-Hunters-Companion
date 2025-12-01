using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public static class SeedEncounters
    {
        // Ensure this matches your App.config connection string
        private static string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";

        public static void Run()
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    int totalEncounters = 0;

                    // 1. FETCH REFERENCE LISTS
                    // Load lookup data into memory to avoid repeated DB calls

                    // Games: (ID, Generation, Name)
                    var games = new List<(int ID, string Gen, string Name)>();
                    using (var cmd = new OleDbCommand("SELECT GameID, Generation, GameName FROM tblGames", conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read()) games.Add((reader.GetInt32(0), reader["Generation"].ToString(), reader["GameName"].ToString()));

                    // Methods: (ID, Name)
                    var methods = new List<(int ID, string Name)>();
                    using (var cmd = new OleDbCommand("SELECT MethodID, MethodName FROM tblMethods", conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read()) methods.Add((reader.GetInt32(0), reader["MethodName"].ToString()));

                    // Forms: (FormID, DexNum, FormName)
                    var forms = new List<(int ID, int DexNum, string FormName)>();
                    using (var cmd = new OleDbCommand("SELECT f.FormID, p.PokedexNumber, f.FormName FROM tblPokemonForms f INNER JOIN tblPokemon p ON f.PokemonID_FK = p.PokemonID", conn))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read()) forms.Add((reader.GetInt32(0), reader.GetInt32(1), reader["FormName"].ToString()));


                    // 2. THE BIG LOOP
                    // Iterate: Game -> Method -> Form

                    using (OleDbTransaction trans = conn.BeginTransaction())
                    using (OleDbCommand cmd = new OleDbCommand("", conn, trans))
                    {
                        try
                        {
                            foreach (var game in games)
                            {
                                int maxDex = GetMaxDexForGen(game.Gen);

                                foreach (var method in methods)
                                {
                                    // FILTER 1: Is this Method valid for this Game Generation?
                                    if (!IsMethodValidForGame(method.Name, game.Gen, game.Name)) continue;

                                    foreach (var form in forms)
                                    {
                                        // FILTER 2: Is this Pokemon valid for this Game Generation?
                                        // e.g., No Gen 5 mons in Gen 1 games
                                        if (form.DexNum > maxDex) continue;

                                        // FILTER 3: Form Specific Logic
                                        // e.g., Alolan forms only in Gen 7+, Galarian in Gen 8+, Hisuian in PLA/Gen 9
                                        if (!IsFormValidForGen(form.FormName, game.Gen)) continue;

                                        // Insert the Link
                                        // We use a try-catch block inside the loop to effectively "INSERT IGNORE"
                                        // This prevents the entire transaction from failing if one duplicate exists.

                                        cmd.CommandText = "INSERT INTO tblEncounters (GameID_FK, MethodID_FK, FormID_FK) VALUES (@GID, @MID, @FID)";
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("@GID", game.ID);
                                        cmd.Parameters.AddWithValue("@MID", method.ID);
                                        cmd.Parameters.AddWithValue("@FID", form.ID);

                                        try
                                        {
                                            cmd.ExecuteNonQuery();
                                            totalEncounters++;
                                        }
                                        catch
                                        {
                                            // Ignore duplicates or constraint violations silently to keep speed up
                                        }
                                    }
                                }
                            }
                            trans.Commit();
                            MessageBox.Show($"Successfully seeded {totalEncounters} Encounters!\nYour database is now fully populated.");
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Error Seeding Encounters: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed: " + ex.Message);
                }
            }
        }

        // --- LOGIC HELPERS ---

        private static int GetMaxDexForGen(string gen)
        {
            // Limits the Pokedex number based on the Game's Generation
            switch (gen)
            {
                case "Gen 1": return 151;
                case "Gen 2": return 251;
                case "Gen 3": return 386;
                case "Gen 4": return 493;
                case "Gen 5": return 649;
                case "Gen 6": return 721;
                case "Gen 7": return 809;
                default: return 1025; // Gen 8, 9, etc.
            }
        }

        private static bool IsMethodValidForGame(string methodName, string gameGen, string gameName)
        {
            // Filters methods so they only appear in relevant games

            // Gen 2 Specifics (Breeding / Odd Egg)
            if (methodName.Contains("Breeding (Gen 2") && gameGen != "Gen 2") return false;
            if (methodName.Contains("Odd Egg") && !gameName.Contains("Crystal")) return false;

            // Gen 4 Specifics (Pokeradar)
            if (methodName.Contains("Pokeradar (Gen 4") && gameGen != "Gen 4") return false;
            if (methodName.Contains("Cute Charm") && gameGen != "Gen 4") return false;

            // Gen 5 Specifics (Masuda Old)
            if (methodName.Contains("Masuda Method (Gen 4-5)") && (gameGen != "Gen 4" && gameGen != "Gen 5")) return false;

            // Gen 6 Specifics (Chain Fishing, DexNav, Friend Safari)
            if (methodName.Contains("Chain Fishing") && gameGen != "Gen 6") return false;
            if (methodName.Contains("Friend Safari") && (gameGen != "Gen 6" || gameName.Contains("Omega"))) return false; // XY Only
            if (methodName.Contains("DexNav") && (gameGen != "Gen 6" || gameName.Contains("X") || gameName.Contains("Y"))) return false; // ORAS Only
            if (methodName.Contains("Horde") && gameGen != "Gen 6") return false;

            // Gen 7 Specifics (SOS, Wormhole)
            if (methodName.Contains("Ultra Wormhole") && (gameGen != "Gen 7" || gameName.Contains("Sun") || gameName.Contains("Moon") && !gameName.Contains("Ultra"))) return false; // USUM Only
            if (methodName.Contains("SOS") && gameGen != "Gen 7") return false;

            // Let's Go
            if (methodName.Contains("Catch Combo") && !gameName.Contains("Let's Go")) return false;

            // Gen 8 Specifics (SwSh)
            if (methodName.Contains("Number Battled") && !gameName.Contains("Sword") && !gameName.Contains("Shield")) return false;
            if (methodName.Contains("Dynamax Adventure") && !gameName.Contains("Sword") && !gameName.Contains("Shield")) return false;

            // Gen 8 Specifics (BDSP)
            if (methodName.Contains("Grand Underground") && !gameName.Contains("Brilliant") && !gameName.Contains("Shining")) return false;
            if (methodName.Contains("Pokeradar (BDSP") && !gameName.Contains("Brilliant") && !gameName.Contains("Shining")) return false;

            // Gen 8 Specifics (PLA)
            if (methodName.Contains("(PLA)") && !gameName.Contains("Legends")) return false;

            // Gen 9 Specifics (SV)
            if (methodName.Contains("(SV)") && gameGen != "Gen 9") return false;

            // General "Full Odds" separation
            if (methodName.Contains("Gen 2-5") && (gameGen == "Gen 6" || gameGen == "Gen 7" || gameGen == "Gen 8" || gameGen == "Gen 9")) return false;
            if (methodName.Contains("Gen 6-9") && (gameGen == "Gen 1" || gameGen == "Gen 2" || gameGen == "Gen 3" || gameGen == "Gen 4" || gameGen == "Gen 5")) return false;

            return true;
        }

        private static bool IsFormValidForGen(string formName, string gameGen)
        {
            // Regional Form Logic
            if (formName.Contains("Alolan"))
            {
                // Alolan forms exist in Gen 7, Let's Go (Gen 7.5), Gen 8, Gen 9
                if (gameGen == "Gen 1" || gameGen == "Gen 2" || gameGen == "Gen 3" || gameGen == "Gen 4" || gameGen == "Gen 5" || gameGen == "Gen 6") return false;
            }

            if (formName.Contains("Galarian"))
            {
                // Galarian forms exist in Gen 8, Gen 9
                if (gameGen != "Gen 8" && gameGen != "Gen 9") return false;
            }

            if (formName.Contains("Hisuian"))
            {
                // Hisuian forms exist in PLA (Gen 8) and Gen 9
                if (gameGen != "Gen 8" && gameGen != "Gen 9") return false;
            }

            if (formName.Contains("Paldean"))
            {
                // Paldean forms exist only in Gen 9
                if (gameGen != "Gen 9") return false;
            }

            return true;
        }
    }
}