using IOT1030_Phase2_GUI.Core.MonsterAttacks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOT1030_Phase2_GUI.Core.Monsters
{
    public abstract class Monster
    {
        /// <summary>
        /// The maximum health of the hero
        /// </summary>
        protected int _maxHealth;
        public int MaxHealth { get { return _maxHealth; } }

        /// <summary>
        /// The current health of the hero
        /// </summary>
        protected int _currentHealth;
        public int CurrentHealth { get { return _currentHealth; } }

        /// <summary>
        /// Gets the name of the monster
        /// </summary>
        public string Name { get { return GetType().ToString().Split('.').Last(); } }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <value>
        /// The image path.
        /// </value>
        public string ImagePath { get { return "/Images/" + Name + "Sprite.png"; } }

        /// <summary>
        /// The attacks of the monster
        /// </summary>
        protected List<MonsterAttack> _attacks;

        /// <summary>
        /// The random object
        /// </summary>
        private Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monster"/> class.
        /// </summary>
        protected Monster()
        {
            _random = new Random();
        }

        /// <summary>
        /// Takes the damage given, returns if monster is alive
        /// </summary>
        /// <returns>False if monster is not alive</returns>
        public virtual bool TakeDamage(int damage) {
            _currentHealth -= damage;
            
            if (_currentHealth <= 0)
                return false; // Monster dead

            return true; // Monster still alive
        }

        /// <summary>
        /// Chooses what action the monster should do
        /// </summary>
        public virtual MonsterAttack TakeAction()
        {
            int randomAttackIndex = _random.Next(0, _attacks.Count - 1);
            return _attacks[randomAttackIndex];
        }
    }
}
