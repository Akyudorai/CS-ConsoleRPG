using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public abstract class Classes
    {
        public string className;
        public string classDescription;
        public StatList stats;
        public StatList statGrowth;   
        public  Ability[] activeAbilities;
        

        public static Classes GenerateClass(int i)
        {
            switch (i)
            {
                default:
                case 1: return new Striker();
                case 2: return new Predator();
                case 3: return new Avenger();
                case 4: return new Sentinel();
                case 5: return new Berzerker();
                case 6: return new Siren();
                
            }
        }
    }


}
