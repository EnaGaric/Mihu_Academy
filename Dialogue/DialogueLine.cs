using System;

public class DialogueLine
{
    public Character Speaker;

    public string Text = "";
    public DialogueLine(Character speaker, string text)
    {
        Speaker = speaker;
        Text = text;
    }
}