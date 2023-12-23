namespace Lab3;

public interface IDataManagement
{
    public void Load(IDataSource dataSource);

    public void Save(IDataSource dataSource);

    public void ClearHistory();

    public void AddHistoryEntity(HistoryEntity historyEntity);

    public List<HistoryEntity> GetHistory();
}