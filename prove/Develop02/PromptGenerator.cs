public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What am I most grateful for today?",
        "What did I learn today?",
        "What challenged me today and how did I handle it?",
        "What made me smile or laugh today?",
        "What is one thing I am proud of myself for today?",
        "Who did I help today and how did it make me feel?",
        "What was the most difficult moment of my day and how did I get through it?",
        "What is something I am looking forward to tomorrow?",
        "What is one thing I wish I had done differently today?",
        "What was something unexpected that happened today?",
        "What song, book, or movie is on my mind today and why?",
        "What is one goal I am working toward and how did today help me get there?",
        "If I could describe today in one word what would it be and why?"
    };

    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count)];
    }
}