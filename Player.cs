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
            do
            {
                ans = Console.Read().ToString().Trim().ToLower();

                switch (ans)
                {
                    case "119":
                        MoveUp(cells);
                        break;

                    case "115":
                        MoveDown(cells);
                        break;

                    case "97":
                        MoveLeft(cells);
                        break;

                    case "100":
                        MoveRight(cells);
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
            backpack.Add(item);
            cells[x, y].ChangeSpace(" ");
            cells[x, y].prev_space = " ";
        }

        public void MoveUp(Cell[,] cells)
        {
            cells[x, y].RevertSpace();
            x -= 1;
            cells[x, y].ChangeSpace(player_token);
        }
        public void MoveDown(Cell[,] cells)
        {
            cells[x, y].RevertSpace();
            x += 1;
            cells[x, y].ChangeSpace(player_token);
        }
        public void MoveLeft(Cell[,] cells)
        {
            cells[x, y].RevertSpace();
            y -= 1;
            cells[x, y].ChangeSpace(player_token);
        }
        public void MoveRight(Cell[,] cells)
        {
            cells[x, y].RevertSpace();
            y += 1;
            cells[x, y].ChangeSpace(player_token);
        }


    }
}
