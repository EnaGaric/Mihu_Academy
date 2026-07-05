using System;
using System.Collections.Generic;
using System.Data.Common;

public class CharacterManager
{
    private List<Character> characters = new List<Character>();

    public CharacterManager()
    {
        characters.Add(new Character
        {
            Name = "Mihu Kashino"
        });
    }
    
    public void ShowCharacters()
    {
        foreach (Character character in characters)
        {
            Console.WriteLine($"{character.Name} | Friendship: {character.Friendship}");
        }
    }
    public Character GetCharacter(string name)
    {
        foreach (Character character in characters)
        {
            if (character.Name == name)
            {
                return character;
            }
        }
        return null!;
    }
}