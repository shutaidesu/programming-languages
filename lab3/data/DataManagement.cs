namespace Lab3;

internal class DataManagement : IDataManagement
{
    private Data data;

    public DataManagement()
    {
        data = new Data();
    }

    public void AddHistoryEntity(HistoryEntity historyEntity)
    {
        data.History.Add(historyEntity);
    }

    public List<HistoryEntity> GetHistory()
    {
        return data.History;
    }

    public void ClearHistory()
    {
        data.History.Clear();
    }

    public void Load(IDataSource dataSource)
    {
        data = dataSource.Load();
    }

    public void Save(IDataSource dataSource)
    {
        dataSource.Save(data);
    }
}
