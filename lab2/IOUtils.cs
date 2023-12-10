namespace Lab2;


[Serializable]
public class InterruptionException : Exception
{
}


public static class IOUtils
{
    public static int ReadPositiveInt(string message)
    {
        while (true)
        {
            int result = ReadInt(message);
            if (result > 0)
            {
                return result;
            }
            Console.WriteLine("Необходимо ввести положительное число.");
        }
    }

    public static int ReadInt(string message, int min, int max)
    {
        while (true)
        {
            int result = ReadInt(message, min);
            if (result <= max)
            {
                return result;
            }
            Console.WriteLine("Необходимо ввести число не больше чем {0}.", max);
        }
    }

    public static int ReadInt(string message, int min)
    {
        while (true)
        {
            int result = ReadInt(message);
            if (result >= min)
            {
                return result;
            }
            Console.WriteLine("Необходимо ввести число не меньше чем {0}.", min);
        }
    }

    public static int ReadInt(string message)
    {
        Console.Write(message);
        while (true)
        {
            var line = Console.ReadLine();


            if (line == "exit")
            {
                throw new InterruptionException();
            }

            if (line == null)
            {
                Console.Write("Строка не может быть пустой. Введите целое число: ");
                continue;
            }

            try
            {
                {
                    return int.Parse(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка при получении числа: " + e.Message);
                Console.Write(message);
            }
        }
    }

    public static DateTime ReadDate()
    {
        var year = ReadInt("Input year: ", 1, 9999);
        var month = ReadInt("Input month: ", 1, 12);
        var day = ReadInt("Input day: ", 1, DateTime.DaysInMonth(year, month));
        return new DateTime(year, month, day);
    }

    internal static void PrintIntArray(int[] array)
    {
        Console.WriteLine(string.Join(" ", array));
    }

    internal static void PrintIntMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,4} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}