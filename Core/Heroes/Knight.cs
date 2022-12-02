using IOT1030_Phase2_GUI.Core.Attacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    public class Knight : Hero
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Knight"/> class.
        /// </summary>
        /// <param name="stats">The stats.</param>
        /// <param name="name">The name.</param>
        public Knight(List<int> stats, string name) : this(name)
        {
            _stats = new Dictionary<Stats, int>();

            // Convert list to dictionary
            for (int i = 0; i < stats.Count; i++)
            {
                _stats.Add((Stats)i, stats[i]);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Knight"/> class.
        /// </summary>
        /// <param name="stats">The stats.</param>
        /// <param name="name">The name.</param>
        [JsonConstructor]
        public Knight(Dictionary<Stats, int> stats, string name) : this(name)
        {
            _stats = stats;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Knight"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        private Knight(string name)
        {
            _name = name;
            _heroClass = HeroClass.Knight;
            _attacks = new List<Attack>
            {
                 new NormalAttack(),
                 new LuckyAttack(),
                 new WeaponAttack(),
                 new KnightKnockoutAttack(),
                 new KnightRageAttack()
            };
        }
    }
}
