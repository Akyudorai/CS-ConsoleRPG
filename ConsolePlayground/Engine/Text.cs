using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Text
    {
        // Singleton
        // -------------------------------------------
        static Text text;
        public static Text GetInstance()
        {
            if (text == null) text = new Text();
            return text;
        }

        // Methodology
        // -------------------------------------------        
        public void CenterText(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) - (text.Length / 2), (Console.WindowHeight / 2));
            Console.WriteLine(text);
        }

        public string YesNo()
        {
            return "(Y) | (N)";
        }


    }
}
