namespace Lab2;

internal class CommandManager
{
    List<Command> commands = new List<Command>();

    public CommandManager()
    {

    }

    public void RegisterCommand(Command command)
    {
        commands.Add(command);
    }

    public void Listen()
    {
        throw new NotImplementedException();
    }
}