using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{ 
    class Arbiter : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Arbitor class is a magical tanking class that utilizes barriers and shields to protect and reflect damage.
        */

        public Arbiter()
        {
            className = "Arbiter";
            stats = new StatList(100, 100, 1, 0, 0, 1, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Arbitor class is a magical tanking class that utilizes barriers and shields to protect and reflect damage.";

            activeAbilities = new Ability[]
            {

            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Mage Armor
        // Increase defenses by 35% of your magic power. 
        protected class Mage_Armor : Ability
        {
            public Mage_Armor()
            {
                name = "Mage Armor";
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

        // Ultimate Ability :: Condemn
        // Unleash an explosion of magical energy around you, dealing damage to all targets equal to 120% magic power plus the remaining total on your active barrier.
        // Heal for 25% of the damage dealt.
        protected class Condemn : Ability
        {
            public Condemn()
            {
                name = "Condemn";
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

        // Activated Ability :: Arcane Barrier
        // Surround yourself with a magical barrier, which absorbs damage up to 100% of your magic power plus 200% of your defences.
        protected class Barrier : Ability
        {
            public Barrier()
            {
                name = "Barrier";
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

        // Activated Ability :: Smite
        // Damage the target for 80% magic power.
        protected class Smite : Ability
        {
            public Smite()
            {
                name = "Smite";
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
