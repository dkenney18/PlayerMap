//Devin Kenney
//SQA Test Analyst
//Publix Supermarkets
//Phone number: 863-999-2432
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
            await WorldMap.player.Move(map);
        }
    }
}