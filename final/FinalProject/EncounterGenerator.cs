using System;
using System.Collections.Generic;

public class EncounterGenerator
{
    private Random _random;

    public EncounterGenerator()
    {
        _random = new Random();
    }

    public List<Monster> GetRandomEncounter()
    {
        List<Monster> encounter = new List<Monster>();
        int roll = _random.Next(1, 4);

        if (roll == 1 || roll == 2)
        {
            int goblinCount = _random.Next(1, 4);
            for (int i = 0; i < goblinCount; i++)
            {
                encounter.Add(new Goblin($"Goblin {i + 1}", 20, 5));
            }
        }
        else
        {
            encounter.Add(new Dragon("Smaug", 100, 18));
        }

        return encounter;
    }
}