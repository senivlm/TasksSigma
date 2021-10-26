using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    struct ProductInfo
    {
        public Product p;
        public int amount;

        public ProductInfo(Product p, int amount)
        {
            this.p = p;
            this.amount = amount;
        }

    }
    internal class Buy
    {
        private List<ProductInfo> productList;

        public Buy(List<ProductInfo> productList)
        {
            this.productList = productList;
        }

        public Buy()
        {
            productList = new List<ProductInfo>();
        }

        private double CountTotalPrice()
        {
            double totalPrice = 0.0;
            foreach (var product in productList)
            {
                totalPrice += product.amount * product.p.Price;
            }
            return totalPrice;
        }

        private double CountTotalWeight()
        {
            double totalWeight = 0.0;
            foreach (var product in productList)
            {
                totalWeight += product.amount * product.p.Weight;
            }
            return totalWeight;
        }


        public override string ToString()
        {

            string str = "";
            foreach (var product in productList)
            {
                str += product.p.ToString() + $"\tamount {product.amount}\n";
            }
            return str + "\n" + $"Total price: {CountTotalPrice()}\tTotal weight {CountTotalWeight()}";
        }

        public void IntitalizeProductList(ProductInfo product)
        {
            productList.Add(product);
        }
    }
}
