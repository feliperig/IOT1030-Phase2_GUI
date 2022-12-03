using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.InventoryObjects.Weapons
{
    public class Sword : Weapon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sword"/> class.
        /// </summary>
        public Sword() : base() 
        {
            _damage = 5;
        }

        /// <summary>
        /// Sword base damage + ((Sword base damage * (strength / 2)) * (0.5 - (0.1 * (Luck / 5))
        /// </summary>
        /// <param name="heroStats">The hero stats.</param>
        /// <returns></returns>
        public override int GetDamage(Dictionary<Stats, int> heroStats)
        {
            float extraDamage = (_damage * (heroStats[Stats.Strength] / 2)); // Get extra damage using Hero's strength stat

            int maxDamageReduction = heroStats[Stats.Luck] / 5; // For every 5 points int luck, 10% better chance to do max damage
            maxDamageReduction = 5 - maxDamageReduction;

            if (maxDamageReduction < 0)
                maxDamageReduction = 0;

            extraDamage *= (1 - (_random.Next(0, maxDamageReduction) / 10)); // Reduce damage up to 50%

            int damageOutput = (int)(_damage + extraDamage);  // Add extra damage to weapon damage
            return damageOutput;
        }
    }
}
