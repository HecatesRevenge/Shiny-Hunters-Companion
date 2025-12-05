using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shiny_Hunters_Companion
{
    public partial class PastHunts : Form
    {

        private HuntDB huntDB = new HuntDB();
        private PokemonDB pokemonDB = new PokemonDB();
        private GameDB gameDB = new GameDB();
        private MethodDB methodDB = new MethodDB();

        public PastHunts()
        {
            InitializeComponent();
        }

        private void PastHunts_Load(object sender, EventArgs e)
        {
            flowpanel.AutoScroll = true;
            LoadHistory();
        }

        public void LoadHistory()
        {
            int userID = Program.CurrentUser.UserID;
            List<Hunt> history = huntDB.GetCompletedHunts(userID);
            foreach (Hunt hunt in history)
            {
                PokemonForm pokemon = pokemonDB.GetPokemonFormByID(hunt.FormID);
                Game game = gameDB.GetGameDetails(hunt.GameID);
                Method method = methodDB.GetMethodDetails(hunt.MethodID);

                Panel card = new Panel();
                card.Size = new Size(240, 160); 
                card.BackColor = Color.WhiteSmoke;
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Margin = new Padding(10); 

                PictureBox sprite = new PictureBox();
                sprite.Size = new Size(100, 100);
                sprite.Location = new Point(5, 20);
                sprite.SizeMode = PictureBoxSizeMode.Zoom;
                if (pokemon != null && !string.IsNullOrEmpty(pokemon.SpriteURL))
                {
                    sprite.LoadAsync(pokemon.SpriteURL);
                }

                Label lblName = new Label();
                lblName.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                lblName.Location = new Point(110, 20);
                lblName.AutoSize = true;
                if (pokemon != null)
                {
                    lblName.Text = pokemon.DisplayName;
                }
                else
                {
                    lblName.Text = "Unknown";
                }

                Label lblGame = new Label();
                lblGame.ForeColor = Color.DimGray;
                lblGame.Location = new Point(110, 45);
                lblGame.AutoSize = true;
                if (game != null)
                {
                    lblGame.Text = game.GameName;
                }
                else
                {
                    lblGame.Text = "Unknown Game";
                }

                Label lblMethod = new Label();
                lblMethod.ForeColor = Color.DimGray; 
                lblMethod.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
                lblMethod.Location = new Point(110, 65);
                lblMethod.AutoSize = true;

                if (method != null)
                {
                    string rawName = method.MethodName;

                    int index = rawName.IndexOf('(');

                    if (index > 0)
                    {
                        lblMethod.Text = rawName.Substring(0, index).Trim();
                    }
                    else
                    {
                        lblMethod.Text = rawName;
                    }
                }
                else
                {
                    lblMethod.Text = "Unknown Method";
                }


                Label lblEncounters = new Label();
                lblEncounters.Text = $"Encounters: {hunt.EncounterCount:N0}";
                lblEncounters.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                lblEncounters.Location = new Point(110, 80);
                lblEncounters.AutoSize = true;

                Label lblDate = new Label();

                string dateString;

                if (hunt.DateCaught.HasValue)
                {
                    dateString = hunt.DateCaught.Value.ToShortDateString();
                }
                else
                {
                    dateString = "Date: --/--/----";
                }

                lblDate.Text = dateString;
                lblDate.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
                lblDate.Location = new Point(110, 100);
                lblDate.AutoSize = true;

                card.Controls.Add(sprite);
                card.Controls.Add(lblName);
                card.Controls.Add(lblGame);
                card.Controls.Add(lblMethod);
                card.Controls.Add(lblEncounters);
                card.Controls.Add(lblDate);

                flowpanel.Controls.Add(card);
            }
        }

        private void flowpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PastHunts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
    }
}
