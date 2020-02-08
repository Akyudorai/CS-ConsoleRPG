using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlayground
{
    
    
    public abstract class Ability
    {
        #region Ability Variables

        public string name;
        protected Type type;

        protected int cdTimer;

        #endregion

        #region Public Methods

        public void Cooldown(int amount) {
            cdTimer -= amount;
        }

        public Type GetAbilityType()
        {
            return type;
        }
        
        #endregion

        #region Abstract Methods

        public abstract void Activate(Settings settings);
        public abstract void Effect(Settings settings);

        #endregion

        public enum Type { passive, active, channeled }

        public class Settings
        {
            public Controller owner;
            public Controller target;

            // Target Ability Settings
            public static Settings Initialize(Controller _owner, Controller _target)
            {                
                return new Settings()
                {
                    owner = _owner,
                    target = _target
                };
            }
        }
    }
}
