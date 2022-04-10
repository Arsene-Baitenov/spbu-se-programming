using System;

namespace Exeption
{
    class Program
    {
        static void Main()
        {
            try
            {
                int a = 4, b = 0;
                Console.WriteLine(a / b);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
