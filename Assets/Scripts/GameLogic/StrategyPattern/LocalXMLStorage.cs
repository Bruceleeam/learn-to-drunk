using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class LocalXMLStorage : IDataStorageStrategy
{
    private string filePath;

    public LocalXMLStorage(string fileName)
    {
        filePath = Application.persistentDataPath + "/" + fileName + ".xml";
    }

    public void SaveData(DataObject data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DataObject));
        using (XmlWriter writer = XmlWriter.Create(filePath))
        {
            serializer.Serialize(writer, data);
        }
    }

    public DataObject LoadData()
    {
        if (System.IO.File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataObject));
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                return serializer.Deserialize(reader) as DataObject;
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            return null;
        }
    }
}
