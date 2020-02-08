using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Menu
    {
        Control control = new Control();
        Battle battle = new Battle();

        // --------------------------- SWITCH DISPLAY ----------------------------

        public void DisplayContent(Player player, Map map, char Location)
        {
            Random rand = new Random();

            switch (Location)
            {                
                case 'H':                    
                    Draw.GetInstance().DrawCity();
                    control.CityControls(player, map);
                    break;
                case ' ':
                    Draw.GetInstance().ClearScreen();
                    int difficulty = map.mapDifficulty[map.playerXPos, map.playerYPos];
                    
                    int encounter = rand.Next(0, 100);
                    if (encounter > 60)
                    {                        
                        Console.SetCursorPosition((Draw.GetInstance().gameWidth * 16 / 25), (Draw.GetInstance().gameHeight / 8) - 1);
                        Console.Write(" Enemy Encountered! ");
                        Enemy enemy = Enemy.GenerateRandomEnemy();
                        //enemy.InitEnemy(difficulty);
                        Draw.GetInstance().DrawEnemy(enemy.entity);
                        battle.BattlePhase(player, enemy.entity);                        
                    }
                    control.MainControls(map);
                    break;
                case 'B':
                    Draw.GetInstance().ClearScreen();

                    bool prompt = true;
                    while (prompt == true)
                    {
                        Console.SetCursorPosition((Draw.GetInstance().gameWidth * 14 / 25), (Draw.GetInstance().gameHeight / 2) - 1);
                        Console.Write("You are about to enter a boss fight.");
                        Console.SetCursorPosition((Draw.GetInstance().gameWidth * 14 / 25), (Draw.GetInstance().gameHeight / 2));
                        Console.Write("Are you sure you wish to enter?");
                        Console.SetCursorPosition((Draw.GetInstance().gameWidth * 14 / 25) + ("Are you sure you wish to enter?".Length / 3), (Draw.GetInstance().gameHeight / 2) + 1);
                        Console.Write("(Y) | (N)");

                        var input = Console.ReadKey();
                        switch (input.KeyChar)
                        {
                            case 'Y':
                            case 'y': prompt = false; break;
                            case 'N':
                            case 'n': prompt = false; break;
                            default: break;
                        }
                        Draw.GetInstance().ClearScreen();
                    }
                    
                    control.MainControls(map);                    
                    break;
            }
        }
        
        
    }
}
