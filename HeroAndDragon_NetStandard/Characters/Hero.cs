using HeroAndDragon_NetStandard.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroAndDragon_NetStandard.Characters
{
    public class Hero : Character
    {
        public Sword? Sword { get; set; }
        public Shield? Shield { get; set; }

        public Hero(string name, int health, int maxDamage, int maxDefence, Sword? sword, Shield? shield = null) : base(name, health, maxDamage, maxDefence)
        {
            this.Sword = sword;
            this.Shield = shield;
        }

        public Hero(int health, int maxDamage, int maxDefence) : base (String.Empty, health, maxDamage, maxDefence)
        {

        }

        public Hero(string name, int health, int maxDamage, int maxDefence) : this(name, health, maxDamage, maxDefence, null, null)
        {

        }

        public override int Attack(Character opponent)
        {
            return base.Attack(opponent);
        }

        public override int Defence()
        {
            return base.Defence();
        }

        public override Character? OpponentSelection(List<Character> characters)
        {
            for (int i = 0; i < characters.Count * 2; ++i)
            {
                int indexGenerated = generator.Next(0, characters.Count);
                if(this != characters[indexGenerated] && characters[indexGenerated].IsAlive())
                {
                    return characters[indexGenerated];
                }
            }


            return base.OpponentSelection(characters);
        }

        public override double ComputeStrength()
        {
            return 0.3 * Health + 0.4 * (MaxDamage + Sword?.Damage ?? 0) + 0.3 * (MaxDefence + Shield?.Armor ?? 0);
        }
    }
}
