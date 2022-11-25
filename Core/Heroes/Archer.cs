using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    public class Archer : Player
    {
        private PlayerName _name = PlayerName.Archer;
        private int _strength = 40;
        private int _powerUp = +20;
        private int _luck = 10;
        private int _stealth;

        public Archer(List<int> stats, string heroName) : base(stats, PlayerName.Archer, heroName)
        {
            _attacks = new List<string>()
            {
                "Normal Attack",
                "Knockout Smash",
                "Unexpected Luck",
                "Rage Archer"
            };
            _attackDescriptions = new List<string>()
            {
                "Simple attack with equipped weapon",
                "Special powerful archer attacks that deals a massive damage",
                "Lucky archer heals himself",
                "Archer enrages"
            };
        }
        //public Knight() : base(PlayerName.Knight) { }

        protected override int NormalAttack()
        {
            Console.WriteLine(_strength);
            return _strength;
        }

        public PlayerName GetKnightName() { return _name; }
        public int GetKnightStrength() { return _strength; }
        public void SetKnightStrength(int strength) { _strength = strength; }
        public int GetKnightPower() { return _powerUp; }
        public void SetKnightPower(int powerUp) { _powerUp = powerUp; }
        public int GetKnightLuck() { return _luck; }
        public void SetKnightLuck(int luck) { _luck = luck; }
        public int GetKnightStealth() { return _stealth; }
        public void SetKnightStealth(int stealth) { _stealth = stealth; }

        public int RageKnight(int rageamount)
        {
            const int MaxRageamount = 100;
            if (rageamount <= 0)
            {
                rageamount = (_strength) + (_powerUp * 2);
            }
            else if (rageamount > 0 && rageamount <= 50)
            {
                return rageamount = (_strength + _powerUp / 2);
            }
            else if (rageamount <= MaxRageamount)
            {
                return _stealth = rageamount;
            }
            else
            {
                return rageamount = MaxRageamount;
            }
            return rageamount;
        }
        public int KnockoutSmash()
        {
            return (2 * _strength) + _powerUp;
        }

        public int UnexpectedLuck()
        {
            if (_luck <= 10)
            {
                if (_health <= 10)
                {
                    _health = MaxHealth;
                }
                else if (_health > 10 && _health <= 50)
                {
                    Heal(_luck);
                    _health++;
                }
                else
                {
                    Damage(_luck);
                }
            }
            else
            {
                Heal(_luck);
            }
            return _health;
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
