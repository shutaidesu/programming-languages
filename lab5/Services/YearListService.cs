using lab5.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab5.Services;

public class YearListService
{
    public IEnumerable<CalendarYear> GetItems() => new[]
    {
        new CalendarYear("2001", new ObservableCollection<CalendarMonth>
        {
            new CalendarMonth(Month.January, new ObservableCollection<CalendarWeek>
            {
                new CalendarWeek(1, new ObservableCollection<CalendarDay>
                {
                    new CalendarDay(1),
                    new CalendarDay(2),
                    new CalendarDay(3),
                    new CalendarDay(4),
                })
            })
        })
    };
}