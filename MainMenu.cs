using System;
using System.Threading.Tasks;
using static System.Console;

namespace consoleProejct
{
    class MainMenu
    {
        public bool menuSelect = true;

        public void Init()
        {
            Title = "안 신나는 리듬 게임";
            SetCursorPosition(0, 0);
            WriteLine("\t*****************************************************************\t");
        }
    }
}
