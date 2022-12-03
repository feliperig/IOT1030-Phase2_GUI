using IOT1030_Phase2_GUI.Core.Heroes;
using IOT1030_Phase2_GUI.Core.Inventory;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Attacks
{
    public class ArcherPreciseShotAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArcherPreciseShotAttack"/> class.
        /// </summary>
        public ArcherPreciseShotAttack()
        {
            _name = "Precise Shot Attack";
            _description = "Archer attacks with an expert bow shot scaled with Weapon Use stat";
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

    public class ArcherQuickAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArcherQuickAttack"/> class.
        /// </summary>
        public ArcherQuickAttack()
        {
            _name = "Archer Quick Attack";
            _description = "Archer quickly attacks dealing damage scaled with Agility and Weapon Use stats";
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
