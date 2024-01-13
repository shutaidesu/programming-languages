using lab5.Models;
using lab5.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.ViewModels;

public class YearAndMonth
{
    public int Year { get; set; }
    public Month Month { get; set; }
}

public class AddMonthViewModel : ViewModelBase
{
    private Month _selectedMonth = Month.January;

    private int? _selectedYear = 2024;

    public ReactiveCommand<Unit, YearAndMonth> OkCommand { get; }
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }

    public AddMonthViewModel()
    {
        IObservable<bool> isValidObservable = this.WhenAnyValue(
            x => x.SelectedYear,
            x => x.SelectedMonth).Select(x =>
            {
                if (x.Item1 == null) return false;
                int year = (int)x.Item1;
                CalendarYear calendarYear = YearListService.FindCalendarYear(year);
                if (calendarYear == null) return true;
                if (1 <= x.Item1 && x.Item1 <= 9999)
                {
                    return !YearListService.HasMonth(calendarYear, (Month)x.Item2);
                }
                return false;
            });

        OkCommand = ReactiveCommand.Create(
            () => new YearAndMonth { Year = (int)(SelectedYear != null ? SelectedYear : 0), Month = SelectedMonth }, isValidObservable);
        CancelCommand = ReactiveCommand.Create(() => { });
    }

    public Month SelectedMonth
    {
        get => _selectedMonth;
        set => this.RaiseAndSetIfChanged(ref _selectedMonth, value);
    }

    public int SelectedMonthIndex
    {
        get => (int)SelectedMonth - 1;
        set => SelectedMonth = (Month)value + 1;
    }

    public int? SelectedYear
    {
        get => _selectedYear;
        set => this.RaiseAndSetIfChanged(ref _selectedYear, value);
    }
}
