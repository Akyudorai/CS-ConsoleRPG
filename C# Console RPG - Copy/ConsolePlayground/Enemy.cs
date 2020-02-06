using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Enemy
    {
        Progress progress = new Progress();
        Draw draw = new Draw();

        private string playerName;
        public string PlayerName { get { return playerName; } set { playerName = value; } }

        private string playerClass;
        public string PlayerClass { get { return playerClass; } set { playerClass = value; } }

        private int classID;
        public int ClassID { get { return classID; } set { classID = value; } }

        private int level;
        public int Level { get { return level; } set { level = value; } }
        private int experience;
        public int Experience { get { return experience; } set { experience = value; } }

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

        public void UpdateEnemy()
        {
            Console.SetCursorPosition((draw.gameWidth * 11 / 50), (draw.gameHeight / 8) + 10);
            progress.EnemyHealth(Convert.ToInt32(Math.Round(Health)), Convert.ToInt32(Math.Round(BaseHealth)));
            progress.EnemyEnergy(Convert.ToInt32(Math.Round(Energy)), Convert.ToInt32(Math.Round(BaseEnergy)));
            System.Threading.Thread.Sleep(20);
        }

        public void InitEnemy(int difficulty)
        {
            double multiplier = 0;

            Level = difficulty;            

            switch (difficulty)
            {
                case 1: multiplier = .75; break;
                case 2: multiplier = 1.75; break;
                case 3: multiplier = 3.25; break;
                case 4: multiplier = 5.00; break;
                case 5: multiplier = 7.25; break;
                case 10: multiplier = 4.00; break;
                case 15: multiplier = 7.00; break;
                case 20: multiplier = 10.00; break;
                default: multiplier = 0.25; break;

            }

            Random rand = new Random();
            int select = rand.Next(1, 7);
            switch (1)
            {
                case 1 :
                    PlayerClass = "Striker"; ClassID = 1;
                    Health = 83 * multiplier; BaseHealth = 100 * multiplier;
                    Energy = 33; BaseEnergy = 100;
                    Power = 1;
                    break;

                default :
                    PlayerClass = "ERROR"; ClassID = 1;
                    Health = 83; BaseHealth = 100;
                    Energy = 33; BaseEnergy = 100;
                    break;
            }       
                        
        }
    }
}
