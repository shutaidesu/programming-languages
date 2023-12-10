namespace Lab3;

public interface IDataManagement
{
    public void Load(IDataManagement dataSource);

    public void Save(IDataManagement dataSource);

    public void AddHistoryEntity(HistoryEntity historyEntity);

    public List<HistoryEntity> GetHistory();
}