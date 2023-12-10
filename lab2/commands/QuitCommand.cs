namespace Lab2;

public class QuitCommand : Command
{
    public QuitCommand() : base("quit", "exit the program")
    {
    }

    public override void Execute()
    {
        throw new NotImplementedException();
    }
}