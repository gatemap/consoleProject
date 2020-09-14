using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace consoleProejct
{
    class InGameScene
    {
        public bool isPlaying = false;      // 게임중인가
        public bool inputSuccess = false;   // 완벽하게 입력을 성공했는가
        public bool noteStart { get; private set; } = false;     // 노트 시작
        public List<String> inList;
        public byte verdict { get; private set; } = 0;

        List<ConsoleColor> fontAnim = new List<ConsoleColor>(){ ConsoleColor.DarkRed, ConsoleColor.Red, ConsoleColor.DarkYellow,
                                    ConsoleColor.Green, ConsoleColor.DarkGreen, ConsoleColor.Blue,
                                    ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta};
        
        string[] arrow = { "→", "←", "↑", "↓" };
        public byte level { get; private set; } = 1;
        float sec = 0f;
        float castingSec = 0f;
        
        Stopwatch timeCheck;
        Stopwatch castingTimer;
        ConsoleKeyInfo cKey;

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

            if(KeyAvailable)
            {
                cKey = ReadKey();
                // esc 입력시 플레이 중이던 음악 종료
                if (cKey.Equals(ConsoleKey.Escape))
                    isPlaying = false;
            }
        }

        public void Render()
        {
            printBanner();
            inGamePrint();
            if(noteStart)
                castingBar();
        }

        public void levelUp()
        {
            if (level < 7) level++;
        }

        void inGamePrint()
        {
            ForegroundColor = ConsoleColor.White;
            Write($"\t\t\t현재 레벨 : {level}\n");
            Write($"\t\t\t흐른 시간 : {sec}초\n");
            if(sec > 3f)
            {
                noteStart = true;
                Write("\t\t\t입력할 노트 : ");
                randomArrow(level);
            }
        }

        void castingBar()
        {
            SetCursorPosition(40, 10);
            
            if (castingTimer.ElapsedMilliseconds *0.0001 > castingSec && verdict < 15)
            {
                castingSec++;
                verdict++;

                if (verdict > 0)
                    BackgroundColor = ConsoleColor.Black;
                else if (verdict > 8)
                    BackgroundColor = ConsoleColor.DarkBlue;
                else if (verdict == 11)
                    BackgroundColor = ConsoleColor.Blue;
                else if (verdict > 11)
                    BackgroundColor = ConsoleColor.DarkBlue;
                else if (verdict > 14)
                    BackgroundColor = ConsoleColor.Black;

                for (int i = 0; i < (int)castingSec; i++)
                    Write(" ");
            }

            BackgroundColor = ConsoleColor.Black;

            if(verdict == 15)
            {
                castingSec = 0f;
                verdict = 0;
                castingTimer.Restart();
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
            fontAnim.Add(tmp);
            fontAnim.RemoveAt(0);
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
            WriteLine();
        }
    }
}
