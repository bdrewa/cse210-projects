public class Monster : Character
{
    public Monster (string name, int health, int attackPower) : base(name, health, attackPower)
    {
        
    }

    public override string Attack(Character target)
    {
        int damage = AttackPower;
        target.TakeDamage(damage);
        return $"{Name} attacks for {damage} damage!";
    }
}