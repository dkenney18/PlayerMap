using System;
using System.Collections.Generic;
using SimpleAdventureGame;

namespace PlayerMap
{
    public class Player
    {
        public int x;
        public int y;
        public string player_token;
		public string name;
        public int money;
        private readonly Backpack backpack = new();
        public int healthPoints = 1000;
        public int damage;
        public Item leftHand;
        public Item rightHand;
        
        public Player(string p_token, string name, int startingCoins) 
		{
            this.player_token = p_token;
            this.name = name;
            this.money = startingCoins;
            this.damage = 0;
		}
		
		public Player() { }

		
		 public void SetName(string n)
        {
            name = n;
        }

        public void SetHP(int hp) 
        {
            this.healthPoints = hp;
        }

        public int GetHP()
        {
            return this.healthPoints;
        }

        public string GetName() 
        {
            return this.name;
		}

 public void SetMoney(int m)
        {
            money = m;
        }

        public void AddMoney(int m)
        {
            money += m;
        }

        public int GetMoney()
        {
            return money;
        }

        public bool AddItemToBackpack(Item item, int addAmount)
        {
            if (item.value <= money)
            {
                backpack.AddItemToBackpack(item, addAmount);
                return true;
            }
            return false;
        }

        public bool RemoveItemFromBackpack(Item item)
        {
            return backpack.RemoveItemFromBackpack(item);
        }

        public Item GetItemByName(ItemName itemName)
        {
            return backpack.GetItemByName(itemName);
        }

        public Item GetItemByNameFromRegestry(ItemName itemName, ItemRegistry registry)
        {
            return registry.GetItemByName(itemName);
        }

        public int ValueOfBackpack()
        {
            return backpack.CurrentValueOfBackpack();
        }

        public void PrintItemsInBackpack()
        {
            backpack.PrintItems();
        }

        public static void PrintAnItem(Item item)
        {
            Backpack.PrintItem(item);
        }

        public void SetLeftHandItem(Item item)
        {
            this.leftHand = item;
            SetDamage(leftHand);
        }

        public void SetRighttHandItem(Item item)
        {
            this.rightHand = item;
            SetDamage(this.rightHand);
        }

        private void SetDamage(Item item)
        {
            this.damage += item.damage;
        }

        public void Eat(Item food)
        {
            //Console.WriteLine("Player is eating "+ food.name + "For Health " + food.damage);
            this.healthPoints += food.damage;
            food.amount -= 1;
        }

        public void SetCenter(int center_x, int center_y)
        {
            x = center_x;
            y = center_y;
        }

        public string GetPlayerToken()
        {
            return player_token;
        }

        public void Move(WorldMap map, Cell[,] cells)
        {
            string ans;
            do
            {
                ans = Console.Read().ToString().Trim().ToLower();

                switch (ans)
                {
                    // w
                    case "119":
                        MoveUp(cells, map);
                        break;

                    // s
                    case "115":
                        MoveDown(cells, map);
                        break;

                    // a
                    case "97":
                        MoveLeft(cells, map);
                        break;

                    // d
                    case "100":
                        MoveRight(cells, map);
                        break;

                    // m
                    case "109":
                        Mine(cells);
                        break;

                    // i
                    case "105":
                        PrintInventory();
                        break;

                    // f for smelter (furnace)
                    case "102":
                        map.smelterInterface.RunSmelterInterface();
                        break;

                    default:
                        break;
                }

                map.Draw();

                // 113 = "q"
            } while (ans != "113");
        }

        public void PrintInventory() 
        {
            PrintItemsInBackpack();
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }

        public void Mine(Cell[,] cells)
        {
            var item = cells[x, y].prev_space;

            if (!item.ToString().Equals(" "))
            {
                var fullNameAsString = ConvertItemToFullName(item);
                var itemNameEnum = ConvertStringToEnum(fullNameAsString);
                var minedItem = GetItemByNameFromRegestry(itemNameEnum, WorldMap.registry);
                this.AddItemToBackpack(minedItem, 1);
                cells[x, y].ChangeSpace(player_token);
                cells[x, y].prev_space = " ";
            }
        }

        private static string ConvertItemToFullName(string item)
        {
            var names = Enum.GetNames(typeof(Blocks));
            foreach (var i in names)
            {
                if (i.Substring(0,2) == item)
                {
                    return i.ToString();
                }
            }
            return "";
        }

        private static ItemName ConvertStringToEnum(string itemName)
        {
            return (ItemName)Enum.Parse(typeof(ItemName), itemName);
        }

        public void MoveUp(Cell[,] cells, WorldMap map)
        {
            var i = CalulateXAndY(x, y, map).X;
            var j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            x -= 1;

            i = CalulateXAndY(x, y, map).X;

            x = i;

            cells[i, j].ChangeSpace(player_token);
        }

        public void MoveDown(Cell[,] cells, WorldMap map)
        {

            var i = CalulateXAndY(x, y, map).X;
            var j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            x += 1;
             
            i = CalulateXAndY(x, y, map).X;

            x = i;

            cells[i, j].ChangeSpace(player_token);
        }

        public void MoveLeft(Cell[,] cells, WorldMap map)
        {
            var i = CalulateXAndY(x, y, map).X;
            var j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            y -= 1;

            j = CalulateXAndY(x, y, map).Y;

            y = j;

            cells[i, j].ChangeSpace(player_token);
        }

        public void MoveRight(Cell[,] cells, WorldMap map)
        {
            var i = CalulateXAndY(x, y, map).X;
            var j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            y += 1;

            j = CalulateXAndY(x, y, map).Y;

            y = j;

            cells[i, j].ChangeSpace(player_token);
        }

        public static Points CalulateXAndY(int x, int y, WorldMap map)
        {
            var i = x - (int)((map.max_width * Math.Floor((double)x / map.max_width)));
            var j = y - (int)((map.max_height * Math.Floor((double)y / map.max_height)));
            return new Points() { X = i, Y = j };
        }

    }
}
