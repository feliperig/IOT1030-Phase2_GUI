using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.InventoryObjects
{
    public abstract class Weapon : Item
    {
        /// <summary>
        /// The amount of damage this weapon deals
        /// </summary>
        protected int _damage;
        public int Damage { get { return _damage; } }

        /// <summary>
        /// Random object
        /// </summary>
        protected Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        protected Weapon()
        {
            _type = ItemType.Weapon;
            _random = new Random();
        }

        /// <summary>
        /// Gets the damage of the weapon using the weapon damage and hero stats.
        /// </summary>
        /// <param name="heroStats">The hero stats.</param>
        /// <returns></returns>
        public abstract int GetDamage(Dictionary<Stats, int> heroStats);
    }
}
