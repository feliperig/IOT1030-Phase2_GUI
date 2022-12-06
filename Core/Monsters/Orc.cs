using IOT1030_Phase2_GUI.Core.MonsterAttacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Monsters
{
    public class Orc : Monster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Orc"/> class.
        /// </summary>
        public Orc() : base()
        {
            _maxHealth = MonsterConfig.OrcHealth;
            _currentHealth = _maxHealth;
            _attacks = new List<MonsterAttack>
            {
                new OrcNormalAttack(),
                new OrcHeadbuttAttack(),
                new OrcBatAttack(),
                new OrcBodySlamAttack()
            };
        }
    }
}
