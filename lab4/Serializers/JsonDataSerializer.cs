using lab4.Data;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab4.Serializers;

public class JsonDataSerializer : IDataSerializer
{
    public HistoryData Deserialize(string content)
    {
        return JsonSerializer.Deserialize<HistoryData>(content);
    }

    public string Serialize(HistoryData data)
    {
        return JsonSerializer.Serialize(data);
    }
}