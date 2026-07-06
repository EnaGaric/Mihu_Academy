using System;

using System;

public abstract class RouteScene : IScene
{
    protected GameContext context;

    protected RouteScene(GameContext context)
    {
        this.context = context;
    }

    protected bool IsRoute(CharacterType type)
        => context.Player.ActiveRoute == type;

    protected Character GetCharacter(string name)
        => context.Characters.GetCharacter(name);

    protected Relationship GetRelationship(CharacterType type)
        => context.Relationships.Get(type);

    protected bool HasFlag(GameFlag flag)
        => context.Flags.Has(flag);

    protected void SetFlag(GameFlag flag)
        => context.Flags.Set(flag);

    public abstract SceneResult Run();
}