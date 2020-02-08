using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Map
    {

        public virtual void DrawMap() {}


        /// OLD STUFF

        // X Position determines the vertical point and Y Position determines the horizontal point
        public int playerXPos = 0;
        public int playerYPos = 0;
        
        public char storeChar = 'H';

        public char[,] mapArray = new char[6, 5];
        public int[,] mapDifficulty = 
        { {0, 1, 1, 3, 10},
          {1, 1, 2, 3, 3},
          {1, 2, 2, 3, 3},
          {2, 2, 2, 3, 3},
          {4, 4, 4, 5, 5},
          {15, 4, 4, 5, 20} };




        // --------------------------- GAME MAP ---------------------------
        public void initMap()
        {
            for (int row = 0; row < mapArray.GetLength(0); row++)
            {
                for (int col = 0; col < mapArray.GetLength(1); col++)
                {
                    mapArray[row, col] = ' ';
                }
            }

            mapArray[playerXPos, playerYPos] = 'P';
            mapArray[5, 4] = 'B';
            mapArray[5, 0] = 'B';
            mapArray[0, 4] = 'B';
        }
       
        public void drawMap()
        {
            UpdatePlayerPos();               
         
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.CursorLeft = (Console.WindowWidth * 3 / 21);
            Console.Write("┌");            
            for (int col = 0; col < mapArray.GetLength(1) - 1; col++)
            {
                Console.Write("────┬");
            }
            Console.Write("────┐");
            
            for (int row = 0; row < mapArray.GetLength(0); row++)
            {
                Console.WriteLine();
                Console.CursorLeft = (Console.WindowWidth * 3 / 21);
                Console.Write("│");
                for (int col = 0; col < mapArray.GetLength(1); col++)
                {
                    if (mapArray[row, col] == 'P')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }

                    if (mapArray[row, col] != 'P' && mapArray[row, col] != ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    Console.Write("  " + mapArray[row, col] + "  ");
                    
                    if (mapArray[row, col] != ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }

                }
                Console.CursorLeft--;
                Console.Write("│");
                Console.WriteLine();
                Console.CursorLeft = (Console.WindowWidth * 3 / 21);
                Console.Write("├");
                for (int col = 0; col < mapArray.GetLength(1) - 1; col++)
                {
                    Console.Write("─  ─┼");
                }
                Console.Write("─  ─┤");
            }
            
            Console.CursorLeft = (Console.WindowWidth * 3 / 21);
            Console.Write("└");
            for (int col = 0; col < mapArray.GetLength(1) - 1; col++)
            {
                Console.Write("────┴");
            }
            Console.Write("────┘");
            Console.ForegroundColor = ConsoleColor.DarkGray;            
        }      
        
        public void UpdatePlayerPos()
        {           
            mapArray[playerXPos, playerYPos] = 'P';
        }
        // --------------------------- GAME MAP END --------------------------
                
    }
}
