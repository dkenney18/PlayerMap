using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAdventureGame;

namespace PlayerMap
{
    public class CrafterInterface
    {
        public Crafter crafter;
        public Player player;
        private readonly Dictionary<int, Dictionary<List<ItemName>, Item>> crafterOptions = new Dictionary<int, Dictionary<List<ItemName>, Item>>();
        public CrafterInterface(Crafter crafter, Player Player)
        {
            this.crafter = crafter;
            player = Player;
        }

        public void CreateSmelterOptions()
        {
            int count = 1;
            foreach (KeyValuePair<List<ItemName>, Item> recipes in crafter.Recipes.Instance())
            {
                if (CanICraft(craftingRecipes: recipes.Key, displayMode: false))
                {
                    try
                    {
                        Dictionary<List<ItemName>, Item> tempdic = new Dictionary<List<ItemName>, Item>
                        {
                            { recipes.Key, recipes.Value }
                        };
                        crafterOptions.Add(count, tempdic);
                        count++;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }

        public void RunCrafterInterface()
        {
            ConsoleKeyInfo ans;

            CreateSmelterOptions();

            do
            {
                //print the options
                foreach (KeyValuePair<int, Dictionary<List<ItemName>, Item>> craftable in crafterOptions)
                {
                    Console.WriteLine("Enter: " + craftable.Key + " to craft " + DisplayListItems(craftable.Value.Keys.First()) + " => " + craftable.Value.Values.First().name + " This costs: " + craftable.Value.Values.First().value);
                }

                Console.WriteLine("Enter q to go back to previous screen");

                ans = Console.ReadKey();

                //craft the right option
                foreach (KeyValuePair<int, Dictionary<List<ItemName>, Item>> craftable in crafterOptions)
                {
                    
                    if (ans.KeyChar.ToString() == craftable.Key.ToString())
                    {
                        List<Item> items = new List<Item>();
                        var names = craftable.Value.Keys.First().ToList();
                        names.ForEach(item => items.Add(player.GetItemByName(item)));
                        crafter.Craft(items, player, 1);
                    }
                }
                //clear the console to make it neat
                Console.Clear();

                //113 = q for quit
            } while (ans.KeyChar != 'q');
        }

        public string DisplayListItems(List<ItemName> names)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var name in names)
            {
                stringBuilder.Append(" " + name + "<" + player.GetItemByName(name).amount + ">");
            }

            return stringBuilder.ToString();
        }

        public bool CanICraft(List<ItemName> craftingRecipes, bool displayMode)
        {
            List<ItemName> playerItemNames = new List<ItemName>();
            Dictionary<ItemName, int> itemAmounts = new Dictionary<ItemName, int>();
            player.backpack.items.ForEach(item => playerItemNames.Add(item.name));
            player.backpack.items.ForEach(item => itemAmounts.Add(item.name, item.amount));

            var result = from a in craftingRecipes
                     join b in playerItemNames on a.ToString().ToLower() equals b.ToString().ToLower()
                     select a;
            bool hasTheItems = result.ToList().Count != 0;
            bool hasTheAmouts = playerItemNames.All(item => CheckIfIHaveEnough(item, itemAmounts));

                if (hasTheItems && hasTheAmouts)
                {
                    return true;
                }
            return false;
            }

        private bool CheckIfIHaveEnough(ItemName item, Dictionary<ItemName, int> itemsAndAmounts)
        {
            List<Item> playerItems = new List<Item>();
            player.backpack.items.ForEach(it => playerItems.Add(it));
            foreach (KeyValuePair<ItemName, int> items in itemsAndAmounts)
            {
                if (item == items.Key && playerItems.Contains(player.GetItemByName(item)) && player.GetItemByName(item).amount >= items.Value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
