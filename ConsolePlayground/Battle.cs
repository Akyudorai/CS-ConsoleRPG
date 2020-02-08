using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Battle
    {
        bool playerTurn = true;
        bool enemyAlive = true;        

        public void BattlePhase(Player player, Entity enemy)
        {
            string attack1 = player.profile._Class.activeAbilities[0].name;
            string attack2 = player.profile._Class.activeAbilities[1].name;
            string ultimate = player.profile._Class.activeAbilities[2].name;
            
            bool fight = true;
            while (fight == true)
            {
                Draw.GetInstance().DrawPlayer(player);

                if (playerTurn == true)
                {
                    Console.SetCursorPosition((Draw.GetInstance().gameWidth * 11 / 25), (Draw.GetInstance().gameHeight / 6));
                    Console.Write("1) {0}\t2) {1}\t3) {2}\t4) Flee", attack1, attack2, ultimate);

                    // COMBAT CONTROLS
                    var input = Console.ReadKey(true);
                    Console.SetCursorPosition((Draw.GetInstance().gameWidth * 12 / 25), (Draw.GetInstance().gameHeight / 6) + 2);
                    for (int i = 0; i < (Draw.GetInstance().gameWidth * 12 / 25); i++)
                    {
                        Console.Write(" ");
                    }

                    switch (input.Key)
                    {
                        case ConsoleKey.D1: // Basic Ability
                            player.profile._Class.activeAbilities[0].Activate(Ability.Settings.Initialize(player, enemy.controller));
                            break;
                        case ConsoleKey.D2: // Intermediate Ability
                            player.profile._Class.activeAbilities[1].Activate(Ability.Settings.Initialize(player, enemy.controller));
                            break;
                        case ConsoleKey.D3: // Ultimate Ability
                            player.profile._Class.activeAbilities[2].Activate(Ability.Settings.Initialize(player, enemy.controller));
                            break;
                        case ConsoleKey.D4:
                            Random rand = new Random();
                            int flee = rand.Next(0, 100);
                            if (flee > 60)
                            {
                                Console.SetCursorPosition((Draw.GetInstance().gameWidth * 12 / 25), (Draw.GetInstance().gameHeight / 6) + 2);
                                Console.Write("You have fled the battle");
                                fight = false;
                                System.Threading.Thread.Sleep(500);
                            }
                            else
                            {
                                Console.SetCursorPosition((Draw.GetInstance().gameWidth * 12 / 25), (Draw.GetInstance().gameHeight / 6) + 2);
                                Console.Write("You are unable to flee the battle");
                                Console.ReadKey();
                                playerTurn = false;
                            }
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.DownArrow: break;                            
                        default:
                            Draw.GetInstance().ClearScreen();
                            break;
                    }                    
                }

                else
                {
                    Draw.GetInstance().ClearScreen();

                    Random rand = new Random();
                    int i = rand.Next(0, 100);

                    if (i <= 50) {  // Enemy uses basic ability 50% of the time
                        enemy.controller.profile._Class.activeAbilities[0].Activate(Ability.Settings.Initialize(enemy.controller, player));
                    } else if (i > 50 && i <= 85) { // Enemy uses intermediate ability 35% of the time
                        enemy.controller.profile._Class.activeAbilities[1].Activate(Ability.Settings.Initialize(enemy.controller, player));
                    } else if (i > 85) { // Enemy uses ultimate ability 15% of the time
                        enemy.controller.profile._Class.activeAbilities[2].Activate(Ability.Settings.Initialize(enemy.controller, player));
                    }

                    Draw.GetInstance().ClearScreen();
                }

                if (enemyAlive == false)
                {
                    player.AddExperience(15);
                    fight = false;
                }
            }
            Draw.GetInstance().DrawPlayer(player);
            Draw.GetInstance().ClearEnemy();
            Draw.GetInstance().ClearScreen();
            enemyAlive = true;
            playerTurn = true;
        }
        
        

            //if (player.Health <= 0)
            //{
            //    Random rand = new Random();
            //    Console.CursorTop += 2;
            //    Console.CursorLeft = (draw.gameWidth * 12 / 25);
            //    int exp = rand.Next(5, 10);
            //    Console.Write("You is bad");                
            //    playerAlive = false;
            //}

            //if (enemy.Health <= 0)
            //{
            //    Random rand = new Random();
            //    Console.CursorTop += 2;
            //    Console.CursorLeft = (draw.gameWidth * 12 / 25);
            //    int exp = rand.Next(5, 10);
            //    Console.Write("Enemy Defeated! +{0} XP!", exp * enemy.Level);
            //    player.Experience += (exp * enemy.Level);               
            //    enemyAlive = false;
            //}

            //if (playerTurn == true)
            //{
            //    playerTurn = false;
            //}

            //else
            //{
            //    playerTurn = true;
            //}

         
    }
}
