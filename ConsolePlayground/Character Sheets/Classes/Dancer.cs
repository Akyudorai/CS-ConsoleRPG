using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Dancer : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Dancer class is a physical class that specializes in evading enemy attacks and returning with counterattacks.
        */

        public Dancer()
        {
            className = "Dancer";
            stats = new StatList(100, 100, 1, 0, 0, 1, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Dancer class is a physical class that specializes in evading enemy attacks and returning with counterattacks.";

            activeAbilities = new Ability[]
            {

            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Blade Dancing
        // Evasion is increased by 15%.  Parry is increased by 15%.  
        protected class Blade_Dancing : Ability
        {
            public Blade_Dancing()
            {
                name = "Blade Dancing";
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

        // Ultimate Ability :: Grand Finale - Seven Sided Strike
        // Strikes random targets 7 times for 35% damage each strike.
        protected class Seven_Sided_Strike : Ability
        {
            public Seven_Sided_Strike()
            {
                name = "Seven Sided Strike";
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

        // Activated Ability :: Riposte
        // Can only be activated after dodging or parrying an attack.  Attacks the target for 250% weapon damage.
        protected class Riposte : Ability
        {
            public Riposte()
            {
                name = "Riposte";
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

        // Activated Ability :: Acrobatic Strike
        // Strike the target for 125% weapon damage and increase dodge chance by 15% for 2 turns.
        protected class Acrobatic_Strike: Ability
        {
            public Acrobatic_Strike()
            {
                name = "Acrobatic Strike";
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
