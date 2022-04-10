using System;
using System.IO;

namespace Exeption
{
    class Program
    {
        static void Main()
        {
            try
            {
                using(StreamReader sr = new StreamReader("zxc"))
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
