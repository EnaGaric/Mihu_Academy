using System;

public class Game
{
    private Player player = new Player();

    private CharacterManager characterManager = new CharacterManager();
    private SceneManager sceneManager = new SceneManager();
    private DialogueManager dialogueManager = new DialogueManager();
    private RelationshipManager relationshipManager = new RelationshipManager();
    private bool isRunning = true;

    public void Start()
    {
        Console.WriteLine("Welcome to the Academy!");

        CreatePlayer();

        PlayIntro();

        ChooseRoommate();

        GameLoop();
    }

    private void CreatePlayer()
    {
        Console.Write("Enter your name: ");
        player.Name = Console.ReadLine() ?? "";

        Console.WriteLine($"Welcome, {player.Name}!");
    }

    private void PlayIntro()
    {
        Character mihu = characterManager.GetCharacter("Mihu Kashino");

        sceneManager.RunScene(new IntroScene(mihu, dialogueManager));
    }

    private void ChooseRoommate()
    {
        RoommateSelectionScene scene =
            new RoommateSelectionScene(characterManager, player);

        sceneManager.RunScene(scene);
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
                    sceneManager.RunScene(new StudyScene(player));
                    AdvanceTime();
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

        if (player.Entropy > 100)
            player.Entropy = 100;

        Console.WriteLine("You slept.");

        while (player.Time != TimeOfDay.Morning)
        {
            AdvanceTime();
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("\n1. Study");
        Console.WriteLine("2. Work");
        Console.WriteLine("3. Socialize");
        Console.WriteLine("4. Sleep");
        Console.WriteLine("5. Exit");
    }

    private void ShowStats()
    {
        Console.WriteLine();
        Console.WriteLine($"Academic: {player.Academic}");
        Console.WriteLine($"Entropy: {player.Entropy}");
        Console.WriteLine($"Money: {player.Money}");
        Console.WriteLine($"Day: {player.Day}");
        Console.WriteLine($"Time: {player.Time}");
    }

    private void ShowDayHeader()
    {
        Console.WriteLine("\n====================");
        Console.WriteLine($"DAY {player.Day}");
        Console.WriteLine(player.Time);
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