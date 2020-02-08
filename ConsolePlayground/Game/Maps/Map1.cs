using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Map1 : Map
    {
        public Box2D[,] grid = new Box2D[10, 10];

        public Map1()
        {
            for (int row = 0; row < mapArray.GetLength(0); row++)
            {
                for (int col = 0; col < mapArray.GetLength(1); col++)
                {
                    // Populate Grid
                }
            }
        }

        public override void DrawMap()
        {

        }
    }
}
