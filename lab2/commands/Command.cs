namespace Lab2;

public abstract class Command
{
    private readonly string name;

    private readonly string description;

    public string Name => name;

    public string Description => description;

    public Command(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    abstract public void Execute();

    public void PrintHelp()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("%s.", name);
        Console.ResetColor();
        Console.Write(" %s.", description);
    }
}