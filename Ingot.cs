namespace SimpleAdventureGame
{
    internal class Ingot : Item
    {

        public Ingot(ItemName name, int value, int damage, int amount)
        {
            this.name = name;
            this.value = value;
            this.amount = amount;
            this.damage = damage;
            tag = ItemTag.Ingot;
        }
    }
}
