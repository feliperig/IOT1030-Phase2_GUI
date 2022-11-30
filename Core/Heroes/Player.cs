using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    public class Player
    {
        protected const int MaxHealth = 100;
        protected static int _health = MaxHealth;
        protected List<int> _stats;
        protected bool hit = true;
        protected bool _hasMap = true;
        protected bool _hasSword = false;
        protected string _characterName;
        protected PlayerName _characterClass;
        protected List<string> _attacks = new List<string>()
        {
            "Normal Attack",
            "One Time Ability",
            "Player Protection",
            "Rage Player"
        };
        protected List<string> _attackDescriptions = new List<string>()
        {
            "Simple attack with equipped weapon",
            "Player special sorcery, available only once",
            "Player protects himself from damage",
            "Player enrages"
        };   

        /*****************************************************
           * Needs to be adjusted when Monster class is made.
           * When monster hit the hero player will take the damage.
         *****************************************************/
        public bool Hit
        {
            get { return hit; }
            protected set { hit = value; }
        }

        protected void Defend()
        {
            int crit = 10;
            if(_health < crit)
            {
                for(int i = 0; i < MaxHealth/5; i++)
                {
                    Damage(0);
                }
            }
        }

        /// <summary>
        /// Heal the health
        /// </summary>
        /// <param name="amount"> amount with which health can be increased </param>
        protected void Heal(int amount)
        {
            _health += amount;
            if (_health > MaxHealth)
            {
                _health = MaxHealth;
            }
        }
        
        public virtual int NormalAttack()
        {
                return MaxHealth/2;
        }

        protected void Damage(int amount)
        {
            _health -= amount;
            if (_health < 0)
            {
                _health = 0;
            }
        } 
        
        public Player(List<int> stats, PlayerName playerClass, string name) 
        { 
            _stats = stats;
            _characterClass = playerClass;
            _characterName = name;
        }

        public List<string> GetAttackNames()
        {
            return _attacks;
        }

        public List<string> GetAttackDescriptions()
        {
            return _attackDescriptions;
        }
        
        public string CauseOfDeath { get; private set; }
        
        public void Kill(string cause)
        {
            _health = 0;
            CauseOfDeath = cause;
        }
    }

    public enum PlayerName { King, Queen, Knight, Mage, Player, Archer };
}

