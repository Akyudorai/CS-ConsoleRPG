using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Character_Sheets.Weapons
{
    class Bow : Weapon
    {
        public Bow()
        {
            type = Type.bow;
            slot = Slot.twohand;
            damage = 7.7;
        }

        public override void EquipEffect(Controller controller)
        {

        }

        public override void UnequipEffect(Controller controller)
        {

        }
    }
}
