
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Vectors;

namespace ConsolePlayground
{
    class Draw
    {
        // Variables
        // -------------------------------------------
        public int gameHeight = (Console.WindowHeight * 9 / 10) + (Console.WindowHeight / 15);
        public int gameWidth = (Console.WindowWidth * 8 / 10) + (Console.WindowWidth / 10);

        // Singleton
        // -------------------------------------------
        static Draw draw;
        public static Draw GetInstance()
        {
            if (draw == null) draw = new Draw();
            return draw;
        }

        // Methodology
        // -------------------------------------------

        public void DrawBox(int x, int y, int height, int width)
        {            
            Console.SetCursorPosition(x, y);               
            // Left
            Console.Write("╔");
            Console.CursorTop++;
            Console.CursorLeft--;
            for (int row = 1; row < height; row++)
            {
                Console.Write("│");
                Console.CursorTop++;
                Console.CursorLeft--;
            }
            Console.Write("╚");
            // Bottom
            for (int col = 0; col < width; col++)
            {
                Console.Write("─");
            }
            Console.Write("╝");
            // Right
            for (int row = 0; row < height; row++)
            {
                Console.CursorTop--;
                Console.CursorLeft--;
                Console.Write("│");
            }
            Console.CursorLeft--;
            Console.Write("╗");            
            // Top
            for (int col = 0; col < width; col++)
            {
                Console.CursorLeft--;
                Console.CursorLeft--;
                Console.Write("─");
            }                                   
        }
        
        /*
        public string GetCornerPiece(Box2D.Corner corner, List<Box2D.Side> sides)
        {
            
            #region 4 Directional
            if (corner == Box2D.Corner.TL && sides.Contains(Box2D.Side.left) && sides.Contains(Box2D.Side.top) ||
                corner == Box2D.Corner.TR && sides.Contains(Box2D.Side.right) && sides.Contains(Box2D.Side.top) ||
                corner == Box2D.Corner.BR && sides.Contains(Box2D.Side.right) && sides.Contains(Box2D.Side.bottom) ||
                corner == Box2D.Corner.BL && sides.Contains(Box2D.Side.left) && sides.Contains(Box2D.Side.bottom))
            {
                return "╬";
            }

            #endregion

            #region 3 Directional
            
            //L-D-R
            else if (corner == Box2D.Corner.TL && sides.Contains(Box2D.Side.left) ||
                 corner == Box2D.Corner.TR && sides.Contains(Box2D.Side.right))
            { return "╦"; }

            //L-U-R
            else if (corner == Box2D.Corner.BL && sides.Contains(Box2D.Side.left) ||
                 corner == Box2D.Corner.BR && sides.Contains(Box2D.Side.right))
            { return "╩"; }

            //U-R-D
            else if (corner == Box2D.Corner.TL && sides.Contains(Box2D.Side.top) ||
                corner == Box2D.Corner.BL && sides.Contains(Box2D.Side.bottom))
            { return "╠"; }

            //U-L-D
            else if (corner == Box2D.Corner.TR && sides.Contains(Box2D.Side.top) ||
                corner == Box2D.Corner.BR && sides.Contains(Box2D.Side.bottom))
            { return "╣"; }

            #endregion

            #region 2 Directional

            else if (corner == Box2D.Corner.BL) { return "╚"; }
            else if (corner == Box2D.Corner.BR) { return "╝"; }
            else if (corner == Box2D.Corner.TL) { return "╔"; }
            else if (corner == Box2D.Corner.TR) { return "╗"; }

            #endregion

            // Error
            else { return "?"; }            
        }
        */


        // Presets
        // -------------------------------------------

        
        Vector2 questPosition = new Vector2((Console.WindowWidth / 10) + 2, (Console.WindowHeight * 10 / 15) + 2);
        public void DrawMainScene(Controller controller)
        {
            Console.Clear();

            #region Frame

            // Draw Main Frame
            DrawBox((Console.WindowWidth / 10), (Console.WindowHeight / 15), (Console.WindowHeight * 9 / 10), (Console.WindowWidth * 8 / 10));

            // Draw Menu Divider
            {
                Console.SetCursorPosition((Console.WindowWidth / 4), (Console.WindowHeight / 15));
                Console.Write("╦");
                Console.CursorTop++;
                for (int i = 0; i < (Console.WindowHeight * 9 / 10) - 1; i++)
                {
                    Console.CursorLeft--;
                    Console.Write("│");
                    Console.CursorTop++;
                }
                Console.CursorLeft--;
                Console.Write("╩");
            }
            
            // Draw Quest Display Divider
            {
                Console.SetCursorPosition((Console.WindowWidth / 10), (Console.WindowHeight * 10 / 15));
                Console.Write("╠");
                for (int i = (Console.WindowWidth / 10); i < (Console.WindowWidth / 4) - 1; i++)
                {
                    Console.Write("─");
                }
                Console.Write("╣");
            }

            
            #endregion


            

            ////int y = (Console.WindowHeight / 15) + 3;

            //// Write Player Information
            //Console.SetCursorPosition((Console.WindowWidth / 10) + 2, y - 1);
            //Console.WriteLine("{0}", controller.profile.Name);
            //Progress.GetInstance().PlayerHealth(Convert.ToInt32(Math.Round(controller.entity.currentHealth)), Convert.ToInt32(Math.Round(controller.profile._Stats.Health)));


            //y += 2;

            //// Write Abilities based on what the player has
            //Console.Write("Abilities: {0}", controller.profile.Abilities.Count);

            //for (int i = 0; i < controller.profile.Abilities.Count; i++)
            //{
            //    Console.SetCursorPosition((Console.WindowWidth / 10) + 2, y);

            //    if (controller.profile.Abilities[i].GetAbilityType() == Ability.Type.active)
            //        Console.Write("{0}. {1}", i, controller.profile.Abilities[i].name);
            //    y++;
            //}

        }

        

        /// OLD STUFF
        public void DrawGame(Player player, Map map)
        {
            DrawPlayer(player);
            DrawMap(player, map);

            DrawBox((Console.WindowWidth / 10), (Console.WindowHeight / 15), (Console.WindowHeight * 9 / 10), (Console.WindowWidth * 8 / 10));            
            // Draw Menu Divider
            Console.SetCursorPosition((Console.WindowWidth / 3), (Console.WindowHeight / 15));
            Console.Write("╦");
            Console.CursorTop++;
            for (int i = 0; i < (Console.WindowHeight * 9 / 10) - 1; i++)
            {
                Console.CursorLeft--;
                Console.Write("│");
                Console.CursorTop++;
            }
            Console.CursorLeft--;
            Console.Write("╩");

            // Draw Map Divider
            Console.SetCursorPosition((Console.WindowWidth / 11) + 1, (Console.WindowHeight * 4 / 7));
            Console.Write("╠");
            for (int i = 0; i < (Console.WindowWidth / 4) - 3; i++)
            {
                Console.Write("─");
            }
            Console.Write("╣");

            // Draw Command Line
            Console.SetCursorPosition((Console.WindowWidth / 3), (Console.WindowHeight * 46 / 50));
            Console.Write("╠");
            for (int i = 0; i < (Console.WindowWidth * 29 / 50) - 3; i++)
            {
                Console.Write("─");
            }
            Console.Write("╣");
            Console.SetCursorPosition((Console.WindowWidth / 3) + 2, (Console.WindowHeight * 47 / 50));
            Console.Write("Press ESC to quit");

            Console.ForegroundColor = ConsoleColor.DarkGray;                                           
        } 
       
        public void DrawMap(Player player, Map map)
        {                                                             
            Console.SetCursorPosition((gameWidth * 11 / 50), (gameHeight * 2 / 3));
            Console.Write("Game Map\n");
            Console.SetCursorPosition((gameWidth * 11 / 50), (gameHeight * 2 / 3) + 1);
            for (int i = 0; i < "Game Map".Length; i++)
            {
                Console.Write("─");
            } 

            //map.drawMap();            


        }

        public void DrawPlayer(Player player)
        {
            Console.SetCursorPosition((gameWidth * 9 / 50), (gameHeight / 8) - 1);
            Console.Write(player.profile.Name + " : " + player.profile._Class.className+ " : " + player.profile.Level);
            Console.SetCursorPosition((gameWidth * 9 / 50), (gameHeight / 8));
            for (int i = 0; i < player.profile.Name.Length + player.profile._Class.className.Length + Convert.ToString(player.profile.Level).Length + 6; i++ )
            {
                Console.Write("─");
            }                
            player.UpdatePlayer();
                           
        }        

        public void DrawEnemy(Entity enemy)
        {
            Console.SetCursorPosition((gameWidth * 9 / 50), (gameHeight / 8) + 11);
            Console.Write("Enemy : " + enemy.controller.profile._Class.className + " : " + enemy.controller.profile.Level);
            Console.SetCursorPosition((gameWidth * 9 / 50), (gameHeight / 8) + 12);
            for (int i = 0; i < "Enemy : ".Length + enemy.controller.profile._Class.className.Length + " : ".Length + Convert.ToString(enemy.controller.profile.Level).Length; i++)
            {
                Console.Write("─");
            }
            

            // Update the visual bar of enemy health/energy
            //enemy.UpdateEnemy();

        }

        public void ClearEnemy()
        {
            Console.CursorTop = (gameHeight / 8) + 11;
            Console.CursorLeft = (gameWidth * 6 / 50 + 1);            
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < (Console.WindowWidth / 5) + 1; i++)
                {
                    Console.Write(" ");
                }
                Console.CursorTop++;
                Console.CursorLeft = (gameWidth * 6 / 50);
            }
        }
        
        public void DrawCity()
        {
            string[] menu = { "1) Visit the Tavern", "2) Visit the Blacksmith", "3) Visit the General Store", "4) Visit the Castle", "5) Adventure!" };

            Console.SetCursorPosition((gameWidth * 16 / 25), (gameHeight / 8) - 1);
            Console.Write(" Welcome to Safehaven ");
            Console.SetCursorPosition((gameWidth * 16 / 25), (gameHeight / 8));
            for (int i = 0; i < " Welcome to Safehaven ".Length; i++)
            {
                Console.Write("─");
            }

            Console.SetCursorPosition((gameWidth * 12 / 25), (gameHeight / 6));
            for (int i = 0; i < menu.Length; i++)
            {
                Console.Write(menu[i]);
                Console.CursorTop++;
                Console.CursorLeft = (gameWidth * 12 / 25);
            }
            Console.SetCursorPosition(4, 0);
        }   
        
        public void ClearScreen()
        {
            Console.SetCursorPosition((Console.WindowWidth / 3) + 1, (Console.WindowHeight / 15) + 1);
            for (int i = 0; i < (Console.WindowHeight * 9 / 10) - (Console.WindowHeight * 2 / 25); i++)
            {
                for (int j = 0; j < gameWidth - (Console.WindowWidth / 3); j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                Console.CursorLeft = (Console.WindowWidth / 3) + 1;
            }            
        }
    }

    
}
