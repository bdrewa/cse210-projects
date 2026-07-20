public abstract class Character
{
    private string _name;
    private int _health;
    private int _maxHealth;
    private int _attackPower;

public Character(string name, int health, int attackPower)
    {
        _name = name;
        _health = health;
        _maxHealth = health;
        _attackPower = attackPower;
    }
protected string Name => _name;
protected int AttackPower => _attackPower;

public bool IsAlive()
    {
        return _health > 0;
    }

public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health < 0)
        {
            _health = 0;
        }
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

public string GetStatus()
    {
        return $"{_name}: {_health}/{_maxHealth} HP";
    }

   public string GetName()
    {
        return _name;
    }
public abstract string Attack(Character target);

}
