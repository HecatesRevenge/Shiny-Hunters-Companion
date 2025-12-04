using Shiny_Hunters_Companion.API;
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
    public partial class ShinyDexDetails : Form
    {
        private PokeApiService service = new PokeApiService();
        private PokemonSpecies currentSpecies;

        public ShinyDexDetails()
        {
            InitializeComponent();
            IntiializeVersions();
        }

        public void LoadPokemonByName(string name)
        {
            txtSearch.Text = name;
            btnSearch_Click(this, EventArgs.Empty);
        }

        private void IntiializeVersions()
        {
            var versions = new Dictionary<string, string>
            {
                { "Red", "red" }, { "Blue", "blue" }, { "Yellow", "yellow" },
                { "Gold", "gold" }, { "Silver", "silver" }, { "Crystal", "crystal" },
                { "Ruby", "ruby" }, { "Sapphire", "sapphire" }, { "Emerald", "emerald" },
                { "FireRed", "firered" }, { "LeafGreen", "leafgreen" },
                { "Diamond", "diamond" }, { "Pearl", "pearl" }, { "Platinum", "platinum" },
                { "HeartGold", "heartgold" }, { "SoulSilver", "soulsilver" },
                { "Black", "black" }, { "White", "white" },
                { "Black 2", "black-2" }, { "White 2", "white-2" },
                { "X", "x" }, { "Y", "y" },
                { "Omega Ruby", "omega-ruby" }, { "Alpha Sapphire", "alpha-sapphire" },
                { "Sun", "sun" }, { "Moon", "moon" },
                { "Ultra Sun", "ultra-sun" }, { "Ultra Moon", "ultra-moon" },
                { "Sword", "sword" }, { "Shield", "shield" },
                { "Scarlet", "scarlet" }, { "Violet", "violet" }
            };
            cbVersions.DataSource = new BindingSource(versions, null);
            cbVersions.DisplayMember = "Key";
            cbVersions.ValueMember = "Value";
            cbVersions.SelectedIndex = 0;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            if (string.IsNullOrWhiteSpace(search))
            {
                return;
            }



            PokemonResponse pokemon = await service.GetPokemonAsync(search);

            if (pokemon != null)
            {
                lblName.Text = pokemon.name.ToUpper();
                lblID.Text = "#" + pokemon.id.ToString("000");


                //Uses string builder to return all types and format to an array
                List<string> typeList = new List<string>();
                foreach (var typeEntry in pokemon.types)
                {
                    typeList.Add(typeEntry.type.name.ToUpper());
                }
                var typeNames = typeList.ToArray();
                lblType.Text = "Type: " + string.Join(", ", typeNames);

                string imageURL = pokemon.Sprites.front_shiny;


                //Using pokeAPI docs as an outline to check if official artwork is available from their API
                if (((pokemon.Sprites.other != null) && (pokemon.Sprites.other.official_artwork != null))
                    && (!string.IsNullOrEmpty(pokemon.Sprites.other.official_artwork.front_shiny)))
                {
                    imageURL = pokemon.Sprites.other.official_artwork.front_shiny;
                }

                if (string.IsNullOrEmpty(imageURL))
                {
                    pbShiny.Image = null;
                }
                else
                {
                    pbShiny.LoadAsync(imageURL);
                }

                if (pokemon.species != null)
                {
                    currentSpecies = await service.GetPokemonSpeciesAsync(pokemon.species.name);
                    UpdateDescription();
                }
                else
                {
                    MessageBox.Show("Pokemon not found! Check spelling.");
                    currentSpecies = null;
                    pbShiny.Image = null;
                    lblDescr.Text = "Description not found.";
                }





            }

        }

        private void UpdateDescription()
        {
            if (currentSpecies == null || cbVersions.SelectedValue == null)
            {
                return;
            }

            string selectedVersion = cbVersions.SelectedValue.ToString();

            FlavorTextEntry entry = null;
            if (currentSpecies.flavor_text_entries != null)
            {
                foreach (var flavorEntry in currentSpecies.flavor_text_entries)
                {
                    if (flavorEntry.language != null && flavorEntry.version != null)
                    {
                        if (flavorEntry.language.name == "en" && flavorEntry.version.name == selectedVersion)
                        {
                            entry = flavorEntry;
                            break;
                        }
                    }


                }
            }

            if (entry != null)
            {
                string description = entry.flavor_text.Replace("\n", " ").Replace("\f", " ");
                lblDescr.Text = description;
            }
            else
            {
                lblDescr.Text = "No English description available.";
            }

        }

        private void cbVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDescription();
        }
    }

}
