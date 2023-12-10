namespace Lab3;

internal class DataSqliteSource : IDataSource
{
    private readonly string filename;

    public DataSqliteSource(string filename)
    {
        this.filename = filename;
    }

    public void Save(Data data)
    {
        throw new NotImplementedException();
    }

    public Data Load()
    {
        throw new NotImplementedException();
    }
}
