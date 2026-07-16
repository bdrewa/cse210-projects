// EXCEEDING REQUIREMENTS:
// Added a leveling system — every 1,000 points earned increases the user's
// level by one, and a message displays the moment they level up.
// This uses the existing score tracking in GoalManager without any new stored state,
// since level is calculated from score whenever it's needed.


using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    manager.RecordEvent();
                    break;
                case "4":
                    manager.DisplayScore();
                    break;
                case "5":
                    Console.Write("Filename to save to: ");
                    manager.SaveGoals(Console.ReadLine());
                    break;
                case "6":
                    Console.Write("Filename to load from: ");
                    manager.LoadGoals(Console.ReadLine());
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Not a valid choice.");
                    break;
            }
        }
    }
}