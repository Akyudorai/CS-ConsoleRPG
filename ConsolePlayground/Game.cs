﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Game
    {        
        Menu menu = new Menu();
        Map map = new Map();
        Control control = new Control();

        Scene scene = new Engine.Scenes.GameScene();

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
            map.initMap();
            Draw.GetInstance().DrawGame(Player.GetInstance(), map);            

            Console.SetCursorPosition(0, 0);
            Console.Write(map.playerXPos + ", " + map.playerYPos);
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
                Console.Write(map.playerXPos + ", " + map.playerYPos);
                
            }
        }
        
    }
}