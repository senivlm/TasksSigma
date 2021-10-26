using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_1
{
    class Product
    {
        private string name;
        private double price;
        private double weight;
        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public Product()
        {
            Name = "milk";
            Price = 20.8;
            Weight = 0.98;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0.0)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value of price");
                }
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0.0)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value of weight");
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}\t price: {Price}\tweight: {Weight}";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            var other = (Product)obj;
            return (name == other.name);
        }

        public static int CompareName(Object p1, Object p2)
        {
            Product first = (Product)p1;
            Product second = (Product)p2;
            return String.Compare(first.Name, second.Name);
        }

        public static int ComparePrice(Object p1, Object p2)
        {
            Product first = (Product)p1;
            Product second = (Product)p2;
            if (first.Price > second.Price)
            {
                return 1;
            }
            return 0;
        }
    }
}
