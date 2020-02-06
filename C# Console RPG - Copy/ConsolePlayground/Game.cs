using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Game
    {
        Player player = new Player(); 
        Text text = new Text();
        Menu menu = new Menu();
        Map map = new Map();
        Draw draw = new Draw();
        Control control = new Control();

        public void GameStart()
        {                      
            text.CenterText("Welcome to Havok");
            Console.ReadKey(true); Console.Clear();
            player.ChooseName();                        
            GameRun();
        }
        
        public void GameRun()
        {           
            map.initMap();
            draw.DrawGame(player, map);            

            Console.SetCursorPosition(0, 0);
            Console.Write(map.playerXPos + ", " + map.playerYPos);
            bool game_is_running = true;
            while (game_is_running == true)
            {
                menu.DisplayContent(player, map, map.storeChar);
                draw.DrawMap(player, map);
                draw.DrawPlayer(player);               
                Console.SetCursorPosition(0, 0);
                Console.Write(map.playerXPos + ", " + map.playerYPos);
                
            }
        }
        
    }
}
