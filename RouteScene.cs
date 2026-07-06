using System;

public abstract class RouteScene : IScene
{
    protected Player player;

    public RouteScene(Player player)
    {
        this.player = player;
    }

    protected bool IsRoute(CharacterType type)
        => player.ActiveRoute == type;

    public abstract SceneResult Run();
}