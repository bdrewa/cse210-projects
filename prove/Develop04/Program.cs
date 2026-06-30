// EXCEEDS CORE REQUIREMENTS:
// Added an activity log that keeps track of how many times
// each activity is completed during the current program session.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> activityLog = new Dictionary<string, int>
        {
            { "Breathing", 0 },
            { "Reflecting", 0 },
            { "Listing", 0 }
        };
         while (true)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();

            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Quit");

            Console.WriteLine();

            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice== "1")
            {
                BreathingActivity activity = new BreathingActivity();

                activity.Run();

                activityLog["Breathing"]++;
            }

            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();

                activity.Run();

                activityLog["Reflecting"]++;
            }

            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();

                activity.Run();

                activityLog["Listing"]++;
            }

            else if (choice == "4")
            {
                Console.Clear();

                Console.WriteLine("Activity Log");
                Console.WriteLine();

                Console.WriteLine($"Breathing Activity: {activityLog["Breathing"]}");
                Console.WriteLine($"Reflecting Activity: {activityLog["Reflecting"]}");
                Console.WriteLine($"Listing Activity: {activityLog["Listing"]}");

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue.");

                Console.ReadLine();
            }

            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");

                break;
            }
        }
    }
}