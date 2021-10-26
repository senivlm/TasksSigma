using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class Comparer : IEqualityComparer<Product>
    {
        public bool Equals(Product p1, Product p2)
        {
            if (Object.ReferenceEquals(p1, null) || Object.ReferenceEquals(p2, null))
                return false;

            return p1.Equals(p2);
        }

        public int GetHashCode(Product product)
        {
            if (Object.ReferenceEquals(product, null)) return 0;

            int hashProductName = product.Name == null ? 0 : product.Name.GetHashCode();

            return hashProductName;
        }

    }
}
