using IOT1030_Phase2_GUI.Core.InventoryObjects;
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
        public NormalAttack() : base()
        {
            _name = "Normal Attack";
            _description = "Simple Attack depending on strength";
            _basicStat = Stats.Strength;
        }
    }

    public class LuckyAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LuckyAttack"/> class.
        /// </summary>
        public LuckyAttack() : base()
        {
            _name = "Lucky Attack";
            _description = "Chance based on Luck stat to do big damage";
            _basicStat = Stats.Luck;
        }
    }

    public class MagicAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagicAttack"/> class.
        /// </summary>
        public MagicAttack() : base()
        {
            _name = "Magic Attack";
            _description = "Magic blast dealing damage scaled from Magic stat";
            _basicStat = Stats.Magic;
        }
    }

    public class StealthAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StealthAttack"/> class.
        /// </summary>
        public StealthAttack() : base()
        {
            _name = "Stealth Attack";
            _description = "A stealthy attack with a small chance to do critical damage based on Stealth stat";
            _basicStat = Stats.Stealth;
        }
    }

    public class WeaponAttack : Attack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeaponAttack"/> class.
        /// </summary>
        public WeaponAttack() : base()
        {
            _name = "Weapon Attack";
            _description = "A precision attack using the equipped weapon dealing damage scaled with the Weapon Use stat";
            _basicStat = Stats.WeaponUse;
        }
    }
}
