using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public class SeedGames
    {
        // Ensure this matches your App.config or DBHelper connection string
        // If you have DBHelper, use: private static string ConnectionString => DBHelper.ConnectionString;
        private static string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";

        public static void Run()
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    int gamesAdded = 0;

                    // 1. Master List with Actual Release Dates (North America/Worldwide)
                    var gamesList = new List<GameDataInternal>
                    {
                        // Gen 1 (Game Boy)
                        new GameDataInternal(1, "Pokemon Red", "Gen 1", "GB", "Kanto", new DateTime(1998, 9, 28)),
                        new GameDataInternal(2, "Pokemon Blue", "Gen 1", "GB", "Kanto", new DateTime(1998, 9, 28)),
                        new GameDataInternal(3, "Pokemon Yellow", "Gen 1", "GB", "Kanto", new DateTime(1999, 10, 18)),
                        
                        // Gen 2 (Game Boy Color)
                        new GameDataInternal(4, "Pokemon Gold", "Gen 2", "GBC", "Johto", new DateTime(2000, 10, 15)),
                        new GameDataInternal(5, "Pokemon Silver", "Gen 2", "GBC", "Johto", new DateTime(2000, 10, 15)),
                        new GameDataInternal(6, "Pokemon Crystal", "Gen 2", "GBC", "Johto", new DateTime(2001, 7, 29)),
                        
                        // Gen 3 (Game Boy Advance)
                        new GameDataInternal(7, "Pokemon Ruby", "Gen 3", "GBA", "Hoenn", new DateTime(2003, 3, 19)),
                        new GameDataInternal(8, "Pokemon Sapphire", "Gen 3", "GBA", "Hoenn", new DateTime(2003, 3, 19)),
                        new GameDataInternal(9, "Pokemon Emerald", "Gen 3", "GBA", "Hoenn", new DateTime(2005, 5, 1)),
                        new GameDataInternal(10, "Pokemon FireRed", "Gen 3", "GBA", "Kanto", new DateTime(2004, 9, 7)),
                        new GameDataInternal(11, "Pokemon LeafGreen", "Gen 3", "GBA", "Kanto", new DateTime(2004, 9, 7)),
                        
                        // Gen 4 (DS)
                        new GameDataInternal(12, "Pokemon Diamond", "Gen 4", "DS", "Sinnoh", new DateTime(2007, 4, 22)),
                        new GameDataInternal(13, "Pokemon Pearl", "Gen 4", "DS", "Sinnoh", new DateTime(2007, 4, 22)),
                        new GameDataInternal(14, "Pokemon Platinum", "Gen 4", "DS", "Sinnoh", new DateTime(2009, 3, 22)),
                        new GameDataInternal(15, "Pokemon HeartGold", "Gen 4", "DS", "Johto", new DateTime(2010, 3, 14)),
                        new GameDataInternal(16, "Pokemon SoulSilver", "Gen 4", "DS", "Johto", new DateTime(2010, 3, 14)),
                        
                        // Gen 5 (DS)
                        new GameDataInternal(17, "Pokemon Black", "Gen 5", "DS", "Unova", new DateTime(2011, 3, 6)),
                        new GameDataInternal(18, "Pokemon White", "Gen 5", "DS", "Unova", new DateTime(2011, 3, 6)),
                        new GameDataInternal(19, "Pokemon Black 2", "Gen 5", "DS", "Unova", new DateTime(2012, 10, 7)),
                        new GameDataInternal(20, "Pokemon White 2", "Gen 5", "DS", "Unova", new DateTime(2012, 10, 7)),
                        
                        // Gen 6 (3DS)
                        new GameDataInternal(21, "Pokemon X", "Gen 6", "3DS", "Kalos", new DateTime(2013, 10, 12)),
                        new GameDataInternal(22, "Pokemon Y", "Gen 6", "3DS", "Kalos", new DateTime(2013, 10, 12)),
                        new GameDataInternal(23, "Pokemon Omega Ruby", "Gen 6", "3DS", "Hoenn", new DateTime(2014, 11, 21)),
                        new GameDataInternal(24, "Pokemon Alpha Sapphire", "Gen 6", "3DS", "Hoenn", new DateTime(2014, 11, 21)),
                        
                        // Gen 7 (3DS / Switch)
                        new GameDataInternal(25, "Pokemon Sun", "Gen 7", "3DS", "Alola", new DateTime(2016, 11, 18)),
                        new GameDataInternal(26, "Pokemon Moon", "Gen 7", "3DS", "Alola", new DateTime(2016, 11, 18)),
                        new GameDataInternal(27, "Pokemon Ultra Sun", "Gen 7", "3DS", "Alola", new DateTime(2017, 11, 17)),
                        new GameDataInternal(28, "Pokemon Ultra Moon", "Gen 7", "3DS", "Alola", new DateTime(2017, 11, 17)),
                        new GameDataInternal(29, "Pokemon Let's Go Pikachu", "Gen 7", "Switch", "Kanto", new DateTime(2018, 11, 16)),
                        new GameDataInternal(30, "Pokemon Let's Go Eevee", "Gen 7", "Switch", "Kanto", new DateTime(2018, 11, 16)),
                        
                        // Gen 8 (Switch)
                        new GameDataInternal(31, "Pokemon Sword", "Gen 8", "Switch", "Galar", new DateTime(2019, 11, 15)),
                        new GameDataInternal(32, "Pokemon Shield", "Gen 8", "Switch", "Galar", new DateTime(2019, 11, 15)),
                        new GameDataInternal(33, "Pokemon Legends: Arceus", "Gen 8", "Switch", "Hisui", new DateTime(2022, 1, 28)),
                        new GameDataInternal(34, "Pokemon Brilliant Diamond", "Gen 8", "Switch", "Sinnoh", new DateTime(2021, 11, 19)),
                        new GameDataInternal(35, "Pokemon Shining Pearl", "Gen 8", "Switch", "Sinnoh", new DateTime(2021, 11, 19)),
                        
                        // Gen 9 (Switch)
                        new GameDataInternal(36, "Pokemon Scarlet", "Gen 9", "Switch", "Paldea", new DateTime(2022, 11, 18)),
                        new GameDataInternal(37, "Pokemon Violet", "Gen 9", "Switch", "Paldea", new DateTime(2022, 11, 18))
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
                                    cmd.Parameters.AddWithValue("@Date", game.ReleaseDate);
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
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Error: " + ex.Message);
                }
            }
        }

        // Internal helper class
        private class GameDataInternal
        {
            public int ID;
            public string Name;
            public string Generation;
            public string Platform;
            public string Region;
            public DateTime ReleaseDate;

            public GameDataInternal(int id, string name, string gen, string plat, string reg, DateTime date)
            {
                ID = id; Name = name; Generation = gen; Platform = plat; Region = reg; ReleaseDate = date;
            }
        }
    }
}