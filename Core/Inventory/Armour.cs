using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Inventory
{
    public abstract class Armour : Item
    {
        /// <summary>
        /// The amount of protection the armour gives the hero
        /// </summary>
        protected int _protection;
        public int Protection { get { return _protection; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Armour"/> class.
        /// </summary>
        protected Armour()
        {
            _type = ItemType.Armour;
        }

        /// <summary>
        /// Mitigates the damage using the hero stats and protection amount.
        /// </summary>
        /// <param name="damage">The damage.</param>
        /// <param name="heroStats">The hero stats.</param>
        /// <returns>The amount of damage left after mitigation</returns>
        public abstract int MitigateDamage(int damage, Dictionary<Stats, int> heroStats);
    }
}
