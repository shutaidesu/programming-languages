namespace Lab1;

internal class Program
{

    public const int MatrixRows = 8;
    public const int MatrixColumns = 8;

    static void Main(string[] args)
    {
        Console.WriteLine("Часть 1:");

        int length = IOUtils.ReadInt("Введите размер массива: ");

        var arrayManipulator = new ArrayManipulator(length);
        arrayManipulator.ProcessData();
        arrayManipulator.PrintResult();


        Console.WriteLine("Часть 2:");

        var matrixManipulator = new MatrixManipulator(MatrixRows, MatrixColumns);
        matrixManipulator.ProcessData();
        matrixManipulator.PrintResult();
    }
}