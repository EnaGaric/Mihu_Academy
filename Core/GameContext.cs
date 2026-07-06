using System;

public class GameContext
{
    public Player Player { get; }

    public CharacterManager Characters { get; }

    public DialogueManager Dialogue { get; }

    public SceneManager Scenes { get; }

    public RelationshipManager Relationships { get; }

    public FlagManager Flags { get; }
    public CalendarManager Calendar { get; }
    public EventManager Events { get; }
    public Random Random { get; } = new();

    public GameContext(
        Player player,
        CharacterManager characters,
        DialogueManager dialogue,
        SceneManager scenes,
        RelationshipManager relationships,
        FlagManager flags)
    {
        Player = player;
        Characters = characters;
        Dialogue = dialogue;
        Scenes = scenes;
        Relationships = relationships;
        Flags = flags;
        Calendar = new CalendarManager();
        Events = new EventManager(this);
    }
}