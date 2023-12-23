namespace Lab3;

public enum FileType
{
    Xml,
    Json,
    Sqlite,

    Cancel
}

public class SaveCommand : Command<HistoryEntity>
{
    public SaveCommand() : base("save", "save the history to file")
    {
    }

    public class XmlCommand : Command<FileType>
    {
        public XmlCommand() : base("xml", "сохранить в файл в формате xml")
        {
        }

        public override FileType Execute()
        {
            return FileType.Xml;
        }
    }

    public class JsonCommand : Command<FileType>
    {
        public JsonCommand() : base("json", "сохранить в файл в формате json")
        {
        }

        public override FileType Execute()
        {
            return FileType.Json;
        }
    }

    public class SqliteCommand : Command<FileType>
    {
        public SqliteCommand() : base("sqlite", "сохранить в файл в формате sqlte")
        {
        }

        public override FileType Execute()
        {
            return FileType.Sqlite;
        }
    }

    public class CancelCommand : Command<FileType>
    {
        public CancelCommand() : base("cancel", "отмена")
        {
        }

        public override FileType Execute()
        {
            return FileType.Cancel;
        }
    }

    public override HistoryEntity Execute()
    {

        var commandManager = new SingleCommandManager<FileType>();
        commandManager.RegisterCommand(new JsonCommand());
        commandManager.RegisterCommand(new XmlCommand());
        commandManager.RegisterCommand(new SqliteCommand());
        commandManager.RegisterCommand(new CancelCommand());

        var fileType = commandManager.Run();

        string filename;
        IDataSource dataSource;

        switch (fileType)
        {
            case FileType.Xml:
                {
                    filename = "data.xml";
                    var serializer = new XmlDataSerializer();
                    dataSource = new DataFileSource(filename, serializer);
                    break;
                }
            case FileType.Json:
                {
                    filename = "data.json";
                    var serializer = new JsonDataSerializer();
                    dataSource = new DataFileSource(filename, serializer);
                    break;
                }
            case FileType.Sqlite:
                {
                    filename = "data.sqlite";
                    dataSource = new DataSqliteSource(filename);
                    break;
                }
            case FileType.Cancel:
                {
                    return new HistoryEntity(this, "Load canceled.");
                }
            default:
                {
                    throw new ArgumentException();
                }
        }

        Application.DataManagement.Save(dataSource);

        Console.Write("История успешно сохранена в ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("{0}", filename);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(".\n");

        return new HistoryEntity(this, "Saved.");
    }
}