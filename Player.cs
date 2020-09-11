using System;
using static System.Console;

namespace consoleProejct
{
    class Player
    {
        int score = 0;
        ConsoleKeyInfo c;

        public void Update()
        {
            if (KeyAvailable)
            {
                c = ReadKey();

                switch (c.Key)
                {
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.RightArrow:
                        break;
                    case ConsoleKey.LeftArrow:
                        break;
                    case ConsoleKey.Spacebar:
                        break;
                }
            }
        }
    }
}
