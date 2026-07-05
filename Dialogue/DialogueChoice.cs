using System;

public class DialogueChoice
{
    public string Text = "";
    public int NextLine = -1;
    public DialogueChoice(string text, int nextLine)
    {
        Text = text;
        NextLine = nextLine;
    }
}