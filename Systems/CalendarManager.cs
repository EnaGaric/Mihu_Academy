using System;

public class CalendarManager
{
    public int Day = 1;

    public TimeOfDay Time = TimeOfDay.Morning;

    public void AdvanceDay()
    {
        Day++;
        Time = TimeOfDay.Morning;
    }

    public void AdvanceTime()
    {
        Time = Time switch
        {
            TimeOfDay.Morning => TimeOfDay.Afternoon,
            TimeOfDay.Afternoon => TimeOfDay.Evening,
            TimeOfDay.Evening => TimeOfDay.Night,
            TimeOfDay.Night => TimeOfDay.Morning
        };

        if (Time == TimeOfDay.Morning)
            Day++;
    }
}