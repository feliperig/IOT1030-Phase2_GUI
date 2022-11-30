using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core.Heroes
{
    class Inventory
    {
        private List<InventoryItem> itemsList = new List<InventoryItem>();
        
        public bool HasMap()
        {
            foreach (InventoryItem item in itemsList)
            {
                if (item._name.Equals(InventoryItemEnum.Map))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasSword()
        {
            foreach (InventoryItem item in itemsList)
            {
                if (item._name.Equals(InventoryItemEnum.Sword))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddItem(InventoryItem item)
        {
            itemsList.Add(item);
        }

        public bool ItemInInventory(InventoryItem item)
        {
            foreach (InventoryItem element in itemsList)
            {
                if (element._name.Equals(item._name))
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveItem(InventoryItem item)
        {
            bool check = false;
            int index = -1;
            foreach (var elements in itemsList)
            {
                if (elements._name == (item._name))
                {
                    check = true;
                }
            }
            if (check)
            {
                for (int i = 0; i < itemsList.Count; i++)
                {
                    if (itemsList[i]._name == (item._name))
                    {
                        index = i;
                    }
                }
                itemsList.RemoveAt(index);
            }
        }

        public override string ToString()
        {
            string ret = " ";
            foreach (var item in itemsList)
            {
                ret = ret + item.ToString();
            }
            return ret;
        }
    }

    enum InventoryItemEnum { Sword, Bow, Shield, HealingPotion, RagePotion, InvisiblePotion, Map, Armour, MagicStick }
}
