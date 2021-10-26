using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_1
{
    public delegate int CompareElements(Object p1, Object p2);
    class ArraySort
    {
        public static void Sort(Object[] obj, CompareElements comparer)
        {
            Object temp;
            for (int i = 1; i < obj.Length; ++i)
            {
                for (int j = 0; j < obj.Length - 1; ++j)
                {
                    if (comparer(obj[j], obj[j + 1]) == 1)
                    {
                        temp = obj[j];
                        obj[j] = obj[j + 1];
                        obj[j + 1] = (Product)temp;
                    }
                }
            }
        }
    }
}
