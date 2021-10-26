using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class StoragesComparerManager
    {
        public static List<Product> GetAllCommonProducts(Storage s1, Storage s2)
        {
            IEnumerable<Product> commonProduct = s1.GetProductList().Intersect(s2.GetProductList(), new Comparer());
            return commonProduct.ToList();
        }

        public static List<Product> GetAllDifferentProducts(Storage s1, Storage s2)
        {

            IEnumerable<Product> differentProduct = s1.GetProductList().Except(s2.GetProductList(), new Comparer()).
                Concat(s2.GetProductList().Except(s1.GetProductList(), new Comparer()));
            return differentProduct.ToList();

        }

        public static List<Product> GetFirstDefferentProducts(Storage s1, Storage s2)
        {
            IEnumerable<Product> differentFirst = s1.GetProductList().Except(s2.GetProductList(), new Comparer());
            return differentFirst.ToList();
        }
    }
}
