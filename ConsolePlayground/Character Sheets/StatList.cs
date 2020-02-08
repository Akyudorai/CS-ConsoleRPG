namespace ConsolePlayground
{
    public class StatList
    {
        public StatList (
            double _health, double _energy, 
            double _armor, double _toughness, double _evasion, 
            double _power, double _magic, 
            double _critChance, double _critDamage
            )
        {
            Health = _health; Energy = _energy;
            Armor = _armor; Toughness = _toughness; Evasion = _evasion;
            Power = _power; Magic = _magic;
            CritChance = _critChance; CritDamage = _critDamage;
            
            HealthMultiplier = 1.0;
            EnergyMultiplier = 1.0;
            PowerMultiplier = 1.0;
            MagicMultiplier = 1.0;
        }

        // Operator Overloading -- Intended for adding stat growth on level up
        public static StatList operator +(StatList a, StatList b)
        {
            return new StatList(
                a.health + b.health, 
                a.energy + b.energy,
                a.armor + b.armor,
                a.toughness + b.toughness,
                a.evasion + b.evasion,
                a.power + b.power,
                a.magic + b.magic,
                a.critChance + b.critChance,
                a.critDamage + b.critDamage
                );
        }

        // Health -- Determines how much damage can be taken
        private double health;
        public double Health { get { return health; } set { health = value; } }
        private double healthMultiplier;
        public double HealthMultiplier { get { return healthMultiplier; } set { healthMultiplier = value; } }
        
        // Energy -- Handles activation of abilities        
        private double energy;
        public double Energy { get { return energy; } set { energy = value; } }       
        private double energyMultiplier;
        public double EnergyMultiplier { get { return energyMultiplier; } set { energyMultiplier = value; } }

        // Armour -- Determines damage reduction for physical attacks        
        private double armor;
        public double Armor { get { return armor; } set { armor = value; } }
        private double armorMultiplier;
        public double ArmorMultiplier { get { return armorMultiplier; } set { armorMultiplier = value; } }

        // Power -- Determines physical damage capability
        private double power;        
        public double Power { get { return power; } set { power = value; } }
        private double powerMultiplier;
        public double PowerMultiplier { get { return powerMultiplier; } set { powerMultiplier = value; } }

        // Magic -- Determins magical damage capability
        private double magic;
        public double Magic { get { return magic; } set { magic = value; } }
        private double magicMultiplier;
        public double MagicMultiplier { get { return magicMultiplier; } set { magicMultiplier = value; } }

        // Crit Chance -- Determines the chance to multiply damage on hit
        private double critChance;
        public double CritChance { get { return critChance; } set { critChance = value; } }

        // Crit Damage -- The multiplier that determines how effective critical strikes are.
        private double critDamage;
        public double CritDamage { get { return critDamage; } set { critDamage = value; } }

        // Evasion -- Determines chance to avoid damage altogether
        private double evasion;
        public double Evasion { get { return evasion; } set { evasion = value; } }

        // Toughness -- An absolute value modifier for reducing incoming damage.
        private double toughness;
        public double Toughness { get { return toughness; } set { toughness = value; } }
    }

    
}
