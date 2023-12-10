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
        throw new NotImplementedException();
    }

    public void Save(Data data)
    {
        throw new NotImplementedException();
    }
}
