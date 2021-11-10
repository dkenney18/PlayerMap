using PlayerMap;

namespace SimpleAdventureGame
{
    public class Combat
    {
        public Player player;
        public Monster monster;

        public Combat(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
        }

        public void Fight()
        {
            while (player.healthPoints >= 0)
            {
                monster.hp -= (player.leftHand.damage + player.rightHand.damage);
                if (monster.hp <= 0)
                {
                    Item item = monster.reward.GiveReward();
                    player.AddItemToBackpack(item, item.amount);
                    player.SetMoney(player.ValueOfBackpack());
                    break;
                }
                else
                {
                    player.healthPoints -= monster.damage;
                }
            }
        }
    }
}
