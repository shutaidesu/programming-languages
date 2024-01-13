using System.Collections.ObjectModel;

namespace lab5.Models;

public class CalendarYear
{
    public ObservableCollection<CalendarMonth>? Months { get; }
    public string Year { get; }

    public CalendarYear(string year)
    {
        Year = year;
    }

    public CalendarYear(string year, ObservableCollection<CalendarMonth> months)
    {
        Year = year;
        Months = months;
    }

}
