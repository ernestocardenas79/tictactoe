using System;

namespace Tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Tictactoe!");
            new Game().play();
            Console.ReadKey();
        }
    }
}