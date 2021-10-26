using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    public class Product
    {
        private string name;
        private double price;
        private double weight;
        private int expirationDate;
        private DateTime creationDate;

        public Product(string name, double price, double weight, int expirationDate, DateTime creationDate)
        {
            Name = name;
            Price = price;
            Weight = weight;
            this.expirationDate = expirationDate;
            this.creationDate = creationDate;
        }

        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }



        public Product()
        {
            Name = "";
            Price = 1;
            Weight = 1;
            expirationDate = 1;
            creationDate = DateTime.Now;
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

        public int ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                if (value >= 0)
                {
                    expirationDate = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value of expiration date");
                }
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return creationDate;
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



        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            var other = (Product)obj;
            return (Name == other.Name && Price == other.Price && Weight == other.Weight
                && ExpirationDate == other.ExpirationDate && CreationDate == other.CreationDate);
        }

        public override String ToString()
        {
            return $"Name: {name}, price = {price}, weight = {weight}, expDate = {expirationDate}, " +
                $"{creationDate:d.MM.yyyy}";
        }

        public virtual void ChangePrice(int percent)
        {
            if (percent < -100 || percent > 100)
            {
                throw new ArgumentException("Incorrect value of percent");
            }
            Price += Price * (percent / 100.0);
        }

        public virtual void Parse(string data)
        {

            string[] info = data.Split();

            if (info.Length != 5)
            {
                throw new ArgumentException("Incorrect format of data");
            }

            Name = info[0];
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            Price = Convert.ToDouble(info[1], formatter);
            Weight = Convert.ToDouble(info[2], formatter);
            ExpirationDate = Convert.ToInt32(info[3]);
            string[] date = info[4].Split('.');
            int day = Convert.ToInt32(date[0]);
            int month = Convert.ToInt32(date[1]);
            int year = Convert.ToInt32(date[2]);
            creationDate = Convert.ToDateTime(new DateTime(year, month, day));
        }
    }
}
