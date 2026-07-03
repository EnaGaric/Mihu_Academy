using System;

public class Player
{
    public string Name;

    public int Academic = 50;
    public int Entropy = 80;
    public int Money = 200;

    public Player()
    {
        Console.Write("Enter your name: ");
        Name = Console.ReadLine();
    }
}