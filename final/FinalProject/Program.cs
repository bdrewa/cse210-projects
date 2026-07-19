using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Party party = new Party();

        bool addingMembers = true;
        while (addingMembers)
        {
            Console.WriteLine("\nChoose a character type to add to your party:");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Healer");
            Console.WriteLine("4. Done adding members");
            Console.Write("Choice: ");
            string typeChoice = Console.ReadLine();

            if (typeChoice == "4")
            {
                addingMembers = false;
            }
            else if (typeChoice == "1" || typeChoice == "2" || typeChoice == "3")
            {
                Console.Write("What is this character's name? ");
                string name = Console.ReadLine();

                PlayerCharacter newMember = null;

                if (typeChoice == "1")
                {
                    newMember = new Warrior(name, 50, 10);
                }
                else if (typeChoice == "2")
                {
                    newMember = new Mage(name, 30, 8);
                }
                else if (typeChoice == "3")
                {
                    newMember = new Healer(name, 40, 5);
                    newMember.AddPotion(new Potion("Health Potion", 20));
                    newMember.AddPotion(new Potion("Health Potion", 20));
                    newMember.AddPotion(new Potion("Health Potion", 20));
                }

                party.AddMember(newMember);

                Console.WriteLine($"{name} has joined the party!");
            }
            else
            {
                Console.WriteLine("Not a valid choice.");
            }
        }

        Console.WriteLine("\nChoose your path into the dungeon:");
        Console.WriteLine("1. Through the Whispering Forest");
        Console.WriteLine("2. Through the Sunken Caves");
        Console.WriteLine("3. Through the Frostbitten Pass");
        Console.Write("Choice: ");
        string pathChoice = Console.ReadLine();

        if (pathChoice == "1")
        {
            Console.WriteLine("\nYour party steps into the Whispering Forest, shadows moving between the trees...");
        }
        else if (pathChoice == "2")
        {
            Console.WriteLine("\nYour party descends into the Sunken Caves, water dripping into the darkness...");
        }
        else
        {
            Console.WriteLine("\nYour party trudges into the Frostbitten Pass, wind howling around you...");
        }

        EncounterGenerator generator = new EncounterGenerator();
        Battle battle = new Battle();

        for (int i = 0; i < 3; i++)
        {
            if (!party.IsDefeated())
            {
                List<Monster> encounter = generator.GetRandomEncounter();
                battle.Fight(party, encounter);
            }
        }

        if (party.IsDefeated())
        {
            Console.WriteLine("\nYour journey ends here...");
        }
        else
        {
            Console.WriteLine("\nYour party emerges from the dungeon, victorious!");
        }
    }
}