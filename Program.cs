using System;
using System.Security;

class Program
{
    static void Main()
    {
        Player player = new Player();

        Console.WriteLine("Welcome to Mihu Academy");

        while(true)
        {
            Console.WriteLine("\n --NEW DAY--");

            Console.WriteLine("1. Study with Mihu");
            Console.WriteLine("2. Work");
            Console.WriteLine("3. Socialize");
            Console.WriteLine("4. Sleep");
            Console.WriteLine("5. Exit")

            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                player.Academic += 10;
                player.Entropy -= 5;
                Console.WriteLine("You studied with Mihu");
                break;

                case "2":
                player.Money += 20;
                player.Entropy -=10;
                Console.WriteLine("You worked.");
                break;

                case "3":
                player.Entropy += 15;
                Console.WriteLine("You socialized.");
                break;

                case "4":
                player.Entropy +=10;
                Console.WriteLine("You slept.");
                break;

                case "5":
                return;
            }

            Console.WriteLine($"Academic: {player.Academic}");
            Console.WriteLine($"Entropy: {player.Entropy}");
            Console.WriteLine($"Money: {player.Money}");
        }
    }
}