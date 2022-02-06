namespace SimpleAdventureGame
{
    internal class Ore : Item
    {
        public Ore(ItemName name, int value, int damage, int amount)
        {
            this.name = name;
            this.value = value;
            this.amount = amount;
            this.damage = damage;
            tag = ItemTag.Ore;
        }
    }
}
