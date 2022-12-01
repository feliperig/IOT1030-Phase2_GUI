using System;
using System.Collections.Generic;
using IOT1030_Phase2_GUI.Core.Attacks;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.NewHeroes
{
    public class King : Hero
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="King"/> class.
        /// </summary>
        /// <param name="stats">The stats.</param>
        /// <param name="name">The name.</param>
        public King(List<int> stats, string name) : this(name)
        {
            _stats = new Dictionary<Stats, int>();

            // Convert list to dictionary
            for(int i = 0; i < stats.Count; i++)
            {
                _stats.Add((Stats)i, stats[i]);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="King"/> class.
        /// </summary>
        /// <param name="stats">The stats.</param>
        /// <param name="name">The name.</param>
        public King(Dictionary<Stats, int> stats, string name) : this(name) 
        {
            _stats = stats;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="King"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        private King(string name) 
        {
            _name = name;
            _heroClass = HeroClass.King;
            _attacks = new List<Attack>
            {
                 new NormalAttack(),
                 new KingPowerAttack(),
                 new KingRageAttack()
            };
        }
    }
}
