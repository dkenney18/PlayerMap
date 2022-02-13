using System.Collections.Generic;

namespace SimpleAdventureGame
{
    public class Crafting_Recipes
    {
        private readonly Dictionary<List<ItemName>, Item> Recipes;

        public Crafting_Recipes()
        {
            Recipes = new Dictionary<List<ItemName>, Item>();
        }

        public void AddRecipe(List<ItemName> inputs, Item output)
        {
            Recipes.Add(inputs, output);
        }

        public void RemoveRecipe(List<ItemName> inputs)
        {
            Recipes.Remove(inputs);
        }

        public Dictionary<List<ItemName>, Item> Instance()
        {
            return Recipes;
        }
    }
}
