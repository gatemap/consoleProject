using System;
using System.Threading.Tasks;

namespace consoleProejct
{
    class GameManager
    {
        public bool gameState = true;

        Player player;

        public void Init()
        {
            Console.Title = "C#으로 만든 안 신나는 콘솔 리듬 게임";
            player = new Player();
            player.Init();
        }

        public void Update()
        {
            player.Update();

            if (player.exit)
                gameState = false;
        }

        public void Render()
        {
            player.Render();
        }
    }
}
