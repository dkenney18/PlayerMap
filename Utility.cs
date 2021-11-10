using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdventureGame
{
    class Utility
    {
        public static Item GetRandomItem(ItemRegistry itemRegistry) 
        {
            var random = new Random();
            return itemRegistry.Items()[random.Next(itemRegistry.Items().Count)];
        }

        public static Item GetRandomFoodItem(ItemRegistry itemRegistry)
        {
            while (true) 
            {
                var random = new Random();
                var item = itemRegistry.Items()[random.Next(itemRegistry.Items().Count)];
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
                var random = new Random();
                var item = itemRegistry.Items()[random.Next(itemRegistry.Items().Count)];
                if (item.tag == ItemTag.Ore)
                {
                    return item;
                }
            }
        }
    }
}
