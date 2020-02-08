using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    // Unique: The Gunslingers weapons have ammo capacities tied to them, meaning that each attack will consume one ammo.
    //    When a weapons ammo capacity empties, the player has to take one turn to reload the weapon.

    // Unique: The Gunslingers have access to three class-specific weapons that each have their own effects
    //    Dual Pistols: Attack twice for 75% weapon damage.  moderate damage, highest clip size, emphasis on multi-shot mechancis 
    //    Shotgun: Attacks strike adjacent targets as well as the original target. low damage, moderate clip-size, emphasis on multi-target mechanics
    //    Sniper: Sniper attacks have high single target damage, but very low clip-size, often leaving the user open for attacks after firing.

    class Gunslinger : Classes
    {
        /* 
        * [CLASS DESCRIPTION]
        * The Gunslinger class is a physical class that wields different ranged weapons for different occassions.
        */

        public Gunslinger()
        {
            className = "Gunslinger";
            stats = new StatList(100, 100, 1, 0, 0, 1, 0, 0.0, 0.0);
            statGrowth = new StatList(15, 0, 0, 0, 0, 0.25, 0, 0, 0);
            classDescription = "The Gunslinger class is a physical class that wields different ranged weapons for different occassions.";

            activeAbilities = new Ability[]
            {

            };
        }

        /*  ---------- ABILITIES ---------- */

        // Passive Ability :: Gun Mastery
        // Dual Pistols: Attack twice for 75% weapon damage each.  
        // Shotgun: Attacks strike targets adjacent as well as the original target.
        // Sniper: Attacks ignore 40% of the targets defences.
        protected class Gun_Mastery : Ability
        {
            public Gun_Mastery()
            {
                name = "Gun Mastery";
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

        // Ultimate Ability :: *The Gunslingers Abilities differ depending on the type of gun they're wielding.
        // Pistols: Ballet of Bullets: Unleash a barrage of bullets, dealing 35% weapon damage up to 12 times to random targets. 
        // Shotgun: Shotgun Opera: Unleash a barrage of bullets, dealing 35% weapon damage 6 times to a target and any adjacent targets.
        // Sniper: Kill Shot: Take aim and fire a single critical shot dealing 250% weapon damage plus 50% of the targets missing health.

        // Activated Ability :: 
        // Pistols: Coup De Grace: Damage a target with a single shot dealing 50% attack power plus 30% of the targets missing health as damage.
        // Shotgun: Close Quarters: Damages a single target for 175% power.
        // Sniper: Marked for Death: Mark a target, increasing critical strike chance on the target by 25%.

        // Activated Ability :: 
        // Pistols: Tumble: Increase evasion by 15% and reload a bullet into each pistol.
        // Shotgun: Riot Control: Fire a low-damaging shot that damages target and its adjacent targets by 30% attack power, and reduces their attack power and defences by 15% for 3 turns.
        // Sniper: Quick Shot: Fire a shot with 15% reduced accuracy, but instantly loads a bullet into the gun.
    }
}
