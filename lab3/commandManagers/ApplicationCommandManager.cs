namespace Lab3;

internal class ApplicationCommandManager : CommandManager<HistoryEntity>
{
    public void Listen()
    {
        PrintHelp();

        while (Application.IsRunning)
        {
            HandleRequest();
        }
    }

    public void HandleRequest()
    {
        var request = ReadRequest();
        try
        {
            var command = HandleCommand(request);
            var historyEntity = command.Execute();
            Application.DataManagement.AddHistoryEntity(historyEntity);
        }
        catch (NotExistCommandException)
        {
            WarnNotFoundCommand(request);
        }
    }
}