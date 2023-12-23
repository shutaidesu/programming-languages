namespace Lab2;

public class DayCommand : Command
{
    public DayCommand() : base("day", "get the name of weekday")
    {
    }

    public override void Execute()
    {
        var date = IOUtils.ReadDate();
        var dayOfWeek = date.DayOfWeek;
        Console.Write("{0} is ", date.ToString("dd.MM.yyyy"));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("{0}", dayOfWeek.ToString());
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(".\n");
    }
}