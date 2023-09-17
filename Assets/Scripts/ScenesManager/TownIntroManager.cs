using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TownIntroManager : MonoBehaviour
{
    public Text _townLabel;
    public Text _message;

    // Start is called before the first frame update
    void Start()
    {
        _townLabel.text = StaticGameData._gameData.NextTown;
        _message.text = "Town description";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
