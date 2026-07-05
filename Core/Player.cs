using System;

public class Player
{
    public string Name = "";

    public int Academic = 50;
    public int MihuFriendship = 0;
    public int Entropy = 80;
    public int Money = 200;
    public int Day = 1;
    public TimeOfDay Time = TimeOfDay.Morning;
    public CharacterType RoommateChoice = CharacterType.None;
    public int RoommateAffection = 0;
    public CharacterType ActiveRoute = CharacterType.None;
}