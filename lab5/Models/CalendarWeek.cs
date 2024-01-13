using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Models;

public class CalendarWeek
{
    public string Week { get; }
    public ObservableCollection<CalendarDay> Days { get; }

    public CalendarWeek(int number, ObservableCollection<CalendarDay> days)
    {
        Week = "Week " + number;
        Days = days;
    }
}
