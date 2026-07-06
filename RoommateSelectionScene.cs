public class RoommateSelectionScene : IScene
{
    private CharacterManager characterManager;
    private Player player;

    public RoommateSelectionScene(CharacterManager characterManager, Player player)
    {
        this.characterManager = characterManager;
        this.player = player;
    }

    public SceneResult Run()
    {
        Console.WriteLine("Choose your roommate:");

        var characters = characterManager.GetRoommates();

        for (int i = 0; i < characters.Count; i++)
        {
            Console.WriteLine($"{i}. {characters[i].Name}");
        }

        int choice = int.Parse(Console.ReadLine() ?? "0");

        Character selected = characters[choice];

        selected.isRoomate = true;
        player.RoommateChoice = selected.Type;
        player.ActiveRoute = selected.Type;

        Console.WriteLine($"You chose: {selected.Name}");

        return new SceneResult
        {
            NextScene = null
        };
    }
}