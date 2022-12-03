using IOT1030_Phase2_GUI.Core.InventoryObjects;
using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Attacks
{
    public class KnightKnockoutAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KnightKnockoutAttack"/> class.
        /// </summary>
        public KnightKnockoutAttack()
        {
            _name = "Knockout Attack";
            _description = "Knight attacks with incredible strength";
        }

        /// <summary>
        /// Uses the attack.
        /// </summary>
        /// <param name="heroStats">The hero stats of the hero that used this attack.</param>
        /// <returns>The amount of damage calculated</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override int UseAttack(Dictionary<Stats, int> heroStats, Weapon equippedWeapon)
        {
            throw new NotImplementedException();
        }
    }

    public class KnightRageAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KnightRageAttack"/> class.
        /// </summary>
        public KnightRageAttack()
        {
            _name = "Knight Rage Attack";
            _description = "Knight attacks with a fury of swipes using Strength, Agility, and Weapon Use stats";
        }

        /// <summary>
        /// Uses the attack.
        /// </summary>
        /// <param name="heroStats">The hero stats of the hero that used this attack.</param>
        /// <returns>The amount of damage calculated</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override int UseAttack(Dictionary<Stats, int> heroStats, Weapon equippedWeapon)
        {
            throw new NotImplementedException();
        }
    }
}
