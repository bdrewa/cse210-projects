using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries yet.\n");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetSaveLine());
            }
        }
        Console.WriteLine($"Journal saved to {filename}\n");
    }
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach(string line in lines)
        {
            if (line.Trim() !="")
            {
                _entries.Add(Entry.FromSaveLine(line));
            }
        }
        Console.WriteLine($"Journal loaded from {filename}\n");
    }
}