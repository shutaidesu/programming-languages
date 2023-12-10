namespace Lab3;

public class LoadCommand : Command
{
    public LoadCommand() : base("save", "load the history from file")
    {
    }

    public override HistoryEntity Execute()
    {
        throw new NotImplementedException();

        return new HistoryEntity(this, "Loaded.");
    }
}