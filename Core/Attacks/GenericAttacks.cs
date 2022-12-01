using IOT1030_Phase2_GUI.Core.Inventory;
using IOT1030_Phase2_GUI.Core.NewHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
