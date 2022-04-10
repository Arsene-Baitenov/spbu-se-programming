using System;
using System.Collections.Generic;

namespace Exeption
{
    class Program
    {
        static void Main()
        {
            List<int> stones = new List<int>();
            try
            {
                Console.WriteLine(stones[0]);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
