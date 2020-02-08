using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Reaver : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Reaver class is a physical bruiser class that excel at rending and crippling multiple enemies at once.
        */

        public Reaver()
        {
            className = "Reaver";
            stats = new StatList(100, 100, 1, 0, 0, 1, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Reaver class is a physical bruiser class that excel at rending and crippling multiple enemies at once.";

            activeAbilities = new Ability[]
            {

            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Serrated Blades
        // Damaging an enemy with a physical damaging attack causes them to bleed.
        protected class Serrated_Blades : Ability
        {
            public Serrated_Blades()
            {
                name = "Serrated Blades";
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

        // Ultimate Ability :: Carnage
        // Damages a single target for 175% damage, increased to 325% damage if the target is bleeding.
        protected class Carnage : Ability
        {
            public Carnage()
            {
                name = "Carnage";
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


        // Activated Ability :: Cleave
        // Damages target and adjacent targets for 75% weapon damage.
        protected class Cleave : Ability
        {
            public Cleave()
            {
                name = "Cleave";
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

        // Activated Ability :: Bloodthirst
        // Damages a target for 100% damage.  If the target is bleeding, damage for 125% and heal for 25% of the damage dealt.
        protected class Bloodthirst: Ability
        {
            public Bloodthirst()
            {
                name = "Bloodthirst";
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
