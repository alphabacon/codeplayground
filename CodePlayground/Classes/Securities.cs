using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePlayground
{
    /// <summary>
    ///Securities class w/ constuctor 
    /// </summary>
    public class Securities
    {
        public Securities()
        {

        }
        public Securities(string symbol, string name, double marketCap, int epsRating, int rsRating, string adRating)
        {
            Symbol = symbol;
            Name = name;
            MarketCap = marketCap;
            EPS_Rating = epsRating;
            RS_Rating = rsRating;
            AD_Rating = adRating;
        }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double MarketCap { get; set; }
        public int EPS_Rating { get; set; }
        public int RS_Rating { get; set; }
        public string AD_Rating { get; set; }
    }
    /// <summary>
    ///  Repository Pattern
    /// </summary>
    public static class SecurityRepository
    {
        public static List<Securities> LoadSecurities()
        {
            return new List<Securities>
            {
                new Securities ("ITT", "ITT Inc", 32741.1, 88, 97, "A-"),
                new Securities ("A", "Agilent Technologies Inc", 21630.1, 68, 87, "B-"),
                new Securities ("CEL", "Cellcom Israel Ltd", 973.9, 32, 47, "B+"),
                new Securities ("AA", "Alcoa Corporation", 8783.8, 79, 95, "B" ),
                new Securities ("AAAP", "Advanced Acce Applic Ads", 3117.2, 1, 98, "A+" ),
                new Securities ("TEAM", "Atlassian Corp Plc Cl A", 10686.6, 96, 95, "A-")
            };
        }
    }
}
