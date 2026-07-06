using System;
using System.Collections.Generic;

public class RelationshipManager
{
    private Dictionary<CharacterType, Relationship> relationships =
        new Dictionary<CharacterType, Relationship>();

    public RelationshipManager()
    {
        foreach (CharacterType type in Enum.GetValues(typeof(CharacterType)))
        {
            relationships[type] = new Relationship();
        }
    }

    public Relationship Get(CharacterType type)
    {
        return relationships[type];
    }
}
