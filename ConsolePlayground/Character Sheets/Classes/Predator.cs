using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public class Predator : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Predator class is a damage dealing class that focuses on inflicting critical strikes.
        */

        public Predator()
        {
            className = "Predator";
            stats = new StatList(65, 125, 0.0, 0.0, 1.0, 1.0, 0.0, 25.0, 1.5);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Predator class is a damage dealing class that focuses on inflicting critical strikes.";

            activeAbilities = new Ability[]
            {
                
            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: On The Hunt
        // Passively marks enemies in combat.  Marked enemies have an additional 30% chance to be critically struck.

        // Ultimate Ability :: 
        // 

        // Activated Ability :: Ravage
        // Deal damage to target equal to 225% attack power.

        // Activated Ability :: 
        // 
    }
}
