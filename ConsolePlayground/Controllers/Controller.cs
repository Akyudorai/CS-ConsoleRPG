using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

namespace ConsolePlayground
{
    public class Controller
    {
        public enum State { menu, explore }

        // Variables
        // -------------------------------------------
        // Profile handles all information about the player character
        public Profile profile;
        public Entity entity;
        
        public State state;


        public int input = 0;
        public void Input(Scene scene)
        {
            Map map = Game.GetInstance().map;

            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:

                    if (state == State.menu)
                    {
                        if (this.input > 0) this.input--;
                        else this.input = 2;

                        scene.DrawMenu();
                        Input(scene);
                    }

                    else if (state == State.explore)
                    {
                        if (map.playerPos.Y - 1 >= 0)
                        {
                            map.UpdatePlayerPosition(new Vector2Int(0, -1));
                        }

                        Input(scene);
                    }
                    
                    break;

                case ConsoleKey.DownArrow:

                    if (state == State.menu)
                    {
                        if (this.input < 2) this.input++;
                        else this.input = 0;

                        scene.DrawMenu();
                        Input(scene);
                    }

                    else if (state == State.explore)
                    {
                        if (map.playerPos.Y + 1 < map.grid.GetLength(1))
                        {
                            map.UpdatePlayerPosition(new Vector2Int(0, 1));
                            
                        }

                        Input(scene);
                    }
                    
                    break;

                case ConsoleKey.LeftArrow:

                    if (state == State.menu)
                    {
                        Input(scene);
                    }

                    else if (state == State.explore)
                    {
                        if (map.playerPos.X - 1 >= 0)
                        {                            
                            map.UpdatePlayerPosition(new Vector2Int(-1, 0));                            
                        }

                        Input(scene);
                    }

                    break;

                case ConsoleKey.RightArrow:

                    if (state == State.menu)
                    {
                        Input(scene);
                    }

                    else if (state == State.explore)
                    {
                        if (map.playerPos.X + 1 < map.grid.GetLength(0))
                        {
                            map.UpdatePlayerPosition(new Vector2Int(1, 0));
                        }

                        Input(scene);
                    }

                    break;

                case ConsoleKey.Enter:

                    // Activate Command
                    if (state == State.menu)
                    {
                        state = State.explore;
                    }

                    else if (state == State.explore)
                    {
                        state = State.menu;
                    }

                    break;

                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Input(scene);
                    break;
            }

        }
        
    }
}
