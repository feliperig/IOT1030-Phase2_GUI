using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    public class Player
    {
        protected readonly Inventory inventory = new();     // Player inventory
        protected readonly EquipItems equipItem = new();
        protected const int MaxHealth = 100;
        protected static int _health = MaxHealth;
        protected List<int> _stats;
        protected bool hit = true;
        protected bool _hasMap = true;
        protected bool _hasSword = false;
        public Location Location { get; set; }
        protected string _characterName;
        public Player(Location start, int herogold)
        {
            Location = start;
            _herogold = herogold;

        }
        protected PlayerName _characterClass;
        protected List<string> _attacks = new List<string>()
        {
            "Normal Attack",
            "One Time Ability",
            "Player Protection",
            "Rage Player"
        };
        protected List<string> _attackDescriptions = new List<string>()
        {
            "Simple attack with equipped weapon",
            "Player special sorcery, available only once",
            "Player protects himself from damage",
            "Player enrages"
        };   

        /*****************************************************
           * Needs to be adjusted when Monster class is made.
           * When monster hit the hero player will take the damage.
         *****************************************************/
        public bool Hit
        {
            get { return hit; }
            protected set { hit = value; }
        }

        public bool HasMap
        {
            get => inventory.HasMap();
            set => _hasMap = value;
        }

        public bool HasSword
        {
            get => inventory.HasSword();
            set => _hasSword = value;
        }

        protected void Defend()
        {
            int crit = 10;
            if(_health < crit)
            {
                for(int i = 0; i < MaxHealth/5; i++)
                {
                    Damage(0);
                }
            }
        }

        /// <summary>
        /// Heal the health
        /// </summary>
        /// <param name="amount"> amount with which health can be increased </param>
        protected void Heal(int amount)
        {
            _health += amount;
            if (_health > MaxHealth)
            {
                _health = MaxHealth;
            }
        }
        
        public virtual int NormalAttack()
        {
            Bow bow = new();
            Sword sword = new();
            MagicStick magicStick = new();
            bool swordequipped = equipItem.Equip(sword);
            bool bowequipped = equipItem.Equip(bow);
            bool magicstickequipped = equipItem.Equip(magicStick);
            if (swordequipped)
            {
                sword = equipItem.Sword;
                return sword.GetDamage() + _strength;
            }
            else if (bowequipped)
            {
                bow = equipItem.Bow;
                return bow.GetDamage() + _strength;
            }
            else if (magicstickequipped)
            {
                magicStick = equipItem.MagicStick;
                return magicStick.GetDamage() + _strength;
            }
            else
            {
                return _strength + _powerUp;
            }
        }

        /// <summary>
        /// Decreases the health
        /// </summary>
        /// <param name="amount"> amount with which health can be decreased </param>
        protected void Damage(int amount)
        {
            _health -= amount;
            if (_health < 0)
            {
                _health = 0;
            }
        }
        
        protected void DamagedWeapon(int amount, InventoryItem item)
        {
            int damagedweapon = item.GetHitpoint();
            int damagedweaponhitpoint = 0;
            damagedweapon -= amount;
            if(damagedweapon <= damagedweaponhitpoint && Hit)
            {
                _health -= amount;
                _health--;
                if(_health < damagedweaponhitpoint)
                {
                    Kill("Weapon got damaged and you wasn't able to save yourself.");
                }
            }
        }  

        public void ItemAdd(InventoryItem item) { inventory.AddItem(item); }
        
        public void UpdateGold(int availablegold) => _herogold += availablegold;
 
        public void ItemRemove(InventoryItem item) => inventory.RemoveItem(item);

        public bool PlayerHasItem(InventoryItem item) { return inventory.ItemInInventory(item); }
        
        public Player(List<int> stats, PlayerName playerClass, string name) 
        { 
            _stats = stats;
            _characterClass = playerClass;
            _characterName = name;
        }

        public List<string> GetAttackNames()
        {
            return _attacks;
        }

        public List<string> GetAttackDescriptions()
        {
            return _attackDescriptions;
        }
        
        public string CauseOfDeath { get; private set; }
        
        public void Kill(string cause)
        {
            _health = 0;
            CauseOfDeath = cause;
        }
        public Player(Location start) { Location = start; }
    }
    public record Location(int Row, int Column);

    public enum PlayerName { King, Queen, Knight, Mage, Player, Archer };
}

