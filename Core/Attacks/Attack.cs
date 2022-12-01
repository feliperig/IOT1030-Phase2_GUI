﻿using IOT1030_Phase2_GUI.Core.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    public abstract class Attack
    {
        /// <summary>
        /// The name of the Attack
        /// </summary>
        protected string _name;
        public string Name { get { return _name; } }

        /// <summary>
        /// The description of the Attack
        /// </summary>
        protected string _description;
        public string Description { get { return _description; } }

        /// <summary>
        /// Uses the attack.
        /// </summary>
        /// <param name="heroStats">The hero stats of the hero that used this attack.</param>
        /// <returns></returns>
        public abstract int UseAttack(Dictionary<Stats, int> heroStats, Weapon equippedWeapon);
    }
}
