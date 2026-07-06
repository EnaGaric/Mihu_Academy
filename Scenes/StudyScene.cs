public class StudyScene : RouteScene
{
    public StudyScene(Player player) : base(player) {}

    public override SceneResult Run()
    {
        Console.WriteLine("You study in the academy library.");

        if (IsRoute(CharacterType.LiliaRomanova))
            Console.WriteLine("Lilia's presence makes studying feel stricter");

        if (IsRoute(CharacterType.AliceBlue))
            Console.WriteLine("Alice casually distracts you while pretending to help.");

        if (IsRoute(CharacterType.EllieKei))
            Console.WriteLine("Ellie helps you as much as she can.");

        if (IsRoute(CharacterType.RubyRei))
            Console.WriteLine("Ruby keeps distracting you with small talk.");

        return new SceneResult
        {
            NextScene = null
        };
    }
}