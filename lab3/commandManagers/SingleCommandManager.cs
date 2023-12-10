namespace Lab3;

internal class SingleCommandManager<T> : CommandManager<T>
{
    public T Run()
    {
        PrintHelp();

        while (true)
        {
            var request = ReadRequest();
            try
            {
                var command = HandleCommand(request);
                return command.Execute();
            }
            catch (NotExistCommandException)
            {
                WarnNotFoundCommand(request);
            }
        }
    }

    public override void WriteRequestInputPrefix()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("  > ");
    }
}