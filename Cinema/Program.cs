using Cinema.Menu;
using System;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"    <<<< Kinoteatrimizga xush kelibsiz >>>>");

            Console.ForegroundColor = ConsoleColor.White;

            new MainMenu().Menu();
        }
    }
}
