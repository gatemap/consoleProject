using System;
using static System.Console;

namespace consoleProejct
{
    class SelectMusicMenu
    {
        public bool musicSelect = false;

        public void Init()
        {
            printBanner();
        }

        public void Render()
        {
            printBanner();
            songList();
        }

        void songList()
        {
            ForegroundColor = ConsoleColor.White;
            WriteLine("\t\t\t\t홍연");
            WriteLine("\t\t\t\tK/DA");
            WriteLine("\t\t\t\tLost stars");
            WriteLine("\t\t\t\tSee you again");
            WriteLine("\t\t\t\tTry everything");
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
        }
    }
}
