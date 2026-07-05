using System;
using System.Collections.Generic;

public class RoommateSelectionScene : IScene
{
    public List<Character> Options { get; private set; }

    public RoommateSelectionScene(CharacterManager characterManager)
    {
        Options = characterManager.GetRoommates();
    }

    public int Run()
    {
        Console.WriteLine("\n=== Choose your roommate ===");

        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i].Name}");
            Console.WriteLine($"   {Options[i].Description}\n");
        }

        Console.WriteLine($"Choose 1-{Options.Count}");

        string input = Console.ReadLine();

        int choice;

        if (!int.TryParse(input, out choice))
            return 0;

        choice -= 1;

        if (choice < 0 || choice >= Options.Count)
            return 0;

        return choice;
    }
}