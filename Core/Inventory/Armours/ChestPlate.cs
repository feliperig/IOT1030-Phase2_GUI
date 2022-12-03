using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Inventory.Armours
{
    public class ChestPlate : Armour
    {
        public ChestPlate() : base() 
        {
            _protection = 5;
        }

        /// <summary>
        /// Takes in an amount of damage and reduces it based on the protection level and other special factor for this armour piece
        /// </summary>
        /// <param name="damage">The damage.</param>
        /// <param name="heroStats">The hero stats.</param>
        /// <returns>
        /// The amount of damage left after mitigation
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override int MitigateDamage(int damage, Dictionary<Stats, int> heroStats)
        {
            throw new NotImplementedException();
        }
    }
}
