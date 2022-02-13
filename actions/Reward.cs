using System;

namespace SimpleAdventureGame
{
    public class Reward
    {
        //private readonly List<Item> rewards = new List<Item>();
        public ItemRegistry ItemRegistry { get; set; }
        public Reward(ItemRegistry itemRegistry)
        {
            ItemRegistry = itemRegistry;
        }

        public Item GiveReward()
        {
            Random random = new Random();
            Item foundItem = Utility.GetRandomItem(ItemRegistry);

            foundItem.amount = random.Next(1, 5);

            return foundItem;
        }
    }
}