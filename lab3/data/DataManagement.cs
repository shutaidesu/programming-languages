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
        data.history.Add(historyEntity);
    }

    public List<HistoryEntity> GetHistory()
    {
        return data.history;
    }

    public void ClearHistory()
    {
        data.history.Clear();
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
