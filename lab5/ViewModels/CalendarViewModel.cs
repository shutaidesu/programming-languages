using DynamicData;
using lab5.Models;
using lab5.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.ViewModels;

public class CalendarViewModel : ViewModelBase
{

    public ObservableCollection<CalendarNode> SelectedNodes { get; }

    public ObservableCollection<CalendarYear> Years
    {
        get
        {
            return YearListService.Years;
        }
    }

    public CalendarViewModel()
    {
        ShowRangeErrorDialog = new Interaction<int, int?>();
        ShowRangeDialog = new Interaction<TimeSpan, int?>();
        SelectedNodes = new ObservableCollection<CalendarNode>();
    }

    public async void CalculateRange()
    {
        if (SelectedNodes.Count != 2)
        {
            await ShowRangeErrorDialog.Handle(SelectedNodes.Count);
        }
        else
        {
            var range = SelectedNodes.First().DateTime - SelectedNodes.Last().DateTime;
            await ShowRangeDialog.Handle(range);
        }
    }

    public Interaction<int, int?> ShowRangeErrorDialog { get; }
    public Interaction<TimeSpan, int?> ShowRangeDialog { get; }
}
