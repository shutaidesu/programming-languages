namespace Lab3;

public class QuitCommand : Command
{
    public QuitCommand() : base("quit", "exit the program")
    {
    }

    public override void Execute()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Stopping...");
        Console.ForegroundColor = ConsoleColor.White;
        Application.Stop();
    }
}