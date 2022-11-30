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
        
        public int DeathMatch()
        {
            Bow bow = equipItem.Bow;
            bool equipbow = equipItem.Equip(bow);
            if (equipbow)
            {
                return (_strength) + bow.GetDamage();
            }
            if (!equipbow)
            {
                equipbow = equipItem.Equip(bow);
                return (_strength) + bow.GetDamage();
            }
            return _strength + bow.GetDamage();
        }
        
        public int Ragequeen(int amount)
        {
            RagePotion ragePotion = equipItem.RagePotion;
            bool equipRage = equipItem.UseRagePotion();
            const int Maxamount = 100;
            int min = 0;
            if (amount <= min)
            {
                Console.WriteLine("Can't Rage the queen with rageamout");
            }
            if (amount > min && amount <= Maxamount / 2)
            {
                if (equipRage || Hit)
                {
                    Hit = false;                  // Hit needs to beed implemented in monster class. It is just an idea.
                    _strength += ragePotion.GetPowerUp();
                    _stealth += amount;
                    _luck += amount;
                    return _health += ragePotion.Getheal();
                }
                return NormalAttack();
            }
            if (amount > (Maxamount / 2))
            {
                if (amount > Maxamount)
                {
                    if (equipRage || Hit)
                    {
                        Console.WriteLine($"Rageamount can't be greater than {Maxamount}. Changing entered rageamount '{amount} to {Maxamount}");
                        amount = Maxamount;
                        Hit = false;                  // Hit needs to beed implemented in monster class. It is just an idea.
                        _strength = (amount / 2) + ragePotion.GetPowerUp();
                        _powerUp = (amount / 2) + ragePotion.GetPowerUp();
                        _stealth += (amount / 2);
                        _luck += (amount / 2);
                        return _health += ragePotion.Getheal();
                    }
                    return NormalAttack();
                }
                if (amount <= Maxamount)
                {
                    if (equipRage || Hit)
                    {
                        Hit = false;                  // Hit needs to beed implemented in monster class. It is just an idea.
                        _strength += ragePotion.GetPowerUp();
                        _powerUp += ragePotion.GetPowerUp();
                        _stealth += amount;
                        _luck += amount;
                        Heal(amount);
                        return DeathMatch();
                    }
                    return NormalAttack();
                }
            }
            return DeathMatch();
        }

        public override int NormalAttack()
        {
            return _strength + _powerUp;
        }
        
        public void Luck(InvisiblePotion invisiblepotion)
        {
            int min = 0;
            int max = 100;
            if (PlayerHasItem(invisiblepotion))
            {
                Console.WriteLine("Press 'I' on Keypad to use invisible spell and protect your Queen");
                if(Console.ReadKey().Key == ConsoleKey.I)
                {
                    if(_luck >= max / 2 && Hit == true)
                    {
                        Hit = false;
                        Damage(min);
                        Defend();
                        if(_health < _luck)
                        {
                            Heal(_luck);
                        }
                    }
                    if(_luck >= max / 2)
                    {
                        Hit = false;                // This need to be implemented in monster class
                        _strength += _strength;
                        _powerUp += invisiblepotion.GetPowerUp();
                        _strength = max;
                        Damage(min);   
                    }
                    if(_luck < max/2 && _luck > 0)
                    {
                        Heal(_luck);
                        Damage(min);
                        for (int i = 0; i < _luck; i++)
                        {
                            _strength++;
                        }
                    }
                    _strength += invisiblepotion.GetPowerUp();
                }
                if(Console.ReadKey().Key != ConsoleKey.I)
                {
                    Console.WriteLine("Invisible Potion not equipped.");
                }
            }
            if (!PlayerHasItem(invisiblepotion))
            {
                Console.WriteLine("You need equip invisible potion to make your luck workable");
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
