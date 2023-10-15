using HeroAndDragon_NetStandard.Random;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HeroAndDragon_NetStandard.Characters
{
    public abstract class Character : Object, IComparable<Character>
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int MaxDamage { get; set; }
        public int MaxDefence { get; set; }

        protected Generator generator = Generator.Instance;

        public event Action<Character, Character, int, int>? AttackPerformed;
        public event Action<Character, int>? DefencePerformed;

        public Character(string name, int health, int maxDamage, int maxDefence)
        {
            this.Name = name;
            this.Health = health;
            this.MaxHealth = health;
            this.MaxDamage = maxDamage;
            this.MaxDefence = maxDefence;
        }

        public virtual int Attack(Character opponent)
        {
            int damage = Convert.ToInt32(generator.NextDouble() * MaxDamage);
            int defence = opponent.Defence();
            damage -= defence;
            opponent.Health -= damage;

            AttackPerformed?.Invoke(this, opponent, damage, defence);

            return damage;
        }

        public virtual int Defence()
        {
            int defence = 0;
            if (generator.NextDouble() <= 0.5)
            {
                defence = generator.Next(0, MaxDefence);

                DefencePerformed?.Invoke(this, defence);
            }
            return defence;
        }

        public bool IsAlive()
        {
            if (Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual Character? OpponentSelection(List<Character> characters)
        {
            return OpponentSelectionBase(characters);
        }

        public virtual bool OpponentExists(List<Character> characters)
        {
            return OpponentSelectionBase(characters) != null ? true : false;
        }

        private Character? OpponentSelectionBase(List<Character> characters)
        {
            return OpponentSelection(characters, null);
        }

        protected Character? OpponentSelection(List<Character> characters, Predicate<Character>? opponentCondition)
        {
            Character? opponent = null;

            foreach (var character in characters)
            {
                bool resultSpecialCondition = opponentCondition != null ? opponentCondition(character) : true;
                if (this != character && character.IsAlive() && resultSpecialCondition)
                {
                    opponent = character;
                    break;
                }
            }

            return opponent;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Strength: {ComputeStrength()}, Health: {Health}, Max. Damage: {MaxDamage}, Max. Defence: {MaxDefence}";
        }

        public int CompareTo([AllowNull] Character other)
        {
            if (other == null)
                return 1;

            return this.ComputeStrength().CompareTo(other.ComputeStrength());

        }

        public virtual double ComputeStrength()
        {
            return 0.2 * Health + 0.4 * MaxDamage + 0.4 * MaxDefence;
        }
    }
}
