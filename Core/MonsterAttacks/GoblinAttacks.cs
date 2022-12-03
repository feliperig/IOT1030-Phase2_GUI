
namespace IOT1030_Phase2_GUI.Core.MonsterAttacks
{
    public class GoblinNormalAttack : MonsterAttack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoblinNormalAttack"/> class.
        /// </summary>
        public GoblinNormalAttack() : base()
        {
            _name = "Goblin Punch";
            _description = "Goblin simple punch";
            _maxDamage = 25;
        }
    }
    public class GoblinBodySlamAttack : MonsterAttack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoblinBodySlamAttack"/> class.
        /// </summary>
        public GoblinBodySlamAttack() : base()
        {
            _name = "Goblin Body Slam Attack";
            _description = "Goblin jumps into a huge body slam";
            _maxDamage = 35;
        }
    }
    public class GoblinSlapAttack : MonsterAttack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoblinSlapAttack"/> class.
        /// </summary>
        public GoblinSlapAttack() : base()
        {
            _name = "Goblin Slap Attack";
            _description = "Goblin runs up and delivers a weak slap";
            _maxDamage = 10;
        }
    }
    public class GoblinKickAttack : MonsterAttack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoblinKickAttack"/> class.
        /// </summary>
        public GoblinKickAttack() : base()
        {
            _name = "Goblin Kick Attack";
            _description = "Goblin slowly walks up and kicks you in the shin";
            _maxDamage = 20;
        }
    }
}
