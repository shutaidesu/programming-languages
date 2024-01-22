using Avalonia.Controls;
using Avalonia.ReactiveUI;
using lab5.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lab5.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(action =>
                action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        }
        private async Task DoShowDialogAsync(InteractionContext<CheckLeapViewModel,
                                                int?> interaction)
        {
            var dialog = new CheckLeapWindow();
            dialog.DataContext = interaction.Input;

            var result = await dialog.ShowDialog<int?>(this);
            interaction.SetOutput(result);
        }
    }

}