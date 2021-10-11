using System;

namespace PlayerMap
{
    class WorldMap
    {
        public int max_width;
        public int max_height;
        public Cell[,] cells;
        private readonly Player player;

        public WorldMap(int width, int height, Player p)
        {
            max_width = width;
            max_height = height;
            cells = new Cell[max_width, max_height];
            player = p;
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

            var mid_x = max_width / 2;
            var mid_y = max_height / 2;

            player.SetCenter(mid_x, mid_y);

            cells[mid_x, mid_y].ChangeSpace(player.GetPlayerToken());
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
