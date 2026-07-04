using System;

public class Game
{
    private Player player = new Player();

    public void Start()
    {
        Console.WriteLine("Welcome to Mihu Academy!");

        CreatePlayer();

        GameLoop();
    }

    private void CreatePlayer()
    {
        Console.Write("Enter your name: ");
        player.Name = Console.ReadLine() ?? "";

        Console.WriteLine($"Welcome, {player.Name}!");
    }

    private void GameLoop()
    {
        while (true)
        {
            Console.WriteLine($"\n-- DAY {player.Day} --");

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
                    return;

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
        player.Entropy -=5;

        Console.WriteLine("You studied with Mihu.");
    }

    private void ShowMenu()
    {
            Console.WriteLine("1. Study with Mihu");
            Console.WriteLine("2. Work");
            Console.WriteLine("3. Socialize");
            Console.WriteLine("4. Sleep");
            Console.WriteLine("5. Exit");
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
        player.Day++;

        Console.WriteLine("You slept.");
    }

    private void ShowStats()
    {
        Console.WriteLine();
        Console.WriteLine($"Academic: {player.Academic}");
        Console.WriteLine($"Entropy: {player.Entropy}");
        Console.WriteLine($"Money: {player.Money}");
        Console.WriteLine($"Day: {player.Day}");
    }
}