using System;
using System.Collections.Generic;
using static System.Console;

namespace consoleProejct
{
    class Player
    {
        public bool playMode = false;
        public bool exit = false;

        MainMenu mainMenu;
        Sound playSound;
        SelectMusicMenu selectMusic;
        InGameScene inGame;
        GameExplain explain;

        ConsoleKeyInfo c;
        List<String> outList;
        uint score = 0;
        ushort combo = 1;
        ushort maxCombo = 0;
        int[] cursurPos = new int[2];
        // 0 : miss, 1 : bad, 2 : cool, 3 : great, 4 : perfect
        ushort[] result = new ushort[5];

        public Player()
        {
            playSound = new Sound();
            mainMenu = new MainMenu();
            outList = new List<string>();

            // 0 : x, 1 : y
            cursurPos[0] = 29;
            cursurPos[1] = 7;
        }

        public void Init()
        {
            mainMenu.Init();
            SetCursorPosition(cursurPos[0], cursurPos[1]);
            Write(">");
        }

        public void Update()
        {
            if (mainMenu.menuSelect)
                mainMenuKeySettings();

            // game explain
            if (explain != null)
            {
                explain.Update();
                if (explain.exitExplain)
                {
                    explain = null;
                    Clear();

                    mainMenu.menuSelect = true;
                    mainMenu.selected = false;
                }
            }

            // select Song view
            if (selectMusic != null && selectMusic.musicSelect)
                selectMusic = null;

            // select Song advance song play
            if (playSound.selectMode)
            {
                if (playSound.moving)
                    playSound.Update();

                selectMusicKeySettings();
            }

            if (playMode && inGame != null)
            {
                inGame.Update();
                if (inGame.noteStart && !inGame.inputSuccess && !playSound.fin && inGame.verdict >= 0)
                    playGameKeySettings();

                // miss 판정
                if (!inGame.inputSuccess && inGame.verdict >= 7)
                {
                    combo = 1;
                    result[0]++;
                }

                if (combo > maxCombo)
                    maxCombo = combo;

                if (!playSound.fin)
                    playSound.Update();
                else
                    resultKeySettings();
            }
        }

        public void Render()
        {
            if (mainMenu.menuSelect)
            {
                SetCursorPosition(cursurPos[0], cursurPos[1]);
                Write(">");
                mainMenu.Render();
            }

            if (explain != null)
                explain.Render();

            if (playSound.selectMode)
            {
                SetCursorPosition(cursurPos[0], cursurPos[1]);
                Write(">");
                selectMusic.Render();
            }

            if (inGame != null)
            {
                if(!playSound.fin)
                {
                    inGame.Render();
                    printCurrScore();
                }
                else
                    printResult();

                if (inGame.noteStart)
                    printOutnote();
            }
        }

        void mainMenuKeySettings()
        {
            if (KeyAvailable)
            {
                c = ReadKey();

                switch (c.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursurPos[1] > 7)
                        {
                            SetCursorPosition(cursurPos[0], cursurPos[1]);
                            Write(" ");
                            cursurPos[1]--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursurPos[1] < 9)
                        {
                            SetCursorPosition(cursurPos[0], cursurPos[1]);
                            Write(" ");
                            cursurPos[1]++;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        mainMenu.selected = true;
                        mainMenu.menuSelect = false;
                        break;
                }
            }

            if (cursurPos[1] == 7)
                mainMenu.menu = MainMenu.MenuState.gameStart;
            else if (cursurPos[1] == 8)
                mainMenu.menu = MainMenu.MenuState.explain;
            else if (cursurPos[1] == 9)
                mainMenu.menu = MainMenu.MenuState.exit;

            if (mainMenu.selected)
                mainMenuSelected();
        }

        void mainMenuSelected()
        {
            Clear();

            switch (mainMenu.menu)
            {
                case MainMenu.MenuState.gameStart:
                    selectMusic = new SelectMusicMenu();
                    selectMusic.Init();
                    playSound.selectMode = true;
                    playSound.moving = true;
                    break;
                case MainMenu.MenuState.explain:
                    explain = new GameExplain();
                    break;
                case MainMenu.MenuState.exit:
                    exit = true;
                    break;
            }
        }

        void selectMusicKeySettings()
        {
            if (KeyAvailable)
            {
                c = ReadKey();

                switch (c.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursurPos[1] > 7)
                        {
                            SetCursorPosition(cursurPos[0], cursurPos[1]);
                            Write(" ");
                            cursurPos[1]--;
                            SetCursorPosition(cursurPos[0], cursurPos[1]);
                            Write(">");
                            playSound.moving = true;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursurPos[1] < 11)
                        {
                            SetCursorPosition(cursurPos[0], cursurPos[1]);
                            Write(" ");
                            cursurPos[1]++;
                            SetCursorPosition(cursurPos[0], cursurPos[1]);
                            Write(">");
                            playSound.moving = true;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        playSound.moving = true;            // 미리듣기 bgm stop용
                        playSound.inAdvance = false;        // 2222
                        selectMusic.musicSelect = true;
                        playSound.selectMode = false;       // selectMode 벗어나기
                        playSound.Update();
                        playMode = true;
                        break;
                }
            }

            switch (cursurPos[1])
            {
                case 7:
                    playSound.selectMusic = Sound.Music.HongYeon;
                    break;
                case 8:
                    playSound.selectMusic = Sound.Music.K_DA;
                    break;
                case 9:
                    playSound.selectMusic = Sound.Music.Lost_stars;
                    break;
                case 10:
                    playSound.selectMusic = Sound.Music.See_you_agin;
                    break;
                case 11:
                    playSound.selectMusic = Sound.Music.Try_everything;
                    break;
            }

            if (!playSound.inAdvance && playMode)
            {
                Clear();
                inGame = new InGameScene();
            }
        }

        void playGameKeySettings()
        {
            if (KeyAvailable)
            {
                c = ReadKey();

                switch (c.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (inGame.inList.Count != outList.Count)
                            outList.Add("↑");
                        break;
                    case ConsoleKey.DownArrow:
                        if (inGame.inList.Count != outList.Count)
                            outList.Add("↓");
                        break;
                    case ConsoleKey.RightArrow:
                        if (inGame.inList.Count != outList.Count)
                            outList.Add("→");
                        break;
                    case ConsoleKey.LeftArrow:
                        if (inGame.inList.Count != outList.Count)
                            outList.Add("←");
                        break;
                    case ConsoleKey.Spacebar:
                        if (checkNote())
                        {
                            combo++;
                            inGame.upCount++;
                            scoreMark();
                            inGame.levelUpCount();
                            inGame.inputSuccess = true;
                            outList.Clear();
                            SetCursorPosition(0, 11);
                            Write("\t\t입력한 노트 :\t\t\t");
                        }
                        break;
                }
            }
        }

        void resultKeySettings()
        {
            if (KeyAvailable)
            {
                c = ReadKey();

                switch (c.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.R:
                        if (inGame != null)
                            inGame = null;
                        Clear();
                        playMode = false;
                        selectMusic = new SelectMusicMenu();
                        selectMusic.musicSelect = false;
                        playSound.moving = true;
                        playSound.inAdvance = true;
                        playSound.selectMode = true;
                        break;
                }
            }
        }

        void printOutnote()
        {
            // 틀렸거나 시간이 초과되었을 때 입력하는 부분 초기화 하는 코드
            if (!checkNote() || inGame.verdict == 0)
            {
                outList.Clear();
                SetCursorPosition(0, 11);
                Write("\t\t입력한 노트 :\t\t\t");
            }

            SetCursorPosition(0, 11);
            Write("\t\t입력한 노트 : ");
            foreach (string str in outList)
                Write($"{str}");
        }

        void printCurrScore()
        {
            SetCursorPosition(0, 9);
            Write($"\t\t현재 점수 : {score}");
        }

        bool checkNote()
        {
            if (inGame.inList.Count > 0 && outList.Count > 0)
            {
                for (int i = 0; i < outList.Count; i++)
                {
                    if (!outList[i].Equals(inGame.inList[i]))
                        return false;
                }
                return true;
            }
            return false;
        }

        void scoreMark()
        {
            switch (inGame.verdict)
            {
                // 판정 bad
                case 1:
                case 7:
                    score += (uint)(inGame.level * combo * 0.6);
                    result[1]++;
                    break;
                // 판정 cool
                case 2:
                case 6:
                    score += (uint)(inGame.level * combo * 0.7);
                    result[2]++;
                    break;
                // 판정 great
                case 3:
                case 5:
                    score += (uint)(inGame.level * combo * 0.8);
                    result[3]++;
                    break;
                // 판정 perfect
                case 4:
                    score += (uint)(inGame.level * combo * 1.0);
                    result[4]++;
                    break;
            }
        }
        void printResult()
        {
            SetCursorPosition(25, 15);
            Write($"Perfect : {result[4]}");
            SetCursorPosition(25, 16);
            Write($"Great : {result[3]}");
            SetCursorPosition(25, 17);
            Write($"Cool : {result[2]}");
            SetCursorPosition(25, 18);
            Write($"Bad : {result[1]}");
            SetCursorPosition(25, 19);
            Write($"Miss : {result[0]}");
            SetCursorPosition(37, 19);
            Write($"Maxcombo : {maxCombo}, resultScore : {score}");

            SetCursorPosition(0, 21);
            Write("\t\tPress R to reselect Song. For exit game is press esc.");
        }
    }
}
