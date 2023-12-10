namespace Lab1;

public class ArrayManipulator : IManipulator
{

    public int IndexOfMaximum
    {
        get { return indexOfMaximum; }
    }

    public int ProductBetweenZeroes
    {
        get { return productBetweenZeroes; }
    }

    private readonly int[] array;

    private int indexOfMaximum;

    private int productBetweenZeroes;

    public ArrayManipulator(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        array = new int[length];

        FillWithRandomValues();
    }

    public void FillWithRandomValues()
    {
        var random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(Constants.MinRandomValue, Constants.MaxRandomValue);
        }

        Console.WriteLine("Массив заполнен случайными числами: ");
        IOUtils.PrintIntArray(array);
    }

    public void PrintResult()
    {
        Console.WriteLine("\n== Part 01. Results. =======\n");
        Console.WriteLine("Индекс максимального элемента: " + indexOfMaximum);
        Console.WriteLine("Произведение элементов между первыми двумя нулевыми: " + productBetweenZeroes);
        Console.WriteLine("Обработанный массив: ");
        IOUtils.PrintIntArray(array);
        Console.WriteLine("\n== Part 01. Results End. ===\n");
    }

    public void ProcessData()
    {
        indexOfMaximum = GetIndexOfMaximum();
        productBetweenZeroes = CalculateProductBetweenFirstZeroes();
        SortArrayOddEvenIndexes();
    }

    private int GetIndexOfMaximum()
    {
        int indexOfMaximum = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[indexOfMaximum])
            {
                indexOfMaximum = i;
            }
        }

        return indexOfMaximum;
    }

    private (int first, int second) GetIndexesOfFirstTwoZeroes()
    {
        int firstIndex = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == 0)
            {
                if (firstIndex == -1)
                {
                    firstIndex = i;
                }
                else
                {
                    int secondIndex = i;
                    if (secondIndex == firstIndex + 1)
                    {
                        throw new ArgumentException("Между первыми двумя нулевыми элементами массива должно быть хотя бы одно ненулевое число.");
                    }
                    return (first: firstIndex, second: secondIndex);
                }
            }
        }

        throw new ArgumentException("В массиве должно быть хотя бы два нулевых значения.");
    }

    private int CalculateProductOfRange(int from, int to)
    {
        int product = 1;

        for (int i = from; i <= to; i++)
        {
            product *= array[i];
        }

        return product;
    }

    private int CalculateProductBetweenFirstZeroes()
    {
        (int first, int second) = GetIndexesOfFirstTwoZeroes();
        return CalculateProductOfRange(first + 1, second - 1);
    }

    private void SortArrayOddEvenIndexes()
    {
        int[] arrayClone = (int[])array.Clone();

        int i = 0;

        for (; i < (array.Length + 1) / 2; i++)
        {
            array[i] = arrayClone[i * 2];
        }

        for (int j = i; i < array.Length; i++)
        {
            array[i] = arrayClone[(i - j) * 2 + 1];
        }
    }
}