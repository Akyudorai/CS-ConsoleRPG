using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Ranger : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Ranger class is a hybrid attacking class that infuses arrows with magic to apply status effects such as poisons and slows.
        */

        public Ranger()
        {
            className = "Ranger";
            stats = new StatList(100, 100, 1, 0, 0, 1, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Ranger class is a hybrid attacking class that infuses arrows with magic to apply status effects such as poisons and slows.";

            activeAbilities = new Ability[]
            {

            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Fleet Footed
        //   

        // Ultimate Ability :: Volley
        // Unleash a barrage of arrows dealing 35% damage to all targets up to 5 times.

        // Activated Ability :: Poisoned Arrow
        // Fires a poisoned arrow at the target, dealing 50% weapon damage and applying a 5 turn DOT for 35% attack power

        // Activated Ability :: 
        // 
    }
}
