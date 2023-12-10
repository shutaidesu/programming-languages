using System.Runtime.ConstrainedExecution;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab4;

public class XmlDataSerializer : IDataSerializer
{
    public Data Deserialize(string content)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));

        using (TextReader reader = new StringReader(content))
        {
            return (Data)serializer.Deserialize(reader);
        }
    }

    public string Serialize(Data data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));
        var writer = new StringWriter();
        serializer.Serialize(writer, data);
        return writer.ToString();
    }
}