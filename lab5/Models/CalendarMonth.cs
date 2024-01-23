using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Models;

public enum Month
{
    January = 1,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December,
}


public class CalendarMonth : CalendarNode
{
    public ObservableCollection<CalendarWeek> Weeks { get; }
    public Month Month { get; }

    public CalendarMonth(Month month, ObservableCollection<CalendarWeek> weeks) : base(weeks.First().Days.First().DateTime)
    {

        Month = month;
        Weeks = weeks;
    }
}
