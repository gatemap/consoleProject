using System;
using static System.Console;

namespace consoleProejct
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Test");

            GameManager game = new GameManager();
            game.Init();

            ReadLine();
        }
    }
}
