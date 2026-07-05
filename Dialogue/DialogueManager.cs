using System;

public class DialogueManager
{
    public int Play(Dialogue dialogue)
    {
        foreach (DialogueLine line in dialogue.Lines)
        {
            ShowLine(line);
        }

        if (dialogue.Choices.Count > 0)
        {
            ShowChoices(dialogue);
            return GetChoice(dialogue);
        }

        return -1;
    }

    private void ShowLine(DialogueLine line)
    {
        Console.Clear();

        Console.WriteLine("================================");
        Console.WriteLine(line.Speaker.Name);
        Console.WriteLine("--------------------------------");
        Console.WriteLine(line.Text);
        Console.WriteLine("================================");
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");

        Console.ReadLine();
    }

    private void ShowChoices(Dialogue dialogue)
    {
        Console.Clear();

        Console.WriteLine("Choose your response:");
        Console.WriteLine();

        for (int i = 0; i < dialogue.Choices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {dialogue.Choices[i].Text}");
        }

        Console.WriteLine();
    }

    private int GetChoice(Dialogue dialogue)
    {
        while (true)
        {
            Console.Write("Choice: ");

            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int number))
            {
                if (number >= 1 && number <= dialogue.Choices.Count)
                {
                    return number - 1;
                }
            }

            Console.WriteLine("Invalid choice.");
        }
    }
}