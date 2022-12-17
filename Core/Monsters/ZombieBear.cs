using IOT1030_Phase2_GUI.Core.MonsterAttacks;
using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.Monsters
{
    public class ZombieBear : Monster
    {
        public ZombieBear() : base()
        {
            _maxHealth = MonsterConfig.ZombieBearHealth;
            _currentHealth = _maxHealth;
            _attacks = new List<MonsterAttack>
            {
                new DeadlyCrunch(),
                new Roar(),
                new ClawGash(),
                new PawAttack(),
            };
        }
    }
}
