using System;
namespace SimpleAdventureGame
{
    public class Item
    {
        public ItemName name { get; set; }
        public int value { get; set; }
        public int damage { get; set; }
        public int amount { get; set; }
        public Enum hand = Hand.LEFT;
        public ItemTag tag { get; set; }
        public Item(ItemName name, int value, int damage, int amount)
        {
            this.name = name;
            this.value = value;
            this.amount = amount;
            this.damage = damage;
            tag = ItemTag.Item;
        }

        public Item() { }
    }
}
