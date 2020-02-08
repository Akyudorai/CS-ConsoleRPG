using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground.Character_Sheets.Weapons
{
    class Sword : Weapon
    {
        public Sword()
        {
            type = Type.sword;   
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
