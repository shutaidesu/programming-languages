using lab5.Models;
using lab5.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace lab5.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;

    public MainWindowViewModel()
    {
        var yearListService = new YearListService();
        YearList = new CalendarViewModel();
        _contentViewModel = YearList;
    }
    public CalendarViewModel YearList { get; }

    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public void AddMonth()
    {
        AddMonthViewModel addItemViewModel = new();

        IObservable<YearAndMonth?> observable = Observable.Merge(
            addItemViewModel.OkCommand,
            addItemViewModel.CancelCommand.Select(_ => (YearAndMonth?)null)
        );
        observable
            .Take(1)
            .Subscribe(newMonth =>
            {
                if (newMonth != null)
                {
                    var calendarYear = YearListService.FindOrCreateCalendarYear(newMonth.Year);
                    var calendarMonth = YearListService.CreateCalendarMonth(newMonth.Year, newMonth.Month);
                    YearListService.InsertCalendarMonth(calendarYear, calendarMonth);
                }
                ContentViewModel = YearList;
            });

        ContentViewModel = addItemViewModel;
    }
}
