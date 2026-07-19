public class Potion
{
    private string _name;
    private int _healAmount;

    public Potion(string name, int healAmount)
    {
        _name = name;
        _healAmount = healAmount;
    }

    public void Use(PlayerCharacter target)
    {
        target.TakeDamage(-_healAmount);
    }
}