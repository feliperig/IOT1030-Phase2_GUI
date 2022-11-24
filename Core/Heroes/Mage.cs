using System;
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
        private List<string> _attacks = new List<string>()
        {
            "Normal Attack",
            "One Time Ability",
            "Mage Protection",
            "Rage Mage"
        };
        private List<string> _attacksDescription = new List<string>()
        {
            "Simple attack with equipped weapon",
            "Mage special sorcery, available only once",
            "Mage protects himself from damage",
            "Mage enrages"
        };

        public Mage(List<int> stats, string heroName) : base(stats, PlayerName.Mage, heroName) { }
        //public Mage() : base(PlayerName.Mage) { }

        public PlayerName GetMageName() { return _name; }
        public int GetMageStrength() { return _strength; }
        public void SetMageStrength(int strength) { _strength = strength; }
        public int GetMagePower() { return _powerUp; }
        public void SetMagePower(int powerUp) { _powerUp = powerUp; }
        public int GetMageLuck() { return _luck; }
        public void SetMageLuck(int luck) { _luck = luck; }
        public int GetMageStealth() { return _stealth; }
        public void SetMageStealth(int stealth) { _stealth = stealth; }

        protected override int NormalAttack()
        {
            return _strength;
        }

        public int OneTimeAbility()
        {
            if (_health <= 0)
            {
                _health = MaxHealth;
            }
            return MaxHealth;
        }

        public int MageProtection()
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
                    Heal(10);
                    _health++;
                }
                return _strength = (8 * _strength) + _powerUp;
            }
            else
            {
                Damage(_luck / 20);
            }
            return _health = (_luck + 20);
        }

        public int RageMage(int amount)
        {
            const int Maxamount = 100;
            if (amount <= 0)
            {
                amount = (Maxamount / 10);
                Heal(amount);
                return (3 * NormalAttack());
            }
            else if (amount > 0 && amount <= 50)
            {
                _stealth = MageProtection();
                return _stealth;
            }
            else
            {
                return OneTimeAbility();
            }
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
