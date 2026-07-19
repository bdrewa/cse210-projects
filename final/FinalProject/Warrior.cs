public class Warrior : PlayerCharacter
{
    public Warrior (string name, int health, int attackPower) : base(name, health, attackPower)
    {
        
    }

    public override string Attack (Character target)
    {
        int damage = AttackPower + 5;
        target.TakeDamage(damage);
        return $"{Name} swings a sword for {damage} damage!";
    }
}