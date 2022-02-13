using System;

namespace SimpleAdventureGame
{
    internal class Utility
    {
        public static Item GetRandomItem(ItemRegistry itemRegistry)
        {
            Random random = new Random();
            return itemRegistry.Items()[random.Next(itemRegistry.Items().Count)];
        }

        public static Item GetRandomFoodItem(ItemRegistry itemRegistry)
        {
            while (true)
            {
                Random random = new Random();
                Item item = itemRegistry.Items()[random.Next(itemRegistry.Items().Count)];
                if (item.tag == ItemTag.Food)
                {
                    return item;
                }
            }
        }

        public static Item GetRandomOreItem(ItemRegistry itemRegistry)
        {
            while (true)
            {
                Random random = new Random();
                Item item = itemRegistry.Items()[random.Next(itemRegistry.Items().Count)];
                if (item.tag == ItemTag.Ore)
                {
                    return item;
                }
            }
        }
    }
}
