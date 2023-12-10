using System.Numerics;

namespace Lab1;

public class MatrixManipulator : IManipulator
{
    private readonly int[,] matrix;

    private List<int> siblingIndexes;

    private int sumOfNegativeRows;


    public List<int> SiblingIndexes
    {
        get { return siblingIndexes; }
    }

    public int SumOfNegativeRows
    {
        get { return sumOfNegativeRows; }
    }


    public MatrixManipulator(int rows, int columns)
    {
        if (rows < 0 || columns < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rows) + " or " + nameof(columns));
        }

        matrix = new int[rows, columns];
        siblingIndexes = new List<int>();

        FillWithRandomValues();
    }

    public void FillWithRandomValues()
    {
        var random = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(Constants.MinRandomValue, Constants.MaxRandomValue);
            }
        }

        Console.WriteLine("Матрица заполнена случайными числами: ");
        IOUtils.PrintIntMatrix(matrix);
    }

    public void PrintResult()
    {
        Console.WriteLine("\n== Part 02. Results. =======\n");
        Console.WriteLine("Индексы совпадающих строк-колонок: ");
        IOUtils.PrintIntArray(siblingIndexes.ToArray());
        Console.WriteLine("Сумма строк с отрицательными элементами: " + SumOfNegativeRows);
        Console.WriteLine("\n== Part 02. Results End. ===\n");
    }

    public void ProcessData()
    {
        siblingIndexes = FindSiblingColumnWithRows();
        sumOfNegativeRows = SumOfRowsWithAtLeastOneNegative();
    }

    private int[] GetRow(int rowIndex)
    {
        int[] row = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            row[i] = matrix[rowIndex, i];
        }

        return row;
    }

    private int[] GetColumn(int columnIndex)
    {
        int[] column = new int[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            column[i] = matrix[i, columnIndex];
        }

        return column;
    }

    private List<int> FindSiblingColumnWithRows()
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new ArgumentException("Матрица обязана быть квадратной.");
        }

        var length = matrix.GetLength(0);

        List<int> result = new List<int>();

        for (int k = 0; k < length; k++)
        {
            var row = GetRow(k);
            var column = GetColumn(k);
            if (row.SequenceEqual(column))
            {
                result.Add(k);
            }
        }

        return result;
    }

    private int SumOfRowsWithAtLeastOneNegative()
    {
        var sum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            var rowSum = 0;
            var isSuitable = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                rowSum += matrix[i, j];
                if (matrix[i, j] < 0)
                {
                    isSuitable = true;
                }
            }
            if (isSuitable)
            {
                sum += rowSum;
            }
        }

        return sum;
    }

}