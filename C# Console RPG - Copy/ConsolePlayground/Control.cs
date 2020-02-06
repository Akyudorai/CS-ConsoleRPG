using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Control
    {
        Draw draw = new Draw();

        public void MainControls(Map map)
        {
            Console.SetCursorPosition(4, 0);
            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map.playerXPos - 1 >= 0)
                    {
                        map.mapArray[map.playerXPos, map.playerYPos] = map.storeChar;
                        map.storeChar = map.mapArray[map.playerXPos - 1, map.playerYPos];                        
                        map.playerXPos--;
                        map.mapArray[map.playerXPos, map.playerYPos] = 'P';                        
                    }                  
                    break;
                case ConsoleKey.DownArrow:
                    if (map.playerXPos + 1 <= map.mapArray.GetLength(0) - 1)
                    {
                        map.mapArray[map.playerXPos, map.playerYPos] = map.storeChar;
                        map.storeChar = map.mapArray[map.playerXPos + 1, map.playerYPos];                        
                        map.playerXPos++;
                        map.mapArray[map.playerXPos, map.playerYPos] = 'P';                        
                    }

                    break;
                case ConsoleKey.LeftArrow:
                    if (map.playerYPos - 1 >= 0)
                    {
                        map.mapArray[map.playerXPos, map.playerYPos] = map.storeChar;
                        map.storeChar = map.mapArray[map.playerXPos, map.playerYPos - 1];                        
                        map.playerYPos--;
                        map.mapArray[map.playerXPos, map.playerYPos] = 'P';                        
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map.playerYPos + 1 <= map.mapArray.GetLength(1) - 1)
                    {
                        map.mapArray[map.playerXPos, map.playerYPos] = map.storeChar;
                        map.storeChar = map.mapArray[map.playerXPos, map.playerYPos + 1];                        
                        map.playerYPos++;
                        map.mapArray[map.playerXPos, map.playerYPos] = 'P';                        
                    }                    
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default :
                    MainControls(map);
                    break;
            }
            
        }

        public void CityControls(Player player, Map map)
        {
            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    
                    break;
                case ConsoleKey.D2:
                   
                    break;
                case ConsoleKey.D3:
                    
                    break;
                case ConsoleKey.D4:
                                       
                    break;
                case ConsoleKey.D5:
                    MainControls(map);
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default :
                    CityControls(player, map);
                    break;
            }
        }        
    }
}
