using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class ConsoleStorageManager
    {
        public event FindExpiredProducts OnFind;
        private (string, double, double) ReadParams()
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price:");
            double price = Convert.ToDouble(Console.ReadLine(), formatter);
            Console.WriteLine("Enter weight:");
            double weight = Convert.ToDouble(Console.ReadLine(), formatter);
            return (name, price, weight);
        }

        public void PrintAllProducts(Storage s)
        {
            OnFind?.Invoke(s);
            foreach (var p in s)
            {
                Console.WriteLine(p.ToString());
            }
        }

        public void EnterCorrectProductData(Storage s)
        {
            Console.WriteLine("Choose the type of product (Enter 'P' for Product, 'M' for Meat, 'D' for DiaryProducts):");
            char type = (char)Console.Read();
            Console.ReadLine();

            switch (type)
            {
                case 'P':
                    {
                        var data = ReadParams();
                        Console.WriteLine("Enter expiration date:");
                        int expirationDate = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter creation date");
                        string date = Console.ReadLine();
                        DateTime dt = Convert.ToDateTime(date);
                        s.AddToStorage(new Product(data.Item1, data.Item2, data.Item3, expirationDate, dt));
                    }
                    break;
                case 'D':
                    {
                        var data = ReadParams();
                        Console.WriteLine("Enter expiration date:");
                        int expirationDate = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter creation date");
                        string date = Console.ReadLine();
                        DateTime dt = Convert.ToDateTime(date);
                        s.AddToStorage(new DiaryProducts(data.Item1, data.Item2, data.Item3, expirationDate, dt));


                    }
                    break;
                case 'M':
                    {
                        var data = ReadParams();
                        Console.WriteLine("Enter grade of meet ('H' for HighestGrade, " +
                      "'F' for FirstGrade, 'S' for SecondGrade):");
                        char grade = (char)Console.Read();
                        Console.ReadLine();
                        MeatType.Category category = MeatType.GetCategoryBySymbol(grade);
                        Console.WriteLine("Enter kind of meet ('L' for Lamb, 'V' for Veal" +
                       "'P' for Pork, 'C' for Chicken):");
                        char kind = (char)Console.Read();
                        Console.ReadLine();
                        MeatType.Kind kindOfMeet = MeatType.GetKindBySymbol(kind);
                        s.AddToStorage(new Meat(data.Item1, data.Item2, data.Item3, category, kindOfMeet));


                    }
                    break;
                default:
                    Console.WriteLine("Uknown type of product. Expected 'P'/'D'/'M'");

                    break;
            }
        }

        public void Run(Storage s)
        {
            Console.WriteLine("Enter the number of products you want to have in the storage:");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Cannot parse the value");
            }

            for (int i = 0; i < number; ++i)
            {
                EnterCorrectProductData(s);

            }
        }
    }
}
