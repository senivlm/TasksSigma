using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    struct MeatType
    {
        public enum Category { HighestGrade = 30, FirstGrade = 20, SecondGrade = 10 };
        public enum Kind { Lamb, Veal, Pork, Chicken };

        public static Category GetCategoryBySymbol(char grade)
        {
            switch (grade)
            {
                case 'H':
                    return Category.HighestGrade;
                case 'F':
                    return Category.FirstGrade;
                case 'S':
                    return Category.SecondGrade;
                default:
                    throw new ArgumentException("Uknown category");
            }

        }

        public static Kind GetKindBySymbol(char kind)
        {
            switch (kind)
            {
                case 'L':
                    return Kind.Lamb;
                case 'V':
                    return Kind.Veal;
                case 'P':
                    return Kind.Pork;
                case 'C':
                    return Kind.Chicken;
                default:
                    throw new ArgumentException("Uknown kind");
            }
        }
    }

    internal class Meat : Product
    {
        MeatType.Category category;
        MeatType.Kind kind;

        public Meat(string name, double price, double weight, MeatType.Category category, MeatType.Kind kind) : base(name, price, weight)
        {
            this.category = category;
            this.kind = kind;
        }

        public Meat()
        {
            this.category = MeatType.Category.HighestGrade;
            this.kind = MeatType.Kind.Chicken;
        }



        public override string ToString()
        {
            return base.ToString() + $", category: {category}, kind: {kind}";
        }

        public override void ChangePrice(int percent)
        {
            if (percent < -100 || percent > 100)
            {
                throw new ArgumentException("Incorrect value of percent");
            }
            Price += Price * (percent / 100.0) * ((int)category / 100.0);
        }

        public override void Parse(string date)
        {
            string[] info = date.Split();

            if (info.Length != 5)
            {
                throw new ArgumentException("Incorrect format of data");
            }

            Name = info[0];
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            Price = Convert.ToDouble(info[1], formatter);
            Weight = Convert.ToDouble(info[2], formatter);
            category = MeatType.GetCategoryBySymbol(char.Parse(info[3]));
            kind = MeatType.GetKindBySymbol(char.Parse(info[4]));
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            Meat other = (Meat)obj;
            return (Name == other.Name && Price == other.Price && Weight == other.Weight
               && category == other.category && kind == other.kind);
        }

    }
}
