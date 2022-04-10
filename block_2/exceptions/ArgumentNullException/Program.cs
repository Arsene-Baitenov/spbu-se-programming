using System;
using System.IO;

namespace Exeption
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<int, int> a = null;
            Console.WriteLine(Tuple.Equals(a, new Tuple<int, int>(5, 6)));


            string path;
            //Console.WriteLine("Please, enter the full path to the any file");
            //path = Console.ReadLine();
            StreamReader sr;
            //sr = new StreamReader(path);
            
            //sr.Close();
            sr = null;
            
            try
            {
                Print(sr);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Print(StreamReader input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("Stream reader wasn't passed to the method Program.Print");
            }
        }
    }
}
