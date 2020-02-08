using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vectors;

namespace ConsolePlayground
{ 
    public struct Box2D
    {
        public Vector2Int start, end;
       
        public enum Side { top, bottom, left, right, none };
        public enum Corner { TL, TR, BL, BR };

        public Box2D(int startX, int startY, int endX, int endY)
        {
            start = new Vector2Int(startX, startY);
            end = new Vector2Int(endX, endY);            
        }

        

        public static Map<int, List<Side>> GetAdjacent(Box2D box2D, List<Box2D> list)
        {
            int numAdjacent = 0;
            List<Side> adjacentSides = new List<Side>();

            for (int i = 0 ; i < list.Count; i++)
            {
                if (box2D.start.X == list[i].end.X)
                {
                    numAdjacent++;
                    adjacentSides.Add(Side.left);                    
                }

                else if (box2D.end.X == list[i].start.X)
                {
                    numAdjacent++;
                    adjacentSides.Add(Side.right);
                }
                  
                else if (box2D.start.Y == list[i].end.Y)
                {
                    numAdjacent++;
                    adjacentSides.Add(Side.top);
                }
                
                else if (box2D.end.Y == list[i].start.Y)
                {
                    numAdjacent++;
                    adjacentSides.Add(Side.bottom);
                }
            }
            
            return new Map<int, List<Side>>(numAdjacent, adjacentSides);
        }

        public void Draw()
        {
            Console.SetCursorPosition(start.X, start.Y);

            Map<int, List<Side>> adjacents = GetAdjacent(this, Scene.activeScene.boxes);
            
            // Top-Left
            Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.TL, adjacents.y));

            // Left-Side
            Console.CursorTop++;
            Console.CursorLeft--;
            for (int X = start.Y; X < end.Y - 1; X++)
            {
                Console.Write("│");
                Console.CursorTop++;
                Console.CursorLeft--;
            }
            
            // Bottom-Left
            Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.BL, adjacents.y));

            // Bottom-Side
            for (int Y = start.X; Y < end.X - 1; Y++)
            {
                Console.Write("─");
            }

            // Bottom-Right
            Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.BR, adjacents.y));

            // Right-Side
            for (int Y = end.Y; Y > start.Y; Y--)
            {
                Console.CursorTop--;
                Console.CursorLeft--;
                Console.Write("│");
            }
            Console.CursorLeft--;

            // Top-Right
            Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.TR, adjacents.y));

            // Top-Side
            for (int X = end.X; X > start.X + 1; X--)
            {
                Console.CursorLeft--;
                Console.CursorLeft--;
                Console.Write("─");
            }
        }

        public int GetWidth()
        {
            return end.X - start.X;
        }        
        public int GetHeight()
        {
            return end.Y - start.Y;
        }        
        public int GetCentreX() { return (start.X + end.X) / 2; }
        
    }
}
