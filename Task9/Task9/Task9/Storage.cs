using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task9
{
    public enum Attributes { Name, Price, Weight, CreationDate, ExpirationDate };

    public delegate void WriteWrongItemToFile(string line);
    public delegate void CorrectWrongInput(Storage storage, string line);
    public delegate void FindExpiredProducts(Storage s);

    public class Storage : IEnumerable
    {
        private List<Product> products;

        public Storage()
        {
            products = new List<Product>();
        }

        public event WriteWrongItemToFile OnWriteWrongInput;
        public event CorrectWrongInput OnCorrectInput;



        public void FillArrayOfProducts()
        {
            products.Add(new Product("Banana", 33.5, 0.970));
            products.Add(new Product("Apple", 17.5, 1.4));
            products.Add(new DiaryProducts("Milk", 28.9, 0.875, 0, new DateTime(2021, 08, 20)));
            products.Add(new Meat("Chicken", 189, 1.23, MeatType.Category.FirstGrade, MeatType.Kind.Chicken));
            products.Add(new DiaryProducts("Cheese", 239.8, 1.65, 0, new DateTime(2021, 04, 10)));
        }


        public void AddToStorage(Product product)
        {
            products.Add(product);
        }

        public void ChangePrice(int percent)
        {
            foreach (var elem in products)
            {
                elem.ChangePrice(percent);
            }
        }

        public Product this[int index]
        {
            get
            {
                return products[index];
            }
            set
            {
                products[index] = value;
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var product in products)
            {
                str += product.ToString() + "\n";
            }
            return str;

        }

        public List<Product> GetAllMeetProducts()
        {
            return products.Where(x => x is Meat).ToList();
        }

        public void RemoveDiaryProducts(string path)
        {
            StreamWriter sw = new StreamWriter(path);

            var removerDiaryProducts = products.Where(x => x is DiaryProducts).ToList().FindAll(p => p.ExpirationDate < (DateTime.Now - p.CreationDate).Days);

            foreach (var product in removerDiaryProducts)
            {
                sw.WriteLine(product.ToString());
                products.Remove(product);
            }

            sw.Close();
        }

        private Product InitProductByCategory(char category)
        {
            switch (category)
            {
                case 'P':
                    return new Product();
                case 'M':
                    return new Meat();
                case 'D':
                    return new DiaryProducts();
                default:
                    throw new ArgumentException("Uknown category. Expected 'P', 'M' or 'D'");

            }
        }

        public void ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string data = "";
                    try
                    {

                        char category = (char)sr.Read();
                        sr.Read();
                        data = sr.ReadLine();
                        Product p = InitProductByCategory(category);
                        p.Parse(data);
                        products.Add(p);
                    }
                    catch (FormatException)
                    {
                        OnWriteWrongInput?.Invoke(data);
                        OnCorrectInput?.Invoke(this, data);
                        continue;
                    }

                }
            }
        }

        public List<Product> GetProductList()
        {
            return products;
        }

        public int GetCount()
        {
            return products.Count();
        }

        public void RemoveProductByName(string name)
        {
            products.RemoveAll((elem) => elem.Name == name);

        }

        public List<Product> FindExpiredProducts()
        {
            return products.FindAll(p => p.ExpirationDate < (DateTime.Now.Date - p.CreationDate).Days);
        }

        public void RemoveExpiredProducts()
        {
            products.RemoveAll(p => p.ExpirationDate < (DateTime.Now.Date - p.CreationDate).Days);
        }


        public List<Product> FindProductByAtribute(Attributes attribute, Object obj)
        {
            switch (attribute)
            {
                case Attributes.Name:
                    return products.FindAll(p => p.Name == Convert.ToString(obj));
                case Attributes.Price:
                    return products.FindAll(p => p.Price == Convert.ToDouble(obj));
                case Attributes.Weight:
                    return products.FindAll(p => p.Weight == Convert.ToDouble(obj));
                case Attributes.CreationDate:
                    return products.FindAll(p => p.CreationDate == Convert.ToDateTime(obj));
                case Attributes.ExpirationDate:
                    return products.FindAll(p => p.ExpirationDate == Convert.ToInt32(obj));
                default:
                    throw new Exception("No such attribute");
            }
        }

        public List<Product> FindProductsByName(string name)
        {
            return products.FindAll(p => p.Name == name);
        }

        public List<Product> FindProductsByPrice(int price)
        {
            return products.FindAll(p => p.Price == price);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ProductEnum GetEnumerator()
        {
            return new ProductEnum(products);
        }

    }
}
