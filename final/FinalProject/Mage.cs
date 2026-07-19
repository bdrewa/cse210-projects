public class Mage : PlayerCharacter
{
    public Mage(string name, int health, int attackPower) : base(name, health, attackPower)
    {
        
    }
    public override string Attack (Character target)
    {
        int damage = AttackPower + 10;
        target.TakeDamage(damage);
        return $"{Name} casts a fireball for {damage} damage!";
    }
}