using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public abstract class Weapon
    {
        public enum Type { sword, bow, gun, axe, staff, wand, shield }
        public enum Slot { mainhand, offhand, twohand }
        
        protected Type type;
        protected Slot slot;

        protected double damage;
        public double GetDamage() { return damage; }
        
        public abstract void EquipEffect(Controller controller);
        public abstract void UnequipEffect(Controller controller);
    }
}
