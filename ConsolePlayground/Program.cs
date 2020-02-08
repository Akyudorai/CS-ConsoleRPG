using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace ConsolePlayground
{
    class Program
    {        
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;        

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            // Set Full Screen
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            
            // Load Screen Animation
            Console.Write(new string(' ', (Console.WindowWidth -  6) / 2));
            int MAX = 5;
            for (int i = 0; i < MAX + 1; i++)
            {
                Progress.GetInstance().GameLoad(i, MAX);
                System.Threading.Thread.Sleep(20);
            }

            System.Threading.Thread.Sleep(1000); Console.Clear();            
            Console.Clear();

            Game.GetInstance().GameStart();
            


        }
    }
}
