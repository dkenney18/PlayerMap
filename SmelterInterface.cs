using System;
using System.Collections.Generic;
using System.Linq;
using SimpleAdventureGame;

namespace PlayerMap
{
    public class SmelterInterface
    {
        public Smelter smelter;
        public Player player;
        private readonly Dictionary<int, Dictionary<ItemName, Item>> smelterOptions = new Dictionary<int, Dictionary<ItemName, Item>>();
        public SmelterInterface(Smelter smelter, Player Player)
        {
            this.smelter = smelter;
            player = Player;
        }

        public void CreateSmelterOptions()
        {
            int count = 1;
            foreach (KeyValuePair<ItemName, Item> recipes in smelter.Recipes.Instance())
            {
                if (CanISmelt(recipes.Key))
                {
                    try
                    {
                        Dictionary<ItemName, Item> tempdic = new Dictionary<ItemName, Item>
                        {
                            { recipes.Key, recipes.Value }
                        };
                        smelterOptions.Add(count, tempdic);
                        count++;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }

        public void RunSmelterInterface()
        {
            string ans;

            CreateSmelterOptions();

            do
            {
                //print the options
                foreach (KeyValuePair<int, Dictionary<ItemName, Item>> smeltable in smelterOptions)
                {
                    Console.WriteLine("Enter: " + smeltable.Key + " to smelt " + smeltable.Value.Keys.First() + " => " + smeltable.Value.Values.First().name);
                }

                Console.WriteLine("Enter q to go back to previous screen");

                ans = Console.Read().ToString().Trim().ToLower();

                //smelt the right option
                foreach (KeyValuePair<int, Dictionary<ItemName, Item>> smeltable in smelterOptions)
                {
                    bool res = int.TryParse(ans, out int number);
                    string result = char.ConvertFromUtf32(number);
                    if (result == smeltable.Key.ToString())
                    {
                        Item item = player.GetItemByName(smeltable.Value.Keys.First());
                        smelter.Smelt(item, player, 1);
                    }
                }
                //clear the console to make it neat
                Console.Clear();

                //113 = q for quit
            } while (ans != "113");
        }

        public bool CanISmelt(ItemName oreName)
        {
            if (player.GetItemByName(oreName) != null)
            {
                return true;
            }
            return false;
        }
    }
}
