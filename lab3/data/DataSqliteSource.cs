using Microsoft.Data.Sqlite;

namespace Lab3;

internal class DataSqliteSource : IDataSource
{
    private readonly string filename;

    public DataSqliteSource(string filename)
    {
        this.filename = filename;
        CreateTable();
    }

    public void Save(Data data)
    {

        using (var connection = new SqliteConnection(string.Format("Data Source={0}", filename)))
        {
            connection.Open();
            data.History.ForEach(entity =>
            {
                InsertEntity(connection, entity);
            });
        }
    }

    public Data Load()
    {
        var data = new Data();

        using (var connection = new SqliteConnection(string.Format("Data Source={0}", filename)))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.Connection = connection;

            command.CommandText = """
SELECT id, command, message, executed_at FROM logs
""";
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetValue(0);
                        string comm = (string)reader.GetValue(1);
                        string message = (string)reader.GetValue(2);
                        DateTime time = DateTime.Parse((string)reader.GetValue(3));

                        data.History.Add(new HistoryEntity(comm, message, time));
                    }
                }
            }
        }

        return data;
    }

    private void InsertEntity(SqliteConnection connection, HistoryEntity entity)
    {
        SqliteCommand command = connection.CreateCommand();
        command.Connection = connection;

        command.CommandText = """
INSERT INTO logs (command, message, executed_at) VALUES (@command, @message, @executed_at)
""";
        SqliteParameter commandParam = new SqliteParameter("@command", entity.Command);
        command.Parameters.Add(commandParam);

        SqliteParameter messageParam = new SqliteParameter("@message", entity.Message);
        command.Parameters.Add(messageParam);

        SqliteParameter timeParam = new SqliteParameter("@executed_at", entity.DateTime);
        command.Parameters.Add(timeParam);

        command.ExecuteNonQuery();
    }

    private void DropTable()
    {
        using (var connection = new SqliteConnection(string.Format("Data Source={0}", filename)))
        {

            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = """
DROP TABLE IF EXISTS logs
""";
        }
    }

    private void CreateTable()
    {

        using (var connection = new SqliteConnection(string.Format("Data Source={0}", filename)))
        {
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.Connection = connection;

            command.ExecuteNonQuery();
            command.Connection = connection;

            command.CommandText = """
CREATE TABLE IF NOT EXISTS logs (
    id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
    command VARCHAR(255) NOT NULL,
    message TEXT NOT NULL,
    executed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)
""";
            command.ExecuteNonQuery();
        }
    }
}
