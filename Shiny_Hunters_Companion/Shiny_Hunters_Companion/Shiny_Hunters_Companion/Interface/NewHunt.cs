using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public partial class NewHunt : Form
    {
        private GameDB gameDB = new GameDB();
        private PokemonDB pokemonDB = new PokemonDB();
        private MethodDB methodDB = new MethodDB();
        private ModifierDB modifierDB = new ModifierDB();
        private HuntDB huntDB = new HuntDB();

        public NewHunt()
        {
            InitializeComponent();

        }
        private void NewHunt_Load(object sender, EventArgs e)
        {


            List<Game> games = gameDB.GetAllGames();
            cbGames.DisplayMember = "GameName";
            cbGames.ValueMember = "GameID";
            cbGames.DataSource = games;
            cbGames.SelectedIndex = -1;

        }

        private void cbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGames.SelectedIndex == -1) return;

            int gameID = (int)cbGames.SelectedValue;

            List<Method> methods = methodDB.GetMethodsFromGame(gameID);

            cbMethods.DisplayMember = "MethodName";
            cbMethods.ValueMember = "MethodID";
            cbMethods.DataSource = methods;

            cbMethods.SelectedIndex = -1;

            LoadModifiersByGame(gameID);

            lstPokemon.DataSource = null;
            pbPreview.Image = null;
            lblPreviewName.Text = "";
            lblPreviewOdds.Text = "Est. Odds: --";
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
        private void cbMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbGames.SelectedIndex == -1) || (cbMethods.SelectedIndex == -1))
            {
                return;
            }
            int gameID = Convert.ToInt32(cbGames.SelectedValue);
            int methodID = Convert.ToInt32(cbMethods.SelectedValue);

            List<PokemonForm> pokemon = pokemonDB.GetFormsByGameAndMethod(gameID, methodID);

            lstPokemon.DisplayMember = "DisplayName";
            lstPokemon.ValueMember = "FormID";
            lstPokemon.DataSource = pokemon;
            lstPokemon.SelectedIndex = -1;
        }


        private List<PlayerModifier> GetSelectModifiers()
        {
            List<PlayerModifier> selectedModifiers = new List<PlayerModifier>();

            //Basic foreach loop that looks at all checked modifiers and adds them to 
            //a list containing all modifiers for that player
            foreach (var item in chkModifiers.CheckedItems)
            {
                selectedModifiers.Add((PlayerModifier)item);
            }
            return selectedModifiers;

        }

        private void lstPokemon_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (lstPokemon.SelectedIndex == -1)
            {
                return;
            }

            PokemonForm selectedPokemon = (PokemonForm)lstPokemon.SelectedItem;

            lblPreviewName.Text = selectedPokemon.DisplayName;
            if (string.IsNullOrEmpty(selectedPokemon.SpriteURL))
            {
                pbPreview.Image = null;
            }
            else
            {
                pbPreview.LoadAsync(selectedPokemon.SpriteURL);
            }

            if (cbMethods.SelectedItem != null)
            {
                Method meth = (Method)cbMethods.SelectedItem;
                lblPreviewOdds.Text = $"Est. Odds: 1/{meth.BaseOdds}";
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if ((cbGames.SelectedIndex == -1) || (cbMethods.SelectedIndex == -1))
            {
                MessageBox.Show("Error! Please Complete All Selections");
                return;

            }

            Hunt newHunt = new Hunt();
            newHunt.GameID = Convert.ToInt32(cbGames.SelectedValue);
            newHunt.MethodID = Convert.ToInt32(cbMethods.SelectedValue);
            newHunt.FormID = Convert.ToInt32(lstPokemon.SelectedValue);
            newHunt.UserID = Program.CurrentUser.UserID;
            newHunt.EncounterCount = 0;
            newHunt.isActive = true;
            newHunt.TotalTimeSeconds = 0;
            newHunt.ActiveModifiers = GetSelectModifiers();

            int newHuntResult = huntDB.CreateHunt(newHunt);

            if (newHuntResult != -1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Creating a New Shiny Hunt");
            }

        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pbPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
