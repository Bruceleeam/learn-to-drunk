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
        _townLabel.text = StaticGameData._gameData._lastTown;
        StartCoroutine(PlayGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayGame()
    {
        _message.text = "Messaggio pre-partita";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Game");
    }
}
