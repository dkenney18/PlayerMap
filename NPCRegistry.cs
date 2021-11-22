using System.Collections.Generic;
using PlayerMap;

namespace SimpleAdventureGame
{
    public class NPCRegistry
    {
        private readonly List<Player> players = new();

        public Player GetNPCByName(string npcName)
        {
            return players.Find(p => p.name == npcName);
        }

        public void AddNPCToRegestry(Player player)
        {
            players.Add(player);
        }
    }
}
