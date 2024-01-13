using System;

namespace lab5.Models;

public class CalendarDay
{
     public DateTime DateTime { get; }

    public CalendarDay(DateTime dateTime)
    {
        DateTime = dateTime;
    }

    public override string ToString()
    {
        return DateTime.Day + " " + DateTime.DayOfWeek;
    }

}
