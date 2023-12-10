namespace Lab3;

public class CheckCommand : Command
{
    public CheckCommand() : base("check", "check if a year is leap")
    {
    }

    public override void Execute()
    {
        try
        {
            var year = IOUtils.ReadPositiveInt("Input year: ");
            if (year % 4 == 0)
            {
                Console.Write("The {0} ", year);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("is");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" leap.\n");
            }
            else
            {
                Console.Write("The {0} ", year);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("is not");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" leap.\n");
            }
        }
        catch (InterruptionException)
        {
            Console.WriteLine("Ввод прерван.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}