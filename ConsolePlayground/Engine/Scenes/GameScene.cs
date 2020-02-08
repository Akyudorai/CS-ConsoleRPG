using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

namespace ConsolePlayground.Engine.Scenes
{
    class GameScene : Scene
    {
        Box2D infobar;
        Box2D map;
        Box2D optionsBar;
        Box2D questInfo;

        Box2D healthBar;
        Box2D energyBar;

        CommandList commands = new CommandList();

        public GameScene()
        {
            // Left Panel
            infobar = new Box2D(Console.WindowWidth / 10, Console.WindowHeight / 15, Console.WindowWidth / 4, Console.WindowHeight * 3/10);
            optionsBar = new Box2D(infobar.start.X, infobar.end.Y, infobar.end.X, Console.WindowHeight * 7 / 10);
            questInfo = new Box2D(infobar.start.X, optionsBar.end.Y, infobar.end.X, Console.WindowHeight * 9 / 10);

            // Right Panel
            //map = new Box2D(Console.WindowWidth / 4, Console.WindowHeight / 15, Console.WindowWidth * 8/10, Console.WindowHeight * 9/10);
            
            // HealthBar
            healthBar = new Box2D(infobar.start.X + 2, infobar.start.Y + 5, infobar.end.X - 2, infobar.start.Y + 7);
            energyBar = new Box2D(infobar.start.X + 2, infobar.start.Y + 8, infobar.end.X - 2, infobar.start.Y + 10);

            boxes.Add(infobar);
            //boxes.Add(map);
            boxes.Add(optionsBar);
            boxes.Add(questInfo);

            Scene.activeScene = this;
        }

        public override void DrawScene()
        {
            Console.Clear();
            // Debug
            Console.SetCursorPosition(0, 0);
            //Console.Write(infobar.start.Y + ", " + infobar.end.Y + "\n");
            //Console.Write(optionsBar.start.Y + ", " + optionsBar.end.Y + "\n");
            //Console.Write(questInfo.start.Y + ", " + questInfo.end.Y);
            Console.Write(Player.GetInstance().input);

            // Draw UI
            //map.Draw();
            infobar.Draw();            
            optionsBar.Draw();
            questInfo.Draw();

            // Draw Player Information
            {
                Player player = Player.GetInstance();
                Vector2Int playerInfoPosition = new Vector2Int(infobar.GetCentreX(), infobar.start.Y + 2);

                #region Player Name, Level, and Class    
                
                    Console.SetCursorPosition(playerInfoPosition.X - (player.profile.Name.Length / 2), playerInfoPosition.Y);
                    Console.Write(player.profile.Name);

                    Console.SetCursorPosition(playerInfoPosition.X - (player.profile.Name.Length / 2) - 1, playerInfoPosition.Y + 1);
                    for (int i = 0; i < player.profile.Name.Length + 2; i++)
                    {
                        Console.Write("─");
                    }

                    string s = player.profile._Class.className + " (" + player.profile.Level + ")";
                    Console.SetCursorPosition(playerInfoPosition.X - (s.Length / 2), playerInfoPosition.Y + 2);
                    Console.Write(s);

                #endregion

                #region Player Health bar
                
                    healthBar.Draw();

                    double onechunk = 30.0 / player.entity.maxHealth;

                    // Draw Fill
                    int position = (healthBar.start.X + 1);
                    Console.SetCursorPosition(position, healthBar.start.Y + 1);
                    for (int i = 0; i <= onechunk * player.entity.currentHealth; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.CursorLeft = position++;
                        Console.Write(" ");
                    }

                    Console.BackgroundColor = ConsoleColor.Black;

                    // Draw Unfilled
                    for (int i = position; i < healthBar.end.X; i++)
                    {                        
                        Console.CursorLeft = position++;
                        Console.Write(" ");
                    }

                    // Draw Health Text
                    //Console.SetCursorPosition(healthBar.GetCentreX() - ("Health".Length / 2), healthBar.start.Y);
                    //Console.Write("Health");
                    string health = player.entity.currentHealth + " / " + player.entity.maxHealth;
                    Console.SetCursorPosition(healthBar.GetCentreX() - (health.Length / 2), healthBar.start.Y + 2);
                    Console.Write(health);    

                #endregion

                #region Player Energy bar

                    energyBar.Draw();

                    onechunk = 30.0 / player.entity.maxEnergy;

                    // Draw Fill
                    position = (energyBar.start.X + 1);
                    Console.SetCursorPosition(position, energyBar.start.Y + 1);
                    for (int i = 0; i <= onechunk * player.entity.currentEnergy; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.CursorLeft = position++;
                        Console.Write(" ");
                    }

                    Console.BackgroundColor = ConsoleColor.Black;

                    // Draw Unfilled
                    for (int i = position; i < energyBar.end.X; i++)
                    {
                        Console.CursorLeft = position++;
                        Console.Write(" ");
                    }

                // Draw Energy Text
                //Console.SetCursorPosition(energyBar.GetCentreX() - ("Energy".Length / 2), energyBar.start.Y);
                //Console.Write("Energy");
                string energy = player.entity.currentEnergy + " / " + player.entity.maxEnergy;
                Console.SetCursorPosition(energyBar.GetCentreX() - (energy.Length / 2), energyBar.start.Y + 2);
                Console.Write(energy);

                #endregion
                
                // Player Experience bar
            }
            
            // Draw Options Dialog
            DrawDialog();




            // Draw Quest Info
        }

        public override void DrawDialog()
        {
            // Draw Options Dialog
            for (int i = 0; i < commands.Commands.Length; i++)
            {
                if (Player.GetInstance().input == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.SetCursorPosition(optionsBar.start.X + 2, optionsBar.start.Y + 2 + i);
                Console.Write(commands.Commands[i]); 
            }

            // Reset
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
