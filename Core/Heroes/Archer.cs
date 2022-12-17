using IOT1030_Phase2_GUI.Core.Attacks;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    public class Archer : Hero
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Archer"/> class.
        /// </summary>
        /// <param name="stats">The stats.</param>
        /// <param name="name">The name.</param>
        public Archer(List<int> stats, string name) : this(name)
        {
            _stats = new Dictionary<Stats, int>();

            // Convert list to dictionary
            for (int i = 0; i < stats.Count; i++)
            {
                _stats.Add((Stats)i, stats[i]);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Archer"/> class.
        /// </summary>
        /// <param name="stats">The stats.</param>
        /// <param name="name">The name.</param>
        [JsonConstructor]
        public Archer(Dictionary<Stats, int> stats, string name) : this(name)
        {
            _stats = stats;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Archer"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        private Archer(string name) : base()
        {
            _name = name;
            _heroClass = HeroClass.Archer;
            _attacks = new List<Attack>
            {
                new NormalAttack(),
                new LuckyAttack(),
                new WeaponAttack(),
                new ArcherPreciseShotAttack(),
                new ArcherQuickAttack()
            };

            _maxHealth = HeroConfig.ArcherHealth;
            _currentHealth = _maxHealth;
        }
    }
}
