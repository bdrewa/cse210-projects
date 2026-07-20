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

    public string GetEncounterIntro(List<Monster> monsters)
    {
        bool isDragon = monsters[0] is Dragon;

        if (isDragon)
        {
            string[] dragonIntros = new string[]
            {
                "A deep rumble shakes the ground as a massive shadow blots out the light above.",
                "The air grows hot and heavy with smoke. Something enormous stirs ahead.",
                "Scorch marks line the walls here. You are not the first to face what waits below."
            };
            return dragonIntros[_random.Next(0, dragonIntros.Length)];
        }
        else
        {
            string[] goblinIntros = new string[]
            {
                "You hear scuffling and low snarls echoing from just around the bend.",
                "Crude torches flicker ahead, held by hunched, twisted shapes.",
                "The stench of unwashed fur and rusted iron fills the corridor."
            };
            return goblinIntros[_random.Next(0, goblinIntros.Length)];
        }
    }

    public string GetVictoryOutro()
    {
        string[] outros = new string[]
        {
            "You catch your breath, the corridor falling silent once more.",
            "Your party pushes forward, wary of what else might be lurking nearby.",
            "The dust settles. Somewhere ahead, the path continues deeper into the dark."
        };
        return outros[_random.Next(0, outros.Length)];
    }
}