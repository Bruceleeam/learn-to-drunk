using UnityEngine;

public class DataManager : MonoBehaviour
{
    private IDataStorageStrategy dataStorageStrategy;

    private void Start()
    {
        // Cambia tra LocalXMLStorage e RemoteAPIDataStorage a seconda delle tue esigenze
        dataStorageStrategy = new LocalXMLStorage("data_file");
        //dataStorageStrategy = new RemoteAPIDataStorage();
    }

    // Metodo per salvare i dati
    public void SaveData(DataObject data)
    {
        dataStorageStrategy.SaveData(data);
    }

    // Metodo per caricare i dati
    public DataObject LoadData()
    {
        return dataStorageStrategy.LoadData();
    }
}
