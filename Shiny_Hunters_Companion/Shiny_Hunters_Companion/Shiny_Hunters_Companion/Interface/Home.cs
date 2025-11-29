using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            activeHunt = huntDB.GetHunt(currentUser.UserID);

            if (activeHunt != null)
            {
                PokemonForm pokemonForm = pokemonDB.GetPokemonFormByID(activeHunt.FormID);
                lblTargetPokemon.Text = pokemonForm.DisplayName;

                string methodName = methodDB.GetMethodName(activeHunt.FormID);
                lblMethod.Text = "Method: " + methodName;
                //TODO look over this later
                lblEncounters.Text = activeHunt.EncounterCount.ToString("N0");

                if (!string.IsNullOrEmpty(pokemonForm.SpriteURL))
                {
                    picPokemonSprite.LoadAsync(pokemonForm.SpriteURL);
                }

                TimeSpan time = TimeSpan.FromSeconds(activeHunt.TotalTimeSeconds);
                lblTimer.Text = time.ToString(@"hh\:mm\:ss");

                EnableControls(true);

                ProbabilityMath();
            }
            else
            {
                lblTargetPokemon.Text = "No Active Shiny Hunt";
                lblMethod.Text = "Select 'New Hunt' from Menu";
                lblEncounters.Text = "---";
                picPokemonSprite.Image = null;
                EnableControls(false);
            }

        }

        private void EnableControls(bool enable)
        {
            btnIncrease.Enabled = enable;
            btnDecrease.Enabled = enable;
            btnToggleTimer.Enabled = enable;
            btnCaught.Enabled = enable;
        }

        private void ProbabilityMath()
        {
            if (activeHunt == null)
            {
                return;
            }

            double hours = activeHunt.TotalTimeSeconds / 3600.0;
            double speed = 0;
            if (hours > 0.01)
            {
                speed = activeHunt.EncounterCount / hours;
                lblSpeed.Text = $"Speed: {speed}/ hr";
            }

            double p = GetOdds();
            double n = activeHunt.EncounterCount;

            Method methodInfo = methodDB.GetMethodDetails(activeHunt.MethodID);
            lblBaseOdds.Text = $"Base: 1/{methodInfo.BaseOdds}";
            lblCurrentOdds.Text = $"Current: 1/{Math.Round(1.0 / 0)}";

            double probability = 1.0 - (Math.Pow(1.0 - p, n));
            lblProbTitle.Text = $"Current 1/{Math.Round(1.0 / p)}";

            int progVal = Convert.ToInt32(probability * 100);
            if (progVal > 100)
            {
                progVal = 100;
            }
            progProb.Value = progVal;


            /*TODO Change these values depending on what I want to display later on for 
             * this section. These values act as a place holder for now. 
             */

            int n50 = Convert.ToInt32(Math.Log(1 - 0.5) / Math.Log(1 - p));
            int n90 = Convert.ToInt32(Math.Log(1 - 0.9) / Math.Log(1 - p));
            int n99 = Convert.ToInt32(Math.Log(1 - 0.99) / Math.Log(1 - p));


            //Display the milestones in the analysis section
            if (n > 50)
            {
                lblMilestone50.Text = "50%: Reached";
            }
            else
            {
                lblMilestone50.Text = $"50%: {n50 - n} left";
            }

            if (n > 90)
            {
                lblMilestone50.Text = "90%: Reached";
            }
            else
            {
                lblMilestone50.Text = $"90%: {n90 - n} left";
            }

            if (n > 99)
            {
                lblMilestone50.Text = "99%: Reached";
            }
            else
            {
                lblMilestone50.Text = $"99%: {n99 - n} left";
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

            if (activeHunt.ActiveModifiers != null)
            {
                foreach (var modifier in activeHunt.ActiveModifiers)
                {
                    rolls += modifier.OddsMultiplier;
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

        public void Menu_LogOut_Click(object sender, EventArgs e)
        {
            Program.CurrentUser = null;
            Application.Restart();
        }
    }
}
