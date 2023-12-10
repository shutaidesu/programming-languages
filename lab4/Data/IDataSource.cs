namespace Lab4;

public interface IDataSource
{
    public void Save(Data data);

    public Data Load();
}