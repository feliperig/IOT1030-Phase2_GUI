using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    class King : Player
    {
        private PlayerName _name = PlayerName.King;
        private int _strength = 15;
        private int _powerUp = +10;
        private int _luck = 30;
        private int _stealth;

        public King(List<int> stats, string heroName) : base(stats, PlayerName.King, heroName) 
        {
            _attacks = new List<string>()
            {
                "Normal Attack",
                "Luck Factor",
                "Power Up",
                "Rage King"
            };
            _attackDescriptions = new List<string>()
            {
                "Simple attack with equipped weapon",
                "Luck Factor magic (?)",
                "Powerful attack",
                "King enrages"
            };
        }

        public PlayerName GetKingName() { return _name; }
        public int GetKingStrength() { return _strength; }
        public void SetKingStrength(int strength) { _strength = strength; }
        public int GetKingPower() { return _powerUp; }
        public void SetKingPower(int powerUp) { _powerUp = powerUp; }
        public int GetKingLuck() { return _luck; }
        public void SetKingLuck(int luck) { _luck = luck; }
        public int GetKingStealth() { return _stealth; }
        public void SetKingStealth(int stealth) { _stealth = stealth; }

        protected override int NormalAttack()
        {
            return _strength;
        }

        public int LuckFactor()
        {
            if (_luck >= 30)
            {
                if (_health <= 50)
                {
                    Heal(20);
                    _health++;
                }
                else
                {
                    Heal(0);
                }
            }
            else
            {
                Damage(_luck);
            }
            return _health;
        }

        public int PowerUpAttack()
        {
            return 2 * (_strength + _powerUp);
        }

        public int RageKing(int amount)
        {
            const int Maxamount = 100;
            if (amount <= 0)
            {
                Heal(10);
                amount = NormalAttack() + (2 * _powerUp);
            }
            else if (amount > 0 && amount <= 50)
            {
                Heal(2 * amount);
                return _stealth = amount + 20;
            }
            else if (amount > 50 && amount <= Maxamount)
            {
                _stealth = amount;
                Heal(amount);
                return PowerUpAttack();
            }
            else
            {
                amount = Maxamount;
                Heal(amount / 2);
                return PowerUpAttack();
            }
            return amount;
        }
        public override string ToString()
        {
            string ret = "The King burst into rage, recovering a large amount of health and getting a boost to his speed and attack power\n";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(ret);
            Console.ResetColor();
            Console.WriteLine($"Hero '{_name}' has the following stats: \n\t Strength \t => {_strength} \n\t PowerUp \t => +{_powerUp} \n\t Luck     \t => {_luck} \n\t Stealth \t => {_stealth}");
            return ret;
        }
    }
}
