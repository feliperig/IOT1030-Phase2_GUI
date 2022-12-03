using IOT1030_Phase2_GUI.Core.Monsters;
using System;

namespace IOT1030_Phase2_GUI.Core.MonsterAttacks
{
    public abstract class MonsterAttack
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
        /// The maximum damage of the attack
        /// </summary>
        protected int _maxDamage;

        /// <summary>
        /// The random object
        /// </summary>
        private Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonsterAttack"/> class.
        /// </summary>
        public MonsterAttack()
        {
            _random = new Random();
        }

        /// <summary>
        /// Uses the attack.
        /// </summary>
        /// <returns></returns>
        public virtual int UseAttack()
        {
            int damageReductionPercent = _random.Next(0, MonsterConfig.MaxMonsterAttackReductionPercent);
            float maxReduction = damageReductionPercent / 100;
            return (int)(_maxDamage * maxReduction);
        }
    }
}
