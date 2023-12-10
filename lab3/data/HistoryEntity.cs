namespace Lab3;

public class HistoryEntity
{
    public readonly DateTime dateTime;

    public readonly Command command;

    public readonly string message;

    public HistoryEntity(Command command, string message)
    {
        this.command = command;
        this.message = message;
        dateTime = DateTime.Now;
    }
}