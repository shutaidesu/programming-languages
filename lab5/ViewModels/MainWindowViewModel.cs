using lab5.Models;
using lab5.Services;
using lab5.Views;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows.Input;

namespace lab5.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;

    public MainWindowViewModel()
    {
        YearList = new CalendarViewModel();
        _contentViewModel = YearList;
        ShowDialog = new Interaction<CheckLeapViewModel, int?>();

        CheckLeapCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var checkLeapViewModel = new CheckLeapViewModel();
            var result = await ShowDialog.Handle(checkLeapViewModel);
        });
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
                    var calendarMonth = YearListService.CreateCalendarMonth(newMonth.Year, newMonth.Month);
                    var calendarYear = YearListService.FindOrCreateCalendarYear(newMonth.Year, calendarMonth);
                }
                ContentViewModel = YearList;
            });

        ContentViewModel = addItemViewModel;
    }

    public ICommand CheckLeapCommand { get; }

    public Interaction<CheckLeapViewModel, int?> ShowDialog { get; }


}
