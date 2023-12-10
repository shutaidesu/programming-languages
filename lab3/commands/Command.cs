namespace Lab3;

public abstract class Command<T>
{
    private static int lastOrderNumber = 0;

    private readonly string name;

    private readonly string description;

    public string Name => name;

    public string Description => description;

    public Command(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    abstract public T Execute();

    public void PrintHelp(int index)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("{0}", index);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("] ");
        Console.ForegroundColor = Constants.CommandColor;
        Console.Write("{0,-8}", name);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" {0}.\n", description);
    }

    public bool IsMatch(string request)
    {
        if (request == name) return true;

        return false;
    }
}