using lab5.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.ViewModels;

public class CalendarViewModel : ViewModelBase
{
    public ObservableCollection<CalendarYear> Years { get; }

    public CalendarViewModel(IEnumerable<CalendarYear> items)
    {
        Years = new ObservableCollection<CalendarYear>(items);
    }
}
