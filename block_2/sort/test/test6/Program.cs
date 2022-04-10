using System;
using System.IO;
using Sort;

namespace SortTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This is the test of the Tuple<int, string> sorting with using the given comparator\nPlease, write the full path to the data file");
            string path = Console.ReadLine();
            using (StreamReader Input = new StreamReader(path))
            {
                string s = Input.ReadLine();
                uint num = uint.Parse(s);
                Tuple<int, string>[] a = new Tuple<int, string>[num];
                Console.WriteLine("Array:");
                for (uint i = 0; i < num; ++i)
                {
                    s = Input.ReadLine();
                    a[i] = new Tuple<int, string>(int.Parse(s.Substring(0, s.IndexOf(' '))), s.Substring(s.IndexOf(' ') + 1));
                    Console.WriteLine($"{a[i]}");
                }
                Console.WriteLine();
                sort.qsort(a, 0, num - 1, cmp);
                Console.WriteLine("Sorted array:");
                for (uint i = 0; i < num; ++i)
                {
                    Console.WriteLine($"{a[i]}");
                }
                Console.WriteLine();
            }
        }
        public static int cmp(Tuple<int, string> a, Tuple<int, string> b)
        {
            if (a.Item1 != b.Item1)
            {
                return a.Item1 - b.Item1;
            }
            int len = Math.Min(a.Item2.Length, b.Item2.Length);
            for (int i=0; i < len; ++i)
            {
                if (a.Item2[i] != b.Item2[i])
                {
                    return a.Item2[i] - b.Item2[i];
                }
            }
            return a.Item2.Length - b.Item2.Length;
        }
    }
}
