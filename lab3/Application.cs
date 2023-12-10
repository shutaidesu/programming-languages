namespace Lab3;

public static class Application
{
    private static readonly CommandManager commandManager;

    private static readonly IDataManagement dataManagement;

    private static bool isRunning = false;

    static Application()
    {
        dataManagement = new DataManagement();
        commandManager = new CommandManager();
        commandManager.RegisterCommand(new CheckCommand());
        commandManager.RegisterCommand(new CalcCommand());
        commandManager.RegisterCommand(new DayCommand());
        commandManager.RegisterCommand(new QuitCommand());
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