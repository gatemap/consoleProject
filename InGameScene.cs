using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace consoleProejct
{
    class InGameScene
    {
        public bool noteStart { get; private set; } = false;     // 노트 시작
        public bool inputSuccess = false;                       // 정확한 입력 체크
        public List<String> inList;
        public byte verdict { get; private set; } = 0;          // 판정
        public byte upCount = 0;

        List<ConsoleColor> fontAnim = new List<ConsoleColor>(){ ConsoleColor.DarkRed, ConsoleColor.Red, ConsoleColor.DarkYellow,
                                    ConsoleColor.Green, ConsoleColor.DarkGreen, ConsoleColor.Blue,
                                    ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta};
        
        string[] arrow = { "→", "←", "↑", "↓" };
        public byte level { get; private set; } = 1;
        float sec = 0f;
        float castingSec = 0f;
        byte timeAtt = 7;
        
        Stopwatch timeCheck;
        Stopwatch castingTimer;

        public InGameScene()
        {
            timeCheck = new Stopwatch();
            castingTimer = new Stopwatch();
            inList = new List<String>();

            timeCheck.Restart();
        }

        public void Update()
        {
            if (timeCheck.ElapsedMilliseconds * 0.001 > sec)
            {
                sec += 1f;
                fontAnimation();
            }
        }

        public void Render()
        {
            printBanner();

            if (noteStart)
                castingBar();

            inGamePrint();
            
        }

        public void levelUpCount()
        {
            switch (level)
            {
                case 1:
                    if (upCount > 0)
                        levelUp();
                    break;
                case 2:
                    if (upCount > 1)
                        levelUp();
                    break;
                case 3:
                    if (upCount > 2)
                        levelUp();
                    break;
                case 4:
                    if (upCount > 3)
                        levelUp();
                    break;
                case 5:
                    if (upCount > 4)
                        levelUp();
                    break;
                case 6:
                    if (upCount > 5)
                        levelUp();
                    break;
                case 7:
                    if (upCount > 4)
                        levelUp();
                    break;
                case 8:
                    if (upCount > 3)
                        levelUp();
                    break;
                case 9:
                    if (upCount > 3)
                    {
                        Stopwatch tmpTimer = new Stopwatch();
                        tmpTimer.Start();
                        // 3초 쉬기
                        while (tmpTimer.ElapsedMilliseconds > 3000)
                            ;
                        level = 6;
                        upCount = 0;
                    }
                    break;
            }
        }

        void levelUp()
        {
            if (level < 9)
            {
                level++;
                upCount = 0;
            }
        }

        void inGamePrint()
        {
            ForegroundColor = ConsoleColor.White;
            SetCursorPosition(0, 7);
            Write($"\t\t현재 레벨 : {level}\n");

            if(sec >= 3f)
            {
                noteStart = true;
                castingTimer.Start();

                if (verdict == 0)
                    inputSuccess = false;

                SetCursorPosition(0, 10);

                if(!inputSuccess)
                {
                    Write("\t\t입력할 노트 : ");
                    if(verdict==0)
                    {
                        inList.Clear();
                        randomArrow(level);
                    }
                }
                else
                    Write("\t\t입력할 노트 :\t\t\t");
            }
        }

        void castingBar()
        {
            SetCursorPosition(40, 8);
            
            if (castingTimer.ElapsedMilliseconds *0.001 > castingSec && verdict <= timeAtt)
            {
                castingSec++;
                verdict++;

                for (int i = 1; i <= castingSec; i++)
                {
                    if (i > 6)
                        BackgroundColor = ConsoleColor.DarkGray;
                    else if (i > 4)
                        BackgroundColor = ConsoleColor.DarkBlue;
                    else if (i == 4)
                        BackgroundColor = ConsoleColor.Blue;
                    else if (i > 1)
                        BackgroundColor = ConsoleColor.DarkBlue;
                    else if (i > 0)
                        BackgroundColor = ConsoleColor.DarkGray;

                    if (BackgroundColor == ConsoleColor.DarkGray)
                        Write("   ");
                    else if(BackgroundColor == ConsoleColor.DarkBlue)
                        Write("  ");
                    else if(BackgroundColor == ConsoleColor.Blue)
                        Write(" ");
                }
            }

            BackgroundColor = ConsoleColor.Black;

            if(verdict > timeAtt)
            {
                castingSec = 0f;
                verdict = 0;
                castingTimer.Restart();
                SetCursorPosition(40, 8);
                Write("\t\t\t\t");
            }
        }

        void printBanner()
        {
            SetCursorPosition(0, 0);

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("\t★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★\t");
            Write("\t★");
            Write("\t\t\t\t\t\t\t\t★\n");
            Write("\t★");
            ForegroundColor = fontAnim[0];
            Write("\t\t\t안 ");
            ForegroundColor = fontAnim[1];
            Write("신");
            ForegroundColor = fontAnim[2];
            Write("나");
            ForegroundColor = fontAnim[3];
            Write("는 ");
            ForegroundColor = fontAnim[4];
            Write("리");
            ForegroundColor = fontAnim[5];
            Write("듬");
            ForegroundColor = fontAnim[6];
            Write("게");
            ForegroundColor = fontAnim[7];
            Write("임");
            ForegroundColor = ConsoleColor.Yellow;
            Write("\t\t\t★\n");
            Write("\t★");
            Write("\t\t\t\t\t\t\t\t★\n");
            WriteLine("\t★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★\t");
            WriteLine();
            WriteLine();

            //fontAnimation();
        }

        void fontAnimation()
        {
            ConsoleColor tmp = fontAnim[0];
            fontAnim.RemoveAt(0);
            fontAnim.Add(tmp);
        }

        void randomArrow(int n)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                int index = rnd.Next(4);
                Write($"{arrow[index]}");
                inList.Add(arrow[index]);
            }
        }
    }
}
