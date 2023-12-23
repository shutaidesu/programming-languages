namespace Lab3;

public class HistoryCommand : Command<HistoryEntity>
{
    public HistoryCommand() : base("history", "review the history of commands")
    {
    }

    public override HistoryEntity Execute()
    {
        var entities = Application.DataManagement.GetHistory().ToArray();

        for (int i = 1; i <= entities.Length; i++)
        {
            var entity = entities[i - 1];
            Console.WriteLine("{0}. {1}", i, entity.Command);
            Console.WriteLine("{0}", entity.Message);
            Console.WriteLine("{0}  \n", entity.DateTime.ToString("dd.MM.yyyy HH:mm:ss"));
        }

        return new HistoryEntity(this, "History viewed.");
    }
}