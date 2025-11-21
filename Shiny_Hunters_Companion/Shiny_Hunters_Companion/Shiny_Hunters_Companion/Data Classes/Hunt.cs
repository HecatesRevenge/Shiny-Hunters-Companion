using System;
using System.Collections.Generic;


namespace Shiny_Hunters_Companion
{
    public class Hunt
    {
        public int HuntID { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }
        public int FormID { get; set; }
        public int MethodID { get; set; }
        public int EncounterCount { get; set; }
        public int TotalTimeSeconds { get; set; }
        public TimeSpan TotalHuntTime { get; set; }
        public bool isActive { get; set; }

        public bool IsCompleted {  get; set; }
        public List<PlayerModifier> ActiveModifiers { get; set;}

        public TimeSpan TotalTime
        {
            get { return TimeSpan.FromSeconds(TotalTimeSeconds); }
            set { TotalTimeSeconds = (int)value.TotalSeconds; }
        }

        public Hunt()
        {
            ActiveModifiers = new List<PlayerModifier>();
            TotalTime=TimeSpan.Zero;
        }

    }
}
