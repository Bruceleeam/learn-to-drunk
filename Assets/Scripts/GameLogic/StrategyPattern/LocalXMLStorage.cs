using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class LocalXMLStorage : IDataStorageStrategy
{
    private string filePath;

    public LocalXMLStorage(string fileName)
    {
        filePath = Application.persistentDataPath + "/" + fileName + ".xml";
        Debug.Log("FILE PATH: " + filePath);
    }

    public void SaveData(GameData data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GameData));
        using (XmlWriter writer = XmlWriter.Create(filePath))
        {
            serializer.Serialize(writer, data);
        }
    }

    public GameData LoadData()
    {
        if (System.IO.File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameData));
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                return serializer.Deserialize(reader) as GameData;
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            return null;
        }
    }
}
