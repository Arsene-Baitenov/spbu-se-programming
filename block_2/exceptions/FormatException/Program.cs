using System;

namespace Exeption
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "two";
            try
            {
                Console.WriteLine(int.Parse(s));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
