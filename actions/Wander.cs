using System;
using PlayerMap;

namespace SimpleAdventureGame
{
    public class Wander
    {
        public ItemRegistry ItemRegistry { get; set; }
        public Wander(ItemRegistry itemRegistry)
        {
            ItemRegistry = itemRegistry;
        }

        public void Forage(Player player)
        {
            Random random = new Random();
            Item foundItem = Utility.GetRandomFoodItem(ItemRegistry);

            foundItem.amount = random.Next(1, 10);

            player.AddItemToBackpack(foundItem, foundItem.amount);

            Console.WriteLine("Found: " + foundItem.name + "\n" + "And added: " + foundItem.amount + " To " + player.name + "'s backpack");

            player.SetMoney(player.ValueOfBackpack());
        }

        public void Mine(Player player)
        {
            Random random = new Random();
            Item foundItem = Utility.GetRandomOreItem(ItemRegistry);

            foundItem.amount = random.Next(1, 10);

            player.AddItemToBackpack(foundItem, foundItem.amount);

            //Console.WriteLine("Found: " + foundItem.name + "\n" + "And added: " + foundItem.amount + " To " + player.name + "'s backpack");

            player.SetMoney(player.ValueOfBackpack());
        }
    }
}
