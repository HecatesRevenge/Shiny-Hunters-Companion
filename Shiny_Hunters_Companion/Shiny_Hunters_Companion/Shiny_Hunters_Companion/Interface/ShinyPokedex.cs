using Shiny_Hunters_Companion.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public partial class ShinyPokedex : Form
    {
        private PokemonDB pokemonDB = new PokemonDB();
        private UserPokedexDB userPokedexDB = new UserPokedexDB();

        public ShinyPokedex()
        {
            InitializeComponent();
        }

        private void ShinyPokedex_Load(object sender, EventArgs e)
        {
            LoadPokedexInfo();
        }
        private void LoadPokedexInfo()
        {
            int userID = Program.CurrentUser.UserID;
            List<PokemonForm> allPokemon = pokemonDB.GetAllPokemonForms();
            HashSet<int> caughtID = userPokedexDB.GetCaughtPokemonIDs(userID);

            flowPanel.SuspendLayout();
            flowPanel.Controls.Clear();

            foreach (PokemonForm pokemon in allPokemon)
            {
                bool isCaught = caughtID.Contains(pokemon.FormID);

                Panel card = new Panel();
                card.Size = new Size(110, 140);
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Margin = new Padding(5);

                if (isCaught)
                {
                    card.BackColor = Color.White;
                }
                else
                {
                    card.BackColor = Color.LightGray;
                }

                CheckBox check = new CheckBox();
                check.AutoSize = true;
                check.Location = new Point(85, 5);
                check.Checked = isCaught;
                check.Cursor = Cursors.Hand;
                check.Tag = pokemon;

                Label lblID = new Label();
                lblID.Text = "#" + pokemon.FormID.ToString("000");
                lblID.ForeColor = Color.DimGray;
                lblID.Location = new Point(5, 6);
                lblID.AutoSize = true;

                PictureBox sprite = new PictureBox();
                sprite.Size = new Size(80, 80);
                sprite.Location = new Point(15, 25);
                sprite.SizeMode = PictureBoxSizeMode.Zoom;
                sprite.Tag = pokemon;
                sprite.Click += PokemonImage_Click;


                if (isCaught)
                {
                    if (!string.IsNullOrEmpty(pokemon.SpriteURL))
                    {
                        sprite.LoadAsync(pokemon.SpriteURL);
                    }
                    sprite.Cursor = Cursors.Hand;
                    sprite.BackColor = Color.Transparent;
                }
                else
                {
                    sprite.Image = null;
                    sprite.Cursor = Cursors.Default;
                    sprite.BackColor = Color.DarkGray;
                }

                Label lblName = new Label();
                lblName.Text = pokemon.DisplayName;
                lblName.Font = new Font("Microsoft Sans Serif", 7, FontStyle.Bold);
                lblName.TextAlign = ContentAlignment.MiddleCenter;
                lblName.Location = new Point(0, 110);
                lblName.Size = new Size(110, 25);

                card.Controls.Add(check);
                card.Controls.Add(lblID);
                card.Controls.Add(sprite);
                card.Controls.Add(lblName);
            }
            flowPanel.ResumeLayout();
        }


        private void flowPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PokemonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            bool isCaught = check.Checked;

            PokemonForm pokemon = (PokemonForm)check.Tag;

            int userID = Program.CurrentUser.UserID;
            userPokedexDB.UpdateCaughtStatus(userID, pokemon.FormID, isCaught);

            Panel card = (Panel)check.Parent;

            if (isCaught)
            {
                card.BackColor = Color.White;
            }
            else
            {
                card.BackColor = Color.LightGray;
            }
            foreach (Control control in card.Controls)
            {

                if (control is PictureBox picture)
                {
                    if (isCaught)
                    {
                        if (!string.IsNullOrEmpty(pokemon.SpriteURL))
                        {
                            picture.LoadAsync(pokemon.SpriteURL);
                        }
                        picture.Cursor = Cursors.Hand;
                        picture.BackColor = Color.Transparent;
                    }
                    else
                    {
                        picture.Image = null;
                        picture.Cursor = Cursors.Default;
                        picture.BackColor = Color.DarkGray;
                    }
                }
            }
        }
        private void PokemonImage_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;

            PokemonForm form = (PokemonForm)picture.Tag;

            Panel card = (Panel)picture.Parent;
            bool isCaught = false;

            foreach (Control control in card.Controls)
            {
                if (control is CheckBox check)
                {
                    isCaught = check.Checked;
                    break;
                }
            }
            if (isCaught)
            {
                OpenDetailView(form.DisplayName);
            }
        }
        private void OpenDetailView(string pokemonName)
        {
            ShinyPokedex dexForm = new ShinyPokedex();
            dexForm.LoadPokemonByName(pokemonName);
            dexForm.Show();
        }
    }
}
