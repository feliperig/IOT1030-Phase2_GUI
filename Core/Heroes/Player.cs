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

        protected virtual int NormalAttack() { return 10; }

        public int GetNormalAttack()
        {
            return NormalAttack();
        }

        protected void Heal(int amount)
        {
            _health += amount;
            if (_health > MaxHealth)
            {
                _health = MaxHealth;
            }
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
        public enum PlayerName { King, Queen, Knight, Mage, Player, Archer };

        public List<string> GetAttackNames()
        {
            return _attacks;
        }

        public List<string> GetAttackDescriptions()
        {
            return _attackDescriptions;
        }
    }
}

