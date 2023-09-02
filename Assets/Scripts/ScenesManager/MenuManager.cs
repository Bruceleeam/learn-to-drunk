using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject _cardButtonsContent;
    public GameObject _cocktailCardBtn;
    public GameObject _cocktailCard;
    public Text _cocktailCardTitle;
    public Text _cocktailCardDesc;
    public GameObject _continue;
    //public List<Cocktail> _cocktails = new List<Cocktail>();

    // Start is called before the first frame update
    void Start()
    {
        if (StaticGameData._gameData.Town != null && StaticGameData._gameData.Lifes > 0)
            _continue.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        StaticGameData._gameData = new GameData(3, null, StaticGameData._gameData.Unlocked);
        SceneManager.LoadScene("Map");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Map");
    }

    public void ClearCard()
    {
        _cocktailCardTitle.text = "";
        _cocktailCardDesc.text = "";
    }
}
