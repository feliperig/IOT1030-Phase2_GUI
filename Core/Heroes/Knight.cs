using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    public class Knight : Player
    {
        protected new PlayerName _name = PlayerName.Knight;
        protected new int _strength = 40;
        private new int _powerUp = +20;
        private new int _luck = 10;
        private new int _stealth;
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

        public int Thunderbolt()
        {
            Armour armour = equipItem.Armour;
            bool equiparmour = equipItem.Equip(armour);
            if (equiparmour)
            {
                return _strength += (armour.GetHitpoint() + _powerUp);
            }
            return thunderboltstrike;
        }
        
        public int KnockoutSmash()
        {
            Sword sword = equipItem.Sword;
            bool equipsword = equipItem.Equip(sword);
            if (equipsword)
            {
                return (sword.GetDamage() + _powerUp);
            }
            return Thunderbolt();
        }
        
        public int UnexpectedLuck()
        {
            int min = 0;
            int times = 2;
            if (_luck <= MaxHealth/4 && _luck >= min)
            {
                Map map = equipItem.Map;
                bool equipMap = equipItem.Equip(map);
                if (equipMap)
                {
                    _strength += _strength;
                    _powerUp += _strength;
                    _strength += _powerUp;
                    if(_health <= _luck)
                    {
                        _health += _health;
                    }
                }
                if (!equipMap)
                {
                    return RageKnight(_luck + _luck);
                }
            }
            return (_strength * times);
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
            RagePotion ragepotion = equipItem.RagePotion;
            bool equipRage = equipItem.UseRagePotion();
            if(rageamount <= MaxRageamount && rageamount >= MaxRageamount/2)
            {
                if (PlayerHasItem(ragepotion) || equipRage)
                {  
                    _strength += ragepotion.GetPowerUp();
                    _powerUp += ragepotion.GetPowerUp();
                    return (_powerUp + _strength);
                }
            }
            if (rageamount > 0 && rageamount < MaxRageamount/2)
            {
                if(_health <= rageamount)
                {
                    if(PlayerHasItem(ragepotion) || equipRage)
                    {
                        _health += ragepotion.Getheal();
                    }
                }
                Heal(rageamount);
                return _strength + (_powerUp / 2);
            }
            if (rageamount <= 0)
            {
                return _strength;
            }
            return rageamount;
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
