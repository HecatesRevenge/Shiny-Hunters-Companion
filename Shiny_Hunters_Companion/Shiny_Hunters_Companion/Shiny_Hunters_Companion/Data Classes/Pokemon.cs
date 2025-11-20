using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiny_Hunters_Companion
{
    public class Pokemon
    {
        public int PokemonID { get; set; }
        public int PokedexNumber { get; set; }
        public string BaseName { get; set; }
        public Pokemon() { }

        public Pokemon(int pokemonID, int pokedexNumber, string baseName)
        {
            PokemonID = pokemonID;
            PokedexNumber = pokedexNumber;
            BaseName = baseName;
        }


        //Good practice to override ToString for easier debugging and display
        public override string ToString()
        {
            return $"#{PokedexNumber:D3}: {BaseName}";
        }

    }
}
