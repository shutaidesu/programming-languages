namespace Lab4;

public interface IDataSerializer
{
    public string Serialize(Data data);

    public Data Deserialize(string content);
}