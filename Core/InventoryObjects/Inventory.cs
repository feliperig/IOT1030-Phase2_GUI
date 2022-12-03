using System.Collections.Generic;

namespace IOT1030_Phase2_GUI.Core.InventoryObjects
{
    public class Inventory
    {
        /// <summary>
        /// The max amount of items that this inventory can hold
        /// </summary>
        protected int _maxItems;
        public int MaxItems { get { return _maxItems; } }

        /// <summary>
        /// The items in the inventory
        /// </summary>
        protected List<Item> _items;
        public List<Item> Items { get { return _items; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory"/> class.
        /// </summary>
        /// <param name="maxItems">The max amount of items this inventory can hold.</param>
        public Inventory(int maxItems)
        {
            _maxItems = maxItems;
            _items = new List<Item>();
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>False if inventory full</returns>
        public bool AddItem(Item item)
        {
            if (Items.Count >= MaxItems)
                return false;
            
            _items.Add(item);
            return true;
        }

        /// <summary>
        /// Removes the item at the selected index
        /// </summary>
        /// <param name="index">The index.</param>
        public void RemoveItem(int index) 
        {
            if (index > _items.Count - 1)
                return;

            _items.RemoveAt(index);
        }

        /// <summary>
        /// Equips the item from the selected index if it's a weapon
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The weapon to equip, null if not a weapon</returns>
        public Weapon EquipWeapon(int index)
        {
            if (_items[index].Type != ItemType.Weapon)
                return null;

            Weapon weaponToEquip = (Weapon)_items[index];
            _items.RemoveAt(index);
            return weaponToEquip;
        }

        /// <summary>
        /// Equips the item from the selected index if it's an armour
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The armour to equip, null if not an armour</returns>
        public Armour EquipArmour(int index)
        {
            if (_items[index].Type != ItemType.Armour)
                return null;

            Armour armourToEquip = (Armour)_items[index];
            _items.RemoveAt(index);
            return armourToEquip;
        }
    }
}
