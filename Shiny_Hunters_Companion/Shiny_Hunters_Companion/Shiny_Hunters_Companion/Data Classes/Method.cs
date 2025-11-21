using System;


namespace Shiny_Hunters_Companion
{
    public class Method
    {
        public int MethodID { get; set; }
        public string MethodName { get; set; }
        public double BaseOdds { get; set; }
        public double OddsModifer { get; set; }
        public string Description { get; set; }

        public Method() { }
        public Method(
            int methodID, 
            string methodName, 
            double baseOdds, 
            double oddsModifer, 
            string description
            )
        {
            MethodID = methodID;
            MethodName = methodName;
            BaseOdds = baseOdds;
            OddsModifer=oddsModifer;
            Description = description;
        }
        public override string ToString()
        {
            //Add more if needed later on
            return MethodName;
        }
    }
}
