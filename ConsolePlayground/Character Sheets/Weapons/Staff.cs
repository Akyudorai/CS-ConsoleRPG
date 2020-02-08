using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Character_Sheets.Weapons
{
    class Staff : Weapon
    {
        public Staff()
        {
            type = Type.staff;
            slot = Slot.twohand;
            damage = 10.3;
        }

        public override void EquipEffect(Controller controller)
        {

        }

        public override void UnequipEffect(Controller controller)
        {

        }
    }
}
