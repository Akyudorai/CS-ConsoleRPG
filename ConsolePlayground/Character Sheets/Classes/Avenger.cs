using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{ 
    public class Avenger : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Advancer class is.. 
        */

        public Avenger()
        {
            className = "Avenger";
            stats = new StatList(100, 100, 1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Advancer class is a hybrid class that excels at taking physical damage while dishing out damage of its own.";

            activeAbilities = new Ability[]
            {
                
            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Perseverance
        // Restore 10% of your missing health at the start of your turn.
        protected class Perseverance : Ability
        {
            public Perseverance()
            {
                name = "Perseverance";
                type = Type.passive;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {
                double heal = settings.owner.entity.maxHealth * 0.1;
                settings.owner.entity.HealEntity(heal);
            }
        }

        // Ultimate Ability :: 
        // 

        // Activated Ability :: Revenge
        // Can only be activated after being hit.  Strikes back at the target for 80% attack power plus 50% of the damage received.
        protected class Revenge : Ability
        {
            public Revenge()
            {
                name = "Revenge";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {
                double damage = (0.8 * (settings.owner.profile._Stats.Power * settings.owner.profile._Stats.PowerMultiplier)) + (0.5 * settings.owner.entity.lastHitReceived);
                settings.target.entity.DamageEntity(damage);
            }
        }

        // Activated Ability :: Takedown
        // Deal damage to the target equal to 70% attack power plus 25% of their missing health.
        protected class Takedown : Ability
        {
            public Takedown()
            {
                name = "Takedown";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {
                double damage = (0.7 * (settings.owner.profile._Stats.Power * settings.owner.profile._Stats.PowerMultiplier)) + (0.25 * (settings.target.entity.maxHealth - settings.target.entity.currentHealth));
                settings.target.entity.DamageEntity(damage);
            }
        }

    }
}
