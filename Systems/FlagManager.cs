using System.Collections.Generic;

public class FlagManager
{
    private HashSet<GameFlag> flags = new();

    public void Set(GameFlag flag)
    {
        flags.Add(flag);
    }

    public bool Has(GameFlag flag)
    {
        return flags.Contains(flag);
    }

    public void Remove(GameFlag flag)
    {
        flags.Remove(flag);
    }
}