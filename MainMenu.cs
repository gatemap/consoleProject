﻿using System;
using static System.Console;

namespace consoleProejct
{
    class MainMenu
    {
        public bool menuSelect = true;
        public bool selected = false;
        public enum MenuState
        {
            gameStart, explain, exit, menuState_Max
        };

        public MenuState menu = MenuState.gameStart;

        public void Init()
        {
            menuPrint();
        }

        public void Render()
        {
            menuPrint();
        }

        void menuPrint()
        {
            SetCursorPosition(0, 0);
            CursorVisible = false;

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
            WriteLine("\t\t\t\tGame Start");
            WriteLine("\t\t\t\tHow to Play");
            WriteLine("\t\t\t\tExit");
            WriteLine();
            WriteLine();
            WriteLine();
            WriteLine();
            WriteLine("\t\t\tPress spaceBar for chosse menu.");
        }
    }
}
