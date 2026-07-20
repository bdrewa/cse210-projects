using System;
using System.Collections.Generic;

public class Battle
{
    private Random _random;

    public Battle()
    {
        _random = new Random();
    }

    public void Fight(Party party, List<Monster> monsters, string introText)
    {
        Console.WriteLine($"\n{introText}");
        Console.WriteLine("Monsters approach:");
        foreach (Monster monster in monsters)
        {
            Console.WriteLine($"- {monster.GetStatus()}");
        }

        while (AnyAlive(monsters) && !party.IsDefeated())
        {
            foreach (PlayerCharacter member in party.GetMembers())
            {
                if (!member.IsAlive())
                {
                    continue;
                }
                if (!AnyAlive(monsters))
                {
                    break;
                }

                TakeTurn(member, monsters, party);
            }

            if (AnyAlive(monsters) && !party.IsDefeated())
            {
                Console.WriteLine();
                foreach (Monster monster in monsters)
                {
                    if (monster.IsAlive())
                    {
                        Console.WriteLine(monster.Attack(party.GetMembers()[0]));
                    }
                }
            }
        }

        Console.WriteLine();
        if (AnyAlive(monsters))
        {
            Console.WriteLine("Your party was defeated...");
        }
        else
        {
            Console.WriteLine("You defeated the encounter!");
            HandleLoot(monsters, party);
        }
    }

    private void TakeTurn(PlayerCharacter member, List<Monster> monsters, Party party)
    {
        Console.WriteLine($"\n{member.GetName()}'s turn! ({member.GetStatus()})");
        Console.WriteLine("1. Attack");
        if (member.HasPotions())
        {
            Console.WriteLine("2. Use a Potion");
        }
        Console.Write("Choice: ");
        string choice = Console.ReadLine();

        if (choice == "2" && member.HasPotions())
        {
            PlayerCharacter healTarget = ChooseAlly(party);
            member.UsePotion(healTarget);
            Console.WriteLine($"{member.GetName()} gives a potion to {healTarget.GetName()}. ({healTarget.GetStatus()})");
        }
        else
        {
            Monster target = ChooseTarget(monsters);
            Console.WriteLine(member.Attack(target));
        }
    }

    private Monster ChooseTarget(List<Monster> monsters)
    {
        List<Monster> aliveMonsters = new List<Monster>();
        foreach (Monster monster in monsters)
        {
            if (monster.IsAlive())
            {
                aliveMonsters.Add(monster);
            }
        }

        if (aliveMonsters.Count == 1)
        {
            return aliveMonsters[0];
        }

        Console.WriteLine();
        Console.WriteLine("Choose a target:");
        for (int i = 0; i < aliveMonsters.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {aliveMonsters[i].GetStatus()}");
        }
        Console.Write("Choice: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < aliveMonsters.Count)
        {
            return aliveMonsters[index];
        }
        return aliveMonsters[0];
    }

    private PlayerCharacter ChooseAlly(Party party)
    {
        List<PlayerCharacter> aliveMembers = new List<PlayerCharacter>();
        foreach (PlayerCharacter member in party.GetMembers())
        {
            if (member.IsAlive())
            {
                aliveMembers.Add(member);
            }
        }

        if (aliveMembers.Count == 1)
        {
            return aliveMembers[0];
        }

        Console.WriteLine();
        Console.WriteLine("Who should receive the potion?");
        for (int i = 0; i < aliveMembers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {aliveMembers[i].GetStatus()}");
        }
        Console.Write("Choice: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < aliveMembers.Count)
        {
            return aliveMembers[index];
        }
        return aliveMembers[0];
    }

    private bool AnyAlive(List<Monster> monsters)
    {
        foreach (Monster monster in monsters)
        {
            if (monster.IsAlive())
            {
                return true;
            }
        }
        return false;
    }

    private void HandleLoot(List<Monster> monsters, Party party)
    {
        foreach (Monster monster in monsters)
        {
            if (monster is Goblin)
            {
                int roll = _random.Next(1, 101);
                if (roll <= 50)
                {
                    List<PlayerCharacter> members = party.GetMembers();
                    List<PlayerCharacter> aliveMembers = new List<PlayerCharacter>();
                    foreach (PlayerCharacter member in members)
                    {
                        if (member.IsAlive())
                        {
                            aliveMembers.Add(member);
                        }
                    }

                    if (aliveMembers.Count > 0)
                    {
                        int index = _random.Next(0, aliveMembers.Count);
                        PlayerCharacter receiver = aliveMembers[index];
                        receiver.AddPotion(new Potion("Health Potion", 20));
                        Console.WriteLine($"The goblin dropped a Health Potion! {receiver.GetName()} picks it up.");
                    }
                }
            }
        }
    }
}