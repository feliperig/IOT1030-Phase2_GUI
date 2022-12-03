namespace IOT1030_Phase2_GUI.Core.Inventory
{
    public abstract class Item
    {
        /// <summary>
        /// The name of the item
        /// </summary>
        protected string _name;
        public string Name { get { return _name; } }

        /// <summary>
        /// The type of the item
        /// </summary>
        protected ItemType _type;
        public ItemType Type { get { return _type;} }
    }

    /// <summary>
    /// Enum for all item types
    /// </summary>
    public enum ItemType
    {
        Item,
        Weapon,
        Armour
    }
}
