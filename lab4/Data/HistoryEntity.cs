using System.ComponentModel.DataAnnotations;

namespace lab4.Data;

public class HistoryEntity
{
    private Guid _id;
    [Key]
    public Guid Id
    {
        get { return _id; }
        private set { _id = value; }
    }

    private DateTime dateTime;

    private Command? command;

    private string? message;

    public DateTime DateTime { get => dateTime; set => dateTime = value; }

    public Command? Command { get => command; set => command = value; }

    public string? Message
    {
        get => message; set => message = value;
    }

    public HistoryEntity(Command command, string message, DateTime dateTime)
    {
        Command = command;
        Message = message;
        DateTime = dateTime;
    }

    public HistoryEntity(Command command, string message)
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