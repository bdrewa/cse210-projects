using System.Collections.Generic;

public abstract class PlayerCharacter : Character
{
    private List<Potion> _inventory;

    public PlayerCharacter(string name, int health, int attackPower) : base(name, health, attackPower)
    {
        _inventory = new List<Potion>();
    }

    public void AddPotion(Potion potion)
    {
        _inventory.Add(potion);
    }

    public void UsePotion(PlayerCharacter target)
    {
        if (_inventory.Count > 0)
        {
            Potion potion = _inventory[0];
            potion.Use(target);
            _inventory.RemoveAt(0);
        }
    }
    public bool HasPotions()
    {
        return _inventory.Count > 0;
    }
}
