using IOT1030_Phase2_GUI.Core.Inventory;
using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Attacks
{
    public class MageFireballAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MageFireballAttack"/> class.
        /// </summary>
        public MageFireballAttack()
        {
            _name = "Mage Fireball Attack";
            _description = "Mage fires a massive fireball dealing damage scaled with Magic and Weapon Use stats";
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

    public class MageIceBlastAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MageIceBlastAttack"/> class.
        /// </summary>
        public MageIceBlastAttack()
        {
            _name = "Mage Ice Blast Attack";
            _description = "Mage fires a blast of ice dealing damage scaled with Magic and Agility stats";
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
