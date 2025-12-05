using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Shiny_Hunters_Companion.Data_Access_Layer;

namespace Shiny_Hunters_Companion
{
    public partial class Home : Form
    {
        private User currentUser;
        private Hunt activeHunt;
        private int encounterSeconds = 0;

        private HuntDB huntDB = new HuntDB();
        private PokemonDB pokemonDB = new PokemonDB();
        private MethodDB methodDB = new MethodDB();
        private GameDB gameDB = new GameDB();
        private UserPokedexDB userPokedexDB = new UserPokedexDB();

        public Home()
        {
            InitializeComponent();
        }


        private void Home_Load(object sender, EventArgs e)
        {
            if (Program.CurrentUser == null)
            {
                this.Close();
                return;
            }

            currentUser = Program.CurrentUser;

            if (lblTitle != null)
            {
                lblTitle.Text = $"Shiny Hunter's Companion  |  Welcome, {currentUser.Username}";
            }
            LoadMainDashboard();
        }

        private void LoadMainDashboard()
        {
            List<Hunt> activeHunts = huntDB.GetActiveHunts(currentUser.UserID); 


            if (activeHunts.Count > 0) {
                activeHunt=activeHunts[0];

                activeHunt.ActiveModifiers = huntDB.GetModifiersForHunt(activeHunt.HuntID);
                PokemonForm pokemon=pokemonDB.GetPokemonFormByID(activeHunt.HuntID);
                lblTargetPokemon.Text=pokemon.DisplayName;
                    
                            
            }


            if (activeHunt != null)
            {
                PokemonForm pokemonForm = pokemonDB.GetPokemonFormByID(activeHunt.FormID);
                lblTargetPokemon.Text = pokemonForm.DisplayName;


                string methodName = methodDB.GetMethodName(activeHunt.MethodID);
                lblMethod.Text = "Method: " + methodName;
                //TODO look over this later
                lblEncounters.Text = activeHunt.EncounterCount.ToString("N0");

                Game gameInfo = gameDB.GetGameDetails(activeHunt.GameID);
                lblGame.Text= "Game: " + gameInfo;

                if (!string.IsNullOrEmpty(pokemonForm.SpriteURL))
                {
                    picPokemonSprite.LoadAsync(pokemonForm.SpriteURL);
                }
                else
                {
                    picPokemonSprite.Image = null;
                }

                TimeSpan time = TimeSpan.FromSeconds(activeHunt.TotalTimeSeconds);
                lblTimer.Text = time.ToString(@"hh\:mm\:ss");

                EnableControls(true);

                ProbabilityMath();
            }
            else
            {
                ClearDashBoard();
            }

        }

        private void EnableControls(bool enable)
        {
            btnIncrease.Enabled = enable;
            btnDecrease.Enabled = enable;
            btnToggleTimer.Enabled = enable;
            btnCaught.Enabled = enable;
        }

        private void ClearDashBoard()
        {
            lblTargetPokemon.Text = "No Active Shiny Hunt";
            lblMethod.Text = "Select 'New Hunt' from Menu";
            lblGame.Text = "--";
            lblEncounters.Text = "---";
            lblBaseOdds.Text = "Base: --";
            lblCurrentOdds.Text = "Current: --";
            lblProbTitle.Text = "Current: --";
            lblMilestone50.Text = "50%: ";
            lblMilestone90.Text = "90%: ";
            lblMilestone99.Text = "99%: ";
            lblMilestone50.ForeColor = Color.Black;
            lblMilestone90.ForeColor = Color.Black;
            lblMilestone99.ForeColor = Color.Black;
            lblLuckStatus.Text = "No Active Hunt";
            picPokemonSprite.Image = null;
            progProb.Visible= false;
            EnableControls(false);
           

        }

        private void ProbabilityMath()
        {
            if (activeHunt == null)
            {
                return;
            }

            double hours = activeHunt.TotalTimeSeconds / 3600.0;
            double speed = 0;
            string estTimeText = "--";
            if (hours > 0.01)
            {
                speed = activeHunt.EncounterCount / hours;
                lblSpeed.Text = $"Speed: {speed:N0}/ hr";
            }
            else
            {
                lblSpeed.Text = "Speed: --/hr";
            }

            double p = GetOdds();
            double n = activeHunt.EncounterCount;
            double oddsFormat = 1.0 / p;

            Method methodInfo = methodDB.GetMethodDetails(activeHunt.MethodID);
            lblBaseOdds.Text = $"Base: 1/{methodInfo.BaseOdds}";
            lblCurrentOdds.Text = $"Current: 1/{Math.Round(1.0 / p):N0}";

            double probability = 1.0 - (Math.Pow(1.0 - p, n));
            lblProbTitle.Text = $"Chance: {probability:P2}";

            int progVal = Convert.ToInt32(probability * 100);
            if (progVal > 100)
            {
                progVal = 100;
            }
            progProb.Value = progVal;

            double encountersRemain= oddsFormat - n;

            if (encountersRemain <= 0)
            {
                lblEstTime.Text = "Odds Reached";
                lblEstTime.ForeColor = Color.Green;

            } else if (speed > 0)
            {
                double hoursLeft = encountersRemain / speed;

                if (hoursLeft < 1.0)
                {
                    lblEstTime.Text = $"{(hoursLeft * 60):N0} mins";
                }
                else
                {
                    lblEstTime.Text = $"{hoursLeft:N1} Hours";
                }
                lblEstTime.ForeColor = Color.Black;
            } else {
                lblEstTime.Text = "--";
                lblEstTime.ForeColor = Color.Gray;
            }

            int n50 = Convert.ToInt32(Math.Log(1 - 0.5) / Math.Log(1 - p));
            int n90 = Convert.ToInt32(Math.Log(1 - 0.9) / Math.Log(1 - p));
            int n99 = Convert.ToInt32(Math.Log(1 - 0.99) / Math.Log(1 - p));


            if (n >= n50)
            {
                lblMilestone50.Text = "50%: Reached";
                lblMilestone50.ForeColor = Color.Green; 
            }
            else
            {
                lblMilestone50.Text = $"50%: {n50 - n:N0} left";
                lblMilestone50.ForeColor = Color.Black;
            }

            if (n >= n90)
            {
                lblMilestone90.Text = "90%: Reached";
                lblMilestone90.ForeColor = Color.Green;
            }
            else
            {
                lblMilestone90.Text = $"90%: {n90 - n:N0} left";
                lblMilestone90.ForeColor = Color.Black;
            }

            if (n >= n99)
            {
                lblMilestone99.Text = "99%: Reached";
                lblMilestone99.ForeColor = Color.Green;
            }
            else
            {
                lblMilestone99.Text = $"99%: {n99 - n:N0} left";
                lblMilestone99.ForeColor = Color.Black;
            }

            if (probability < 0.25)
            {
                //Change these little quips later on
                lblLuckStatus.Text = "STATUS: EARLY GAME";
                lblLuckStatus.ForeColor = Color.Green;
                lblPercentile.Text = "Just getting started.";
            }
            else if (probability < 0.63)
            {
                lblLuckStatus.Text = "STATUS: ON PACE";
                lblLuckStatus.ForeColor = Color.Orange;
                lblPercentile.Text = "Approaching average luck.";
            }
            else if (probability < 0.90)
            {
                lblLuckStatus.Text = "STATUS: OVER ODDS";
                lblLuckStatus.ForeColor = Color.Red;
                lblPercentile.Text = $"Longer than {probability:P0} of hunts.";
            }
            else
            {
                lblLuckStatus.Text = "STATUS: DRY SPELL";
                lblLuckStatus.ForeColor = Color.DarkRed;
                lblPercentile.Text = "Extremely unlucky. Keep going!";
            }

        }
        private double GetOdds()
        {
            Method methodInfo = methodDB.GetMethodDetails(activeHunt.MethodID);
            double baseOdds = methodInfo.BaseOdds;

            double rolls = 0;

            if ((activeHunt.ActiveModifiers != null)&&(activeHunt.ActiveModifiers.Count>0))
            {
                foreach (var modifier in activeHunt.ActiveModifiers)
                    if (modifier.OddsMultiplier > 1.0)
                    {
                        rolls +=( modifier.OddsMultiplier-1.0);
                    }
                {
                   
                }
            }
            return ((1.0 + rolls) / baseOdds);
        }
        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (activeHunt == null)
            {
                return;
            }
            if (activeHunt.EncounterCount==0)
            {
                huntTimer.Start();
            }
            activeHunt.EncounterCount++;
            lblEncounters.Text = activeHunt.EncounterCount.ToString("N0");
            encounterSeconds = 0;
            lblLapTimer.Text = "00:00";


            ProbabilityMath();
            huntDB.UpdateHuntCount(activeHunt.HuntID, activeHunt.EncounterCount, activeHunt.TotalTimeSeconds);
        }
        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (activeHunt == null || activeHunt.EncounterCount == 0)
            {
                return;
            }
            activeHunt.EncounterCount--;
            lblEncounters.Text = activeHunt.EncounterCount.ToString("N0");
            ProbabilityMath();
        }
        private void btnToggleTimer_Click(object sender, EventArgs e)
        {
            if (huntTimer.Enabled)
            {
                huntTimer.Stop();
                btnToggleTimer.Text = "▶";
                btnToggleTimer.BackColor = Color.LightGreen;
            }
            else
            {
                huntTimer.Start();
                btnToggleTimer.Text = "||";
                btnToggleTimer.BackColor = Color.LightSalmon;
            }

        }
        private void huntTimer_Tick(object sender, EventArgs e)
        {
            if (activeHunt == null)
            {
                return;
            }

            activeHunt.TotalTimeSeconds++;
            TimeSpan time = TimeSpan.FromSeconds(activeHunt.TotalTimeSeconds);
            lblTimer.Text = time.ToString(@"hh\:mm\:ss");

            encounterSeconds++;
            TimeSpan lap = TimeSpan.FromSeconds(encounterSeconds);
            lblLapTimer.Text= "Lap: " + lap.ToString(@"mm\:ss");

        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (dropDownMenu != null)
            {

                dropDownMenu.Show(btnMenu, new Point(0, btnMenu.Height));

            }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblCurrentOdds_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void picPokemonSprite_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void Menu_NewHunt_Click(object sender, EventArgs e)
        {

            NewHunt frm = new NewHunt();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadMainDashboard();
            }

        }

        public void Menu_ViewPokedex_Click(object sender, EventArgs e)
        {
            ShinyPokedex frm = new ShinyPokedex();
            frm.ShowDialog();
        }

        public void Menu_LogOut_Click(object sender, EventArgs e)
        {
            Program.CurrentUser = null;
            Application.Restart();
        }

        public void Menu_PastHunts_Click(object sender, EventArgs e)
        {
            PastHunts frm = new PastHunts();
            frm.ShowDialog();
        }

        private void btnCaught_Click(object sender, EventArgs e)
        {
            if (activeHunt == null)
            {
                return;
            }

            var result = MessageBox.Show($"Shiny {lblTargetPokemon.Text} Caught!");
            huntTimer.Stop();
            btnToggleTimer.Text = "▶";
            btnToggleTimer.BackColor = Color.LightGreen;
            userPokedexDB.UpdateCaughtStatus(currentUser.UserID, activeHunt.FormID, true);
            huntDB.UpdateHuntCount(activeHunt.HuntID, activeHunt.EncounterCount, activeHunt.TotalTimeSeconds);
            huntDB.CompleteHunt(activeHunt.HuntID);
            MessageBox.Show("Hunt Saved to History!");

            ClearDashBoard();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grbAchievements_Enter(object sender, EventArgs e)
        {

        }
    }
}
