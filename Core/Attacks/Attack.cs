using IOT1030_Phase2_GUI.Core.InventoryObjects;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    public class Attack
    {
        /// <summary>
        /// The name of the Attack
        /// </summary>
        protected string _name;
        public string Name { get { return _name; } }

        /// <summary>
        /// The description of the Attack
        /// </summary>
        protected string _description;
        public string Description { get { return _description; } }

        /// <summary>
        /// The basic stat used for the basic attack function
        /// </summary>
        protected Stats _basicStat = Stats.Strength;

        /// <summary>
        /// The weapon damage
        /// </summary>
        protected int _weaponDamage;
        public int WeaponDamage { get { return _weaponDamage; } }

        /// <summary>
        /// The maximum multiplier percentage for the weapon damage
        /// </summary>
        protected int _maxWeaponMultiplierPercentage;
        public int MaxWeaponMultiplierPercentage { get { return _maxWeaponMultiplierPercentage; } }

        /// <summary>
        /// The current weapon multiplier percentage
        /// </summary>
        protected int _weaponMultiplierPercentage;
        public int WeaponMultiplierPercentage { get { return _weaponMultiplierPercentage; } }

        /// <summary>
        /// The damage dealt when UseAttack() was called
        /// </summary>
        protected int _damageDealt;
        public int DamageDealt { get { return _damageDealt; } }

        /// <summary>
        /// The random object
        /// </summary>
        protected Random _random;

        protected Attack()
        {
            _random = new Random();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attack"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="weaponDamage">The weapon damage.</param>
        /// <param name="maxWeaponMultiplierPercentage">The maximum weapon multiplier percentage.</param>
        /// <param name="weaponMultiplierPercentage">The weapon multiplier percentage.</param>
        /// <param name="damageDealt">The damage dealt.</param>
        public Attack(string name, string description, int weaponDamage, int maxWeaponMultiplierPercentage, int weaponMultiplierPercentage, int damageDealt)
        {
            _name = name;
            _description = description;
            _weaponDamage = weaponDamage;
            _maxWeaponMultiplierPercentage = maxWeaponMultiplierPercentage;
            _weaponMultiplierPercentage = weaponMultiplierPercentage;
            _damageDealt = damageDealt;
        }

        /// <summary>
        /// Uses the basic attack, using the basic stat
        /// </summary>
        /// <param name="heroStats">The hero stats of the hero that used this attack.</param>
        /// <returns></returns>
        public virtual int UseAttack(Dictionary<Stats, int> heroStats, Weapon equippedWeapon)
        {
            _weaponDamage = equippedWeapon.GetDamage(heroStats); // Get damage from weapon

            _maxWeaponMultiplierPercentage = 100 + (heroStats[_basicStat] / 5 * 35); // Get multiplier (+35% for every 5 _basicStat)
            _weaponMultiplierPercentage = _random.Next(75, _maxWeaponMultiplierPercentage);

            float weaponMultiplier = _weaponMultiplierPercentage / 100f; // Convert to float for multiplying

            _damageDealt = (int)(_weaponDamage * weaponMultiplier); // Apply multiplier

            return _damageDealt;
        }
    }
}
