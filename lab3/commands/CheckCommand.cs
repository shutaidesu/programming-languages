namespace Lab3;

public class CheckCommand : Command<HistoryEntity>
{
    public CheckCommand() : base("check", "check if a year is leap")
    {
    }

    public override HistoryEntity Execute()
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

                return new HistoryEntity(this, string.Format("{0} is leap.", year));
            }
            else
            {
                Console.Write("The {0} ", year);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("is not");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" leap.\n");

                return new HistoryEntity(this, string.Format("{0} is not leap.", year));
            }

        }
        catch (InterruptionException)
        {
            Console.WriteLine("Ввод прерван.");
            return new HistoryEntity(this, "Ввод прерван.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new HistoryEntity(this, ex.Message);
        }
    }
}