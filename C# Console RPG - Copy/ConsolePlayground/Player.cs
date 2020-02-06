using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{    
    class Player
    {
        Progress progress = new Progress();
        Text text = new Text();
        Draw draw = new Draw();

        private string playerName;
        public string PlayerName { get { return playerName; } set { playerName = value; } }

        private string playerClass;
        public string PlayerClass { get { return playerClass; } set { playerClass = value; } }

        private int classID;
        public int ClassID { get { return classID; } set { classID = value; }  }

        private int level;
        public int Level { get { return level; } set { level = value; } }
        private int experience;
        private int experienceCap;
        public int Experience { get { return experience; } set { experience = value; } }
        public int ExperienceCap { get { return experienceCap; } set { experienceCap = value; } }

        private double baseHealth;
        private double health;
        public double Health { get { return health; } set { health = value; } }
        public double BaseHealth { get { return baseHealth; } set { baseHealth = value; } }

        private double baseEnergy;
        private double energy;
        public double Energy { get { return energy; } set { energy = value; } }
        public double BaseEnergy { get { return baseEnergy; } set { baseEnergy = value; } }

        private double baseArmour;
        private double armour;
        public double Armour { get { return armour; } set { armour = value; } }
        public double BaseArmour { get { return baseArmour; } set { baseArmour = value; } }

        private double power;
        private double basePower;
        public double Power { get { return power; } set { power = value; } }
        public double BasePower { get { return basePower; } set { basePower = value; } }

        private double critChance;
        public double CritChance { get { return critChance; } set { critChance = value; } }
        private double critDamage;
        public double CritDamage { get { return critDamage; } set { critDamage = value; } }

        private double dodgeChance;
        public double DodgeChance { get { return dodgeChance; } set { dodgeChance = value; } }
        private double shieldValue;
        public double ShieldValue { get { return shieldValue; } set { shieldValue = value; } }

        public void UpdatePlayer()
        {
            Console.SetCursorPosition((draw.gameWidth * 11 / 50), (draw.gameHeight / 8) + 2);
            progress.PlayerHealth(Convert.ToInt32(Math.Round(Health)), Convert.ToInt32(Math.Round(BaseHealth)));
            progress.PlayerEnergy(Convert.ToInt32(Math.Round(Energy)), Convert.ToInt32(Math.Round(BaseEnergy)));
            progress.PlayerExperience(Experience, ExperienceCap); 
            System.Threading.Thread.Sleep(20); 
        }

        public void CheckExperience()
        {
            if (Experience >= ExperienceCap)
            {
                int excess = Experience - ExperienceCap;
                Experience = 0;
                Experience += excess;
                Level++;

                // UPDATE STATS
                    BaseHealth += BaseHealth * 0.75;                    
                    Health = BaseHealth;
                    Energy = BaseEnergy;
                    BasePower += 0.60;
                    Power = BasePower;

            }
        }

        public void ChooseName()
        {
            Console.Clear();
            text.CenterText("Designate a name for yourself: ");
            Console.CursorTop = (Console.WindowHeight / 2) + 2;
            Console.CursorLeft = (Console.WindowWidth / 2) - 3;
            PlayerName = Console.ReadLine();
            System.Threading.Thread.Sleep(50);
            Console.Clear();

            bool prompt = true;
            while (prompt == true)
            {
                text.CenterText("Is this correct?");
                Console.CursorTop = (Console.WindowHeight / 2) + 2;
                Console.CursorLeft = (Console.WindowWidth / 2) - (PlayerName.Length / 2);
                Console.WriteLine(PlayerName);

                Console.CursorTop = (Console.WindowHeight / 2) + 6;
                Console.CursorLeft = (Console.WindowWidth / 2) - (text.YesNo().Length / 2);
                Console.WriteLine(text.YesNo());

                var input = Console.ReadKey();

                switch (input.KeyChar)
                {
                    case 'Y':
                    case 'y': ChooseClass(); prompt = false; break;
                    case 'N':
                    case 'n': ChooseName(); prompt = false; break;
                    default: break;
                }
            }
        }

        public void ChooseClass()
        {
            Console.Clear();
            text.CenterText("Welcome " + PlayerName);
            Console.Clear();
            text.CenterText("You're a Striker");
            PlayerClass = "Striker"; ClassID = 1;
            Health = 100; BaseHealth = 100;
            Energy = 100; BaseEnergy = 100;
            Power = 1.00; BasePower = 1.00;
            Experience = 0; ExperienceCap = 100;
            Level = 1;

            Console.Clear();

            // Prompt begin tutorial

            Console.Clear();
            text.CenterText("You're Ready For The Field!");
            Console.ReadKey(); Console.Clear();            
        }   
     

    }
}
