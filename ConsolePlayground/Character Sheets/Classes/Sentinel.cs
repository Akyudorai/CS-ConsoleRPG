using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public class Sentinel : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Sentinel class is a tanking class that can absorb many hits.
        */

        public Sentinel()
        {
            className = "Sentinel";
            stats = new StatList(175, 50, 2, 1, 0.0, 0.65, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Sentinel class is a tanking class that can absorb many hits.";

            activeAbilities = new Ability[]
            {
                
            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Ardent Defender
        // Increase health by 25%, armor by 15%.
        protected class Ardent_Defender : Ability
        {
            public Ardent_Defender()
            {
                name = "Ardent Defender";
                type = Type.passive;
            }
            
            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {                
                settings.owner.profile._Stats.HealthMultiplier += 0.25;
                settings.owner.profile._Stats.ArmorMultiplier += 0.15;
            }
        }

        // Ultimate Ability :: Titan Form
        // Increase health by 60%, armor by 25%, and attack power by 25%.
        protected class Titan_Form : Ability
        {
            public Titan_Form()
            {
                name = "Titan Form";
                type = Type.active;

                cdTimer = 0;
            }

            public override void Activate(Settings settings)
            {
                throw new NotImplementedException();
            }

            public override void Effect(Settings settings)
            {
                settings.owner.profile._Stats.HealthMultiplier += 0.6;
                settings.owner.profile._Stats.ArmorMultiplier += 0.25;
                settings.owner.profile._Stats.PowerMultiplier += 0.25;
            }
        }

        // Activated Ability :: Colossus Smash
        // Strike a target for 60% attack power, increasing damage they receive by 20% for 3 turns.
        protected class Colossus_Smash : Ability
        {
            public Colossus_Smash()
            {
                name = "Colossus Smash";
                type = Type.active;

                cdTimer = 0;
            }

            public override void Activate(Settings settings)
            {
                throw new NotImplementedException();
            }

            public override void Effect(Settings settings)
            {      
                // Strike for 60% attack power
                double damage = 0.6 * (settings.owner.profile._Stats.Power * settings.owner.profile._Stats.PowerMultiplier);
                settings.target.entity.DamageEntity(damage);
                
                // Cripple target, increasing damage they receive by 20% for 3 turns.
            }
        }


        // Activated Ability :: 
        // 
    }
}
