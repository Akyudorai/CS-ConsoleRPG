using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Character_Sheets.Weapons
{
    class Shield : Weapon
    {
        readonly double armorRating = 15.0;

        public Shield()
        {
            type = Type.shield;
            slot = Slot.offhand;
            damage = 0;
        }

        public override void EquipEffect(Controller controller)
        {
            // Increase Armor Rating while equipped
            controller.profile._Stats.Armor += armorRating;

            // Grants access to the block ability while equipped
            controller.profile.Abilities.Add(new Block());
        }

        public override void UnequipEffect(Controller controller)
        {
            // Remove the Armor Rating bonus
            controller.profile._Stats.Armor -= armorRating;

            // Remove the ability to use weapon-specific ability
            int index = 0;
            for (int i = 0; i < controller.profile.Abilities.Count; i++)
            {
                if (controller.profile.Abilities[i].name == "Block")
                {
                    index = i;
                }
            }

            controller.profile.Abilities.RemoveAt(index);
        }



        public class Block : Ability
        {
            public Block()
            {
                name = "Block";
                type = Type.active;
            }

            public override void Activate(Settings settings)
            {
                throw new NotImplementedException();
            }

            public override void Effect(Settings settings)
            {
                throw new NotImplementedException();
            }
        }
    }
}
