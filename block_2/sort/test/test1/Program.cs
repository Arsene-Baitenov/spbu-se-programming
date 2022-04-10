using System;
using System.IO;
using Sort;

namespace SortTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This is the test of the char sorting\nPlease, write the full path to the data file");
            string path = Console.ReadLine();
            using (StreamReader Input = new StreamReader(path))
            {
                string s = Input.ReadLine();
                uint num = uint.Parse(s);
                char[] a = new char[num];
                Console.WriteLine("Array:");
                for (uint i = 0; i < num; ++i)
                {
                    s = Input.ReadLine();
                    a[i] = char.Parse(s);
                    Console.Write($"{a[i]} ");
                }
                Console.WriteLine();
                sort.qsort(a, 0, num - 1);
                Console.WriteLine("Sorted array:");
                for (uint i = 0; i < num; ++i)
                {
                    Console.Write($"{a[i]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
