namespace Lab2;

public static class Application
{
    private static CommandManager commandManager;

    private static bool isRunning = false;

    static Application()
    {
        commandManager = new CommandManager();
        commandManager.RegisterCommand(new CheckCommand());
        commandManager.RegisterCommand(new CalcCommand());
        commandManager.RegisterCommand(new DayCommand());
        commandManager.RegisterCommand(new QuitCommand());
    }

    public static bool IsRunning { get => isRunning; }

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