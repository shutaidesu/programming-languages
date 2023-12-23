namespace Lab2;

public class CalcCommand : Command
{
    public CalcCommand() : base("calc", "calc interval length")
    {
    }

    public override void Execute()
    {
        // Reading FROM
        Console.Write("Input ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("From Date");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(".\n");
        var dateFrom = IOUtils.ReadDate();

        Console.Write("\n");

        // Reading TO
        Console.Write("Input ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("To Date");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(".\n");
        var dateTo = IOUtils.ReadDate();

        Console.Write("\n");

        // Result
        var differenceDays = (dateTo - dateFrom).TotalDays;
        Console.Write("Between these dates ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("{0}", differenceDays);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" days.\n");
    }
}