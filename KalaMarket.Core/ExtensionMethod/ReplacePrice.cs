using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ExtensionMethod
{
    public static class ReplacePrice
    {
        public static int PriceReplacement(this string price)
        {
            int Price = 0;
            if (!string.IsNullOrEmpty(price))
            {
                Price = int.Parse(price.Replace(",", ""));
            }
            return Price;
        }
    }
}
