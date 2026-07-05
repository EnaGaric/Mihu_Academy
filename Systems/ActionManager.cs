using System;
using System.Collections.Generic;

public class ActionManager
{
    private List<GameAction> actions = new List<GameAction>();

    public ActionManager()
    {
        actions.Add(new GameAction
        {
            Name = "Study with Mihu",
            TimeCost = 1
        });

        actions.Add(new GameAction
        {
            Name = "Work",
            TimeCost = 2
        });

        actions.Add(new GameAction
        {
            Name = "Socialize",
            TimeCost = 1
        });

        actions.Add(new GameAction
        {
            Name = "Sleep",
            TimeCost = 1
        });
    }

    public void ShowActions()
    {
        for(int i = 0; i < actions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {actions[i].Name}");
        }
    }
}