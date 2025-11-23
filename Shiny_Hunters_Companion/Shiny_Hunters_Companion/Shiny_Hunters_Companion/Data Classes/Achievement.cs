using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shiny_Hunters_Companion
{
    public class Achievement
    {
        public int AchievementID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ConditionType { get; set; }
        public int Threshold { get; set; }
        public string ImageURL { get; set; }
        public bool IsUnlocked { get; set; }
        public DateTime UnlockDate { get; set; }
        public Achievement() { }
    }
}
