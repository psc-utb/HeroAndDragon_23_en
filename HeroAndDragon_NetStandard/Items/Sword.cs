using System;
using System.Collections.Generic;
using System.Text;

namespace HeroAndDragon_NetStandard.Items
{
    public class Sword : Item
    {
        public int Damage { get; set; }

        public Sword(string name, double weight, int damage) : base(name, weight)
        {
            Damage = damage;
        }
    }
}
