using System.Collections.Generic;

public class Party
{
    private List<PlayerCharacter> _members;

    public Party()
    {
        _members = new List<PlayerCharacter>();
    }

    public void AddMember(PlayerCharacter member)
    {
        _members.Add(member);
    }
    
    public List<PlayerCharacter> GetMembers()
    {
        return _members;
    }

    public bool IsDefeated()
    {
        foreach (PlayerCharacter member in _members)
        {
            if (member.IsAlive())
            {
                return false;
            }
        }

        return true;
    }
}