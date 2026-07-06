using System;
using System.Collections.Generic;

public class EventManager
{
    private GameContext context;

    public EventManager(GameContext context)
    {
        this.context = context;
    }

    public void CheckEvents()
    {
        if (context.Flags.Has(GameFlag.MetMihu)
            && context.Calendar.Day >= 2
            && context.Calendar.Time == TimeOfDay.Morning)
        {
            TriggerMihuEvent();
        }
    }

    private void TriggerMihuEvent()
    {
        Console.WriteLine("Mihu notices your progress...");

        // kasnije: context.Scenes.RunScene(new MihuEventScene(context));
    }
}