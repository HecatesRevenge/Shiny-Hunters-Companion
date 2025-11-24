using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShinyCompanion.accdb;";
        private OleDbConnection myConnection;
        public Form1()
        {
            myConnection = new OleDbConnection(connectionString);
            InitializeComponent();
           
  
           RunSystemDiagnostics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Add these namespaces at the top

        private void RunSystemDiagnostics()
            {
        Debug.WriteLine("--- STARTING SYSTEM CHECK ---");

        try
        {
            // 1. TEST USER DATABASE
            Debug.WriteLine("1. Testing User Registration...");
            UserDB userDB = new UserDB();
            // Use a random name so you can run the test multiple times without "User Exists" error
            string testUser = "Tester_" + DateTime.Now.Ticks.ToString().Substring(10);
            bool regSuccess = userDB.RegisterUser(testUser, "password123");
            Debug.WriteLine($"   - Register Result: {regSuccess}");

            Debug.WriteLine("2. Testing Login...");
            User currentUser = userDB.VerifyLogin(testUser, "password123");
            if (currentUser != null)
            {
                Debug.WriteLine($"   - Login Success: Welcome ID {currentUser.UserID}");
            }
            else
            {
                Debug.WriteLine("   - Login FAILED.");
                return; // Stop test if login fails
            }

            // 2. TEST GAME & METHOD
            Debug.WriteLine("3. Testing Game Logic...");
            GameDB gameDB = new GameDB();
            List<Game> games = gameDB.GetAllGames();
            Debug.WriteLine($"   - Games Found: {games.Count}");

            if (games.Count == 0)
            {
                Debug.WriteLine("   ! STOPPING: No games in database. Add sample data.");
                return;
            }
            int testGameID = games[0].GameID; // Pick the first game found

            MethodDB methodDB = new MethodDB();
            List<Method> methods = methodDB.GetMethodsFromGame(testGameID);
            Debug.WriteLine($"   - Methods for Game {testGameID}: {methods.Count}");

            if (methods.Count == 0)
            {
                Debug.WriteLine("   ! STOPPING: No methods linked to this game. Check tblGameMethods.");
                return;
            }
            int testMethodID = methods[0].MethodID;

            // 3. TEST POKEMON FORMS (The Complex Query)
            Debug.WriteLine("4. Testing Pokemon Form Logic...");
            PokemonDB pokeDB = new PokemonDB();
            // This tests the critical "GetFormsByGameAndMethod" function
            List<PokemonForm> availableMons = pokeDB.GetFormsByGameAndMethod(testGameID, testMethodID);
            Debug.WriteLine($"   - Pokemon found for Game {testGameID} + Method {testMethodID}: {availableMons.Count}");

            if (availableMons.Count > 0)
            {
                Debug.WriteLine($"   - First Pokemon: {availableMons[0].DisplayName} (FormID: {availableMons[0].FormID})");
            }
            else
            {
                Debug.WriteLine("   ! WARNING: No Pokemon found. Check 'tblEncounters' table.");
            }

            // 4. TEST HUNT CREATION
            if (availableMons.Count > 0)
            {
                Debug.WriteLine("5. Testing Hunt Creation...");
                HuntDB huntDB = new HuntDB();
                Hunt newHunt = new Hunt
                {
                    UserID = currentUser.UserID,
                    GameID = testGameID,
                    MethodID = testMethodID,
                    FormID = availableMons[0].FormID, // Uses the FormID we just found
                    EncounterCount = 0,
                    isActive = true
                };

                int newHuntID = huntDB.CreateHunt(newHunt);
                Debug.WriteLine($"   - Hunt Created! ID: {newHuntID}");

                if (newHuntID != -1)
                {
                    // 5. TEST ACHIEVEMENT TRIGGER
                    Debug.WriteLine("6. Testing Achievement Logic...");
                    AchievementDB achDB = new AchievementDB();
                    // Pretend we just did 1 encounter
                    achDB.CheckAndUnlock(currentUser.UserID, "TotalEncounters", 1);
                    Debug.WriteLine("   - Achievement check ran without crashing.");
                }
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine("!!! CRITICAL FAILURE !!!");
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
        }

        Debug.WriteLine("--- TEST COMPLETE ---");
    }
        private void SeedTestDatabase()
        {
            Debug.WriteLine("--- SEEDING DATABASE WITH TEST DATA ---");
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;

                    // 1. Ensure a TEST GAME exists (ID 1)
                    // We use 'On Error Resume Next' logic by checking counts or catching errors, 
                    // but for simplicity, we'll just try to insert and ignore duplicate errors if they exist.
                    try
                    {
                        cmd.CommandText = "INSERT INTO tblGames (GameID, GameName, Generation, Platform) VALUES (1, 'Test Game', 'Gen 1', 'TestConsole')";
                        cmd.ExecuteNonQuery();
                        Debug.WriteLine(" - Added Test Game.");
                    }
                    catch { Debug.WriteLine(" - Test Game already exists."); }

                    // 2. Ensure a TEST METHOD exists (ID 1)
                    try
                    {
                        cmd.CommandText = "INSERT INTO tblMethods (MethodID, MethodName, BaseOdds) VALUES (1, 'Wild Encounter', 4096)";
                        cmd.ExecuteNonQuery();
                        Debug.WriteLine(" - Added Test Method.");
                    }
                    catch { Debug.WriteLine(" - Test Method already exists."); }

                    // 3. (THE FIX) Link Game 1 to Method 1 in tblGameMethods
                    try
                    {
                        // Access doesn't support "IF NOT EXISTS", so we try insert. If it fails (pk violation), we assume it exists.
                        cmd.CommandText = "INSERT INTO tblGameMethods (GameID_FK, MethodID_FK) VALUES (1, 1)";
                        cmd.ExecuteNonQuery();
                        Debug.WriteLine(" - LINKED Game 1 to Method 1 (Fixed the error!).");
                    }
                    catch { Debug.WriteLine(" - Link already exists."); }

                    // 4. Ensure a TEST POKEMON exists (ID 1)
                    try
                    {
                        cmd.CommandText = "INSERT INTO tblPokemon (PokemonID, BaseName, PokedexNumber) VALUES (1, 'TestMon', 1)";
                        cmd.ExecuteNonQuery();
                        Debug.WriteLine(" - Added Test Pokemon.");
                    }
                    catch { Debug.WriteLine(" - Test Pokemon already exists."); }

                    // 5. Ensure a TEST FORM exists (ID 100)
                    try
                    {
                        cmd.CommandText = "INSERT INTO tblPokemonForms (FormID, PokemonID_FK, FormName, DisplayName) VALUES (100, 1, 'Standard', 'TestMon')";
                        cmd.ExecuteNonQuery();
                        Debug.WriteLine(" - Added Test Form.");
                    }
                    catch { Debug.WriteLine(" - Test Form already exists."); }

                    // 6. Link Everything in tblEncounters
                    try
                    {
                        cmd.CommandText = "INSERT INTO tblEncounters (GameID_FK, MethodID_FK, FormID_FK) VALUES (1, 1, 100)";
                        cmd.ExecuteNonQuery();
                        Debug.WriteLine(" - Added Encounter Logic (Traffic Cop).");
                    }
                    catch { Debug.WriteLine(" - Encounter Logic already exists."); }

                    Debug.WriteLine("--- SEEDING COMPLETE ---");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seeding Error: " + ex.Message);
                }
            }
        }

    }
}
