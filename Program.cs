using System.Threading.Tasks;

namespace PlayerMap
{
    internal class Program
    {
        private static async Task Main()
        {
            WorldMap map = new(10, 10);

            map.GenerateMap();
            map.Draw();

            //starts the Console interface
            await WorldMap.player.Move(map, map.cells);
        }
    }
}
