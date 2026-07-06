using System;

public class Game
{
    private bool isRunning = true;

    private GameContext context;

    public void Start()
    {
        Console.WriteLine("Welcome to the Academy!");

        context = new GameContext(
            new Player(),
            new CharacterManager(),
            new DialogueManager(),
            new SceneManager(),
            new RelationshipManager(),
            new FlagManager()
        );

        CreatePlayer();

        PlayIntro();

        ChooseRoommate();

        GameLoop();
    }

    private void CreatePlayer()
    {
        Console.Write("Enter your name: ");
        context.Player.Name = Console.ReadLine() ?? "";

        Console.WriteLine($"Welcome, {context.Player.Name}!");
    }

    private void PlayIntro()
    {
        context.Scenes.RunScene(new IntroScene(context));
    }

    private void ChooseRoommate()
    {
        context.Scenes.RunScene(new RoommateSelectionScene(context));
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
                    context.Scenes.RunScene(new StudyScene(context));
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
        context.Player.Money += 20;
        context.Player.Entropy -= 10;

        Console.WriteLine("You worked.");

        AdvanceTime();
    }

    private void Socialize()
    {
        context.Player.Entropy += 15;

        Console.WriteLine("You socialized.");

        AdvanceTime();
    }

    private void Sleep()
    {
        context.Player.Entropy += 10;

        if (context.Player.Entropy > 100)
            context.Player.Entropy = 100;

        Console.WriteLine("You slept.");

        while (context.Player.Time != TimeOfDay.Morning)
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
        Console.WriteLine($"Academic: {context.Player.Academic}");
        Console.WriteLine($"Entropy: {context.Player.Entropy}");
        Console.WriteLine($"Money: {context.Player.Money}");
        Console.WriteLine($"Day: {context.Player.Day}");
        Console.WriteLine($"Time: {context.Player.Time}");
    }

    private void ShowDayHeader()
    {
        Console.WriteLine("\n====================");
        Console.WriteLine($"DAY {context.Player.Day}");
        Console.WriteLine(context.Player.Time);
        Console.WriteLine("====================");
    }

    private void AdvanceTime()
    {
        switch (context.Player.Time)
        {
            case TimeOfDay.Morning:
                context.Player.Time = TimeOfDay.Afternoon;
                break;

            case TimeOfDay.Afternoon:
                context.Player.Time = TimeOfDay.Evening;
                break;

            case TimeOfDay.Evening:
                context.Player.Time = TimeOfDay.Night;
                break;

            case TimeOfDay.Night:
                context.Player.Time = TimeOfDay.Morning;
                context.Player.Day++;
                break;
        }
    }
}