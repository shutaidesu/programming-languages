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

public record CheckLeapResult(
    int Year,
    bool IsLeap
);

public class CheckLeapViewModel : ViewModelBase
{
    private int? _selectedYear = 2024;

    public ReactiveCommand<Unit, int?> OkCommand { get; }
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }

    public CheckLeapViewModel()
    {
        ShowLeapResultDialog = new Interaction<CheckLeapResult, int?>();
        IObservable<bool> isValidObservable = this.WhenAnyValue(
            x => x.SelectedYear).Select(x =>
            {
                if (x.Value < 1 || x.Value > 9999) return false;

                return true;
            });

        OkCommand = ReactiveCommand.Create(
            () => SelectedYear, isValidObservable);
        CancelCommand = ReactiveCommand.Create(() => { });

        OkCommand
            .Subscribe(async year =>
            {
                if (year != null)
                {
                    var isLeap = (int)year % 4 == 0;
                    var result =  await ShowLeapResultDialog.Handle(new CheckLeapResult((int)year, isLeap));
                }
            });
    }

    public int? SelectedYear
    {
        get => _selectedYear;
        set => this.RaiseAndSetIfChanged(ref _selectedYear, value);
    }

    public Interaction<CheckLeapResult, int?> ShowLeapResultDialog { get; }
}
