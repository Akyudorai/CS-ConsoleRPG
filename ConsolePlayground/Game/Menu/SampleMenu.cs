using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class SampleMenu : Menu
    {
        public SampleMenu()
        {
            commands = new string[] {
            "Option 1: First Choice",
            "Option 2: Second Choice",
            "Option 3: Final Choice"
            };
        }
    }
}
