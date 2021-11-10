using System.Collections.Generic;

namespace SimpleAdventureGame
{
    public class MonsterRegistry
    {
        private readonly List<Monster> monsters = new();

        public Monster GetMonsterByName(string monsterName)
        {
            return monsters.Find(m => m.name == monsterName);
        }

        public void AddMonsterToRegestry(Monster Monster)
        {
            monsters.Add(Monster);
        }
    }
}
