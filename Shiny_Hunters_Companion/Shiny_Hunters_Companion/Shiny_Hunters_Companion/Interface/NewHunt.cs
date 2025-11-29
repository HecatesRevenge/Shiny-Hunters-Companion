using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public partial class NewHunt : Form
    {
        private GameDB gameDB=new GameDB();
        private MethodDB methodDB = new MethodDB();
        private ModifierDB modifierDB = new ModifierDB();
        private HuntDB huntDB = new HuntDB();

        public NewHunt()
        {
            InitializeComponent();
        }

        private void LoadModifiersByGame(int gameID)
        {
            List<PlayerModifier> modifiers = modifierDB.GetModifiersByGame(gameID);

            chkModifiers.DataSource = null;
            chkModifiers.DataSource = modifiers;
            chkModifiers.DisplayMember = "ModifierName";
            chkModifiers.ValueMember = "ModifierID";


            //Clear all values that were check by the user prior
            for (int i = 0; i < chkModifiers.Items.Count; i++)
            {
                chkModifiers.SetItemChecked(i, false);
            }
        }

        private void NewHunt_Load(object sender, EventArgs e)
        {


            List<Game> games = gameDB.GetAllGames();
            if (games.Count == 0)
            {
                MessageBox.Show("Debug Warning: GameDB returned 0 games. Database might be empty or reset.");
            }
            cbGames.DataSource = games;
            cbGames.DisplayMember = "GameName";
            cbGames.ValueMember = "GameID";
            cbGames.SelectedIndex = -1;

        }

       
        
        private void cbMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGames.SelectedIndex == -1) return;

            int gameID = Convert.ToInt32(cbGames.SelectedValue);

            List<Method> methods = methodDB.GetMethodsFromGame(gameID);
            cbMethods.DataSource = methods;
            cbMethods.DisplayMember = "MethodName";
            cbMethods.ValueMember = "MethodID";

            cbMethods.SelectedIndex = -1;

            LoadModifiersByGame(gameID);
            lstPokemon.DataSource = null;
            pbPreview.Image = null;
            lblPreviewName.Text = "";
            lblPreviewOdds.Text = "Est. Odds: --";
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pbPreview_Click(object sender, EventArgs e)
        {

        }

        private void cbgames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
