namespace Lab3;

public class DayCommand : Command<HistoryEntity>
{
    public DayCommand() : base("day", "get the name of weekday")
    {
    }

    public override HistoryEntity Execute()
    {
        var date = IOUtils.ReadDate();
        var dayOfWeek = date.DayOfWeek;
        Console.Write("{0} is ", date.ToString("dd.MM.yyyy"));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("{0}", dayOfWeek.ToString());
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(".\n");

        return new HistoryEntity(this, string.Format("{0} is {1}.", date.ToString("dd.MM.yyyy"), dayOfWeek.ToString()));
    }
}