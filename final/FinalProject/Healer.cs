public class Healer : PlayerCharacter
{
    public Healer(string name, int health, int attackPower) : base(name, health, attackPower)
    {
        
    }
    public override string Attack (Character target)
    {
        int damage = AttackPower;
        target.TakeDamage(damage);
        return $"{Name} strikes with a staff for {damage} damage!";
    }
}