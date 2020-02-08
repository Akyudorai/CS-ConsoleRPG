using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    public class Entity
    {
        // Variables
        // -------------------------------------------
        public Controller controller;

        public double currentHealth;
        public double maxHealth;

        public double currentEnergy;
        public double maxEnergy;

        public double lastHitReceived;

        // Methodology
        // -------------------------------------------
        public Entity(){}     
        
        public void DamageEntity(double amount)
        {
            currentHealth -= amount;
            lastHitReceived = amount;

            if (currentHealth <= 0)
            {
                // Enemy Dies
            }
        }

        public void HealEntity(double amount)
        {
            currentHealth += amount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}
