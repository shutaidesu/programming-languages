using System;

namespace lab5.Models;

public class CalendarDay : CalendarNode
{
    public CalendarDay(DateTime dateTime) : base(dateTime)
    {
    }

    public override string ToString()
    {
        return DateTime.Day + " " + DateTime.DayOfWeek;
    }

}
