using System;
using System.Collections.Generic;
using IrrKlang;
using static System.Console;

namespace consoleProejct
{
    class Sound
    {
        ISoundEngine bgm;
        public bool selectMode = true;
        public enum music
        {
            m1, m2, m3, m4, m5, music_max
        };

        public Sound()
        {
            bgm = new ISoundEngine();
        }
    }
}
