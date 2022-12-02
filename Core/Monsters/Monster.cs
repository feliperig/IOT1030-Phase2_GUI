using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Monsters
{
    public abstract class Monster
    {
        protected readonly Random rnd = new Random();

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
        /// Defines if the monster is dead due to its current health
        /// </summary>
        protected bool _isDead = false;
        public bool IsDead
        {
            get { return _isDead; }
            set { _isDead = _currentHealth <= 0; }
        }

        /// <summary>
        /// Takes the damage given, returns if monster is alive
        /// </summary>
        /// <returns>False if monster is not alive</returns>
        public virtual bool TakeDamage(int damage) {
            _currentHealth -= damage;

            if (_currentHealth < 0)
            {
                _currentHealth = 0;
                return IsDead; // Monster dead
            }
            return IsDead; // Monster still alive
        }

        /// <summary>
        /// Deals damage to the opponent
        /// </summary>
        /// <returns>Damage that should be dealt to the opponent</returns>
        public abstract int DealDamage();

        /// <summary>
        /// Chooses what action the monster should do
        /// </summary>
        public abstract void TakeAction();
    }
}
