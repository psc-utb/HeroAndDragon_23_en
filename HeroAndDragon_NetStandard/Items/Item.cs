using System;
using System.Collections.Generic;
using System.Text;

namespace HeroAndDragon_NetStandard.Items
{
    public class Item
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public Item(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
