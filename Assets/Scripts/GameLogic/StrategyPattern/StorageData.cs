using System.Collections.Generic;
using UnityEngine;

public class StorageData : MonoBehaviour
{
    private DataManager dataManager;

    private void Awake()
    {
        dataManager = new DataManager();
    }

    public void SaveDataLocally(GameData data)
    {
        dataManager.SaveData(data);
        Debug.Log("Dati salvati localmente.");
    }

    public void SaveDataRemotely(GameData data)
    {
        dataManager.SaveData(data);
        Debug.Log("Dati salvati tramite API REST.");
    }

    public GameData LoadData()
    {
        GameData loadedData = dataManager.LoadData();
        if (loadedData != null)
        {
            Debug.Log("Valore caricato last town: " + loadedData.Town);
            Debug.Log("Valore caricato lifes: " + loadedData.Lifes);
            Debug.Log("Valore caricato lifes: " + loadedData.Unlocked.ToString());
        }
        else
        {
            Debug.Log("Impossibile caricare i dati.");
            loadedData = new GameData(3, null, new List<Card>());
        }

        return loadedData;
    }
}
