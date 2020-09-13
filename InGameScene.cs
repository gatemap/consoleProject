using System;
using static System.Console;

namespace consoleProejct
{
    class InGameScene
    {
        public bool isPlaying = false;
        ConsoleColor[] fontAnim = { ConsoleColor.DarkRed, ConsoleColor.Red, ConsoleColor.DarkYellow,
                                    ConsoleColor.Green, ConsoleColor.DarkGreen, ConsoleColor.Blue,
                                    ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta};

        public void Render()
        {
            printBanner();
            inGamePrint();
        }

        void inGamePrint()
        {

        }

        void printBanner()
        {
            SetCursorPosition(0, 0);

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("\t★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★\t");
            Write("\t★");
            Write("\t\t\t\t\t\t\t\t★\n");
            Write("\t★");
            ForegroundColor = ConsoleColor.DarkRed;
            Write("\t\t\t안 ");
            ForegroundColor = ConsoleColor.Red;
            Write("신");
            ForegroundColor = ConsoleColor.DarkYellow;
            Write("나");
            ForegroundColor = ConsoleColor.Green;
            Write("는 ");
            ForegroundColor = ConsoleColor.DarkGreen;
            Write("리");
            ForegroundColor = ConsoleColor.Blue;
            Write("듬");
            ForegroundColor = ConsoleColor.DarkBlue;
            Write("게");
            ForegroundColor = ConsoleColor.DarkMagenta;
            Write("임");
            ForegroundColor = ConsoleColor.Yellow;
            Write("\t\t\t★\n");
            Write("\t★");
            Write("\t\t\t\t\t\t\t\t★\n");
            WriteLine("\t★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★\t");
            WriteLine();
            WriteLine();
            ForegroundColor = ConsoleColor.White;
        }

        void fontAnimation()
        {
            for(int i=1;i<fontAnim.Length;i++)
            {
                ConsoleColor tmp; 
            }
        }
    }
}
