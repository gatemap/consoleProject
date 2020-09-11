using System;
using static System.Console;

namespace consoleProejct
{
    class GameExplain
    {
        public bool exitExplain = false;

        ConsoleKeyInfo c;

        public void Update()
        {
            if(KeyAvailable)
            {
                c = ReadKey();

                if (c.Key == ConsoleKey.Backspace)
                    exitExplain = true;
            }
        }

        public void Render()
        {
            explainPrint();
        }

        void explainPrint()
        {
            SetCursorPosition(15, 5);
            BackgroundColor = ConsoleColor.White;
            Write("\t\t\t\t\t\t\t\t\t\t\t");
            for(int i=6;i<20;i++)
            {
                SetCursorPosition(15, i);
                Write("  ");
                SetCursorPosition(94, i);
                Write("  ");
            }

            BackgroundColor = ConsoleColor.Black;
            SetCursorPosition(37, 8);
            Write("조\t\t      작\t\t법");
            SetCursorPosition(37, 13);
            Write("메뉴 내 조작키 : ↑, ↓, spacebar");
            SetCursorPosition(37, 15);
            Write("게임 내 조작키 : ↑, ↓, →, ←, spacebar");
            SetCursorPosition(37, 17);
            Write("현재 창에서 뒤로가기 : backspace");

            SetCursorPosition(15, 20);
            BackgroundColor = ConsoleColor.White;
            Write("\t\t\t\t\t\t\t\t\t\t\t");
            BackgroundColor = ConsoleColor.Black;
        }
    }
}
