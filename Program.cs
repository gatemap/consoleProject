using System;
using static System.Console;

namespace consoleProejct
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            game.Init();

            while(game.gameState)
            {
                game.Update();
                game.Render();
            }

        }
    }
}
