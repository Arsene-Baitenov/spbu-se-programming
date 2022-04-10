using System;
using System.IO;
using Sort;

namespace SortTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This is the test of the string sorting with using the given comparator\nPlease, write the full path to the data file");
            string path = Console.ReadLine();
            using (StreamReader Input = new StreamReader(path))
            {
                string s = Input.ReadLine();
                uint num = uint.Parse(s);
                string[] a = new string[num];
                Console.WriteLine("Array:");
                for (uint i = 0; i < num; ++i)
                {
                    a[i] = Input.ReadLine();
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
        public static int cmp(string a, string b)
        {
            int len = Math.Min(a.Length, b.Length);
            for (int i=0; i < len; ++i)
            {
                if (a[i] != b[i])
                {
                    return a[i] - b[i];
                }
            }
            return a.Length - b.Length;
        }
    }
}
