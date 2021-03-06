using System;
using System.Collections.Generic;

namespace SimpleAdventureGame
{
    public class Backpack
    {
        public List<Item> items { get; set; }

        public Backpack()
        {
            items = new List<Item>();
        }

        public void AddItemToBackpack(Item item, int addamount)
        {
            if (items.Contains(item))
            {
                items[items.IndexOf(item)].amount += addamount;
            }
            else
            {
                item.amount = addamount;
                items.Add(item);
            }

        }

        public bool RemoveItemFromBackpack(Item item)
        {
            return items.Remove(item);
        }

        public List<Item> GetBackpack()
        {
            return items;
        }

        public Item GetItemByName(ItemName itemName)
        {
            return items.Find(item => item.name.Equals(itemName));
        }

        public int CurrentValueOfBackpack()
        {
            int currentValue = 0;
            items.ForEach(item => currentValue += (item.value * item.amount));
            return currentValue;
        }

        public static void PrintItem(Item item)
        {
            Console.WriteLine($"name: {item.name}\n value: {item.value}\ndamage: {item.damage} \nAmount: {item.amount}");
        }

        public void PrintItems()
        {
            items.ForEach(item => Console.WriteLine($"{item.name}<{item.amount}>"));
        }

        public void PrintItemsWithDetails()
        {
            items.ForEach(item => Console.WriteLine($"name: {item.name}\nvalue: {item.value}\ndamage: {item.damage}\namout: {item.amount}"));
        }

    }
}
