using System;
using System.Collections.Generic;

public class RelationshipManager
{
    private Dictionary<CharacterType, Relationship> relationships = new();

    public RelationshipManager()
    {
        foreach (CharacterType type in Enum.GetValues<CharacterType>())
        {
            relationships[type] = new Relationship
            {
                Character = type
            };
        }
    }

    public Relationship Get(CharacterType type)
    {
        return relationships[type];
    }
}