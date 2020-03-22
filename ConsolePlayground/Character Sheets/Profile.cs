using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public class Profile
    {
        public Profile()
        {
            Abilities = new List<Ability>();
        }

        // Name
        private string name;
        public string Name { get { return name; } set { name = value; } }
        
        // Class
        private Classes _class;
        public Classes _Class { get { return _class; } set { _class = value; } }
        public readonly List<Ability> Abilities;
        
        // Stats
        private StatList _stats;
        public StatList _Stats { get { return _stats; } set { _stats = value; } }

        // Level
        private int level;
        public int Level { get { return level; } set { level = value; } }

        // Experience 
        private int experience;
        public int Experience { get { return experience; } set { experience = value; } }

        // Combat Menu
        private Menu combatMenu;
        public Menu CombatMenu { get { return combatMenu; } set { combatMenu = value; } }

        // Equipment -- turn into custom class
        public Equipment equipment;
    }
}
