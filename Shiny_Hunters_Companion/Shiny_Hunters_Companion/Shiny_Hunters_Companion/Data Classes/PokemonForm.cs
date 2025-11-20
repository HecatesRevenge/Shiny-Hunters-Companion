using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiny_Hunters_Companion
{
    public class PokemonForm
    {
        public int FormID { get; set; }
        public string FormName { get; set; }
        public string DisplayName { get; set; }
        public string SpriteURL { get; set; }

        public Pokemon BasePokemon { get; set; }


        public int PokedexNumber
        {
            // Returns the Pokedex number of the base Pokemon, or 0 if BasePokemon is null
            get
            {
                if (BasePokemon != null)
                {
                    return BasePokemon.PokedexNumber;
                }
                else
                {
                    return 0; 
                }
            }
        }

        public PokemonForm()
        {
            BasePokemon = new Pokemon();
        }

        public PokemonForm(int formID, string formName, string displayName, string spriteURL, Pokemon basePokemon)
        {
            FormID = formID;
            FormName = formName;
            DisplayName = displayName;
            SpriteURL = spriteURL;
            BasePokemon = basePokemon;
        }

        //Good practice to override ToString for easier debugging and display
        public override string ToString()
        {
            return $"#{PokedexNumber:D3}: {DisplayName}";
        }


    }
}


