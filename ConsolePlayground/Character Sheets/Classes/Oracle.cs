using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Oracle : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Oracle class is a magical attacking class that utilizes psychic spells to directly damage their opponents.
        */

        public Oracle()
        {
            className = "Oracle";
            stats = new StatList(100, 100, 1, 0, 0, 1, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Oracle class is a magical attacking class that utilizes psychic spells to directly damage their opponents.";

            activeAbilities = new Ability[]
            {

            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: 
        // 

        // Ultimate Ability :: 
        // 

        // Activated Ability :: Mind Blast
        // Blasts the target with psychic power dealing 135% magic damage.
        protected class Mind_Blast : Ability
        {
            public Mind_Blast()
            {
                name = "Mind Blast";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {
                double damage = 1.35 * (settings.owner.profile._Stats.Magic * settings.owner.profile._Stats.MagicMultiplier);
                settings.target.entity.DamageEntity(damage);
            }
        }

        // Activated Ability :: 
        // 
    }
}
