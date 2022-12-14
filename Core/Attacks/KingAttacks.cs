using IOT1030_Phase2_GUI.Core.InventoryObjects;
using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Attacks
{
    public class KingPowerAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KingPowerAttack"/> class.
        /// </summary>
        public KingPowerAttack() : base()
        {
            _name = "King Power Attack";
            _description = "King attack with the double capacity of his strength.";
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

    public class KingRageAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KingRageAttack"/> class.
        /// </summary>
        public KingRageAttack() : base()
        {
            _name = "Rage King";
            _description = "Super strength, increased health and powered attack.";
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
