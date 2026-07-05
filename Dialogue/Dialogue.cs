using System;
using System.Collections.Generic;
using System.IO.Compression;

public class Dialogue
{
    public List<DialogueLine> Lines = new();
    public List<DialogueChoice> Choices = new();
    public void AddLine(Character speaker, string text)
    {
        Lines.Add(new DialogueLine(speaker, text));
    }
    public void AddChoice(string text, int nextLine)
    {
        Choices.Add(new DialogueChoice(text, nextLine));
    } 
}