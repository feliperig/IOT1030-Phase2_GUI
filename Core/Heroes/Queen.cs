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
                "Simple Attack depending on strength.",
                "Knockout the enemy",
                "Higher the luck higher the healing amount for queen",
                "Agile queen has powerful attack when in rage ability"
            };
        }

        public int DeathMatch()
        {
            return (5 * _powerUp) + _strength;
        }

        public override int NormalAttack()
        {
            return _strength + _powerUp;
        }
        
        public int Luck()
        {
            if (_luck >= (MaxHealth/2))
            {
                if (_health <= (MaxHealth/2))
                {
                    Heal(MaxHealth/2);
                }
                else
                {
                    Heal(MaxHealth/10);
                }
            }
            else if (_luck < (MaxHealth/2) && _luck > 0)
            {
                if (_health <= (MaxHealth / 2))
                {
                    Heal(2 * _luck);
                }
                else
                {
                    Heal(_luck);
                }
            }
            else
            {
                _luck = 0;
                Damage(_luck + 5);
            }
            return _health;
        }
        
        public int Ragequeen(int amount)
        {
            const int Maxamount = 100;
            if (amount <= 0)
            {
                return NormalAttack();
            }
            else if (amount > 0 && amount <= Maxamount/2)
            {
                Heal(amount);
                return 2*NormalAttack();
            }
            else if (amount > (Maxamount/2) && amount <= Maxamount)
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
