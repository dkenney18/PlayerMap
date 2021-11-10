using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerMap;

namespace SimpleAdventureGame
{
   public class Crafter
    {
        private readonly Crafting_Recipes Recipes;

        public Crafter(Crafting_Recipes recipes)
        {
            Recipes = recipes;
        }

        public void Craft(List<Item> items, Player player, int amountToCraft) 
        {
            foreach (var recipes in Recipes.Instance())
            {
                var listOfItemNames = new List<ItemName>();
                recipes.Key.ForEach(item => listOfItemNames.Add(item));

                bool hasTheItems = Enumerable.SequenceEqual(recipes.Key.OrderBy(e => e), listOfItemNames.OrderBy(e => e));
                bool hasTheAmouts = items.All(item => item.amount >= amountToCraft);

                if (hasTheItems && hasTheAmouts)
                {
                    items.ForEach(item => item.amount -= amountToCraft);
                    player.AddItemToBackpack(recipes.Value, amountToCraft);
                    return;
                }
            }
        }
    }
}
