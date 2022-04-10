using System;
using System.IO;
using Sort;

namespace SortTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This is the test of the int descending sorting with using the given comparator\nPlease, write the full path to the data file");
            string path = Console.ReadLine();
            using (StreamReader Input = new StreamReader(path))
            {
                string s = Input.ReadLine();
                uint num = uint.Parse(s);
                int[] a = new int[num];
                Console.WriteLine("Array:");
                for (uint i = 0; i < num; ++i)
                {
                    s = Input.ReadLine();
                    a[i] = int.Parse(s);
                    Console.WriteLine($"{a[i]} ");
                }
                Console.WriteLine();
                sort.qsort(a, 0, num - 1, cmp);
                Console.WriteLine("Sorted array:");
                for (uint i = 0; i < num; ++i)
                {
                    Console.WriteLine($"{a[i]} ");
                }
                Console.WriteLine();
            }
        }
        public static int cmp(int a, int b)
        {
            return b - a;
        }
    }
}
