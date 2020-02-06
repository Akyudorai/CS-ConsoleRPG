using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Battle
    {
        Draw draw = new Draw();

        bool playerTurn = true;
        bool enemyAlive = true;
        bool playerAlive = true;

        public void BattlePhase(Player player, Enemy enemy)
        {
            string attack1 = "attack 1";
            string attack2 = "attack 2";
            string special = "special";

            switch (player.ClassID)
            {
                case 1: attack1 = "Double Strike"; attack2 = "Triple Strike"; break; 
                default: break;
            }

            bool fight = true;
            while (fight == true)
            {
                draw.DrawPlayer(player);

                if (playerTurn == true)
                {
                    Console.SetCursorPosition((draw.gameWidth * 11 / 25), (draw.gameHeight / 6));
                    Console.Write("1) {0}\t2) {1}\t3) {2}\t4) Flee", attack1, attack2, special);

                    // COMBAT CONTROLS
                    var input = Console.ReadKey(true);
                    Console.SetCursorPosition((draw.gameWidth * 12 / 25), (draw.gameHeight / 6) + 2);
                    for (int i = 0; i < (draw.gameWidth * 12 / 25); i++)
                    {
                        Console.Write(" ");
                    }

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                            PrimaryAttack(player, enemy);
                            break;
                        case ConsoleKey.D2:
                            SecondaryAttack(player, enemy);
                            break;
                        case ConsoleKey.D3:

                            break;
                        case ConsoleKey.D4:
                            Random rand = new Random();
                            int flee = rand.Next(0, 100);
                            if (flee > 60)
                            {
                                Console.SetCursorPosition((draw.gameWidth * 12 / 25), (draw.gameHeight / 6) + 2);
                                Console.Write("You have fled the battle");
                                fight = false;
                                System.Threading.Thread.Sleep(500);
                            }
                            else
                            {
                                Console.SetCursorPosition((draw.gameWidth * 12 / 25), (draw.gameHeight / 6) + 2);
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
                            draw.ClearScreen();
                            break;
                    }                    
                }

                else
                {
                    draw.ClearScreen();
                    switch (1)
                    {
                        case 1 :
                            PrimaryAttack(player, enemy);
                            break;

                        default: break;
                    }
                    draw.ClearScreen();
                }

                if (enemyAlive == false)
                {
                    player.CheckExperience();
                    fight = false;
                }
            }
            draw.DrawPlayer(player);
            draw.ClearEnemy();
            draw.ClearScreen();
            enemyAlive = true;
            playerTurn = true;
        }
        
        public void PrimaryAttack(Player player, Enemy enemy)
        {                       
            if (playerTurn == true)
            {
                Random rand = new Random();
                // PLAYER ATTACK
                switch (1)
                {
                    // STRIKER
                    case 1:
                        Console.SetCursorPosition((draw.gameWidth * 12 / 25), (draw.gameHeight / 6) + 2);
                        Console.Write("Double Strike!");
                        double totaldamage = 0;
                        for (int i = 0; i < 2; i++ )
                        {
                            Console.SetCursorPosition((draw.gameWidth * 12 / 25), (draw.gameHeight / 6) + 3);
                            Console.CursorTop += i;
                            Console.CursorLeft = (draw.gameWidth * 12 / 25);
                            double damage = Math.Round(rand.Next(10, 15) * player.Power, 0);
                            Console.Write("Hit! ({0})", damage);
                            totaldamage += damage;
                            enemy.Health -= damage;

                            // Update the Health Bar
                            draw.ClearEnemy();
                            draw.DrawEnemy(enemy);
                            System.Threading.Thread.Sleep(50);
                            Console.CursorTop = (draw.gameHeight / 6) + 3 + i + 1;
                        }
                        
                        Console.CursorLeft = (draw.gameWidth * 12 / 25);
                        Console.Write("Total Damage: ({0})", totaldamage);

                            break;
                    // PREDATOR
                    case 2:

                        break;
                    // ADVANCER
                    case 3:

                        break;
                    // SENTINEL
                    case 4:

                        break;
                    // BERZERKER
                    case 5:

                        break;
                    // SIREN
                    case 6:

                        break;

                    default:

                        break;
                }
            }

            else
            {
                Random rand = new Random();

                Console.CursorTop = (draw.gameHeight / 8) + 2;
                Console.CursorLeft = (draw.gameWidth * 12 / 25);
                Console.Write("Enemy Attack!");
                
                // ENEMY ATTACK
                switch (enemy.ClassID)
                {
                    // STRIKER
                    case 1:                        
                        Console.Write("Double Strike!");
                        double totaldamage = 0;
                        for (int i = 0; i < 2; i++ )
                        {                            
                            Console.CursorTop += i;
                            Console.CursorLeft = (draw.gameWidth * 12 / 25);
                            double damage = Math.Round(rand.Next(10, 15) * enemy.Power, 0);
                            Console.Write("Hit! ({0})", damage);
                            totaldamage += damage;
                            player.Health -= damage;

                            // Update the Health Bar
                            draw.ClearEnemy();
                            draw.DrawEnemy(enemy);
                            System.Threading.Thread.Sleep(50);
                            Console.CursorTop = (draw.gameHeight / 6) + 3 + i + 1;
                        }
                        
                        Console.CursorLeft = (draw.gameWidth * 12 / 25);
                        Console.Write("Total Damage: ({0})", totaldamage);
                        break;
                    // PREDATOR
                    case 2:

                        break;
                    // ADVANCER
                    case 3:

                        break;
                    // SENTINEL
                    case 4:

                        break;
                    // BERZERKER
                    case 5:

                        break;
                    // SIREN
                    case 6:

                        break;

                    default:

                        break;
                }
            }

            if (player.Health <= 0)
            {
                Random rand = new Random();
                Console.CursorTop += 2;
                Console.CursorLeft = (draw.gameWidth * 12 / 25);
                int exp = rand.Next(5, 10);
                Console.Write("You is bad");                
                playerAlive = false;
            }

            if (enemy.Health <= 0)
            {
                Random rand = new Random();
                Console.CursorTop += 2;
                Console.CursorLeft = (draw.gameWidth * 12 / 25);
                int exp = rand.Next(5, 10);
                Console.Write("Enemy Defeated! +{0} XP!", exp * enemy.Level);
                player.Experience += (exp * enemy.Level);               
                enemyAlive = false;
            }

            if (playerTurn == true)
            {
                playerTurn = false;
            }

            else
            {
                playerTurn = true;
            }

            Console.ReadKey();
        }

        public void SecondaryAttack(Player player, Enemy enemy)
        {
            if (playerTurn == true)
            {
                Random rand = new Random();                

                    // PLAYER ATTACK
                switch (1)
                {
                    // STRIKER
                    case 1:
                        Console.SetCursorPosition((draw.gameWidth * 12 / 25), (draw.gameHeight / 6) + 2);
                        Console.Write("Triple Strike!");
                        double totaldamage = 0;
                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition((draw.gameWidth * 12 / 25), (draw.gameHeight / 6) + 3);
                            Console.CursorTop += i;
                            Console.CursorLeft = (draw.gameWidth * 12 / 25);
                            double damage = Math.Round(rand.Next(7, 15) * player.Power, 0);
                            Console.Write("Hit! ({0})", damage);
                            totaldamage += damage;
                            enemy.Health -= damage;

                            // Update the Health Bar
                            draw.ClearEnemy();
                            draw.DrawEnemy(enemy);
                            System.Threading.Thread.Sleep(50);
                            Console.CursorTop = (draw.gameHeight / 6) + 3 + i + 1;
                        }

                        Console.CursorLeft = (draw.gameWidth * 12 / 25);
                        Console.Write("Total Damage: ({0})", totaldamage);

                        break;
                    // PREDATOR
                    case 2:

                        break;
                    // ADVANCER
                    case 3:

                        break;
                    // SENTINEL
                    case 4:

                        break;
                    // BERZERKER
                    case 5:

                        break;
                    // SIREN
                    case 6:

                        break;

                    default:

                        break;
                }
            }

            else
            {
                // ENEMY ATTACK
                switch (enemy.ClassID)
                {
                    // STRIKER
                    case 1:

                        break;
                    // PREDATOR
                    case 2:

                        break;
                    // ADVANCER
                    case 3:

                        break;
                    // SENTINEL
                    case 4:

                        break;
                    // BERZERKER
                    case 5:

                        break;
                    // SIREN
                    case 6:

                        break;

                    default:

                        break;
                }
            }

            if (enemy.Health <= 0)
            {
                Random rand = new Random();
                Console.CursorTop += 2;
                Console.CursorLeft = (draw.gameWidth * 12 / 25);
                int exp = rand.Next(5, 10);
                Console.Write("Enemy Defeated! +{0} XP!", exp * enemy.Level);
                player.Experience += (exp * enemy.Level); 
                enemyAlive = false;
            }

            if (playerTurn == true)
            {
                playerTurn = false;
            }

            else
            {
                playerTurn = true;
            }

            Console.ReadKey();
        }
    }
}
