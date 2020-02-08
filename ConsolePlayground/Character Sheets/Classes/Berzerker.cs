using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public class Berzerker : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Berzerker class is a damage dealing class that hits harder the lower it's health gets.
        */

        public Berzerker()
        {
            className = "Berzerker";
            stats = new StatList(100, 50, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Berzerker class is a damage dealing class that hits harder the lower it's health gets.";

            activeAbilities = new Ability[]
            {
                
            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Berzerker's Rage
        // Increase total attack power by 1% for each % of missing health.
        protected class Berzerkers_Rage: Ability
        {
            public Berzerkers_Rage()
            {
                name = "Berzerkers Rage";
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

        // Ultimate Ability :: Undying Rage
        // For the next 2 turns, you cannot be brought below 1 health.
        protected class Undying_Rage : Ability
        {
            public Undying_Rage()
            {
                name = "Undying Rage";
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

        // Activated Ability :: Reckless Swing
        // Strikes the target for 175% weapon damage, ignoring defences, but take damage equal to 25% recoil damage.
        protected class Reckless_Swing: Ability
        {
            public Reckless_Swing()
            {
                name = "Reckless Swing";
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

        // Activated Ability :: Enraged Regeneration
        // Restore health equal to 30% of missing health.
        protected class Enraged_Regeneration: Ability
        {
            public Enraged_Regeneration()
            {
                name = "Enraged Regeneration";
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
