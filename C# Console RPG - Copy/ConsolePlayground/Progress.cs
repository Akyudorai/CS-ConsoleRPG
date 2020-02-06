using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Progress
    {
        Draw draw = new Draw();

        public void GameLoad(int progress, int total)
        {
            draw.DrawBox((Console.WindowWidth / 2) - 19, (Console.WindowHeight / 2) - 1, 2, 33);

            //draw empty progress bar
            Console.CursorTop = (Console.WindowHeight / 2);
            Console.CursorLeft = (Console.WindowWidth / 2) - 18;            
            Console.Write("["); //start
            Console.CursorLeft = (Console.WindowWidth / 2) + 14;
            Console.Write("]"); //end
            Console.CursorLeft = (Console.WindowWidth / 2) - 17;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = (Console.WindowWidth / 2) - 17;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= (Console.WindowWidth / 2) + 13; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorTop = (Console.WindowHeight / 2) + 2;
            Console.CursorLeft = (Console.WindowWidth / 2) - 6;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
            
        }

        public void PlayerHealth(int progress, int total)
        {
            draw.DrawBox((draw.gameWidth * 6 / 50), (draw.gameHeight / 8) + 3, 2, 31);

            //draw empty progress bar
            Console.CursorTop = (draw.gameHeight / 8) + 4;            
            Console.CursorLeft = (draw.gameWidth * 6 / 50) + 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = (draw.gameWidth * 6 / 50) + 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= (draw.gameWidth * 6 / 50) + 18; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorTop = (draw.gameHeight / 8) + 2;
            Console.CursorLeft = (draw.gameWidth * 6 / 50);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Health: " + progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
            
        }

        public void PlayerEnergy(int progress, int total)
        {
            draw.DrawBox((draw.gameWidth * 6 / 50), (draw.gameHeight / 8) + 7, 2, 31);

            //draw empty progress bar
            Console.CursorTop = (draw.gameHeight / 8) + 8;
            Console.CursorLeft = (draw.gameWidth * 6 / 50) + 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = (draw.gameWidth * 6 / 50) + 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= (draw.gameWidth * 6 / 50) + 18; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorTop = (draw.gameHeight / 8) + 6;
            Console.CursorLeft = (draw.gameWidth * 6 / 50);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Energy: " + progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess

        }        

        public void EnemyHealth(int progress, int total)
        {
            draw.DrawBox((draw.gameWidth * 6 / 50), (draw.gameHeight / 8) + 14, 2, 31);

            //draw empty progress bar
            Console.CursorTop = (draw.gameHeight / 8) + 15;
            Console.CursorLeft = (draw.gameWidth * 6 / 50) + 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = (draw.gameWidth * 6 / 50) + 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= (draw.gameWidth * 6 / 50) + 18; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorTop = (draw.gameHeight / 8) + 13;
            Console.CursorLeft = (draw.gameWidth * 6 / 50);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Health: " + progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
            
        }

        public void EnemyEnergy(int progress, int total)
        {
            draw.DrawBox((draw.gameWidth * 6 / 50), (draw.gameHeight / 8) + 18, 2, 31);

            //draw empty progress bar
            Console.CursorTop = (draw.gameHeight / 8) + 19;
            Console.CursorLeft = (draw.gameWidth * 6 / 50) + 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = (draw.gameWidth * 6 / 50) + 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= (draw.gameWidth * 6 / 50) + 18; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorTop = (draw.gameHeight / 8) + 17;
            Console.CursorLeft = (draw.gameWidth * 6 / 50);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Energy: " + progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess

        }

        public void PlayerExperience(int progress, int total)
        {
            Console.SetCursorPosition((draw.gameWidth * 6 / 50) - 1, (draw.gameHeight * 4 / 7));
            for (int i = 0; i < (Console.WindowWidth / 5) + 6; i++)
            {
                Console.Write("─");
            }
            
            //draw empty progress bar
            Console.CursorTop = ((draw.gameHeight * 4 / 7) + 1);
            Console.CursorLeft = (draw.gameWidth * 7 / 50);
            float onechunk = 30.0f / total;

            //draw filled part
            int position = (draw.gameWidth * 7 / 50) + 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= (draw.gameWidth * 7 / 50) + 32; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorTop = (draw.gameHeight * 4 / 7) + 1;
            Console.CursorLeft = (draw.gameWidth * 6 / 50);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" XP" + progress); //blanks at the end remove any excess

        }
    }
}
