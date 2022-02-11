//Devin Kenney
//SQA Test Analyst
//Publix Supermarkets
//Phone number: 863-999-2432
using System.Collections.Generic;
using System.Linq;
using PlayerMap;

namespace SimpleAdventureGame
{
    public class Crafter
    {
        public Crafting_Recipes Recipes;

        public Crafter(Crafting_Recipes recipes)
        {
            Recipes = recipes;
        }

        public void Craft(List<Item> items, Player player, int amountToCraft)
        {
            foreach (KeyValuePair<List<ItemName>, Item> recipes in Recipes.Instance())
            {
                List<ItemName> listOfItemNames = new List<ItemName>();
                recipes.Key.ForEach(item => listOfItemNames.Add(item));

                try
                {
                    bool hasTheAmounts = items.All(item => item.amount >= amountToCraft);
                    bool hasTheMoney = player.GetMoney() >= recipes.Value.value;
                    bool hasTheItems = Enumerable.SequenceEqual(recipes.Key.OrderBy(e => e), listOfItemNames.OrderBy(e => e));

                    if (hasTheItems && hasTheAmounts && hasTheMoney && items.All(item => listOfItemNames.Contains(item.name)))
                    {
                        items.ForEach(item => item.amount -= amountToCraft);
                        player.AddItemToBackpack(recipes.Value, amountToCraft);
                        return;
                    }
                }
                catch (System.Exception)
                {
                    Craft(items, player, amountToCraft);
                }
            }
        }
    }
}