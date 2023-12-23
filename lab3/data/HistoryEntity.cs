namespace Lab3;

public class HistoryEntity
{
    private DateTime dateTime;

    private string command;

    private string message;

    public DateTime DateTime { get => dateTime; set => dateTime = value; }

    public string Command { get => command; set => command = value; }

    public string Message
    {
        get => message; set => message = value;
    }

    public HistoryEntity(Command<HistoryEntity> command, string message, DateTime dateTime)
    {
        Command = command.Name;
        Message = message;
        DateTime = dateTime;
    }

    public HistoryEntity(string command, string message, DateTime dateTime)
    {
        Command = command;
        Message = message;
        DateTime = dateTime;
    }

    public HistoryEntity(Command<HistoryEntity> command, string message)
    {
        Command = command.Name;
        Message = message;
        DateTime = DateTime.Now;
    }

    public HistoryEntity(string command, string message)
    {
        Command = command;
        Message = message;
        DateTime = DateTime.Now;
    }

    public HistoryEntity()
    {
        Command = null;
        Message = null;
        DateTime = DateTime.Now;
    }
}