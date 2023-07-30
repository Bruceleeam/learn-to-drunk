using UnityEngine;

public class StorageData : MonoBehaviour
{
    private DataManager dataManager;

    private void Start()
    {
        dataManager = new DataManager();
    }

    private void SaveDataLocally(DataObject data)
    {
        dataManager.SaveData(data);
        Debug.Log("Dati salvati localmente.");
    }

    private void SaveDataRemotely(DataObject data)
    {
        dataManager.SaveData(data);
        Debug.Log("Dati salvati tramite API REST.");
    }

    private DataObject LoadData()
    {
        DataObject loadedData = dataManager.LoadData();
        if (loadedData != null)
        {
            Debug.Log("Valore caricato last town: " + loadedData._lastTown);
            Debug.Log("Valore caricato lifes: " + loadedData._lifes);
        }
        else
        {
            Debug.Log("Impossibile caricare i dati.");
        }

        return loadedData;
    }
}
