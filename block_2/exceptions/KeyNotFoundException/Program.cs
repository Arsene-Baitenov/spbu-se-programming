using System;
using System.Collections.Generic;

namespace Exeption
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("abba", 5);
            dict.Add("opa", 6);
            try
            {
                Console.WriteLine(dict["zxc"]);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
