using System;
using System.Collections.Generic;
using SimpleAdventureGame;

namespace PlayerMap
{
    public class WorldMap
    {
        public int max_width;
        public int max_height;
        public int mid_x;
        public int mid_y;
        public Cell[,] cells;
        public static ItemRegistry registry = new ItemRegistry();
        public NPCRegistry npcRegistry = new NPCRegistry();
        public MonsterRegistry monsterRegistry = new MonsterRegistry();
        public Combat combat;

        public static Smelting_Recipes smelting_Recipes = new Smelting_Recipes();
        public static Crafting_Recipes crafting_recipes = new Crafting_Recipes();

        public static Smelter smelter = new Smelter(smelting_Recipes);
        public static Crafter crafter = new Crafter(crafting_recipes);

        public Wander wander = new Wander(registry);

        public static Player player = new Player("#", "Devin", 1000000);

        public SmelterInterface smelterInterface = new SmelterInterface(smelter, player);
        public CrafterInterface crafterInterface = new CrafterInterface(crafter, player);

        public Monster zombie = new Monster("Zombie", 100, new Reward(registry), 10);

        public WorldMap(int width, int height)
        {
            max_width = width;
            max_height = height;
            cells = new Cell[max_width, max_height];
            mid_x = max_width / 2;
            mid_y = max_height / 2;
        }

        public void SetupPlayer()
        {
            player.SetCenter(mid_x, mid_y);
            cells[mid_x, mid_y].ChangeSpace(player.GetPlayerToken());
        }

        public void GenerateMap()
        {
            for (int i = 0; i < max_width; i++)
            {
                for (int j = 0; j < max_height; j++)
                {
                    cells[i, j] = new Cell();
                }
            }

            SetupPlayer();
            Run();
        }

        public void Draw()
        {
            Console.Clear();
            for (int i = 0; i < max_width; i++)
            {
                for (int j = 0; j < max_height; j++)
                {
                    Console.Write(string.Format("{0} ", cells[i, j].GetSpace()));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }


        public void Run()
        {
            //Sets up all the game items in a function
            SetupNPCs();
            SetupMonsters();
            SetUpGameItems(registry);
            SetUpSmeltingRecipes();
            SetUpCraftingRecipes();

            AddItemsToPlayersBackpack();

            player.SetMoney(player.ValueOfBackpack());

            player.SetLeftHandItem(registry.GetItemByName(ItemName.Wood_Sword));
            player.SetRighttHandItem(registry.GetItemByName(ItemName.Wood_Axe));

            combat = new Combat(player, monsterRegistry.GetMonsterByName("Zombie"));
        }

        private void AddItemsToPlayersBackpack()
        {
            player.AddItemToBackpack(registry.GetItemByName(ItemName.Gold_Ore), 1);
            player.AddItemToBackpack(registry.GetItemByName(ItemName.Silver_Ore), 1);
            player.AddItemToBackpack(registry.GetItemByName(ItemName.Bronze_Ore), 1);
            player.AddItemToBackpack(registry.GetItemByName(ItemName.Iron_Ore), 1);
            player.AddItemToBackpack(registry.GetItemByName(ItemName.Copper_Ore), 1);
            player.AddItemToBackpack(registry.GetItemByName(ItemName.Copper_Ore), 1);

            player.AddItemToBackpack(registry.GetItemByName(ItemName.Wood_Axe), 1);
            player.AddItemToBackpack(registry.GetItemByName(ItemName.Wood_Sword), 0);

            player.AddItemToBackpack(registry.GetItemByName(ItemName.Wood), 10);
            player.AddItemToBackpack(registry.GetItemByName(ItemName.Sticks), 10);

            player.AddItemToBackpack(registry.GetItemByName(ItemName.Apple), 4);

        }

        //Add Monsters for combat here
        private void SetupMonsters()
        {
            monsterRegistry.AddMonsterToRegestry(new Monster("Zombie", 100, new Reward(registry), 10));
        }

        //Add NPCs for combat here
        private void SetupNPCs()
        {
            npcRegistry.AddNPCToRegestry(new NPC("!", "Dave", 140));
        }

        //Add Crafing Recipes here
        private static void SetUpCraftingRecipes()
        {
            //Sticks Recipe
            crafting_recipes.AddRecipe(
                new List<ItemName> {
                    ItemName.Wood
                },
                registry.GetItemByName(ItemName.Sticks)
                );

            //Wooden Sword Recipe
            crafting_recipes.AddRecipe(
                new List<ItemName> {
                    ItemName.Sticks,
                    ItemName.Wood,
                    ItemName.Wood
                },
                registry.GetItemByName(ItemName.Wood_Sword)
                );

        }

        //Add Smelting Recipes here
        private static void SetUpSmeltingRecipes()
        {
            smelting_Recipes.AddRecipe(ItemName.Copper_Ore, registry.GetItemByName(ItemName.Copper_Ingot));
            smelting_Recipes.AddRecipe(ItemName.Bronze_Ore, registry.GetItemByName(ItemName.Bronze_Ingot));
            smelting_Recipes.AddRecipe(ItemName.Silver_Ore, registry.GetItemByName(ItemName.Silver_Ingot));
            smelting_Recipes.AddRecipe(ItemName.Gold_Ore, registry.GetItemByName(ItemName.Gold_Ingot));
            smelting_Recipes.AddRecipe(ItemName.Iron_Ore, registry.GetItemByName(ItemName.Iron_Ingot));
            smelting_Recipes.AddRecipe(ItemName.Iron_Ingot, registry.GetItemByName(ItemName.Steel_Ingot));
        }

        //Set up all new items here
        //This is the only place to add or remove items
        //You will also need to add an item name in ItemName.cs
        private static void SetUpGameItems(ItemRegistry registry)
        {

            //Ores
            registry.AddItemToRegestry(new Ore(name: ItemName.Gold_Ore, value: 10, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Ore(name: ItemName.Silver_Ore, value: 5, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Ore(name: ItemName.Bronze_Ore, value: 2, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Ore(name: ItemName.Copper_Ore, value: 1, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Ore(name: ItemName.Iron_Ore, value: 1, damage: 1, amount: 1));

            //Ingots
            registry.AddItemToRegestry(new Ingot(name: ItemName.Gold_Ingot, value: 30, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Ingot(name: ItemName.Silver_Ingot, value: 15, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Ingot(name: ItemName.Bronze_Ingot, value: 6, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Ingot(name: ItemName.Copper_Ingot, value: 3, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Ingot(name: ItemName.Iron_Ingot, value: 3, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Ingot(name: ItemName.Steel_Ingot, value: 3, damage: 1, amount: 1));

            //Wood Weapons
            registry.AddItemToRegestry(new Weapon(name: ItemName.Wood_Sword, value: 1000, damage: 15, amount: 1));
            registry.AddItemToRegestry(new Weapon(name: ItemName.Wood_Axe, value: 500, damage: 5, amount: 1));

            //Copper Weapons
            registry.AddItemToRegestry(new Weapon(name: ItemName.Copper_Sword, value: 1000, damage: 15, amount: 1));
            registry.AddItemToRegestry(new Weapon(name: ItemName.Copper_Axe, value: 500, damage: 5, amount: 1));

            //Bronze Weapons
            registry.AddItemToRegestry(new Weapon(name: ItemName.Bronze_Sword, value: 1000, damage: 15, amount: 1));
            registry.AddItemToRegestry(new Weapon(name: ItemName.Bronze_Axe, value: 500, damage: 5, amount: 1));

            //Silver Weapons
            registry.AddItemToRegestry(new Weapon(name: ItemName.Silver_Sword, value: 1000, damage: 15, amount: 1));
            registry.AddItemToRegestry(new Weapon(name: ItemName.Silver_Axe, value: 500, damage: 5, amount: 1));

            //Gold Weapons
            registry.AddItemToRegestry(new Weapon(name: ItemName.Gold_Sword, value: 1000, damage: 15, amount: 1));
            registry.AddItemToRegestry(new Weapon(name: ItemName.Gold_Axe, value: 500, damage: 5, amount: 1));

            //Iron Weapons
            registry.AddItemToRegestry(new Weapon(name: ItemName.Iron_Sword, value: 1000, damage: 15, amount: 1));
            registry.AddItemToRegestry(new Weapon(name: ItemName.Iron_Axe, value: 500, damage: 5, amount: 1));

            //Steel Weapons
            registry.AddItemToRegestry(new Weapon(name: ItemName.Steel_Sword, value: 1000, damage: 15, amount: 1));
            registry.AddItemToRegestry(new Weapon(name: ItemName.Steel_Axe, value: 500, damage: 5, amount: 1));

            //Foods
            registry.AddItemToRegestry(new Food(name: ItemName.Apple, value: 1, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Food(name: ItemName.Orange, value: 3, damage: 3, amount: 1));
            registry.AddItemToRegestry(new Food(name: ItemName.Mango, value: 5, damage: 5, amount: 1));
            registry.AddItemToRegestry(new Food(name: ItemName.Pear, value: 6, damage: 6, amount: 1));
            registry.AddItemToRegestry(new Food(name: ItemName.Starfruit, value: 10, damage: 10, amount: 1));
            registry.AddItemToRegestry(new Food(name: ItemName.Tomato, value: 2, damage: 2, amount: 1));

            //Items
            registry.AddItemToRegestry(new Item(name: ItemName.Wood, value: 3, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Item(name: ItemName.Sticks, value: 1, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Item(name: ItemName.Stone, value: 1, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Item(name: ItemName.Rock, value: 1, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Item(name: ItemName.Diamond, value: 1000, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Item(name: ItemName.Emerald, value: 500, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Item(name: ItemName.Saphire, value: 700, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Item(name: ItemName.Ruby, value: 600, damage: 1, amount: 1));
            registry.AddItemToRegestry(new Item(name: ItemName.Coal, value: 2, damage: 1, amount: 1));
        }
    }
}
