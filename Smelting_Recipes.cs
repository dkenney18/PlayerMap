using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdventureGame
{
    public class Smelting_Recipes
    {
        private readonly Dictionary<ItemName, Item> Recipes;

        public Smelting_Recipes() {
            Recipes = new Dictionary<ItemName, Item>();
        }

        public void AddRecipe(ItemName input, Item output) 
        {
            Recipes.Add(input, output);
        }

        public void RemoveRecipe(ItemName input)
        {
            Recipes.Remove(input);
        }

        public Dictionary<ItemName, Item> Instance() 
        {
            return Recipes;
        }
    }
}
