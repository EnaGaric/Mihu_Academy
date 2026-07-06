using System;

public class IntroScene : IScene
{
    private Character mihu;
    private DialogueManager dialogueManager;

    public IntroScene(Character mihu, DialogueManager dialogueManager)
    {
        this.mihu = mihu;
        this.dialogueManager = dialogueManager;
    }

    public SceneResult Run()
    {
        Dialogue dialogue = new Dialogue();

        dialogue.AddLine(mihu, "Good morning.");
        dialogue.AddLine(mihu, "Welcome to my office.");
        dialogue.AddLine(mihu, "My name is Mihu Kashino.");
        dialogue.AddLine(mihu, "I'll be your study partner.");

        dialogue.AddChoice("Nice to meet you.", 0);
        dialogue.AddChoice("Who are you?", 1);
        dialogue.AddChoice("Stay silent.", 2);

        dialogueManager.Play(dialogue);

        return new SceneResult
        {
            NextScene = null
        };
    }
}