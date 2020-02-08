using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Character_Sheets.Weapons
{
    class Axe : Weapon
    {
        public Axe()
        {
            type = Type.axe;
            slot = Slot.twohand;
            damage = 10.6;
        }

        public override void EquipEffect(Controller controller)
        {

        }

        public override void UnequipEffect(Controller controller)
        {

        }
    }
}
