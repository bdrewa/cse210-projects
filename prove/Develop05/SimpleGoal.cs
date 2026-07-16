public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }
        _isComplete = true;
        return Points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string mark = _isComplete ? "[X]" : "[ ]";
        return $"{mark} {Name}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Points},{_isComplete}";
    }
}