namespace PlayerMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("#");
            WorldMap map = new WorldMap(10, 10, player);

            map.GenerateMap();
            map.Draw();

            player.Move(map, map.cells);

        }
    }
}
