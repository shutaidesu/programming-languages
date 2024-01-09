using lab4.Serializers;

namespace lab4.Data;

internal class DataFileSource : IDataSource
{
    private readonly string filename;

    private readonly IDataSerializer serializer;

    public DataFileSource(string filename, IDataSerializer serializer)
    {
        this.filename = filename;
        this.serializer = serializer;
    }

    public HistoryData Load()
    {
        var content = File.ReadAllText(filename);
        return serializer.Deserialize(content);
    }

    public void Save(HistoryData data)
    {
        var content = serializer.Serialize(data);
        File.WriteAllText(filename, content);
    }
}
