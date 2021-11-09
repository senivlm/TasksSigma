using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task9
{
    class Program
    {// обробники подій слід винести в окремі класи з статичними методами
        static void WriteWrongItemIntoFile(string line)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Ростик\source\repos\Task9\Task9\WrongProductsInput.txt", true))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("Incorrect product");
                sw.Write(line + " ");
            }
        }

        static void CorrectWrongData(Storage storage, string line)
        {
            Console.WriteLine("Incorrect product");
            Console.WriteLine(line);
            Console.WriteLine("Do you want to correct wrong format?");
            char answer = (char)Console.Read();
            Console.ReadLine();
            switch (answer)
            {
                case 'y':
                    {
                        ConsoleStorageManager storageManager = new ConsoleStorageManager();
                        storageManager.EnterCorrectProductData(storage);
                    }
                    break;
                default:
                    break;
            }

        }

        static void RemoveExpiredProducts(Storage storage)
        {
            var expiredProducts = storage.FindExpiredProducts();
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Ростик\source\repos\Task9\Task9\RemovedExpiredProducts.txt", true))
            {
                sw.WriteLine("Expired product");
                foreach (var p in expiredProducts)
                {
                    sw.WriteLine(p.ToString());
                }
            }

            storage.RemoveExpiredProducts();
        }



        static void Main(string[] args)
        {
            Storage s = new Storage();
            ConsoleStorageManager storageManager = new ConsoleStorageManager();
            try
            {
                s.OnWriteWrongInput += WriteWrongItemIntoFile;
                s.OnCorrectInput += CorrectWrongData;
                storageManager.OnFind += RemoveExpiredProducts;
                s.ReadFromFile(@"C:\Users\Ростик\source\repos\Task9\Task9\ListOfProducts.txt");
                Console.WriteLine("Storage:");
                storageManager.PrintAllProducts(s);

                var products = s.FindProductByAtribute(Attributes.CreationDate, new DateTime(2021, 08, 20));
                Console.WriteLine("----------------------------------");
                foreach (var p in products)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.ReadLine();
        }
    }
}
