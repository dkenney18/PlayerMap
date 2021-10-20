using System;
using System.Collections.Generic;

namespace PlayerMap
{
    class Player
    {
        private int x;
        private int y;
        private readonly string player_token;
        private readonly List<string> backpack = new List<string>();

        public Player(string p_token) { player_token = p_token; }

        public void SetCenter(int center_x, int center_y)
        {
            x = center_x;
            y = center_x;
        }

        public string GetPlayerToken()
        {
            return player_token;
        }

        public void Move(WorldMap map, Cell[,] cells)
        {
            var ans = "";
            do
            {
                ans = Console.Read().ToString().Trim().ToLower();

                switch (ans)
                {
                    case "119":
                        MoveUp(cells, map);
                        break;

                    case "115":
                        MoveDown(cells, map);
                        break;

                    case "97":
                        MoveLeft(cells, map);
                        break;

                    case "100":
                        MoveRight(cells, map);
                        break;

                    case "109":
                        Mine(cells);
                        break;

                    default:
                        break;
                }

                map.Draw();

            } while (ans != "113");

            PrintBackpack();
        }

        public void PrintBackpack()
        {
            foreach (var item in backpack)
            {
                Console.WriteLine(item);
            }
        }

        private void Mine(Cell[,] cells)
        {
            var item = cells[x, y].prev_space;

            if (!item.ToString().Equals(" "))
            {
                backpack.Add(item);
            }

            cells[x, y].ChangeSpace(player_token);
            cells[x, y].prev_space = " ";
        }

        public void MoveUp(Cell[,] cells, WorldMap map)
        {
            var i = CalulateXAndY(x, y, map).X;
            var j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            x -= 1;

            i = CalulateXAndY(x, y, map).X;

            cells[i, j].ChangeSpace(player_token);
        }

        public void MoveDown(Cell[,] cells, WorldMap map)
        {

            var i = CalulateXAndY(x, y, map).X;
            var j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            x += 1;

            i = CalulateXAndY(x, y, map).X;

            cells[i, j].ChangeSpace(player_token);
        }

        public void MoveLeft(Cell[,] cells, WorldMap map)
        {
            var i = CalulateXAndY(x, y, map).X;
            var j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            y -= 1;

            j = CalulateXAndY(x, y, map).Y;

            cells[i, j].ChangeSpace(player_token);
        }

        public void MoveRight(Cell[,] cells, WorldMap map)
        {
            var i = CalulateXAndY(x, y, map).X;
            var j = CalulateXAndY(x, y, map).Y;

            cells[i, j].RevertSpace();

            y += 1;

            j = CalulateXAndY(x, y, map).Y;

            cells[i, j].ChangeSpace(player_token);
        }

        private Points CalulateXAndY(int x, int y, WorldMap map)
        {
            var i = x - (int)((map.max_width * Math.Floor((double)x / map.max_width)));
            var j = y - (int)((map.max_height * Math.Floor((double)y / map.max_height)));
            return new Points() { X = i, Y = j };
        }

    }
}
