using System;
using System.Collections.Generic;


namespace Shiny_Hunters_Companion
{
    public class Hunt
    {
        public int HuntID { get; set; }
        public Pokemon Pokemon { get; set; }
        public Game Game { get; set; }
        public Method Method { get; set; }
        public int EncounterCount { get; set; }
        public TimeSpan TotalTime { get; set; }
        public bool isActive { get; set; }

        //Holds all modifers that are active for this shiny hunt
        public List<PlayerModifier> ActiveModifers { get; set; }

        public Hunt()
        {
            ActiveModifers = new List<PlayerModifier>();
            TotalTime=TimeSpan.Zero;
        }

    }
}
