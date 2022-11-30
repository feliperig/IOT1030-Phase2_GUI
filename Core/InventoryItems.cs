class InventoryItem
    {
        public InventoryItemEnum _name;
        public string info;                 
        protected int _price;              
        protected readonly int _heal;         
        protected readonly int _damage;
        protected readonly int _powerUp;
        protected readonly int _hitpoint;

        public virtual int GetPrice()
        {
            return _price;
        }

        public virtual int GetDamage()
        {
            return _damage;
        }

        public virtual int GetPowerUp()
        {
            return _powerUp;
        }

        public virtual int Getheal()
        {
            return _heal;
        }

        public virtual int GetHitpoint()
        {
            return _hitpoint;
        }

        public InventoryItem(InventoryItemEnum name, int price, int damage, int powerUp)
        {
            info = "";
            _name = name;
            _price = price;
            _damage = damage;
            _powerUp = powerUp;
        }

        public InventoryItem(InventoryItemEnum name, int price, int hitpoint)
        {
            _name = name;
            _price = price;
            _hitpoint = hitpoint;
        }

        public InventoryItem(int price, InventoryItemEnum name, int heal, int powerUp)
        {
            info = "";
            _name = name;
            _price = price;
            _heal = heal;
            _powerUp = powerUp;
        }
    }

    class Weapon : InventoryItem
    {
        public Weapon(InventoryItemEnum name, int price, int damage, int powerUp) : base(name, price, damage, powerUp) { }

    }

    class Potion : InventoryItem
    {
        public Potion(int price, InventoryItemEnum name, int heal, int powerUp) : base(name, price, heal, powerUp) { }
    }

    class Sword : Weapon
    {
        public Sword() : base(InventoryItemEnum.Sword, 10, 20, +5)
        {
            info = "Magical sword!!! It can be fired Up and used as a Fire Sword.";
        }
        public override int GetPrice() { return _price; }
        public override int GetDamage() { return _damage; }
        public override int GetPowerUp() { return _powerUp; }
        public override string ToString() { return _name.ToString(); }

    }

    class Bow : Weapon
    {
        public Bow() : base(InventoryItemEnum.Bow, 20, 30, +5)
        { }
        public override int GetPrice() { return _price; }
        public override int GetDamage() { return _damage; }
        public override int GetPowerUp() { return _powerUp; }
        public override string ToString() { return _name.ToString(); }
    }

    class MagicStick : Weapon
    {
        public MagicStick() : base(InventoryItemEnum.MagicStick, 20, 10, +2) { }
        public override int GetPrice() { return _price; }
        public override int GetDamage() { return _damage; }
        public override int GetPowerUp() { return _powerUp; }
        public override string ToString() { return _name.ToString(); }

    }
    class HealingPotion : Potion
    {
        public HealingPotion() : base(20, InventoryItemEnum.HealingPotion, 30, 0) { }
        public override int Getheal() { return _heal; }
        public override int GetPrice() { return _price; }
        public override int GetPowerUp() { return _powerUp; }
        public override string ToString() { return _name.ToString(); }
    }

    class RagePotion : Potion
    {
        public RagePotion() : base(25, InventoryItemEnum.RagePotion, 20, +20)
        {
            info = "Heals and 'Boost' player's strength for 20 seconds by improving damage rate per second";
        }
        public override int Getheal() { return _heal; }
        public override int GetPrice() { return _price; }
        public override int GetPowerUp() { return _powerUp; }
        public override string ToString() { return _name.ToString(); }
    }

    class InvisiblePotion : Potion
    {
        public InvisiblePotion() : base(30, InventoryItemEnum.InvisiblePotion, 10, +5)
        {
            info = "Make you invisble for 30 seconds aginst your enemy.";
        }
        public override int Getheal() { return _heal; }
        public override int GetPrice() { return _price; }
        public override int GetPowerUp() { return _powerUp; }
        public override string ToString() { return _name.ToString(); }
    }

    class Shield : InventoryItem
    {
        public Shield() : base(InventoryItemEnum.Shield, 10, 40) { }
        public override int GetPrice() { return _price; }
        public override int GetHitpoint() { return _hitpoint; }
        public override string ToString() { return _name.ToString(); }
    }
    class Map : InventoryItem
    {
        public Map() : base(InventoryItemEnum.Map, 100, 1000, 0)
        {
            info = "Magical Map!!! It can't be destroyed easily and can only read by recieting some magical words. With magical words, It gives you magical path to reach the destination.";
        }
        public override int GetPrice() { return _price; }
        public override int GetDamage() { return _damage; }
        public override int GetPowerUp() { return _powerUp; }
        public override string ToString() { return _name.ToString(); }
    }

    class Armour : InventoryItem
    {
        public Armour(): base(InventoryItemEnum.Armour, 80, 90) { }
        public override int GetPrice() { return _price; }
        public override int GetHitpoint() { return _hitpoint; }
        public override string ToString() { return _name.ToString(); }
    }
