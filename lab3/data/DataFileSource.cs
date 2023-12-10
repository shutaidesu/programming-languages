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

    public void Load()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}
