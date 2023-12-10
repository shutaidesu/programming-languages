namespace Lab1;

public class ArrayManipulator : IManipulator
{
    private readonly int[] array;

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
    }

    public void PrintResult()
    {
        throw new NotImplementedException();
    }

    public void ProcessData()
    {
        throw new NotImplementedException();
    }
}