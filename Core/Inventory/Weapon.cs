using IOT1030_Phase2_GUI.Core.NewHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Inventory
{
    public abstract class Weapon : Item
    {
        /// <summary>
        /// The amount of damage this weapon deals
        /// </summary>
        protected int _damage;
        public int Damage { get { return _damage; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        protected Weapon()
        {
            _type = ItemType.Weapon;
        }

        /// <summary>
        /// Gets the damage of the weapon using the weapon damage and hero stats.
        /// </summary>
        /// <param name="heroStats">The hero stats.</param>
        /// <returns></returns>
        public abstract int GetDamage(Dictionary<Stats, int> heroStats);
    }
}
