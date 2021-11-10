using System;
using System.Collections.Generic;

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
            var random = new Random();
            var foundItem = Utility.GetRandomItem(ItemRegistry);

            foundItem.amount = random.Next(1,5);

            return foundItem;
        }
    }
}