using System;
using SimpleAdventureGame;

public class ItemModel
{
    public ItemName Name { get; set; }
    public int Value { get; set; }
    public int Damage { get; set; }
    public int Amount { get; set; }
    public Enum Hand { get; set; }
    public ItemTag Tag { get; set; }
}
