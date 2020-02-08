using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Harbinger : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Harbinger class is a magical bruiser class that utilizes conjured swords and heavy armor.
        */

        public Harbinger()
        {
            className = "Harbinger";
            stats = new StatList(100, 100, 1, 0, 0, 1, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Harbinger class is a magical bruiser class that utilizes conjured swords and heavy armor.";

            activeAbilities = new Ability[]
            {

            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Astral Swords
        // 

        // Ultimate Ability :: Blade Lotus
        // Summons 5 astral swords which pierce the target each dealing 75% magic damage.
        protected class Blade_Lotus : Ability
        {
            public Blade_Lotus()
            {
                name = "Blade Lotus";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {
                for (int i = 0; i < 5; i++)
                {
                    double damage = 0.75 * (settings.owner.profile._Stats.Magic * settings.owner.profile._Stats.MagicMultiplier);
                    settings.target.entity.DamageEntity(damage);
                }                
            }
        }

        // Activated Ability :: Surge of Blades
        // Strike the target with magical blades dealing 75% magic damage.
        protected class Blade_Surge : Ability
        {
            public Blade_Surge()
            {
                name = "Blade Surge";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {
                double damage = 0.75 * (settings.owner.profile._Stats.Magic * settings.owner.profile._Stats.MagicMultiplier);
                settings.target.entity.DamageEntity(damage);
            }
        }

        // Activated Ability :: 
        // 
    }
}
