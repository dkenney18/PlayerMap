using System;
using SimpleAdventureGame;

public class PlayerModel
{
    public int X { get; set; }
    public int Y { get; set; }
    public string PlayerToken { get; set; }
    public string Name { get; set; }
    public int Money { get; set; }
    public BackpackModel Backpack { get; set; }
    public int HealthPoints { get; set; }
    public int Damage { get; set; }
    public ItemModel LeftHand { get; set; }
    public ItemModel RightHand { get; set; }
    public bool FirstTime { get; set; }
}
