using UnityEngine;

public class DataManager : MonoBehaviour
{
    private IDataStorageStrategy dataStorageStrategy;

    public DataManager()
    {
        // Cambia tra LocalXMLStorage e RemoteAPIDataStorage a seconda delle tue esigenze
        dataStorageStrategy = new LocalXMLStorage("game_data");
        //dataStorageStrategy = new RemoteAPIDataStorage();
    }

    // Metodo per salvare i dati
    public void SaveData(GameData data)
    {
        dataStorageStrategy.SaveData(data);
    }

    // Metodo per caricare i dati
    public GameData LoadData()
    {
        return dataStorageStrategy.LoadData();
    }
}
