using System;
using System.IO;
using Sort;

namespace SortTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This is the test of the custom class object sorting with using the given comparator\nPlease, write the full path to the data file");
            string path = Console.ReadLine();
            using (StreamReader Input = new StreamReader(path))
            {
                string s = Input.ReadLine();
                uint num = uint.Parse(s);
                MyInt[] a = new MyInt[num];
                Console.WriteLine("Array:");
                for (uint i = 0; i < num; ++i)
                {
                    s = Input.ReadLine();
                    a[i] = new MyInt(int.Parse(s));
                    a[i].Print();
                }
                Console.WriteLine();
                sort.qsort(a, 0, num - 1, cmp);
                Console.WriteLine("Sorted array:");
                for (uint i = 0; i < num; ++i)
                {
                    a[i].Print();
                }
                Console.WriteLine();
            }
        }
        public static int cmp(MyInt a, MyInt b)
        {
            return a.val - b.val;
        }
    }
    class MyInt
    {
        public MyInt(int _val)
        {
            val = _val;
        }
        public int val;
        public void Print()
        {
            Console.WriteLine($"({val})");
        }
    }
}
