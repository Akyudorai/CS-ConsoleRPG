using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

namespace ConsolePlayground
{    
    class Map1 : Map
    {
        public Map1()
        {
            width = 9; height = 8;
            grid = new Zone[,]
            {
                { new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland()},
                { new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland()},
                { new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland()},
                { new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland()},
                { new City(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland()},
                { new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland()},
                { new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland()},
                { new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland()},
                { new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland(), new Grassland()}
            }; 

            for (int row = 0; row < grid.GetLength(1); row++)
            {
                for (int col = 0; col < grid.GetLength(0); col++)
                {
                    grid[col, row].coords = new Vector2Int(col, row);
                }
            }
        }

        public override void DrawMap(Box2D container)
        {
            int maxWidth = container.GetWidth();
            int maxHeight = container.GetHeight();
 
            Vector2Int position = new Vector2Int(container.GetCentreX(), container.GetCentreY());
            position = new Vector2Int(position.X - (maxWidth / 2), position.Y - (maxHeight / 2));
            
            for (int row = 0; row < grid.GetLength(1); row++)
            {
                position.X = container.GetCentreX() - (maxWidth / 2);                
                for (int col = 0; col < grid.GetLength(0); col++)
                {
                    grid[col, row].box.height = maxHeight / height;
                    grid[col, row].box.width = maxWidth / width;

                    Box2D.Adjacency adjacency;
                    {
                        if (row == 0 && col == 0) adjacency = Box2D.Adjacency.Bottom_Right;
                        else if (row == 0 && col == width - 1) adjacency = Box2D.Adjacency.Bottom_Left;
                        else if (row == height - 1 && col == 0) adjacency = Box2D.Adjacency.Top_Bottom_Right;
                        else if (row == height - 1 && col == width - 1) adjacency = Box2D.Adjacency.Top_Bottom_Left;
                        else if (row == 0) adjacency = Box2D.Adjacency.Bottom_Left_Right;
                        else if (row == height - 1) adjacency = Box2D.Adjacency.Top_Left_Right;
                        else if (col == 0) adjacency = Box2D.Adjacency.Top_Bottom_Right;
                        else if (col == width - 1) adjacency = Box2D.Adjacency.Top_Bottom_Left;
                        else adjacency = Box2D.Adjacency.All;
                    }
                    
                    grid[col, row].box.Draw(position, adjacency);
                    grid[col, row].box.start = position;
                    
                    if (grid[col, row].zone == ZoneType.City)
                        grid[col, row].box.Outline(grid[col, row].background);
                    if (grid[col, row].zone == ZoneType.Grassland)
                        grid[col, row].box.Outline(grid[col, row].background);

                    position.X += maxWidth / width;
                    
                }

                position.Y += maxHeight / height;
            }

            UpdateMap();

            base.DrawMap(container);
        }        
    }
}
