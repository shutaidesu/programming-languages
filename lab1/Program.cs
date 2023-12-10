namespace Lab1;

internal class Program
{

    public const int MatrixRows = 8;
    public const int MatrixColumns = 8;

    static void Main(string[] args)
    {
        Console.WriteLine("Часть 1:");

        try
        {
            int length = IOUtils.ReadPositiveInt("Введите размер массива: ");

            var arrayManipulator = new ArrayManipulator(length);
            arrayManipulator.ProcessData();
            arrayManipulator.PrintResult();
        }
        catch (InterruptionException)
        {
            Console.WriteLine("Выполнение Части 1 прервано.");
        }


        Console.WriteLine("Часть 2:");

        var matrixManipulator = new MatrixManipulator(MatrixRows, MatrixColumns);
        matrixManipulator.ProcessData();
        matrixManipulator.PrintResult();
    }
}