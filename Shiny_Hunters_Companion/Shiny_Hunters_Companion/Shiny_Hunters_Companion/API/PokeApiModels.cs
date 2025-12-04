using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiny_Hunters_Companion.API
{
    public class PokemonResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public Sprites Sprites { get; set; }
        public List<PokemonType> types { get; set; }
        public SpeciesRef species { get; set; }
    }
    public class Sprites
    {
        public string front_default { get; set; }
        public string front_shiny { get; set; }
        public OtherSprites other { get; set; }
    }
    public class OtherSprites
    {
        //Issue with C# property naming conventions and JSON property names with hyphens
        [Newtonsoft.Json.JsonProperty("official-artwork")]
        public OfficialArtwork official_artwork { get; set; }
    }
    public class OfficialArtwork
    {
        public string front_default { get; set; }
        public string front_shiny { get; set; }
    }
    public class PokemonType
    {
        public TypeInfo type { get; set; }
    }
    public class TypeInfo
    {
        public string name { get; set; }
    }
    public class SpeciesRef
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class PokemonSpecies
    {
        public List<FlavorTextEntry> flavor_text_entries { get; set; }
    }

    public class FlavorTextEntry
    {
        public string flavor_text { get; set; }
        public Language language { get; set; }
        public Version version { get; set; }
    }
    public class Language
    {
        public string name { get; set; }
    }
    public class Version
    {
        public string name { get; set; }
    }


}
