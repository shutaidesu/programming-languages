using System.Xml.Linq;

namespace Lab3;

public class NotExistCommandException : Exception { }

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
        PrintHelp();

        while (Application.IsRunning)
        {
            var request = ReadRequest();
            try
            {
                var command = HandleCommand(request);
                command.Execute();
            }
            catch (NotExistCommandException)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Команда ");
                Console.ForegroundColor = Constants.CommandColor;
                Console.Write("{0}", request);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" не найдена.\n");
            }
        }
    }

    public string ReadRequest()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(">>> ");
        Console.ForegroundColor = ConsoleColor.White;
        return Console.ReadLine().Trim();
    }

    public Command HandleCommand(string request)
    {
        foreach (var command in commands)
        {
            if (command.IsMatch(request))
            {
                return command;
            }
        }

        throw new NotExistCommandException();
    }

    public void PrintHelp()
    {
        Console.Write("+--- Help -------------------------------+ \n\n");
        foreach (var command in commands)
        {
            command.PrintHelp();
        }
        Console.Write("\n+----------------------------------------+ \n\n");
    }
}