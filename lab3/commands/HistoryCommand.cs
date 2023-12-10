namespace Lab3;

public class HistoryCommand : Command
{
    public HistoryCommand() : base("history", "review the history of commands")
    {
    }

    public override HistoryEntity Execute()
    {
        throw new NotImplementedException();

        return new HistoryEntity(this, "History viewed.");
    }
}