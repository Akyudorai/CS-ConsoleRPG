using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    /// <summary>
    /// ZONES
    /// 1 = City
    /// 0 = None
    /// 
    /// </summary>
    class Zone
    {
        public Box2D box;
        public Vectors.Vector2Int coords;
        public ConsoleColor background;
        public string text;
        public string zoneDescription;
        
        public Zone() { }
        public Zone(int id)
        {
            switch (id)
            {
                case 0:
                    background = ConsoleColor.Black;
                    zoneDescription = "The area is a vast openness with no discerning details to it.";
                    break;

                case 1: 
                    background = ConsoleColor.DarkGray;
                    zoneDescription = "You're in a city.";
                    break;                
            }

            box = new Box2D(new Vectors.Vector2Int(0, 0), 0, 0);
        }

        public void DrawText()
        {
            Console.SetCursorPosition(box.GetCentreX(), box.GetCentreY());
            {
                Console.Write(text);
            }
        }

        public class Event
        {
            public string eventDialog;
            public Option[] eventOptions;
            
            public class Option
            {
                public string text;
            }
        }

    }
}
