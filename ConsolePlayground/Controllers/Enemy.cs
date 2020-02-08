using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    class Enemy : Controller
    {
        public static Enemy GenerateRandomEnemy()
        {
            Random rand = new Random();
            int i = rand.Next(1, 6); // Number of Possible Classes

            Enemy e = new Enemy();

            // Initialize Profile
            e.profile = new Profile()
            {
                Name = "Enemy",
                _Class = Classes.GenerateClass(i),
                Level = 1
            };

            e.profile._Stats = e.profile._Class.stats;

            // Initialize Entity
            e.entity = new Entity()
            {
                controller = e,
                currentHealth = e.profile._Stats.Health,
                maxHealth = e.profile._Stats.Health,
                currentEnergy = e.profile._Stats.Energy,
                maxEnergy = e.profile._Stats.Energy
            };

            return e;
        }

        public Enemy() {}
        
        //public void InitEnemy(int difficulty)
        //{
        //    double multiplier = 0;

        //    Level = difficulty;            

        //    switch (difficulty)
        //    {
        //        case 1: multiplier = .75; break;
        //        case 2: multiplier = 1.75; break;
        //        case 3: multiplier = 3.25; break;
        //        case 4: multiplier = 5.00; break;
        //        case 5: multiplier = 7.25; break;
        //        case 10: multiplier = 4.00; break;
        //        case 15: multiplier = 7.00; break;
        //        case 20: multiplier = 10.00; break;
        //        default: multiplier = 0.25; break;

        //    }
            
        //}
    }
}
