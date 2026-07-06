using System;

public class RoommateSelectionScene : RouteScene
{
    public RoommateSelectionScene(GameContext context)
        : base(context)
    {
    }

    public override SceneResult Run()
    {
        Console.WriteLine("Choose your roommate:");

        var characters = context.Characters.GetRoommates();

        for (int i = 0; i < characters.Count; i++)
        {
            Console.WriteLine($"{i}. {characters[i].Name}");
        }

        int choice = int.Parse(Console.ReadLine() ?? "0");

        Character selected = characters[choice];

        context.Player.RoommateChoice = selected.Type;
        context.Player.ActiveRoute = selected.Type;

        context.Flags.Set(GameFlag.ChoseRoommate);

        Console.WriteLine($"You chose: {selected.Name}");

        return SceneResult.Continue();
    }
}