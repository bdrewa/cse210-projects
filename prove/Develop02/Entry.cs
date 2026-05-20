public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public string GetDate() => _date;
    public string GetPrompt() => _promptText;
    public string GetText() => _entryText;
    
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    public string GetSaveLine()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public static Entry FromSaveLine(string line)
    {
        string[] parts = line.Split("|");
    return new Entry(parts[0], parts[1], parts[2]);
    }

}