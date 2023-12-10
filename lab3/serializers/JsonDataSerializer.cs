using System.Text.Json;

namespace Lab3;

public class JsonDataSerializer : IDataSerializer
{
    public Data Deserialize(string content)
    {
        throw new NotImplementedException();
    }

    public string Serialize(Data data)
    {
        return JsonSerializer.Serialize(data);
    }
}