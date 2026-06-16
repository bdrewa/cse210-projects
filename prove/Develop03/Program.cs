// Exceeded requirements by loading scriptures from a text file (scriptures.txt)
// and selecting one at random each time the program runs.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("scriptures.txt");
        Random random = new Random();
        string line = lines[random.Next(lines.Length)];
        string[] parts = line.Split('|');

        Reference reference;
        Scripture scripture;

        if (parts.Length == 5)
        {
            reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
            scripture = new Scripture(reference, parts[4]);
        }
        else
        {
            reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
            scripture = new Scripture(reference, parts[3]);
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden! Well done!");
                break;
            }

            Console.Write("Press Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }
    }
}