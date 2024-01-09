using lab4.Data;

namespace lab4.Serializers;

public interface IDataSerializer
{
    public string Serialize(HistoryData data);

    public HistoryData Deserialize(string content);
}