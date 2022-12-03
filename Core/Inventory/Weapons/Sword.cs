using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Inventory.Weapons
{
    public class Sword : Weapon
    {
        public Sword() : base() 
        {
            _damage = 5;
        }

        public override int GetDamage(Dictionary<Stats, int> heroStats)
        {
            throw new NotImplementedException();
        }
    }
}
