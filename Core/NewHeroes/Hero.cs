using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.NewHeroes
{
    public abstract class Hero
    {
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

        /// <summary>
        /// The stats of the hero
        /// </summary>
        protected Dictionary<Stats, int> _stats;
        public Dictionary<Stats, int> Stats { get { return _stats; } }

        /// <summary>
        /// The attacks of the hero
        /// </summary>
        protected List<Attack> _attacks;

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
            return _attacks[index].UseAttack(Stats);
        }

        /// <summary>
        /// Takes the amount damage given.
        /// </summary>
        /// <param name="damage">The damage.</param>
        /// <returns>If the hero is still alive</returns>
        public virtual bool TakeDamage(int damage)
        {
            _currentHealth -= damage;

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
