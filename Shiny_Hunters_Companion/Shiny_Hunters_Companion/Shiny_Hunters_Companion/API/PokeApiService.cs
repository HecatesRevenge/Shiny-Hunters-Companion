using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shiny_Hunters_Companion.API
{
    public class PokeApiService
    {
        private static HttpClient client=new HttpClient();
        private const string BaseUrl = "https://pokeapi.co/api/v2/";

        public async Task<PokemonResponse> GetPokemonAsync(string pokemonName)
        {
            string url = $"{BaseUrl}pokemon/{pokemonName.ToLower().Trim()}";
           return await GetDataSync<PokemonResponse>(url);
        }
        public async Task<PokemonSpecies> GetPokemonSpeciesAsync(string speciesName)
        {
            string url = $"{BaseUrl}pokemon-species/{speciesName.ToLower().Trim()}";
            return await GetDataSync<PokemonSpecies>(url);
        }

        private async Task<T> GetDataSync<T>(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                throw new Exception($"Error fetching data from PokeAPI: {response.StatusCode}");
            }
        }



    }
}
