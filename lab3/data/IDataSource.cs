namespace Lab3;

public interface IDataSource
{
    public void Save(Data data);

    public Data Load();
}