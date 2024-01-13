using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Models;

//public class Month
//{
//    public Month(string name, )
//    {

//    }
//}

//January - 31 days
//February - 28 days in a common year and 29 days in leap years
//March - 31 days
//April - 30 days
//May - 31 days
//June - 30 days
//July - 31 days
//August - 31 days
//September - 30 days
//October - 31 days
//November - 30 days
//December - 31 days

public enum Month
{
    January,
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


public class CalendarMonth
{
    public ObservableCollection<CalendarWeek>? Weeks { get; }
    public Month Month { get; }

    public CalendarMonth(Month month)
    {
        Month = month;
    }

    public CalendarMonth(Month month, ObservableCollection<CalendarWeek> weeks)
    {
        Month = month;
        Weeks = weeks;
    }
}
