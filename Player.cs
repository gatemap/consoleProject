using System;
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
        GameExplain explain;
        int score = 0;
        ConsoleKeyInfo c;
        int[] cursurPos = new int[2];

        public Player()
        {
            playSound = new Sound();
            mainMenu = new MainMenu();

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

            if(selectMusic != null && selectMusic.musicSelect)
                selectMusic = null;

            if (playSound.selectMode)
            {
                if(playSound.moving)
                    playSound.Update();

                selectMusicKeySettings();
            }

            if (explain != null)
            {
                explain.Update();
                if(explain.exitExplain)
                {
                    explain = null;
                    Clear();
                    
                    mainMenu.menuSelect = true;
                    mainMenu.selected = false;
                }
            }

            if (playMode)
                playGameKeySettings();
        }

        public void Render()
        {
            if (mainMenu.menuSelect)
            {
                SetCursorPosition(cursurPos[0], cursurPos[1]);
                Write(">");
                mainMenu.Render();
            }

            if (playSound.selectMode)
            {
                SetCursorPosition(cursurPos[0], cursurPos[1]);
                Write(">");
                selectMusic.Render();
            }

            if (explain != null)
                explain.Render();
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
                        playSound.inAdvance = false;
                        playSound.moving = true;
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

            if(!playSound.inAdvance && playMode)
        }

        void selectedSong()
        {
            switch (playSound.selectMusic)
            {
                case Sound.Music.HongYeon:
                    break;
                case Sound.Music.K_DA:
                    break;
                case Sound.Music.Lost_stars:
                    break;
                case Sound.Music.See_you_agin:
                    break;
                case Sound.Music.Try_everything:
                    break;
                case Sound.Music.music_max:
                    break;
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
