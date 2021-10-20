using System;

namespace PlayerMap
{
    public class WorldMap
    {
        public int max_width;
        public int max_height;
        public int mid_x;
        public int mid_y;
        public Cell[,] cells;
        public Player player;

        public WorldMap(int width, int height, Player p)
        {
            max_width = width;
            max_height = height;
            cells = new Cell[max_width, max_height];
            mid_x = max_width / 2;
            mid_y = max_height / 2;
            player = p;
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
    }
}
