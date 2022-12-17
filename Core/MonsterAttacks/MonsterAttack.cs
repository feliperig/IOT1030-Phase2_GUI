using IOT1030_Phase2_GUI.Core.Heroes;
using IOT1030_Phase2_GUI.Core.Monsters;
using System;

namespace IOT1030_Phase2_GUI.Core.MonsterAttacks
{
    public class MonsterAttack : Attack
    {
        /// <summary>
        /// The maximum damage of the attack
        /// </summary>
        protected int _maxDamage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonsterAttack"/> class.
        /// </summary>
        protected MonsterAttack()
        {
            _random = new Random();
        }

        public MonsterAttack(string name, string description, int damageDealt)
        {
            _name= name;
            _description= description;
            _damageDealt = damageDealt;
        }

        /// <summary>
        /// Uses the attack.
        /// </summary>
        /// <returns></returns>
        public virtual int UseAttack()
        {
            int damageReductionPercent = _random.Next(0, MonsterConfig.MaxMonsterAttackReductionPercent);
            float damageReduction = (100 - damageReductionPercent) / 100f;
            Console.WriteLine($"Damage Reduction: {damageReduction}");
            _damageDealt = (int)(_maxDamage * damageReduction);
            Console.WriteLine($"Damage dealt: {_damageDealt}");
            return _damageDealt;
        }
    }
}
