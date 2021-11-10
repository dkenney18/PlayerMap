using System;
namespace SimpleAdventureGame
{
    public class Item
    {
        public ItemName name;
        public int value;
        public int damage;
        public int amount;
        public Enum hand = Hand.LEFT;
        public ItemTag tag;
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
