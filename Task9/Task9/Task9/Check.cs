using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    sealed internal class Check
    {
        public static string PrintProductData(ref Product product)
        {
            return product.ToString();
        }

        public static String PrintBuyData(Buy buy)
        {
            return buy.ToString();
        }
    }
}
