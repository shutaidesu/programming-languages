namespace Lab2;

public static class Application
{
    private static CommandManager commandManager;

    static Application()
    {
        commandManager = new CommandManager();
        commandManager.RegisterCommand(new CheckCommand());
        commandManager.RegisterCommand(new CalcCommand());
        commandManager.RegisterCommand(new DayCommand());
        commandManager.RegisterCommand(new QuitCommand());
    }

    public static void Run()
    {
        commandManager.Listen();
    }
}