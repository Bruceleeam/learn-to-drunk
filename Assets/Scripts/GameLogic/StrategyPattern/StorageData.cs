using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    private DataManager dataManager;

    private void Start()
    {
        dataManager = new DataManager();
    }

    private void SaveDataLocally()
    {
        DataObject data = new DataObject();
        data.value = 42; // Valore da salvare

        dataManager.SaveData(data);
        Debug.Log("Dati salvati localmente.");
    }

    private void SaveDataRemotely()
    {
        DataObject data = new DataObject();
        data.value = 99; // Valore da salvare

        dataManager.SaveData(data);
        Debug.Log("Dati salvati tramite API REST.");
    }

    private void LoadData()
    {
        DataObject loadedData = dataManager.LoadData();
        if (loadedData != null)
        {
            Debug.Log("Valore caricato: " + loadedData.value);
        }
        else
        {
            Debug.Log("Impossibile caricare i dati.");
        }
    }
}
