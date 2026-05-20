// Exceeds requirements:
// - PromptGenerator is a separate class
// - 17 prompts included
// - File existence checked before loading
// - DisplayMenu() keeps Main() clean and readable

using System;

class Program
{
    static Journal _journal = new Journal();
    static PromptGenerator _promptGenerator = new PromptGenerator();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = _promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    Entry newEntry = new Entry(date, prompt, response);
                    _journal.AddEntry(newEntry);
                    Console.WriteLine();
                    break;

                case "2":
                    _journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    _journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    _journal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option, please try again.\n");
                    break;
            }
        }
    }
      static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
    }
}
