namespace Lab2;

public abstract class Command
{
    private static int lastOrderNumber = 0;

    private readonly string name;

    private readonly string description;

    private readonly int orderNumber;

    public string Name => name;

    public string Description => description;

    public Command(string name, string description)
    {
        this.name = name;
        this.description = description;
        this.orderNumber = ++lastOrderNumber;
    }

    abstract public void Execute();

    public void PrintHelp()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("{1}", name, orderNumber);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("] ");
        Console.ForegroundColor = Constants.CommandColor;
        Console.Write("{0,-8}", name, orderNumber);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" {0}.\n", description);
    }

    public bool IsMatch(string request)
    {
        if (request == name) return true;
        if (request == orderNumber.ToString()) return true;

        return false;
    }
}