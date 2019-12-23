using System.IO;
using System.Xml.Serialization;

namespace PizzaBox.Storing.Adapters
{
  public class FileAdapter
  {
    public static T ReadFromXml<T>(string path) where T : class
    {
      var xml = new XmlSerializer(typeof(T));
      var reader = new StreamReader(path);

      return xml.Deserialize(reader) as T;
    }

    public static void WriteToXml<T>(T data, string path)
    {
      var xml = new XmlSerializer(typeof(T));
      var writer = new StreamWriter(path);

      xml.Serialize(writer, data);
    }
  }
}