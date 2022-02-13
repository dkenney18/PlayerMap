namespace SimpleAdventureGame
{
    public class Monster
    {
        public string name;
        public int hp;
        public int damage;
        public Reward reward;

        public Monster(string name, int hp, Reward reward, int damage)
        {
            this.name = name;
            this.hp = hp;
            this.reward = reward;
            this.damage = damage;
        }

        public void Damage(int damage)
        {
            hp -= damage;
        }
    }
}
