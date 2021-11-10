using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerMap;

namespace SimpleAdventureGame
{
   public  class Smelter
    {
        public Smelting_Recipes Recipes;

        public Smelter(Smelting_Recipes Recipes) 
        {
            this.Recipes = Recipes;
        }

        public void Smelt(Item ore, Player player, int amountToCraft)
        {
            var returnedIem = new Item();
            foreach (KeyValuePair<ItemName, Item> recipes in Recipes.Instance())
            {
                if (recipes.Key.Equals(ore.name) && ore.amount <= amountToCraft) 
                {
                    returnedIem = recipes.Value;
                    ore.amount -= amountToCraft;
                    player.AddItemToBackpack(returnedIem, amountToCraft);
                    return;
                }
            }
        }
    }
}
