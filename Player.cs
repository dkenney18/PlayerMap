using System;
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
        public Backpack backpack = new();
        public int healthPoints = 1000;
        public int damage;
        public Item leftHand;
        public Item rightHand;
        private bool firstTime = true;

        public Player(string p_token, string name, int startingCoins)
        {
            player_token = p_token;
            this.name = name;
            money = startingCoins;
            damage = 0;
        }

        public Player() { }


        public void SetName(string n)
        {
            name = n;
        }

        public void SetHP(int hp)
        {
            healthPoints = hp;
        }

        public int GetHP()
        {
            return healthPoints;
        }

        public string GetName()
        {
            return name;
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

        public void PrintItemsInBackpack_Detailed()
        {
            backpack.PrintItemsWithDetails();
        }

        public static void PrintAnItem(Item item)
        {
            Backpack.PrintItem(item);
        }

        public void SetLeftHandItem(Item item)
        {
            leftHand = item;
            SetDamage(leftHand);
        }

        public void SetRighttHandItem(Item item)
        {
            rightHand = item;
            SetDamage(rightHand);
        }

        private void SetDamage(Item item)
        {
            damage += item.damage;
        }

        public void Eat(Item food)
        {
            //Console.WriteLine("Player is eating "+ food.name + "For Health " + food.damage);
            healthPoints += food.damage;
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
            ConsoleKeyInfo ans;
            do
            {
                if (firstTime)
                {
                    Console.WriteLine("Enter esc key to quit the application\nEnter w a s d to control the player\nEnter f for the furnance\nEnter c for the crafter\nEnter g for grathing food\nEnter r to auto mine\nEnter h for help or to display this message again\nEnter any key to clear this message");
                    Console.ReadKey();
                    firstTime = false;
                }

                ans = Console.ReadKey();

                switch (ans.KeyChar)
                {
                    // w
                    case 'w':
                        MoveUp(cells, map);
                        break;

                    // s
                    case 's':
                        MoveDown(cells, map);
                        break;

                    // a
                    case 'a':
                        MoveLeft(cells, map);
                        break;

                    // d
                    case 'd':
                        MoveRight(cells, map);
                        break;

                    // m
                    case 'm':
                        Mine(cells);
                        break;

                    // i
                    case 'i':
                        PrintInventory();
                        break;

                    // f for smelter (furnace)
                    case 'f':
                        map.smelterInterface.RunSmelterInterface();
                        break;

                    // c for crafter
                    case 'c':
                        map.crafterInterface.RunCrafterInterface();
                        break;

                    // g for gather
                    case 'g':
                        map.wander.Forage(this);
                        break;

                    // h for help
                    case 'h':
                        DisplayHelp();
                        break;

                    // r for mine(r)
                    case 'r':
                        map.wander.Mine(this);
                        break;

                    default:
                        break;
                }

                map.Draw();

                // 113 = "esc key"
            } while (ans.KeyChar != '\u001b');
        }

        private void DisplayHelp()
        {
            Console.WriteLine("Enter ecs key to quit the application\nEnter w a s d to control the player\nEnter f for the furnance\nEnter c for the crafter\nEnter g for grathing food\nEnter r to auto mine\nEnter h for help or to display this message again\nEnter any key to clear this message");
            Console.ReadKey();
        }

        public void PrintInventory()
        {
            PrintItemsInBackpack();
            Console.WriteLine("Press q to return to the main menu");
            Console.ReadKey();
        }

        public void Mine(Cell[,] cells)
        {
            string item = cells[x, y].prev_space;

            if (!item.ToString().Equals("  "))
            {
                string fullNameAsString = ConvertItemToFullName(item);
                ItemName itemNameEnum = ConvertStringToEnum(fullNameAsString);
                Item minedItem = GetItemByNameFromRegestry(itemNameEnum, WorldMap.registry);
                AddItemToBackpack(minedItem, 1);
                SetMoney(ValueOfBackpack());
                cells[x, y].ChangeSpace(player_token);
                cells[x, y].prev_space = "  ";
            }
        }

        public string ConvertItemToFullName(string item)
        {
            string[] names = Enum.GetNames(typeof(Blocks));
            foreach (string i in names)
            {
                if (i.Substring(0, 2) == item)
                {
                    return i.ToString();
                }
            }
            return "";
        }

        public ItemName ConvertStringToEnum(string itemName)
        {
            return (ItemName)Enum.Parse(typeof(ItemName), itemName);
        }

        public void MoveUp(Cell[,] cells, WorldMap map)
        {
            int i = CalulateXAndY(x, y, map).X;
            int j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            x -= 1;

            i = CalulateXAndY(x, y, map).X;

            x = i;

            cells[i, j].ChangeSpace(player_token);
        }

        public void MoveDown(Cell[,] cells, WorldMap map)
        {

            int i = CalulateXAndY(x, y, map).X;
            int j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            x += 1;

            i = CalulateXAndY(x, y, map).X;

            x = i;

            cells[i, j].ChangeSpace(player_token);
        }

        public void MoveLeft(Cell[,] cells, WorldMap map)
        {
            int i = CalulateXAndY(x, y, map).X;
            int j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            y -= 1;

            j = CalulateXAndY(x, y, map).Y;

            y = j;

            cells[i, j].ChangeSpace(player_token);
        }

        public void MoveRight(Cell[,] cells, WorldMap map)
        {
            int i = CalulateXAndY(x, y, map).X;
            int j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            y += 1;

            j = CalulateXAndY(x, y, map).Y;

            y = j;

            cells[i, j].ChangeSpace(player_token);
        }

        public static Points CalulateXAndY(int x, int y, WorldMap map)
        {
            int i = x - (int)((map.max_width * Math.Floor((double)x / map.max_width)));
            int j = y - (int)((map.max_height * Math.Floor((double)y / map.max_height)));
            return new Points() { X = i, Y = j };
        }

    }
}
