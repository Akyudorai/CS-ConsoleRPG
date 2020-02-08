using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Progress
    {

        // Singleton
        // -------------------------------------------
        static Progress progress;
        public static Progress GetInstance()
        {
            if (progress == null) progress = new Progress();
            return progress;
        }

        // Methodology
        // -------------------------------------------

        public void GameLoad(int progress, int total)
        {
            Draw.GetInstance().DrawBox((Console.WindowWidth / 2) - 19, (Console.WindowHeight / 2) - 1, 2, 33);

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
        
        public void PlayerExperience(int progress, int total)
        {
            Console.SetCursorPosition((Draw.GetInstance().gameWidth * 6 / 50) - 1, (Draw.GetInstance().gameHeight * 4 / 7));
            for (int i = 0; i < (Console.WindowWidth / 5) + 6; i++)
            {
                Console.Write("─");
            }
            
            //draw empty progress bar
            Console.CursorTop = ((Draw.GetInstance().gameHeight * 4 / 7) + 1);
            Console.CursorLeft = (Draw.GetInstance().gameWidth * 7 / 50);
            float onechunk = 30.0f / total;

            //draw filled part
            int position = (Draw.GetInstance().gameWidth * 7 / 50) + 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= (Draw.GetInstance().gameWidth * 7 / 50) + 32; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorTop = (Draw.GetInstance().gameHeight * 4 / 7) + 1;
            Console.CursorLeft = (Draw.GetInstance().gameWidth * 6 / 50);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" XP" + progress); //blanks at the end remove any excess

        }
    }
}
