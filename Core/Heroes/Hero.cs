using IOT1030_Phase2_GUI.Core.InventoryObjects;
using IOT1030_Phase2_GUI.Core.InventoryObjects.Armours;
using IOT1030_Phase2_GUI.Core.InventoryObjects.Weapons;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    [JsonConverter(typeof(HeroConverter))]
    public abstract class Hero
    {
        /// <summary>
        /// Gets the type of the hero
        /// </summary>
        public string Type { get { return GetType().ToString().Split('.').Last(); } }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <value>
        /// The image path.
        /// </value>
        public string ImagePath { get { return "/Images/" + ClassName + "Sprite.png"; } }

        /// <summary>
        /// The maximum health of the hero
        /// </summary>
        protected int _maxHealth;
        public int MaxHealth { get { return _maxHealth; } }

        /// <summary>
        /// The current health of the hero
        /// </summary>
        protected int _currentHealth;
        public int CurrentHealth { get { return _currentHealth; } }

        /// <summary>
        /// The name of the hero
        /// </summary>
        protected string _name;
        public string Name { get { return _name; } }

        /// <summary>
        /// The hero class of the hero
        /// </summary>
        protected HeroClass _heroClass;
        public HeroClass HeroClass { get { return _heroClass; } }
        public string ClassName { get { return HeroClass.ToString(); } }

        /// <summary>
        /// The inventory
        /// </summary>
        protected Inventory _inventory;

        /// <summary>
        /// The equipped weapon
        /// </summary>
        protected Weapon _equippedWeapon;
        public Weapon EquippedWeapon { get { return _equippedWeapon; } }

        /// <summary>
        /// The equipped armour
        /// </summary>
        protected Armour _equippedArmour;
        public Armour EquippedArmour { get { return _equippedArmour; } }

        /// <summary>
        /// The stats of the hero
        /// </summary>
        protected Dictionary<Stats, int> _stats;
        public Dictionary<Stats, int> Stats { get { return _stats; } }

        /// <summary>
        /// The attacks of the hero
        /// </summary>
        protected List<Attack> _attacks;
        public List<Attack> Attacks { get { return _attacks; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hero"/> class.
        /// </summary>
        protected Hero()
        {
            _inventory = new Inventory(HeroConfig.HeroInventorySize);
            _equippedWeapon = new Sword();
            _equippedArmour = new ChestPlate();
        }

        /// <summary>
        /// Gets the attack at the given index.
        /// </summary>
        /// <param name="index">The index of the attack.</param>
        /// <returns></returns>
        public virtual Attack GetAttack(int index)
        {
            if (index > _attacks.Count)
                return null;

            return _attacks[index];
        }

        /// <summary>
        /// Gets the damage from attack at the given index.
        /// </summary>
        /// <param name="index">The index of the attack.</param>
        /// <returns></returns>
        public virtual int GetDamageFromAttack(int index)
        {
            if (index > _attacks.Count)
                return 0;
            return _attacks[index].UseAttack(_stats, _equippedWeapon);
        }

        /// <summary>
        /// Takes the amount damage given.
        /// </summary>
        /// <param name="damage">The damage.</param>
        /// <returns>If the hero is still alive</returns>
        public virtual bool TakeDamage(int damage)
        {
            System.Console.WriteLine($"Hero to take {damage} damage");
            int damageToTake = damage;
            if(_equippedArmour != null)
            {
                damageToTake = _equippedArmour.MitigateDamage(damage, _stats);
            }
            System.Console.WriteLine($"Hero took {damageToTake} damage");

            _currentHealth -= damageToTake;

            if(_currentHealth <= 0) 
                return false; // Hero dead

            return true; // Hero still alive
        }

        /// <summary>
        /// Gets the attack names.
        /// </summary>
        /// <returns>List of attack names</returns>
        public virtual List<string> GetAttackNames()
        {
            List<string> attackNames = new List<string>();
            foreach(Attack attack in _attacks)
            {
                attackNames.Add(attack.Name);
            }
            return attackNames;
        }

        /// <summary>
        /// Gets the attack descriptions.
        /// </summary>
        /// <returns>List of attack descriptions</returns>
        public virtual List<string> GetAttackDescriptions()
        {
            List<string> attackDescriptions = new List<string>();
            foreach(Attack attack in _attacks)
            {
                attackDescriptions.Add(attack.Description);
            }
            return attackDescriptions;
        }

        /// <summary>
        /// Gets the stat from the list of stats
        /// </summary>
        /// <param name="stat">The stat to get</param>
        /// <returns></returns>
        public virtual int GetStat(Stats stat)
        {
            return Stats[stat];
        }
    }

    /// <summary>
    /// Enum for all stats
    /// </summary>
    public enum Stats
    {
        Strength,
        Intelligence,
        Agility,
        Vitality,
        Luck,
        Magic,
        WeaponUse,
        Parry,
        Dodge,
        Stealth
    }

    /// <summary>
    /// Enum for all hero classes
    /// </summary>
    public enum HeroClass
    {
        Player,
        King,
        Queen,
        Knight,
        Mage,
        Archer
    }
}
