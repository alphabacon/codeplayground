using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            Program codePlayground = new Program();
            List<Securities> securityList = SecurityRepository.LoadSecurities();

            //Securities filterdSecurities = codePlayground.QuerySymbol(securityList);
            //codePlayground.ReadOutSecurity(filterdSecurities);

            IEnumerable<Securities> securitiesByMarketCap = codePlayground.QueryMarketCapBySize(securityList);
            codePlayground.ReadOutSecuritiesMarketCap(securitiesByMarketCap);

            Console.Read();
        }

        /// <summary>
        /// Convert C# anonymous type into a explicit type.
        /// The var keyword is used to hold anonymous collections.
        /// </summary>
        /// <param name="securityList"></param>
        private Securities QuerySymbol(List<Securities> securityList)
        {
            Securities securities = new Securities();

            var anonymousType = from s in securityList
                        where s.Symbol.Equals("A")
                        select new
                        {
                            s.Symbol,
                            s.Name,
                            s.MarketCap,
                            s.EPS_Rating,
                            s.RS_Rating,
                            s.AD_Rating
                        };

            foreach (var item in anonymousType)
            {
                securities = new Securities(item.Symbol, item.Name, item.MarketCap, item.EPS_Rating, item.RS_Rating, item.AD_Rating);
            }
            return securities;
        }
        /// <summary>
        /// Store ordered securities directly in an IEnumerable of type Securities.
        /// Note that IEnumerable describes behavior while List is an implementation of that behavior.
        /// </summary>
        /// <param name="securityList"></param>
        /// <returns></returns>
        private IEnumerable<Securities> QueryMarketCapBySize(List<Securities> securityList)
        {
            IEnumerable<Securities> sortedMarketCap = from security in securityList
                                                      orderby security.MarketCap descending
                                                      select security;

            return sortedMarketCap;
        }

        private void ReadOutSecurity(Securities securities)
        {
            Console.WriteLine(securities.Name);
        }

        private void ReadOutSecuritiesMarketCap(IEnumerable<Securities> securityList)
        {
            Console.WriteLine("---Securities By MarketCap Descending---");
            foreach (Securities security in securityList)
            {
                Console.WriteLine(security.Name + ": " + security.MarketCap.ToString("C"));
            }
        }

        static void LoopOverSecurities(List<Securities> securityList)
        {
            Console.WriteLine("Total Securities: " + securityList.Count());
            Console.WriteLine("========================================");
            foreach (Securities security in securityList)
            {
                Console.WriteLine(security.Name);
            }
        }
    }
}
