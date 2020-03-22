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

        Box2D[] enemyHealthbars;
        Box2D[] enemyEnergybars;

        

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

            // Enemy Bars
            enemyHealthbars = new Box2D[] {
                new Box2D(new Vector2Int(rightPanel.start.X + 2, rightPanel.start.Y + 4), rightPanel.GetWidth() - 4, 2),
                new Box2D(new Vector2Int(rightPanel.start.X + 2, rightPanel.start.Y + 14), rightPanel.GetWidth() - 4, 2),
                new Box2D(new Vector2Int(rightPanel.start.X + 2, rightPanel.start.Y + 24), rightPanel.GetWidth() - 4, 2),
                new Box2D(new Vector2Int(rightPanel.start.X + 2, rightPanel.start.Y + 34), rightPanel.GetWidth() - 4, 2),
                new Box2D(new Vector2Int(rightPanel.start.X + 2, rightPanel.start.Y + 44), rightPanel.GetWidth() - 4, 2)
            };


            enemyEnergybars = new Box2D[] {
                new Box2D(new Vector2Int(rightPanel.start.X + 2, rightPanel.start.Y + 7), rightPanel.GetWidth() - 4, 2),
                new Box2D(new Vector2Int(rightPanel.start.X + 2, rightPanel.start.Y + 17), rightPanel.GetWidth() - 4, 2),
                new Box2D(new Vector2Int(rightPanel.start.X + 2, rightPanel.start.Y + 27), rightPanel.GetWidth() - 4, 2),
                new Box2D(new Vector2Int(rightPanel.start.X + 2, rightPanel.start.Y + 37), rightPanel.GetWidth() - 4, 2),
                new Box2D(new Vector2Int(rightPanel.start.X + 2, rightPanel.start.Y + 47), rightPanel.GetWidth() - 4, 2)
            };

            // Player Bars
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

        public override void DrawHealthAndEnergy(Battle battle)
        {
            ClearRightPanel();

            if (this.battle != battle) this.battle = battle;            
            if (battle == null) return;

            #region Player Health bar

            healthBar.Draw(Box2D.Adjacency.None);

            double p_onechunk = 26.0 / Player.GetInstance().entity.maxHealth;

            // Draw Fill
            int p_position = (healthBar.start.X + 1);
            Console.SetCursorPosition(p_position, healthBar.start.Y + 1);
            for (int i = 0; i <= p_onechunk * Player.GetInstance().entity.currentHealth; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.CursorLeft = p_position++;
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;

            // Draw Unfilled
            for (int i = p_position; i < healthBar.end.X; i++)
            {
                Console.CursorLeft = p_position++;
                Console.Write(" ");
            }

            // Draw Health Text
            //Console.SetCursorPosition(healthBar.GetCentreX() - ("Health".Length / 2), healthBar.start.Y);
            //Console.Write("Health");
            string p_health = Player.GetInstance().entity.currentHealth + " / " + Player.GetInstance().entity.maxHealth;
            Console.SetCursorPosition(healthBar.GetCentreX() - (p_health.Length / 2), healthBar.start.Y + 2);
            Console.Write(p_health);

            #endregion

            #region Player Energy bar

            energyBar.Draw(Box2D.Adjacency.None);

            p_onechunk = 26.0 / Player.GetInstance().entity.maxEnergy;

            // Draw Fill
            p_position = (energyBar.start.X + 1);
            Console.SetCursorPosition(p_position, energyBar.start.Y + 1);
            for (int i = 0; i <= p_onechunk * Player.GetInstance().entity.currentEnergy; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.CursorLeft = p_position++;
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;

            // Draw Unfilled
            for (int i = p_position; i < energyBar.end.X; i++)
            {
                Console.CursorLeft = p_position++;
                Console.Write(" ");
            }

            // Draw Energy Text
            //Console.SetCursorPosition(energyBar.GetCentreX() - ("Energy".Length / 2), energyBar.start.Y);
            //Console.Write("Energy");
            string p_energy = Player.GetInstance().entity.currentEnergy + " / " + Player.GetInstance().entity.maxEnergy;
            Console.SetCursorPosition(energyBar.GetCentreX() - (p_energy.Length / 2), energyBar.start.Y + 2);
            Console.Write(p_energy);

            #endregion

            if (battle.enemies.Length > 0)
            {
                for (int i = 0; i < battle.enemies.Length; i++)
                {
                    if (battle.enemies[i] == null)
                    {
                        continue;
                    }

                    #region Enemy Name, Level, and Class
                    Console.SetCursorPosition(rightPanel.GetCentreX() - (battle.enemies[i].profile.Name.Length / 2), rightPanel.start.Y + 1 + (i * 10));
                    Console.Write(battle.enemies[i].profile.Name);

                    Console.SetCursorPosition(rightPanel.GetCentreX() - (battle.enemies[i].profile.Name.Length / 2) - 1, rightPanel.start.Y + 2 + (i * 10));
                    for (int j = 0; j < battle.enemies[i].profile.Name.Length + 2; j++)
                    {
                        Console.Write("─");
                    }

                    string s = battle.enemies[i].profile._Class.className + " (" + battle.enemies[i].profile.Level + ")";
                    Console.SetCursorPosition(rightPanel.GetCentreX() - (s.Length / 2), rightPanel.start.Y + 3 + (i * 10));
                    Console.Write(s);
                    #endregion

                    #region Enemy Health bar

                    enemyHealthbars[i].Draw(Box2D.Adjacency.None);

                    double onechunk = 26.0 / battle.enemies[i].entity.maxHealth;

                    // Draw Fill
                    int position = (enemyHealthbars[i].start.X + 1);
                    Console.SetCursorPosition(position, enemyHealthbars[i].start.Y + 1);
                    for (int j = 0; j <= onechunk * battle.enemies[i].entity.currentHealth; j++)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.CursorLeft = position++;
                        Console.Write(" ");
                    }

                    Console.BackgroundColor = ConsoleColor.Black;

                    // Draw Unfilled
                    for (int j = position; j < enemyHealthbars[i].end.X; j++)
                    {
                        Console.CursorLeft = position++;
                        Console.Write(" ");
                    }

                    string health = battle.enemies[i].entity.currentHealth + " / " + battle.enemies[i].entity.maxHealth;
                    Console.SetCursorPosition(enemyHealthbars[i].GetCentreX() - (health.Length / 2), enemyHealthbars[i].start.Y + 2);
                    Console.Write(health);

                    #endregion

                    #region Enemy Energy bar

                    enemyEnergybars[i].Draw(Box2D.Adjacency.None);

                    onechunk = 26.0 / battle.enemies[i].entity.maxEnergy;

                    // Draw Fill
                    position = (enemyEnergybars[i].start.X + 1);
                    Console.SetCursorPosition(position, enemyEnergybars[i].start.Y + 1);
                    for (int j = 0; j <= onechunk * battle.enemies[i].entity.currentEnergy; j++)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.CursorLeft = position++;
                        Console.Write(" ");
                    }

                    Console.BackgroundColor = ConsoleColor.Black;

                    // Draw Unfilled
                    for (int j = position; j < enemyEnergybars[i].end.X; j++)
                    {
                        Console.CursorLeft = position++;
                        Console.Write(" ");
                    }

                    // Draw Energy Text
                    //Console.SetCursorPosition(energyBar.GetCentreX() - ("Energy".Length / 2), energyBar.start.Y);
                    //Console.Write("Energy");
                    string energy = battle.enemies[i].entity.currentEnergy + " / " + battle.enemies[i].entity.maxEnergy;
                    Console.SetCursorPosition(enemyEnergybars[i].GetCentreX() - (energy.Length / 2), enemyEnergybars[i].start.Y + 2);
                    Console.Write(energy);

                    #endregion
                }
            }
        }

        private void ClearRightPanel()
        {
            for (int j = 0; j < rightPanel.start.Y + rightPanel.height - 5; j++)
            {
                Console.SetCursorPosition(rightPanel.start.X + 2, rightPanel.start.Y + 1 + j);
                for (int i = 0; i < rightPanel.width - 3; i++)
                {                    
                    Console.Write(" ");
                }
            }
        }

        public override void DrawMenu()
        {
            ClearMenu();

            // Get the Current Menu Dialog
            //menu = Game.GetInstance().map.GetZone().zoneMenu;

            if (Player.GetInstance().state == Controller.State.menu)
            {
                // Draw Options Dialog
                for (int i = 0; i < menu.commands.Count; i++)
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
                    Console.Write(menu.commands[i].dialog);
                }
            }

            else if (Player.GetInstance().state == Controller.State.combat)
            {
                // Draw Options Dialog
                for (int i = 0; i < battle.combatMenu.commands.Count; i++)
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
                    Console.Write(battle.combatMenu.commands[i].dialog);
                }
            }

            

            // Reset
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void ClearMenu()
        {
            for (int j = 0; j < 20; j++)
            {
                Console.SetCursorPosition(optionsBar.start.X + 2, optionsBar.start.Y + 2 + j);
                for (int i = 0; i < optionsBar.width - 3; i++)
                {
                    Console.Write(" ");
                }                
            }            
        }
        
        public override void LogPanel_2(string text, string text2)
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
            if (text != "")
            {
                Console.SetCursorPosition(mapDetails.GetCentreX() - (text.Length / 2), mapDetails.GetCentreY());
                Console.Write(text);
            }

            if (text2 != "")
            {
                Console.SetCursorPosition(mapDetails.GetCentreX() - (text2.Length / 2), mapDetails.GetCentreY() + 1);
                Console.Write(text2);
            }
        }
        
    }
}
