using lab4.Data;
using System.Runtime.ConstrainedExecution;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab4.Serializers;

public class XmlDataSerializer : IDataSerializer
{
    public HistoryData Deserialize(string content)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(HistoryData));

        using (TextReader reader = new StringReader(content))
        {
            return (HistoryData)serializer.Deserialize(reader);
        }
    }

    public string Serialize(HistoryData data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(HistoryData));
        var writer = new StringWriter();
        serializer.Serialize(writer, data);
        return writer.ToString();
    }
}