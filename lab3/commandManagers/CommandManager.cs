namespace Lab3;

public class NotExistCommandException : Exception { }

internal class CommandManager<T>
{
    List<Command<T>> commands = new List<Command<T>>();

    public CommandManager()
    {

    }

    public void RegisterCommand(Command<T> command)
    {
        commands.Add(command);
    }

    protected void WarnNotFoundCommand(string request)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Команда ");
        Console.ForegroundColor = Constants.CommandColor;
        Console.Write("{0}", request);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" не найдена.\n");
    }

    public virtual void WriteRequestInputPrefix()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(">>> ");
    }

    public string ReadRequest()
    {
        WriteRequestInputPrefix();
        Console.ForegroundColor = ConsoleColor.White;
        return Console.ReadLine().Trim();
    }

    public Command<T> HandleCommand(string request)
    {
        for (int i = 1; i <= commands.Count; i++)
        {
            var command = commands[i-1];
            if ((command.IsMatch(request)) || (request == i.ToString()))
            {
                return command;
            }
        }

        throw new NotExistCommandException();
    }

    public void PrintHelp()
    {
        Console.Write("+--- Help -------------------------------+ \n\n");
        for (int i = 1; i <= commands.Count; i++)
        {
            commands[i-1].PrintHelp(i);
        }
        Console.Write("\n+----------------------------------------+ \n\n");
    }
}