using System;
using System.Collections.Generic;

public class CharacterManager
{
    private List<Character> characters = new List<Character>();

    public CharacterManager()
    {
        SeedCharacters();
    }

    private void SeedCharacters()
    {
    characters.Add(new Character
    {
        Name = "Mihu Kashino",
        Id = "mihu_kashino",
        Type = CharacterType.None,
        Description = "Your academic mentor."
    });

    characters.Add(new Character
    {
        Name = "Alice Blue",
        Id = "alice_blue",
        Type = CharacterType.AliceBlue,
        Description = "Friendly, charming, but something feels off..."
    });

    characters.Add(new Character
    {
        Name = "Ellie Kei",
        Id = "ellie_kei",
        Type = CharacterType.EllieKei,
        Description = "Energetic and unpredictable."
    });

    characters.Add(new Character
    {
        Name = "Ruby Rei",
        Id = "ruby_rei",
        Type = CharacterType.RubyRei,
        Description = "Emotional, chaotic, expressive."
    });

    characters.Add(new Character
    {
        Name = "Lilia Romanova",
        Id = "lilia_romanova",
        Type = CharacterType.LiliaRomanova,
        Description = "Cold, intelligent, distant."
    });
    }

    public List<Character> GetRoommates()
    {
        return characters.Where(c => c.Type != CharacterType.None).ToList();
    }

   public Character GetByIndex(int index)
    {
        var list = GetRoommates();

        if (index < 0 || index >= list.Count)
            return null;

        return list[index];
    }

    public Character GetCharacter(string name)
    {
        return characters.Find(c => c.Name == name);
    }
}