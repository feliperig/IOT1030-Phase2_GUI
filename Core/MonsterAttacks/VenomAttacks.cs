using IOT1030_Phase2_GUI.Core.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.MonsterAttacks
{
    class InjectPotion : MonsterAttack
    {
        public InjectPotion() : base()
        {
            _name = "Inject Potion";
            _description = "Inject Potion attack";
        }

        public override int UseAttack()
        {
            int amount = 40;
            int health = _random.Next(1, 50);
            if (health >= amount)
            {
                _damageDealt = _random.Next(health);
                return _damageDealt;
            }
            else
            {
                _damageDealt = _random.Next(0, amount);
                return _damageDealt;
            }
        }
    }

    class MonsterRandomAttack : MonsterAttack
    {
        public MonsterRandomAttack() : base()
        {
            _name = "Monster Random Attack";
            _description = "Monster Random Attack (_random.Next(30, 70))";
        }

        public override int UseAttack()
        {
            _damageDealt = _random.Next(30, 70);
            return _damageDealt;
        }
    }

    class SquareAttack : MonsterAttack
    {
        public SquareAttack() : base()
        {
            _name = "Square Attack";
            _description = "Find square root in a range of 0 and 100; if amount matches to square root, then return damage equal to square root.";
        }

        /// <summary>
        /// Find square root in a range of 0 and 100; if amount matches to square root, then return damage equal to square root.
        /// </summary>
        /// <param name="player"> Player, who will take damage from the monster attack </param>
        /// <returns> if number matches with square root return square root else amount selected by _random object between range 50 and 100 </returns>
        public override int UseAttack()
        {
            _damageDealt = _random.Next(0, 100);
            if (_damageDealt == Math.Sqrt(_damageDealt))
            {
                return _damageDealt;
            }
            _damageDealt -= _random.Next(10);
            return _damageDealt;
        }
    }

    class KillStats : MonsterAttack
    {
        private Hero hero;

        /// <summary>
        /// Work around to make this work -Lane
        /// </summary>
        public KillStats() : base()
        {
            hero = new Player(new List<int>{ 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, "Hero");
            _name = "Kill Stats";
            _description = "Use the hero stats to return an interger";
        }

        /// <summary>
        /// Use the hero stats to return an interger.
        /// </summary>
        /// <returns> value of hero stat when amonnt is greater than or equal to 80 else return the random int between 1 and 80</returns>
        public override int UseAttack()
        {
            int max = 80;
            _damageDealt = _random.Next(1, max);
            if (_damageDealt >= max)
            {
                foreach (var kvp in hero.Stats)
                {
                    for (int i = 0; i < hero.Stats.Count; i++)
                    {
                        return kvp.Value;
                    }
                }
            }
            return _damageDealt;
        }
    }
}
