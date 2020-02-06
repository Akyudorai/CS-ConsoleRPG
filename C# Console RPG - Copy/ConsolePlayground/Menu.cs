using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Menu
    {
        Text text = new Text();
        Draw draw = new Draw();
        Control control = new Control();
        Battle battle = new Battle();

        // --------------------------- SWITCH DISPLAY ----------------------------

        public void DisplayContent(Player player, Map map, char Location)
        {
            Random rand = new Random();

            switch (Location)
            {                
                case 'H':                    
                    draw.DrawCity();
                    control.CityControls(player, map);
                    break;
                case ' ':
                    draw.ClearScreen();
                    int difficulty = map.mapDifficulty[map.playerXPos, map.playerYPos];
                    
                    int encounter = rand.Next(0, 100);
                    if (encounter > 60)
                    {                        
                        Console.SetCursorPosition((draw.gameWidth * 16 / 25), (draw.gameHeight / 8) - 1);
                        Console.Write(" Enemy Encountered! ");
                        Enemy enemy = new Enemy();
                        enemy.InitEnemy(difficulty);
                        draw.DrawEnemy(enemy);
                        battle.BattlePhase(player, enemy);                        
                    }
                    control.MainControls(map);
                    break;
                case 'B':
                    draw.ClearScreen();

                    bool prompt = true;
                    while (prompt == true)
                    {
                        Console.SetCursorPosition((draw.gameWidth * 14 / 25), (draw.gameHeight / 2) - 1);
                        Console.Write("You are about to enter a boss fight.");
                        Console.SetCursorPosition((draw.gameWidth * 14 / 25), (draw.gameHeight / 2));
                        Console.Write("Are you sure you wish to enter?");
                        Console.SetCursorPosition((draw.gameWidth * 14 / 25) + ("Are you sure you wish to enter?".Length / 3), (draw.gameHeight / 2) + 1);
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
                        draw.ClearScreen();
                    }
                    
                    control.MainControls(map);                    
                    break;
            }
        }
        
        
    }
}
