using System;
using System.Collections.Generic;
using System.Text;

namespace HeroAndDragon_NetStandard.Characters
{
    public class Dragon : Character
    {
        public Dragon(string name, int health, int maxDamage, int maxDefence) : base(name, health, maxDamage, maxDefence)
        {

        }

        public override Character? OpponentSelection(List<Character> characters)
        {
            return this.OpponentSelection(characters, opponent => opponent.GetType() != this.GetType());
        }

        public override bool OpponentExists(List<Character> characters)
        {
            return base.OpponentSelection(characters, opponent => opponent.GetType() != this.GetType()) != null ? true : false;
        }
    }
}
