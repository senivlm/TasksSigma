using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TextWorker t = new TextWorker();
                t.ReadFromFile(@"C:\Users\Ростик\source\repos\Task8_3\Task8_3\Text.txt");
                Console.WriteLine(t.ToString());
                Console.WriteLine("Sentence with max depth");
                Console.WriteLine(t.GetMostDepthSentence());
                Console.WriteLine();
                Console.WriteLine(t.ToString());
                t.SortSentences();
                Console.WriteLine();
                Console.WriteLine(t.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
