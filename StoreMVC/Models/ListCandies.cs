using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class ListCandies
    {
        private static List<Candy> candies = new List<Candy>();
        public static IEnumerable<Candy> Candies
        {
            get { return candies; }
        }
        public static void AddCandy(Candy candy)
        {
            candies.Add(candy);
        }

    }
}
