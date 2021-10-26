using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    public class ProductEnum : System.Collections.IEnumerator
    {
        public List<Product> _products;

        int position = -1;

        public ProductEnum(List<Product> products)
        {
            _products = products;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _products.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _products[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
