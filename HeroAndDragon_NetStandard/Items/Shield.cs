using System;
using System.Collections.Generic;
using System.Text;

namespace HeroAndDragon_NetStandard.Items
{
    public class Shield : Item
    {
        public int Armor { get; set; }

        public Shield(string name, double weight, int armor) : base(name, weight)
        {
            Armor = armor;
        }
    }
}
