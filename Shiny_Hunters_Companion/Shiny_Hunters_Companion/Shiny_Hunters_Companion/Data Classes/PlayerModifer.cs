using System;


namespace Shiny_Hunters_Companion
{
    public class PlayerModifer
    {
        public int ModifierID { get; set; }
        public string ModifierName { get; set; }
        public double OddsMultiplier { get; set; }
        public string ModiferDescription { get; set; }

        public PlayerModifer(int modifierID, string modifierName, double oddsMultiplier, string modiferDescription)
        {
            ModifierID = modifierID;
            ModifierName = modifierName;
            OddsMultiplier = oddsMultiplier;
            ModiferDescription = modiferDescription;
        }

        public override string ToString()
        {
            //Add more if needed later on
            return ModifierName;
        }

    }
}
