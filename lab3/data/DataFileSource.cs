namespace Lab3;

internal class DataFileSource : IDataSource
{
    private readonly string filename;

    private readonly IDataSerializer serializer;

    public DataFileSource(string filename, IDataSerializer serializer)
    {
        this.filename = filename;
        this.serializer = serializer;
    }

    public Data Load()
    {
        var content = File.ReadAllText(filename);
        return serializer.Deserialize(content);
    }

    public void Save(Data data)
    {
        var content = serializer.Serialize(data);
        File.WriteAllText(filename, content);
    }
}
