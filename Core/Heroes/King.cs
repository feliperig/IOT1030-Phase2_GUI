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

         public int Luckfactor()
        {
            Shield shield = new();
            int expectedlevel = 30;
            if (_luck >= expectedlevel)
            {
                if (_health <= expectedlevel)
                {
                    Heal(_luck);
                }
                else
                {
                    Heal(expectedlevel);
                }
            }
            if(_luck < expectedlevel)
            {
                if(_health < expectedlevel)
                {
                    for (int i = 0; i < expectedlevel + shield.GetHitpoint(); i++)      // Shield hitpoint will work as defence for king.
                    {
                        _health++;
                    }
                }
            }
            return _health;
        }
        public int PowerUpAttack()
        {
            int min = 0;
            int multiplier = 2;
            int max = 100;
            if(_health == MaxHealth)
            {
                if ((_strength + _powerUp) < max / 2)
                {
                    return (_strength + _powerUp) * multiplier;
                }

            }
            if(_health < MaxHealth && _health > min)
            {
                return _strength + _powerUp;
            }
            return RageKing(MaxHealth / 4);
        }
        public int DoubleKingStrength()
        {
            int times = 2;
            return times * _strength;
        }
        public int RageKing(int amount)
        {
            const int Maxamount = 100;
            int multiplier = 2;
            if (amount <= Maxamount / 10)
            {
                Heal(10);
                Defend();
                return NormalAttack();
            }
            else if (amount > 10 && amount <= Maxamount / 2)
            {
                Heal(multiplier * amount);
                Defend();
                return _stealth = amount + 20;
            }
            else if (amount > Maxamount / 2 && amount <= Maxamount)
            {
                _stealth = amount;
                Heal(_stealth);
                Defend();
                return PowerUpAttack();
            }
            else
            {
                amount = Maxamount;
                Heal(amount / 2);
                Defend();
                return PowerUpAttack();
            }
        }
        public override int NormalAttack()
        {
            int multiplier = 2;
            Sword sword = new();
            if(sword != null)
            {
                return sword.GetDamage() + _strength * multiplier;
            }
            else
            {
                return (multiplier * multiplier * _strength) + _powerUp;
            }
        }
        
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
