using System;
using static System.Console;

namespace consoleProejct
{
    class Player
    {
        MainMenu mainMenu;
        Sound playSound;
        int score = 0;
        ConsoleKeyInfo c;

        public Player()
        {
            playSound = new Sound();
            mainMenu = new MainMenu();
        }

        public void Update()
        {
            if (playSound.selectMode)
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
                        case ConsoleKey.Spacebar:
                            break;
                    }
                }
            }
            else
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
}
