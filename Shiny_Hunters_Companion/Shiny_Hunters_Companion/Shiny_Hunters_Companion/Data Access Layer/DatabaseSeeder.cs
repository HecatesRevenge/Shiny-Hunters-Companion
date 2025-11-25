using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public static class DatabaseSeeder
    {
      

        public static void SeedGames()
        {
            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;"))
            {
                conn.Open();
                int gamesAdded = 0;

                // 1. Define the Master List of Games
                // Format: ID, Name, Generation, Platform, Region
                var gamesList = new List<GameDataInternal>
                {
                    // Gen 1
                    new GameDataInternal(1, "Pokemon Red", "Gen 1", "GB", "Kanto"),
                    new GameDataInternal(2, "Pokemon Blue", "Gen 1", "GB", "Kanto"),
                    new GameDataInternal(3, "Pokemon Yellow", "Gen 1", "GB", "Kanto"),
                    // Gen 2
                    new GameDataInternal(4, "Pokemon Gold", "Gen 2", "GBC", "Johto"),
                    new GameDataInternal(5, "Pokemon Silver", "Gen 2", "GBC", "Johto"),
                    new GameDataInternal(6, "Pokemon Crystal", "Gen 2", "GBC", "Johto"),
                    // Gen 3
                    new GameDataInternal(7, "Pokemon Ruby", "Gen 3", "GBA", "Hoenn"),
                    new GameDataInternal(8, "Pokemon Sapphire", "Gen 3", "GBA", "Hoenn"),
                    new GameDataInternal(9, "Pokemon Emerald", "Gen 3", "GBA", "Hoenn"),
                    new GameDataInternal(10, "Pokemon FireRed", "Gen 3", "GBA", "Kanto"),
                    new GameDataInternal(11, "Pokemon LeafGreen", "Gen 3", "GBA", "Kanto"),
                    // Gen 4
                    new GameDataInternal(12, "Pokemon Diamond", "Gen 4", "DS", "Sinnoh"),
                    new GameDataInternal(13, "Pokemon Pearl", "Gen 4", "DS", "Sinnoh"),
                    new GameDataInternal(14, "Pokemon Platinum", "Gen 4", "DS", "Sinnoh"),
                    new GameDataInternal(15, "Pokemon HeartGold", "Gen 4", "DS", "Johto"),
                    new GameDataInternal(16, "Pokemon SoulSilver", "Gen 4", "DS", "Johto"),
                    // Gen 5
                    new GameDataInternal(17, "Pokemon Black", "Gen 5", "DS", "Unova"),
                    new GameDataInternal(18, "Pokemon White", "Gen 5", "DS", "Unova"),
                    new GameDataInternal(19, "Pokemon Black 2", "Gen 5", "DS", "Unova"),
                    new GameDataInternal(20, "Pokemon White 2", "Gen 5", "DS", "Unova"),
                    // Gen 6
                    new GameDataInternal(21, "Pokemon X", "Gen 6", "3DS", "Kalos"),
                    new GameDataInternal(22, "Pokemon Y", "Gen 6", "3DS", "Kalos"),
                    new GameDataInternal(23, "Pokemon Omega Ruby", "Gen 6", "3DS", "Hoenn"),
                    new GameDataInternal(24, "Pokemon Alpha Sapphire", "Gen 6", "3DS", "Hoenn"),
                    // Gen 7
                    new GameDataInternal(25, "Pokemon Sun", "Gen 7", "3DS", "Alola"),
                    new GameDataInternal(26, "Pokemon Moon", "Gen 7", "3DS", "Alola"),
                    new GameDataInternal(27, "Pokemon Ultra Sun", "Gen 7", "3DS", "Alola"),
                    new GameDataInternal(28, "Pokemon Ultra Moon", "Gen 7", "3DS", "Alola"),
                    new GameDataInternal(29, "Pokemon Let's Go Pikachu", "Gen 7", "Switch", "Kanto"),
                    new GameDataInternal(30, "Pokemon Let's Go Eevee", "Gen 7", "Switch", "Kanto"),
                    // Gen 8
                    new GameDataInternal(31, "Pokemon Sword", "Gen 8", "Switch", "Galar"),
                    new GameDataInternal(32, "Pokemon Shield", "Gen 8", "Switch", "Galar"),
                    new GameDataInternal(33, "Pokemon Legends: Arceus", "Gen 8", "Switch", "Hisui"),
                    new GameDataInternal(34, "Pokemon Brilliant Diamond", "Gen 8", "Switch", "Sinnoh"),
                    new GameDataInternal(35, "Pokemon Shining Pearl", "Gen 8", "Switch", "Sinnoh"),
                    // Gen 9
                    new GameDataInternal(36, "Pokemon Scarlet", "Gen 9", "Switch", "Paldea"),
                    new GameDataInternal(37, "Pokemon Violet", "Gen 9", "Switch", "Paldea")
                };

                using (OleDbTransaction trans = conn.BeginTransaction())
                using (OleDbCommand cmd = new OleDbCommand("", conn, trans))
                {
                    try
                    {
                        foreach (var game in gamesList)
                        {
                            // Check if GameID exists
                            cmd.CommandText = "SELECT COUNT(*) FROM tblGames WHERE GameID = @ID";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ID", game.ID);

                            int count = (int)cmd.ExecuteScalar();

                            if (count == 0)
                            {
                                // Insert if new
                                cmd.CommandText = @"INSERT INTO tblGames 
                                (GameID, GameName, Generation, Platform, RegionName, ReleaseDate, BoxArtURL) 
                                VALUES (@ID, @Name, @Gen, @Plat, @Reg, @Date, @Url)";

                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ID", game.ID);
                                cmd.Parameters.AddWithValue("@Name", game.Name);
                                cmd.Parameters.AddWithValue("@Gen", game.Generation);
                                cmd.Parameters.AddWithValue("@Plat", game.Platform);
                                cmd.Parameters.AddWithValue("@Reg", game.Region);
                                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString()); // Placeholder date
                                cmd.Parameters.AddWithValue("@Url", ""); // Placeholder URL

                                cmd.ExecuteNonQuery();
                                gamesAdded++;
                            }
                        }
                        trans.Commit();
                        MessageBox.Show($"Success! Added {gamesAdded} new Games to the database.");
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Error Seeding Games: " + ex.Message);
                    }
                }
            }
        }

        // Internal helper class just for this seeder
        private class GameDataInternal
        {
            public int ID;
            public string Name;
            public string Generation;
            public string Platform;
            public string Region;

            public GameDataInternal(int id, string name, string gen, string plat, string reg)
            {
                ID = id; Name = name; Generation = gen; Platform = plat; Region = reg;
            }
        }
    }
}