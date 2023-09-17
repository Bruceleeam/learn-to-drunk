using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SynchronizationManager : MonoBehaviour
{

    public StorageData _storageData;

    // Start is called before the first frame update
    void Start()
    {
        //CheckNetworking
        // OFFLINE MODE -> add check networking api
        if (StaticSettings.OFFLINE_MODE)
        {
            StaticGameData._gameData = _storageData.GetComponent<StorageData>().LoadData();
            SceneManager.LoadScene("Menu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
