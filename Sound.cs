using System;
using System.Collections.Generic;
using IrrKlang;
using static System.Console;

namespace consoleProejct
{
    class Sound
    {
        public bool selectMode = true;
        public enum Music
        {
            HongYeon, K_DA, Lost_stars, See_you_agin, Try_everything, music_max
        };

        ISoundEngine engine;
        ISound bgm;
        Music selectMusic;
        string soundPath = "../../sound/";

        public Sound()
        {
            engine = new ISoundEngine();
            bgm = engine.Play2D(soundPath + "Idle_bgm.ogg", true);
            Clear();
        }

        public void Update()
        {
            if(selectMode)
            {
                switch (selectMusic)
                {
                    case Music.HongYeon:
                        bgm.Stop();
                        bgm.PlayPosition = 60 * 1000;
                        bgm = engine.Play2D(soundPath + "HongYeon.mp3");
                        break;
                    case Music.K_DA:
                        bgm.Stop();
                        bgm.PlayPosition = 60 * 1000;
                        bgm = engine.Play2D(soundPath + "K_DA.mp3");
                        break;
                    case Music.Lost_stars:
                        bgm.Stop();
                        bgm.PlayPosition = 60 * 1000;
                        bgm = engine.Play2D(soundPath + "Lost stars.mp3");
                        break;
                    case Music.See_you_agin:
                        bgm.Stop();
                        bgm.PlayPosition = 60 * 1000;
                        bgm = engine.Play2D(soundPath + "See you again.mp3");
                        break;
                    case Music.Try_everything:
                        bgm.Stop();
                        bgm.PlayPosition = 10 * 1000;
                        bgm = engine.Play2D(soundPath + "Try everything.mp3");
                        break;
                }
            }
        }
    }
}
