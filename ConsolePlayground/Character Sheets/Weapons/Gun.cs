using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Character_Sheets.Weapons
{
    class Gun : Weapon
    {
        public Gun()
        {
            type = Type.gun;
            slot = Slot.mainhand;
            damage = 5.3;
        }

        public override void EquipEffect(Controller controller)
        {

        }

        public override void UnequipEffect(Controller controller)
        {

        }
    }
}
