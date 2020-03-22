using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Game
    {                
        public Map map = new Map1();        
        public Scene scene = new Engine.Scenes.GameScene();

        // Singleton
        // -------------------------------------------
        static Game game;
        public static Game GetInstance()
        {
            if (game == null) game = new Game();
            return game;
        }

        // Methodology
        // -------------------------------------------

        public void GameStart()
        {                      
            Text.GetInstance().CenterText("Welcome to Deloria");
            Console.ReadKey(true); Console.Clear();

            // [LOAD SAVED DATA HERE AND ASSIGN IT TO A NEW PLAYER OBJECT]

            Player.GetInstance().CreatePlayer();                        
            GameRun();
        }
        
        public void GameRun()
        {
            scene.SetMenu(map.GetZone().zoneMenu);
            map.InitializeMap();
            Draw.GetInstance().DrawGame(Player.GetInstance(), map);            
            
            bool game_is_running = true;
            while (game_is_running == true)
            {
                //Draw.GetInstance().DrawMainScene(player);
                //Draw.GetInstance().DrawPlayerInfo(player);

                scene.DrawScene();
                Player.GetInstance().Input(scene);

                //menu.DisplayContent(Player.GetInstance(), map, map.storeChar);
                //Draw.GetInstance().DrawMap(player, map);
                //Draw.GetInstance().DrawPlayer(player);               
                Console.SetCursorPosition(0, 0);
                
            }
        }
        
    }
}
