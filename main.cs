namespace PlayerMap
{
    class Program
    {
        private static void Main()
        {
            WorldMap map = new WorldMap(10, 10);

            map.GenerateMap();
            map.Draw();

            //starts the Console interface
            WorldMap.player.Move(map, map.cells);
        }
    }
}
