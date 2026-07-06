using System;

public class IntroScene : RouteScene
{
    public IntroScene(GameContext context)
        : base(context)
    {
    }

    public override SceneResult Run()
    {
        Character mihu = GetCharacter("Mihu Kashino");

        Dialogue dialogue = new Dialogue();

        dialogue.AddLine(mihu, "Good morning.");
        dialogue.AddLine(mihu, "Welcome to my office.");
        dialogue.AddLine(mihu, "My name is Mihu Kashino.");
        dialogue.AddLine(mihu, "I'll be your study partner.");

        dialogue.AddChoice("Nice to meet you.", 0);
        dialogue.AddChoice("Who are you?", 1);
        dialogue.AddChoice("Stay silent.", 2);

        context.Dialogue.Play(dialogue);

        SetFlag(GameFlag.MetMihu);

        return SceneResult.Continue();
    }
}