using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    public class Knight : Player
    {
        protected PlayerName _name = PlayerName.Knight;
        protected int _strength = 40;
        private int _powerUp = +20;
        private int _luck = 10;
        private int _stealth;
        private readonly int thunderboltstrike = 80;

        public Knight(List<int> stats, string heroName) : base(stats, PlayerName.Knight, heroName)
        {
            _attacks = new List<string>()
            {
                "Normal Attack",
                "Knockout Smash",
                "Unexpected Luck",
                "Rage Knight"
            };
            _attackDescriptions = new List<string>()
            {
                "Simple Attack depending on strength.",
                "Rigorous Night with unbeatable strength",
                "One hit Kill Smash",
                "Luck have unexpected improvements"
            };
        }
        //public Knight() : base(PlayerName.Knight) { }
        
        public int KnockoutSmash()
        {
            return thunderboltstrike + _strength;
        }
        
        public int UnexpectedLuck()
        {
            if (_luck <= MaxHealth/3)
            {
                if (_health <= MaxHealth/10)
                {
                    _health = MaxHealth;
                }
                else if (_health > (MaxHealth / 10) && _health <= (MaxHealth/2))
                {
                    Heal(MaxHealth/2);
                }
                else
                {
                    Heal(0);
                }
            }
            else
            {
                Heal(_luck);
            }
            return _health;
        }
        
        public override int NormalAttack()
        {
            int min = 0;
            int max = 100;
            if(_health <= max && _health >= max / 2)
            {
                return (_strength * 2) + _powerUp;
            }
            if(_health < max/2 && _health > min)
            {
                return _strength + _powerUp;
            }
            return _strength;
        }
        
        public int RageKnight(int rageamount)
        {
            const int MaxRageamount = 100;
            if (rageamount <= 0)
            {
                return _strength;
            }
            else if (rageamount > 0 && rageamount <= MaxRageamount/2)
            {
                Heal(rageamount);
                return _strength + (_powerUp / 2);
            }
            else if (rageamount <= MaxRageamount)
            {
                Heal(rageamount);
                return _stealth = rageamount;
            }
            else
            {
                Heal(MaxRageamount);
                return _health;
            }
        }

        public override string ToString()
        {
            string ret = "There is a Mystery about this Hero! Try it out and Find the Mystery...!!!\n";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(ret);
            Console.ResetColor();
            Console.WriteLine($"Hero '{_name}' has the following stats: \n\t Strength \t => {_strength} \n\t PowerUp \t => +{_powerUp} \n\t Luck     \t => {_luck} \n\t Stealth \t => {_stealth}");
            return ret;
        }
    }
}
