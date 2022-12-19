using IOT1030_Phase2_GUI.Core.MonsterAttacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Monsters
{
    public class Pishacha : Monster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pishacha"/> class.
        /// </summary>
        public Pishacha() : base()
        {
            _maxHealth = MonsterConfig.PishachaHealth;
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
