public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points)
    {
    }

    public override int RecordEvent()
    {
        return Points; // always award points, never "done"
    }

    public override bool IsComplete()
    {
        return false; // eternal goals can never be completed
    }

    public override string GetDetailsString()
    {
        return $"[ ] {Name}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Points}";
    }
}