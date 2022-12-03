using System;

namespace IOT1030_Phase2_GUI.Core.Monsters
{
    public class Goblin : Monster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Goblin"/> class.
        /// </summary>
        public Goblin() : base() 
        {
            _maxHealth = MonsterConfig.GoblinHealth;
            _currentHealth = _maxHealth;
        }

        /// <summary>
        /// Chooses what action the goblin should do
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
