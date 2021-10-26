using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productsList = new List<Product>();
            productsList.Add(new Product("Milk", 30, 0.875));
            productsList.Add(new Product("Banana", 21.5, 1.3));
            productsList.Add(new Product("Bread", 16, 1));
            productsList.Add(new Product("Chocolate", 30, 0.875));
            productsList.Add(new Product("Milk", 30, 0.875));

            Product[] productArray = productsList.ToArray();

            foreach (var elem in productArray)
            {
                Console.WriteLine(elem.ToString());
            }
            Console.WriteLine();
            Console.WriteLine();

            CompareElements comparer = new CompareElements(Product.CompareName);
            ArraySort.Sort(productArray, comparer);

            //CompareElements comparer = new CompareElements(Product.ComparePrice);
            //ArraySort.Sort(productArray, comparer);

            foreach (var elem in productArray)
            {
                Console.WriteLine(elem.ToString());
            }

            Console.ReadLine();
        }
    }
}
