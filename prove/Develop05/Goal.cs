public abstract class Goal
{
    private string _name;
    private int _points;

    public Goal(string name,int points)
    {
        _name = name;
        _points = points;
    }
    protected string Name => _name;
    protected int Points => _points;
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}

