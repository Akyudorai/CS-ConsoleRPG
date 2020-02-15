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
       
        Box2D optionsBar;
        Box2D questInfo;

        Box2D map;
        public Box2D mapDetails;

        Box2D rightPanel;

        Box2D healthBar;
        Box2D energyBar;

        

        public GameScene()
        {
            // Left Panel
            infobar = new Box2D(new Vector2Int(Console.WindowWidth / 15, Console.WindowHeight / 15), (Console.WindowWidth / 5 - Console.WindowWidth / 15), (Console.WindowHeight * 3/10 - Console.WindowHeight / 15));
            optionsBar = new Box2D(new Vector2Int(infobar.start.X, infobar.end.Y), infobar.GetWidth(), (Console.WindowHeight * 7 / 10 - infobar.end.Y));
            questInfo = new Box2D(new Vector2Int(infobar.start.X, optionsBar.end.Y), infobar.GetWidth(), (Console.WindowHeight * 9 / 10 - optionsBar.end.Y));
            boxes.Add(infobar);
            boxes.Add(optionsBar);
            boxes.Add(questInfo);

            // Map
            map = new Box2D(new Vector2Int(Console.WindowWidth / 5 + 1, Console.WindowHeight / 15), (Console.WindowWidth * 7/10 - Console.WindowWidth / 5 - 1), (Console.WindowHeight * 9/10 - Console.WindowHeight * 2/15 - 1));
            mapDetails = new Box2D(new Vector2Int(map.start.X, map.end.Y), map.GetWidth(), Console.WindowHeight / 15 + 1);
            boxes.Add(map);
            boxes.Add(mapDetails);

            // Right Panel
            rightPanel = new Box2D(new Vector2Int(map.end.X + 1, map.start.Y), infobar.GetWidth(), infobar.GetHeight() + optionsBar.GetHeight() + questInfo.GetHeight());
            boxes.Add(rightPanel);

            // HealthBar
            healthBar = new Box2D(new Vector2Int(infobar.start.X + 2, infobar.start.Y + 5), infobar.GetWidth() - 4, 2);
            energyBar = new Box2D(new Vector2Int(infobar.start.X + 2, infobar.start.Y + 8), infobar.GetWidth() - 4, 2);


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
            
            #region Left Panel
            infobar.Draw(Box2D.Adjacency.Bottom);
            optionsBar.Draw(Box2D.Adjacency.Top_Bottom);
            questInfo.Draw(Box2D.Adjacency.Top);

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
                
                    healthBar.Draw(Box2D.Adjacency.None);

                    double onechunk = 26.0 / player.entity.maxHealth;

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

                    energyBar.Draw(Box2D.Adjacency.None);

                    onechunk = 26.0 / player.entity.maxEnergy;

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
            DrawMenu();

            // Draw Quest Info

            #endregion

            #region Right Panel
            rightPanel.Draw(Box2D.Adjacency.None);


            #endregion

            #region Map
            Map _map = Game.GetInstance().map;

            map.Draw(Box2D.Adjacency.None);
            mapDetails.Draw(Box2D.Adjacency.None);
            
            Map currentMap = Game.GetInstance().map;
            currentMap.DrawMap(map);
            
            #endregion

        }

        public override void DrawMenu()
        {
            // Draw Options Dialog
            for (int i = 0; i < menu.commands.Length; i++)
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
                Console.Write(menu.commands[i]); 
            }

            // Reset
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void LogPanel_2(string text)
        {
            // Clear the entire panel of text
            Console.SetCursorPosition(mapDetails.start.X + 1, mapDetails.GetCentreY()); 
            for (int row = 0; row < mapDetails.height - 1; row++)
            {
                Console.SetCursorPosition(mapDetails.start.X + 1, mapDetails.start.Y + 1 + row);
                for (int col = 0; col < mapDetails.width - 1; col++)
                {
                    Console.Write(" ");
                }                
            }

            // Write the new text
            Console.SetCursorPosition(mapDetails.GetCentreX() - (text.Length / 2), mapDetails.GetCentreY());
            Console.Write(text);
        }
    }
}
