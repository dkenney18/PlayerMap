using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAdventureGame
{
    class Ingot : Item
    {

        public Ingot(ItemName name, int value, int damage, int amount)
        {
            this.name = name;
            this.value = value;
            this.amount = amount;
            this.damage = damage;
            this.tag = ItemTag.Ingot;
        }
    }
}
