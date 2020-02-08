using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Warden : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Warden class is a defensive class that uses a one-handed weapon with a shield to brush off attacks.
        */

        public Warden()
        {
            className = "Warden";
            stats = new StatList(100, 100, 1, 0, 0, 1, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Warden class is a defensive class that uses a one-handed weapon with a shield to brush off attacks.";

            activeAbilities = new Ability[]
            {
                new Sword_And_Board(),
                new Iron_Fortress(),
                new Shield_Slam(),
                new Sunder()
            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Sword and Board
        // AP scales with defense rating. Increase block chance by 15%.
        protected class Sword_And_Board : Ability
        {
            public Sword_And_Board()
            {
                name = "Sword and Board";
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

        // Ultimate Ability :: Iron Fortress
        // For the next 3 turns, reduce all damage received by 60%.
        protected class Iron_Fortress : Ability
        {
            public Iron_Fortress()
            {
                name = "Iron Fortress";
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
        
        // Activated Ability :: Shield Slam
        // Bashes target with your shield, dealing damage equal to 50% attack power + 50% defense rating.
        protected class Shield_Slam: Ability
        {
            public Shield_Slam()
            {
                name = "Shield Slam";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {
                // Inflict damage equal to 50% attack power plus 50% armor rating
                double damage = (0.5 * (settings.owner.profile._Stats.Power * settings.owner.profile._Stats.PowerMultiplier)) + (0.5 * (settings.owner.profile._Stats.Armor * settings.owner.profile._Stats.ArmorMultiplier));
                settings.target.entity.DamageEntity(damage);
            }
        }

        // Activated Ability :: Sunder
        // Sunders the targets armor, dealing 125% weapon damage and reducing their armor by 25%.  Armor reductiong stacks twice.
        protected class Sunder : Ability
        {
            public Sunder()
            {
                name = "Sunder";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                /// NO ACTIVATED ABILITY
            }

            public override void Effect(Settings settings)
            {
                // Damage for 125% weapon damage.
                double damage = 1.25 * (settings.owner.profile.equipment.mainhand.GetDamage());
                settings.target.entity.DamageEntity(damage);

                // Shred armor by 25%.
                
            }
        }

    }
}
