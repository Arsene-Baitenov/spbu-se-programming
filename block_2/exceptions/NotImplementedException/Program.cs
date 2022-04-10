using System;

namespace Exeption
{
    class Program
    {
        static void Main()
        {
            try
            {
                TakePuff(4);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void TakePuff(int strength)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }
    }
}
