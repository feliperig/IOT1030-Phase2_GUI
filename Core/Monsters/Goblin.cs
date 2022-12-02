using System;

namespace IOT1030_Phase2_GUI.Core.Monsters
{
    class Goblin : Monster
    {
        public Goblin() 
        {
            _maxHealth = ( rnd.Next()*15 ) + 45;
            _currentHealth = _maxHealth;
        }

        public override int DealDamage()
        {
            return ( rnd.Next()*10 ) + 1;
        }

        public override void TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
