using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    class Queen : Player
    {
        private PlayerName _name = PlayerName.Queen;
        private int _strength = 10;
        private int _powerUp = +10;
        private int _luck = 50;
        private int _stealth;

        public Queen(List<int> stats, string heroName) : base(stats, PlayerName.Queen, heroName) 
        {
            _attacks = new List<string>()
            {
                "Normal Attack",
                "Death Match",
                "Luck",
                "Rage Queen"
            };
            _attackDescriptions = new List<string>()
            {
                "Simple attack with equipped weapon",
                "Queen's special attack",
                "Luck attack",
                "Queen enrages"
            };
        }

        public PlayerName GetQueentName() { return _name; }
        public int GetQueenStrength() { return _strength; }
        public void SetQueenStrength(int strength) { _strength = strength; }
        public int GetQueenPower() { return _powerUp; }
        public void SetQueenPower(int powerUp) { _powerUp = powerUp; }
        public int GetQueenLuck() { return _luck; }
        public void SetQueenLuck(int luck) { _luck = luck; }
        public int GetQueenStealth() { return _stealth; }
        public void SetQueenStealth(int stealth) { _stealth = stealth; }
        protected override int NormalAttack()
        {
            return _strength;
        }

        public int DeathMatch()
        {
            return (5 * _powerUp) + _strength;
        }

        public int Luck()
        {
            if (_luck >= 50)
            {
                if (_health <= 50)
                {
                    Heal(50);
                    _health++;
                }
                else
                {
                    Heal(0);
                }
            }
            else if (_luck >= 30 && _luck < 50)
            {
                Heal(20);
            }
            else
            {
                Damage(_luck);
            }
            return _health;
        }

        public int RageQueen(int amount)
        {
            const int Maxamount = 100;
            if (amount <= 0)
            {
                amount = NormalAttack() + (2 * _powerUp);
            }
            else if (amount > 0 && amount <= 50)
            {
                return _stealth = amount + _powerUp;
            }
            else if (amount > 50 && amount <= Maxamount)
            {
                _stealth = amount;
                Heal(_stealth);
                return DeathMatch();
            }
            else
            {
                amount = Maxamount;
                Heal(amount / 2);
                return DeathMatch();
            }
            return amount;
        }
        public override string ToString()
        {
            string ret = "The Queen vanishes from sight to recover some health and unleash devastating volleys of high damage ammunition.\n";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ret);
            Console.ResetColor();
            Console.WriteLine($"Hero '{_name}' has the following stats: \n\t Strength \t => {_strength} \n\t PowerUp \t => +{_powerUp} \n\t Luck     \t => {_luck} \n\t Stealth \t => {_stealth}");
            return ret;
        }
    }
}
