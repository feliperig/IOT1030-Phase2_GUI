using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.MonsterAttacks
{
    public class OrcNormalAttack : MonsterAttack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrcNormalAttack"/> class.
        /// </summary>
        public OrcNormalAttack() : base()
        {
            _name = "Orc Punch";
            _description = "Goblin simple punch";
            _maxDamage = 29;
        }
    }
    public class OrcBodySlamAttack : MonsterAttack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrcBodySlamAttack"/> class.
        /// </summary>
        public OrcBodySlamAttack() : base()
        {
            _name = "Orc Body Slam Attack";
            _description = "Orc jumps into a huge body slam";
            _maxDamage = 40;
        }
    }
    public class OrcBatAttack : MonsterAttack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrcBatAttack"/> class.
        /// </summary>
        public OrcBatAttack() : base()
        {
            _name = "Orc Bat Attack";
            _description = "Orc runs up and delivers a swing of his bat";
            _maxDamage = 50;
        }
    }
    public class OrcHeadbuttAttack : MonsterAttack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrcHeadbuttAttack"/> class.
        /// </summary>
        public OrcHeadbuttAttack() : base()
        {
            _name = "Orc Headbutt Attack";
            _description = "Orc slowly walks up and slams his head against yours";
            _maxDamage = 35;
        }
    }
}
