namespace lab4.Data;

internal class DataManagement : IDataManagement
{
    private HistoryData data;

    public DataManagement()
    {
        data = new HistoryData();
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
