using HeroAndDragon_NetStandard.Characters;
using HeroAndDragon_NetStandard.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hrdina_a_drak
{
    class Program
    {
        static void Main(string[] args)
        {
            //equipment
            Sword sword1 = new Sword("Silver sword", 2.5, 175);
            Sword sword2 = new Sword("Daedric sword", 4, 150);
            Shield shield = new Shield("Elfish shield", 2.5, 150);


            //heroes and dragons
            Hero hero = new Hero("Geralt", 500, 175, 50);
            Dragon dragon = new Dragon("Alduin", 350, 100, 40);
            Dragon dragon2 = new Dragon("Smaug", 450, 75, 25);
            Hero hero2 = new Hero("Dovahkiin", 150, 75, 35, sword1);


            //list of characters
            List<Character> characters = new List<Character>();
            characters.Add(hero);
            characters.Add(dragon);
            characters.Add(dragon2);
            characters.Add(hero2);

            characters.Sort();
            Console.WriteLine(String.Join(Environment.NewLine, characters));
            Console.WriteLine(Environment.NewLine + Environment.NewLine);


            //attack events attached
            characters.ForEach(character => character.AttackPerformed += WriteAttackData);


            for (int i = 0; OpponentCanBeChosen(characters); ++i)
            {
                Console.WriteLine("Fight no. " + i);

                for (int j = 0; j < characters.Count; ++j)
                {
                    Character attacker = characters[j];
                    if (attacker.IsAlive())
                    {
                        Character? opponent = attacker.OpponentSelection(characters);
                        if (opponent != null)
                            attacker.Attack(opponent);
                        else
                            continue;

                        Console.WriteLine(Environment.NewLine + Environment.NewLine);
                    }
                }
            }

            Console.WriteLine("Winners:");
            foreach (var character in characters)
            {
                if (character.IsAlive())
                {
                    Console.WriteLine(character.ToString());
                }
            }
            Console.WriteLine("Loosers:");
            foreach (var character in characters)
            {
                if (!character.IsAlive())
                {
                    Console.WriteLine(character.ToString());
                }
            }
        }

        public static bool OpponentCanBeChosen(List<Character> characters)
        {
            foreach (Character character in characters)
            {
                if (character.IsAlive() && character.OpponentExists(characters))
                {
                    return true;
                }
            }
            return false;
        }


        public static void WriteAttackData(Character attacker, Character opponent, int damage, int defence)
        {
            Console.WriteLine($"Attacker {attacker.Name} gives damage: " + damage);
            Console.WriteLine($"Opponent {opponent.Name} has health: " + opponent.Health);
        }
    }
}
