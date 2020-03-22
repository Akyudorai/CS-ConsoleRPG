using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

public delegate void WriteMapDetails(string mapDetails);

namespace ConsolePlayground
{
    class Map
    {
        public Zone[,] grid;
        
        protected int width;
        public int GetWidth { get { return width; } }

        protected int height;
        public int GetHeight { get { return height; } }

        public Vector2Int playerPos = new Vector2Int(4, 0);


        public virtual void InitializeMap()
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    grid[row, col].text = string.Empty;
                }
            }

            grid[playerPos.X, playerPos.Y].text = "P";
        }

        public virtual void DrawMap(Box2D container) { }    
        
        public void UpdatePlayerPosition(Vector2Int direction)
        {
            grid[playerPos.X, playerPos.Y].text = " ";
            playerPos += direction;
            grid[playerPos.X, playerPos.Y].text = "P";
            
            UpdateMap();

            // Enter City Automatically
            if (grid[playerPos.X, playerPos.Y].zone == ZoneType.City)
            {
                Game.GetInstance().scene.menu = GetZone().zoneMenu;
                Player.GetInstance().SetState();                
            }
            
            // Random Event
            grid[playerPos.X, playerPos.Y].GenerateRandomEvent();

            
        }

        public virtual void UpdateMap()
        {
            
            string zoneDescription = grid[playerPos.X, playerPos.Y].zoneDescription;
            Game.GetInstance().scene.LogPanel_2(zoneDescription, "");
            
            for (int row = 0; row < grid.GetLength(1); row++)
            {
                for (int col = 0; col < grid.GetLength(0); col++)
                {
                    grid[col, row].DrawText();
                }
            }
        }

        public Zone GetZone() { return grid[playerPos.X, playerPos.Y]; }

        // --------------------------- GAME MAP END --------------------------
                
    }
}
