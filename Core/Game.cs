using System;
using System.Collections;

public class Game
{
    private Player player = new Player();
    private ActionManager actionManager = new ActionManager();
    private CharacterManager characterManager = new CharacterManager();
    private DialogueManager dialogueManager = new DialogueManager();
    private SceneManager sceneManager = new SceneManager();
    private bool isRunning = true;

    public void Start()
    {
        Console.WriteLine("Welcome to the Academy!");

        CreatePlayer();
        ChooseRoommate();
        GameLoop();
    }

    private void CreatePlayer()
    {
        Console.Write("Enter your name: ");
        player.Name = Console.ReadLine() ?? "";

        Console.WriteLine($"Welcome, {player.Name}!");

        MeetMihu();
    }

    private void MeetMihu()
    {
        Character mihu = characterManager.GetCharacter("Mihu Kashino");

        IntroScene intro = new IntroScene(mihu, dialogueManager);

        int choice = sceneManager.RunScene(intro);

        HandleMihuChoice(choice);
    }

    private void HandleMihuChoice(int choice)
    {
        switch (choice)
        {
            case 0:
                Console.WriteLine("Mihu nods slightly.");
                player.Entropy -= 5;
                player.MihuFriendship += 5;
                break;

            case 1:
                Console.WriteLine("Mihu ignores you.");
                player.Academic += 5;
                player.MihuFriendship += 2;
                break;

            case 2:
                Console.WriteLine("Awkward silence fills the room.");
                player.Entropy -= 10;
                player.MihuFriendship -= 2;
                break;
        }
    }
    private void ChooseRoommate()
    {
        RoommateSelectionScene scene = new RoommateSelectionScene(characterManager);

        int choice = sceneManager.RunScene(scene);

        Character selected = scene.Options[choice];

        if (selected != null)
        {
            selected.isRoomate = true;
            player.RoommateChoice = selected.Type;

            Console.WriteLine($"You chose: {selected.Name}");
        }
    }
    private void GameLoop()
    {
        while (isRunning)
        {
            ShowDayHeader();
            ShowMenu();

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Study();
                    break;

                case "2":
                    Work();
                    break;

                case "3":
                    Socialize();
                    break;

                case "4":
                    Sleep();
                    break;

                case "5":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            ShowStats();
        }
    }

    private void Study()
    {
        player.Academic += 10;
        player.Entropy -= 5;

        Console.WriteLine("You studied with Mihu.");
        AdvanceTime();
    }

    private void Work()
    {
        player.Money += 20;
        player.Entropy -= 10;

        Console.WriteLine("You worked.");
        AdvanceTime();
    }

    private void Socialize()
    {
        player.Entropy += 15;

        Console.WriteLine("You socialized.");
        AdvanceTime();
    }

    private void Sleep()
    {
        player.Entropy += 10;

        Console.WriteLine("You slept.");

        if (player.Entropy > 100)
            player.Entropy = 100;

        AdvanceTime();
    }

    private void ShowMenu()
    {
        actionManager.ShowActions();
        Console.WriteLine("5. Exit");
    }

    private void ShowStats()
    {
        Console.WriteLine();
        Console.WriteLine($"Academic: {player.Academic}");
        Console.WriteLine($"Entropy: {player.Entropy}");
        Console.WriteLine($"Money: {player.Money}");
        Console.WriteLine($"Mihu Friendship: {player.MihuFriendship}");
        Console.WriteLine($"Day: {player.Day}");
    }

    private void ShowDayHeader()
    {
        Console.WriteLine($"\n====================");
        Console.WriteLine($"DAY {player.Day}");
        Console.WriteLine($"{player.Time}");
        Console.WriteLine("====================");
    }

    private void AdvanceTime()
    {
        switch (player.Time)
        {
            case TimeOfDay.Morning:
                player.Time = TimeOfDay.Afternoon;
                break;

            case TimeOfDay.Afternoon:
                player.Time = TimeOfDay.Evening;
                break;

            case TimeOfDay.Evening:
                player.Time = TimeOfDay.Night;
                break;

            case TimeOfDay.Night:
                player.Time = TimeOfDay.Morning;
                player.Day++;
                break;
        }
    }
}