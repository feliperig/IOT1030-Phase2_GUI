using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.InventoryObjects.Armours
{
    public class ChestPlate : Armour
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChestPlate"/> class.
        /// </summary>
        public ChestPlate() : base() 
        {
            _protection = 5;
            _name = "Chest Plate";
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
            float mitigation = (100 - ((float)_protection * (heroStats[Stats.Strength]))) / 100f; // amount of mitigation percent is (protection * (hero strength stat)) / 100

            Console.WriteLine($"Base mitigation: {mitigation}");

            int maxReduction = 5 - (heroStats[Stats.Luck] / 5); // Max amount of reduction gets better for every 5 luck

            if (maxReduction > 8)
                maxReduction = 8;
            else if(maxReduction < 0) 
                maxReduction = 0;

            float reduction = (_random.Next(0, maxReduction) / 10f) + 1f; // Random amount of reduction up to max amount

            if(reduction < ItemConfig.MaxReduction) // Ensure reduction amount is >= ItemConfig.MaxReduction
                reduction = ItemConfig.MaxReduction;

            mitigation *= reduction; // Reduce mitigation percent by reduction

            if(mitigation < ItemConfig.MaxMitigation)
                mitigation = ItemConfig.MaxMitigation; // Ensure migigation is <= MaxMitigation

            Console.WriteLine($"Reduction: {reduction} Mitigation: {mitigation}, Max Reduction: {maxReduction}");
            int damageLeftover = (int)(damage * mitigation); // Apply mitigation to damage

            return damageLeftover;
        }
    }
}
