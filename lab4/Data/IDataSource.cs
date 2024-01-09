namespace lab4.Data;

public interface IDataSource
{
    public void Save(HistoryData data);

    public HistoryData Load();
}