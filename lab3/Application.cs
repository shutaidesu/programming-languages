namespace Lab3;

public static class Application
{
    private static readonly ApplicationCommandManager commandManager;

    private static readonly IDataManagement dataManagement;

    private static bool isRunning = false;

    static Application()
    {
        dataManagement = new DataManagement();
        commandManager = new ApplicationCommandManager();
        commandManager.RegisterCommand(new CheckCommand());
        commandManager.RegisterCommand(new CalcCommand());
        commandManager.RegisterCommand(new DayCommand());
        commandManager.RegisterCommand(new QuitCommand());
        commandManager.RegisterCommand(new LoadCommand());
        commandManager.RegisterCommand(new SaveCommand());
        commandManager.RegisterCommand(new HistoryCommand());
    }

    public static bool IsRunning { get => isRunning; }

    public static IDataManagement DataManagement => dataManagement;

    public static void Run()
    {
        isRunning = true;
        commandManager.Listen();
    }

    public static void Stop()
    {
        isRunning = false;
    }
}