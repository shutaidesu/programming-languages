using System.Collections.ObjectModel;

namespace lab5.Models;

public class CalendarYear
{
    public ObservableCollection<CalendarMonth> Months { get; }
    public int Year { get; }

    public CalendarYear(int year, ObservableCollection<CalendarMonth> months)
    {
        Year = year;
        Months = months;
    }
}
