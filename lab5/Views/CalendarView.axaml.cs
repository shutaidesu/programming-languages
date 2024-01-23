using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.VisualTree;
using lab5.ViewModels;
using ReactiveUI;
using System;
using System.Threading.Tasks;

namespace lab5.Views;

public partial class CalendarView : ReactiveUserControl<CalendarViewModel>
{
    public CalendarView()
    {
        InitializeComponent();
        this.WhenActivated(action =>
            action(ViewModel!.ShowRangeDialog.RegisterHandler(DoShowRangeDialogAsync)));
        this.WhenActivated(action =>
            action(ViewModel!.ShowRangeErrorDialog.RegisterHandler(DoShowRangeErrorDialogAsync)));
    }
    private async Task DoShowRangeDialogAsync(InteractionContext<TimeSpan,
                                            int?> interaction)
    {
        var text = "Selected range is " + Math.Abs(interaction.Input.TotalDays) + " days.";

        Window window = null;

        await MessageBox.Show(window, text, "Range Selection", MessageBox.MessageBoxButtons.Ok);

        interaction.SetOutput(null);
    }
    private async Task DoShowRangeErrorDialogAsync(InteractionContext<int,
                                            int?> interaction)
    {
        var text = "Should be selected only 2 days. Now selected " + interaction.Input + ".";

        Window window = null;

        await MessageBox.Show(window, text, "Range Selection Error", MessageBox.MessageBoxButtons.Ok);

        interaction.SetOutput(null);
    }
}