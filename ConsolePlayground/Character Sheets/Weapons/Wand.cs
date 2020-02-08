using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Character_Sheets.Weapons
{
    class Wand : Weapon
    {
        public Wand()
        {
            type = Type.wand;
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
