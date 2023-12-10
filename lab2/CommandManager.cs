using System.Xml.Linq;

namespace Lab2;

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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}", request);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" не найдена.\n");
            }
        }
    }

    public string ReadRequest()
    {
        Console.Write(">>> ");
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
}