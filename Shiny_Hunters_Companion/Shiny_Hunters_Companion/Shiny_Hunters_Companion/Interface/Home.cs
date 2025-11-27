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
        private int lapSeconds = 0;

        private HuntDB huntDB=new HuntDB();
        private PokemonDB pokemonDB=new PokemonDB();
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
    }
}
