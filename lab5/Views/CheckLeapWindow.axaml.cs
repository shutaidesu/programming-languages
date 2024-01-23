using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using lab5.ViewModels;
using ReactiveUI;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System;

namespace lab5.Views;

public partial class CheckLeapWindow : ReactiveWindow<CheckLeapViewModel>
{
    public CheckLeapWindow()
    {
        InitializeComponent();
        this.WhenActivated(action =>
            action(ViewModel!.ShowLeapResultDialog.RegisterHandler(DoShowLeapResultDialogAsync)));
        this.WhenActivated(d => d(ViewModel!.CancelCommand.Subscribe((obj) => Close())));
    }
    private async Task DoShowLeapResultDialogAsync(InteractionContext<CheckLeapResult,
                                            int?> interaction)
    {
        var isLeap = interaction.Input.IsLeap;
        var year = interaction.Input.Year;

        var text = isLeap ? year + " year is leap." : year + " year is not leap.";

        await MessageBox.Show(this, text, "Check Year is Leap", MessageBox.MessageBoxButtons.Ok);

        interaction.SetOutput(null);
    }
}