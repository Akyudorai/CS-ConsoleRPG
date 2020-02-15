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
        public int width, height;

        public enum Side { top, bottom, left, right, none };
        public enum Corner { TL, TR, BL, BR };

        public enum Adjacency {
            Left, Right, Top, Bottom,
            Top_Left, Top_Right, Bottom_Left, Bottom_Right, Top_Bottom, Left_Right,
            Top_Left_Right, Bottom_Left_Right, Top_Bottom_Left, Top_Bottom_Right,
            All, None
        }

        //public Box2D(int startX, int startY, int endX, int endY)
        //{
        //    start = new Vector2Int(startX, startY);
        //    end = new Vector2Int(endX, endY);            
        //}

        public Box2D(Vector2Int position, int width, int height)
        {
            this.width = width;
            this.height = height;

            start = position;
            end = new Vector2Int(position.X + width, position.Y + height);
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

        public void Draw(Adjacency adjacency)
        {
            Console.SetCursorPosition(start.X, start.Y);

            Map<int, List<Side>> adjacents = GetAdjacent(this, Scene.activeScene.boxes);
            
            // Top-Left
            switch (adjacency)
            {
                case Adjacency.Top:
                case Adjacency.Top_Bottom:    
                case Adjacency.Top_Bottom_Right:
                    Console.Write("╠"); break;
                case Adjacency.Left:
                case Adjacency.Left_Right:
                case Adjacency.Bottom_Left_Right:
                    Console.Write("╦"); break;
                case Adjacency.Top_Left:
                case Adjacency.Top_Left_Right:
                case Adjacency.All:
                    Console.Write("╬"); break;
                default:
                    Console.Write("╔"); break;
            }


            //Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.TL, adjacents.y));

            // Left-Side
            Console.CursorTop++;
            Console.CursorLeft--;
            for (int Y = start.Y; Y < start.Y + height - 1; Y++)
            {
                Console.Write("│");
                Console.CursorTop++;
                Console.CursorLeft--;
            }

            // Bottom-Left
            switch (adjacency)
            {
                case Adjacency.Bottom:
                case Adjacency.Top_Bottom:
                case Adjacency.Top_Bottom_Right:
                    Console.Write("╠"); break;
                case Adjacency.Left:
                case Adjacency.Left_Right:
                case Adjacency.Top_Left_Right:
                    Console.Write("╩"); break;
                case Adjacency.Bottom_Left:
                case Adjacency.Bottom_Left_Right:
                case Adjacency.All:
                    Console.Write("╬"); break;
                default:
                    Console.Write("╚"); break;
            }

            //Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.BL, adjacents.y));

            // Bottom-Side
            for (int X = start.X; X < start.X + width - 1; X++)
            {
                Console.Write("─");
            }

            // Bottom-Right
            switch (adjacency)
            {
                case Adjacency.Bottom:
                case Adjacency.Top_Bottom:
                case Adjacency.Top_Bottom_Left:
                    Console.Write("╣"); break;
                case Adjacency.Right:
                case Adjacency.Left_Right:
                case Adjacency.Top_Left_Right:
                    Console.Write("╩"); break;
                case Adjacency.Bottom_Right:
                case Adjacency.Bottom_Left_Right:
                case Adjacency.All:
                    Console.Write("╬"); break;
                default:
                    Console.Write("╝"); break;
            }

            //Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.BR, adjacents.y));

            // Right-Side
            for (int Y = start.Y + height; Y > start.Y; Y--)
            {
                Console.CursorTop--;
                Console.CursorLeft--;
                Console.Write("│");
            }
            Console.CursorLeft--;

            // Top-Right
            switch (adjacency)
            {
                case Adjacency.Top:
                case Adjacency.Top_Bottom:
                case Adjacency.Top_Bottom_Left:
                    Console.Write("╣"); break;
                case Adjacency.Right:
                case Adjacency.Left_Right:
                case Adjacency.Bottom_Left_Right:
                    Console.Write("╦"); break;
                case Adjacency.Top_Right:
                case Adjacency.Top_Left_Right:
                case Adjacency.All:
                    Console.Write("╬"); break;
                default:
                    Console.Write("╗"); break;
            }
            //Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.TR, adjacents.y));

            // Top-Side
            for (int X = start.X + width; X > start.X + 1; X--)
            {
                Console.CursorLeft--;
                Console.CursorLeft--;
                Console.Write("─");
            }
        }
        public void Draw(Vector2Int position, Adjacency adjacency)
        {
            Console.SetCursorPosition(position.X, position.Y);

            Map<int, List<Side>> adjacents = GetAdjacent(this, Scene.activeScene.boxes);

            // Top-Left
            switch (adjacency)
            {
                case Adjacency.Top:
                case Adjacency.Top_Bottom:
                case Adjacency.Top_Right:
                case Adjacency.Top_Bottom_Right:
                    Console.Write("╠"); break;
                case Adjacency.Left:
                case Adjacency.Left_Right:
                case Adjacency.Bottom_Left:
                case Adjacency.Bottom_Left_Right:
                    Console.Write("╦"); break;
                case Adjacency.Top_Left:
                case Adjacency.Top_Left_Right:
                case Adjacency.Top_Bottom_Left:
                case Adjacency.All:
                    Console.Write("╬"); break;
                default:
                    Console.Write("╔"); break;
            }


            //Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.TL, adjacents.y));

            // Left-Side
            Console.CursorTop++;
            Console.CursorLeft--;
            for (int Y = start.Y; Y < start.Y + height - 1; Y++)
            {
                Console.Write("│");
                Console.CursorTop++;
                Console.CursorLeft--;
            }

            // Bottom-Left
            switch (adjacency)
            {
                case Adjacency.Bottom:
                case Adjacency.Top_Bottom:
                case Adjacency.Top_Bottom_Right:
                    Console.Write("╠"); break;
                case Adjacency.Left:
                case Adjacency.Left_Right:
                case Adjacency.Top_Left:
                case Adjacency.Top_Bottom_Left:
                case Adjacency.Top_Left_Right:
                    Console.Write("╩"); break;
                case Adjacency.Bottom_Left:
                case Adjacency.Bottom_Left_Right:                
                case Adjacency.All:
                    Console.Write("╬"); break;
                default:
                    Console.Write("╚"); break;
            }

            //Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.BL, adjacents.y));

            // Bottom-Side
            for (int X = start.X; X < start.X + width - 1; X++)
            {
                Console.Write("─");
            }

            // Bottom-Right
            switch (adjacency)
            {
                case Adjacency.Bottom:
                case Adjacency.Top_Bottom:
                case Adjacency.Top_Bottom_Left:
                    Console.Write("╣"); break;
                case Adjacency.Right:
                case Adjacency.Left_Right:
                case Adjacency.Top_Left_Right:
                    Console.Write("╩"); break;
                case Adjacency.Bottom_Right:
                case Adjacency.Bottom_Left_Right:
                case Adjacency.All:
                    Console.Write("╬"); break;
                default:
                    Console.Write("╝"); break;
            }

            //Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.BR, adjacents.y));

            // Right-Side
            for (int Y = start.Y + height; Y > start.Y; Y--)
            {
                Console.CursorTop--;
                Console.CursorLeft--;
                Console.Write("│");
            }
            Console.CursorLeft--;

            // Top-Right
            switch (adjacency)
            {
                case Adjacency.Top:
                case Adjacency.Top_Bottom:
                case Adjacency.Top_Left:
                case Adjacency.Top_Bottom_Left:
                    Console.Write("╣"); break;
                case Adjacency.Right:
                case Adjacency.Left_Right:
                case Adjacency.Bottom_Left_Right:
                    Console.Write("╦"); break;
                case Adjacency.Top_Right:
                case Adjacency.Top_Left_Right:
                case Adjacency.All:
                    Console.Write("╬"); break;
                default:
                    Console.Write("╗"); break;
            }
            //Console.Write(ConsolePlayground.Draw.GetInstance().GetCornerPiece(Corner.TR, adjacents.y));

            // Top-Side
            for (int X = start.X + width; X > start.X + 1; X--)
            {
                Console.CursorLeft--;
                Console.CursorLeft--;
                Console.Write("─");
            }
        }

        public void Fill(ConsoleColor color)
        {
            for (int row = 0; row < height - 1; row++)
            {
                Console.SetCursorPosition(start.X + 1, start.Y + 1 + row);
                for (int col = 0; col < width - 1; col++)
                {                    
                    Console.BackgroundColor = color;
                    Console.Write(" ");
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Outline(ConsoleColor color)
        {
            Console.SetCursorPosition(start.X + 1, start.Y + 1);
            Console.BackgroundColor = color;

            // Left-Side            
            for (int Y = start.Y; Y < start.Y + height - 2; Y++)
            {
                Console.Write("  ");
                Console.CursorTop++;
                Console.CursorLeft--;
                Console.CursorLeft--;
            }
            
            // Bottom-Side
            for (int X = start.X; X < start.X + width - 1; X++)
            {
                Console.Write(" ");
            }
            
            // Right-Side
            for (int Y = start.Y + height; Y > start.Y + 2; Y--)
            {
                Console.CursorTop--;
                Console.CursorLeft--;
                Console.CursorLeft--;
                Console.Write("  ");
            }
            Console.CursorLeft--;
            
            // Top-Side
            for (int X = start.X + width; X > start.X + 4; X--)
            {
                Console.CursorLeft--;
                Console.CursorLeft--;
                Console.CursorLeft--;
                Console.Write("  ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        public int GetWidth()
        {
            return width;
        }        
        public int GetHeight()
        {
            return height;
        }        
        public int GetCentreX() { return start.X  + (width / 2); }
        public int GetCentreY() { return start.Y + (height / 2); }
        
    }
}
