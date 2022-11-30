﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    class Mage : Player
    {
        private PlayerName _name = PlayerName.Mage;
        private int _strength = 8;
        private int _powerUp = +6;
        private int _luck = 80;
        private int _stealth;

        //public Mage() : base(new Location(0, 0), 500) { inventory.AddItem(new MagicStick()); }

        public Mage(List<int> stats, string heroName) : base(stats, PlayerName.Mage, heroName) 
        {
            _attacks = new List<string>()
            {
                "Normal Attack",
                "One Time Ability",
                "Mage Protection",
                "Rage Mage"
            };
            _attackDescriptions = new List<string>()
            {
                "Simple attack with equipped weapon",
                "Mage special sorcery, available only once",
                "Mage protects himself from damage",
                "Mage enrages"
            };
        }
        //public Mage() : base(PlayerName.Mage) { }

       public int OneTimeAbility()
        {
            int criticalhealth = 10;
            if (_health <= criticalhealth)
            {
                _health = MaxHealth;  
            }
            return _health;
        }
        
        public void MageProtection()
        {
            int multiplier = 2;
            if (_luck >= MaxHealth / multiplier)
            {
                if (_health <= MaxHealth / multiplier)
                {
                    Heal(MaxHealth / multiplier);
                    Defend();
                }
                _strength =  (multiplier * multiplier * multiplier * _strength) + _powerUp;
            }
        }
        
        public int RageMage(int amount)
        {
            const int Maxamount = 100;
            if (amount <= Maxamount && amount > Maxamount/2)
            {
                Heal(amount);
                MageProtection();
                return NormalAttack();
            }
            if (amount > Maxamount/10 && amount <= Maxamount/2)
            {
                Heal(amount);
                return _stealth = _luck;
            }
            else
            {
                return OneTimeAbility();
            }
        }
        
        public override int NormalAttack()
        {
            return (_strength + _powerUp);
        }
       
        public override string ToString()
        {
            string ret = "The Mage radiates the health boosting Aura that improves with every level. All attacks and defences will get increased damage.\n";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(ret);
            Console.ResetColor();
            Console.WriteLine($"Hero '{_name}' has the following stats: \n\t Strength \t => {_strength} \n\t PowerUp \t => +{_powerUp} \n\t Luck     \t => {_luck} \n\t Stealth \t => {_stealth}");
            return ret;
        }
    }
}
