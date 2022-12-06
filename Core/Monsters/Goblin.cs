using IOT1030_Phase2_GUI.Core.MonsterAttacks;
using System;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Monsters
{
    public class Goblin : Monster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Goblin"/> class.
        /// </summary>
        public Goblin() : base() 
        {
            _maxHealth = MonsterConfig.GoblinHealth;
            _currentHealth = _maxHealth;
            _attacks = new List<MonsterAttack>
            {
                new GoblinNormalAttack(),
                new GoblinSlapAttack(),
                new GoblinKickAttack(),
                new GoblinBodySlamAttack()
            };
        }
    }
}
