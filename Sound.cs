using IrrKlang;
using static System.Console;
using System.Diagnostics;

namespace consoleProejct
{
    class Sound
    {
        public bool selectMode = false; 
        public bool moving = false;     // 커서를 움직이는 중인가
        public bool inAdvance = true;   // 미리듣기 모드
        public enum Music
        {
            HongYeon, K_DA, Lost_stars, See_you_agin, Try_everything, music_max
        };

        public Music selectMusic { get; set; }

        ISoundEngine engine;
        ISound bgm;
        Stopwatch timer;
        string soundPath = "../../sound/";

        public Sound()
        {
            engine = new ISoundEngine();
            bgm = engine.Play2D(soundPath + "Idle_bgm.ogg", true);
            Clear();

            selectMusic = Music.HongYeon;
            timer = new Stopwatch();
        }

        public void Update()
        {
            moving = false;

            if(selectMode)
            {
                bgm.Stop();
                timer.Restart();

                // 0.5초 딜레이
                while (timer.ElapsedMilliseconds < 500)
                    ;
                playSelectSong();
                VolumeSetting();
            }

            if(!inAdvance)
            {

            }

        }

        void playSelectSong()
        {
            switch (selectMusic)
            {
                case Music.HongYeon:
                    bgm = engine.Play2D(soundPath + "HongYeon.mp3");
                    if (inAdvance)
                        bgm.PlayPosition = 78 * 1000;
                    break;
                case Music.K_DA:
                    bgm = engine.Play2D(soundPath + "K_DA.mp3");
                    if (inAdvance)
                        bgm.PlayPosition = 52 * 1000;
                    break;
                case Music.Lost_stars:
                    bgm = engine.Play2D(soundPath + "Lost stars.mp3");
                    if (inAdvance)
                        bgm.PlayPosition = 158 * 1000;
                    break;
                case Music.See_you_agin:
                    bgm = engine.Play2D(soundPath + "See you again.mp3");
                    if (inAdvance)
                        bgm.PlayPosition = 10 * 1000;
                    break;
                case Music.Try_everything:
                    bgm = engine.Play2D(soundPath + "Try everything.mp3");
                    if (inAdvance)
                        bgm.PlayPosition = 48 * 1000;
                    break;
            }
        }

        void VolumeSetting()
        {
            float sec = 0f;
            bgm.Volume = 0.5f;

            while(bgm.Volume < 1f)
            {
                if (timer.ElapsedMilliseconds * 0.001 > sec)
                {
                    sec += 0.1f;
                    bgm.Volume += 0.1f;
                }
            }

            timer.Stop();
        }
    }
}
