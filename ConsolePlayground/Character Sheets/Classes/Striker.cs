using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public class Striker : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Striker class is a damage dealing class that places emphasis on physical attacks.
        */

        public Striker()
        {
            className = "Striker";
            stats = new StatList(100, 100, 1, 0, 0, 1, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Striker class is a damage dealing class that specializes in multi-hit techniques.";

            activeAbilities = new Ability[]
            {
               new Slice_And_Dice()
            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Dual Wield Specialization
        // Can equip an additional one-handed weapon.  While dual-wielding, basic attacks strike twice each dealing 75% damage.
        protected class Dual_Wield_Spec: Ability
        {
            public Dual_Wield_Spec()
            {
                name = "Dual Wield Specialization";
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

        // Ultimate Ability :: Seven-Sided Strike
        // At flashing speeds, the user strikes the target 7 times consecutively, dealing 50% weapon damage with each strike.
        

        // Activated Ability :: Blade Flurry
        // Strike all targets for 75% attack power.

        // Activated Ability :: Slice and Dice
        // Strike the target twice, dealing 100% damage with each strike.
        protected class Slice_And_Dice : Ability
        {
            public Slice_And_Dice()
            {
                name = "Slice and Dice";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
                settings.owner.entity.currentEnergy -= 25.0f;
                Effect(settings);
            }

            public override void Effect(Settings settings)
            {
                settings.target.entity.DamageEntity(25 * settings.owner.profile._Stats.Power * settings.owner.profile._Stats.PowerMultiplier);
                Game.GetInstance().scene.DrawHealthAndEnergy(Game.GetInstance().scene.battle);

                System.Threading.Thread.Sleep(200);
                settings.target.entity.DamageEntity(25 * settings.owner.profile._Stats.Power * settings.owner.profile._Stats.PowerMultiplier);                
            }
        }

        /*
        protected class DoubleStrike : Ability
        {
            /* Attacks the target twice for 75% power 

        public DoubleStrike()
        {
            abilityRank = 1;
            Name = "Double Strike";
        }

        public override void Activate(Entity target, Entity user)
        {
            Random rand = new Random();

            Console.SetCursorPosition((Draw.GetInstance().gameWidth * 12 / 25), (Draw.GetInstance().gameHeight / 6) + 2);
            Console.Write("Double Strike!");
            double totaldamage = 0;
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition((Draw.GetInstance().gameWidth * 12 / 25), (Draw.GetInstance().gameHeight / 6) + 3);
                Console.CursorTop += i;
                Console.CursorLeft = (Draw.GetInstance().gameWidth * 12 / 25);
                double damage = Math.Round(rand.Next(10, 15) * user.controller.profile._Stats.Power, 0);
                Console.Write("Hit! ({0})", damage);
                totaldamage += damage;
                target.DamageEntity(damage);

                // Update the Health Bar
                Draw.GetInstance().ClearEnemy();
                Draw.GetInstance().DrawEnemy(target);
                System.Threading.Thread.Sleep(50);
                Console.CursorTop = (Draw.GetInstance().gameHeight / 6) + 3 + i + 1;
            }

            Console.CursorLeft = (Draw.GetInstance().gameWidth * 12 / 25);
            Console.Write("Total Damage: ({0})", totaldamage);
            }
        }
    */
    }
}
