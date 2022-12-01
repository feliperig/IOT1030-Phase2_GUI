using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Inventory
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
    }
}
