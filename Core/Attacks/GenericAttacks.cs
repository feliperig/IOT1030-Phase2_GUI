using IOT1030_Phase2_GUI.Core.Inventory;
using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Attacks
{
    public class NormalAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalAttack"/> class.
        /// </summary>
        public NormalAttack()
        {
            _name = "Normal Attack";
            _description = "Simple Attack depending on strength";
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

    public class LuckyAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LuckyAttack"/> class.
        /// </summary>
        public LuckyAttack()
        {
            _name = "Lucky Attack";
            _description = "Chance based on Luck stat to do big damage";
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

    public class MagicAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagicAttack"/> class.
        /// </summary>
        public MagicAttack()
        {
            _name = "Magic Attack";
            _description = "Magic blast dealing damage scaled from Magic stat";
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

    public class StealthAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StealthAttack"/> class.
        /// </summary>
        public StealthAttack()
        {
            _name = "Stealth Attack";
            _description = "A stealthy attack with a small chance to do critical damage based on Stealth stat";
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

    public class WeaponAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponAttack"/> class.
        /// </summary>
        public WeaponAttack()
        {
            _name = "Weapon Attack";
            _description = "A precision attack using the equipped weapon dealing damage scaled with the Weapon Use stat";
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
