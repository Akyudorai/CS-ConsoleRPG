using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Defiler : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Defiler class is a magical attacking class that inflicts damage over time effects and curses on their targets.
        */

        public Defiler()
        {
            className = "Defiler";
            stats = new StatList(100, 100, 1, 0, 0, 1, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Defiler class is a magical attacking class that inflicts damage over time effects and curses on their targets.";

            activeAbilities = new Ability[]
            {

            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Vampiric Touch
        // Your DoT abilities restore health equal to 25% of their damage.
        protected class Vampiric_Touch : Ability
        {
            public Vampiric_Touch()
            {
                name = "Vampiric Touch";
                type = Type.passive;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {

            }
        }

        // Ultimate Ability :: Dark Harvest
        // Inflict damage to each target equal to 90% magic power plus 35% magic power for each DoT applied to the target.
        protected class Dark_Harvest: Ability
        {
            public Dark_Harvest()
            {
                name = "Dark Harvest";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {

            }
        }

        // Activated Ability :: Corruption
        // Applies a DoT to the target for 8 turns, dealing 35% magic damage each turn.
        protected class Corruption : Ability
        {
            public Corruption()
            {
                name = "Corruption";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {

            }
        }


        // Activated Ability :: Agony
        // Applies a DoT to the target for 8 turns, dealing 35% magic damage each turn.
        protected class Agony : Ability
        {
            public Agony()
            {
                name = "Agony";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {

            }
        }
    }
}
