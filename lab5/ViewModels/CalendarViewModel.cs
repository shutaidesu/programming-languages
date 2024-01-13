using lab5.Models;
using lab5.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.ViewModels;

public class CalendarViewModel : ViewModelBase
{
    public ObservableCollection<CalendarYear> Years
    {
        get
        {
            return YearListService.Years;
        }
    }

    public CalendarViewModel() { }
}
