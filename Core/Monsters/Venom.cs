using IOT1030_Phase2_GUI.Core.Heroes;
using IOT1030_Phase2_GUI.Core.MonsterAttacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Monsters
{
    public class Venom : Monster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Venom"/> class.
        /// </summary>
        public Venom() : base()
        {
            _maxHealth = MonsterConfig.VenomHealth;
            _currentHealth = _maxHealth;
            _attacks = new List<MonsterAttack>
            {
                new InjectPotion(),
                new KillStats(),
                new MonsterRandomAttack(),
                new SquareAttack()
            };
        }
    }
}
