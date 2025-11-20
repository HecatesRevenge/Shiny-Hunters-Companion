using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiny_Hunters_Companion
{
    public class Game
    {
        public int GameID { get; set; }
        public string GameName { get; set; }
        public string Generation { get; set; }
        public string Platform { get; set; }
        public string RegionName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string BoxArtURL { get; set; }

        public Game() { }

        public Game(
            int gameID, 
            string gameName, 
            string generation, 
            string platform, 
            string regionName, 
            DateTime releaseDate, 
            string boxArtURL)
        {
            GameID = gameID;
            GameName = gameName;
            Generation = generation;
            Platform= platform;
            RegionName = regionName;
            ReleaseDate = releaseDate;
            BoxArtURL = boxArtURL;
        }

        public override string ToString()
        {
            //TODO: Adjust what is displayed if need be
            return GameName; 
        }
    }
}
