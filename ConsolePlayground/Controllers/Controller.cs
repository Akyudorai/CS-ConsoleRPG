using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public class Controller
    {
        // Variables
        // -------------------------------------------
        // Profile handles all information about the player character
        public Profile profile;
        public Entity entity;
        
        public int input = 0;
        public void Input(Scene scene)
        {
            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:

                    if (this.input > 0) this.input--;
                    else this.input = 2;

                    scene.DrawDialog();
                    Input(scene);

                    break;

                case ConsoleKey.DownArrow:

                    if (this.input < 2) this.input++;
                    else this.input = 0;

                    scene.DrawDialog();
                    Input(scene);

                    break;

                case ConsoleKey.Enter:

                    // Activate Command

                    break;

                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Input(scene);
                    break;
            }

        }
        
    }
}
