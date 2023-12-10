namespace Lab3;

internal class DataSqliteSource : IDataSource
{
    private readonly string filename;

    public DataSqliteSource(string filename)
    {
        this.filename = filename;
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
