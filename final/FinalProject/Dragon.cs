public class Dragon : Monster
{
    public Dragon(string name, int health, int attackPower) : base(name, health, attackPower)
    {
        
    }

    public override string Attack(Character target)
    {
        int damage = AttackPower + 15;
        target.TakeDamage(damage);
        return $"{Name} breathes fire for {damage} damage!";
    }
}