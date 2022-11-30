using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    class Mage : Player
    {
        private List<Player> players = new();
        private new PlayerName _name = PlayerName.Mage;
        private new int _strength = 8;
        private new int _powerUp = +6;
        private new int _luck = 80;
        private new int _stealth;

        public Mage() : base(new Location(0, 0), 500) 
        {
            inventory.AddItem(new MagicStick());
            players.Add(new King());
            players.Add(new Queen());
            players.Add(new Knight());
        }

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
                if(equipItem.Armour != null)
                {
                    Console.WriteLine("Would you like to use heal hero to full health or defend/tolerate against the attack?");
                    Console.WriteLine("Press 0 to defend/tolerate or H to use max health ability");
                    if(Console.ReadKey().Key == 0)
                    {
                        for(int i = 0; i < MaxHealth/2; i++)
                        {
                            Damage(0);
                            _health++;
                        }
                    }
                    if(Console.ReadKey().Key == ConsoleKey.H)
                    {
                        _health = MaxHealth;
                    }
                }
            }
            return _health;
        }
        
        public void MageProtection(Player player)
        {
            var random = new Random();
            int index = random.Next(players.Count);
            if(index == 0 || index == 1 || index == 3)
            {
                _strength += player.GetStrength();
                _powerUp += player.GetPower();
                _luck += player.GetLuck();
                _stealth += player.GetStealth();
                _health += _health;
            }
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
        
        public int RageMage(int amount, Player player)
        {
            const int Maxamount = 100;
            if (amount <= Maxamount && amount > Maxamount/2)
            {
                Heal(amount);
                MageProtection(player);
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
            MagicStick magicStick = null;
            bool equipmagicStick = equipItem.MagicStickEquipped();
            if (equipmagicStick)
            {
                magicStick = equipItem.MagicStick;
                return magicStick.GetDamage() + _strength;
            }
            magicStick = equipItem.MagicStick;
            return magicStick.GetDamage() + (_strength * magicStick.GetPowerUp());
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
