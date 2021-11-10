namespace SimpleAdventureGame
{
    internal class Weapon : Item
    {
        public bool canDualWield = false;

        public Weapon(ItemName name, int value, int damage, int amount)
        {
            this.name = name;
            this.value = value;
            this.amount = amount;
            this.damage = damage;
            tag = ItemTag.Weapon;
        }
    }
}
