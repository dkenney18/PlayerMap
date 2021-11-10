namespace SimpleAdventureGame
{
    internal class Food : Item
    {

        public Food(ItemName name, int value, int damage, int amount)
        {
            this.name = name;
            this.value = value;
            this.amount = amount;
            this.damage = damage;
            tag = ItemTag.Food;
        }
    }
}
