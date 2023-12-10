namespace Lab3;

public class SaveCommand : Command
{
    public SaveCommand() : base("save", "save the history to file")
    {
    }

    public override HistoryEntity Execute()
    {
        throw new NotImplementedException();

        return new HistoryEntity(this, "Saved.");
    }
}