namespace Lab1;


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

    internal static void PrintIntArray(int[] array)
    {
        Console.WriteLine(string.Join(" ", array));
    }
}