public class Goblin : Monster
{
    public Goblin(string name, int health, int attackPower) : base(name, health, attackPower)
    {
        
    }

    public override string Attack(Character target)
    {
        int damage = AttackPower - 2;
        target.TakeDamage(damage);
        return $"{Name} scratches at you for {damage} damage!";
    }
}