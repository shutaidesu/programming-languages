namespace Lab3;

public class HistoryEntity
{
    private DateTime dateTime;

    private string command;

    private string message;

    public DateTime DateTime { get => dateTime; set => dateTime = value; }
    
    public string Command { get => command; set => command = value; }
    
    public string Message { get => message; set => message = value; }

    public HistoryEntity(Command<HistoryEntity> command, string message)
    {
        this.Command = command.Name;
        this.Message = message;
        DateTime = DateTime.Now;
    }

    public HistoryEntity()
    {
        Command = null;
        Message = null;
        DateTime = DateTime.Now;
    }
}