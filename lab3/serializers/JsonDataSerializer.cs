using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab3;

public class JsonDataSerializer : IDataSerializer
{
    public Data Deserialize(string content)
    {
        return JsonSerializer.Deserialize<Data>(content);
    }

    public string Serialize(Data data)
    {
        return JsonSerializer.Serialize(data);
    }
}