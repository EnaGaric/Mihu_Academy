using System;

public class Game
{
    private Player player = new Player();
    private CharacterManager characterManager = new CharacterManager();
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
    }

    private void Socialize()
    {
        player.Entropy += 15;

        Console.WriteLine("You socialized.");
    }

    private void Sleep()
    {
        player.Entropy += 10;

        if (player.Entropy > 100)
            player.Entropy = 100;

        player.Day++;

        Console.WriteLine("You slept.");
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
    }

    private void ShowDayHeader()
    {
        Console.WriteLine("\n====================");
        Console.WriteLine($"DAY {player.Day}");
        Console.WriteLine("====================");
    }
}