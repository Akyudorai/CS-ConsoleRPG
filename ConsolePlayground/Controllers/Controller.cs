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
        public enum State { menu, explore, combat }

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
                        else this.input = Game.GetInstance().scene.menu.commands.Count - 1;

                        scene.DrawMenu();
                        Input(scene);
                    }

                    else if (state == State.explore)
                    {
                        if (map.playerPos.Y - 1 >= 0)
                        {
                            map.UpdatePlayerPosition(new Vector2Int(0, -1));
                        }

                        scene.DrawMenu();
                        Input(scene);
                    }

                    else if (state == State.combat)
                    {
                        if (this.input > 0) this.input--;
                        else this.input = Game.GetInstance().scene.battle.combatMenu.commands.Count - 1;

                        scene.DrawMenu();
                        Input(scene);
                    }
                    
                    break;

                case ConsoleKey.DownArrow:

                    if (state == State.menu)
                    {
                        if (this.input < Game.GetInstance().scene.menu.commands.Count - 1) this.input++;
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

                        scene.DrawMenu();
                        Input(scene);
                    }

                    else if (state == State.combat)
                    {
                        if (this.input < Game.GetInstance().scene.battle.combatMenu.commands.Count - 1) this.input++;
                        else this.input = 0;

                        scene.DrawMenu();
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

                        scene.DrawMenu();
                        Input(scene);
                    }

                    else if (state == State.combat)
                    {

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

                        scene.DrawMenu();
                        Input(scene);
                    }

                    else if (state == State.combat)
                    {

                    }

                    break;

                case ConsoleKey.Enter:

                    if (state == State.menu)
                    {
                        if (Game.GetInstance().scene.menu.commands[this.input].dialogEvent != null)
                            Game.GetInstance().scene.menu.commands[this.input].dialogEvent.Activate();
                    }

                    else if (state == State.explore)
                    {
                        Game.GetInstance().scene.menu = map.GetZone().zoneMenu;
                        state = State.menu;
                    }

                    else if (state == State.combat)
                    {
                        if (Game.GetInstance().scene.battle.combatMenu.commands[this.input].dialogEvent != null)
                            Game.GetInstance().scene.battle.combatMenu.commands[this.input].dialogEvent.Activate();
                    }


                    this.input = 0;
                    
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
