using lab5.Services;

namespace lab5.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    public MainWindowViewModel()
    {
        var yearListService = new YearListService();
        YearList = new CalendarViewModel(yearListService.GetItems());
    }
    public CalendarViewModel YearList { get; }
}
