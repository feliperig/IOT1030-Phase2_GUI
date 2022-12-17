using IOT1030_Phase2_GUI.Core.InventoryObjects;
using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Attacks
{
    public class QueenRoyalAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueenRoyalAttack"/> class.
        /// </summary>
        public QueenRoyalAttack() : base()
        {
            _name = "Queen Royal Attack";
            _description = "Queen attacks dealing damage scaled using Weapon Use and Intelligence";
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

    public class QueenRageAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueenRageAttack"/> class.
        /// </summary>
        public QueenRageAttack() : base()
        {
            _name = "Queen Rage Attack";
            _description = "Queen throws a frenzy of attacks dealing damage scaled using Luck and Intelligence";
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
