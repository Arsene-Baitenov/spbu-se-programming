using System;

namespace Exeption
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weapons = { "Sword", "Shield", "Wand" };
            Object[] inventory = weapons;
            try
            {
                inventory[2] = 100; // adding money
                Console.WriteLine(inventory[2]);
            }
            catch (ArrayTypeMismatchException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
