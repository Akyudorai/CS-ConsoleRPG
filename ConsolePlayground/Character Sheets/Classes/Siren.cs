using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public class Siren : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Siren class is a magic class that absorbs the life force of their enemies.
        */

        public Siren()
        {
            className = "Siren";
            stats = new StatList(65, 150, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Siren class is a magic class that absorbs the life force of their enemies.";

            activeAbilities = new Ability[]
            {
                
            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Siphoning Strikes
        // Your attacks drain the target of its power and life force, siphoning the targets power and defences by 10% per hit, maximum 60%        
        protected class Siphoning_Strikes : Ability
        {
            public Siphoning_Strikes()
            {
                name = "Siphoning Strikes";
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

        // Ultimate Ability :: Soul Shackles
        // Damages all targets for 35% magic power three times, healing for 100% of the damage dealt.
        protected class Soul_Shackles : Ability
        {
            public Soul_Shackles()
            {
                name = "Soul Shackles";
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

        // Activated Ability :: Ebb and Flow
        // Damage the target for 50% magic power and heal for half the amount.
        protected class Ebb_And_Flow : Ability
        {
            public Ebb_And_Flow()
            {
                name = "Ebb and Flow";
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

        // Activated Ability :: Hysteria
        // Damage the target for 30% magic damage and has a chance to apply a DoT that burns the target for 30% magic damage each turn.
        protected class Hysteria : Ability
        {
            public Hysteria()
            {
                name = "Hysteria";
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
