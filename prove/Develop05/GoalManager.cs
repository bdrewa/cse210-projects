using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your current score is: {_score} points");
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("What type of goal? 1) Simple 2) Eternal 3) Checklist");
        string choice = Console.ReadLine();

        Console.Write("Goal name: ");
        string name = Console.ReadLine();

        Console.Write("Points per event: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, points));
        }
        else if (choice == "3")
        {
            Console.Write("How many times to complete it: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points on completion: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Not a valid choice.");
        }
    }

    public void RecordEvent()
    {
        DisplayGoals();
        Console.Write("Which goal number did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int oldScore = _score;
            int earned = _goals[index].RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points!");
            CheckLevelUp(oldScore);
        }
        else
        {
            Console.WriteLine("That goal number doesn't exist.");
        }
    }

    public void CheckLevelUp(int oldScore)
    {
        int oldLevel = oldScore / 1000;
        int newLevel = _score / 1000;
        if (newLevel > oldLevel)
        {
            Console.WriteLine($"***Level up! You are now level {newLevel}!***");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals(string filename)
    {
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] typeAndData = lines[i].Split(':');
            string type = typeAndData[0];
            string[] parts = typeAndData[1].Split(',');

            if (type == "SimpleGoal")
            {
                string name = parts[0];
                int points = int.Parse(parts[1]);
                bool isComplete = bool.Parse(parts[2]);
                SimpleGoal goal = new SimpleGoal(name, points);
                if (isComplete)
                {
                    goal.RecordEvent();
                }
                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                string name = parts[0];
                int points = int.Parse(parts[1]);
                _goals.Add(new EternalGoal(name, points));
            }
            else if (type == "ChecklistGoal")
            {
                string name = parts[0];
                int points = int.Parse(parts[1]);
                int amountCompleted = int.Parse(parts[2]);
                int target = int.Parse(parts[3]);
                int bonus = int.Parse(parts[4]);

                ChecklistGoal goal = new ChecklistGoal(name, points, target, bonus);
                for (int j = 0; j < amountCompleted; j++)
                {
                    goal.RecordEvent(); 
                }
                _goals.Add(goal);
            }
        }
        Console.WriteLine("Goals loaded.");
    }
}