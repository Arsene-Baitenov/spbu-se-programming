using System;

namespace Exeption
{
    class Program
    {
        static void Main()
        {
            int[] a = new int[5];
            try
            {
                int num = 10;
                for (int i = 0; i < num; ++i)
                {
                    a[i] = 2 * i + 1;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
