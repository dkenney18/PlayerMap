namespace PlayerMap
{
    class Program
    {
        static void Main()
        {
            WorldMap map = new(10, 10);

            map.GenerateMap();
            map.Draw();

            //starts the Console interface
            WorldMap.player.Move(map, map.cells);
        }
    }
}
