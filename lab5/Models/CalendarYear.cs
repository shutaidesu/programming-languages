using System.Collections.ObjectModel;
using System.Linq;

namespace lab5.Models;

public class CalendarYear : CalendarNode
{
    public ObservableCollection<CalendarMonth> Months { get; }
    public int Year { get; }

    public CalendarYear(int year, ObservableCollection<CalendarMonth> months) : base(months.First().Weeks.First().Days.First().DateTime)
    {
        Year = year;
        Months = months;
    }
}
